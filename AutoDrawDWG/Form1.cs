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

        //
        TextBox T_AddStation;
        Button B_AddStation;
        ListBox L_AddStation;
        //

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
                //groupBox1.Text = ProjectName;

                this.Size = new Size(300, 300);
                //添加第一层Groupbox
                GroupBox gb = new GroupBox();
                gb.Name = "MainGroueBox";
                gb.Location = new Point(12, 41);
                gb.Size = new Size(this.Size.Width / 2 - 20, this.Size.Height - 92);
                gb.Text = "设置站点";
                this.Controls.Add(gb);

                ///在第一层GroupBox中添加按钮用来设置项目中站点
                /// 添加textBox和按钮
                /// 
                //textBox
                T_AddStation = new TextBox();
                T_AddStation.Name = "T_AddStation";
                T_AddStation.Text = "添加站点";
                T_AddStation.Location = new Point(8, 24);
                T_AddStation.Size = new Size(gb.Size.Width - 16, 24);

                //按钮
                B_AddStation = new Button();
                B_AddStation.Name = "B_AddStation";
                B_AddStation.Text = "添加站点";
                B_AddStation.Location = new Point(8, 54);
                B_AddStation.Size = new Size(gb.Size.Width - 16, 23);
                B_AddStation.MouseClick += B_AddStation_MouseClick;

                //listBox
                L_AddStation = new ListBox();
                L_AddStation.Name = "B_AddStation";
                L_AddStation.Location = new Point(8, 83);
                L_AddStation.Size = new Size(gb.Size.Width - 16, gb.Size.Height - 83 - 10);

                gb.Controls.Add(T_AddStation);  //添加textBox
                gb.Controls.Add(B_AddStation);  //添加按钮
                gb.Controls.Add(L_AddStation);  //添加listBox
                //在第一层GroupBox中添加tableLayoutPannel
            }
        }


        void B_AddStation_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Button == MouseButtons.Left)
            {

                if (T_AddStation.Text == "添加站点" || T_AddStation.Text == "")
                {
                    MessageBox.Show("需要指定站或里程", "注意", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (!ListStation.Contains(T_AddStation.Text))
                    {
                        ListStation.Add(T_AddStation.Text);
                        L_AddStation.Items.Add(T_AddStation.Text.ToString());
                    }
                    
                    
                }
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
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    c.Size = new Size(c.Size.Width, this.Size.Height - 92);
                    foreach(Control subC in c.Controls)
                    {
                        if(subC is ListBox)
                        {
                            subC.Size = new Size(c.Size.Width - 12, c.Size.Height - 83 - 10);
                        }
                    }
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(223, 88);
        }
    }
}
