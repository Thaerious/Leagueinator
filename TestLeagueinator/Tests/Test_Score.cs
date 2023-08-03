using Leagueinator.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLeagueinator.Tests {
    [TestClass]
    public class Test_Score {

        [TestMethod]
        public void New_Score_Object() {
            var score = new Score(1);
            Assert.IsNotNull(score);
        }

        [TestMethod]
        public void Set_Get_Array_Operator() {
            var score = new Score(5);
            score[0] = 1.5;
            Assert.AreEqual(1.5, score[0]);
            Assert.AreEqual(0, score[1]); // initially 0
        }

        [TestMethod]
        public void Less_than_0() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 2.0;

            Assert.IsTrue(s1 < s2);
        }

        [TestMethod]
        public void LTE_0() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 2.0;

            Assert.IsTrue(s1 <= s2);
        }

        [TestMethod]
        public void LTE_1() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 1.5;

            Assert.IsTrue(s1 <= s2);
        }

        [TestMethod]
        public void GTE_0() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 2.5;
            s2[0] = 1.0;

            Assert.IsTrue(s1 >= s2);
        }

        [TestMethod]
        public void GTE_1() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 1.5;

            Assert.IsTrue(s1 >= s2);
        }

        [TestMethod]
        public void Less_than_1() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 1.5;
            s1[1] = -2.5;

            Assert.IsTrue(s1 < s2);
        }

        [TestMethod]
        public void Greater_than() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 2.0;

            Assert.IsTrue(s2 > s1);
        }

        [TestMethod]
        public void Equality() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 1.5;

            Assert.IsTrue(s2 == s1);
        }

        [TestMethod]
        public void InEquality() {
            var s1 = new Score(5);
            var s2 = new Score(5);
            s1[0] = 1.5;
            s2[0] = 2.5;

            Assert.IsTrue(s2 != s1);
        }

        [TestMethod]
        public void Sort_0() {
            Score[] scores = {
                new Score(5),
                new Score(5),
                new Score(5)
            };

            scores[0][1] = 2.5;
            scores[1][1] = 1.5;
            scores[2][1] = 3.5;

            Array.Sort(scores);

            Assert.AreEqual(1.5, scores[0][1]);
        }

        [TestMethod]
        public void Sort_1() {
            Score[] scores = {
                new Score(5),
                new Score(5),
                new Score(5)
            };

            scores[2][1] = 2.5;
            scores[1][1] = 1.5;
            scores[0][0] = 3.5;
            scores[0][1] = 0.5;

            Array.Sort(scores);

            Assert.AreEqual(3.5, scores[2][0]);
        }

        [TestMethod]
        public void Multiply() {
            Score score1 = new Score(2.0, 3.0, 5.0);
            Score score2 = score1 * 7;
            Assert.AreEqual(14.0, score2[0]);
            Assert.AreEqual(21.0, score2[1]);
            Assert.AreEqual(35.0, score2[2]);
        }

        [TestMethod]
        public void Divide() {
            Score score1 = new Score(2.0, 3.0, 5.0);
            Score score2 = score1 / 2;
            Assert.AreEqual(1.0, score2[0]);
            Assert.AreEqual(1.5, score2[1]);
            Assert.AreEqual(2.5, score2[2]);
        }

        [TestMethod]
        public void Add() {
            Score score1 = new Score(2.0, 3.0, 5.0);
            Score score2 = new Score(1.0, 2.0, 3.0);
            Score score3 = score1 + score2;
            Assert.AreEqual(3.0, score3[0]);
            Assert.AreEqual(5.0, score3[1]);
            Assert.AreEqual(8.0, score3[2]);
        }

        [TestMethod]
        public void Subtract() {
            Score score1 = new Score(2.0, 3.0, 5.0);
            Score score2 = new Score(1.0, 2.0, 3.0);
            Score score3 = score1 - score2;
            Assert.AreEqual(1.0, score3[0]);
            Assert.AreEqual(1.0, score3[1]);
            Assert.AreEqual(2.0, score3[2]);
        }
    }
}
