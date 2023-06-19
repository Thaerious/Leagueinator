using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Components;
using Leagueinator.Model.LeagueEvents;

namespace Leagueinator.Utility {
    public class EventDBListener {
        public EventDBListener(EventDB db, EventsPanel eventsPanel) {
            eventsPanel.OnEventCardRemove += (card, data) => {
                db.RemoveEvent(data.LeagueEvent.SQLidx);
            };
        }
    }
}
