using System;
using System.Windows.Forms;

using AlarmClockApp;
namespace AlarmClockApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();             // Enable visual styles for controls
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // Launch Form1 as the main window
        }
    }
}
