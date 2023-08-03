using Leagueinator.Controller;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Leagueinator.Utility_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace TestLeagueinator.Tests {
    [TestClass]
    public class Test_ScoreKeeper {

        public (ScoreKeeper, LeagueEvent) Build() {
            var setting = new Setting() {
                TeamSize = 1,
                LaneCount = 4,
                MatchSize = 2,
            };

            var le = new LeagueEvent(setting);
            var r1 = le.NewRound();

            // m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][1][0] = new PlayerInfo("B");
            r1[1][0][0] = new PlayerInfo("C");
            r1[1][1][0] = new PlayerInfo("D");

            return (new ScoreKeeper(le), le);
        }

        public (ScoreKeeper, LeagueEvent) BuildTwoRounds() {
            var setting = new Setting() {
                TeamSize = 1,
                LaneCount = 4,
                MatchSize = 2,
            };

            var le = new LeagueEvent(setting);
            var r1 = le.NewRound();

            // m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][1][0] = new PlayerInfo("B");
            r1[1][0][0] = new PlayerInfo("C");
            r1[1][1][0] = new PlayerInfo("D");

            var r2 = le.NewRound();
            r2[0][0][0] = new PlayerInfo("A");
            r2[0][1][0] = new PlayerInfo("D");
            r2[1][0][0] = new PlayerInfo("C");
            r2[1][1][0] = new PlayerInfo("B");

            return (new ScoreKeeper(le), le);
        }

        [TestMethod]
        public void Contructor() {
            var setting = new Setting() {
                TeamSize = 1,
                LaneCount = 4,
                MatchSize = 2,
            };

            var le = new LeagueEvent(setting);
            var r1 = le.NewRound();

            // m  t  p
            r1[0][0][0] = new PlayerInfo("A");
            r1[0][1][0] = new PlayerInfo("B");

            var sc = new ScoreKeeper(le);

            Assert.IsNotNull(sc);
        }

        [TestMethod]
        public void One_Round_No_Scores() {
            var (sk, le) = Build();

            var score = sk[new PlayerInfo("A")];
            Assert.IsTrue(score == sk.Zero);
        }

        [TestMethod]
        public void One_Round_Has_Winner() {
            var (sk, le) = Build();
            // r  m  t
            le[0][0][0].Score = 5; // A
            le[0][0][1].Score = 7; // B
            le[0][1][0].Score = 3; // C
            le[0][1][1].Score = 6; // D

            var list = le.SeekDeep<Team>();
            list.Unique();
            list.Sort(new TeamComparer(sk));
            list.Reverse();

            // Team 'B' is the winner
            Assert.AreEqual(le[0][0][1], list[0]);
        }

        [TestMethod]
        public void Two_Rounds_Has_Winner() {
            var (sk, le) = BuildTwoRounds();

            // r  m  t
            le[0][0][0].Score = 5; // A
            le[0][0][1].Score = 7; // B
            le[0][1][0].Score = 3; // C
            le[0][1][1].Score = 6; // D

            le[1][0][0].Score = 1; // A
            le[1][0][1].Score = 9; // D
            le[1][1][0].Score = 7; // C
            le[1][1][1].Score = 5; // B

            var list = le[1].SeekDeep<Team>(); // examine only the last round
            list.Unique();
            list = list.Where(t => t.Players.Count > 0).ToList<Team>();
            list.ForEach(t => Debug.WriteLine(t.Players.Count));
            list.Sort(new TeamComparer(sk));
            list.Reverse();

            foreach (PlayerInfo pi in le.SeekDeep<PlayerInfo>().Unique()) {
                Debug.WriteLine($"{pi.Name} {sk[pi]}");
            }

            Debug.WriteLine(list.DelString("\n"));

            // Team 'D' is the winner
            Assert.AreEqual(le[1][0][1], list[0]);

            // Team 'B' is second by first tie-breaker
            Assert.AreEqual(le[1][1][1], list[1]);
        }

        [TestMethod]
        public void Check_Values() {
            var (sk, le) = BuildTwoRounds();

            // r  m  t
            le[0][0][0].Score = 5; // A
            le[0][0][1].Score = 7; // B
            le[0][1][0].Score = 3; // C
            le[0][1][1].Score = 6; // D

            le[1][0][0].Score = 1; // A
            le[1][0][1].Score = 9; // D
            le[1][1][0].Score = 7; // C
            le[1][1][1].Score = 5; // B

            foreach (PlayerInfo pi in le.SeekDeep<PlayerInfo>().Unique()) {
                Debug.WriteLine($"{pi.Name} {sk[pi]}");
            }

            Assert.AreEqual(sk[new PlayerInfo("A")], new Leagueinator.Controller.Score(0.0, 6.0, 16.0));
            Assert.AreEqual(sk[new PlayerInfo("B")], new Leagueinator.Controller.Score(1.0, 12.0, 12.0));
            Assert.AreEqual(sk[new PlayerInfo("C")], new Leagueinator.Controller.Score(1.0, 10.0, 11.0));
            Assert.AreEqual(sk[new PlayerInfo("D")], new Leagueinator.Controller.Score(2.0, 15.0, 4.0));
        }
    }
}
