using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    if (!match.Players.Contains(player)) continue;
                    if (match.WinningTeam() == null) continue;

                    if (match.WinningTeam().Players.Contains(player)) {
                        score[0]++;
                    }
                    
                    foreach (Team team in match.Teams) {
                        if (team.Players.Contains(player)) {
                            score[1] += team.Score;
                        } else {
                            score[2] += team.Score;
                        }
                    }
                }
                return score;
            }
        }

        public Score this[Team team] {
            get {
                var score = new Score(this.Labels.Length);
                foreach (PlayerInfo player in team.Players) {
                    score += this[player];
                }
                return score / this.lEvent.Settings.TeamSize;
            }
        }

        public string[] Labels => new string[] { "Wins", "Points_For", "Points_Against"};

        public Score Zero => new Score(this.Labels.Length);
    }

    public class ScoreComparer : IComparer<PlayerInfo> {
        private readonly IScoreKeeper scoreKeeper;

        public ScoreComparer(IScoreKeeper scoreKeeper) {
            this.scoreKeeper = scoreKeeper;
        }

        public int Compare(PlayerInfo x, PlayerInfo y) {
            if (x == y) return 0;
            return scoreKeeper[x] > scoreKeeper[y] ? 1 : -1;
        }
    }

    public class TeamComparer : IComparer<Team> {
        private readonly IScoreKeeper scoreKeeper;

        public TeamComparer(IScoreKeeper scoreKeeper) {
            this.scoreKeeper = scoreKeeper;
        }

        public int Compare(Team x, Team y) {
            if (x == y) return 0;
            if (x.Players.Count == 0 && y.Players.Count == 0) return 0;
            if (x.Players.Count == 0) return -1;
            if (y.Players.Count == 0) return 1;            

            return scoreKeeper[x] > scoreKeeper[y] ? 1 : -1;
        }
    }
}
