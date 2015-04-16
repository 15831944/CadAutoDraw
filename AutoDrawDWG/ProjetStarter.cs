using System;
using System.Collections.Generic;
using System.Text;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;

[assembly:ExtensionApplication(typeof(AutoDrawDWG.InitProject))]
[assembly: CommandClass(typeof(AutoDrawDWG.ProjetStarter))]
namespace AutoDrawDWG
{
    public class ProjetStarter
    {
        public static bool _IsShow = false;
        //private MainForm form;
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

        Form1 form;
        [CommandMethod("AutoDrawer", CommandFlags.Session)]
        public void starter()
        {
            if (form == null || form.IsDisposed)
            {
                ed.WriteMessage("功能已载入.");
                form = new Form1();
                Application.ShowModelessDialog(form);  //显示非模态对话框 
                //Application.ShowModalDialog(form);  //显示非模态对话框 
                
            }

            else
            {

                form.Activate();
            }
        }
    }

    public class InitProject : Autodesk.AutoCAD.Runtime.IExtensionApplication
    {
        Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
        //Editor ed = doc.Editor;
        Database db = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Database;
        Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        public void Initialize()
        {            
            ed.WriteMessage("packages loaded.");

            ContextMenuExtension ce = new ContextMenuExtension();
            ce.Title = "编辑块定义";
            MenuItem mi1 = new MenuItem("定义块基点");
            mi1.Click += mi1_Click;

            MenuItem mi2 = new MenuItem("定义块大小");
            mi2.Click += mi2_Click;

            ce.MenuItems.Add(mi1);
            ce.MenuItems.Add(mi2);

            Autodesk.AutoCAD.ApplicationServices.Application.AddDefaultContextMenuExtension(ce);
        }



        void mi1_Click(object sender, EventArgs e)
        {
            ed.WriteMessage("定义块基点");

            Transaction tr = doc.TransactionManager.StartTransaction();
            using (tr)
            {
                DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();

                // Note that error checking is minimal.
                Entity ent;
                // Ask the user to select an object
                PromptEntityOptions peo = new PromptEntityOptions("\nSelect the Block Reference >>");
                peo.SetRejectMessage("\nSelect Block Reference only >>");
                peo.AddAllowedClass(typeof(BlockReference), false);
                PromptEntityResult res;
                res = ed.GetEntity(peo);
                if (res.Status != PromptStatus.OK)
                    return;
                ent = (Entity)tr.GetObject(res.ObjectId, OpenMode.ForRead);
                if (ent == null)
                    return;
                BlockReference bref = (BlockReference)ent as BlockReference;
                if (bref != null)
                {
                    bref.UpgradeOpen();

                    // Get the block reference's associated block table record.

                    ObjectId blockId = bref.BlockTableRecord;

                    BlockTableRecord pBlockTableRecord = (BlockTableRecord)tr.GetObject(blockId, OpenMode.ForWrite);

                    PromptPointOptions pPointOptions = new PromptPointOptions("\n 选择一个点");

                    PromptPointResult pPointResult = doc.Editor.GetPoint(pPointOptions);

                    if (pPointResult.Status == PromptStatus.OK)
                    {
                        Point3d point3d = pPointResult.Value;

                        Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("是否重新定义块:" + pBlockTableRecord.Name + " 基点于:"
                            + System.Environment.NewLine + "X:" + point3d.X.ToString("0.0000")
                            + System.Environment.NewLine + "Y:" + point3d.Y.ToString("0.0000")
                            + System.Environment.NewLine + "Z:" + point3d.Z.ToString("0.0000"));
                        pBlockTableRecord.Origin = point3d;
                    }
                    // Store the BTR's current origin (we'll need it later).


                    
                }
                m_DocumentLock.Dispose();
            }

        }
        void mi2_Click(object sender, EventArgs e)
        {
            ed.WriteMessage("定义块大小");
            DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
            m_DocumentLock.Dispose();
        }
        public void Terminate()
        {
            
        }
    }
}
