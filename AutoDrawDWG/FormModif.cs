using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoDrawDWG
{
    public partial class FormModif : Form
    {
        int indexThis;
        Form1.BinoStation BiStation = new Form1.BinoStation();
        Form1.BinoStation NewBiStation;
        index_BinoStation Index_NewBiStation;
        public class index_BinoStation
        {
            private int _index;
            private Form1.BinoStation _biStation;

            public int index
            {
                get { return this._index; }
                set { this._index = value; }
            }
            public Form1.BinoStation biStation
            {
                get { return this._biStation; }
                set { this._biStation = value; }
            }

            public index_BinoStation(int Index, Form1.BinoStation BiStation)
            {
                this.index = Index;
                this.biStation = BiStation;
            }
        }

        public index_BinoStation Form2Value
        {

            get
            {
                return Index_NewBiStation;

            }

            set
            {

                this.Index_NewBiStation = value;

            }

        }

        public event EventHandler changeValues;

      
        public FormModif(int index,Form1.BinoStation B_S)
        {
            InitializeComponent();
            indexThis = index;
            BiStation = B_S;
            T_From_Name.Text = BiStation.FromStation.Name;
            T_From_Loc.Text = BiStation.FromStation.Location;
            T_To_Name.Text = BiStation.ToStation.Name;
            T_To_Loc.Text = BiStation.ToStation.Location;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changeValues != null)
            {
                if (T_From_Name.Text != BiStation.FromStation.Name || T_From_Loc.Text != BiStation.FromStation.Location || T_To_Name.Text != BiStation.ToStation.Name || T_To_Loc.Text != BiStation.ToStation.Location)
                {
                    DialogResult messageboxResult = MessageBox.Show("确认变更?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (messageboxResult == DialogResult.Yes)
                    {
                        //from
                        Form1.ListStationAndLocation from = new Form1.ListStationAndLocation(BiStation.FromStation.ID.ToString(), T_From_Name.Text.Replace(" ", "").ToString(), T_From_Loc.Text.ToUpper());
                        //to
                        Form1.ListStationAndLocation to = new Form1.ListStationAndLocation(BiStation.ToStation.ID.ToString(), T_To_Name.Text.Replace(" ", "").ToString(), T_To_Loc.Text.ToUpper());

                        NewBiStation = new Form1.BinoStation(from, to);

                        Index_NewBiStation = new index_BinoStation(indexThis, NewBiStation);
                    }
                }
                changeValues(this, EventArgs.Empty);  //当窗体触发事件，传递自身引用
                MessageBox.Show(BiStation.FromStation.Name + "-->" + T_From_Name.Text + System.Environment.NewLine +
                                BiStation.FromStation.Location + "-->" + T_From_Loc.Text + System.Environment.NewLine +
                                BiStation.ToStation.Name + "-->" + T_To_Name.Text + System.Environment.NewLine +
                                BiStation.ToStation.Location + "-->" + T_To_Loc.Text, "已修改");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
