using System;
using System.Diagnostics;
using System.Windows.Forms;
using Leagueinator.Forms;

namespace Leagueinator {
    internal static class Program {
        [STAThread]
        static void Main() {
            Debug.WriteLine("Starting Program");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
