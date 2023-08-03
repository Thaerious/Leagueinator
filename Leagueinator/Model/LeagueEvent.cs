using System;
using System.Collections;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;
using Leagueinator.Model.Settings;
using System.Diagnostics;

namespace Leagueinator.Model {
    [Serializable]
    public class LeagueEvent : IEnumerable<Round> {
        public readonly string Date;
        public readonly Settings.Setting Settings;
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

        public Round this[ListPos pos] {
            get {
                switch (pos) {
                    case ListPos.FIRST: return this[0];
                    default: return this[this.Size - 1];
                }
            }
        }

        public int Size { get => this.Rounds.Count; }

        public LeagueEvent(string date, String name, Setting settings) {
            this.Date = date;
            this.Name = name;
            this.Settings = settings;
        }

        public LeagueEvent(Setting settings) {
            this.Date = DateTime.Today.ToString("yyyy-MM-dd");
            this.Name = "Event";
            this.Settings = settings;
        }

        /// <summary>
        /// Add a new empty round to this event.
        /// The new round will contain all players (idle) found in this event.
        /// </summary>
        public Round NewRound() {
            var round = new Round(this.SeekDeep<PlayerInfo>().Unique(), this.Settings);
            this.Rounds.Add(round);
            return round;
        }

        /// <summary>
        /// Add an existing round to this event.
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public Round AddRound(Round round) {
            this.Rounds.Add(round);
            return round;
        }

        /// <summary>
        /// Replace a round in this event with a specified round.
        /// </summary>
        /// <param name="replace"></param>
        /// <param name="with"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ReplaceRound(Round replace, Round with) {
            int index = this.Rounds.IndexOf(replace);

            if (index < 0) {
                throw new ArgumentOutOfRangeException(
                    $"Attempting to replace round that is not a member of League Event"
                );
            }

            this.Rounds[index] = with;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();

            xsb.OpenTag("Event", $"name='{this.Name}' hash='{this.GetHashCode().ToString("X")}'");
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

        internal void RemoveRound(Round round) {
            Debug.WriteLine($"Remove Round {round.GetHashCode("X")}");
            this.Rounds.Remove(round);
            Debug.WriteLine(this);
        }
    }

    public interface IModelLeagueEvent {
        LeagueEvent LeagueEvent { get; set; }
    }
}
