using System;
using System.Linq;
using System.Windows.Forms;

namespace UserInterface
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static int f = 5;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new MainScreen();
            main.Show();
            Application.Run();
        }        
    }
}
