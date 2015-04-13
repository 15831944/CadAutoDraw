
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Geometry;
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

        public class objectBound
        {
            private Point3d _DownLeftDownPoint;
            private Point3d _UpRightPoint;

            private Point3d downLeftPoint
            {
                get
                {
                    return _DownLeftDownPoint;
                }
                set
                {
                    _DownLeftDownPoint = value;
                }
            }
            private Point3d upRightPoint
            {
                get
                {
                    return _UpRightPoint;
                }
                set
                {
                    _UpRightPoint = value;
                }
            }

            public objectBound(Point3d DownLeftPoint, Point3d UpRightPoint)
            {
                upRightPoint  = UpRightPoint;
                downLeftPoint = DownLeftPoint;
            }
        }

        string[] FilePaths = null;
        Size defSize = new Size(30, 30);
        public BlockEditeur(string filePath)
        {
            InitializeComponent();
            if (filePath != "" && filePath != null)
            {
                FilePaths[0] = filePath;
                StringBuilder str = new StringBuilder();
                foreach (var path in FilePaths)
                {
                    str.Append(path + System.Environment.NewLine);
                }
                textBox1.Text = str.ToString();
            }
            
        }

        private void BlockEditeur_ResizeEnd(object sender, EventArgs e)
        {
            this.tabControl1.Size = new Size(this.Size.Width - 39, this.statusStrip1.Location.Y - 20);

            this.button1.Location = new Point(this.button1.Location.X, this.tabControl1.Size.Height - 54);

            this.button2.Location = new Point(this.button2.Location.X, this.tabControl1.Size.Height - 54);

            this.listView1.Size = new Size(this.listView1.Size.Width, this.tabControl1.Size.Height - 158);

            this.B_BiggerImg.Size = new Size(this.B_BiggerImg.Size.Width, this.listView1.Size.Height / 2 - 5);

            this.B_SmallerImg.Location = new Point(this.B_SmallerImg.Location.X, this.B_BiggerImg.Location.Y + this.B_BiggerImg.Size.Height + 10);
            this.B_SmallerImg.Size = new Size(this.B_SmallerImg.Size.Width, this.listView1.Size.Height / 2 - 5);

            this.button3.Location = new Point(this.B_BiggerImg.Location.X + this.B_BiggerImg.Size.Width + 5, this.B_BiggerImg.Location.Y);
            this.button3.Size = new Size(this.button3.Size.Width, this.listView1.Size.Height);

        }

        List<string> FileAndPahts = new List<string>();
        //string BE_NameAndExtention = string.Empty;
        private void B_ChoisirFiche_Click(object sender, EventArgs e)
        {
            List<string> fileNames = new List<string>();
            //DotNetARX.BlockTools.ImportBlocksFromDwg(FilePath,)
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = true;
                fileDialog.Title = "请选择文件.";
                fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePaths = fileDialog.SafeFileNames;



                    StringBuilder str = new StringBuilder();
                    foreach (var path in FilePaths)
                    {
                        str.Append(path + System.Environment.NewLine);

                        StringBuilder str2 = new StringBuilder();
                        string[] filePathAndExtentions = fileDialog.FileName.Split(new[] { "\\" }, StringSplitOptions.None);
                        for (int i = 0; i < filePathAndExtentions.Length - 1; i++)
                        {
                            str2.Append(filePathAndExtentions[i] + "\\");
                        }
                        str2.Append(path);
                        FileAndPahts.Add(str2.ToString());
                    }
                    textBox1.Text = str.ToString();

                }

            }
        }

        private void B_ReadBlock_Click(object sender, EventArgs e)
        {
            foreach (var FilePaths in FileAndPahts)
            {
                GenerateBlockPreview(FilePaths);
            }
            

            ///
            /// 将生成的bgm文件加入到listview中
            /// fileListView(string bmgFilesLocation);
            ///
        }

        /// DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
        ///  代码...
        /// m_DocumentLock.Dispose();
        /// 
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
                        BlockTableRecord btRecord = (BlockTableRecord)trans.GetObject(blockRecordId, OpenMode.ForRead);
                        // 如果是匿名块、布局块及没有预览图形的块，则返回
                        if (btRecord.IsAnonymous || btRecord.IsLayout || !btRecord.HasPreviewIcon) continue;
                        
                        Bitmap preview;
                        try
                        {
                            StringBuilder str = new StringBuilder();
                            if (!btRecord.IsDynamicBlock)
                            {
                                str.Append("D");
                            }
                                                        
                            if (btRecord.ExtensionDictionary == null)
                            {
                                str.Append("E");
                            }

                            // 获取块预览图案（适用于AutoCAD 2008及以下版本）
                            //preview = BlockThumbnailHelper.GetBlockThumbanail(btr.ObjectId);

                            preview = btRecord.PreviewIcon; // 适用于AutoCAD 2009及以上版本 
                            preview.Save(path + "\\" + btRecord.Name + "_" + str.ToString() + ".bmp"); // 保存块预览图案


                            //自动整理图块比例
                            //listBox1.Items.Add(btRecord.Name);
                            autoBlockScaleFit(db, btRecord, trans);

                            //int numa = sizeEntity.Count;
                            //重新生成块
                            //btr.
                            //在图中插入 块参照 (画块)
                            spaceId.InsertBlockReference("0", btRecord.Name, new Autodesk.AutoCAD.Geometry.Point3d(100 * i, 100 * i, 0), new Autodesk.AutoCAD.Geometry.Scale3d(1), 0);
                        }
                        catch (Exception ee)
                        {
                            trans.Abort();
                            ed.WriteMessage("错误;  " + ee.ToString());
                            //preview = btr.PreviewIcon; // 适用于AutoCAD 2009及以上版本
                        }
                        
                    }
                    //
                    trans.Commit();
                    int numa = sizeEntity.Count;
                    foreach (var item in typeAndNum)
                    {

                        listBox1.Items.Add("type " + item.Key + "; Number: " + item.Value); 
                    }
                    m_DocumentLock.Dispose();


                    fillImageList("C:\\Temp", defSize);
                    fileListView("C:\\Temp");
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

        ImageList imageList1;
        List<string> filename;

        private void fillImageList(string bmgFilesLocation,Size imgSize)
        {
            DirectoryInfo Dir = new DirectoryInfo(bmgFilesLocation);
            imageList1 = new ImageList();
            filename = new List<string>();
            try
            {

                foreach (FileInfo f in Dir.GetFiles("*.bmp")) //查找文件
                {
                    imageList1.Images.Add(Bitmap.FromFile(@"" + bmgFilesLocation + "\\" + f));
                    imageList1.ImageSize = imgSize;
                    filename.Add(f.ToString().Split('.')[0]);
                    //imageListSmall.Images.Add(Bitmap.FromFile(@"..\..\绘图.bmp"));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        
        //用块的预览图填充listview
        private void fileListView(string bmgFilesLocation)
        {
            //to do           

            this.listView1.View = View.LargeIcon;
            this.listView1.LargeImageList = imageList1;
            
            this.listView1.BeginUpdate();
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = i;

                lvi.Text = filename[i] + ""; //imageList1.Images[i].;

                this.listView1.Items.Add(lvi);
            }  

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BlockPreview bp = new BlockPreview();
            bp.Show();
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            //button3.Size = new Size(button3.Size.Width, listView1.Size.Height);
            //button3.Location = new Point(B_BiggerImg.Location.X + B_BiggerImg.Size.Width + 6, listView1.Location.Y);
        }

        Dictionary<string, int> typeAndNum = new Dictionary<string, int>();
        Dictionary<string, objectBound> sizeEntity = new Dictionary<string, objectBound>();

       

        public void autoBlockScaleFit(Database db, BlockTableRecord blockTR, Transaction tr)
        {
            Point3d DownLeft_Point = new Point3d();
            Point3d UpRight_Point = new Point3d();
            string compareResult = string.Empty;

            bool started = false;
            try
            {
                string blockName = blockTR.Name;
                foreach (ObjectId entId in blockTR)
                {

                    DBObject objSubBlock = (DBObject)tr.GetObject(entId, OpenMode.ForWrite);

                    if (objSubBlock.Bounds == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (started == false)
                        {

                            UpRight_Point = objSubBlock.Bounds.Value.MaxPoint;
                            DownLeft_Point = objSubBlock.Bounds.Value.MinPoint;
                            started = true;
                            continue;
                        }
                        else
                        {
                            string compareMaxRes = string.Empty;
                            string compareMinRes = string.Empty;

                            if (objSubBlock.Bounds.Value.MaxPoint.X > UpRight_Point.X)
                            {
                                UpRight_Point = new Point3d(objSubBlock.Bounds.Value.MaxPoint.X, UpRight_Point.Y, UpRight_Point.Z);
                            }
                            if (objSubBlock.Bounds.Value.MaxPoint.Y > UpRight_Point.Y)
                            {
                                UpRight_Point = new Point3d(UpRight_Point.X, objSubBlock.Bounds.Value.MaxPoint.Y, UpRight_Point.Z);
                            }

                            if (objSubBlock.Bounds.Value.MinPoint.X < DownLeft_Point.X)
                            {
                                DownLeft_Point = new Point3d(objSubBlock.Bounds.Value.MinPoint.X, DownLeft_Point.Y, UpRight_Point.Z);
                            }
                            if (objSubBlock.Bounds.Value.MinPoint.Y < DownLeft_Point.Y)
                            {
                                DownLeft_Point = new Point3d(DownLeft_Point.X, objSubBlock.Bounds.Value.MinPoint.Y, UpRight_Point.Z);
                            }
                        }
                    }
                }

                objectBound ob = new objectBound(DownLeft_Point, UpRight_Point);
                sizeEntity.Add(blockName, ob);

                /*
                Polyline c1 = new Polyline();
                c1.CreatePolyCircle(new Point2d(UpRight_Point.X, UpRight_Point.Y), 5);

                Polyline c2 = new Polyline();
                c2.CreatePolyCircle(new Point2d(DownLeft_Point.X, DownLeft_Point.Y), 5); ;

                c1.ColorIndex = 200; //upright
                c2.ColorIndex = 100;
                //db.AddToModelSpace(c1, c2);

                try
                {
                    blockTR.UpgradeOpen();
                    blockTR.AppendEntity(c1);
                    blockTR.AppendEntity(c2);
                    blockTR.DowngradeOpen();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee + "");
                }
                 * */
                
            }
            catch (Exception ee)
            {

            }

        }

       
        public void autoBlockScaleFit(Database db, BlockTableRecord blockTR, Transaction tr, Editor ed)
        {
            List<string> entType = new List<string>();

            try
            {
                string testST = blockTR.Name;
                foreach (ObjectId entId in blockTR)
                {

                    if (entId != null)
                    {
                        Entity entSubBlock = (Entity)tr.GetObject(entId, OpenMode.ForWrite);
                        //DBObject objSubBlock = (DBObject)tr.GetObject(entId, OpenMode.ForWrite);


                        if (!typeAndNum.ContainsKey(entSubBlock.GetType().Name.ToString()))
                        {
                            typeAndNum.Add(entSubBlock.GetType().Name.ToString(), 1);

                        }
                        else
                        {
                            int numType = typeAndNum[entSubBlock.GetType().Name.ToString()];
                            typeAndNum[entSubBlock.GetType().Name.ToString()] = numType + 1;
                        }

                        //
                        Point3d maxPoint;
                        Point3d minPoint;
                        //Point3d maxPoint1;
                        //Point3d minPoint1;
                        if (true)
                        {
                            maxPoint = entSubBlock.GeometricExtents.MaxPoint;
                            minPoint = entSubBlock.GeometricExtents.MinPoint;


                            //maxPoint1 = entSubBlock.Bounds.Value.MaxPoint;
                            //minPoint1 = entSubBlock.Bounds.Value.MinPoint;

                            /*Polyline c1 = new Polyline();
                            c1.CreatePolyCircle(new Point2d(maxPoint.X, maxPoint.Y), 5);

                            Polyline c2 = new Polyline();
                            c2.CreatePolyCircle(new Point2d(minPoint.X, minPoint.Y), 5);

                            db.AddToModelSpace(c1, c2);*/
                        }
                        else
                        {

                        }


                        //

                        //

                        //

                        string[] temp = entSubBlock.GetType().ToString().ToLower().Split(new[] { "." }, StringSplitOptions.None);
                        string type = temp[temp.Length - 1];
                        switch (type)
                        {
                            case ("line"):
                                //entSubBlock.GeometricExtents.MaxPoint
                                break;
                            case ("mline"):
                                //entSubBlock
                                break;
                            case ("hatch"):
                                //entSubBlock
                                //entSubBlock.Highlight();
                                break;
                            case ("polyline"):
                                //entSubBlock
                                break;
                            case ("circle"):
                                //entSubBlock
                                maxPoint = entSubBlock.GeometricExtents.MaxPoint;
                                minPoint = entSubBlock.GeometricExtents.MinPoint;

                                Polyline c1 = new Polyline();
                                c1.CreatePolyCircle(new Point2d(maxPoint.X, maxPoint.Y), 5);

                                Polyline c2 = new Polyline();
                                c2.CreatePolyCircle(new Point2d(minPoint.X, minPoint.Y), 5);

                                c1.ColorIndex = entSubBlock.ColorIndex;
                                c2.ColorIndex = entSubBlock.ColorIndex;

                                try
                                {
                                    blockTR.UpgradeOpen();
                                    blockTR.AppendEntity(c1);
                                    blockTR.AppendEntity(c2);
                                    blockTR.DowngradeOpen();
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                                //db.AddToModelSpace(c1, c2);
                                break;
                            case ("dbtext"):

                                break;
                            case ("elipse"):

                                break;
                            case ("arc"):

                                break;
                            case ("block reference"):

                                break;
                            case ("aligned dimension"):

                                break;
                            case ("attribute definition"):

                                break;

                        }
                        entSubBlock.DowngradeOpen();
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ee)
            {
                //tr.Abort();
                MessageBox.Show("" + ee + System.Environment.NewLine + blockTR.Name, "错误");
                ed.WriteMessage("错误信息: " + ee.Message + System.Environment.NewLine + "块" + blockTR.Name);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Size defSize = new System.Drawing.Size(30, 30);
            fillImageList("C:\\Temp", defSize);
            fileListView("C:\\Temp");
        }

        //选中缩略图
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string a = listView1.SelectedItems[0].Text.ToString();
                }
                
            }
        }

        private void B_BiggerImg_Click(object sender, EventArgs e)
        {
            if (imageList1.Images.Count != 0 || imageList1 != null)
            {
                System.Drawing.Size biggerSize = new Size(imageList1.ImageSize.Width + 5, imageList1.ImageSize.Height + 5);
                fillImageList("C:\\Temp", biggerSize);
                fileListView("C:\\Temp");
            }
        }

        private void B_SmallerImg_Click(object sender, EventArgs e)
        {
            if (imageList1.Images.Count != 0 || imageList1 != null)
            {
                if (imageList1.ImageSize.Width > 30 && imageList1.ImageSize.Height > 30)
                {
                    System.Drawing.Size smallerSize = new Size(imageList1.ImageSize.Width - 5, imageList1.ImageSize.Height - 5);
                    fillImageList("C:\\Temp", smallerSize);
                    fileListView("C:\\Temp");
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string blockDel = listView1.SelectedItems[0].Text;
            DialogResult ret = MessageBox.Show("确认删除块" + System.Environment.NewLine + blockDel, "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.OK)
            {
                //从块表中删除,
                //todo

                //重新生成缩略图
                //todo
            }
        }

        private void regenerateBlock(BlockTableRecord btr)
        {
            DBObjectCollection acDBObjColl = new DBObjectCollection();
            Polyline acPoly = new Polyline();
            acPoly.Explode(acDBObjColl);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = listBox1.SelectedItem.ToString();
        }

        private void listBox1_Click_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = listBox1.SelectedItem.ToString();
        }

        private void BlockEditeur_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void listViewMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            listView1.MultiSelect = listViewMultiSelect.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument)
            {

                try
                {
                    acDoc.SendStringToExecute("BEDIT ", false, false, false);
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee + "", "BEDIT命令错误");
                }
            }


        }

        private void B_AutoClean_Click(object sender, EventArgs e)
        {
            //PURGE 
            using (Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument)
            {
                try
                {
                    acDoc.SendStringToExecute("PURGE ", false, false, false);
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee+"","PURGE命令错误");
                }
            }



            // Draws a circle and zooms to the extents or 

            // limits of the drawing

            
        }

        


        //private DBObjectCollection explodBlock()
        //{
        //    return null;
        //}

        //private void 
    }
}
