using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(!Directory.Exists(Path.Combine(Path.GetTempPath(), "WordSearcher")))
            {
                Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "WordSearcher"));
            }
            Application.Run(new Form1());
        }
    }
}
