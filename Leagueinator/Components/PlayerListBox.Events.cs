using System;
using System.Drawing;
using System.Windows.Forms;
using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {
    public partial class PlayerListBox : ListBox {
        public event PlayerInfoEvent RenamePlayer;
        public event PlayerInfoEvent DeletePlayer;

        private void HndMouseDown(object sender, MouseEventArgs e) {
            switch (e.Button) {
                case MouseButtons.Right: {
                        if (this.PlayerInfo == null) return;
                        this.contextMenu.Show(this, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        private void HndMenuDelete(object sender, EventArgs e) {
            this.TriggerDeleteEvent();
            this.Items.Remove(this.SelectedItem);
        }

        private void HndMenuRename(object sender, EventArgs e) {
            this.TriggerRenameEvent();
        }

        public void TriggerRenameEvent() {
            this.RenamePlayer?.Invoke(this, new PlayerInfoArgs {
                PlayerInfo = (Model.PlayerInfo)this.SelectedItem
            });
        }

        public void TriggerDeleteEvent() {
            this.DeletePlayer?.Invoke(this, new PlayerInfoArgs {
                PlayerInfo = (Model.PlayerInfo)this.SelectedItem
            });
        }
    }
}
