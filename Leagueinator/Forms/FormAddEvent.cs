using System.Windows.Forms;
using Leagueinator.Model.Settings;

namespace Leagueinator.Components {
    public partial class FormAddEvent : Form {

        public Setting Settings {
            get {
                var setting = new Setting {
                    TeamSize = (int)this.spinTeamSize.Value,
                    LaneCount = (int)this.spinLaneCount.Value,
                    MatchSize = 2,
                    Date = this.dateTimePicker.Text,
                    Name = this.txtName.Text
                };

                if (radRoundRobin.Checked) setting.MatchType = MATCH_TYPE.RoundRobin;
                else if  (radBracket.Checked) setting.MatchType = MATCH_TYPE.Brackets;
                else if (radRanked.Checked) setting.MatchType = MATCH_TYPE.Ranked;
                else if (radPenache.Checked) setting.MatchType = MATCH_TYPE.Penache;
                else setting.MatchType = MATCH_TYPE.None;

                return setting;
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
