using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Model {
    public class LeagueEvent {
        public readonly int Index;
        public readonly string Date;

        public LeagueEvent(int index, string date) {
            this.Date = date;
            this.Index = index;
        }
    }
}
