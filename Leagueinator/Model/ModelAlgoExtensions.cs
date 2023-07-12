using Leagueinator.Algorithms;
using Leagueinator.Algorithms.Solutions;
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
        /// Replace the target round with a generated round generated from
        /// the RoundRobin algorithm.
        /// </summary>
        /// <param name="lEvent"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Round DoRoundRobin(this LeagueEvent lEvent, Round target) {
            Round reference = lEvent[0];
            reference.InjectByes();
            Debug.WriteLine(reference);
            RoundRobin rr = new RoundRobin(reference);
            int index = lEvent.IndexOf(target);
            Round newRound = rr.Value(index);
            lEvent.ReplaceRound(target, newRound);
            return newRound;
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
        public static Round DoAssignLanes(this LeagueEvent lEvent, Round target) {
            var solution = new LaneSolution(lEvent, target);
            var algo = new GreedyWalk();

            int index = lEvent.IndexOf(target);

            var best = algo.Run(solution, s => {
                //Debug.WriteLine($"{algo.Generation} : [{s.Evaluate()}]");
            });

            Round newRound = best.Value();
            lEvent.ReplaceRound(target, newRound);
            return newRound;
        }
    }
}
