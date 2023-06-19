using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Utility;

namespace Leagueinator.Utility.Model {
    public class LeagueEvent {
        public readonly string Date;
        public readonly ImmutableList<Player> players;
        public readonly ImmutableList<Round> rounds;

        public LeagueEvent(string date, IEnumerable<Player> players) {
            this.Date = date;
            this.players = players.ToImmutableList();
        }
    }
}
