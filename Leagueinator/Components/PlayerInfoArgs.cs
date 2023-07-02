using Leagueinator.Model;

namespace Leagueinator.Components {
    public class PlayerInfoArgs {
        public delegate void PlayerInfoEvent(object source, PlayerInfoArgs args);
        public PlayerInfo PlayerInfo = null;
    }
}
