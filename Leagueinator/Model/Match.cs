using System;
using System.Collections.Generic;
using System.Linq;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Match {
        public readonly Settings Settings;
        private readonly Team[] _teams;

        public Team this[int key] => _teams[key];

        [Model] public List<Team> Teams => new List<Team>().AddUnique(_teams);

        public List<PlayerInfo> Players => this.SeekDeep<PlayerInfo>().Unique();

        /// <summary>
        /// The maximum number of teams this match can have.
        /// </summary>
        public int MaxSize => _teams.Length;

        /// <summary>
        /// Count the number of teams that have more than 0 players.
        /// </summary>
        public int Count => _teams.Where(e=>e != null).Count();

        public Match(Settings settings) {
            Settings = settings;
            _teams = new Team[settings.MatchSize].Populate(() => new Team(settings));
        }

        public XMLStringBuilder ToXML(int lane) {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Match", $"lane='{lane}'");
            foreach (var team in Teams) {
                xsb.AppendXML(team.ToXML());
            }
            xsb.CloseTag();
            return xsb;
        }

        public override String ToString() {
            return ToXML(0).ToString();
        }

        public void ClearPlayers() {
            for (int i = 0; i < MaxSize; i++) {
                this[i].Clear();
            }
        }
    }
}
