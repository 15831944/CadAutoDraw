namespace AutoDrawDWG
{
    partial class BlockEditeur
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
            this.components = new System.ComponentModel.Container();
            this.B_ChoisirFiche = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_ReadBlock = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.listViewMultiSelect = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.B_SmallerImg = new System.Windows.Forms.Button();
            this.B_BiggerImg = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.B_AutoClean = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_ChoisirFiche
            // 
            this.B_ChoisirFiche.Location = new System.Drawing.Point(255, 6);
            this.B_ChoisirFiche.Name = "B_ChoisirFiche";
            this.B_ChoisirFiche.Size = new System.Drawing.Size(75, 37);
            this.B_ChoisirFiche.TabIndex = 0;
            this.B_ChoisirFiche.Text = "选择文件";
            this.B_ChoisirFiche.UseVisualStyleBackColor = true;
            this.B_ChoisirFiche.Click += new System.EventHandler(this.B_ChoisirFiche_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 37);
            this.textBox1.TabIndex = 2;
            // 
            // B_ReadBlock
            // 
            this.B_ReadBlock.Location = new System.Drawing.Point(336, 6);
            this.B_ReadBlock.Name = "B_ReadBlock";
            this.B_ReadBlock.Size = new System.Drawing.Size(75, 37);
            this.B_ReadBlock.TabIndex = 3;
            this.B_ReadBlock.Text = "读取块";
            this.B_ReadBlock.UseVisualStyleBackColor = true;
            this.B_ReadBlock.Click += new System.EventHandler(this.B_ReadBlock_Click);
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(9, 68);
            this.listView1.MinimumSize = new System.Drawing.Size(321, 242);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(321, 242);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(194, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "删除块";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 407);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_AutoClean);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.listViewMultiSelect);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.B_SmallerImg);
            this.tabPage1.Controls.Add(this.B_BiggerImg);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.B_ChoisirFiche);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.B_ReadBlock);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "导入块";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 345);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listViewMultiSelect
            // 
            this.listViewMultiSelect.AutoSize = true;
            this.listViewMultiSelect.Location = new System.Drawing.Point(89, 49);
            this.listViewMultiSelect.Name = "listViewMultiSelect";
            this.listViewMultiSelect.Size = new System.Drawing.Size(50, 17);
            this.listViewMultiSelect.TabIndex = 13;
            this.listViewMultiSelect.Text = "多选";
            this.listViewMultiSelect.UseVisualStyleBackColor = true;
            this.listViewMultiSelect.CheckedChanged += new System.EventHandler(this.listViewMultiSelect_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(397, 68);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(151, 238);
            this.listBox1.TabIndex = 12;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click_1);
            // 
            // B_SmallerImg
            // 
            this.B_SmallerImg.Location = new System.Drawing.Point(336, 205);
            this.B_SmallerImg.Name = "B_SmallerImg";
            this.B_SmallerImg.Size = new System.Drawing.Size(22, 105);
            this.B_SmallerImg.TabIndex = 11;
            this.B_SmallerImg.Text = "-";
            this.B_SmallerImg.UseVisualStyleBackColor = true;
            this.B_SmallerImg.Click += new System.EventHandler(this.B_SmallerImg_Click);
            // 
            // B_BiggerImg
            // 
            this.B_BiggerImg.Location = new System.Drawing.Point(336, 68);
            this.B_BiggerImg.Name = "B_BiggerImg";
            this.B_BiggerImg.Size = new System.Drawing.Size(22, 103);
            this.B_BiggerImg.TabIndex = 10;
            this.B_BiggerImg.Text = "+";
            this.B_BiggerImg.UseVisualStyleBackColor = true;
            this.B_BiggerImg.Click += new System.EventHandler(this.B_BiggerImg_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(364, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 242);
            this.button3.TabIndex = 9;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "已读取块:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "目标文件:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(554, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生成块";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // B_AutoClean
            // 
            this.B_AutoClean.Location = new System.Drawing.Point(89, 316);
            this.B_AutoClean.Name = "B_AutoClean";
            this.B_AutoClean.Size = new System.Drawing.Size(75, 23);
            this.B_AutoClean.TabIndex = 15;
            this.B_AutoClean.Text = "清理";
            this.B_AutoClean.UseVisualStyleBackColor = true;
            this.B_AutoClean.Click += new System.EventHandler(this.B_AutoClean_Click);
            // 
            // BlockEditeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 457);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "BlockEditeur";
            this.Text = "块编辑";
            this.Load += new System.EventHandler(this.BlockEditeur_Load);
            this.ResizeEnd += new System.EventHandler(this.BlockEditeur_ResizeEnd);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_ChoisirFiche;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_ReadBlock;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_SmallerImg;
        private System.Windows.Forms.Button B_BiggerImg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox listViewMultiSelect;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button B_AutoClean;
    }
}