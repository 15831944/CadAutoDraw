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
            
            T_FilePath.Text = FilePath;
        }

        private void BlockEditeur_ResizeEnd(object sender, EventArgs e)
        {

        }

        string currentFilePath = string.Empty;
        string currentFileName = string.Empty;
        private void B_ReadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择文件.";
                fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (currentFilePath == "" || currentFilePath == string.Empty || currentFilePath != fileDialog.FileName)
                    {
                        currentFilePath = fileDialog.FileName;

                        T_FilePath.Text = currentFilePath;

                        string[] filePathAndExtentions = currentFilePath.Split(new[] { "\\" }, StringSplitOptions.None);
                        currentFileName = filePathAndExtentions[filePathAndExtentions.Length - 1];

                        this.toolStripStatusLabel1.Text = "已选择：" + currentFileName;

                        string[] fileNameAndExtentions = currentFileName.Split(new[] { "." }, StringSplitOptions.None);

                        string fileName = fileNameAndExtentions[0];
                    }
                }

            }
        }

        private void B_ReadBlock_Click(object sender, EventArgs e)
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

                        #region 生成bitmap
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
                        #endregion

                        #region 在指定文件中读写块

                        #endregion

                        preview.Save(path + "\\" + btr.Name + ".bmp"); // 保存块预览图案
                    }
                    trans.Commit();
                    m_DocumentLock.Dispose();
                    this.toolStripStatusLabel1.Text = currentFileName + "块读取成功.";
                }
                catch (Exception  ee)
                {

                    MessageBox.Show("" + ee, "error");
                }
                
            }
        }

        private void BlockEditeur_Load(object sender, EventArgs e)
        {

        }




    }
}
