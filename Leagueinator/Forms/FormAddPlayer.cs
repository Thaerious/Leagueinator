using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Forms {
    public partial class FormAddPlayer : Form {
        public delegate void AddPlayer(PlayerInfo playerInfo, bool currentRoundOnly);
        public event AddPlayer OnAddPlayer;

        public bool CurrentRoundOnly => this.chkCurrentRound.Checked;

        public FormAddPlayer() {
            InitializeComponent();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (txtName.Text != null && txtName.Text.Trim() != "") {
                    OnAddPlayer(new PlayerInfo(txtName.Text), this.CurrentRoundOnly);
                }
                txtName.Text = null;
            }
        }

        private void ButOK_Click(object sender, System.EventArgs e) {
            if (OnAddPlayer != null) {
                if (txtName.Text != null && txtName.Text.Trim() != "") {
                    OnAddPlayer(new PlayerInfo(txtName.Text), this.CurrentRoundOnly);
                }
                txtName.Text = null;
            }
        }
    }
}
