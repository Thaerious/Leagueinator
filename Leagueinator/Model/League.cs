using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class League {
        private readonly Settings settings;

        /// <summary>
        /// Retrieve a non-reflective list of players.
        /// Changes made to the list are non-reflective.
        /// Changes made to a playerInfo object is refelective.
        /// </summary>
        public List<PlayerInfo> Players {
            get {
                var list = new List<PlayerInfo>();
                foreach (var lEvent in Events) {
                    foreach (var p in lEvent.Players) {
                        if (!list.Contains(p)) list.Add(p);
                    }
                }
                return list;
            }
        }

        public List<LeagueEvent> Events { get; private set; } = new List<LeagueEvent>();

        /// <summary>
        /// Add to the default players of this League.
        /// </summary>
        /// <param name="players"></param>
        public void AddPlayers(IEnumerable<string> players) {
            foreach (var name in players) this.Players.Add(new PlayerInfo(name));
        }

        /// <summary>
        /// Add a new Event to the league.
        /// Will add all current league players to the event.
        /// </summary>
        /// <returns></returns>
        public LeagueEvent AddEvent(string eventName, string date, Settings settings) {
            var lEvent = new LeagueEvent(eventName, date, settings);
            var round = lEvent.AddRound();
            round.IdlePlayers.AddRange(this.Players);
            this.Events.Add(lEvent);
            return lEvent;
        }

        /// <summary>
        /// Construct a detailed string representation of a League object by combining 
        /// information about players and events, separated by newlines, and presented 
        /// in a formatted manner.
        /// </summary>
        /// <returns></returns>
        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("League");
            xsb.InlineTag("Players", this.Players.DelString());
            foreach (var lEvent in this.Events) {
                xsb.AppendXML(lEvent.ToXML());
            }
            xsb.CloseTag("League");
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }
    }
}
