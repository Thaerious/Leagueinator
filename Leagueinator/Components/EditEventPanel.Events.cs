using System;
using System.Linq;
using Leagueinator.Forms;
using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {

    public partial class EditEventPanel {
        public event PlayerInfoEvent RenamePlayer {
            add {
                foreach (var control in this.panelMatchCard.Controls.OfType<MatchCard>()) {
                    control.RenamePlayer += value;
                }
                this.PlayerListBox.RenamePlayer += value;
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchCard>()) {
                    control.RenamePlayer -= value;
                }
                this.PlayerListBox.RenamePlayer -= value;
            }
        }

        public event PlayerInfoEvent DeletePlayer {
            add {
                foreach (var control in this.panelMatchCard.Controls.OfType<MatchCard>()) {
                    control.DeletePlayer += value;
                }
                this.PlayerListBox.DeletePlayer += value;
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchCard>()) {
                    control.DeletePlayer -= value;
                }
                this.PlayerListBox.DeletePlayer -= value;
            }
        }

        private void HndAddRound(object sender, EventArgs e) {
            this.AddRound(this.leagueEvent.NewRound());
            IsSaved.Singleton.Value = false;
        }

        private void HndRemoveRound(object sender, EventArgs e) {
            if (this.currentRoundButton != null) {
                this.flowRounds.Controls.Remove(this.currentRoundButton);
                this.currentRoundButton = null;
                IsSaved.Singleton.Value = false;
            }
        }
    }
}
