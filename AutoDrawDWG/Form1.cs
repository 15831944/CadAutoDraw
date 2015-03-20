using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        string ProjectName;
        string addStation = "";
        List<string> ListStation = new List<string>();
        List<string> isEditStation = new List<string>();

        DataSet DS_Station;
        DataTable inforTable;
        DataColumn stationID;
        DataSet DS_EditStation = new DataSet();


        private void B_Valide_Click(object sender, EventArgs e)
        {
            //if (T_ProjectName.Text == "")
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Multiselect = false;
                    fileDialog.Title = "请选择文件.";
                    fileDialog.Filter = "cad|*.dwg|所有文件(*.*)|*.*";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string NameAndExtention = fileDialog.FileName;

                        string[] filePathAndExtentions = NameAndExtention.Split(new[] { "\\" }, StringSplitOptions.None);
                        string fileNameAndExtention = filePathAndExtentions[filePathAndExtentions.Length - 1];

                        string[] fileNameAndExtentions = fileNameAndExtention.Split(new[] { "." }, StringSplitOptions.None);
                        string fileName = fileNameAndExtentions[0];
                        T_ProjectName.Text = fileName;
                        ProjectName = fileName;
                    }

                }
                this.Text = "绘制" + ProjectName + "线";

                this.Size = new Size(700, 400);
                MainGroupBox.Visible = true;
            }
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
            this.Size = new Size(223, 88);

            DS_Station = new DataSet("StationInfo");
            inforTable = DS_Station.Tables.Add("StationAndInfo");
            //stationID = inforTable.Columns.Add("StationID", typeof(Int32));
            inforTable.Columns.Add("StationName", typeof(string));
            inforTable.Columns.Add("DistanceMark", typeof(string));

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

                    if (fonctions.isExMatch(T_AddSt.Text.ToString(), @"^[\u4e00-\u9fa5]*$"))
                    {
                        if (!ListStation.Contains(T_AddSt.Text))
                        {
                            List<string> ListDistance = new List<string>();
                            if (fonctions.isExMatch(T_StaLoc.Text.ToString().ToUpper(), @"^([A-Z]{2,3})(\d*).(\d{0,4})$", out ListDistance))
                            {
                                DataRow dr = DS_Station.Tables["StationAndInfo"].NewRow();
                                //dr["StationID"] = DS_Station.Tables["StationAndInfo"].Rows.Count + 1;
                                dr["StationName"] = T_AddSt.Text;
                                dr["DistanceMark"] = T_StaLoc.Text.ToString().ToUpper();

                                DS_Station.Tables["StationAndInfo"].Rows.Add(dr);
                                dataGridView1.DataSource = DS_Station;
                                dataGridView1.Columns[1].HeaderText = "站名";
                                dataGridView1.Columns[2].HeaderText = "里程";
                            }



                            
                            
                            //DR_Stat
                            //ListStation.Add(T_AddSt.Text + "," + T_StaLoc.Text.ToString().ToUpper());

                            //listBox
                            L_AddSt.Items.Add(T_AddSt.Text + "," + T_StaLoc.Text.ToString().ToUpper());
                            //
                            isEditStation.Add(T_AddSt.Text + "," + T_StaLoc.Text.ToString().ToUpper());

                            //comboBox1.DataSourceChanged -= comboBox1_DataSourceChanged;
                            comboBox1.DataSource = DS_Station;
                            comboBox1.DisplayMember = DS_Station.Tables[0].Columns["StationName"].ToString();
                            //comboBox1.DataSourceChanged += comboBox1_DataSourceChanged;

                            //comboBox2.DataSourceChanged -= comboBox1_DataSourceChanged;
                            comboBox2.DataSource = DS_Station;
                            comboBox2.DisplayMember = DS_Station.Tables[0].Columns["StationName"].ToString();
                            //comboBox2.DataSourceChanged += comboBox1_DataSourceChanged;

                            this.Size = new Size(700, this.Size.Height);
                            groupBox1.Visible = true;
                            groupBox1.Text = "站间设备设置";

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = DS_Station.Tables["StationAndInfo"];
                        }
                    }
                    else
                    {
                        MessageBox.Show("名称不符合规范" + System.Environment.NewLine + "或与管理员联系.", "注意", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                    
	
                    
                    
                }
            }

        private void comboBox1_DataSourceChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isEditStation.Contains(comboBox1.SelectedItem.ToString()))
            {
                //isEditStation.Remove(comboBox1.SelectedItem.ToString());
                comboBox1.DataSource = isEditStation; 
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isEditStation.Contains(comboBox2.SelectedItem.ToString()))
            {
                //isEditStation.Remove(comboBox2.SelectedItem.ToString());
                comboBox2.DataSource = isEditStation;
            }
        }


        
    }
}
