using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;
using Leagueinator.Model.Algorithms;
using Leagueinator.Algorithms;

namespace Leagueinator {
    internal static class Program {
        static string Filename = "D:/Scratch/my.league";

        [STAThread]
        static void Main() {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(Filename, FileMode.Open)) {
                League league = (League)formatter.Deserialize(stream);
                LeagueEvent lEvent = league.Events[0];
                Round target = lEvent.Rounds[lEvent.Rounds.Count - 1];
                                
                var algo = new FindPartnersMember(lEvent, target);
                var best = new RandomWalk().Run(algo);

                Debug.WriteLine($"Best {best.Evaluate()}");

            }
        }
    }
}
