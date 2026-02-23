
using Autodesk.AutoCAD.Windows.ToolPalette;
using System;
using System.Collections.Generic;
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
        }

        public class UsageInfo
        {
            [JsonPropertyName("total_tokens")]
            public int TotalTokens { get; set; }
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
            public async Task<DeepseekResponse> GenerateTextAsync(string SystemInstructions = DEFAULT_SYS_PROMPT, string Prompts = "", string Model = "deepseek-chat")
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
