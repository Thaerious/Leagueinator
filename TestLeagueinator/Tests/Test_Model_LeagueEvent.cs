using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator
{

    [TestClass]
    public class Test_Model_LeagueEvent {

        [TestMethod]
        public void Constructor() {
            var e1 = new LeagueEvent(new Settings());

            var r1 = e1.AddRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            Assert.AreEqual(4, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void EmptyEvent() {
            var e1 = new LeagueEvent(new Settings());

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(0, e1.Size);
        }

        [TestMethod]
        public void AddRound() {
            var e1 = new LeagueEvent(new Settings());
            e1.AddRound();

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void GetTeams_0() {
            var e1 = new LeagueEvent(new Settings());
            e1.AddRound();

            Assert.AreEqual(0, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void GetTeams_1() {
            var e1 = new LeagueEvent(new Settings());

            var r1 = e1.AddRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            Assert.AreEqual(4, e1.SeekDeep<PlayerInfo>().Count);
            Assert.AreEqual(1, e1.Size);
        }

        [TestMethod]
        public void Get_Teams_For_Player() {
            var e1 = new LeagueEvent(new Settings());            

            var r1 = e1.AddRound();
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            var r2 = e1.AddRound();
            r2[1][0][0] = new PlayerInfo("Adam");
            r2[1][0][1] = new PlayerInfo("Bailey");
            r2[1][1][0] = new PlayerInfo("Cain");
            r2[1][1][1] = new PlayerInfo("Dave");

            List<Team> teams = e1.GetTeams(new PlayerInfo("Adam"));

            Assert.AreEqual(teams.Count, 2);
            Assert.AreEqual(r1[0][0], teams[0]);
            Assert.AreEqual(r2[1][0], teams[1]);
        }
    }
}
