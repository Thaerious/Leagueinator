using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Match {
        public readonly Settings Settings;
        private Team[] _teams;

        public Team this[int key] {
            get { return _teams[key]; }
            set { _teams[key] = value; }
        }

        [Model]
        public List<Team> Teams {
            get => new List<Team>().AddUnique(this._teams);
        }

        public List<PlayerInfo> Players {
            get {
                var list = new List<PlayerInfo>();

                foreach (Team team in this.Teams) {
                    list.AddUnique(team.Players);
                }
                return list;
            }
        }

        /// <summary>
        /// The number of teams this match can accept.
        /// </summary>
        public int MaxSize => this._teams.Length;

        public Match(Settings settings) {
            this.Settings = settings;
            this._teams = new Team[settings.MatchSize];
            for (int i = 0; i < settings.MatchSize; i++) {
                this[i] = new Team(settings);
            }
        }

        public XMLStringBuilder ToXML(int lane) {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Match", $"lane='{lane}'");
            foreach (var team in this.Teams) {
                xsb.AppendXML(team.ToXML());
            }
            xsb.CloseTag("Match");
            return xsb;
        }

        public override String ToString() {
            return this.ToXML(0).ToString();
        }

        public void ClearPlayers() {
            for (int i = 0; i < this.MaxSize; i++) {
                this[i].Clear();
            }
        }
    }

    public interface HasModelMatch {
        Match Match { get; set; }
    }
}
