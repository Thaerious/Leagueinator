using System;
using System.Collections.Generic;
using System.Linq;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Round {
        public readonly Settings Settings;
        private readonly Match[] _matches;

        [Model]
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();

        public Match this[int key] => _matches[key];

        [Model] public List<Match> Matches => new List<Match>().AddUnique(_matches);

        public int MaxSize => _matches.Length;

        public List<Team> Teams => this.SeekDeep<Team>().Where(t => !t.IsEmpty).ToList();

        public List<PlayerInfo> AllPlayers {
            get {
                var list = new List<PlayerInfo>();
                list.AddUnique(IdlePlayers);
                list.AddUnique(ActivePlayers);
                return list;
            }
        }

        public List<PlayerInfo> ActivePlayers => Matches.SeekDeep<PlayerInfo>().Unique();

        public Round(Settings settings) {
            if (settings == null) throw new NullReferenceException("settings");
            Settings = settings;
            _matches = new Match[settings.LaneCount].Populate(() => new Match(settings));
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

            xsb.CloseTag();
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
