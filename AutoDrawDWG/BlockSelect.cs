using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace AutoDrawDWG
{
    //目标：多选块。
    public partial class BlockSelect : Form
    {
        public BlockSelect()
        {
            InitializeComponent();
        }

        private void BlockSelect_Load(object sender, EventArgs e)
        {
            /*using (ResXResourceWriter rw = new ResXResourceWriter("Resource.resx"))
            {
                foreach (var VARIABLE in _countryTranslation)
                {
                    rw.AddResource(VARIABLE.Key.ToString(CultureInfo.InvariantCulture), VARIABLE.Value);
                }

            }*/
        }
    }
}
