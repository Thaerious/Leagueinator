using System.Windows.Forms;

namespace Leagueinator.Forms {
    public partial class FormAddPlayer : Form {

        public string PlayerName {
            get {
                return this.txtName.Text;
            }
        }
        public FormAddPlayer() {
            InitializeComponent();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.butOK.PerformClick();
            }
        }
    }
}
