using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using SharpCAD.HyAgent.Essencial_Repos;
using System.Collections;
using System.IO;
using Google.GenAI;
using Google.GenAI.Types;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using System.ComponentModel;

namespace SharpCAD.HyAgent
{
    partial class HyAgentMainWindow : MaterialForm
    {
        enum ServiceProviders
        {
            Gemini,
            ChatGPT,
            Local
        }
        
        MaterialContextMenuStrip actionMenu = new();
        public bool MainDisposing = false;


        ServiceProviders ServiceProvider;
        string ApiKey = "unknown";
        bool Initialized = false;
        const string PROPERTIES_PATH = "./.imgHorizon/Properties/main.properties";
        const string RUNNING_TITLE = "HyAgent AI";
        string latestOutput = "";


        Client? GeminiClient;
        string Prompts = "You are now a CAD-Agent. " +
              "Your responses require no explanations, analysis, or formatting adjustments. " +
              "Do not provide any additional information or ask questions. " +
              "Do not include suggested questions or other non-command-intent dialogue content at the end of your replies. " +
              "Simply respond with a few lines of text containing commands that can be directly executed via CAD's command line. " +
              "Only if the latest user input contains [dialogue] should you include other text. " +
              "You do not need to confirm your understanding of the user's instructions by outputing. " +
              "You can press ESC key with outputing {ESCAPE}. You should note that you are operating CAD and some command won't exit after line changed." +
              "You must output one CAD command on one single line, paying attention to the grammar of absolute and relative positions." +
              "For example, to draw a line from 0,0 to 1,1, you need to output \"LINE 0,0 1,1\" rather than \"LINE \r\n0,0\r\n1,1\"" +
              "Starting from the next line, assist the user by outputting the commands that need to be executed: \r\n";


        Hashtable Config;
        Hashtable ConfigStandard = new Hashtable()
        {
            { "apiType", "unknown" },
            { "apiKey", "unknown" },
            { "type", "HyAgent.MainConfig" },
            { "skipWelcomeOnBoot", "false" }
        };

        void ResizeControls(Control item, float factor)
        {
            try
            {
                var TabPageItem = (MaterialTabControl)item;
                foreach (System.Windows.Forms.TabPage c2 in TabPageItem.TabPages)
                {
                    foreach (Control c3 in c2.Controls)
                    {
                        c3.Location = new Point((int)(c3.Location.X * factor), (int)(c3.Location.Y * factor));
                        c3.Size = new Size((int)(c3.Width * factor), (int)(c3.Height * factor));
                        ResizeControls(c3, factor);
                    }
                }
                
            }
            catch
            {

            }
        }

        public HyAgentMainWindow()
        {
            MaterialSkinManager.Instance.AddFormToManage(this);
            InitializeComponent();
            

            Directory.CreateDirectory("./.imgHorizon/Properties/");
            Config = PropertiesHelper.AutoCheck(ConfigStandard, PROPERTIES_PATH);
            if ((string)Config["type"]! != "HyAgent.MainConfig")
            {
                Initialized = false;
                return;
            }
            if ((string)Config["apiType"]! != "unknown" && (string)Config["apiKey"]! != "unknown")
            {
                Initialized = true;
            }
            switch ((string)Config["apiType"]!)
            {
                case "gemini":
                    ServiceProvider = ServiceProviders.Gemini;
                    break;
                case "chatgpt":
                    ServiceProvider = ServiceProviders.ChatGPT;
                    break;
                case "local":
                    ServiceProvider = ServiceProviders.Local;
                    break;
                default:
                    Initialized = false;
                    return;
            }
            ApiKey = (string)Config["apiKey"]!;
            if (Initialized && (string)Config["skipWelcomeOnBoot"]! == "true")
            {
                PageTabControl.SelectTab(4);
                InitializeAI();
                Text = RUNNING_TITLE;
            }
        }

