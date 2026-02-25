using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using ImgHorizon.CADExample;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: ExtensionApplication(typeof(AutoBase))]
[assembly: CommandClass(typeof(AutoBase))]
namespace ImgHorizon.CADExample
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
            SharedDoc = Application.DocumentManager.MdiActiveDocument;
            WriteMessage("\n欢迎使用 幻域·ImgHorizon。\n" +
                "开发者：幻愿Recovery\n" +
                "teko.IO SisTemS! 相互科技工作室 版权所有");

            Application.DocumentManager.MdiActiveDocument.SendStringToExecute("main ", true, false, false);

        }

        [CommandMethod("hello")]
        public void Test()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("Hello, world!");
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Terminate()
        {
            //SharedDoc = null;
        }
    }
}
