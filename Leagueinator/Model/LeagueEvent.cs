using System;
using System.Collections;
using System.Collections.Generic;
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

        public int Size { get => Rounds.Count; }

        public LeagueEvent(string date, String name, Settings settings) {
            Date = date;
            Name = name;
            Settings = settings;
        }

        public LeagueEvent(Settings settings) {
            Date = DateTime.Today.ToString("yyyy-MM-dd");
            Name = "Event";
            Settings = settings;
        }

        /// <summary>
        /// Add a new empty round to this event.
        /// </summary>
        public Round AddRound() {
            var round = new Round(this.SeekDeep<PlayerInfo>(), Settings);
            Rounds.Add(round);
            return round;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Event");
            xsb.InlineTag("Players", this.SeekDeep<PlayerInfo>().DelString());
            foreach (var round in Rounds) {
                xsb.AppendXML(round.ToXML());
            }
            xsb.CloseTag("Event");
            return xsb;
        }
        public override string ToString() {
            return ToXML().ToString();
        }

        public IEnumerator<Round> GetEnumerator() {
            return Rounds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Rounds.GetEnumerator();
        }

        public int IndexOf(Round round) {
            return Rounds.IndexOf(round);
        }

        public void ForEach(Action<Round> value) {
            Rounds.ForEach(value);
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
