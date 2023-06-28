using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class MatchLabel : Label {
        public int Team { get; set; } = 0;
        public int Position { get; set; } = 0;
        public int Lane => (Parent as MatchCard).Lane;

        private PlayerInfo _playerInfo;
        public PlayerInfo PlayerInfo {
            get { return _playerInfo; }
            set {
                _playerInfo = value;
                if (value == null) Text = "";
                else Text = _playerInfo.Name;
            }
        }
    }
}
