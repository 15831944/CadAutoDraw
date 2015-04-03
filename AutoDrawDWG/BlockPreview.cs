using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
//using System.Threading.Tasks;
using System.Collections.Generic;

namespace AutoDrawDWG
{
    public partial class BlockPreview : Form
    {
        public BlockPreview()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x, y;
            Random rd = new Random();
            x = rd.Next(this.Size.Width - label1.Size.Width);
            y = rd.Next(this.Size.Height - label1.Size.Height);
            label1.Location = new Point(x, y);
        }

        private void BlockPreview_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
