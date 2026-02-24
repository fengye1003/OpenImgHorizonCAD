
using Autodesk.AutoCAD.Windows.ToolPalette;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImgHorizon.HyAgent.AIHelpers
{
    namespace DeepseekApi
    {
        public class RequestJson
        {

            [JsonPropertyName("model")]
            public string Model { get; set; } = "deepseek-chat";

            [JsonPropertyName("messages")]
            public List<ChatMessage> Messages { get; set; } = new();

            [JsonPropertyName("stream")]
            public bool IsStream { get; set; } = false;

            [JsonPropertyName("thinking")]
            ThinkingOption Thinking { get; set; } = new();

            public bool EnableThinking
            {
                get
                {
                    return Thinking.Type == "enabled";
                }
                set
                {
                    if (value)
                    {
                        Thinking.Type = "enabled";
                    }
                    else
                    {
                        Thinking.Type = "disabled";
                    }
                }
            }
        }

        public class ChatMessage
        {
            [JsonPropertyName("role")]
            public string Role { get; set; } = "user";

            [JsonPropertyName("content")]
            public string Content { get; set; } = "";

            public ChatMessage()
            {

            }

            public ChatMessage(string Role, string Content)
            {
                this.Role = Role;
                this.Content = Content;
            }
        }

        public class DeepseekResponse
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = "";

            [JsonPropertyName("choices")]
            public List<Choice> Choices { get; set; } = new();

            [JsonPropertyName("usage")]
            public UsageInfo? Usage { get; set; }
        }

        public class Choice
        {
            [JsonPropertyName("message")]
            public ResponseMessage Message { get; set; } = new();

            [JsonPropertyName("finish_reason")]
            public string FinishReason { get; set; } = "";
        }

        public class ResponseMessage
        {
            [JsonPropertyName("role")]
            public string Role { get; set; } = "";

            [JsonPropertyName("content")]
            public string Content { get; set; } = "";
            [JsonPropertyName("reasoning_content")]
            public string ReasoningContent { get; set; } = "";
        }

        public class ThinkingOption
        {
            [JsonPropertyName("type")]
            public string Type = "disabled";
        }

        public class UsageInfo
        {
            [JsonPropertyName("total_tokens")]
            public int TotalTokens { get; set; }
        }

        /// <summary>
        /// 流式返回的根对象
        /// </summary>
        public class DeepSeekStreamResponse
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = string.Empty;

            [JsonPropertyName("object")]
            public string Object { get; set; } = string.Empty;

            [JsonPropertyName("created")]
            public long Created { get; set; }

            [JsonPropertyName("model")]
            public string Model { get; set; } = string.Empty;

            [JsonPropertyName("system_fingerprint")]
            public string SystemFingerprint { get; set; } = string.Empty;

            [JsonPropertyName("choices")]
            public List<StreamChoice> Choices { get; set; } = new();
        }

        public class StreamChoice
        {
            [JsonPropertyName("index")]
            public int Index { get; set; }

            /// <summary>
            /// 注意：流式返回中，内容在 delta 字段而不是 message 字段
            /// </summary>
            [JsonPropertyName("delta")]
            public DeltaContent Delta { get; set; } = new();

            [JsonPropertyName("logprobs")]
            public object? Logprobs { get; set; }

            [JsonPropertyName("finish_reason")]
            public string? FinishReason { get; set; }
        }

        public class DeltaContent
        {
            /// <summary>
            /// 角色（通常只在第一块返回中出现）
            /// </summary>
            [JsonPropertyName("role")]
            public string? Role { get; set; }

            /// <summary>
            /// 真正的文本片段
            /// </summary>
            [JsonPropertyName("content")]
            public string Content { get; set; } = string.Empty;

            [JsonPropertyName("reasoning_content")]
            public string ReasoningContent { get; set; } = string.Empty;
        }

        public class ProgressReport
        {
            public ProgressReport()
            {

            }

            public ProgressReport(ProgressTypes type, string report)
            {
                ProgressType = type;
                Report = report;
            }

            public enum ProgressTypes
            {
                Reasoning,
                Chat
            }
            public ProgressTypes ProgressType;
            public string Report = string.Empty;
        }

        public class Client
        {
            string ApiKey;
            const string DEFAULT_SYS_PROMPT = "You are a helpful assistant.";
            const string DEEPSEEK_API = "https://api.deepseek.com/chat/completions";
            const string DEEPSEEK_API_SUPPORT_OPENAI = "https://api.deepseek.com/v1/chat/completions";
            public bool SupportOpenAI = false;
            public Client(string key)
            {
                ApiKey = key;
            }

            public async Task<DeepseekResponse> GenerateTextAsync(string SystemInstructions = DEFAULT_SYS_PROMPT, string Prompts = "", string Model = "deepseek-chat", bool Thinking = false)
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, SupportOpenAI ? DEEPSEEK_API_SUPPORT_OPENAI : DEEPSEEK_API);
                var headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "Authorization", $"Bearer {ApiKey}" }
                };

                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }

                RequestJson payload = new();
                payload.IsStream = false;
                payload.Model = Model;
                if (Thinking)
                {
                    payload.EnableThinking = true;
                }
                payload.Messages = new List<ChatMessage>
                {
                    new ChatMessage("system", SystemInstructions),
                    new ChatMessage("user", Prompts)
                };
                //MessageBox.Show(JsonSerializer.Serialize(payload));
                request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                string jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                DeepseekResponse? result = JsonSerializer.Deserialize<DeepseekResponse>(jsonString, options);

                return result!;
            }

            public async Task<string> GenerateTextStreamAsync(HyAgentMainWindow ui, IProgress<bool> progress, string SystemInstructions = DEFAULT_SYS_PROMPT, string Prompts = "", string Model = "deepseek-chat", bool Thinking = false)
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, SupportOpenAI ? DEEPSEEK_API_SUPPORT_OPENAI : DEEPSEEK_API);
                var headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "Authorization", $"Bearer {ApiKey}" }
                };

                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }

                RequestJson payload = new();
                payload.IsStream = true;
                payload.Model = Model;
                if (Thinking)
                {
                    payload.EnableThinking = true;
                }
                payload.Messages = new List<ChatMessage>
                {
                    new ChatMessage("system", SystemInstructions),
                    new ChatMessage("user", Prompts)
                };
                //MessageBox.Show(JsonSerializer.Serialize(payload));
                request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                using var stream = await response.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    string? line = await reader.ReadLineAsync();
                    if (line != null)
                    {
                        // 1. 去掉 SSE 前缀 "data: "
                        if (line.StartsWith("data: "))
                        {
                            string json = line.Length > 5 ? line.Substring(5).TrimStart() : "";
                            
                            // 2. 结束标志检查
                            if (json == "[DONE]") break;

                            try
                            {
                                // 3. 解析 delta 片段
                                var chunk = JsonSerializer.Deserialize<DeepSeekStreamResponse>(json);

                                string? reasoning = chunk?.Choices?[0]?.Delta?.ReasoningContent;

                                if (reasoning != null)
                                {
                                    ui.DsOutputQueue.Add(new ProgressReport(ProgressReport.ProgressTypes.Reasoning, reasoning));
                                    // 通过 Progress 报告给 UI 线程
                                    while (ui.DsRefreshingUI)
                                    {
                                        Thread.Sleep(1);
                                    }
                                    progress.Report(true);
                                }

                                string? content = chunk?.Choices?[0]?.Delta?.Content;

                                if (content != null)
                                {
                                    ui.DsOutputQueue.Add(new ProgressReport(ProgressReport.ProgressTypes.Chat, content));
                                    //MessageBox.Show(json);
                                    // 4. 通过 Progress 报告给 UI 线程
                                    while (ui.DsRefreshingUI)
                                    {
                                        Thread.Sleep(1);
                                    }
                                    progress.Report(true);
                                }
                            }
                            catch { /* 忽略不完整的 JSON 行 */ }
                        }
                    }
                    ;
                }

                return "result";
            }

            public string ParseDeepSeekReasoningResponse(DeepseekResponse response)
            {
                try
                {
                    if (response?.Choices != null && response.Choices.Count > 0)
                    {
                        return response.Choices[0].Message.ReasoningContent;
                    }

                    return "Error: Unable to parse. RAW = " + JsonSerializer.Serialize(response);

                }
                catch (Exception ex)
                {
                    return $"Error: JSON parse error - {ex.Message}\r\nRAW:\r\n" + JsonSerializer.Serialize(response);
                }
            }
            public string ParseDeepSeekReasoningResponse(string jsonRaw)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                DeepseekResponse response = JsonSerializer.Deserialize<DeepseekResponse>(jsonRaw, options)!;
                return ParseDeepSeekReasoningResponse(response!);
            }

            public string ParseDeepSeekResponse(DeepseekResponse response)
            {
                try
                {
                    if (response?.Choices != null && response.Choices.Count > 0)
                    {
                        return response.Choices[0].Message.Content;
                    }

                    return "Error: Unable to parse. RAW = " + JsonSerializer.Serialize(response);

                }
                catch (Exception ex)
                {
                    return $"Error: JSON parse error - {ex.Message}\r\nRAW:\r\n" + JsonSerializer.Serialize(response);
                }
            }

            public string ParseDeepSeekResponse(string jsonRaw)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                DeepseekResponse response = JsonSerializer.Deserialize<DeepseekResponse>(jsonRaw, options)!;
                return ParseDeepSeekResponse(response!);
            }
        }
    }
}
