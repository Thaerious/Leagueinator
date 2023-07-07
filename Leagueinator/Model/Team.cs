using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Team {
        public readonly Settings settings;

        private PlayerInfo[] _players;
        public PlayerInfo this[int key] {
            get => this._players[key];
            set => this._players[key] = value;
        }

        public int MaxSize => this._players.Length;

        public bool IsFull => this.Players.Count == this.MaxSize;

        public bool IsEmpty => this.Players.Count == 0;

        [Model] public List<PlayerInfo> Players => new List<PlayerInfo>().AddUnique(this._players);

        public Team(Settings settings) {
            this.settings = settings;
            this._players = new PlayerInfo[settings.TeamSize];
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Team", $"hash='{this.GetHashCode().ToString("X")}'");
            
            foreach ( var player in this.Players ) {
                xsb.AppendXML( player.ToXML() );
            }
            
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }

        public void Clear() {
            this._players.Fill(null);
        }

        public bool HasPlayer(PlayerInfo player) {
            return this.Players.Contains(player);
        }

        /// <summary>
        /// Add player to the next empty position.
        /// If there is no emptly position, no change is made.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True, if a change was made.</returns>
        public bool AddPlayer(PlayerInfo player) {
            for (int i = 0; i < this._players.Length; i++) {
                if (this._players[i] == null) {
                    this._players[i] = player;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove a player from this Team.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True, if a change was made.</returns>
        public bool RemovePlayer(PlayerInfo player) {
            for (int i = 0; i < this._players.Length; i++) {
                if (this._players[i] == player) {
                    this._players[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
