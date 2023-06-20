using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leagueinator.Model {
    public class Match {
        public readonly Team[] Teams;

        public Match(Settings settings) {
            this.Teams = new Team[settings.MatchSize];
            for(int i = 0; i < this.Teams.Length; i++) {
                this.Teams[i] = new Team(settings);
            }
        }


        public List<PlayerInfo> Players() {
            var list = new List<PlayerInfo>();
            foreach (Team team in this.Teams) {
                if (team != null) list.AddRange(team.Players);
            }
            return list;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (Team team in this.Teams) {
                sb.Append($"[{team.Players.DelString()}]");
            }
            return sb.ToString();
        }
    }

    public interface IModelMatch {
        Match Match { get; set; }
    }
}
