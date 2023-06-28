using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Forms {
    public partial class FormAddPlayer : Form {
        public delegate void AddPlayer(PlayerInfo playerInfo);
        public event AddPlayer OnAddPlayer;

        public FormAddPlayer() {
            InitializeComponent();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                OnAddPlayer(new PlayerInfo(txtName.Text));
                txtName.Text = null;
            }
        }

        private void ButOK_Click(object sender, System.EventArgs e) {
            if (OnAddPlayer != null) {
                OnAddPlayer(new PlayerInfo(txtName.Text));
                txtName.Text = null;
            }
        }
    }
}
