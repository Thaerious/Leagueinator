using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Utility;

namespace Leagueinator {

    public class TeamCollection : List<Team>, HasPlayerInfo {
        private PlayerInfoMap playerInfoMap;

        public TeamCollection(PlayerInfoMap playerInfoMap) : base() {
            this.playerInfoMap = playerInfoMap.ShallowCopy();
            this.Randomize();
        }

        public PlayerInfoMap GetPlayerInfo() {
            return this.playerInfoMap.DeepCopy();
        }

        public int PlayerWeightSum() {
            int sum = 0;
            foreach(Team team in this) {
                sum += team.PlayerWeight();
            }
            return sum;
        }

        /// <summary>
        /// Create teams of 2 players.
        /// Will create an even number of teams.
        /// Remaining players will be in the buy list.
        /// </summary>
        /// <param name="buyBlackList">List of names to exclude from having a buy</param>
        void Randomize() {            
            this.Clear();

            var playerInfoMap = this.playerInfoMap.ShallowCopy();

            int matchCount = playerInfoMap.Count / 4;
            int teamCount = matchCount * 2;
            int playerCount = teamCount * 2;      
            int buyCount = playerInfoMap.Count - playerCount;            

            if (teamCount < 2) throw new Exception("Minimum 4 players required to build matches.");

            while (playerInfoMap.Count > 0) {
                var p1 = playerInfoMap.RemoveRandom();
                var p2 = playerInfoMap.RemoveRandom();
                this.Add(p1, p2);
            }
        }

        public Team Add(PlayerInfo p1, PlayerInfo p2) {
            Team team = new Team(new List<PlayerInfo>() { p1, p2 });
            this.Add(team);
            this.playerInfoMap[p1.Name].PreviousPartners.Add(p2.Name);
            this.playerInfoMap[p2.Name].PreviousPartners.Add(p1.Name);
            return team;
        }
    }
}
