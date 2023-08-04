using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System.Diagnostics;
using System.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Leagueinator.Algorithms {

    /// <summary>
    /// Converts arrays where the pairings are next to each other, to 
    /// the round robin encoding where pairings are opposite each other.
    /// 
    /// Adjacent: 1, 1, 2, 2, 3, 3
    /// Opposite: 1, 2, 3, 3, 2, 1
    /// 
    /// </summary>
    public static class RRArrayExtensions {
        /// <summary>
        /// Create an opposite pairing array from an adjacent array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="before"></param>
        /// <returns></returns>
        public static T[] ToOpposite<T>(this T[] before) {
            T[] after = new T[before.Length];

            int i = 0;
            int j = after.Length - 1;
            int idx = 0;
            while (idx < before.Length) {
                if (i == j) {
                    after[i] = before[before.Length - 1];
                    break;
                }
                after[i++] = before[idx++];
                after[j--] = before[idx++];
            }
            return after;
        }


        /// <summary>
        /// Create an adjacent pairing array from an opposite array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="before"></param>
        /// <returns></returns>
        public static T[] ToAdjacent<T>(this T[] before) {
            T[] after = new T[before.Length];

            int i = 0;
            int j = after.Length - 1;
            int idx = 0;
            while (idx < before.Length) {
                if (i == j) {
                    after[after.Length - 1] = before[i];
                    break;
                }
                after[idx++] = before[i++];
                after[idx++] = before[j--];
            }
            return after;
        }
    }

    /// <summary>
    /// A class for assigning match pairings using the round robin algorithm.
    /// The Reference class is passed into the constuctor and is used to create
    /// new rounds.  The reference class is not manipulated.
    /// </summary>
    public class RoundRobin {
        private readonly Round Reference;

        public RoundRobin(Round round) {
            this.Reference = round;
        }

        /// <summary>
        /// Create a new Round instance based on the reference Round.
        /// </summary>
        /// <param name="count">The number of rounds after the reference instance</param>
        /// <returns></returns>
        public Round GenerateRound(int count) {
            if (count == 0) return this.Reference.DeepCopy();
            if (this.Reference.Teams.Count == 0) return new Round(this.Reference.Settings);

            var list = this.Reference.Teams;
            Team[] before = list.ToArray();
            Team[] teams = before.ToOpposite();

            Shift(teams, count);
            Team[] after = teams.ToAdjacent();
            return AssignTeams(after);
        }

        /// <summary>
        /// Shift all values except the first.
        /// Move the second value to the end and shift all other values down by 1.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private Team[] Shift(Team[] teams, int count) {
            while (count-- > 0) {
                Team temp = teams[1];
                for (int i = 1; i < teams.Length - 1; i++) {
                    teams[i] = teams[i + 1];
                }
                teams[teams.Length - 1] = temp;
            }
            return teams;
        }

        /// <summary>
        /// Assign teams to a new Round instance.
        /// </summary>
        /// <param name="teams">An adjacent pairings array.</param>
        /// <returns></returns>
        private Round AssignTeams(Team[] teams) {
            Round round = new Round(this.Reference.Settings);

            int i = 0;
            int lane = 0;
            while(i < teams.Length) {
                round[lane][0] = teams[i++];
                if (i == teams.Length) {
                    break;
                }
                round[lane][1] = teams[i++];
                lane++;
            }

            return round;
        }
    }
}
