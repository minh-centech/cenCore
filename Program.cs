using cenCommonUIbase.Forms;
using Infragistics.Win.AppStyling;
using System;
using System.Windows.Forms;
namespace cenBusinessManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StyleManager.Load(Application.StartupPath + "\\Office2007Blue.isl");
            Application.Run(new frmMain());
        }
    }
}
