using Leagueinator.Model;
using Leagueinator.Search_Algorithms.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeagueinator {
    [TestClass]
    public class Test_LaneSolution {
        public static LeagueEvent NewEvent() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.AddRound();
            lEvent.AddRound();
            lEvent.AddRound();

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

            lEvent.AddRound();
            lEvent.AddRound();
            
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
            Assert.AreEqual(4, solution.Evaluate());
        }

        /// <summary>
        /// All players in the same lane for three rounds.
        /// Will equal the number of players x 2.
        /// </summary>
        [TestMethod]
        public void Simple_Repeat_Lanes_Twice() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.AddRound();
            lEvent.AddRound();
            lEvent.AddRound();

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
            Assert.AreEqual(16, solution.Evaluate());
        }

        /// <summary>
        /// Third round only 1 match is a repeat
        /// 
        /// </summary>
        [TestMethod]
        public void Repeat_Some_Lanes() {
            var lEvent = new LeagueEvent(new Settings());

            lEvent.AddRound();
            lEvent.AddRound();
            lEvent.AddRound();

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

            lEvent[2][2][0][0] = new PlayerInfo("Ernie");
            lEvent[2][2][0][1] = new PlayerInfo("Fred");
            lEvent[2][2][1][0] = new PlayerInfo("Gary");
            lEvent[2][2][1][1] = new PlayerInfo("Harry");

            var solution = new LaneSolution(lEvent, lEvent.Rounds[2]);
            Assert.AreEqual(8, solution.Evaluate());
        }
    }
}
