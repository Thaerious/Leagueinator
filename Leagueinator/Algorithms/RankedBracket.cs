using Leagueinator.Controller;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Leagueinator.Algorithms {
    /// <summary>
    /// A class for assigning match pairings using the round robin algorithm.
    /// The Reference class is passed into the constuctor and is used to create
    /// new rounds.  The reference class is not manipulated.
    /// </summary>
    public class RankedBracket {
        private readonly LeagueEvent leagueEvent;
        private readonly IScoreKeeper iScoreKeeper;

        public RankedBracket(LeagueEvent leagueEvent, IScoreKeeper iScoreKeeper) {
            this.leagueEvent = leagueEvent;
            this.iScoreKeeper = iScoreKeeper;
        }

        /// <summary>
        /// Create a new Round instance based on the referenced LeagueEvent.
        /// </summary>
        /// <returns>A new round instance (not added to the LeagueEvent)</returns>
        public Round GenerateRound() {
            List<Team> teams = this.leagueEvent[ListPos.LAST].Teams;
            teams.Select(team => team.Players.Count > 0);
            teams.Sort(new TeamComparer(this.iScoreKeeper));
            teams.Reverse();

            Round round = new Round(this.leagueEvent.Settings);

            int i = 0;
            foreach (Match match in round.Matches) {
                if (i < teams.Count) {
                    match[0] = teams[i++].DeepCopy();
                    match[0].Score = 0;
                }

                if (i < teams.Count) {
                    match[1] = teams[i++].DeepCopy();
                    match[1].Score = 0;
                }
            }

            return round;
        }
    }
}
