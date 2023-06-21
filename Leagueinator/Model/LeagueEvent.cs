using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueinator.Model {
    [Serializable]
    public class LeagueEvent {
        public readonly string Date;
        public readonly Settings settings;
        public readonly string Name;

        public List<PlayerInfo> Players { get; private set; } = new List<PlayerInfo>();

        public List<Round> Rounds { get; private set; } = new List<Round>();

        public LeagueEvent(string date, String name, Settings settings) {
            this.Date = date;
            this.Name = name;   
            this.settings = settings;
        }

        public LeagueEvent(Settings settings) {
            this.Date = DateTime.Today.ToString("yyyy-MM-dd");
            this.Name = "Event";
            this.settings = settings;
        }

        /// <summary>
        /// Add players to this event.
        /// Does not automatically update when new players are added to the league.
        /// </summary>
        /// <param name="players"></param>
        public void AddPlayers(IEnumerable<PlayerInfo> players) {
            foreach (var playerInfo in players) this.Players.Add(playerInfo);
        }

        public void AddPlayer(PlayerInfo playerInfo) {
            this.Players.Add(playerInfo);
        }

        /// <summary>
        /// Add a new empty round to this event.
        /// </summary>
        public Round AddRound() {
            var round = new Round(this.Players, this.settings);
            this.Rounds.Add(round);
            return round;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players [{this.Players.DelString()}]");
            sb.AppendLine($"Rounds [");
            this.Rounds.ForEach(i => sb.AppendLine(i.ToString()));
            sb.AppendLine($"]");
            return sb.ToString();
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
