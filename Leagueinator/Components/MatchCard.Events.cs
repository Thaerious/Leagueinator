using System.Linq;
using System.Windows.Forms;
using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl {
        public event PlayerInfoEvent RenamePlayer {
            add {
                foreach (var control in Controls.OfType<MatchLabel>()) {
                    control.RenamePlayer += value;
                }
            }
            remove {
                foreach (var control in Controls.OfType<MatchLabel>()) {
                    control.RenamePlayer -= value;
                }
            }
        }

        public event PlayerInfoEvent DeletePlayer {
            add {
                foreach (var control in Controls.OfType<MatchLabel>()) {
                    control.DeletePlayer += value;
                }
            }
            remove {
                foreach (var control in Controls.OfType<MatchLabel>()) {
                    control.DeletePlayer -= value;
                }
            }
        }
    }
}
