using System;
using System.Collections.Generic;
using System.Linq;
using Leagueinator.Model;
using Leagueinator.Search_Algorithms;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Search_Algorithms.Solutions {

    public class PartnerSolution : ASolution {
        public readonly LeagueEvent LEvent;
        public readonly Round Round;
        private readonly Random rng = new Random();

        public PartnerSolution(LeagueEvent lEvent, Round round) : base(0) {
            this.LEvent = lEvent;
            this.Round = round.Clone();
        }

        public PartnerSolution(PartnerSolution that) : base(0) {
            this.LEvent = that.LEvent;
            this.Round = that.Round;
        }

        public Round Value => this.Round;

        public override ASolution Clone() => new PartnerSolution(this.LEvent, this.Round);

        /// <summary>
        /// Return the nubmer of times player1 was on a team with player2
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int Evaluate(PlayerInfo player1, PlayerInfo player2) {
            int sum = 0;

            List<Team> teams = this.LEvent
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

            foreach (PlayerInfo player1 in this.Round.ActivePlayers) {
                var team = this.Round.GetTeam(player1);

                foreach (PlayerInfo player2 in team.Players) {
                    if (player1.Equals(player2)) continue;
                    sum += this.Evaluate(player1, player2);
                }
            }

            return sum / 2;
        }

        public override bool IsValid() => true;

        public Round Randomize() {
            this.Round.ResetPlayers();

            foreach (Match match in this.Round.Matches) {
                foreach (Team team in match.Teams) {
                    while (team.IsFull == false) {
                        var player = this.Round.IdlePlayers.SelectRandom();
                        team.AddPlayer(player);
                        this.Round.IdlePlayers.Remove(player);
                        if (this.Round.IdlePlayers.Count == 0) return this.Round;
                    }
                }
            }

            return this.Round;
        }

        public override void Mutate() {
            var p1 = this.Round.AllPlayers.SelectRandom();
            var p2 = this.Round.AllPlayers.SelectRandom();
            if (p1 == p2) return;

            var t1 = this.Round.GetTeam(p1);
            var t2 = this.Round.GetTeam(p2);

            if (t1 == t2) return;

            t1.RemovePlayer(p1);
            t2.RemovePlayer(p2);

            t1.AddPlayer(p2);
            t2.AddPlayer(p1);
        }
    }
}
