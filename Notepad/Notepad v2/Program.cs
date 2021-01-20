using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Form1 form1 = new Form1();

            if (args.Length > 0)
            {
                form1.openFile_FromExplorer(args);
                Application.Run(form1);
            } 
            else
            {
                Application.Run(form1);
            }
        }
    }
}
