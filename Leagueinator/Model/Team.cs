using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;
using Org.BouncyCastle.Utilities.IO;

namespace Leagueinator.Model {
    [Serializable]
    public class Team {
        public readonly Settings settings;

        private PlayerInfo[] _players;
        public PlayerInfo this[int key] {
            get => _players[key];
            set => _players[key] = value;
        }

        public int MaxSize => _players.Length;

        public bool IsFull => Players.Count == this.MaxSize;

        public bool IsEmpty => Players.Count == 0;

        [Model] public List<PlayerInfo> Players => new List<PlayerInfo>().AddUnique(_players);

        public Team(Settings settings) {
            this.settings = settings;
            _players = new PlayerInfo[settings.TeamSize];
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.InlineTag("Team", Players.DelString());
            return xsb;
        }

        public override string ToString() {
            return ToXML().ToString();
        }

        public void Clear() {
            this._players.Fill(null);
        }

        public bool HasPlayer(PlayerInfo player) {
            return Players.Contains(player);
        }

        /// <summary>
        /// Add player to the next empty position.
        /// If there is no emptly position, no change is made.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True, if a change was made.</returns>
        public bool AddPlayer(PlayerInfo player) {
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i] == null) {
                    _players[i] = player;
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
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i] == player) {
                    _players[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
