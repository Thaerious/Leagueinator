using Leagueinator.Controller;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System.Collections.Generic;
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
            List<Team> list = this.leagueEvent.SeekDeep<Team>();
            list.Select(team => team.Players.Count > 0);
            list.Unique();
            list.Sort(new TeamComparer(this.iScoreKeeper));
            list.Reverse();

            Round round = new Round(this.leagueEvent.Settings);

            int i = 0;
            foreach (Match match in round.Matches) {
                if (i < list.Count) {
                    match[0] = list[i++].DeepCopy();
                    match[0].Score = 0;
                }

                if (i < list.Count) {
                    match[1] = list[i++].DeepCopy();
                    match[1].Score = 0;
                }
            }

            return round;
        }
    }
}
