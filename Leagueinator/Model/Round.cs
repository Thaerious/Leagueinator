using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Round {
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();
        private readonly Match[] _matches;

        public Match this[int key] {
            get { return _matches[key]; }
            set { _matches[key] = value; }
        }

        public List<Match> Matches {
            get => new List<Match>().AddUnique(this._matches);
        }

        public List<PlayerInfo> Players {
            get {
                var list = new List<PlayerInfo>();
                list.AddUnique(this.IdlePlayers);

                foreach (Match match in this.Matches) {
                    list.AddUnique(match.Players);
                }
                return list;
            }
        }

        public Round(Settings settings) {
            this._matches = new Match[settings.LaneCount];
            for (int i = 0; i < this._matches.Length; i++) {
                _matches[i] = new Match(settings);
            }
        }

        public Round(List<PlayerInfo> idlePlayers, Settings settings) : this(settings) {
            var copy = idlePlayers.DeepCopy();
            this.IdlePlayers = copy;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Round");
            xsb.InlineTag("Players", this.Players.DelString());
            xsb.InlineTag("Idle", this.IdlePlayers.DelString());
            for (int i = 0; i < this._matches.Length; i++) {
                xsb.AppendXML(this._matches[i].ToXML(i));
            }
            xsb.CloseTag("Round");
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }
    }

    public interface IModelRound {
        Round Round { get; set; }
    }
}
