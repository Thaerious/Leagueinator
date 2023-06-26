using System.Diagnostics;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class DragData {
        public HasPlayerInfo Source;
        public PlayerInfo PlayerInfo;

        public void SwapWith(HasPlayerInfo dest) {
            PlayerInfo prev = dest.AddPlayer(PlayerInfo);
            Source.ClearPlayer(PlayerInfo);

            if (prev != null) { Source.AddPlayer(prev); }
        }
    }
}
