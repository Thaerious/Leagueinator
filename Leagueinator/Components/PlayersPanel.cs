using System;
using System.Diagnostics;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class PlayerArgs {
        public PlayerInfo PlayerInfo { get; set; }
    }

    public partial class PlayersPanel : UserControl {
        public delegate void OnPlayerAdded(PlayersPanel source, PlayerArgs args);
        public event OnPlayerAdded PlayerAdded;

        public PlayersPanel() {
            InitializeComponent();
        }

        private void txtNameKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                var playerInfo = new PlayerInfo(this.txtName.Text);
                this.AddPlayer(playerInfo);
                this.txtName.Text = "";
                this.PlayerAdded?.Invoke(this, new PlayerArgs { PlayerInfo = playerInfo });
            }
        }

        public void AddPlayer(PlayerInfo playerInfo) {
            try {
                if (this.listPlayers.Items.Contains(playerInfo)) return;
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