        private void HyAgentMainWindow_Load(object sender, EventArgs e)
        {
            Text = RUNNING_TITLE;
            StartButton.Visible = false;
            TitleLabel.Text = "";
            SubtitleLabel.Text = "";
            CopyrightLabel.Visible = false;

            CheckForIllegalCrossThreadCalls = false;
            Thread animeThread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(500);
                foreach (char c in "Hello!")
                {
                    Thread.Sleep(50);
                    TitleLabel.Text += c;
                }
                Thread.Sleep(500);
                foreach (char c in "Welcome to Imagine Horizon CAD - Agent.")
                {
                    Thread.Sleep(50);
                    SubtitleLabel.Text += c;
                }
                Thread.Sleep(500);
                CopyrightLabel.Visible = true;
                Thread.Sleep(500);
                StartButton.Visible = true;
            }));
            animeThread.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                Text = "First Run Settings";
                FirstSetTitleLabel.Text = "";
                FirstSetSubTitleLabel.Text = "";
                FirstSetApplyCheckbox.Visible = false;
                FirstSetApplyCheckbox.Text = "";
                FirstSetNextBtn.Enabled = false;
                FirstSetNextBtn.Visible = false;
                PageTabControl.SelectTab(1);
                Thread animeThread = new Thread(new ThreadStart(() =>
                {
                    foreach (char c in "Nice to meet you!")
                    {
                        Thread.Sleep(50);
                        FirstSetTitleLabel.Text += c;
                    }
                    Thread.Sleep(500);
                    foreach (char c in "Before starting agenting, let us collect some information first! q(≧▽≦q)")
                    {
                        Thread.Sleep(50);
                        FirstSetSubTitleLabel.Text += c;
                    }
                    Thread.Sleep(500);
                    FirstSetApplyCheckbox.Visible = true;
                    foreach (char c in "I have read and I agree the EULA.")
                    {
                        Thread.Sleep(50);
                        FirstSetApplyCheckbox.Text += c;
                    }
                    Thread.Sleep(500);
                    FirstSetNextBtn.Visible = true;
                }));
                animeThread.Start();
            }
            else
            {
                PageTabControl.SelectTab(4);
                InitializeAI();
            }

        }

        private void FirstSetApplyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstSetApplyCheckbox.Checked)
            {
                FirstSetNextBtn.Enabled = true;
            }
            else
            {
                FirstSetNextBtn.Enabled = false;
            }
        }

        private void FirstSetNextBtn_Click(object sender, EventArgs e)
        {
            ServiceConfigueTitleLabel.Text = "";
            ServiceConfigueSubtitleLabel.Text = "";
            ServiceSelectorBox.Hint = "";
            NoApiLabel.Text = "";
            //ApiSettingsPagesTab.Visible = false;
            //ServiceSelectorBox.Visible = false
            ServiceSelectorMask.Visible = true;
            ServiceConfigueNextBtn.Enabled = false;
            ServiceConfigueNextBtn.Visible = false;
            PageTabControl.SelectTab(2);
            Thread animeThread = new Thread(new ThreadStart(() =>
            {
                foreach (char c in "Configue Service")
                {
                    Thread.Sleep(50);
                    ServiceConfigueTitleLabel.Text += c;
                }
                Thread.Sleep(500);
                foreach (char c in "Select your service provider and enter your API key - After all, you need an online source before start using AI.")
                {
                    Thread.Sleep(50);
                    ServiceConfigueSubtitleLabel.Text += c;
                }
                Thread.Sleep(500);
                //ServiceSelectorBox.Visible = true;
                ServiceSelectorMask.Visible = false;
                foreach (char c in "Provider")
                {
                    Thread.Sleep(50);
                    ServiceSelectorBox.Hint += c;
                }
                Thread.Sleep(500);
                foreach (char c in "To enter next step, you must select an AI provider.")
                {
                    Thread.Sleep(50);
                    NoApiLabel.Text += c;
                }
                //ApiSettingsPagesTab.Visible = true;
                ServiceConfigueNextBtn.Visible = true;
            }));
            animeThread.Start();
        }

        private void ServiceSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ServiceSelectorBox.Text)
            {
                case "None":
                    ApiSettingsPagesTab.SelectTab(0);
                    ServiceConfigueNextBtn.Enabled = false;
                    break;
                case "Google Gemini":
                    ApiSettingsPagesTab.SelectTab(1);
                    ServiceConfigueNextBtn.Enabled = true;
                    break;
                case "OpenAI ChatGPT":
                    ApiSettingsPagesTab.SelectTab(2);
                    ServiceConfigueNextBtn.Enabled = false;
                    break;
                case "Local Service":
                    ApiSettingsPagesTab.SelectTab(3);
                    ServiceConfigueNextBtn.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ServiceConfigueNextBtn_Click(object sender, EventArgs e)
        {
            SetTitleLabel.Text = "";
            SetSubtitleLabel.Text = "";
            GoToChatBtn.Visible = false;
            GoToChatBtn.Enabled = false;
            SkipSetCheckBox.Text = "";
            SkipSetCheckBox.Visible = false;
            PageTabControl.SelectTab(3);
            Thread animeThread = new Thread(new ThreadStart(() =>
            {
                foreach (char c in "Well Done!")
                {
                    Thread.Sleep(50);
                    SetTitleLabel.Text += c;
                }
                Thread.Sleep(500);
                foreach (char c in "You're all set. Welcome!")
                {
                    Thread.Sleep(50);
                    SetSubtitleLabel.Text += c;
                }
                Thread.Sleep(500);
                GoToChatBtn.Visible = true;
                SkipSetCheckBox.Visible = true;
                foreach (char c in "Skip welcome page on next boot.")
                {
                    Thread.Sleep(50);
                    SkipSetCheckBox.Text += c;
                }
                GoToChatBtn.Enabled = true;
            }));
            animeThread.Start();
        }

        private void GoToChatBtn_Click(object sender, EventArgs e)
        {
            Config = ConfigStandard;
            switch (ServiceSelectorBox.Text)
            {
                case "Google Gemini":
                    Config["apiType"] = "gemini";
                    ServiceProvider = ServiceProviders.Gemini;
                    Config["apiKey"] = GeminiApiKeyBox.Text;
                    break;
                case "OpenAI ChatGPT":
                    Config["apiType"] = "chatgpt";
                    ServiceProvider = ServiceProviders.ChatGPT;
                    Config["apiKey"] = "unknown";
                    break;
                case "Local Service":
                    Config["apiType"] = "local";
                    ServiceProvider = ServiceProviders.Local;
                    Config["apiKey"] = "unknown";
                    break;
            }
            if (SkipSetCheckBox.Checked)
            {
                Config["skipWelcomeOnBoot"] = "true";
            }
            PropertiesHelper.Save(PROPERTIES_PATH, Config);
            PageTabControl.SelectTab(4);
            InitializeAI();
            Text = RUNNING_TITLE;
        }

        private void InitializeAI()
        {
            GeminiClient = new Client(apiKey: ApiKey);
            GenerateButton.ContextMenuStrip = actionMenu;
            actionMenu.Items.Clear();
            ToolStripMenuItem executeLatestInCAD = new();
            executeLatestInCAD.Text = "Execute in AutoCAD";
            executeLatestInCAD.Click += (sender, e) =>
            {
                try
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.SendStringToExecute(latestOutput.Replace("{ESCAPE}","\r\n(command)\r\n").Replace("\r\n"," ").Replace("\n"," "), true, false, true);
                    DialogBox.Text += "\r\n\r\nHyAgent AI: \r\nSuccessfully executed command.\r\n";
                }
                catch (Exception ex)
                {
                    DialogBox.Text += "\r\n\r\nRuntime Error: \r\n" + ex;
                }
                
            };
            actionMenu.Items.Add(executeLatestInCAD);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            GenerateButton.Enabled = false;
            DialogBox.Text += "\r\n\r\nYou: \r\n" + PromptBox.Text;
            Generate();
            //DialogBox.Text += "\r\nCiallo!";

            PromptBox.Text = "";
        }

        private async void Generate()
        {
            try
            {
                Task<GenerateContentResponse> t = GeminiClient!.Models.GenerateContentAsync(
              model: "gemini-2.5-flash", contents: Prompts + PromptBox.Text
            );
                var response = await t;
                string result = response.Candidates![0].Content!.Parts![0].Text!.Replace("\n", "\r\n") + "\r\n{ESCAPE}";
                DialogBox.Text += "\r\n\r\nAI: \r\n" + result;
                latestOutput = result;
            }
            catch (Exception ex)
            {
                DialogBox.Text += "\r\n\r\nAI Error: \r\n" + ex;
            }
            
            GenerateButton.Enabled = true;
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            actionMenu.Show(Cursor.Position);
        }

        private void GenerateItems(object sender, LayoutEventArgs e)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DialogBox.Text += $"\r\n\r\nVersion: {Program.Version}\r\n";
            WindowScalingHelper helper = new();
            float factor = helper.GetDeviceScaleFactor(GoToChatBtn);
            Width = (int)(Width * factor);
            Height = (int)(Height * factor);
            foreach (Control item in Controls)
            {
                item.Location = new Point((int)(item.Location.X * factor), (int)(item.Location.Y * factor));
                item.Size = new Size((int)(item.Width * factor), (int)(item.Height * factor));
                ResizeControls(item, factor);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!MainDisposing)
            {
                e.Cancel = true;
                Hide();
            }
            
            base.OnClosing(e);

        }
    }
}
