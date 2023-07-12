using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Leagueinator.Utility_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator {

    [TestClass]
    public class Test_Model_LeagueEvent {

        [TestMethod]
        public void Constructor() {
            var e1 = new LeagueEvent(new Setting());

            var r1 = e1.NewRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            Assert.AreEqual(4, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void EmptyEvent() {
            var e1 = new LeagueEvent(new Setting());

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(0, e1.Size);
        }

        [TestMethod]
        public void Add_New_Round() {
            var e1 = new LeagueEvent(new Setting());
            e1.NewRound();

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void Add_Specified_Round() {
            var e1 = new LeagueEvent(new Setting());
            Round round = new Round(e1.Settings);
            e1.AddRound(round);

            Assert.AreEqual(round, e1[0]);
        }

        [TestMethod]
        public void GetTeams_0() {
            var e1 = new LeagueEvent(new Setting());
            e1.NewRound();

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void GetTeams_1() {
            var e1 = new LeagueEvent(new Setting());

            var r1 = e1.NewRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            Assert.AreEqual(4, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void Get_Teams_For_Player() {
            var e1 = new LeagueEvent(new Setting());

            var r1 = e1.NewRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            var r2 = e1.NewRound();
            r2[1][0][0] = new PlayerInfo("Adam");
            r2[1][0][1] = new PlayerInfo("Bailey");
            r2[1][1][0] = new PlayerInfo("Cain");
            r2[1][1][1] = new PlayerInfo("Dave");

            List<Team> teams =
                e1.SeekDeep<Team>()
                .Where(t => t.HasPlayer(new PlayerInfo("Adam")))
                .ToList();

            Assert.AreEqual(2, teams.Count);
            Assert.AreEqual(r1[0][0], teams[0]);
            Assert.AreEqual(r2[1][0], teams[1]);
        }

        [TestMethod]
        public void Replace_Round() {
            var e1 = new LeagueEvent(new Setting());
            var r1 = e1.NewRound();
            var r2 = new Round(e1.Settings);

            int i = e1.IndexOf(r1);
            e1.ReplaceRound(r1, r2);
            Assert.AreEqual(i, e1.IndexOf(r2));
            Assert.AreEqual(-1, e1.IndexOf(r1));
        }
    }
}


