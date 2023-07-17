using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Model {
    [Serializable]
    public enum Result {
        WIN, LOSS, TIE
    }

    [Serializable]
    public class Score : IComparable<Score>{
        public static readonly double factor = 1.5;

        public int wins = 0;
        public int ties = 0;
        public int losses = 0;
        public int raw;
        public int count;
        public int plus;

        public static bool operator == (Score left, Score right) {
            if (left  == null || right == null) return false;
            if (left.wins != right.wins) return false;
            if (left.losses != right.losses) return false;
            if (left.ties != right.ties) return false;
            if (left.count != right.count) return false;
            if (left.plus != right.plus) return false;
            return true;
        }

        public static bool operator !=(Score left, Score right) {
            if (left == null || right == null) return true;
            if (left.wins != right.wins) return true;
            if (left.losses != right.losses) return true;
            if (left.ties != right.ties) return true;
            if (left.count != right.count) return true;
            if (left.plus != right.plus) return true;
            return false;
        }

        public static Score operator +(Score left, Score right) {
            var score = new Score();
            score.wins = left.wins + right.wins;
            score.losses = left.losses + right.losses;
            score.ties = left.ties + right.ties;
            score.raw = left.raw + right.raw;
            score.count = left.count + right.count;
            score.plus = left.plus + right.plus;
            return score;
        }

        public Score() {}

        public Score(Result result, int raw, int rounds) {
            switch (result) {
                case Result.WIN: this.wins++; break;
                case Result.LOSS: this.losses++; break;
                case Result.TIE: this.ties++; break;
            }

            this.raw = raw;
            int max = (int)(rounds * 1.5);
            this.count = raw < max ? raw : max;
            this.plus = raw - this.count;
        }

        public override bool Equals(object obj) {
            return obj is Score score &&
                   this.wins == score.wins &&
                   this.ties == score.ties &&
                   this.losses == score.losses &&
                   this.raw == score.raw &&
                   this.count == score.count &&
                   this.plus == score.plus;
        }

        public override int GetHashCode() {
            int hashCode = 1066740792;
            hashCode = hashCode * -1521134295 + this.wins.GetHashCode();
            hashCode = hashCode * -1521134295 + this.ties.GetHashCode();
            hashCode = hashCode * -1521134295 + this.losses.GetHashCode();
            hashCode = hashCode * -1521134295 + this.raw.GetHashCode();
            hashCode = hashCode * -1521134295 + this.count.GetHashCode();
            hashCode = hashCode * -1521134295 + this.plus.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Score other) {
            if (this.wins > other.wins) return -1;
            if (this.wins < other.wins) return 1;
            if (this.count > other.count) return -1;
            if (this.count < other.count) return 1;
            if (this.plus > other.plus) return -1;
            if (this.plus < other.plus) return 1;
            return 0;
        }
    }
}
