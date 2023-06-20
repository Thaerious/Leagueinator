using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueinator.Model {
    [Serializable]
    public class League {
        public List<PlayerInfo> Players { get; private set; } = new List<PlayerInfo>();

        public List<LeagueEvent> Events { get; private set; } = new List<LeagueEvent> ();

        /// <summary>
        /// Add to the default players of this League.
        /// </summary>
        /// <param name="players"></param>
        public void AddPlayers(IEnumerable<String> players) {
            foreach (var name in players) this.Players.Add(new PlayerInfo(name));
        }

        /// <summary>
        /// Add a new Event to the league.
        /// Will add all current league players to the event.
        /// </summary>
        /// <returns></returns>
        public LeagueEvent AddEvent(Settings settings) {
            var lEvent = new LeagueEvent(settings);
            lEvent.AddPlayers(this.Players);
            this.Events.Add(lEvent);            
            return lEvent;
        }

        /// <summary>
        /// Add a new Event to the league with a date.
        /// Will add all current league players to the event.
        /// </summary>
        /// <returns></returns>
        public LeagueEvent AddEvent(string date, string name, Settings settings) {
            var lEvent = new LeagueEvent(date, name, settings);
            lEvent.AddPlayers(this.Players);
            this.Events.Add(lEvent);
            return lEvent;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Players : ");
            foreach (var player in this.Players) {
                sb.AppendLine(" - " + player.ToString());
            }
            foreach (var lEvent in this.Events) {
                sb.AppendLine(lEvent.ToString());
            }
            return sb.ToString();
        }
    }
}
