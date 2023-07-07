﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Search_Algorithms.Solutions {
    public class LaneSolution : ASolution {
        private static Random random = new Random();
        private readonly LeagueEvent LeagueEvent;
        private readonly Round Ignore;
        private static readonly Random rng = new Random();
        public readonly Round Round;

        public LaneSolution(LeagueEvent leagueEvent, Round round) : base(leagueEvent.Settings.LaneCount) {
            this.LeagueEvent = leagueEvent;
            this.Round = round;

            Debug.WriteLine(leagueEvent.Settings.LaneCount);
            for (int lane = 0; lane < leagueEvent.Settings.LaneCount; lane++) {
                this[lane] = lane;
            }
        }

        public override int Evaluate() {
            int laneCount = this.LeagueEvent.Settings.LaneCount;
            int sum = 0;

            foreach (Allele a in this) {
                Debug.WriteLine(a);
                Match match = this.Round[a.Value];
                match.Players.ForEach(p => sum += Count(p, a.Index));
            }

            return sum;
        }

        public Round Value() {
            var newRound = new Round(this.Round.Settings);

            foreach (Allele a in this) {
                newRound[a.Index] = this.Round[a.Value].DeepCopy();
            }

            return newRound;
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
                if (round == this.Round) continue;
                Match match = round[lane];
                if (match.Players.Contains(player)) sum++;
            }

            return sum;
        }

        /// <summary>
        /// A valid solution has a unique value for each index.
        /// The values should be between 0 .. n-1 inclusive.
        /// Each value is represented exactly once.
        /// </summary>
        /// <returns></returns>
        public override bool IsValid() {
            // teams -> number of times value is represented
            Dictionary<int, int> Counts = new Dictionary<int, int>();

            for (int i = 0; i< this.Size; i++) {
                Counts[this[i]]++;                
            }

            for (int i = 0; i < this.Size; i++) {
                if (!Counts.ContainsKey(i) || Counts[i] != 1) return false;
            }

            return true;
        }

        public override ASolution Clone() {
            return new LaneSolution(this.LeagueEvent, this.Round);
        }

        public override void Mutate() {
            int r1 = 0, r2 = 0;

            while (r1 == r2) {
                r1 = random.Next(this.Size);
                r2 = random.Next(this.Size);
            }

            (this[r1], this[r2]) = (this[r2], this[r1]);
        }
    }
}
