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
using Newtonsoft.Json;

namespace Leagueinator.Forms {
    public partial class FormSettings : Form {

        public Settings Settings {
            get {
                return new Settings();
            }
            set {
                this.spinTeamSize.Value = value.TeamSize;
                this.spinLaneCount.Value = value.LaneCount;
            }
        }

        public FormSettings() {
            InitializeComponent();
        }

    }
}
