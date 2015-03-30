using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using DotNetARX;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AutoDrawDWG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ListStationAndLocation
        {
            private string id = string.Empty;
            private string name = string.Empty;
            private string location = string.Empty;
            
            //可以根据自己的需求继续添加,如：private Int32 m_Index；

            public ListStationAndLocation()
            { }
            public ListStationAndLocation(string sid, string sname,string slocation)
            {
                id = sid;
                name = sname;
                location = slocation;
            }
            public override string ToString()
            {
                return this.name;
            }

            public string ID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }
            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }
            public string Location
            {
                get
                {
                    return this.location;
                }
                set
                {
                    this.location = value;
                }
            }
        }

        public class BinoStation
        {
            private ListStationAndLocation _fromStation;
            private ListStationAndLocation _toStation;

            public ListStationAndLocation FromStation
            {
                get { return this._fromStation; }
                set { this._fromStation = value; }
            }

            public ListStationAndLocation ToStation
            {
                get { return this._toStation; }
                set { this._toStation = value; }
            }

            public BinoStation()
            {

            }

            public BinoStation(ListStationAndLocation fromStation, ListStationAndLocation toStation)
            {
                this._fromStation = fromStation;
                this._toStation = toStation;
            }
        }

        //文件名和文件格式。
        string NameAndExtention;

        string ProjectName;
        string addStation = "";
        Dictionary<string,string> ListStation = new Dictionary<string,string>();
        Dictionary<string,string> isEditStation = new Dictionary<string,string>();

        DataSet DS_Station;
        System.Data.DataTable inforTable;
        System.Data.DataColumn stationID;
        DataSet DS_EditStation = new DataSet();
        
        List<ListStationAndLocation> list_StationAndLocation = new List<ListStationAndLocation>();
        List<BinoStation> list_BinoStation = new List<BinoStation>();

        private void B_Valide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择文件.";
                fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    NameAndExtention = fileDialog.FileName;

                    string[] filePathAndExtentions = NameAndExtention.Split(new[] { "\\" }, StringSplitOptions.None);
                    string fileNameAndExtention = filePathAndExtentions[filePathAndExtentions.Length - 1];

                    string[] fileNameAndExtentions = fileNameAndExtention.Split(new[] { "." }, StringSplitOptions.None);
                    string fileName = fileNameAndExtentions[0];
                    T_ProjectName.Text = fileName;
                    ProjectName = fileName;
                }

            }
            this.Text = "绘制" + ProjectName + "线";

            this.Size = new Size(700, 420);
            MainGroupBox.Visible = true;
            
        }


        private void T_ProjectName_TextChanged(object sender, EventArgs e)
        {
            if (T_ProjectName.Text != ProjectName)
            {
                ProjectName = T_ProjectName.Text;
                this.Text = "绘制" + ProjectName + "线";
                //groupBox1.Text = ProjectName;
            }
        }
        
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            MainGroupBox.Size = new Size(MainGroupBox.Size.Width, this.Size.Height - 92);
            L_AddSt.Size = new Size(MainGroupBox.Size.Width - 12, MainGroupBox.Size.Height - 83 - 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(223, 100);

            DS_Station = new DataSet("StationInfo");
            inforTable = DS_Station.Tables.Add("StationAndInfo");
            //DataColumn idColumn = new DataColumn("id",         Type.GetType("System.Int32"),"");
            //idColumn.AutoIncrement=true;
            stationID = inforTable.Columns.Add("ID", typeof(Int32));
            stationID.AutoIncrement = true;

            inforTable.Columns.Add("站名", typeof(string));
            inforTable.Columns.Add("里程", typeof(string));

            timer1.Start();
            //inforTable.PrimaryKey = new DataColumn[] { stationID };

        }

        private void B_AddSt_Click(object sender, EventArgs e)
        {
            if (T_AddSt.Text == "添加站点" || T_AddSt.Text == "")
            {
                MessageBox.Show("需要指定站或里程", "注意", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                FonctionsCs fonctions = new FonctionsCs();
                List<string> ListDistance = new List<string>();

                if (fonctions.isExMatch(T_AddSt.Text.ToString().Replace(" ", ""), @"^[\u4e00-\u9fa5]*$") && fonctions.isExMatch(T_StaLoc.Text.ToString().Replace(" ", "").ToUpper(), @"^([A-Z]*)(\d*)([A-Z]*)(\d*).(\d{0,4})$", out ListDistance))
                {
                    bool isInTheList = false;


                    if (ListStation.ContainsKey(T_AddSt.Text.ToString().Replace(" ", "")) || ListStation.ContainsValue(T_StaLoc.Text.ToString().Replace(" ", "").ToUpper()))
                    {
                        isInTheList = true;

                    }
                    

                    if (isInTheList == false)
                    {
                        //在dataset中添加数据
                        addData(T_AddSt.Text.ToString().Replace(" ", ""), T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());
                      
                        dataGridView1.DataSource = DS_Station.Tables["StationAndInfo"];

                        //L_AddSt.Items.Add(T_AddSt.Text.ToString().Replace(" ", "") + "," + T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());
                        //
                        ListStation.Add(T_AddSt.Text.ToString().Replace(" ", ""), T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());
                        isEditStation.Add(T_AddSt.Text.ToString().Replace(" ", ""), T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());

                        ListStationAndLocation StationAndLocation = new ListStationAndLocation(list_StationAndLocation.Count.ToString(), T_AddSt.Text.ToString().Replace(" ", ""), T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());
                        list_StationAndLocation.Add(StationAndLocation);

                        this.comboBox_From.Items.Add(StationAndLocation);
                        this.comboBox_From.DisplayMember = "Name";
                        this.comboBox_From.ValueMember = "Location";

                        this.comboBox_To.Items.Add(StationAndLocation);
                        this.comboBox_To.DisplayMember = "Name";
                        this.comboBox_To.ValueMember = "Location";

                        
                        if (groupBox1.Visible == false)
                        {
                            this.Size = new Size(700, this.Size.Height);
                            groupBox1.Visible = true;
                            groupBox1.Text = "站间设备设置";
                        }


                    }


                    else
                    {
                        MessageBox.Show("名称不符合规范" + System.Environment.NewLine + "或与管理员联系.", "注意", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox_From.Text = comboBox_From.SelectedItem.ToString();
                //MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.SelectedColumns.+" ","1");
        }

        private void addData(string name, string location)
        {
            DataRow dr = DS_Station.Tables["StationAndInfo"].NewRow();

            dr["站名"] = name;
            dr["里程"] = location;

            DS_Station.Tables["StationAndInfo"].Rows.Add(dr);

            DS_Station.AcceptChanges();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (DS_Station.HasChanges(DataRowState.Modified | DataRowState.Added) && DS_Station.HasErrors)
            {

            }

            /*
            DataSet tempDataSet = DS_Station.GetChanges(DataRowState.Modified);
            DataTable dataChanges = DS_Station.Tables[0].GetChanges();
            DataSet dsSave = new DataSet();
            dsSave.Tables.Add(dataChanges.Copy());

            if (dsSave != null)
            {

            }
            else
            {
                MessageBox.Show("没有数据需要保存");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //T_NumBlock.Text = comboBox_From.SelectedItem.ToString() + "--" + comboBox_To.SelectedItem.ToString();
            if (comboBox_From.SelectedItem.ToString() != comboBox_To.SelectedItem.ToString())
            {
                //todo
                BinoStation binoStation = new BinoStation(list_StationAndLocation[comboBox_From.SelectedIndex], list_StationAndLocation[comboBox_To.SelectedIndex]);
                list_BinoStation.Add(binoStation);

                //List<ListStationAndLocation>
                refreshListBox(list_BinoStation);
                
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult messageboxResult = MessageBox.Show("确认删除?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (messageboxResult == DialogResult.Yes)
            {
                //int posindex = L_AddSt.IndexFromPoint(new Point(e.X, e.Y));
                list_BinoStation.RemoveAt(L_AddSt.SelectedIndex);
                refreshListBox(list_BinoStation);
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //list_BinoStation[L_AddSt.SelectedIndex];
            using (FormModif fM = new FormModif(L_AddSt.SelectedIndex, list_BinoStation[L_AddSt.SelectedIndex]))
            {
                fM.changeValues += fM_changeValues;
                fM.ShowDialog();
            }
        }

        void fM_changeValues(object sender, EventArgs e)
        {
            FormModif f2 = (FormModif)sender;
            FormModif.index_BinoStation a = f2.Form2Value;
            list_BinoStation[a.index].FromStation.Name = a.biStation.FromStation.Name;
            list_BinoStation[a.index].FromStation.Location = a.biStation.FromStation.Location;
            list_BinoStation[a.index].ToStation.Name = a.biStation.ToStation.Name;
            list_BinoStation[a.index].ToStation.Location = a.biStation.ToStation.Location;
            refreshListBox(list_BinoStation);
            //throw new NotImplementedException();
        }

        private void refreshListBox(List<BinoStation> listElements)
        {
            L_AddSt.Items.Clear();
            //L_AddSt.Items.Add(comboBox_From.SelectedItem.ToString() + "--" + comboBox_To.SelectedItem.ToString());
            foreach (BinoStation bStation in listElements)
            {
                L_AddSt.Items.Add(bStation.FromStation.Name.ToString() + ";" + bStation.FromStation.Location.ToString() + "  ---  " + bStation.ToStation.Name.ToString() + ";" + bStation.ToStation.Location.ToString());
            }
        }

        private void L_AddSt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posindex = L_AddSt.IndexFromPoint(new Point(e.X, e.Y));
                L_AddSt.ContextMenuStrip = null;
                if (posindex >= 0 && posindex < L_AddSt.Items.Count)
                {
                    L_AddSt.SelectedIndex = posindex;
                    contextMenuStrip1.Show(L_AddSt, new Point(e.X, e.Y));
                }
            }
            L_AddSt.Refresh();
        }

        private void B_Admin_Click(object sender, EventArgs e)
        {

            BlockEditeur BE = new BlockEditeur(NameAndExtention, BlockDictionaryPath);
            BE.Owner = this;
            BE.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        public string BlockDictionaryPath = string.Empty;
        private void 块库文件储存位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                
                fileDialog.Title = "请选择文件.";
                fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(fileDialog.FileName))
                    {
                        BlockDictionaryPath = fileDialog.FileName;

                        //生成一个新的cad文件用于储存块
                        CreateNewDwg();

                        //另存为
                        ///AC1027 Autocad 2013
                        ///AC1024 Autocad 2010/2011/2012
                        ///AC1021 AutoCAD 2007/2008/2009
                        ///AC1018 AutoCAD 2004/2005/2006
                        ///AC1015 AutoCAD 2000/2000i/2002
                        DwgVersion CADversion = DwgVersion.AC1500;
                        SaveDwg(BlockDictionaryPath, CADversion);
                        
                    }
                    else
                    {
                        Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
                        ed.WriteMessage("文件已存在.");
                    }

                }

            }
        }

        private void CreateNewDwg()
        {
            string template = "acad.dwt";//模板
            DocumentCollection docs = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
            Editor ed = docs.MdiActiveDocument.Editor;
            Document doc = docs.Add(template);//根据模板创建文档
            Database db = doc.Database;

            using (doc.LockDocument())//锁定文档
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    DBText textTitle = new DBText();
                    textTitle.Position = new Autodesk.AutoCAD.Geometry.Point3d(50, 50, 0);
                    textTitle.Height = 10;
                    textTitle.TextString = "块库";
                    //文字de水平对齐方式为居中
                    textTitle.HorizontalMode = TextHorizontalMode.TextCenter;
                    //文字的垂直对齐方式为居中
                    textTitle.VerticalMode = TextVerticalMode.TextVerticalMid;
                    //设置文字对齐点
                    textTitle.AlignmentPoint = textTitle.Position;

                    //
                    DBText textTime = new DBText();
                    textTime.Height = 100;
                    textTime.TextString = "日期;" + DateTime.Now.ToShortDateString();
                    //文字de水平对齐方式为居中
                    textTime.HorizontalMode = TextHorizontalMode.TextCenter;
                    //文字的垂直对齐方式为居中
                    textTime.VerticalMode = TextVerticalMode.TextVerticalMid;
                    //对齐点
                    textTime.AlignmentPoint = new Point3d(50, 35, 0);
                    db.AddToModelSpace(textTitle, textTime);
                    trans.Commit();//提交事务处理
                }
            }
        }

        private void SaveDwg(string savePath, DwgVersion versionCAD)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //获取DWGTITLED系统变量，它指示当前图形是否已命名
            object tiled = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DWGTITLED");
            if (!doc.Saved()) return;
            if (Convert.ToInt16(tiled) == 0)//如果图形没有命名
                doc.Database.SaveAs(savePath, versionCAD);
            else
                doc.Save();//如果已经命名则保存
        }
    }
}
