using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {

    public partial class MatchLabel {
        public event PlayerInfoEvent RenamePlayer;
        public event PlayerInfoEvent DeletePlayer;

        public void TriggerRenameEvent() {
            this.RenamePlayer?.Invoke(this, new PlayerInfoArgs {
                PlayerInfo = this.PlayerInfo
            });
        }

        public void TriggerDeleteEvent() {
            this.DeletePlayer?.Invoke(this, new PlayerInfoArgs {
                PlayerInfo = this.PlayerInfo
            });
        }
    }
}
