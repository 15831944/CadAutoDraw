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


        private void B_Valide_Click(object sender, EventArgs e)
        {
            if (T_ProjectName.Text == "")
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

                this.Size = new Size(300, 400);
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

                    if (fonctions.isExMatch(T_AddSt.Text.ToString(), @"(^[\u4e00-\u9fa5]*)$"))
                    {
                        if (!ListStation.Contains(T_AddSt.Text))
                        {
                            ListStation.Add(T_AddSt.Text);
                            L_AddSt.Items.Add(T_AddSt.Text.ToString());
                            isEditStation.Add(T_AddSt.Text.ToString());
                            comboBox1.DataSource= isEditStation;
                            comboBox1.DataSourceChanged += comboBox1_DataSourceChanged  ; 
                            comboBox2.DataSource = isEditStation;
                            this.Size = new Size(400, this.Size.Height);
                            groupBox1.Visible = true;
                            groupBox1.Text = "站间设备设置";
                        }
                    }
                    else
                    {
                        MessageBox.Show("名称不符合规范"+System.Environment.NewLine+"或与管理员联系.", "注意", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
