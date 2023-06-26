using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator
{
    [TestClass]
    public class Test_Model_Team {
        PlayerInfo adam = new PlayerInfo("Adam");
        PlayerInfo eve = new PlayerInfo("Eve");

        [TestMethod]
        public void Empty_Team() {
            var t1 = new Team(new Settings());
            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.IsFalse(t1.HasPlayer(adam));
        }

        [TestMethod]
        public void Constructor() {
            var t1 = new Team(new Settings()) {
                Players = new List<PlayerInfo>{ adam, eve }
            };

            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        [TestMethod]
        public void HasPlayer() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            Assert.AreEqual(1, t1.Players.Count);
            Assert.IsFalse(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(null, t1[1]);

            t1[1] = eve;
            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        /// <summary>
        /// Can not add the same player to multiple positions.
        /// </summary>
        [TestMethod]
        public void AddDuplicate() {
            var t1 = new Team(new Settings());
            Assert.ThrowsException<ArgumentException>(() => {
                t1[0] = adam;
                t1[0] = adam;
            });
        }

        [TestMethod]
        public void OutOfBounds_0() {
            var t1 = new Team(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                t1[2] = adam;
            });
        }

        [TestMethod]
        public void OutOfBounds_1() {
            var t1 = new Team(new Settings());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                t1[-1] = adam;
            });
        }

        [TestMethod]
        public void RemovePlayer() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;

            t1[0] = null;
            t1[1] = null;

            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(null, t1[0]);
            Assert.AreEqual(null, t1[1]);
        }

        [TestMethod]
        public void DeepCopy() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;

            var t2 = t1.DeepCopy();

            Assert.AreEqual(2, t2.Players.Count);
            Assert.IsTrue(t2.isFull);
            Assert.AreEqual(2, t2.MaxSize);
            Assert.AreEqual(adam, t2[0]);
            Assert.AreEqual(eve, t2[1]);
        }

        [TestMethod]
        public void DeepCopy_NonReflective() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;

            var t2 = t1.DeepCopy();

            t1[0] = null;
            t1[1] = null;

            Assert.AreEqual(2, t2.Players.Count);
            Assert.IsTrue(t2.isFull);
            Assert.AreEqual(2, t2.MaxSize);
            Assert.AreEqual(adam, t2[0]);
            Assert.AreEqual(eve, t2[1]);
        }

        [TestMethod]
        public void Clear() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;
            t1.Clear();

            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.isFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.IsFalse(t1.HasPlayer(adam));
        }

        [TestMethod]
        public void Players() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;

            var list = t1.Players;

            Assert.IsTrue(list.Contains(adam));
            Assert.IsTrue(list.Contains(eve));
        }

        [TestMethod]
        public void Players_NonReflective() {
            var t1 = new Team(new Settings());

            t1[0] = adam;
            t1[1] = eve;

            var list = t1.Players;

            t1[0] = null;
            t1[1] = null;

            Assert.IsTrue(list.Contains(adam));
            Assert.IsTrue(list.Contains(eve));
        }
    }
}
