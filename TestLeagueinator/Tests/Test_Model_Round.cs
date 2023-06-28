using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator
{

    [TestClass]
    public class Test_Model_Round {

        [TestMethod]
        public void EmptyRound() {
            var r1 = new Round(new Settings());
            Assert.AreEqual(0, r1.AllPlayers.Count);
            Assert.AreEqual(8, r1.Matches.Count); // by default a match is inserted for each lane
            Assert.AreEqual(8, r1.MaxSize);
        }

        [TestMethod]
        public void OutOfBounds_0() {
            var r1 = new Round(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                r1[8].Teams[0].Players[0] = null;
            });
        }

        [TestMethod]
        public void OutOfBounds_1() {
            var r1 = new Round(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                r1[-1].Teams[0].Players[0] = null;
            });
        }

        [TestMethod]
        public void ResetPlayers() {
            var r1 = new Round(new Settings());

            r1.Matches[0][0][0] = new PlayerInfo("Adam");
            r1.Matches[0][0][1] = new PlayerInfo("Eve");
            r1.Matches[0][1][0] = new PlayerInfo("Cain");
            r1.Matches[0][1][1] = new PlayerInfo("Able");

            r1.ResetPlayers();

            Assert.AreEqual(0, r1.ActivePlayers.Count);
            Assert.AreEqual(4, r1.IdlePlayers.Count);
            Assert.AreEqual(4, r1.AllPlayers.Count);
            Assert.AreEqual(0, r1.Teams.Count);
            Assert.AreEqual(8, r1.MaxSize);
        }

        [TestMethod]
        public void Players() {
            var r1 = new Round(new Settings());

            r1.Matches[0][0][0] = new PlayerInfo("Adam");
            r1.Matches[0][0][1] = new PlayerInfo("Eve");
            r1.Matches[0][1][0] = new PlayerInfo("Cain");
            r1.Matches[0][1][1] = new PlayerInfo("Able");

            var list = r1.AllPlayers;

            Assert.IsTrue(list.Contains(new PlayerInfo("Adam")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Eve")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Cain")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Able")));
        }

        [TestMethod]
        public void Teams() {
            var r1 = new Round(new Settings());

            r1.Matches[0][0][0] = new PlayerInfo("Adam");
            r1.Matches[0][0][1] = new PlayerInfo("Eve");
            r1.Matches[0][1][0] = new PlayerInfo("Cain");
            r1.Matches[0][1][1] = new PlayerInfo("Able");
            r1.Matches[1][0][0] = new PlayerInfo("Bain");

            Assert.AreEqual(5, r1.ActivePlayers.Count);
            Assert.AreEqual(0, r1.IdlePlayers.Count);
            Assert.AreEqual(5, r1.AllPlayers.Count);
            Assert.AreEqual(3, r1.Teams.Count);          // return teams with >0 players
            Assert.AreEqual(8, r1.MaxSize);
        }

        [TestMethod]
        public void GetTeam() {
            var r1 = new Round(new Settings());

            r1.Matches[0][0][0] = new PlayerInfo("Adam");
            r1.Matches[0][0][1] = new PlayerInfo("Eve");
            r1.Matches[0][1][0] = new PlayerInfo("Cain");
            r1.Matches[0][1][1] = new PlayerInfo("Able");
            r1.Matches[1][0][0] = new PlayerInfo("Bain");

            Assert.AreEqual(5, r1.ActivePlayers.Count);
            Assert.AreEqual(0, r1.IdlePlayers.Count);
            Assert.AreEqual(5, r1.AllPlayers.Count);
            Assert.AreEqual(3, r1.Teams.Count);          // return teams with >0 players
            Assert.AreEqual(8, r1.MaxSize);

            Team t1 = r1.GetTeam(new PlayerInfo("Adam"));
            Debug.WriteLine(r1[0]);
            Debug.WriteLine(t1);
            Assert.AreEqual(r1[0][0], t1);
        }

        [TestMethod]
        public void Get_Team_For_Player() {
            var r1 = new Round(new Settings());
            r1[0][0][0] = new PlayerInfo("Adam");
            r1[0][0][1] = new PlayerInfo("Bailey");
            r1[0][1][0] = new PlayerInfo("Cain");
            r1[0][1][1] = new PlayerInfo("Dave");

            var t = r1.GetTeam(new PlayerInfo("Adam"));

            Assert.AreEqual(r1[0][0], t);
        }
    }
}
