using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class SettingsPanel : UserControl {
        public Settings Settings { 
            get {
                return new Settings(
                    (int)this.spinTeamSize.Value,
                    (int)this.spinLaneCount.Value
                );
            }
            set {
                this.spinTeamSize.Value = value.TeamSize;
                this.spinLaneCount.Value = value.LaneCount;
            }
        }

        public SettingsPanel() {
            InitializeComponent();
        }
    }
}
