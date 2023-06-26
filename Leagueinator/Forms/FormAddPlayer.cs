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
                OnAddPlayer(new PlayerInfo(this.txtName.Text));
                this.txtName.Text = null;
            }
        }

        private void ButOk_Click() {
            if (this.OnAddPlayer != null) {
                OnAddPlayer(new PlayerInfo(this.txtName.Text));
                this.txtName.Text = null;
            }
        }
    }
}
