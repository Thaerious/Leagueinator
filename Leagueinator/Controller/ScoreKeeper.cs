using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Controller {
    public class ScoreKeeper : IScoreKeeper {
        private LeagueEvent lEvent;

        public ScoreKeeper(LeagueEvent lEvent) {
            this.lEvent = lEvent;
        }

        public Score this[PlayerInfo player] {
            get {
                var score = new Score(this.Labels.Length);
                var Matches = this.lEvent.SeekDeep<Match>().Unique();
                foreach (Match match in Matches) {
                    if (match.WinningTeam().Players.Contains(player)) {
                        score[0]++;
                    }
                }
                return score;
            }
        }

        public string[] Labels => new string[] { "Wins" };
    }
}
