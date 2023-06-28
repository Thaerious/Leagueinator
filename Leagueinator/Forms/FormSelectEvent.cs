using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Forms {
    public partial class FormSelectEvent : Form {
        public string Action = "";
        public LeagueEvent LeagueEvent = null;

        public FormSelectEvent() {
            InitializeComponent();
        }

        public void SetEvents(IEnumerable<LeagueEvent> events) {
            listEvents.Items.Clear();
            listEvents.Items.AddRange(
                events.Select(e => new LeagueEventWrapper { LeagueEvent = e }).ToArray()
            );
        }

        private void clickSelect(object sender, EventArgs e) {
            Action = "Select";
            LeagueEvent = (listEvents.SelectedItem as LeagueEventWrapper).LeagueEvent;
        }

        private void clickDelete(object sender, EventArgs e) {
            Action = "Delete";
            LeagueEvent = (listEvents.SelectedItem as LeagueEventWrapper).LeagueEvent;
        }
    }

    class LeagueEventWrapper {
        public LeagueEvent LeagueEvent;
        public override string ToString() {
            return LeagueEvent.Name + " " + LeagueEvent.Date;
        }
    }
}
