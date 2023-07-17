using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using MatchPrinter;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        IEnumerator<bool> printEnumerator;

        private void HndRenamePlayer(object source, PlayerInfoArgs args) {
            var form = new FormRenamePlayer {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            var result = form.ShowDialog();
            if (result == DialogResult.Cancel) return;

            foreach (var player in this.League.SeekDeep<PlayerInfo>()) {
                if (player.Name == form.PlayerName) {
                    string msg = "Name already in use";
                    MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string previous = args.PlayerInfo.Name;
            foreach (var player in this.League.SeekDeep<PlayerInfo>()) {
                if (player.Name == previous) {
                    player.Name = form.PlayerName;
                }
            }

            this.editEventPanel.RefreshRound();
        }

        private void HndDeletePlayer(object source, PlayerInfoArgs args) {
            if (source is MatchLabel label) {
                this.editEventPanel.CurrentRound[label.Lane][label.Team][label.Position] = null;
            }
            if (source is PlayerListBox list) {
                this.editEventPanel.CurrentRound.IdlePlayers.Remove(args.PlayerInfo);
            }
        }
    }
}
