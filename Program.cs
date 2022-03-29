using MapView.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapView
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLoading frm = new frmLoading();
            frm.LoadingData();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}
