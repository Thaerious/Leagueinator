using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Model {
    [Serializable]
    public class Team {
        private readonly PlayerInfo[] _players;

        public PlayerInfo this[int key] {
            get { return _players[key]; }
            set { _players[key] = value; }
        }

        public List<PlayerInfo> Players {
            get => new List<PlayerInfo>().AddUnique(this._players);
        }


        public Team(Settings settings) {
            this._players = new PlayerInfo[settings.TeamSize];
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.InlineTag("Team", this.Players.DelString());
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }
    }

    public interface IModelTeam {
        Team Team { get; set; }
    }
}
