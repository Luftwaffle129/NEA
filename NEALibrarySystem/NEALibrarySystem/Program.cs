using NEALibrarySystem.Data_Structures;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileHandler.InitialiseFilePath();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
    }
}
