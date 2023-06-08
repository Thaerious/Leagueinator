using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.utility_classes;

namespace Leagueinator {

    public class Round : List<Match>, HasPlayerInfo {
        private static Random rng = new Random();
        private readonly PlayerInfoMap playerInfoMap;
        private TeamCollection teams;
        private PlayerInfoMap buys;
        private PlayerInfoMap playing;

        public PlayerInfoMap Buys => this.buys.DeepCopy();

        public int LaneWeight {
            get {
                int weight = 0;
                foreach (Match match in this) {
                    weight += match.LaneWeight();
                }
                return weight;
            }
        }

        public Round(PlayerInfoMap playerInfoMap) {
            this.playerInfoMap = playerInfoMap.DeepCopy();
            this.Randomize();
        }

        public PlayerInfoMap GetPlayerInfo() {
            return this.playerInfoMap.DeepCopy();
        }

        /// <summary>
        /// Randomly assign the current list of players to teams.
        /// </summary>
        void Randomize() {
            this.Clear();
            this.AssignBuys();
            this.BuildTeams();
            this.AssignTeams();
        }

        void BuildTeams() {
            TeamCollection best = new TeamCollection(this.playing);

            for (int i = 0; i < 10; i++) {
                TeamCollection next = new TeamCollection(this.playing);
                if (next.PlayerWeightSum() < best.PlayerWeightSum()) best = next;
            }

            this.teams = best;
        }

        void AssignTeams() {
            int matchCount = playerInfoMap.Count / 4;
            int laneCount = matchCount < 4 ? 4 : matchCount;
            List<int> laneList = Enumerable.Range(1, laneCount).ToList();

            while (teams.Count > 0) {
                Team team1 = rng.RemoveFrom(teams);
                Team team2 = rng.RemoveFrom(teams);
                int lane = rng.RemoveFrom<int>(laneList);
                
                var match = new Match(new List<Team> { team1, team2 }, lane);

                this.playerInfoMap[team1.Player1].PreviousLanes.Add(lane);
                this.playerInfoMap[team1.Player2].PreviousLanes.Add(lane);
                this.playerInfoMap[team2.Player1].PreviousLanes.Add(lane);
                this.playerInfoMap[team2.Player2].PreviousLanes.Add(lane);

                this.Add(match);
            }
        }

        /// <summary>
        /// Create teams of 2 players.
        /// Will create an even number of teams.
        /// Remaining players will be in the buy list.
        /// </summary>
        /// <param name="buyBlackList">List of names to exclude from having a buy</param>
        void AssignBuys() {
            this.buys = new PlayerInfoMap();
            this.playing = this.playerInfoMap.ShallowCopy();

            int matchCount = playerInfoMap.Count / 4;
            int teamCount = matchCount * 2;
            int playerCount = teamCount * 2;
            int buyCount = playerInfoMap.Count - playerCount;

            if (teamCount < 2) throw new Exception("Minimum 4 players required to build matches.");

            while (this.buys.Count < buyCount) {
                var pinfo = this.playing.LowestRandomBuy();
                pinfo.CountBuys++;
                this.buys.Add(pinfo);
            }
        }
    }   
}
