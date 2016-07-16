using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhotoSlideCS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           // string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            { 
                // usage
                // >application_name.exe "file_name"
                
                if (System.IO.File.Exists(args[0]))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form1 frm1 = new Form1();
                    frm1.OpenFile(args[0]);
                    Application.Run(frm1);
                }
                else
                {
                    MessageBox.Show("Invalid argument\n" + args[0]);
                    OpenMainForm();
                }
            }
            else if (args.Length > 1) {
                OpenMainForm();
            }
            else
            { 
                OpenMainForm();
            }
        }

        static void OpenMainForm() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
  
    }
 
}
