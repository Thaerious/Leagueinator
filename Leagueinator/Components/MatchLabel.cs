using System.ComponentModel;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class MatchLabel : Label, IModelPlayer {
        [Category("Misc"), Description("The team number for this label.")]
        public Team Team { get; set; }

        public int Position { get; set; } = 0;

        private PlayerInfo _playerInfo;
        public PlayerInfo PlayerInfo {
            get { return _playerInfo; }
            set {
                _playerInfo = value;
                this.Team[this.Position] = value;

                if (value == null) this.Text = "";
                else this.Text = _playerInfo.Name;
            }
        }

        public PlayerInfo AddPlayer(PlayerInfo playerInfo) {
            PlayerInfo prev = this.PlayerInfo;
            this.PlayerInfo = playerInfo;
            return prev;
        }

        public void ClearPlayer(PlayerInfo playerInfo) {
            if (this.PlayerInfo == playerInfo) this.PlayerInfo = null;
        }
    }

    public class MatchLabelArgs {
        public PlayerInfo PlayerInfo;
        public int Team;
        public int Position;
    }
}
