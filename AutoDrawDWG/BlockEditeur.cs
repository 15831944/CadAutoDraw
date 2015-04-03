
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Internal;
using acadDb=Autodesk.AutoCAD.DatabaseServices;

using DotNetARX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AutoDrawDWG
{
    public partial class BlockEditeur : Form
    {
        string FilePath = null;
        public BlockEditeur(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;
            textBox1.Text = FilePath;
        }

        private void BlockEditeur_ResizeEnd(object sender, EventArgs e)
        {
        }

        //string BE_NameAndExtention = string.Empty;
        private void B_ChoisirFiche_Click(object sender, EventArgs e)
        {
            //DotNetARX.BlockTools.ImportBlocksFromDwg(FilePath,)
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择文件.";
                fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = fileDialog.FileName;
                    textBox1.Text = FilePath;

                    string[] filePathAndExtentions = FilePath.Split(new[] { "\\" }, StringSplitOptions.None);
                    string fileNameAndExtention = filePathAndExtentions[filePathAndExtentions.Length - 1];

                    string[] fileNameAndExtentions = fileNameAndExtention.Split(new[] { "." }, StringSplitOptions.None);
                    string fileName = fileNameAndExtentions[0];
                }

            }
        }

        private void B_ReadBlock_Click(object sender, EventArgs e)
        {
            GenerateBlockPreview(FilePath);

            ///
            /// 将生成的bgm文件加入到listview中
            /// fileListView(string bmgFilesLocation);
            ///
        }
        /// DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
        ///  代码...
        /// m_DocumentLock.Dispose();
        public void GenerateBlockPreview(string openFilePath)
        {
            
            Database db = HostApplicationServices.WorkingDatabase;
            ObjectId spaceId = db.CurrentSpaceId;//获取当前空间(模型空间或图纸空间)
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            // 提示用户选择文件
            //PromptFileNameResult result = ed.GetFileNameForOpen("请选择需要预览的文件");
            //if (result.Status != PromptStatus.OK) return; // 如果未选择，则返回
            //string filename = result.StringResult; // 获取带有路径的文件名
            string filename = openFilePath;
            // 在C盘根目录下创建一个临时文件夹，用来存放文件中的块预览图标
            string path =string.Empty;
#if DEBUG
            path = "C:\\Temp";
            
            //string b=
#else
            path = "..\\Resourse\\";
#endif

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();

                    // 导入外部文件中的块
                    db.ImportBlocksFromDwg(filename);
                    //打开块表
                    BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                    // 循环遍历块表中的块表记录
                    int i=0;
                    foreach (ObjectId blockRecordId in bt)
                    {
                        // 打开 块表 记录对象
                        BlockTableRecord btr = (BlockTableRecord)trans.GetObject(blockRecordId, OpenMode.ForRead);
                        // 如果是匿名块、布局块及没有预览图形的块，则返回
                        if (btr.IsAnonymous || btr.IsLayout || !btr.HasPreviewIcon) continue;
                        
                        Bitmap preview;
                        try
                        {
                            // 获取块预览图案（适用于AutoCAD 2008及以下版本）
                            //preview = BlockThumbnailHelper.GetBlockThumbanail(btr.ObjectId);
                            preview = btr.PreviewIcon; // 适用于AutoCAD 2009及以上版本
                            preview.Save(path + "\\" + btr.Name + ".bmp"); // 保存块预览图案

                            autoBlockFit(btr, trans, ed);
                            spaceId.InsertBlockReference("0", btr.Name, new Autodesk.AutoCAD.Geometry.Point3d(100 * i, 100 * i, 0), new Autodesk.AutoCAD.Geometry.Scale3d(1), 0);



                        }
                        catch (Exception ee)
                        {
                            ed.WriteMessage("错误;  " + ee.ToString());
                            //preview = btr.PreviewIcon; // 适用于AutoCAD 2009及以上版本
                        }
                         
                    }
                    trans.Commit();
                    m_DocumentLock.Dispose();
                }
                catch (Exception  ee)
                {

                    MessageBox.Show("" + ee, "error");
                }
                
            }
        }

        private ObjectId CreateBlock(string nameOfBlock, Autodesk.AutoCAD.Geometry.Point3d pos)
        {
            // get the current working database
            acadDb.Database db = acadDb.HostApplicationServices.WorkingDatabase;
            acadDb.Transaction trans = db.TransactionManager.StartTransaction();
            acadDb.BlockTable bt = (acadDb.BlockTable)(trans.GetObject(db.BlockTableId, acadDb.OpenMode.ForRead));
            acadDb.BlockTableRecord btr = (acadDb.BlockTableRecord)trans.GetObject(bt[acadDb.BlockTableRecord.ModelSpace], acadDb.OpenMode.ForWrite);
            // Create the block reference...use the return from CreateEmployeeDefinition directly!
            acadDb.BlockReference br = new acadDb.BlockReference(pos, bt[nameOfBlock]);
            //acadDb.BlockReference br = new acadDb.BlockReference(pos, btr.ObjectId);
            // Add the reference to ModelSpace
            btr.AppendEntity(br);
            // Add the attribute reference to the block reference
            trans.AddNewlyCreatedDBObject(br, true);
            acadDb.ObjectId retId = br.ObjectId;
            // trans.Commit();


            trans.Commit();
            trans.Dispose();
            return retId;
        }
        private void fileListView(string bmgFilesLocation)
        {
            //to do
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BlockPreview bp = new BlockPreview();
            bp.Show();
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            button3.Size = new Size(button3.Size.Width, listView1.Size.Height);
            button3.Location = new Point(listView1.Location.X + listView1.Size.Width + 6, listView1.Location.Y);
        }

        private void autoBlockFit(BlockTableRecord blockTR, Transaction tr, Editor ed)
        {
            foreach (ObjectId bId in blockTR)
            {
                using (Entity ent = (Entity)tr.GetObject(bId, OpenMode.ForRead, false))
                {
                    ed.WriteMessage("type:" + ent.GetType().ToString());
                    /*if (ent.GetRXClass().Name.ToString() == "AcDbBlockReference")
                    {

                        BlockReference br = (BlockReference)ent;

                        BlockTableRecord blkObj = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead);

                        if ((blkObj.HasAttributeDefinitions) && (blkObj.Name == ""))
                        {
                        }
                    }*/
                }
            }
        }
    }
}
