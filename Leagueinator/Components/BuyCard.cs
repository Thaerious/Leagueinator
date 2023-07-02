using System.Windows.Forms;

namespace Leagueinator {
    public partial class BuyCard : UserControl {
        public BuyCard(string name) {
            this.InitializeComponent();
            this.labelName.Text = name;
        }
    }
}
