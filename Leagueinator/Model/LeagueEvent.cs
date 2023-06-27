using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class LeagueEvent : IEnumerable<Round> {
        public readonly string Date;
        public readonly Settings Settings;
        public readonly string Name;

        /// <summary>
        /// Retreive a non-reflective list of all rounds in this event.
        /// </summary>
        [Model]
        public List<Round> Rounds {
            get; private set;
        } = new List<Round>();

        public Round this[int key] {
            get { return Rounds[key]; }
            set { Rounds.Remove(Rounds[key]); }
        }

        public int Size { get => Rounds.Count;}

        public LeagueEvent(string date, String name, Settings settings) {
            this.Date = date;
            this.Name = name;
            this.Settings = settings;
        }

        public LeagueEvent(Settings settings) {
            this.Date = DateTime.Today.ToString("yyyy-MM-dd");
            this.Name = "Event";
            this.Settings = settings;
        }

        /// <summary>
        /// Add a new empty round to this event.
        /// </summary>
        public Round AddRound() {
            var round = new Round(this.SeekDeep<PlayerInfo>(), this.Settings);
            this.Rounds.Add(round);
            return round;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Event");
            xsb.InlineTag("Players", this.SeekDeep<PlayerInfo>().DelString());
            foreach (var round in this.Rounds) {
                xsb.AppendXML(round.ToXML());
            }
            xsb.CloseTag("Event");
            return xsb;
        }
        public override string ToString() {
            return this.ToXML().ToString();
        }

        public IEnumerator<Round> GetEnumerator() {
            return this.Rounds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.Rounds.GetEnumerator();
        }

        public int IndexOf(Round round) {
            return Rounds.IndexOf(round);
        }

        public void ForEach(Action<Round> value) {
            Rounds.ForEach(value);
        }

        public List<Team> GetTeams(PlayerInfo player) {
            List<Team> teams = new List<Team>();
            foreach (Team team in this.SeekAll<Team>()) {
                if (team.HasPlayer(player)) teams.Add(team);
            }
            return teams;
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
