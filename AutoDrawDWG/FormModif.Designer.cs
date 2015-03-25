namespace AutoDrawDWG
{
    partial class FormModif
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.T_From_Name = new System.Windows.Forms.TextBox();
            this.T_From_Loc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.T_To_Name = new System.Windows.Forms.TextBox();
            this.T_To_Loc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // T_From_Name
            // 
            this.T_From_Name.Location = new System.Drawing.Point(12, 25);
            this.T_From_Name.Name = "T_From_Name";
            this.T_From_Name.Size = new System.Drawing.Size(100, 20);
            this.T_From_Name.TabIndex = 0;
            // 
            // T_From_Loc
            // 
            this.T_From_Loc.Location = new System.Drawing.Point(12, 51);
            this.T_From_Loc.Name = "T_From_Loc";
            this.T_From_Loc.Size = new System.Drawing.Size(100, 20);
            this.T_From_Loc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "--->";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // T_To_Name
            // 
            this.T_To_Name.Location = new System.Drawing.Point(161, 25);
            this.T_To_Name.Name = "T_To_Name";
            this.T_To_Name.Size = new System.Drawing.Size(100, 20);
            this.T_To_Name.TabIndex = 7;
            // 
            // T_To_Loc
            // 
            this.T_To_Loc.Location = new System.Drawing.Point(161, 51);
            this.T_To_Loc.Name = "T_To_Loc";
            this.T_To_Loc.Size = new System.Drawing.Size(100, 20);
            this.T_To_Loc.TabIndex = 8;
            // 
            // FormModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 160);
            this.Controls.Add(this.T_To_Loc);
            this.Controls.Add(this.T_To_Name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T_From_Loc);
            this.Controls.Add(this.T_From_Name);
            this.Name = "FormModif";
            this.Text = "FormModif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_From_Name;
        private System.Windows.Forms.TextBox T_From_Loc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox T_To_Name;
        private System.Windows.Forms.TextBox T_To_Loc;
    }
}