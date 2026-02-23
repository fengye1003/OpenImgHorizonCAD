using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCAD.HyAgent
{
    internal class Program
    {
        public static HyAgentMainWindow? AgentUIInstance;
        public static string Version = Assembly
    .GetExecutingAssembly()!
    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
    ?.InformationalVersion!;

        [STAThread]
        static void Main(string[] args)
        {
            AgentUIInstance = new HyAgentMainWindow();
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.Run(AgentUIInstance);
        }
    }
}
