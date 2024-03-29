﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeagueinator.Helpers;

namespace TestLeagueinator {
    [TestClass]
    public class Test_IsModel_Team {
        PlayerInfo adam = new PlayerInfo("Adam");
        PlayerInfo eve = new PlayerInfo("Eve");
        PlayerInfo cain = new PlayerInfo("Cain");

        [TestMethod]
        public void Empty_Team() {
            var t1 = new Team(new Setting());
            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.IsFalse(t1.HasPlayer(adam));
        }

        [TestMethod]
        public void Constructor() {
            var t1 = new Team(new Setting());
            t1[0] = adam;
            t1[1] = eve;

            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        [TestMethod]
        public void SetPlayer() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            Assert.AreEqual(1, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(null, t1[1]);

            t1[1] = eve;
            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        [TestMethod]
        public void Remove_Player_By_Index() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            t1[1] = eve;
            t1.RemovePlayer(eve);

            Assert.AreEqual(1, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(null, t1[1]);
        }

        [TestMethod]
        public void Remove_Unknown_Player_By_Value_Returns_False() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            t1[1] = eve;

            Assert.IsFalse(t1.RemovePlayer(cain));
        }

        [TestMethod]
        public void AddPlayer_In_Order() {
            var t1 = new Team(new Setting());
            t1.AddPlayer(adam);
            t1.AddPlayer(eve);

            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        [TestMethod]
        public void AddPlayer_Fill_Null() {
            var t1 = new Team(new Setting());

            t1[1] = eve;
            t1.AddPlayer(adam);

            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);
        }

        [TestMethod]
        public void Add_Player_No_Vacanacy() {
            var t1 = new Team(new Setting());
            t1.AddPlayer(adam);
            t1.AddPlayer(eve);
            Assert.IsFalse(t1.AddPlayer(cain));
        }

        [TestMethod]
        public void HasPlayer() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            Assert.AreEqual(1, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(null, t1[1]);

            t1[1] = eve;
            Assert.AreEqual(2, t1.Players.Count);
            Assert.IsTrue(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(adam, t1[0]);
            Assert.AreEqual(eve, t1[1]);

            Assert.IsTrue(t1.HasPlayer(adam));
            Assert.IsTrue(t1.HasPlayer(new PlayerInfo("Adam")));
        }

        [TestMethod]
        public void OutOfBounds_0() {
            var t1 = new Team(new Setting());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                t1[2] = adam;
            });
        }

        [TestMethod]
        public void OutOfBounds_1() {
            var t1 = new Team(new Setting());
            Assert.ThrowsException<IndexOutOfRangeException>(() => {
                t1[-1] = adam;
            });
        }

        [TestMethod]
        public void Remove_Player_By_Value() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            t1[1] = eve;

            t1[0] = null;
            t1[1] = null;

            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.AreEqual(null, t1[0]);
            Assert.AreEqual(null, t1[1]);
        }

        [TestMethod]
        public void Clear() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            t1[1] = eve;
            t1.Clear();

            Assert.AreEqual(0, t1.Players.Count);
            Assert.IsFalse(t1.IsFull);
            Assert.AreEqual(2, t1.MaxSize);
            Assert.IsFalse(t1.HasPlayer(adam));
        }

        [TestMethod]
        public void Players() {
            var t1 = new Team(new Setting());

            t1[0] = adam;
            t1[1] = eve;

            var list = t1.Players;

            Assert.IsTrue(list.Contains(adam));
            Assert.IsTrue(list.Contains(eve));
        }

        [TestMethod]
        public void Players_NonReflective() {
            var t1 = new Team(new Setting());

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
