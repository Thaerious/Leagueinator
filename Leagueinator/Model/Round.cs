using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Round : HasDeepCopy<Round> {
        public readonly Settings Settings;
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();
        private Match[] _matches;

        public Match this[int key] {
            get { return _matches[key]; }
            set { _matches[key] = value; }
        }

        public List<Match> Matches {
            get => new List<Match>().AddUnique(this._matches);
        }

        public int MaxSize => this._matches.Length;

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
                list.AddUnique(this.IdlePlayers);
                list.AddUnique(this.ActivePlayers);
                return list;
            }
        }

        public List<PlayerInfo> ActivePlayers {
            get {
                var list = new List<PlayerInfo>();

                foreach (Match match in this.Matches) {
                    list.AddUnique(match.Players);
                }
                return list;
            }
        }

        public Round(Settings settings) {
            if (settings == null) throw new NullReferenceException("settings");

            this.Settings = settings;
            this._matches = new Match[settings.LaneCount];
            for (int i = 0; i < this._matches.Length; i++) {
                _matches[i] = new Match(settings);
            }
        }

        public Round(List<PlayerInfo> idlePlayers, Settings settings) : this(settings) {
            this.Settings = settings;
            this.IdlePlayers = idlePlayers.DeepCopy();
        }

        public Round DeepCopy(){            
            return new Round(this.Settings) {
                IdlePlayers = this.IdlePlayers.DeepCopy(),
                _matches = this._matches.DeepCopy()
            };
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Round");
            xsb.InlineTag("Players", this.AllPlayers.DelString());
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

        /// <summary>
        /// Move all players in teams to idle, 
        /// retaining players previously in idle.
        /// </summary>
        public void ResetPlayers() {
            var players = this.AllPlayers;
            this.IdlePlayers.Clear();
            foreach (PlayerInfo player in players) {
                this.IdlePlayers.Add(player);
            }

            foreach (Match match in this._matches) {
                match.ClearPlayers();
            }
        }

        public Team GetTeam(PlayerInfo player) {
            foreach(Team team in this.Teams) {
                if (team.HasPlayer(player)) return team;
            }
            return null;
        }
    }

    public interface IModelRound {
        Round Round { get; set; }
    }
}
