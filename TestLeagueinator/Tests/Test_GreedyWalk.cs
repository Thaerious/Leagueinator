using System;
using System.Diagnostics;
using Leagueinator.Model;
using Leagueinator.Algorithms.Solutions;
using Leagueinator.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leagueinator.Model.Settings;

namespace TestLeagueinator {
    [TestClass]
    public class Test_GreedyWalk {
        public static LeagueEvent NewEvent() {
            var lEvent = new LeagueEvent(new Setting());

            lEvent.NewRound();
            lEvent.NewRound();
            lEvent.NewRound();

            // First Round
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            // Second Round
            lEvent[1][0][0][0] = new PlayerInfo("Adam");
            lEvent[1][0][0][1] = new PlayerInfo("Bently");
            lEvent[1][0][1][0] = new PlayerInfo("Cain");
            lEvent[1][0][1][1] = new PlayerInfo("Dave");

            // Third Round
            lEvent[2][0][0][0] = new PlayerInfo("Adam");
            lEvent[2][0][0][1] = new PlayerInfo("Cain");
            lEvent[2][0][1][0] = new PlayerInfo("Bently");
            lEvent[2][0][1][1] = new PlayerInfo("Dave");

            return lEvent;
        }

        [TestMethod]
        public void Basic() {
            var lEvent = new LeagueEvent(new Setting());

            lEvent.NewRound();

            // First Round
            //     R  M  T  P
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            lEvent[0][1][0][0] = new PlayerInfo("Edwin");
            lEvent[0][1][0][1] = new PlayerInfo("Fred");
            lEvent[0][1][1][0] = new PlayerInfo("Harvey");
            lEvent[0][1][1][1] = new PlayerInfo("Ian");

            // ------------------------------------------

            var g = new PartnerSolution(lEvent, lEvent[0]);
            g.Randomize();
            new GreedyWalk().Run(g);

            Debug.WriteLine(g.Round[0]);
            Debug.WriteLine(g.Round[1]);
            Debug.WriteLine(g.Evaluate());
        }
    }
}
