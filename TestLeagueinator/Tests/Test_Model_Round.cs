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
        public void RemoveMatch_0() {
            var r1 = new Round(new Settings());
            r1[0] = null; 

            Assert.AreEqual(0, r1.AllPlayers.Count);
            Assert.AreEqual(7, r1.Matches.Count); // by default a match is inserted for each lane
            Assert.AreEqual(8, r1.MaxSize);
        }

        [TestMethod]
        public void OutOfBounds_0() {
            var r1 = new Round(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                r1[8] = new Match(r1.Settings);
            });
        }

        [TestMethod]
        public void OutOfBounds_1() {
            var r1 = new Round(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                r1[-1] = new Match(r1.Settings);
            });
        }

        [TestMethod]
        public void DeepCopy() {
            var r1 = new Round(new Settings());

            r1[0] = new Match(r1.Settings);
            r1[1] = new Match(r1.Settings);

            var r2 = r1.DeepCopy();

            Assert.AreEqual(8, r2.Matches.Count);
            Assert.AreEqual(8, r2.MaxSize);
        }

        [TestMethod]
        public void DeepCopy_NonReflective() {
            var r1 = new Round(new Settings());

            r1[0] = new Match(r1.Settings);
            r1[1] = new Match(r1.Settings);

            var r2 = r1.DeepCopy();

            r1[0] = null;
            r1[1] = null;

            Assert.AreEqual(6, r1.Matches.Count);
            Assert.AreEqual(8, r2.Matches.Count);
            Assert.AreEqual(8, r2.MaxSize);
        }

        [TestMethod]
        public void ResetPlayers() {
            var r1 = new Round(new Settings());

            r1[0][0] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Adam"),
                    new PlayerInfo("Eve"),
                }
            };
            r1[0][1] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Cain"),
                    new PlayerInfo("Able"),
                }
            };

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

            r1[0][0] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Adam"),
                    new PlayerInfo("Eve"),
                }
            };
            r1[0][1] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Cain"),
                    new PlayerInfo("Able"),
                }
            };

            var list = r1.AllPlayers;

            Assert.IsTrue(list.Contains(new PlayerInfo("Adam")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Eve")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Cain")));
            Assert.IsTrue(list.Contains(new PlayerInfo("Able")));
        }

        [TestMethod]
        public void Teams() {
            var r1 = new Round(new Settings());

            r1[0][0] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Adam"),
                    new PlayerInfo("Eve"),
                }
            };
            r1[0][1] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Cain"),
                    new PlayerInfo("Able"),
                }
            };

            r1[1][1] = new Team(r1.Settings) {
                Players = new List<PlayerInfo>() {
                    new PlayerInfo("Bain"),
                }
            };

            Assert.AreEqual(5, r1.ActivePlayers.Count);
            Assert.AreEqual(0, r1.IdlePlayers.Count);
            Assert.AreEqual(5, r1.AllPlayers.Count);
            Assert.AreEqual(3, r1.Teams.Count);          // return teams with >0 players
            Assert.AreEqual(8, r1.MaxSize);
        }
    }
}
