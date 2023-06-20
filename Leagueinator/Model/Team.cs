using System.Collections.Generic;

namespace Leagueinator.Model {
    public class Team {
        public readonly PlayerInfo[] Players;

        public Team(Settings settings) {
            this.Players = new PlayerInfo[settings.TeamSize];
        }

        /// <summary>
        /// Set the player in a specific index.
        /// Returns the player previously in that index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="playerInfo"></param>
        /// <returns></returns>
        public PlayerInfo SetPlayer(int index, PlayerInfo playerInfo) {
            PlayerInfo previousPlayer = Players[index];
            Players[index] = playerInfo;
            return previousPlayer;
        }
    }

    public interface IModelTeam {
        Team Team { get; set; }
    }
}
