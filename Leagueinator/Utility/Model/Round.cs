using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model.LeagueEvents;

namespace Leagueinator.Utility.Model {
    public class Round {
        public readonly ImmutableList<Player> Buys;
        public readonly ImmutableList<Match> Matches;

        public Round(IEnumerable<Match> matches, IEnumerable<Player> buys) {
            this.Matches = matches.ToImmutableList();
            this.Buys = buys.ToImmutableList();
        }
    }
}
