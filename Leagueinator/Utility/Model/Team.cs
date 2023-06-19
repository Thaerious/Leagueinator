using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Utility.Model {
    public class Team {
        public readonly ImmutableList<Player> Players;

        public Team(IEnumerable<Player> players) {
            this.Players = players.ToImmutableList();
        }
    }
}
