using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCAD.HyAgent
{
    partial class HyAgentMainWindow : MaterialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleLabel = new MaterialLabel();
            SubtitleLabel = new MaterialLabel();
            StartButton = new MaterialButton();
            CopyrightLabel = new MaterialLabel();
            PageTabControl = new MaterialTabControl();
            WelcomePage = new System.Windows.Forms.TabPage();
            BootSettingsLandPage = new System.Windows.Forms.TabPage();
            FirstSetApplyCheckbox = new MaterialCheckBox();
            FirstSetNextBtn = new MaterialButton();
            FirstSetSubTitleLabel = new MaterialLabel();
            FirstSetTitleLabel = new MaterialLabel();
            ConfigueServicePage = new System.Windows.Forms.TabPage();
            ServiceSelectorMask = new MaterialLabel();
            ApiSettingsPagesTab = new MaterialTabControl();
            None = new System.Windows.Forms.TabPage();
            NoApiLabel = new MaterialLabel();
            Gemini = new System.Windows.Forms.TabPage();
            GeminiApiKeyBox = new MaterialTextBoxEdit();
            ChatGPT = new System.Windows.Forms.TabPage();
            materialLabel2 = new MaterialLabel();
            Local = new System.Windows.Forms.TabPage();
            materialLabel3 = new MaterialLabel();
            ServiceSelectorBox = new MaterialComboBox();
            ServiceConfigueNextBtn = new MaterialButton();
            ServiceConfigueSubtitleLabel = new MaterialLabel();
            ServiceConfigueTitleLabel = new MaterialLabel();
            DoneSettingPage = new System.Windows.Forms.TabPage();
            SkipSetCheckBox = new MaterialCheckBox();
            SetTitleLabel = new MaterialLabel();
            SetSubtitleLabel = new MaterialLabel();
            GoToChatBtn = new MaterialButton();
            DialogPage = new System.Windows.Forms.TabPage();
            aiOperationBtn = new MaterialFloatingActionButton();
            GenerateButton = new MaterialButton();
            PromptBox = new MaterialMultiLineTextBoxEdit();
            DialogBox = new MaterialMultiLineTextBoxEdit();
            PageTabControl.SuspendLayout();
            WelcomePage.SuspendLayout();
            BootSettingsLandPage.SuspendLayout();
            ConfigueServicePage.SuspendLayout();
            ApiSettingsPagesTab.SuspendLayout();
            None.SuspendLayout();
            Gemini.SuspendLayout();
            ChatGPT.SuspendLayout();
            Local.SuspendLayout();
            DoneSettingPage.SuspendLayout();
            DialogPage.SuspendLayout();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Depth = 0;
            TitleLabel.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            TitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            TitleLabel.Location = new Point(32, 209);
            TitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(123, 58);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Hello!";
            // 
            // SubtitleLabel
            // 
            SubtitleLabel.Depth = 0;
            SubtitleLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            SubtitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            SubtitleLabel.Location = new Point(32, 273);
            SubtitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            SubtitleLabel.Name = "SubtitleLabel";
            SubtitleLabel.Size = new Size(272, 70);
            SubtitleLabel.TabIndex = 1;
            SubtitleLabel.Text = "Welcome to Imagine Horizon CAD - Agent.";
            // 
            // StartButton
            // 
            StartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartButton.Density = MaterialButton.MaterialButtonDensity.Default;
            StartButton.Depth = 0;
            StartButton.HighEmphasis = true;
            StartButton.Icon = null;
            StartButton.IconType = MaterialButton.MaterialIconType.Rebase;
            StartButton.Location = new Point(32, 349);
            StartButton.Margin = new Padding(4, 6, 4, 6);
            StartButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            StartButton.Name = "StartButton";
            StartButton.NoAccentTextColor = Color.Empty;
            StartButton.Size = new Size(102, 36);
            StartButton.TabIndex = 2;
            StartButton.Text = "LET'S DO IT!";
            StartButton.Type = MaterialButton.MaterialButtonType.Contained;
            StartButton.UseAccentColor = false;
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // CopyrightLabel
            // 
            CopyrightLabel.Depth = 0;
            CopyrightLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            CopyrightLabel.Location = new Point(32, 596);
            CopyrightLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            CopyrightLabel.Name = "CopyrightLabel";
            CopyrightLabel.Size = new Size(300, 74);
            CopyrightLabel.TabIndex = 3;
            CopyrightLabel.Text = "Copyright 2016 - 2016 (C)  teko.IO SisTemS!™ All rights reserved. Work by NJUT with <3";
            // 
            // PageTabControl
            // 
            PageTabControl.Controls.Add(WelcomePage);
            PageTabControl.Controls.Add(BootSettingsLandPage);
            PageTabControl.Controls.Add(ConfigueServicePage);
            PageTabControl.Controls.Add(DoneSettingPage);
            PageTabControl.Controls.Add(DialogPage);
            PageTabControl.Depth = 0;
            PageTabControl.Location = new Point(6, 67);
            PageTabControl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            PageTabControl.Multiline = true;
            PageTabControl.Name = "PageTabControl";
            PageTabControl.SelectedIndex = 0;
            PageTabControl.Size = new Size(371, 727);
            PageTabControl.TabIndex = 4;
            // 
            // WelcomePage
            // 
            WelcomePage.BackColor = Color.Transparent;
            WelcomePage.Controls.Add(TitleLabel);
            WelcomePage.Controls.Add(CopyrightLabel);
            WelcomePage.Controls.Add(SubtitleLabel);
            WelcomePage.Controls.Add(StartButton);
            WelcomePage.Location = new Point(4, 26);
            WelcomePage.Name = "WelcomePage";
            WelcomePage.Padding = new Padding(3);
            WelcomePage.Size = new Size(363, 697);
            WelcomePage.TabIndex = 0;
            WelcomePage.Text = "0";
            // 
            // BootSettingsLandPage
            // 
            BootSettingsLandPage.BackColor = Color.Transparent;
            BootSettingsLandPage.Controls.Add(FirstSetApplyCheckbox);
            BootSettingsLandPage.Controls.Add(FirstSetNextBtn);
            BootSettingsLandPage.Controls.Add(FirstSetSubTitleLabel);
            BootSettingsLandPage.Controls.Add(FirstSetTitleLabel);
            BootSettingsLandPage.Location = new Point(4, 26);
            BootSettingsLandPage.Name = "BootSettingsLandPage";
            BootSettingsLandPage.Padding = new Padding(3);
            BootSettingsLandPage.Size = new Size(363, 697);
            BootSettingsLandPage.TabIndex = 1;
            BootSettingsLandPage.Text = "1";
            // 
            // FirstSetApplyCheckbox
            // 
            FirstSetApplyCheckbox.AutoSize = true;
            FirstSetApplyCheckbox.BackColor = Color.White;
            FirstSetApplyCheckbox.Depth = 0;
            FirstSetApplyCheckbox.Location = new Point(23, 375);
            FirstSetApplyCheckbox.Margin = new Padding(0);
            FirstSetApplyCheckbox.MouseLocation = new Point(-1, -1);
            FirstSetApplyCheckbox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FirstSetApplyCheckbox.Name = "FirstSetApplyCheckbox";
            FirstSetApplyCheckbox.ReadOnly = false;
            FirstSetApplyCheckbox.Ripple = true;
            FirstSetApplyCheckbox.Size = new Size(266, 37);
            FirstSetApplyCheckbox.TabIndex = 4;
            FirstSetApplyCheckbox.Text = "I have read and I agree the EULA.";
            FirstSetApplyCheckbox.UseAccentColor = false;
            FirstSetApplyCheckbox.UseVisualStyleBackColor = false;
            FirstSetApplyCheckbox.CheckedChanged += FirstSetApplyCheckbox_CheckedChanged;
            // 
            // FirstSetNextBtn
            // 
            FirstSetNextBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FirstSetNextBtn.Density = MaterialButton.MaterialButtonDensity.Default;
            FirstSetNextBtn.Depth = 0;
            FirstSetNextBtn.HighEmphasis = true;
            FirstSetNextBtn.Icon = null;
            FirstSetNextBtn.IconType = MaterialButton.MaterialIconType.Rebase;
            FirstSetNextBtn.Location = new Point(33, 439);
            FirstSetNextBtn.Margin = new Padding(4, 6, 4, 6);
            FirstSetNextBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FirstSetNextBtn.Name = "FirstSetNextBtn";
            FirstSetNextBtn.NoAccentTextColor = Color.Empty;
            FirstSetNextBtn.Size = new Size(111, 36);
            FirstSetNextBtn.TabIndex = 3;
            FirstSetNextBtn.Text = "Here we go!";
            FirstSetNextBtn.Type = MaterialButton.MaterialButtonType.Contained;
            FirstSetNextBtn.UseAccentColor = false;
            FirstSetNextBtn.UseVisualStyleBackColor = true;
            FirstSetNextBtn.Click += FirstSetNextBtn_Click;
            // 
            // FirstSetSubTitleLabel
            // 
            FirstSetSubTitleLabel.Depth = 0;
            FirstSetSubTitleLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            FirstSetSubTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            FirstSetSubTitleLabel.Location = new Point(28, 285);
            FirstSetSubTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FirstSetSubTitleLabel.Name = "FirstSetSubTitleLabel";
            FirstSetSubTitleLabel.Size = new Size(288, 78);
            FirstSetSubTitleLabel.TabIndex = 2;
            FirstSetSubTitleLabel.Text = "Before starting agenting, let us collect some information first! q(≧▽≦q)";
            // 
            // FirstSetTitleLabel
            // 
            FirstSetTitleLabel.AutoSize = true;
            FirstSetTitleLabel.Depth = 0;
            FirstSetTitleLabel.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            FirstSetTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            FirstSetTitleLabel.Location = new Point(28, 227);
            FirstSetTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FirstSetTitleLabel.Name = "FirstSetTitleLabel";
            FirstSetTitleLabel.Size = new Size(263, 41);
            FirstSetTitleLabel.TabIndex = 1;
            FirstSetTitleLabel.Text = "Nice to meet you!";
            // 
            // ConfigueServicePage
            // 
            ConfigueServicePage.BackColor = Color.Transparent;
            ConfigueServicePage.Controls.Add(ServiceSelectorMask);
            ConfigueServicePage.Controls.Add(ApiSettingsPagesTab);
            ConfigueServicePage.Controls.Add(ServiceSelectorBox);
            ConfigueServicePage.Controls.Add(ServiceConfigueNextBtn);
            ConfigueServicePage.Controls.Add(ServiceConfigueSubtitleLabel);
            ConfigueServicePage.Controls.Add(ServiceConfigueTitleLabel);
            ConfigueServicePage.Location = new Point(4, 26);
            ConfigueServicePage.Name = "ConfigueServicePage";
            ConfigueServicePage.Padding = new Padding(3);
            ConfigueServicePage.Size = new Size(363, 697);
            ConfigueServicePage.TabIndex = 2;
            ConfigueServicePage.Text = "2";
            // 
            // ServiceSelectorMask
            // 
            ServiceSelectorMask.Depth = 0;
            ServiceSelectorMask.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            ServiceSelectorMask.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            ServiceSelectorMask.Location = new Point(27, 209);
            ServiceSelectorMask.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ServiceSelectorMask.Name = "ServiceSelectorMask";
            ServiceSelectorMask.Size = new Size(313, 62);
            ServiceSelectorMask.TabIndex = 6;
            ServiceSelectorMask.Visible = false;
            // 
            // ApiSettingsPagesTab
            // 
            ApiSettingsPagesTab.Controls.Add(None);
            ApiSettingsPagesTab.Controls.Add(Gemini);
            ApiSettingsPagesTab.Controls.Add(ChatGPT);
            ApiSettingsPagesTab.Controls.Add(Local);
            ApiSettingsPagesTab.Depth = 0;
            ApiSettingsPagesTab.Location = new Point(6, 277);
            ApiSettingsPagesTab.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ApiSettingsPagesTab.Multiline = true;
            ApiSettingsPagesTab.Name = "ApiSettingsPagesTab";
            ApiSettingsPagesTab.SelectedIndex = 0;
            ApiSettingsPagesTab.Size = new Size(351, 348);
            ApiSettingsPagesTab.TabIndex = 7;
            // 
            // None
            // 
            None.Controls.Add(NoApiLabel);
            None.Location = new Point(4, 26);
            None.Name = "None";
            None.Padding = new Padding(3);
            None.Size = new Size(343, 318);
            None.TabIndex = 0;
            None.Text = "0";
            None.UseVisualStyleBackColor = true;
            // 
            // NoApiLabel
            // 
            NoApiLabel.Depth = 0;
            NoApiLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            NoApiLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            NoApiLabel.Location = new Point(17, 16);
            NoApiLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            NoApiLabel.Name = "NoApiLabel";
            NoApiLabel.Size = new Size(313, 104);
            NoApiLabel.TabIndex = 8;
            NoApiLabel.Text = "To enter next step, you must select an AI provider.";
            // 
            // Gemini
            // 
            Gemini.Controls.Add(GeminiApiKeyBox);
            Gemini.Location = new Point(4, 26);
            Gemini.Name = "Gemini";
            Gemini.Padding = new Padding(3);
            Gemini.Size = new Size(343, 318);
            Gemini.TabIndex = 1;
            Gemini.Text = "1";
            Gemini.UseVisualStyleBackColor = true;
            // 
            // GeminiApiKeyBox
            // 
            GeminiApiKeyBox.AnimateReadOnly = false;
            GeminiApiKeyBox.AutoCompleteMode = AutoCompleteMode.None;
            GeminiApiKeyBox.AutoCompleteSource = AutoCompleteSource.None;
            GeminiApiKeyBox.BackgroundImageLayout = ImageLayout.None;
            GeminiApiKeyBox.CharacterCasing = CharacterCasing.Normal;
            GeminiApiKeyBox.Depth = 0;
            GeminiApiKeyBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            GeminiApiKeyBox.HideSelection = true;
            GeminiApiKeyBox.Hint = "API key";
            GeminiApiKeyBox.LeadingIcon = null;
            GeminiApiKeyBox.Location = new Point(17, 22);
            GeminiApiKeyBox.MaxLength = 32767;
            GeminiApiKeyBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            GeminiApiKeyBox.Name = "GeminiApiKeyBox";
            GeminiApiKeyBox.PasswordChar = '\0';
            GeminiApiKeyBox.PrefixSuffixText = null;
            GeminiApiKeyBox.ReadOnly = false;
            GeminiApiKeyBox.RightToLeft = RightToLeft.No;
            GeminiApiKeyBox.SelectedText = "";
            GeminiApiKeyBox.SelectionLength = 0;
            GeminiApiKeyBox.SelectionStart = 0;
            GeminiApiKeyBox.ShortcutsEnabled = true;
            GeminiApiKeyBox.Size = new Size(313, 48);
            GeminiApiKeyBox.TabIndex = 0;
            GeminiApiKeyBox.TabStop = false;
            GeminiApiKeyBox.TextAlign = HorizontalAlignment.Left;
            GeminiApiKeyBox.TrailingIcon = null;
            GeminiApiKeyBox.UseSystemPasswordChar = false;
            // 
            // ChatGPT
            // 
            ChatGPT.Controls.Add(materialLabel2);
            ChatGPT.Location = new Point(4, 26);
            ChatGPT.Name = "ChatGPT";
            ChatGPT.Padding = new Padding(3);
            ChatGPT.Size = new Size(343, 318);
            ChatGPT.TabIndex = 2;
            ChatGPT.Text = "2";
            ChatGPT.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel2.Location = new Point(17, 25);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(313, 104);
            materialLabel2.TabIndex = 9;
            materialLabel2.Text = "Currently not supported. Please subscribe to upgrades.";
            // 
            // Local
            // 
            Local.Controls.Add(materialLabel3);
            Local.Location = new Point(4, 26);
            Local.Name = "Local";
            Local.Padding = new Padding(3);
            Local.Size = new Size(343, 318);
            Local.TabIndex = 3;
            Local.Text = "3";
            Local.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel3.Location = new Point(17, 25);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(313, 104);
            materialLabel3.TabIndex = 10;
            materialLabel3.Text = "Currently not supported. Please subscribe to upgrades.";
            // 
            // ServiceSelectorBox
            // 
            ServiceSelectorBox.AutoResize = false;
            ServiceSelectorBox.BackColor = Color.FromArgb(255, 255, 255);
            ServiceSelectorBox.Depth = 0;
            ServiceSelectorBox.DrawMode = DrawMode.OwnerDrawVariable;
            ServiceSelectorBox.DropDownHeight = 174;
            ServiceSelectorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ServiceSelectorBox.DropDownWidth = 121;
            ServiceSelectorBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            ServiceSelectorBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            ServiceSelectorBox.FormattingEnabled = true;
            ServiceSelectorBox.Hint = "Provider";
            ServiceSelectorBox.IntegralHeight = false;
            ServiceSelectorBox.ItemHeight = 43;
            ServiceSelectorBox.Items.AddRange(new object[] { "None", "Google Gemini", "OpenAI ChatGPT", "Local Service" });
            ServiceSelectorBox.Location = new Point(27, 222);
            ServiceSelectorBox.MaxDropDownItems = 4;
            ServiceSelectorBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            ServiceSelectorBox.Name = "ServiceSelectorBox";
            ServiceSelectorBox.Size = new Size(313, 49);
            ServiceSelectorBox.StartIndex = 0;
            ServiceSelectorBox.TabIndex = 4;
            ServiceSelectorBox.SelectedIndexChanged += ServiceSelectorBox_SelectedIndexChanged;
            // 
            // ServiceConfigueNextBtn
            // 
            ServiceConfigueNextBtn.AutoSize = false;
            ServiceConfigueNextBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ServiceConfigueNextBtn.Density = MaterialButton.MaterialButtonDensity.Default;
            ServiceConfigueNextBtn.Depth = 0;
            ServiceConfigueNextBtn.HighEmphasis = true;
            ServiceConfigueNextBtn.Icon = null;
            ServiceConfigueNextBtn.IconType = MaterialButton.MaterialIconType.Rebase;
            ServiceConfigueNextBtn.Location = new Point(27, 634);
            ServiceConfigueNextBtn.Margin = new Padding(4, 6, 4, 6);
            ServiceConfigueNextBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ServiceConfigueNextBtn.Name = "ServiceConfigueNextBtn";
            ServiceConfigueNextBtn.NoAccentTextColor = Color.Empty;
            ServiceConfigueNextBtn.Size = new Size(313, 45);
            ServiceConfigueNextBtn.TabIndex = 5;
            ServiceConfigueNextBtn.Text = "next >";
            ServiceConfigueNextBtn.Type = MaterialButton.MaterialButtonType.Contained;
            ServiceConfigueNextBtn.UseAccentColor = false;
            ServiceConfigueNextBtn.UseVisualStyleBackColor = true;
            ServiceConfigueNextBtn.Click += ServiceConfigueNextBtn_Click;
            // 
            // ServiceConfigueSubtitleLabel
            // 
            ServiceConfigueSubtitleLabel.Depth = 0;
            ServiceConfigueSubtitleLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            ServiceConfigueSubtitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            ServiceConfigueSubtitleLabel.Location = new Point(27, 105);
            ServiceConfigueSubtitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ServiceConfigueSubtitleLabel.Name = "ServiceConfigueSubtitleLabel";
            ServiceConfigueSubtitleLabel.Size = new Size(313, 104);
            ServiceConfigueSubtitleLabel.TabIndex = 3;
            ServiceConfigueSubtitleLabel.Text = "Select your service provider and enter your API key - After all, you need an online source before start using AI.";
            // 
            // ServiceConfigueTitleLabel
            // 
            ServiceConfigueTitleLabel.AutoSize = true;
            ServiceConfigueTitleLabel.Depth = 0;
            ServiceConfigueTitleLabel.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            ServiceConfigueTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            ServiceConfigueTitleLabel.Location = new Point(27, 53);
            ServiceConfigueTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ServiceConfigueTitleLabel.Name = "ServiceConfigueTitleLabel";
            ServiceConfigueTitleLabel.Size = new Size(255, 41);
            ServiceConfigueTitleLabel.TabIndex = 2;
            ServiceConfigueTitleLabel.Text = "Configue Service";
            // 
            // DoneSettingPage
            // 
            DoneSettingPage.BackColor = Color.Transparent;
            DoneSettingPage.Controls.Add(SkipSetCheckBox);
            DoneSettingPage.Controls.Add(SetTitleLabel);
            DoneSettingPage.Controls.Add(SetSubtitleLabel);
            DoneSettingPage.Controls.Add(GoToChatBtn);
            DoneSettingPage.Location = new Point(4, 26);
            DoneSettingPage.Name = "DoneSettingPage";
            DoneSettingPage.Padding = new Padding(3);
            DoneSettingPage.Size = new Size(363, 697);
            DoneSettingPage.TabIndex = 3;
            DoneSettingPage.Text = "3";
            // 
            // SkipSetCheckBox
            // 
            SkipSetCheckBox.AutoSize = true;
            SkipSetCheckBox.BackColor = Color.White;
            SkipSetCheckBox.Depth = 0;
            SkipSetCheckBox.Location = new Point(43, 365);
            SkipSetCheckBox.Margin = new Padding(0);
            SkipSetCheckBox.MouseLocation = new Point(-1, -1);
            SkipSetCheckBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            SkipSetCheckBox.Name = "SkipSetCheckBox";
            SkipSetCheckBox.ReadOnly = false;
            SkipSetCheckBox.Ripple = true;
            SkipSetCheckBox.Size = new Size(268, 37);
            SkipSetCheckBox.TabIndex = 6;
            SkipSetCheckBox.Text = "Skip welcome page on next boot.";
            SkipSetCheckBox.UseAccentColor = false;
            SkipSetCheckBox.UseVisualStyleBackColor = false;
            // 
            // SetTitleLabel
            // 
            SetTitleLabel.AutoSize = true;
            SetTitleLabel.Depth = 0;
            SetTitleLabel.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            SetTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H3;
            SetTitleLabel.Location = new Point(43, 206);
            SetTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            SetTitleLabel.Name = "SetTitleLabel";
            SetTitleLabel.Size = new Size(226, 58);
            SetTitleLabel.TabIndex = 3;
            SetTitleLabel.Text = "Well Done!";
            // 
            // SetSubtitleLabel
            // 
            SetSubtitleLabel.Depth = 0;
            SetSubtitleLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            SetSubtitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            SetSubtitleLabel.Location = new Point(43, 270);
            SetSubtitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            SetSubtitleLabel.Name = "SetSubtitleLabel";
            SetSubtitleLabel.Size = new Size(272, 36);
            SetSubtitleLabel.TabIndex = 4;
            SetSubtitleLabel.Text = "You're all set. Welcome!";
            // 
            // GoToChatBtn
            // 
            GoToChatBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GoToChatBtn.Density = MaterialButton.MaterialButtonDensity.Default;
            GoToChatBtn.Depth = 0;
            GoToChatBtn.HighEmphasis = true;
            GoToChatBtn.Icon = null;
            GoToChatBtn.IconType = MaterialButton.MaterialIconType.Rebase;
            GoToChatBtn.Location = new Point(43, 312);
            GoToChatBtn.Margin = new Padding(4, 6, 4, 6);
            GoToChatBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            GoToChatBtn.Name = "GoToChatBtn";
            GoToChatBtn.NoAccentTextColor = Color.Empty;
            GoToChatBtn.Size = new Size(107, 36);
            GoToChatBtn.TabIndex = 5;
            GoToChatBtn.Text = "Go To Chat";
            GoToChatBtn.Type = MaterialButton.MaterialButtonType.Contained;
            GoToChatBtn.UseAccentColor = false;
            GoToChatBtn.UseVisualStyleBackColor = true;
            GoToChatBtn.Click += GoToChatBtn_Click;
            // 
            // DialogPage
            // 
            DialogPage.BackColor = Color.Transparent;
            DialogPage.Controls.Add(aiOperationBtn);
            DialogPage.Controls.Add(GenerateButton);
            DialogPage.Controls.Add(PromptBox);
            DialogPage.Controls.Add(DialogBox);
            DialogPage.Location = new Point(4, 26);
            DialogPage.Name = "DialogPage";
            DialogPage.Padding = new Padding(3);
            DialogPage.Size = new Size(363, 697);
            DialogPage.TabIndex = 4;
            DialogPage.Text = "4";
            // 
            // aiOperationBtn
            // 
            aiOperationBtn.Depth = 0;
            aiOperationBtn.Icon = Properties.Resources.more;
            aiOperationBtn.Location = new Point(294, 634);
            aiOperationBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            aiOperationBtn.Name = "aiOperationBtn";
            aiOperationBtn.Size = new Size(59, 61);
            aiOperationBtn.TabIndex = 7;
            aiOperationBtn.Text = "materialFloatingActionButton1";
            aiOperationBtn.UseVisualStyleBackColor = true;
            aiOperationBtn.Click += materialFloatingActionButton1_Click;
            aiOperationBtn.Layout += GenerateItems;
            // 
            // GenerateButton
            // 
            GenerateButton.AutoSize = false;
            GenerateButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GenerateButton.Density = MaterialButton.MaterialButtonDensity.Default;
            GenerateButton.Depth = 0;
            GenerateButton.HighEmphasis = true;
            GenerateButton.Icon = null;
            GenerateButton.IconType = MaterialButton.MaterialIconType.Rebase;
            GenerateButton.Location = new Point(19, 637);
            GenerateButton.Margin = new Padding(4, 6, 4, 6);
            GenerateButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            GenerateButton.Name = "GenerateButton";
            GenerateButton.NoAccentTextColor = Color.Empty;
            GenerateButton.Size = new Size(265, 49);
            GenerateButton.TabIndex = 6;
            GenerateButton.Text = "Generate";
            GenerateButton.Type = MaterialButton.MaterialButtonType.Contained;
            GenerateButton.UseAccentColor = false;
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += materialButton1_Click;
            // 
            // PromptBox
            // 
            PromptBox.AnimateReadOnly = false;
            PromptBox.BackgroundImageLayout = ImageLayout.None;
            PromptBox.CharacterCasing = CharacterCasing.Normal;
            PromptBox.Depth = 0;
            PromptBox.HideSelection = true;
            PromptBox.Hint = "Prompts Here...";
            PromptBox.Location = new Point(7, 546);
            PromptBox.MaxLength = 32767;
            PromptBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            PromptBox.Name = "PromptBox";
            PromptBox.PasswordChar = '\0';
            PromptBox.ReadOnly = false;
            PromptBox.ScrollBars = ScrollBars.Vertical;
            PromptBox.SelectedText = "";
            PromptBox.SelectionLength = 0;
            PromptBox.SelectionStart = 0;
            PromptBox.ShortcutsEnabled = true;
            PromptBox.Size = new Size(354, 76);
            PromptBox.TabIndex = 2;
            PromptBox.TabStop = false;
            PromptBox.TextAlign = HorizontalAlignment.Left;
            PromptBox.UseSystemPasswordChar = false;
            // 
            // DialogBox
            // 
            DialogBox.AnimateReadOnly = false;
            DialogBox.BackgroundImageLayout = ImageLayout.None;
            DialogBox.CharacterCasing = CharacterCasing.Normal;
            DialogBox.Depth = 0;
            DialogBox.HideSelection = true;
            DialogBox.Location = new Point(6, 6);
            DialogBox.MaxLength = 32767;
            DialogBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            DialogBox.Name = "DialogBox";
            DialogBox.PasswordChar = '\0';
            DialogBox.ReadOnly = true;
            DialogBox.ScrollBars = ScrollBars.Vertical;
            DialogBox.SelectedText = "";
            DialogBox.SelectionLength = 0;
            DialogBox.SelectionStart = 0;
            DialogBox.ShortcutsEnabled = true;
            DialogBox.Size = new Size(354, 534);
            DialogBox.TabIndex = 1;
            DialogBox.TabStop = false;
            DialogBox.Text = "AI can make mistakes. Check the results carefully.";
            DialogBox.TextAlign = HorizontalAlignment.Left;
            DialogBox.UseSystemPasswordChar = false;
            // 
            // HyAgentMainWindow
            // 
            ClientSize = new Size(389, 791);
            Controls.Add(PageTabControl);
            Name = "HyAgentMainWindow";
            Load += HyAgentMainWindow_Load;
            PageTabControl.ResumeLayout(false);
            WelcomePage.ResumeLayout(false);
            WelcomePage.PerformLayout();
            BootSettingsLandPage.ResumeLayout(false);
            BootSettingsLandPage.PerformLayout();
            ConfigueServicePage.ResumeLayout(false);
            ConfigueServicePage.PerformLayout();
            ApiSettingsPagesTab.ResumeLayout(false);
            None.ResumeLayout(false);
            Gemini.ResumeLayout(false);
            ChatGPT.ResumeLayout(false);
            Local.ResumeLayout(false);
            DoneSettingPage.ResumeLayout(false);
            DoneSettingPage.PerformLayout();
            DialogPage.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private MaterialLabel TitleLabel;
        private MaterialLabel SubtitleLabel;
        private ReaLTaiizor.Controls.MaterialButton StartButton;
        private MaterialLabel CopyrightLabel;
        private ReaLTaiizor.Controls.MaterialTabControl PageTabControl;
        private System.Windows.Forms.TabPage WelcomePage;
        private System.Windows.Forms.TabPage BootSettingsLandPage;
        private MaterialLabel FirstSetSubTitleLabel;
        private MaterialLabel FirstSetTitleLabel;
        private ReaLTaiizor.Controls.MaterialCheckBox FirstSetApplyCheckbox;
        private ReaLTaiizor.Controls.MaterialButton FirstSetNextBtn;
        private System.Windows.Forms.TabPage ConfigueServicePage;
        private MaterialLabel ServiceConfigueSubtitleLabel;
        private MaterialLabel ServiceConfigueTitleLabel;
        private MaterialComboBox ServiceSelectorBox;
        private MaterialButton ServiceConfigueNextBtn;
        private MaterialLabel ServiceSelectorMask;
        private MaterialTabControl ApiSettingsPagesTab;
        private System.Windows.Forms.TabPage None;
        private MaterialLabel NoApiLabel;
        private System.Windows.Forms.TabPage Gemini;
        private MaterialTextBoxEdit GeminiApiKeyBox;
        private System.Windows.Forms.TabPage ChatGPT;
        private MaterialLabel materialLabel2;
        private System.Windows.Forms.TabPage Local;
        private MaterialLabel materialLabel3;
        private System.Windows.Forms.TabPage DoneSettingPage;
        private MaterialCheckBox SkipSetCheckBox;
        private MaterialLabel SetTitleLabel;
        private MaterialLabel SetSubtitleLabel;
        private MaterialButton GoToChatBtn;
        private System.Windows.Forms.TabPage DialogPage;
        private MaterialMultiLineTextBoxEdit DialogBox;
        private MaterialButton GenerateButton;
        private MaterialMultiLineTextBoxEdit PromptBox;
        private MaterialFloatingActionButton aiOperationBtn;
    }
}
