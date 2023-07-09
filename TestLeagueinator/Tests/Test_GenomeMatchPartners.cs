using System;
using System.Diagnostics;
using Leagueinator.Model;
using Leagueinator.Search_Algorithms.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeagueinator {
    [TestClass]
    public class Test_GenomeMatchPartners {
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
        public void Evaluate_By_Player() {
            var lEvent = NewEvent();
            var g = new PartnerSolution(lEvent, lEvent[0]);

            Assert.AreEqual(
                2, 
                g.Evaluate(new PlayerInfo("Adam"), new PlayerInfo("Bently"))
            );
        }

        /// <summary>
        /// The event is empty, all rounds evaluate to 0
        /// </summary>
        [TestMethod]
        public void Evaluate_0() {
            var lEvent = new LeagueEvent(new Settings());
            
            Round r = new Round(lEvent.Settings);
            r[0][0][0] = new PlayerInfo("Adam");
            r[0][0][1] = new PlayerInfo("Cain");
            r[0][1][0] = new PlayerInfo("Bently");
            r[0][1][1] = new PlayerInfo("Dave");

            var g = new PartnerSolution(lEvent, r);

            Assert.AreEqual(0, g.Evaluate());
        }

        /// <summary>
        /// The round is part of the event, so it counts
        /// in the evaluation. It will evaluate to the
        /// number of teams.
        /// </summary>
        [TestMethod]
        public void Evaluate_1() {
            var lEvent = new LeagueEvent(new Settings());

            Round r = lEvent.NewRound();
            r[0][0][0] = new PlayerInfo("Adam");
            r[0][0][1] = new PlayerInfo("Bently");
            r[0][1][0] = new PlayerInfo("Cain");
            r[0][1][1] = new PlayerInfo("Dave");

            var g = new PartnerSolution(lEvent, r);

            Assert.AreEqual(2, g.Evaluate());
        }

        [TestMethod]
        public void Evaluate_2() {
            var lEvent = new LeagueEvent(new Settings());
            lEvent.NewRound();

            // First Round
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            var g = new PartnerSolution(lEvent, lEvent[0]);

            Assert.AreEqual(2, g.Evaluate());
        }

        [TestMethod]
        public void Evaluate_3() {
            var lEvent = new LeagueEvent(new Settings());
            lEvent.NewRound();
            lEvent.NewRound();

            //     r  m  t  p   
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            lEvent[1][0][0][0] = new PlayerInfo("Adam");
            lEvent[1][0][0][1] = new PlayerInfo("Bently");
            lEvent[1][0][1][0] = new PlayerInfo("Cain");
            lEvent[1][0][1][1] = new PlayerInfo("Dave");

            var g = new PartnerSolution(lEvent, lEvent[0]);

            Assert.AreEqual(4, g.Evaluate());
        }

        [TestMethod]
        public void Randomize() {
            var lEvent = new LeagueEvent(new Settings());
            lEvent.NewRound();

            //     r  m  t  p  
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            var g = new PartnerSolution(lEvent, lEvent[0]);
            Round r = g.Randomize();
            Assert.AreEqual(4, r.AllPlayers.Count);
            Debug.WriteLine(r);
        }

        [TestMethod]
        public void RandomizeEmpty() {
            var lEvent = new LeagueEvent(new Settings());
            lEvent.NewRound();

            //     r  m  t  p  
            lEvent[0][0][0][0] = new PlayerInfo("Adam");
            lEvent[0][0][0][1] = new PlayerInfo("Bently");
            lEvent[0][0][1][0] = new PlayerInfo("Cain");
            lEvent[0][0][1][1] = new PlayerInfo("Dave");

            lEvent[0].ResetPlayers();

            var g = new PartnerSolution(lEvent, lEvent[0]);
            Round r = g.Randomize();
            Assert.AreEqual(4, r.AllPlayers.Count);
        }
    }
}
