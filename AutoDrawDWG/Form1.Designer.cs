﻿namespace AutoDrawDWG
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.T_ProjectName = new System.Windows.Forms.TextBox();
            this.B_Valide = new System.Windows.Forms.Button();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.B_GridModiCancel = new System.Windows.Forms.Button();
            this.B_GridModiValide = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.T_StaLoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.B_AddSt = new System.Windows.Forms.Button();
            this.T_AddSt = new System.Windows.Forms.TextBox();
            this.L_AddSt = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_ChoixEqu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.B_Draw = new System.Windows.Forms.Button();
            this.Combo_Block = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.T_NumBlock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_To = new System.Windows.Forms.ComboBox();
            this.comboBox_From = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.B_AddEq = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.B_Admin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置储存位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Com_CadLayer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // T_ProjectName
            // 
            this.T_ProjectName.Location = new System.Drawing.Point(11, 27);
            this.T_ProjectName.Name = "T_ProjectName";
            this.T_ProjectName.Size = new System.Drawing.Size(100, 20);
            this.T_ProjectName.TabIndex = 0;
            this.T_ProjectName.TextChanged += new System.EventHandler(this.T_ProjectName_TextChanged);
            // 
            // B_Valide
            // 
            this.B_Valide.Location = new System.Drawing.Point(117, 27);
            this.B_Valide.Name = "B_Valide";
            this.B_Valide.Size = new System.Drawing.Size(75, 25);
            this.B_Valide.TabIndex = 1;
            this.B_Valide.Text = "创建或读取";
            this.B_Valide.UseVisualStyleBackColor = true;
            this.B_Valide.Click += new System.EventHandler(this.B_Valide_Click);
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.B_GridModiCancel);
            this.MainGroupBox.Controls.Add(this.B_GridModiValide);
            this.MainGroupBox.Controls.Add(this.dataGridView1);
            this.MainGroupBox.Controls.Add(this.T_StaLoc);
            this.MainGroupBox.Controls.Add(this.label4);
            this.MainGroupBox.Controls.Add(this.label3);
            this.MainGroupBox.Controls.Add(this.B_AddSt);
            this.MainGroupBox.Controls.Add(this.T_AddSt);
            this.MainGroupBox.Location = new System.Drawing.Point(11, 58);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(210, 314);
            this.MainGroupBox.TabIndex = 2;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "设置车站名称与里程";
            this.MainGroupBox.Visible = false;
            // 
            // B_GridModiCancel
            // 
            this.B_GridModiCancel.Location = new System.Drawing.Point(126, 266);
            this.B_GridModiCancel.Name = "B_GridModiCancel";
            this.B_GridModiCancel.Size = new System.Drawing.Size(75, 23);
            this.B_GridModiCancel.TabIndex = 6;
            this.B_GridModiCancel.Text = "button3";
            this.B_GridModiCancel.UseVisualStyleBackColor = true;
            // 
            // B_GridModiValide
            // 
            this.B_GridModiValide.Location = new System.Drawing.Point(6, 266);
            this.B_GridModiValide.Name = "B_GridModiValide";
            this.B_GridModiValide.Size = new System.Drawing.Size(75, 23);
            this.B_GridModiValide.TabIndex = 5;
            this.B_GridModiValide.Text = "保存";
            this.B_GridModiValide.UseVisualStyleBackColor = true;
            this.B_GridModiValide.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(195, 162);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // T_StaLoc
            // 
            this.T_StaLoc.Location = new System.Drawing.Point(65, 43);
            this.T_StaLoc.Name = "T_StaLoc";
            this.T_StaLoc.Size = new System.Drawing.Size(116, 20);
            this.T_StaLoc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "里程:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "名称:";
            // 
            // B_AddSt
            // 
            this.B_AddSt.Location = new System.Drawing.Point(65, 69);
            this.B_AddSt.Name = "B_AddSt";
            this.B_AddSt.Size = new System.Drawing.Size(116, 23);
            this.B_AddSt.TabIndex = 2;
            this.B_AddSt.Text = "添加站点";
            this.B_AddSt.UseVisualStyleBackColor = true;
            this.B_AddSt.Click += new System.EventHandler(this.B_AddSt_Click);
            // 
            // T_AddSt
            // 
            this.T_AddSt.Location = new System.Drawing.Point(65, 19);
            this.T_AddSt.Name = "T_AddSt";
            this.T_AddSt.Size = new System.Drawing.Size(116, 20);
            this.T_AddSt.TabIndex = 0;
            // 
            // L_AddSt
            // 
            this.L_AddSt.FormattingEnabled = true;
            this.L_AddSt.Location = new System.Drawing.Point(435, 74);
            this.L_AddSt.Name = "L_AddSt";
            this.L_AddSt.Size = new System.Drawing.Size(189, 290);
            this.L_AddSt.TabIndex = 3;
            this.L_AddSt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_AddSt_MouseDown);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(227, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 314);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备名称和里程";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 295);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.B_ChoixEqu);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Combo_Block);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.T_NumBlock);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox_To);
            this.panel2.Controls.Add(this.comboBox_From);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.B_AddEq);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 295);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(44, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 10;
            // 
            // B_ChoixEqu
            // 
            this.B_ChoixEqu.Location = new System.Drawing.Point(171, 3);
            this.B_ChoixEqu.Name = "B_ChoixEqu";
            this.B_ChoixEqu.Size = new System.Drawing.Size(19, 23);
            this.B_ChoixEqu.TabIndex = 9;
            this.B_ChoixEqu.Text = "+";
            this.B_ChoixEqu.UseVisualStyleBackColor = true;
            this.B_ChoixEqu.Click += new System.EventHandler(this.B_ChoixEqu_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.B_Draw);
            this.panel3.Location = new System.Drawing.Point(3, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 40);
            this.panel3.TabIndex = 1;
            // 
            // B_Draw
            // 
            this.B_Draw.Location = new System.Drawing.Point(39, 10);
            this.B_Draw.Name = "B_Draw";
            this.B_Draw.Size = new System.Drawing.Size(121, 23);
            this.B_Draw.TabIndex = 0;
            this.B_Draw.Text = "绘制";
            this.B_Draw.UseVisualStyleBackColor = true;
            this.B_Draw.Click += new System.EventHandler(this.B_Draw_Click);
            // 
            // Combo_Block
            // 
            this.Combo_Block.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Block.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Combo_Block.FormattingEnabled = true;
            this.Combo_Block.Location = new System.Drawing.Point(44, 214);
            this.Combo_Block.Name = "Combo_Block";
            this.Combo_Block.Size = new System.Drawing.Size(121, 21);
            this.Combo_Block.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "数量:";
            // 
            // T_NumBlock
            // 
            this.T_NumBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.T_NumBlock.Enabled = false;
            this.T_NumBlock.ForeColor = System.Drawing.SystemColors.WindowText;
            this.T_NumBlock.Location = new System.Drawing.Point(44, 159);
            this.T_NumBlock.Name = "T_NumBlock";
            this.T_NumBlock.Size = new System.Drawing.Size(121, 20);
            this.T_NumBlock.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "设备:";
            // 
            // comboBox_To
            // 
            this.comboBox_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_To.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_To.FormattingEnabled = true;
            this.comboBox_To.Location = new System.Drawing.Point(44, 131);
            this.comboBox_To.Name = "comboBox_To";
            this.comboBox_To.Size = new System.Drawing.Size(121, 21);
            this.comboBox_To.TabIndex = 4;
            this.comboBox_To.Visible = false;
            this.comboBox_To.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox_From
            // 
            this.comboBox_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_From.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_From.FormattingEnabled = true;
            this.comboBox_From.Location = new System.Drawing.Point(44, 106);
            this.comboBox_From.Name = "comboBox_From";
            this.comboBox_From.Size = new System.Drawing.Size(121, 21);
            this.comboBox_From.TabIndex = 3;
            this.comboBox_From.Visible = false;
            this.comboBox_From.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "到:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "从:";
            // 
            // B_AddEq
            // 
            this.B_AddEq.Location = new System.Drawing.Point(44, 185);
            this.B_AddEq.Name = "B_AddEq";
            this.B_AddEq.Size = new System.Drawing.Size(121, 23);
            this.B_AddEq.TabIndex = 0;
            this.B_AddEq.Text = "添加";
            this.B_AddEq.UseVisualStyleBackColor = true;
            this.B_AddEq.Click += new System.EventHandler(this.B_AddEq_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(637, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // B_Admin
            // 
            this.B_Admin.Location = new System.Drawing.Point(567, 28);
            this.B_Admin.Name = "B_Admin";
            this.B_Admin.Size = new System.Drawing.Size(57, 40);
            this.B_Admin.TabIndex = 5;
            this.B_Admin.Text = "设置块";
            this.B_Admin.UseVisualStyleBackColor = true;
            this.B_Admin.Click += new System.EventHandler(this.B_Admin_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置储存位置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 设置储存位置ToolStripMenuItem
            // 
            this.设置储存位置ToolStripMenuItem.Name = "设置储存位置ToolStripMenuItem";
            this.设置储存位置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置储存位置ToolStripMenuItem.Text = "设置储存位置";
            this.设置储存位置ToolStripMenuItem.Click += new System.EventHandler(this.设置储存位置ToolStripMenuItem_Click);
            // 
            // Com_CadLayer
            // 
            this.Com_CadLayer.FormattingEnabled = true;
            this.Com_CadLayer.Location = new System.Drawing.Point(277, 31);
            this.Com_CadLayer.Name = "Com_CadLayer";
            this.Com_CadLayer.Size = new System.Drawing.Size(121, 21);
            this.Com_CadLayer.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "绘制于图层：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(637, 404);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Com_CadLayer);
            this.Controls.Add(this.B_Admin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainGroupBox);
            this.Controls.Add(this.L_AddSt);
            this.Controls.Add(this.B_Valide);
            this.Controls.Add(this.T_ProjectName);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_ProjectName;
        private System.Windows.Forms.Button B_Valide;
        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Button B_AddSt;
        private System.Windows.Forms.TextBox T_AddSt;
        private System.Windows.Forms.ListBox L_AddSt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_To;
        private System.Windows.Forms.ComboBox comboBox_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_AddEq;
        private System.Windows.Forms.TextBox T_StaLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button B_GridModiCancel;
        private System.Windows.Forms.Button B_GridModiValide;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Combo_Block;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox T_NumBlock;
        private System.Windows.Forms.Button B_Admin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置储存位置ToolStripMenuItem;
        private System.Windows.Forms.Button B_Draw;
        private System.Windows.Forms.ComboBox Com_CadLayer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button B_ChoixEqu;
        private System.Windows.Forms.TextBox textBox1;
    }
}

