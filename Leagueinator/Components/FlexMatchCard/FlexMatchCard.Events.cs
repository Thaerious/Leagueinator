using System.Linq;
using System.Windows.Forms;
using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {
    public partial class FlexMatchCard : UserControl {
        public event PlayerInfoEvent RenamePlayer {
            add {
                foreach (var control in this.Controls.OfType<MatchLabel>()) {
                    control.RenamePlayer += value;
                }
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchLabel>()) {
                    control.RenamePlayer -= value;
                }
            }
        }

        public event PlayerInfoEvent DeletePlayer {
            add {
                foreach (var control in this.Controls.OfType<MatchLabel>()) {
                    control.DeletePlayer += value;
                }
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchLabel>()) {
                    control.DeletePlayer -= value;
                }
            }
        }
    }
}
