using System;
using System.Diagnostics;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class PlayersPanel : UserControl {
        public PlayersPanel() {
            InitializeComponent();
        }

        private void txtNameKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                var playerInfo = new PlayerInfo(this.txtName.Text);
                this.AddPlayer(playerInfo);
                this.txtName.Text = "";
            }
        }

        public void AddPlayer(PlayerInfo playerInfo) {
            try {
                this.listPlayers.Items.Add(playerInfo);
                txtPlayerName.Text = playerInfo.Name;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void onSelect(object sender, EventArgs e) {
            string selectedPlayer = listPlayers.SelectedItem as string;
            if (selectedPlayer == null) return;
            txtPlayerName.Text = selectedPlayer;
        }

        private void txtRenameKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.listPlayers.Items[this.listPlayers.SelectedIndex] = txtPlayerName.Text;
            }
        }

        private void clickDelete(object sender, EventArgs e) {
            if (listPlayers.SelectedIndex == -1) return;
            string selectedPlayer = listPlayers.SelectedItem as string;
            this.listPlayers.Items.Remove(selectedPlayer);
            txtPlayerName.Text = "";
            lblIndex.Text = "";
        }
    }
}
