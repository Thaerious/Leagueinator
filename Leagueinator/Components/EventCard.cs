using System;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class EventCard : UserControl {
        private readonly LeagueEvent leagueEvent;
        public delegate void EventCardSelect(object sender, EventCardArgs args);
        public event EventCardSelect OnEventCardSelect;

        public EventCard(LeagueEvent leagueEvent) {
            InitializeComponent();
            this.leagueEvent = leagueEvent;
            this.lblDate.Text = leagueEvent.Date.ToString();
        }

        private void EventCard_DoubleClick(object sender, EventArgs e) {
            if (OnEventCardSelect == null) return;
            var args = new EventCardArgs(this.leagueEvent);
            OnEventCardSelect(this, args);
        }
    }

    public class EventCardArgs : EventArgs {
        public readonly LeagueEvent LeagueEvent;

        public EventCardArgs(LeagueEvent leagueEvent) {
            this.LeagueEvent = leagueEvent;
        }
    }
}
