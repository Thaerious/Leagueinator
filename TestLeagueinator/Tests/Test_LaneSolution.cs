using Leagueinator.Model;
using Leagueinator.Algorithms;
using Leagueinator.Algorithms.Solutions;
using Leagueinator.Utility_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestLeagueinator {
    [TestClass]
    public class Test_LaneSolution {
        public static LeagueEvent NewEvent() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.NewRound();
            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");
            lEvent[0][1][0][0] = new PlayerInfo("Ernie");
            lEvent[0][1][0][1] = new PlayerInfo("Fred");
            lEvent[0][1][1][0] = new PlayerInfo("Gary");
            lEvent[0][1][1][1] = new PlayerInfo("Harry");

            // Second Round
            lEvent[1][0][0][0] = new PlayerInfo("Adam");
            lEvent[1][0][0][1] = new PlayerInfo("Bently");
            lEvent[1][0][1][0] = new PlayerInfo("Cain");
            lEvent[1][0][1][1] = new PlayerInfo("Dave");
            lEvent[1][1][0][0] = new PlayerInfo("Ernie");
            lEvent[1][1][0][1] = new PlayerInfo("Fred");
            lEvent[1][1][1][0] = new PlayerInfo("Gary");
            lEvent[1][1][1][1] = new PlayerInfo("Harry");

            // Third Round
            lEvent[2][0][0][0] = new PlayerInfo("Adam");
            lEvent[2][0][0][1] = new PlayerInfo("Bently");
            lEvent[2][0][1][0] = new PlayerInfo("Cain");
            lEvent[2][0][1][1] = new PlayerInfo("Dave");
            lEvent[2][1][0][0] = new PlayerInfo("Ernie");
            lEvent[2][1][0][1] = new PlayerInfo("Fred");
            lEvent[2][1][1][0] = new PlayerInfo("Gary");
            lEvent[2][1][1][1] = new PlayerInfo("Harry");

            return lEvent;
        }

        [TestMethod]
        public void Constuctor_Sanity_Test() {
            var lEvent = Test_LaneSolution.NewEvent();
            new LaneSolution(lEvent, lEvent.Rounds[2]);
        }

        /// <summary>
        /// All players in the same lane for two rounds.
        /// Will equal the number of players.
        /// </summary>
        [TestMethod]
        public void Simple_Repeat_Lanes() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            //     r  m  t  p
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            // Second Round
            lEvent[1][0][0][0] = new PlayerInfo("Adam");
            lEvent[1][0][0][1] = new PlayerInfo("Bently");
            lEvent[1][0][1][0] = new PlayerInfo("Cain");
            lEvent[1][0][1][1] = new PlayerInfo("Dave");

            var solution = new LaneSolution(lEvent, lEvent.Rounds[1]);
            Assert.AreEqual(8, solution.Evaluate());
        }

        /// <summary>
        /// All players in the same lane for three rounds.
        /// Will equal the number of players x 3.
        /// </summary>
        [TestMethod]
        public void Simple_Repeat_Lanes_Twice() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.NewRound();
            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            lEvent[0][1][0][0] = new PlayerInfo("Ernie");
            lEvent[0][1][0][1] = new PlayerInfo("Fred");
            lEvent[0][1][1][0] = new PlayerInfo("Gary");
            lEvent[0][1][1][1] = new PlayerInfo("Harry");

            // Second Round
            lEvent[1][0][0][0] = new PlayerInfo("Adam");
            lEvent[1][0][0][1] = new PlayerInfo("Bently");
            lEvent[1][0][1][0] = new PlayerInfo("Cain");
            lEvent[1][0][1][1] = new PlayerInfo("Dave");

            lEvent[1][1][0][0] = new PlayerInfo("Ernie");
            lEvent[1][1][0][1] = new PlayerInfo("Fred");
            lEvent[1][1][1][0] = new PlayerInfo("Gary");
            lEvent[1][1][1][1] = new PlayerInfo("Harry");

            // Third Round
            lEvent[2][0][0][0] = new PlayerInfo("Adam");
            lEvent[2][0][0][1] = new PlayerInfo("Bently");
            lEvent[2][0][1][0] = new PlayerInfo("Cain");
            lEvent[2][0][1][1] = new PlayerInfo("Dave");

            lEvent[2][1][0][0] = new PlayerInfo("Ernie");
            lEvent[2][1][0][1] = new PlayerInfo("Fred");
            lEvent[2][1][1][0] = new PlayerInfo("Gary");
            lEvent[2][1][1][1] = new PlayerInfo("Harry");

            var solution = new LaneSolution(lEvent, lEvent.Rounds[2]);
            Assert.AreEqual(24, solution.Evaluate());
        }

        [TestMethod]
        public void Evaluate_One_Round() {
            var lEvent = new LeagueEvent(new Settings {
                TeamSize = 1,
                LaneCount = 2,
                MatchSize = 2,
            });

            lEvent.NewRound();            

            // First Round
            //     r  m  t  p
            lEvent[0][0][0][0] = new PlayerInfo("A");
            lEvent[0][0][1][0] = new PlayerInfo("B");

            var sol = new LaneSolution(lEvent, lEvent.Rounds[0]);
            Debug.WriteLine(sol.DelString());
            Assert.AreEqual(2, sol.Evaluate());
            (sol[0], sol[1]) = (sol[1], sol[0]);
            Debug.WriteLine(sol.DelString());
            Assert.AreEqual(0, sol.Evaluate());
        }

        /// <summary>
        /// Create a new Round object from a solution.
        /// </summary>
        [TestMethod]
        public void Build_Value() {
            var lEvent = new LeagueEvent(new Settings {
                TeamSize = 1,
                LaneCount = 2,
                MatchSize = 2,
            });

            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            //     r  m  t  p
            lEvent[0][0][0][0] = new PlayerInfo("A");
            lEvent[0][0][1][0] = new PlayerInfo("B");

            var sol = new LaneSolution(lEvent, lEvent.Rounds[0]);
            (sol[0], sol[1]) = (sol[1], sol[0]);
            Debug.WriteLine($"{sol.DelString()} = {sol.Evaluate()}");
            Assert.AreEqual("A", sol.Value()[1][0][0].Name);
            Debug.WriteLine(sol.Value());
        }

        /// <summary>
        /// Create a new Round object from a solution.
        /// </summary>
        [TestMethod]
        public void Clone() {
            var lEvent = new LeagueEvent(new Settings {
                TeamSize = 1,
                LaneCount = 2,
                MatchSize = 2,
            });

            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            //     r  m  t  p
            lEvent[0][0][0][0] = new PlayerInfo("A");
            lEvent[0][0][1][0] = new PlayerInfo("B");

            var sol = new LaneSolution(lEvent, lEvent.Rounds[0]);
            sol[0] = 1;
            sol[1] = 0;
            var clone = sol.Clone();
            Assert.AreEqual(1, clone[0]);
            Assert.AreEqual(0, clone[1]);
        }

        [TestMethod]
        public void TestGreedyAlgo() {
            var lEvent = new LeagueEvent(new Settings {
                TeamSize = 1,
                LaneCount = 2,
                MatchSize = 2,
            });

            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            //     r  m  t  p
            lEvent[0][0][0][0] = new PlayerInfo("A");
            lEvent[0][0][1][0] = new PlayerInfo("B");
            lEvent[0][1][0][0] = new PlayerInfo("C");
            lEvent[0][1][1][0] = new PlayerInfo("D");

            var sol = new LaneSolution(lEvent, lEvent[0]);
            var algo = new GreedyWalk();

            var best = algo.Run(sol, s => {
                Debug.WriteLine($"{algo.Generation} : [{s.DelString()}] = {s.Evaluate()}");
            });

            
            Debug.WriteLine(best.Value());

            Assert.AreEqual("C", best.Value()[0][0][0].Name);
            Assert.AreEqual("A", best.Value()[1][0][0].Name);
        }
    }
}
