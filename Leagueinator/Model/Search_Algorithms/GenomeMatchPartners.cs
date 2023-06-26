using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Search_Algorithms;

namespace Leagueinator.Model.Search_Algorithms {

    public static class RoundExtension {
        public static PlayerInfo[] ToArray(this Round round) {
            var teams = round.Teams;
            PlayerInfo[] array = new PlayerInfo[teams.Count];

            int i = 0;
            foreach (var team in teams) {
                foreach(var player in team.Players) {
                    array[i++] = player;
                }
            }

            return array;
        }
    }

    public class GenomeMatchPartners : AMember<Round> {
        public readonly LeagueEvent lEvent;
        public readonly Round targetRound;
        private readonly Random rng = new Random();

        public GenomeMatchPartners(LeagueEvent lEvent, Round round) {
            this.lEvent = lEvent;
            this.targetRound = round.DeepCopy();
        }

        public override Round Value => this.targetRound;

        public override AMember<Round> Clone() {
            return new GenomeMatchPartners(lEvent, targetRound.DeepCopy());
        }

        public override int Evaluate() {
            int sum = 0;

            foreach (PlayerInfo player in targetRound.AllPlayers) {
                Team currentTeam = targetRound.GetTeam(player);
                if (currentTeam == null) continue;

                // a list of all teams that player is on
                List<Team> teams = this.lEvent.Teams.Where(t => t.HasPlayer(player)).ToList();

                // for each partner in the current team
                foreach (Team team in teams) {
                    foreach (PlayerInfo partner in  team.Players) {
                        if (player == partner) continue;
                        if (team.HasPlayer(partner)) sum++;
                    }
                }
            }

            return sum;
        }

        public override bool IsValid() => true;

        public override void Mutate() {
            Team t1 = this.targetRound.Teams.SelectRandom();
            Team t2 = this.targetRound.Teams.SelectRandom();

            int idx1 = rng.Next(t1.Players.Count);
            int idx2 = rng.Next(t2.Players.Count);

            (t1[idx1], t2[idx2]) = (t2[idx2], t1[idx1]);
        }
    }
}
