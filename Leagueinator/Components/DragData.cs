using System.Diagnostics;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class DragData {
        public IModelPlayer Source;
        public PlayerInfo PlayerInfo;

        public void SwapWith(IModelPlayer dest) {
            Debug.WriteLine("SwapWith");
            Debug.WriteLine("src " + Source);
            Debug.WriteLine("dest " + dest);

            PlayerInfo prev = dest.AddPlayer(PlayerInfo);
            Source.ClearPlayer(PlayerInfo);

            if (prev != null) { Source.AddPlayer(prev); }
        }
    }
}
