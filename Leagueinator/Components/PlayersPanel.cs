using System;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class PlayersPanel : UserControl {

        public PlayersPanel() {
            InitializeComponent();
        }

        private League _league;
        public League League {
            get {
                return _league;
            }
            set {
                this._league = value;
                this.listPlayers.Items.Clear();
                if (value == null) return;
                foreach (PlayerInfo player in value.SeekDeep<PlayerInfo>()) {
                    this.listPlayers.Items.Add(player);
                }
            }
        }

        private void onSelect(object sender, EventArgs e) {
            PlayerInfo selectedPlayer = listPlayers.SelectedItem as PlayerInfo;
            if (selectedPlayer == null) return;
            txtPlayerName.Text = selectedPlayer.Name;
        }

        private void clickDelete(object sender, EventArgs e) {
            if (listPlayers.SelectedIndex == -1) return;
            string selectedPlayer = listPlayers.SelectedItem as string;
            this.listPlayers.Items.Remove(selectedPlayer);
            txtPlayerName.Text = "";
        }

        internal void Clear() {
            this.listPlayers.Items.Clear();
        }

        private void ButRename_Click(object sender, EventArgs e) {
            PlayerInfo selectedPlayer = listPlayers.SelectedItem as PlayerInfo;
            if (selectedPlayer == null) return;

            foreach (var player in this.League.SeekDeep<PlayerInfo>()) {
                if (player.Name == txtPlayerName.Text) {
                    string msg = "Name already in use";
                    MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            PlayerInfo selected = this.listPlayers.SelectedItem as PlayerInfo;
            foreach (var lEvent in this.League.Events) {
                foreach (var p in lEvent.SeekDeep<PlayerInfo>()) {
                    if (p.Name == selected.Name) {
                        selected.Name = txtPlayerName.Text;
                    }
                }
            }

            listPlayers.Items.Remove(selectedPlayer);
            listPlayers.Items.Add(selectedPlayer);
        }

        public class PlayerArgs {
            public PlayerInfo PlayerInfo { get; set; }
        }
    }
}
