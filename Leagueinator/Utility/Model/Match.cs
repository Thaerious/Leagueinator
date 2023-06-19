using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Utility.Model {
    public class Match {
        public readonly ImmutableList<Team> Teams;
        public readonly int Lane;
        
        public Match(IEnumerable<Team> teams, int lane) {
            this.Teams = teams.ToImmutableList();
            this.Lane = lane;
        }
    }
}
