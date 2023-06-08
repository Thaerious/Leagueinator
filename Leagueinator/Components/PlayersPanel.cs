using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.utility_classes;

namespace Leagueinator.Components {
    public partial class PlayersPanel : UserControl {
        private DBManager dbManager;

        public DBManager DBManager {
            get { return this.dbManager; }
            set {
                this.dbManager = value;
                this.listPlayers.Items.Clear();
                if (this.dbManager == null) return;

                foreach(var playerInfo in this.dbManager.GetPlayers()) {
                    this.listPlayers.Items.Add(playerInfo);
                }
            }
        }

        public PlayersPanel() {
            InitializeComponent();
        }

        private void txtNameKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.addPlayer(this.txtName.Text);
                this.txtName.Text = "";
            }
        }

        private void addPlayer(string name) {
            try {
                var playerinfo = this.dbManager.AddName(name);
                var index = this.listPlayers.Items.Add(playerinfo);
                txtPlayerName.Text = playerinfo.Name;
                lblIndex.Text = playerinfo.SQLIndex.ToString();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void onSelect(object sender, EventArgs e) {
            PlayerInfo selectedPlayer = listPlayers.SelectedItem as PlayerInfo;
            if (selectedPlayer == null) return;

            txtPlayerName.Text = selectedPlayer.Name;
            lblIndex.Text = selectedPlayer.SQLIndex.ToString();
        }

        private void txtRenameKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PlayerInfo selectedPlayer = listPlayers.SelectedItem as PlayerInfo;
                selectedPlayer.Name = txtPlayerName.Text;
                this.listPlayers.Items[this.listPlayers.SelectedIndex] = selectedPlayer;
                this.dbManager.UpdateName(selectedPlayer.SQLIndex, txtPlayerName.Text);
            }
        }

        private void clickDelete(object sender, EventArgs e) {
            if (listPlayers.SelectedIndex == -1) return;
            PlayerInfo selectedPlayer = listPlayers.SelectedItem as PlayerInfo;
            this.dbManager.RemovePlayer(selectedPlayer.SQLIndex);
            this.listPlayers.Items.Remove(selectedPlayer);
            txtPlayerName.Text = "";
            lblIndex.Text = "";
        }
    }
}
