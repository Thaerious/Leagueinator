using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Leagueinator.Forms {
    public partial class FormSettings : Form {

        public Settings Settings {
            get {
                return new Settings(
                    this.chkRegenerate.Checked,
                    (int)this.spinTeamSize.Value,
                    (int)this.spinLaneCount.Value
                );
            }
            set {
                this.chkRegenerate.Checked = value.Regenerate;
                this.spinTeamSize.Value = value.TeamSize;
                this.spinLaneCount.Value = value.LaneCount;
            }
        }

        public FormSettings() {
            InitializeComponent();
        }

    }

    public class Settings {
        public readonly bool Regenerate;
        public readonly int TeamSize;
        public readonly int LaneCount;

        public Settings(bool regenerate, int teamSize, int laneCount) {
            this.Regenerate = regenerate;
            this.TeamSize = teamSize;
            this.LaneCount = laneCount;
        }

        public static FormSettings FromJSON(string json) {
            return JsonConvert.DeserializeObject<FormSettings>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
