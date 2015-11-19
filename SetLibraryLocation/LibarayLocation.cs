using System;
using System.Windows.Forms;
using AutoDrawDWG;
namespace SetLibraryLocation
{
    public partial class LibarayLocation : Form
    {
       
        public LibarayLocation()
        {
            InitializeComponent();
        }

        private void LibarayLocation_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";

            using (Form1 tF = new Form1())
            {
                label1.Text = "默认库位置为：" + tF.StringLocation;
            }
        }
        /// <summary>  
        /// 计算字符串长度(汉字占两格)  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static int CalStringLength(string str)
        {
            return System.Text.Encoding.Default.GetByteCount(str);
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.ShowNewFolderButton = false;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                //显示选择的文件位置
                this.textBox1.Text = path;
                //地址回传
                Form1 f = (Form1)this.Owner;
                f.StringLocation = path;
                //form.bi
                //form.StringLocation
                //form1.Show();//.LocationString 
                //提示变更成功
                //TODO 设置验证
                if (DirectoryIsMatch())
                {
                    toolStripStatusLabel1.Text = "库位置变更成功。";
                    
                }
                //调用方法延时自动关闭窗口
                CloseForm();
            }
            else
            {
                MessageBox.Show("未能设置库位置。");
            }
           

            
        }
        string titlelName = "设置库文件位置";

        private bool DirectoryIsMatch()
        {
            bool isMatch = true;
            return isMatch;
        }

        private void CloseForm()
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            
        }

        int poseTime = 0;
        int remainTime = 10;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (poseTime < 10)
            {
                poseTime += 1;
            }
            else
            {
                if (remainTime > 0)
                {
                    remainTime -= 1;
                    this.Text = titlelName + "  窗口将于：" + remainTime + "秒后关闭";                    
                }
                else
                {
                    toolStripStatusLabel1.Text = "";
                    timer1.Enabled = false;
                    this.Close();
                }
            }
        }

        private void LibarayLocation_MouseMove(object sender, MouseEventArgs e)
        {
            poseTime = 0;
        }

        private void LibarayLocation_MouseClick(object sender, MouseEventArgs e)
        {
            poseTime = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = Properties.Resources.TextFile1;
            if( textBox2.Text==""||textBox2.Text==null){
                textBox2.Text = s;
            }
            else if (textBox2.Text != s) { 
                //Properties.Resources.TextFi
            }
            
        }
    }
}
