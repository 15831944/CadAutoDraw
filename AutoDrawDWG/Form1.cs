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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class StationAndLocation
        {
            private string id = string.Empty;
            private string name = string.Empty;
            private string location = string.Empty;

            //可以根据自己的需求继续添加,如：private Int32 m_Index；

            public StationAndLocation()
            { }
            public StationAndLocation(string sid, string sname, string slocation)
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
            private StationAndLocation _fromStation;
            private StationAndLocation _toStation;

            public StationAndLocation FromStation
            {
                get { return this._fromStation; }
                set { this._fromStation = value; }
            }

            public StationAndLocation ToStation
            {
                get { return this._toStation; }
                set { this._toStation = value; }
            }

            public BinoStation()
            {

            }

            public BinoStation(StationAndLocation fromStation, StationAndLocation toStation)
            {
                this._fromStation = fromStation;
                this._toStation = toStation;
            }
        }

        public class BlockStockLocation
        {
            private string _location;

            public string Location
            {
                get
                {
                    return this._location;
                }
                set
                {
                    this._location = value;
                }
            }

            public BlockStockLocation(string StockLocation)
            {
                this.Location = StockLocation;
            }
        }

        //文件名和文件格式。
        string NameAndExtention;

        string ProjectName;
        string addStation = "";
        Dictionary<string, string> ListStation = new Dictionary<string, string>();
        Dictionary<string, string> isEditStation = new Dictionary<string, string>();

        DataSet DS_Station;
        DataTable inforTable;
        DataColumn stationID;
        DataSet DS_EditStation = new DataSet();

        BlockStockLocation BlockFileLocation = new BlockStockLocation("C:\\Temp");
        List<StationAndLocation> list_StationAndLocation = new List<StationAndLocation>();
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
            toolStripStatusLabel1.Text = "";
            DS_Station = new DataSet("StationInfo");
            inforTable = DS_Station.Tables.Add("StationAndInfo");
            //DataColumn idColumn = new DataColumn("id",         Type.GetType("System.Int32"),"");
            //idColumn.AutoIncrement=true;
            stationID = inforTable.Columns.Add("ID", typeof(Int32));
            stationID.AutoIncrement = true;

            inforTable.Columns.Add("站名", typeof(string));
            inforTable.Columns.Add("里程", typeof(string));

            if (File.Exists(BlockFileLocation + "\\BlockBase.dwg"))
            {
                toolStripStatusLabel1.Text = "未找到图块库.";
            }
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

                        StationAndLocation StationAndLocation = new StationAndLocation(list_StationAndLocation.Count.ToString(), T_AddSt.Text.ToString().Replace(" ", ""), T_StaLoc.Text.ToString().Replace(" ", "").ToUpper());
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

        BlockEditeur BE;
        private void B_Admin_Click(object sender, EventArgs e)
        {

            if (BE == null || BE.IsDisposed)
            {
                BE = new BlockEditeur(NameAndExtention, BlockFileLocation.Location);
                BE.Owner = this;
                //BE.ShowDialog();
                BE.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void 设置储存位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void B_Draw_Click(object sender, EventArgs e)
        {
            string layerName = Com_CadLayer.SelectedItem.ToString(); //绘制于图层

            Draw_Station_Location dsl = new Draw_Station_Location();
            StationAndLocation station_location = new StationAndLocation("1", "AA", "AA1+000");
            dsl.drawSL(station_location, string layerName);
            //dsl.DrawStationMark(new Autodesk.AutoCAD.Geometry.Point3d(), true);
        }


    }

}
