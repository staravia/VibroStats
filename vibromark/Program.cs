using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vibromark
{
    static class Program
    {
        public static bool onlineData;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            createService();
            Application.Run(new MainForm());
        }
        public static void createService()
        {

            //server stuff
        }
    }
}
