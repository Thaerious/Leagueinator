using Leagueinator.Algorithms;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Leagueinator.Utility_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestLeagueinator {
    [TestClass]
    public class Test_Penache {
        [TestMethod]
        public void Simple_Case() {
            Round r1 = new Round(new Setting() {
                TeamSize = 2,
                LaneCount = 3,
                MatchSize = 2,
            });

            // m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][0][1] = new PlayerInfo("B");
            r1[0][1][0] = new PlayerInfo("C");
            r1[0][1][1] = new PlayerInfo("D");
            r1[1][0][0] = new PlayerInfo("E");
            r1[1][0][1] = new PlayerInfo("F");
            r1[1][1][0] = new PlayerInfo("G");
            r1[1][1][1] = new PlayerInfo("H");
            r1[2][0][0] = new PlayerInfo("I");
            r1[2][0][1] = new PlayerInfo("J");
            r1[2][1][0] = new PlayerInfo("K");
            r1[2][1][1] = new PlayerInfo("L");

            var rr1 = new Penache(r1);
            var r2 = rr1.GenerateRound(1);

            Debug.WriteLine(r2);

            //Assert.AreEqual("A", r2[0][0][0].Name);
            //Assert.AreEqual("C", r2[0][1][0].Name);
            //Assert.AreEqual("E", r2[1][0][0].Name);
            //Assert.AreEqual("B", r2[1][1][0].Name);
            //Assert.AreEqual("F", r2[2][0][0].Name);
            //Assert.AreEqual("D", r2[2][1][0].Name);
        }
    }
}
