using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpCAD.HyAgent;
using System.IO;

[assembly: ComVisible(false)]
[assembly: ExtensionApplication(typeof(AutoBase))]
[assembly: CommandClass(typeof(AutoBase))]
namespace SharpCAD.HyAgent
{

    public class AutoBase : IExtensionApplication
    {
        /// <summary>
        /// 公共
        /// </summary>
        public static Document SharedDoc { get; private set; } = null!;

        /// <summary>
        /// 写出
        /// </summary>
        public static void WriteMessage(string message)
        {
            SharedDoc.Editor.WriteMessage(message);
        }

        /// <summary>
        /// 初始
        /// </summary>
        public void Initialize()
        {
            SharedDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            WriteMessage("\n欢迎使用 幻域·SharpCAD。\n" +
                "开发者：幻愿Recovery\n" +
                "teko.IO SisTemS! 相互科技工作室 版权所有\n" +
                $"版本: {Program.Version}\r\n");

            //Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.SendStringToExecute("main ", true, false, false);
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        [CommandMethod("hello")]
        public void Test()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("Hello, world!");
        }

        [CommandMethod("hyagentpanel")]
        public void StartHyAgentPanel()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("正在拉起Agent面板...");
            if (Program.AgentUIInstance == null)
            {
                Program.AgentUIInstance = new();
            }
            
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(Program.AgentUIInstance);
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Terminate()
        {
            if (Program.AgentUIInstance != null)
            {
                Program.AgentUIInstance.MainDisposing = true;
                Program.AgentUIInstance.Close();
            }
            
            //SharedDoc = null;
        }

        //private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        //{
        //    // 获取当前插件所在的物理目录
        //    string pluginDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        //    // 构造缺失 DLL 的路径
        //    string assemblyName = new AssemblyName(args.Name).Name!;
        //    string assemblyPath = Path.Combine(pluginDir, assemblyName);

        //    Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        //    ed.WriteMessage($"ImgHorizon HyAgent: 缺失DLL动态库{assemblyName}，尝试从当前目录加载...\r\n");
        //    // 如果该目录下存在这个 DLL，就手动加载它
        //    if (File.Exists(assemblyPath))
        //    {
        //        ed.WriteMessage($"ImgHorizon HyAgent: 成功加载{assemblyName}。\r\n");
        //        return Assembly.LoadFrom(assemblyPath);
        //    }
        //    return null;
        //}
    }
}
