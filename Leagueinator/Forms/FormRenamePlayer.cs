using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Forms {
    public partial class FormRenamePlayer : Form {

        public string PlayerName => this.txtName.Text;

        public FormRenamePlayer() {
            InitializeComponent();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.butOK.PerformClick();
            }
        }
    }
}
