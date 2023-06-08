using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Leagueinator.utility_classes;

namespace Leagueinator {
    public class Team {
        private List<PlayerInfo> players;
        public List<PlayerInfo> Players => new List<PlayerInfo>(players);

        public string Player1 => players[0].Name;
        public string Player2 => players[1].Name;

        public Team(List<PlayerInfo> players) {
            this.players = new List<PlayerInfo>();

            foreach (var pinfo in players) {
                var newPinfo = new PlayerInfo(pinfo);
                this.players.Add(newPinfo);
            }
        }

        public override string ToString() {
            return $"{this.Player1}, {this.Player2}";
        }

        public int PlayerWeight() {
            int weight = 0;

            foreach (string name in this.players[0].PreviousPartners) {
                if (name == this.players[1].Name) weight++;
            }

            return weight;
        }
    }
}
