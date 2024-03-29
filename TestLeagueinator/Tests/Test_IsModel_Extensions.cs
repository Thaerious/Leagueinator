﻿using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leagueinator.Utility_Classes;
using Leagueinator.Model.Settings;

namespace TestLeagueinator
{

    class HasPlayerInfo1 {
        [Model]
        public PlayerInfo PI {
            get; set;
        }
    }

    class HasPlayerInfo2 {
        [Model] // is ignored
        public PlayerInfo this[int index] {
            get => null;
        }
    }

    class HasPlayerList {
        [Model]
        public List<PlayerInfo> Players {
            get; set;
        } = new List<PlayerInfo>();
    }

    class HasDeepPlayer {
        [Model]
        public HasPlayerInfo1 Child { get; set; } = new HasPlayerInfo1();
    }

    [TestClass]
    public class Test_IsModel_Extensions {

        [TestMethod]
        public void SeekAll() {
            var target = new HasPlayerInfo1();
            target.PI = new PlayerInfo("Charles");
            var list = target.SeekAll<PlayerInfo>();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Charles", list[0].Name);
        }

        [TestMethod]
        public void SeekAll_Empty() {
            var target = new HasPlayerInfo1();
            var list = target.SeekAll<PlayerInfo>();
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Indexed properties are not collected.
        /// </summary>
        [TestMethod]
        public void SeekAll_Index_Overload() {
            var target = new HasPlayerInfo2();
            var list = target.SeekAll<PlayerInfo>();
            Debug.WriteLine(list.Count);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void SeekAll_List() {
            var target = new HasPlayerList();
            target.Players.Add(new PlayerInfo("Adam"));

            Debug.WriteLine(target.Players.Count);

            var list = target.SeekAll<PlayerInfo>();
            Debug.WriteLine(list.Count);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void SeekDeep() {
            var target = new HasDeepPlayer();
            target.Child.PI = new PlayerInfo("Bane");

            var list = target.SeekDeep<PlayerInfo>();
            Debug.WriteLine(list.Count);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Bane", list[0].Name);
        }

        [TestMethod]
        public void PlayerInfo() {
            var target = new PlayerInfo("Able");
            var list = target.SeekDeep<PlayerInfo>();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(target, list[0]);
        }

        [TestMethod]
        public void Team() {
            var target = new Team(new Setting());

            target[0] = new PlayerInfo("Barney");
            target[1] = new PlayerInfo("Charlie");

            var list = target.SeekDeep<PlayerInfo>();
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(target[0], list[0]);
            Assert.AreEqual(target[1], list[1]);
        }

        [TestMethod]
        public void Match() {
            var target = new Match(new Setting());

            target[0][0] = new PlayerInfo("Barney");
            target[0][1] = new PlayerInfo("Charlie");

            var list = target.SeekDeep<PlayerInfo>();
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void Round_0() {
            var target = new Round(new Setting());

            target.Matches[0].Teams[0][0] = new PlayerInfo("Albert");
            target.Matches[0].Teams[0][1] = new PlayerInfo("Bert");
            target.Matches[0].Teams[1][0] = new PlayerInfo("Chuck");
            target.Matches[0].Teams[1][1] = new PlayerInfo("Desere");

            var list = target.SeekDeep<PlayerInfo>();
            Debug.WriteLine(list.DelString());
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void Round_1() {
            var target = new Round(new Setting());

            target.Matches[0].Teams[0][0] = new PlayerInfo("Albert");
            target.Matches[0].Teams[0][1] = new PlayerInfo("Bert");
            target.IdlePlayers.Add(new PlayerInfo("Chuck"));
            target.IdlePlayers.Add(new PlayerInfo("Desere"));

            var list = target.SeekDeep<PlayerInfo>();
            Debug.WriteLine(list.DelString());
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void Event() {
            var target = new LeagueEvent(new Setting());

            var r1 = target.NewRound();
            r1.Matches[0].Teams[0][0] = new PlayerInfo("Albert");
            r1.Matches[0].Teams[0][1] = new PlayerInfo("Bert");
            r1.Matches[0].Teams[1][0] = new PlayerInfo("Chuck");
            r1.Matches[0].Teams[1][1] = new PlayerInfo("Desere");

            var r2 = target.NewRound(); // adds idle players

            var list = target.SeekDeep<PlayerInfo>();
            Debug.WriteLine(list.DelString());
            Assert.AreEqual(8, list.Count);

        }

        [TestMethod]
        public void Root_Is_Array() {
            PlayerInfo[] target = new PlayerInfo[4];
            target[0] = new PlayerInfo("Albert");
            target[1] = new PlayerInfo("Bert");
            target[2] = new PlayerInfo("Chuck");
            target[3] = new PlayerInfo("Desere");
            Assert.AreEqual(4, target.SeekDeep<PlayerInfo>().Count);
        }
    }
}
