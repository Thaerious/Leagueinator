using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Team : HasDeepCopy<Team> {
        private PlayerInfo[] _players;
        private Settings settings;

        public PlayerInfo this[int key] {
            get {
                return _players[key];
            }
            set {
                if (value != null && this.HasPlayer(value)) {
                    throw new ArgumentException($"Team already contains value '{value.Name}'");
                }
                _players[key] = value;
            }
        }

        public int MaxSize => _players.Length;

        public bool isFull => _players.Length == Players.Count;

        public ICollection<PlayerInfo> Players {
            get => new List<PlayerInfo>().AddUnique(this._players);
            set {
                this.Clear();
                int i = 0;
                
                foreach (PlayerInfo p in value) {
                    this._players[i++] = p;
                }
            }
        }

        public Team(Settings settings) {
            this.settings = settings;
            this._players = new PlayerInfo[settings.TeamSize];
        }

        public Team DeepCopy() {
            return new Team(this.settings) {
                _players = this._players.DeepCopy()
            };
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.InlineTag("Team", this.Players.DelString());
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }

        public void Clear() {
            for (int i = 0; i < this._players.Length; i++) {
                this._players[i] = null;
            }
        }

        public bool HasPlayer(PlayerInfo player) {
            foreach (PlayerInfo p in this._players) if (p == player) return true;
            return false;
        }
    }
}
