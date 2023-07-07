using System;
using System.Diagnostics;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Search_Algorithms.Solutions {
    public class LaneSolution : ASolution {
        private readonly LeagueEvent LeagueEvent;
        private readonly Round Ignore;
        private static readonly Random rng = new Random();
        public readonly Round Round;

        public LaneSolution(LeagueEvent leagueEvent, Round round) {
            this.LeagueEvent = leagueEvent;
            this.Ignore = round;
            this.Round = round.Clone();
        }

        public override ASolution Clone() => new LaneSolution(this.LeagueEvent, this.Round);

        public override int Evaluate() {
            int laneCount = this.LeagueEvent.Settings.LaneCount;
            int sum = 0;

            for (int lane = 0; lane < laneCount; lane++) {
                Match match = this.Round[lane];
                match.Players.ForEach(p => sum += Count(p, lane));
            }

            return sum;
        }

        /// <summary>
        /// Count the number of times player has been in lane.
        /// Does not include the target round.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="lane"></param>
        /// <returns></returns>
        internal int Count(PlayerInfo player, int lane) {
            int sum = 0;
            
            foreach (Round round in this.LeagueEvent.Rounds) {
                if (round == this.Ignore) continue;
                Match match = round[lane];
                if (match.Players.Contains(player)) sum++;
            }

            return sum;
        }

        public override bool IsValid() => true;

        public override void Mutate() {
            int r1 = rng.Next(this.Round.Matches.Count);
            int r2 = rng.Next(this.Round.Matches.Count);
            (this.Round[r2], this.Round[r1]) = (this.Round[r1], this.Round[r2]);
        }
    }
}
