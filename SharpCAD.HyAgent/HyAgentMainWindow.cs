using ReaLTaiizor.Forms;
using System.Windows.Forms;

namespace SharpCAD.HyAgent
{
    partial class HyAgentMainWindow : MaterialForm
    {
        public HyAgentMainWindow()
        {
            InitializeComponent();
        }

        private void HyAgentMainWindow_Load(object sender, EventArgs e)
        {
            StartButton.Visible = false;
            TitleLabel.Text = "";
            SubtitleLabel.Text = "";
            CopyrightLabel.Visible = false;

            CheckForIllegalCrossThreadCalls = false;
            Thread animeThread = new Thread(new ThreadStart(() =>
            {
                foreach (char c in "你好！")
                {
                    Thread.Sleep(50);
                    TitleLabel.Text += c;
                }
                foreach (char c in "欢迎使用幻域CAD - Agent")
                {
                    Thread.Sleep(50);
                    SubtitleLabel.Text += c;
                }
                CopyrightLabel.Visible = true;
                StartButton.Visible = true;
            }));
            animeThread.Start();
        }
    }
}
