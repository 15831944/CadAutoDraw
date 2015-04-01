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
            this.B_ReadFile = new System.Windows.Forms.Button();
            this.T_FilePath = new System.Windows.Forms.TextBox();
            this.B_ReadBlock = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_ReadFile
            // 
            this.B_ReadFile.Location = new System.Drawing.Point(197, 12);
            this.B_ReadFile.Name = "B_ReadFile";
            this.B_ReadFile.Size = new System.Drawing.Size(75, 23);
            this.B_ReadFile.TabIndex = 0;
            this.B_ReadFile.Text = "读取文件";
            this.B_ReadFile.UseVisualStyleBackColor = true;
            this.B_ReadFile.Click += new System.EventHandler(this.B_ReadFile_Click);
            // 
            // T_FilePath
            // 
            this.T_FilePath.Location = new System.Drawing.Point(12, 12);
            this.T_FilePath.Name = "T_FilePath";
            this.T_FilePath.Size = new System.Drawing.Size(179, 21);
            this.T_FilePath.TabIndex = 2;
            // 
            // B_ReadBlock
            // 
            this.B_ReadBlock.Location = new System.Drawing.Point(197, 41);
            this.B_ReadBlock.Name = "B_ReadBlock";
            this.B_ReadBlock.Size = new System.Drawing.Size(75, 23);
            this.B_ReadBlock.TabIndex = 3;
            this.B_ReadBlock.Text = "读取块";
            this.B_ReadBlock.UseVisualStyleBackColor = true;
            this.B_ReadBlock.Click += new System.EventHandler(this.B_ReadBlock_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BlockEditeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.B_ReadBlock);
            this.Controls.Add(this.T_FilePath);
            this.Controls.Add(this.B_ReadFile);
            this.Name = "BlockEditeur";
            this.Text = "块编辑";
            this.Load += new System.EventHandler(this.BlockEditeur_Load);
            this.ResizeEnd += new System.EventHandler(this.BlockEditeur_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_ReadFile;
        private System.Windows.Forms.TextBox T_FilePath;
        private System.Windows.Forms.Button B_ReadBlock;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}