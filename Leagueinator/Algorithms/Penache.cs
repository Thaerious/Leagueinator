using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leagueinator.Algorithms {
    public class Penache {
        private readonly Round Reference;

        public Penache(Round round) {
            this.Reference = round;
        }

        public Round Value(int count) {
            PlayerInfo[] before = this.Reference.AllPlayers.ToArray();
            if (before.Length == 0) return new Round(this.Reference.Settings);

            PlayerInfo[] players = before.ToOpposite();
            Shift(players, count);
            PlayerInfo[] after = players.ToAdjacent();

            return AssignTeams(after);
        }

        private PlayerInfo[] Shift(PlayerInfo[] players, int count) {
            while (count-- > 0) {
                PlayerInfo temp = players[1];
                for (int i = 1; i < players.Length - 1; i++) {
                    players[i] = players[i + 1];
                }
                players[players.Length - 1] = temp;
            }
            return players;
        }

        private Round AssignTeams(PlayerInfo[] players) {
            Round round = new Round(this.Reference.Settings);

            int numTeams = (int)Math.Ceiling((double)(players.Length / 2));
            List<Team> teams = new List<Team>();
            
            for (int i = 0; i < numTeams; i++) {
                Team team = new Team(this.Reference.Settings); 
                team[0] = players[i * 2];
                team[1] = players[i * 2 + 1];
                teams.Add(team);
            }

            int lane = 0;
            for (int i = 0; i < numTeams; i += 2) {
                round[lane][0] = teams.RemoveRandom();
                round[lane][1] = teams.RemoveRandom();
                lane++;
            }

            return round;
        }
    }
}
