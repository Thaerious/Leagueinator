using System;
using System.Collections.Generic;
using System.Linq;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class LeagueEvent {
        public readonly string Date;
        public readonly Settings settings;
        public readonly string Name;

        /// <summary>
        /// Retreive a non-reflective list of all rounds in this event.
        /// </summary>
        public List<Round> Rounds { get; private set; } = new List<Round>();

        public List<Team> Teams {
            get {
                var list = new List<Team>();
                this.Rounds.ForEach(r => list.AddRange(r.Teams));
                return list;
            }
        }

        public List<PlayerInfo> Players {
            get {
                var list = new List<PlayerInfo>();
                foreach (var round in Rounds) {
                    list.AddUnique(round.AllPlayers);
                }
                return list;
            }
        }

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
        /// Add a new empty round to this event.
        /// </summary>
        public Round AddRound() {
            var round = new Round(this.Players, this.settings);
            this.Rounds.Add(round);
            return round;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Event");
            xsb.InlineTag("Players", this.Players.DelString());
            foreach (var round in this.Rounds) {
                xsb.AppendXML(round.ToXML());
            }
            xsb.CloseTag("Event");
            return xsb;
        }
        public override string ToString() {
            return this.ToXML().ToString();
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
