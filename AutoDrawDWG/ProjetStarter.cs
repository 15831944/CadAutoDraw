using System;
using System.Collections.Generic;
using System.Text;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace AutoDrawDWG
{
    public class ProjetStarter
    {
        public static bool _IsShow = false;
        //private MainForm form;
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

        Form1 form;
        [CommandMethod("AutoDrawer")]
        public void starter()
        {
            ed.WriteMessage(DateTime.Now.ToShortDateString() + "AutoDrawer功能载入成功.");
            if (form == null)
            {
                form = new Form1();
                Application.ShowModelessDialog(form);  //显示非模态对话框 
            }
            else
            {
                form.Activate();
            }
            /*else if (form.Visible == false && form.IsDisposed == false)
            {
                form.Visible = true;
            }
            else if (form.IsDisposed == true)
            {
                form = new Form1();
                Application.ShowModelessDialog(form);  //显示非模态对话框 
            }
            else
            {
                ed.WriteMessage("界面已打开,请勿重复打开..");
            }*/
        }
    }
}
