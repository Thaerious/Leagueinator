using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Team {
        public readonly Settings settings;

        private PlayerInfo[] _players;
        public PlayerInfo this[int key] {
            get {
                return _players[key];
            }
            set {
                if (_players[key] == value) return;
                _players[key] = value;
            }
        }

        public int MaxSize => _players.Length;

        public bool IsFull => _players.Length == Players.Count;

        [Model]
        public ICollection<PlayerInfo> Players {
            get => new List<PlayerInfo>().AddUnique(_players);

            set {
                Clear();
                int i = 0;

                foreach (PlayerInfo p in value) {
                    _players[i++] = p;
                }
            }
        }

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
            for (int i = 0; i < _players.Length; i++) {
                _players[i] = null;
            }
        }

        public bool HasPlayer(PlayerInfo player) {
            return Players.Contains(player);
        }

        public void AddPlayer(PlayerInfo player) {
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i] == null) {
                    _players[i] = player;
                    return;
                }
            }

            throw new ArgumentException();
        }

        public void RemovePlayer(PlayerInfo player) {
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i] == player) {
                    _players[i] = null;
                    return;
                }
            }

            throw new KeyNotFoundException();
        }
    }
}
