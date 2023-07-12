using System;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeagueinator
{
    [TestClass]
    public class Test_Model_PlayerInfo
    {
        [TestMethod]
        public void Equals_True()
        {
            var p1 = new PlayerInfo("Adam");
            var p2 = new PlayerInfo("Adam");
            Assert.IsTrue(p1.Equals(p2));
            //Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void Equals_False() {
            var p1 = new PlayerInfo("Adam");
            var p2 = new PlayerInfo("Eve");
            Assert.IsFalse(p1.Equals(p2));
            //Assert.IsTrue(p1 != p2);
        }

        [TestMethod]
        public void Equals_Null() {
            var p1 = new PlayerInfo("Adam");
            var p2 = new PlayerInfo("Eve");
            Assert.IsFalse(p1.Equals(null));
        }

        [TestMethod]
        public void Equals_Diff_Objects() {
            var p1 = new PlayerInfo("Adam");
            var m1 = new Match(new Setting());
            Assert.IsFalse(p1.Equals(m1));
        }
    }
}
