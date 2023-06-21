using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;
using Leagueinator.utility_classes;
using Leagueinator.Utility_Classes;

namespace Leagueinator
{
    internal static class Program {
        [STAThread]
        static void Main() {
            Debug.WriteLine("Starting Program");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        //[STAThread]
        //static void Main() {
        //    Debug.WriteLine("Starting Dev Program");
        //    Settings settings = new Settings();
        //    Round round = new Round(settings);

        //    round.Matches[0].Teams[0].Players[0] = new PlayerInfo("Adam");
        //    round.Matches[0].Teams[0].Players[1] = new PlayerInfo("Eve");
        //    round.Matches[0].Teams[1].Players[0] = new PlayerInfo("Cain");
        //    round.Matches[0].Teams[1].Players[1] = new PlayerInfo("Able");

        //    round.Matches[3].Teams[0].Players[0] = new PlayerInfo("Monster");
        //    round.Matches[3].Teams[0].Players[1] = new PlayerInfo("Bill");
        //    round.Matches[3].Teams[1].Players[0] = new PlayerInfo("Greg");
        //    round.Matches[3].Teams[1].Players[1] = new PlayerInfo("Phil");

        //    Debug.WriteLine(round);

        //    ScoreCardPrinter.Print(round);
        //}
    }
}
