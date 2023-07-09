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
            get { return this.Rounds[key]; }            
        }

        public int Size { get => this.Rounds.Count; }

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
        public Round NewRound() {
            var round = new Round(this.SeekDeep<PlayerInfo>().Unique(), this.Settings);
            this.Rounds.Add(round);
            return round;
        }

        public Round AddRound(Round round) {
            this.Rounds.Add(round);
            return round;
        }

        public void ReplaceRound(Round replace, Round with) {
            int index = this.Rounds.IndexOf(replace);
            this.Rounds[index] = with;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Event", $"hash='{this.GetHashCode().ToString("X")}'");
            xsb.InlineTag("Players", this.SeekDeep<PlayerInfo>().DelString());
            foreach (var round in this.Rounds) {
                xsb.AppendXML(round.ToXML());
            }
            xsb.CloseTag();
            return xsb;
        }
        public override string ToString() {
            return this.ToXML().ToString();
        }

        public IEnumerator<Round> GetEnumerator() => this.Rounds.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.Rounds.GetEnumerator();

        public int IndexOf(Round round) {
            return this.Rounds.IndexOf(round);
        }

        public void ForEach(Action<Round> value) {
            this.Rounds.ForEach(value);
        }

        public Round PrevRound(Round round) {
            Round prev = null;
            foreach(Round r in this.Rounds) {
                if (r == round) return prev;
                prev = r;
            }
            return null;
        }

        public Round NextRound(Round round) {
            Round prev = null;
            foreach (Round r in this.Rounds) {
                if (prev == round) return r;
                prev = r;
            }
            return null;
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
