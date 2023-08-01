using System;
using System.Diagnostics;
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
            var round = this.leagueEvent.NewRound();
            if (round != this.leagueEvent[0]) {
                round = this.SetupRound(round);
            }

            this.AddRound(round);
            this.RefreshRound();
            IsSaved.Singleton.Value = false;
        }

        private void HndRemoveRound(object sender, EventArgs e) {
            if (this.currentRoundButton == null) return;
            this.panelMatchCard.Visible = false;
            this.playerListBox.Items.Clear();
            this.LeagueEvent.RemoveRound(this.CurrentRound);
            this.flowRounds.Controls.Remove(this.currentRoundButton);
            this.currentRoundButton = null;
            IsSaved.Singleton.Value = false;
        }

        /// <summary>
        /// Triggered when a player updates a match card score.
        /// </summary>
        /// <param name="laneIndex"></param>
        /// <param name="teamIndex"></param>
        /// <param name="value"></param>
        private void HndScoreUpdate(int laneIndex, int teamIndex, int value) {
            this.CurrentRound[laneIndex][teamIndex].Score = value;
        }
    }
}
