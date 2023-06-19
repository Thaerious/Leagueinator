using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leagueinator.Model {
    public class LeagueEvent : HasDeepCopy<LeagueEvent> {
        public readonly string Date;

        public List<PlayerInfo> Players { get; private set; } = new List<PlayerInfo>();

        public List<Round> Rounds { get; private set; } = new List<Round>();

        public LeagueEvent(string date) {
            this.Date = date;
        }

        public LeagueEvent(string date, List<PlayerInfo> players, List<Round> rounds) : this(date) {
            Players = players.DeepCopy();
            Rounds = rounds.DeepCopy();
        }

        public LeagueEvent() {
            this.Date = DateTime.Today.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Add players to this event.
        /// Does not automatically update when new players are added to the league.
        /// </summary>
        /// <param name="players"></param>
        public void AddPlayers(IEnumerable<PlayerInfo> players) {
            foreach (var playerInfo in players) this.Players.Add(playerInfo);
        }

        /// <summary>
        /// Add a new empty round to this event.
        /// </summary>
        public Round AddRound() {
            var round = new Round(this.Players);
            this.Rounds.Add(round);
            return round;
        }

        public LeagueEvent DeepCopy() {
            
            var that = new LeagueEvent(this.Date) {
                Players = this.Players.DeepCopy(),
                Rounds = this.Rounds.DeepCopy()
            };

            return that;
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
