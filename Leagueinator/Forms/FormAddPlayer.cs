using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Forms {
    public partial class FormAddPlayer : Form {
        public delegate void AddPlayer(PlayerInfo playerInfo, bool currentRoundOnly);
        public event AddPlayer OnAddPlayer;

        public bool CurrentRoundOnly => this.chkCurrentRound.Checked;

        public FormAddPlayer() {
            this.InitializeComponent();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) this.butOK.PerformClick();
            if (e.KeyCode == Keys.Enter) {
                if (this.txtName.Text == "") this.butOK.PerformClick();
                if (this.txtName.Text != null && this.txtName.Text.Trim() != "") {
                    OnAddPlayer(new PlayerInfo(this.txtName.Text), this.CurrentRoundOnly);
                }
                this.txtName.Text = null;
            }
        }

        private void ButOK_Click(object sender, System.EventArgs e) {
            if (OnAddPlayer != null) {
                if (this.txtName.Text != null && this.txtName.Text.Trim() != "") {
                    OnAddPlayer(new PlayerInfo(this.txtName.Text), this.CurrentRoundOnly);
                }
                this.txtName.Text = null;
            }
        }
    }
}
