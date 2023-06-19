using System.Collections.Generic;

namespace Leagueinator.Model {
    public class Match : HasDeepCopy<Match>{
        public Dictionary<int, Team> Teams { get; private set; } = new Dictionary<int, Team>();

        public void SetPlayer(int team, int pos) {
            if (Teams[team] == null) Teams[team] = new Team();

        }

        public Match DeepCopy() {
            return new Match() {
                Teams = this.Teams.DeepCopy()
            };
        }

        public List<PlayerInfo> Players() {
            var list = new List<PlayerInfo>();
            foreach (Team team in this.Teams.Values) {
                list.AddRange(team.Players.Values);
            }
            return list;
        }
    }

    public interface IModelMatch {
        Match Match { get; set; }
    }
}
