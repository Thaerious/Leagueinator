using System.Collections.Generic;

namespace Leagueinator.Model {
    public class Team : HasDeepCopy<Team> {
        public Dictionary<int, PlayerInfo> Players { get; private set; } = new Dictionary<int, PlayerInfo>();

        public void AddPlayer(PlayerInfo playerInfo) {
            this.Players.Add(Players.Count, playerInfo);
        }

        public void AddPlayer(int index, PlayerInfo playerInfo) {
            this.Players.Add(index, playerInfo);
        }

        public Team DeepCopy() {
            return new Team {
                Players = this.Players.DeepCopy()
            };
        }
    }

    public interface IModelTeam {
        Team Team { get; set; }
    }
}
