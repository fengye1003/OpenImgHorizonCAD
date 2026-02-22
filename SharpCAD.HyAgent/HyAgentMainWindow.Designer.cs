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
            TitleLabel = new Label();
            SubtitleLabel = new Label();
            StartButton = new ReaLTaiizor.Controls.MaterialButton();
            CopyrightLabel = new Label();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            TitleLabel.Location = new Point(34, 298);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(125, 46);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "你好！";
            // 
            // SubtitleLabel
            // 
            SubtitleLabel.AutoSize = true;
            SubtitleLabel.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            SubtitleLabel.Location = new Point(41, 357);
            SubtitleLabel.Name = "SubtitleLabel";
            SubtitleLabel.Size = new Size(252, 27);
            SubtitleLabel.TabIndex = 1;
            SubtitleLabel.Text = "欢迎使用幻域CAD - Agent";
            // 
            // StartButton
            // 
            StartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            StartButton.Depth = 0;
            StartButton.HighEmphasis = true;
            StartButton.Icon = null;
            StartButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            StartButton.Location = new Point(41, 410);
            StartButton.Margin = new Padding(4, 6, 4, 6);
            StartButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            StartButton.Name = "StartButton";
            StartButton.NoAccentTextColor = Color.Empty;
            StartButton.Size = new Size(102, 36);
            StartButton.TabIndex = 2;
            StartButton.Text = "LET'S DO IT!";
            StartButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            StartButton.UseAccentColor = false;
            StartButton.UseVisualStyleBackColor = true;
            // 
            // CopyrightLabel
            // 
            CopyrightLabel.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            CopyrightLabel.Location = new Point(34, 714);
            CopyrightLabel.Name = "CopyrightLabel";
            CopyrightLabel.Size = new Size(308, 74);
            CopyrightLabel.TabIndex = 3;
            CopyrightLabel.Text = "Copyright 2016 - 2016 (C) 相互科技工作室teko.IO SisTemS!™ 保留所有权利。Work by NJUT with <3";
            // 
            // HyAgentMainWindow
            // 
            ClientSize = new Size(369, 791);
            Controls.Add(CopyrightLabel);
            Controls.Add(StartButton);
            Controls.Add(SubtitleLabel);
            Controls.Add(TitleLabel);
            Name = "HyAgentMainWindow";
            Load += HyAgentMainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label TitleLabel;
        private Label SubtitleLabel;
        private ReaLTaiizor.Controls.MaterialButton StartButton;
        private Label CopyrightLabel;
    }
}
