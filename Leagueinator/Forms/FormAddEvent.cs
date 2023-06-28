using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class FormAddEvent : Form {

        public Settings Settings {
            get {
                return new Settings {
                    TeamSize = (int)spinTeamSize.Value,
                    LaneCount = (int)spinLaneCount.Value,
                    MatchSize = 2,
                    Date = dateTimePicker.Text,
                    Name = txtName.Text
                };
            }
        }

        public string EventName {
            get => txtName.Text;
        }

        public string Date {
            get => dateTimePicker.Text;
        }

        public FormAddEvent() {
            InitializeComponent();
        }
    }
}
