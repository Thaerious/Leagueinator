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

            set {
                this.txtName.Text = value.Name;
                this.dateTimePicker.Text = value.Date;
                this.spinTeamSize.Value = value.TeamSize;
                this.spinLaneCount.Value = value.LaneCount;

                switch (value.MatchType) {
                    case MATCH_TYPE.RoundRobin:
                        radRoundRobin.Checked = true;
                        break;
                        case MATCH_TYPE.Brackets:
                        radBracket.Checked = true;
                        break;
                        case MATCH_TYPE.Ranked:
                        radRanked.Checked = true;
                        break;
                        case MATCH_TYPE.Penache:
                        radPenache.Checked = true;
                        break;
                        default:
                        radNone.Checked = true;
                        break;
                }
            }
        }

        public string EventName {
            get => this.txtName.Text;
        }

        public string Date {
            get => this.dateTimePicker.Text;
        }

        private bool _rassign = false;
        public bool Reassign {
            get => _rassign;
            set {
                _rassign = value;
                if (value) {
                    this.spinTeamSize.Enabled = false;
                    this.spinLaneCount.Enabled = false;
                    if (Settings.TeamSize != 2) this.radPenache.Enabled = false;
                }
                else {
                    this.spinTeamSize.Enabled = true;
                    this.spinLaneCount.Enabled = true;
                }
            }
        }

        public FormAddEvent() {
            this.InitializeComponent();
        }

        private void radPenache_CheckedChanged(object sender, System.EventArgs e) {
            if (radPenache.Checked) {
                this.spinTeamSize.Value = 2;
                this.spinTeamSize.Enabled = false;
            }
            else {
                if (!_rassign) this.spinTeamSize.Enabled = true;
            }
        }
    }
}
