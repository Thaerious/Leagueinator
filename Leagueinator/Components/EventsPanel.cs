﻿using System.Collections.Generic;
using System.Windows.Forms;
using Leagueinator.Model;
using static Leagueinator.Components.EventCard;

namespace Leagueinator.Components {
    public partial class EventsPanel : FlowLayoutPanel {
        public event EventCardSelect OnEventCardSelect;

        public EventsPanel() {
            this.InitializeComponent();
        }

        public void SetEvents(IEnumerable<LeagueEvent> list) {
            this.Controls.Clear();
            foreach (var lEvent in list) {
                this.AddEvent(lEvent);
            }
        }

        public void AddEvent(LeagueEvent lEvent) {
            var card = new EventCard(lEvent);
            this.Controls.Add(card);

            card.OnEventCardSelect += (s, e) => {
                OnEventCardSelect(this, e);
            };
        }
    }
}
