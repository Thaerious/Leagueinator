using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Leagueinator {
    public class Match {
        public readonly List<Team> teams;
        
        
        public int Lane {
            get;
            set;
        } = 0;

        public Match (List<Team> teams, int lane) {
            this.teams = new List<Team> ();
            foreach (Team team in teams) {
                Team newTeam = new Team(team.Players);
                this.teams.Add (newTeam);
            }

            this.Lane = lane;
        }

           

        public Dictionary<string, string> ToDictionary(Dictionary<string, string> map = null, string prefix = "M1") {
            if (map == null) map = new Dictionary<string, string> ();

            map.Add(prefix + "T1P1", this.teams[0].Player1);
            map.Add(prefix + "T1P2", this.teams[0].Player2);
            map.Add(prefix + "T2P1", this.teams[1].Player1);
            map.Add(prefix + "T2P2", this.teams[1].Player2);

            return map;
        }

        public int LaneWeight() {
            int weight = 0;

            foreach (var team in this.teams) {
                foreach(var pinfo  in team.Players) {                 
                    if (pinfo.PreviousLanes.Contains(Lane)) weight++;
                }
            }

            return weight;
        }
    }

    
}
