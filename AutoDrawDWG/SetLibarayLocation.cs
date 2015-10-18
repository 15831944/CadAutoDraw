using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace AutoDrawDWG
{
    public partial class SetLibarayLocation : Form
    {
        public SetLibarayLocation()
        {
            InitializeComponent();
        }

        private void SetLibarayLocation_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void B_Location_Click(object sender, EventArgs e)
        {
            string path = "";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.ShowNewFolderButton = false;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                T_Location.Text = path;

                string s = Properties.Resources.AppSetting;

                richTextBox1.Text = s;
                /*if (textBox2.Text == "" || textBox2.Text == null)
                {
                    textBox2.Text = s;
                }
                else if (textBox2.Text != s)
                {
                    //Properties.Resources.TextFi
                }*/
            }
            else
            {
            }
        }
    }
}
