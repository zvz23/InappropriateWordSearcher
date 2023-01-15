using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InappropriateWordSearcher.Services;

namespace InappropriateWordSearcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(AppConstants.ABS_TEMP_FOLDER))
            {
                Directory.CreateDirectory(AppConstants.ABS_TEMP_FOLDER);
            }
            if (!Directory.Exists(AppConstants.ABS_APP_DATA_FOLDER))
            {
                Directory.CreateDirectory(AppConstants.ABS_APP_DATA_FOLDER);
            }
            AppDBContext.Initialize_Database();

            Application.Run(new Main());
        }
    }
}
