using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public FormAddEvent() {
            InitializeComponent();
        }
    }
}
