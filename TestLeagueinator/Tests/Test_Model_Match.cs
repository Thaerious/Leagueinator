using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator
{
    [TestClass]
    public class Test_Model_Match {

        [TestMethod]
        public void EmptyMatch() {
            var m1 = new Match(new Settings());
            Assert.AreEqual(0, m1.Players.Count);
            Assert.AreEqual(2, m1.Teams.Count); // by default two empty teams are added
            Assert.AreEqual(2, m1.MaxSize);
        }        

        [TestMethod]
        public void OutOfBounds_0() {
            var m1 = new Match(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                m1[2][0] = new PlayerInfo("Adam");
            });
        }

        [TestMethod]
        public void OutOfBounds_1() {
            var m1 = new Match(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                m1[-1][0] = new PlayerInfo("Adam");
            });
        }

        [TestMethod]
        public void ClearPlayers() {
            var m1 = new Match(new Settings());

            m1[0][0] = new PlayerInfo("Adam");
            m1[0][1] = new PlayerInfo("Eve");
            m1[1][0] = new PlayerInfo("Cain");
            m1[1][1] = new PlayerInfo("Able");

            m1.ClearPlayers();

            Assert.AreEqual(0, m1.Players.Count);
            Assert.AreEqual(2, m1.Teams.Count);
            Assert.AreEqual(2, m1.MaxSize);
        }

        [TestMethod]
        public void Players() {
            var m1 = new Match(new Settings());

            m1[0][0] = new PlayerInfo("Adam");
            m1[0][1] = new PlayerInfo("Eve");
            m1[1][0] = new PlayerInfo("Cain");
            m1[1][1] = new PlayerInfo("Able");

            var list = m1.Players;

            Assert.IsTrue(list.Contains(new PlayerInfo("Adam")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Eve")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Cain")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Able")));
        }
    }
}
