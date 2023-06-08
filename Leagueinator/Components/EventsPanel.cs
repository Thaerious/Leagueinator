﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
