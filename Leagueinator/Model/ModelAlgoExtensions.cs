using Leagueinator.Algorithms;
using Leagueinator.Algorithms.Solutions;
using Leagueinator.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Model {
    public static class ModelAlgoExtensions {

        /// <summary>
        /// Copy players from the first round to the target round.</br>
        /// Retains the teams composition and order.</br>
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        public static void CopyPlayersTo(this LeagueEvent lEvent, Round target) {
            Round source = lEvent[0];
            if (source == null) return;

            target.ResetPlayers();

            for (int i = 0; i < source.MaxSize; i++) {
                var match = source.Matches[i];
                for (int j = 0; j < match.MaxSize; j++) {
                    var team = match[j];
                    for (int k = 0; k < team.MaxSize; k++) {
                        target.IdlePlayers.Remove(team[k]);
                        target[i][j][k] = team[k];
                    }
                }
            }
        }

        /// <summary>
        /// Add a new round to the event populated with the round robin algorithm.
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Round AddRoundRobin(this LeagueEvent lEvent) {
            if (lEvent.Rounds.Count == 0) throw new Exception("Event must contain one or more rounds.");

            Round reference = lEvent[0];

            reference.InjectByes();
            RoundRobin rr = new RoundRobin(reference);

            int count = lEvent.Rounds.Count;
            Debug.WriteLine($"count {count}");

            Round newRound = rr.Value(count);
            lEvent.AddRound(newRound);
            Debug.WriteLine("new round");
            Debug.WriteLine(newRound);
            return newRound;
        }

        /// <summary>
        /// Add a new round to the event populated with the ranked bracket algorithm.
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        /// <retu
        public static Round AddRoundRanked(this LeagueEvent lEvent) {
            var scoreKeeper = new ScoreKeeper(lEvent);
            var round = new RankedBracket(lEvent, scoreKeeper).GenerateRound();
            lEvent.AddRound(round);
            return round;
        }

        /// <summary>
        /// Replace the target round with a generated round generated from
        /// the Penache algorithm.
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Round DoPenache(this LeagueEvent lEvent, Round target) {
            Round reference = lEvent[0];
            Penache penache = new Penache(reference);
            int index = lEvent.IndexOf(target);
            Round newRound = penache.Value(index);

            var idle = reference.AllPlayers;
            idle.RemoveAll(p => newRound.ActivePlayers.Contains(p));
            newRound.IdlePlayers.AddRange(idle);

            lEvent.ReplaceRound(target, newRound);
            return newRound;
        }

        /// <summary>
        /// Replace the target round with the round generated from the 
        /// GreedyWalk algorithm.
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Round AssignLanes(this LeagueEvent lEvent, Round target) {
            var solution = new LaneSolution(lEvent, target);
            var algo = new GreedyWalk();

            int index = lEvent.IndexOf(target);

            var best = algo.Run(solution, s => {
                //Debug.WriteLine($"{algo.Generation} : [{s.Evaluate()}]");
            });

            Round newRound = best.Value();
            newRound.IdlePlayers.AddRange(target.IdlePlayers);
            lEvent.ReplaceRound(target, newRound);
            return newRound;
        }
    }
}
