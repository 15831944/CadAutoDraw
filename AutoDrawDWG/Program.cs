using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoDrawDWG
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
#if debug
            //Application.Run(new Form1());
            ProjetStarter ps = new ProjetStarter();
            ps.starter();
#else

            Application.Run(new Form1());
#endif
        }
    }
}
