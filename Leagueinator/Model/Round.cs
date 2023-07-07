using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Round : HasDeepCopy<Round>{
        public readonly Settings Settings;
        private Match[] _matches;

        [Model]
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();

        public Match this[int key] {
            get => this._matches [key];
            set => this._matches[key] = value;
        }

        public Match this[Match match] {
            get {
                if (this.Matches.Contains(match)) return match;
                throw new InvalidOperationException ();
            }
            set {
                if (!this.Matches.Contains(match)) throw new InvalidOperationException();
                int idx = this.Matches.IndexOf(match);
                Debug.WriteLine($"Set index {idx} to {value.GetHashCode().ToString("X")}");
                this._matches[idx] = value;
            }
        }

        [Model] public List<Match> Matches => new List<Match>().AddUnique(this._matches);

        public int MaxSize => this._matches.Length;

        public List<Team> Teams => this.SeekDeep<Team>().Where(t => !t.IsEmpty).ToList();

        public List<PlayerInfo> AllPlayers {
            get {
                var list = new List<PlayerInfo>();
                list.AddUnique(this.IdlePlayers);
                list.AddUnique(this.ActivePlayers);
                return list;
            }
        }

        public List<PlayerInfo> ActivePlayers => this.Matches.SeekDeep<PlayerInfo>().Unique();

        public Round(Settings settings) {
            if (settings == null) throw new NullReferenceException("settings");
            this.Settings = settings;
            this._matches = new Match[settings.LaneCount].Populate(() => new Match(settings));
        }

        public Round(List<PlayerInfo> idlePlayers, Settings settings) : this(settings) {
            this.Settings = settings;
            this.IdlePlayers = new List<PlayerInfo>(idlePlayers);
        }

        public void CopyFrom(Round that) {
            this.IdlePlayers = new List<PlayerInfo>(that.IdlePlayers);

            for (int m = 0; m < this.MaxSize; m++) {
                for (int t = 0; t < this[m].MaxSize; t++) {
                    for (int p = 0; p < this[m][t].MaxSize; p++) {
                        this[m][t][p] = that[m][t][p];
                    }
                }
            }
        }

        public Round Clone() {
            var clone = new Round(this.Settings);
            clone.CopyFrom(this);
            return clone;
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Round", $"hash='{this.GetHashCode().ToString("X")}'");
            xsb.InlineTag("Players", this.AllPlayers.DelString());
            xsb.InlineTag("Idle", this.IdlePlayers.DelString());

            for (int i = 0; i < this._matches.Length; i++) {
                if (this._matches[i].Players.Count == 0) continue;
                xsb.AppendXML(this._matches[i].ToXML(i));
            }

            xsb.CloseTag();
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
            foreach (Team team in this.Teams) {
                if (team.HasPlayer(player)) return team;
            }
            return null;
        }

        public Round DeepCopy() {
            return new Round(this.Settings) {
                IdlePlayers = this.IdlePlayers.DeepCopy(),
                _matches = this._matches.DeepCopy()
            };
        }
    }
}
