using Leagueinator.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Controller {
    public class Score : IComparable {
        private double[] score;

        public double this[int i] {
            get { return score[i]; }
            set { score[i] = value; }
        }
                
        public Score(int size) {
            this.score = new double[size];
        }

        int IComparable.CompareTo(Object _other) {
            if (_other is Score == false) throw new InvalidCastException();
            Score other = (Score) _other;

            if (this == other) return 0;
            if (this.score.Length != other.score.Length) throw new ArrayTypeMismatchException();

            for (int i = 0; i < this.score.Length; i++) {
                if (this[i] > other[i]) return 1;
                if (this[i] < other[i]) return -1;
            }

            return 0;
        }

        public override bool Equals(object _other) {
            if (_other is Score == false) return false;
            Score other = (Score)_other;

            for (int i = 0; i < this.score.Length; i++) {
                if (this[i] != other[i]) return false;
            }
            return true;
        }

        public override int GetHashCode() {
            return 2132320477 + EqualityComparer<double[]>.Default.GetHashCode(this.score);
        }

        public static bool operator < (Score left, Score right) {
            if (left.score.Length != right.score.Length) throw new ArrayTypeMismatchException();

            for (int i = 0; i < left.score.Length; i++) {
                if (left[i] > right[i]) return false;
                if (left[i] < right[i]) return true;
            }

            return false;
        }

        public static bool operator > (Score left, Score right) {
            if (left.score.Length != right.score.Length) throw new ArrayTypeMismatchException();

            for (int i = 0; i < left.score.Length; i++) {
                if (left[i] > right[i]) return true;
                if (left[i] < right[i]) return false;
            }

            return false;
        }

        public static bool operator <=(Score left, Score right) {
            if (left.score.Length != right.score.Length) throw new ArrayTypeMismatchException();
            
            for (int i = 0; i < left.score.Length; i++) {
                if (left[i] > right[i]) return false;
                if (left[i] < right[i]) return true;
            }
            return true;
        }

        public static bool operator >=(Score left, Score right) {
            if (left.score.Length != right.score.Length) throw new ArrayTypeMismatchException();

            for (int i = 0; i < left.score.Length; i++) {
                if (left[i] > right[i]) return true;
                if (left[i] < right[i]) return false;
            }

            return true;
        }

        public static bool operator ==(Score left, Score right) {
            return left.Equals(right);
        }

        public static bool operator !=(Score left, Score right) {
            return !left.Equals(right);
        }

        public override string ToString() {
            return this.score.DelString();
        }
    }
}
