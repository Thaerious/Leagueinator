using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class FormAddEvent : Form {

        public Settings Settings {
            get {
                return new Settings {
                    TeamSize = (int)this.spinTeamSize.Value,
                    LaneCount = (int)this.spinLaneCount.Value,
                    MatchSize = 2,
                    Date = this.dateTimePicker.Text,
                    Name = this.txtName.Text
                };
            }
        }

        public string EventName {
            get => this.txtName.Text;
        }

        public string Date {
            get => this.dateTimePicker.Text;
        }

        public FormAddEvent() {
            this.InitializeComponent();
        }
    }
}
