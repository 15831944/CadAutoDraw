using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Internal;
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
            label1.Text = FilePath;
            label1.Location = new Point((this.Size.Width - label1.Size.Width) / 2, label1.Location.Y);
        }

        private void BlockEditeur_ResizeEnd(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Size.Width - label1.Size.Width) / 2, label1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DotNetARX.BlockTools.ImportBlocksFromDwg(FilePath,)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateBlockPreview();
        }
        /// DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
        ///  代码...
        /// m_DocumentLock.Dispose();
        public void GenerateBlockPreview()
        {
            
            Database db = HostApplicationServices.WorkingDatabase;
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            // 提示用户选择文件
            PromptFileNameResult result = ed.GetFileNameForOpen("请选择需要预览的文件");
            if (result.Status != PromptStatus.OK) return; // 如果未选择，则返回
            string filename = result.StringResult; // 获取带有路径的文件名
            filename = FilePath;
            // 在C盘根目录下创建一个临时文件夹，用来存放文件中的块预览图标
            string path = "C:\\Temp";
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
                    foreach (ObjectId blockRecordId in bt)
                    {
                        // 打开块表记录对象
                        BlockTableRecord btr = (BlockTableRecord)trans.GetObject(blockRecordId, OpenMode.ForRead);
                        // 如果是匿名块、布局块及没有预览图形的块，则返回
                        if (btr.IsAnonymous || btr.IsLayout || !btr.HasPreviewIcon) continue;
                        Bitmap preview;
                        try
                        {
                            // 获取块预览图案（适用于AutoCAD 2008及以下版本）
                            preview = BlockThumbnailHelper.GetBlockThumbanail(btr.ObjectId);
                        }
                        catch (Exception)
                        {

                            preview = btr.PreviewIcon; // 适用于AutoCAD 2009及以上版本
                        }
                        
                        preview.Save(path + "\\" + btr.Name + ".bmp"); // 保存块预览图案
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
    }
}
