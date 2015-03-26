using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
