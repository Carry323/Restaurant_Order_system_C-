using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceRestoComposants
{
    static class Program
    {
        static private Form1 mainForm;
        static private Form2 updateForm;
        static public Form1 MainForm { get => mainForm; }
        static public Form2 UpdateForm { get => updateForm; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form1();
            updateForm = new Form2();
            Application.Run(mainForm);
        }
    }
}
