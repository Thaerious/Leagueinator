using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Round {
        public readonly Settings Settings;
        private Match[] _matches;

        [Model]
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();

        public Match this[int key] {
            get { return _matches[key]; }
            set { _matches[key] = value; }
        }

        [Model]
        public List<Match> Matches {
            get => new List<Match>().AddUnique(_matches);
        }

        public int MaxSize => _matches.Length;

        /// <summary>
        /// Retreive a list of all teams that contain at least one player.
        /// </summary>
        public List<Team> Teams {
            get {
                List<Team> list = new List<Team>();
                foreach (Match match in _matches) {
                    foreach (Team team in match.Teams) {
                        if (team.Players.Count > 0) list.Add(team);
                    }
                }
                return list;
            }
        }

        public List<PlayerInfo> AllPlayers {
            get {
                var list = new List<PlayerInfo>();
                list.AddUnique(IdlePlayers);
                list.AddUnique(ActivePlayers);
                return list;
            }
        }

        public List<PlayerInfo> ActivePlayers {
            get {
                var list = new List<PlayerInfo>();

                foreach (Match match in Matches) {
                    list.AddUnique(match.Players);
                }
                return list;
            }
        }

        public Round(Settings settings) {
            if (settings == null) throw new NullReferenceException("settings");

            Settings = settings;
            _matches = new Match[settings.LaneCount];
            for (int i = 0; i < _matches.Length; i++) {
                _matches[i] = new Match(settings);
            }
        }

        public Round(List<PlayerInfo> idlePlayers, Settings settings) : this(settings) {
            Settings = settings;
            IdlePlayers = new List<PlayerInfo>(idlePlayers);
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Round");
            xsb.InlineTag("Players", AllPlayers.DelString());
            xsb.InlineTag("Idle", IdlePlayers.DelString());

            for (int i = 0; i < _matches.Length; i++) {
                if (_matches[i].Players.Count == 0) continue;
                xsb.AppendXML(_matches[i].ToXML(i));
            }

            xsb.CloseTag("Round");
            return xsb;
        }

        public override string ToString() {
            return ToXML().ToString();
        }

        /// <summary>
        /// Move all players in teams to idle, 
        /// retaining players previously in idle.
        /// </summary>
        public void ResetPlayers() {
            var players = AllPlayers;
            IdlePlayers.Clear();

            foreach (PlayerInfo player in players) {
                IdlePlayers.Add(player);
            }

            foreach (Match match in _matches) {
                match.ClearPlayers();
            }
        }

        public Team GetTeam(PlayerInfo player) {
            foreach (Team team in Teams) {
                if (team.HasPlayer(player)) return team;
            }
            return null;
        }
    }

    public interface IModelRound {
        Round Round { get; set; }
    }
}
