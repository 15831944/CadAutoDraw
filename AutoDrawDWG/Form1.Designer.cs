namespace AutoDrawDWG
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
            this.T_ProjectName = new System.Windows.Forms.TextBox();
            this.B_Valide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // T_ProjectName
            // 
            this.T_ProjectName.Location = new System.Drawing.Point(12, 12);
            this.T_ProjectName.Name = "T_ProjectName";
            this.T_ProjectName.Size = new System.Drawing.Size(100, 21);
            this.T_ProjectName.TabIndex = 0;
            this.T_ProjectName.TextChanged += new System.EventHandler(this.T_ProjectName_TextChanged);
            // 
            // B_Valide
            // 
            this.B_Valide.Location = new System.Drawing.Point(118, 12);
            this.B_Valide.Name = "B_Valide";
            this.B_Valide.Size = new System.Drawing.Size(75, 23);
            this.B_Valide.TabIndex = 1;
            this.B_Valide.Text = "创建或读取";
            this.B_Valide.UseVisualStyleBackColor = true;
            this.B_Valide.Click += new System.EventHandler(this.B_Valide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.B_Valide);
            this.Controls.Add(this.T_ProjectName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T_ProjectName;
        private System.Windows.Forms.Button B_Valide;
    }
}

