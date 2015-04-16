using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.ApplicationServices;


[assembly: CommandClass(typeof(BlockContextMenu.BlockTableEditer))]
namespace BlockContextMenu
{
    public class BlockTableEditer:IExtensionApplication
    {
        /*[CommandMethod("BEdit")]
        public void BlockEditer()
        {
            ContextMenuExtension ce = new ContextMenuExtension();
            ce.Title = "编辑块定义";
            MenuItem mil=new MenuItem("定义块")
        }
         */

        public void Initialize()
        {
            ContextMenuExtension ce = new ContextMenuExtension();
            ce.Title = "编辑块定义";
            MenuItem mil=new MenuItem("定义块")
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
