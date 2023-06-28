using System.Collections.Generic;
using System.Windows.Forms;
using Leagueinator.Model;
using static Leagueinator.Components.EventCard;

namespace Leagueinator.Components {
    public partial class EventsPanel : FlowLayoutPanel {
        public event EventCardSelect OnEventCardSelect;

        public EventsPanel() {
            InitializeComponent();
        }

        public void SetEvents(IEnumerable<LeagueEvent> list) {
            Controls.Clear();
            foreach (var lEvent in list) {
                AddEvent(lEvent);
            }
        }

        public void AddEvent(LeagueEvent lEvent) {
            var card = new EventCard(lEvent);
            Controls.Add(card);

            card.OnEventCardSelect += (s, e) => {
                OnEventCardSelect(this, e);
            };
        }
    }
}
