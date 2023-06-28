using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leagueinator.Search_Algorithms;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model.Search_Algorithms {

    public class PartnerSolution : ASolution {
        public readonly LeagueEvent LEvent;
        public readonly Round Round;
        private readonly Random rng = new Random();

        public PartnerSolution(LeagueEvent lEvent, Round round) {
            LEvent = lEvent;
            Round = round.Clone();
        }

        public PartnerSolution(PartnerSolution that) {
            LEvent = that.LEvent;
            Round = that.Round;
        }

        public Round Value => Round;

        public override ASolution Clone()  => new PartnerSolution(this.LEvent, this.Round);

        /// <summary>
        /// Return the nubmer of times player1 was on a team with player2
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int Evaluate(PlayerInfo player1, PlayerInfo player2) {
            int sum = 0;

            List<Team> teams = LEvent
                .SeekDeep<Team>()
                .Where(t => t.HasPlayer(player1))
                .ToList();

            foreach (Team team in teams) {
                if (team.HasPlayer(player2)) sum++;
            }
            return sum;
        }

        /// <summary>
        /// The number of times a match was repeated.
        /// </summary>
        /// <returns></returns>
        public override int Evaluate() {
            int sum = 0;
            
            foreach (PlayerInfo player1 in Round.ActivePlayers) {
                var team = Round.GetTeam(player1);

                foreach (PlayerInfo player2 in team.Players) {
                    if (player1.Equals(player2)) continue;
                    sum += Evaluate(player1, player2);
                }
            }

            return sum / 2;
        }

        public override bool IsValid() => true;

        public Round Randomize() {            
            Round.ResetPlayers();            

            foreach (Match match in Round.Matches) {
                foreach (Team team in match.Teams) {
                    while (team.IsFull == false) {
                        var player = Round.IdlePlayers.SelectRandom();
                        team.AddPlayer(player);
                        Round.IdlePlayers.Remove(player);
                        if (Round.IdlePlayers.Count == 0) return Round;
                    }
                }
            }

            return Round;
        }

        public override void Mutate() {
            var p1 = Round.AllPlayers.SelectRandom();
            var p2 = Round.AllPlayers.SelectRandom();
            if (p1 == p2) return;

            var t1 = Round.GetTeam(p1);
            var t2 = Round.GetTeam(p2);

            if (t1 == t2) return;

            t1.RemovePlayer(p1);
            t2.RemovePlayer(p2);

            t1.AddPlayer(p2);
            t2.AddPlayer(p1);
        }
    }
}
