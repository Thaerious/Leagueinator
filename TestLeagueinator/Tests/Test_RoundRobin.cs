using Leagueinator.Algorithms;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace TestLeagueinator {
    [TestClass]
    public class Test_RoundRobin {
        [TestMethod]
        public void Simple_Case() {
            Round r1 = new Round(new Settings {
                TeamSize = 1,
                LaneCount = 3,
                MatchSize = 2,
            });

            //    m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][1][0] = new PlayerInfo("F");
            r1[1][0][0] = new PlayerInfo("B");
            r1[1][1][0] = new PlayerInfo("E");
            r1[2][0][0] = new PlayerInfo("C");
            r1[2][1][0] = new PlayerInfo("D");

            var rr1 = new RoundRobin(r1);
            var r2 = rr1.Value(1);

            Debug.WriteLine(r2);

            Assert.AreEqual("A", r2[0][0][0].Name);
            Assert.AreEqual("B", r2[0][1][0].Name);
            Assert.AreEqual("C", r2[1][0][0].Name);
            Assert.AreEqual("F", r2[1][1][0].Name);
            Assert.AreEqual("D", r2[2][0][0].Name);
            Assert.AreEqual("E", r2[2][1][0].Name);

            var rr2 = new RoundRobin(r2);
            var r3 = rr2.Value(1);

            Debug.WriteLine(r3);

            Assert.AreEqual("A", r3[0][0][0].Name);
            Assert.AreEqual("C", r3[0][1][0].Name);
            Assert.AreEqual("D", r3[1][0][0].Name);
            Assert.AreEqual("B", r3[1][1][0].Name);
            Assert.AreEqual("E", r3[2][0][0].Name);
            Assert.AreEqual("F", r3[2][1][0].Name);
        }

        [TestMethod]
        public void Count_2() {
            Round r1 = new Round(new Settings {
                TeamSize = 1,
                LaneCount = 3,
                MatchSize = 2,
            });

            //    m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][1][0] = new PlayerInfo("F");
            r1[1][0][0] = new PlayerInfo("B");
            r1[1][1][0] = new PlayerInfo("E");
            r1[2][0][0] = new PlayerInfo("C");
            r1[2][1][0] = new PlayerInfo("D");

            var rr1 = new RoundRobin(r1);
            var r3 = rr1.Value(2);

            Debug.WriteLine(r3);

            Assert.AreEqual("A", r3[0][0][0].Name);
            Assert.AreEqual("C", r3[0][1][0].Name);
            Assert.AreEqual("D", r3[1][0][0].Name);
            Assert.AreEqual("B", r3[1][1][0].Name);
            Assert.AreEqual("E", r3[2][0][0].Name);
            Assert.AreEqual("F", r3[2][1][0].Name);
        }
    }
}
