using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leagueinator.Components;

namespace Leagueinator.Model {
    public class Round : HasDeepCopy<Round> {
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();
        public Dictionary<int, Match> Matches { get; private set; } = new Dictionary<int, Match>(); // Lane -> Match

        public Round() {}

        public Round(List<PlayerInfo> idlePlayers) {
            var copy = idlePlayers.DeepCopy();
            this.IdlePlayers = copy;
        }

        public Round DeepCopy() {
            var that = new Round() {
                Matches = this.Matches.DeepCopy(),
                IdlePlayers = this.IdlePlayers.DeepCopy()
            };

            return that;
        }

        public override string ToString() {
            var idle = string.Join(",", this.IdlePlayers.ConvertAll<string>(p => p.Name));

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            builder.AppendLine($"\tIdle: [{idle}]");
            builder.AppendLine($"\tMatches: [");

            foreach (int lane in this.Matches.Keys) {
                builder.AppendLine($"\t\t{lane} : {this.Matches[lane]}");
            }

            builder.AppendLine($"\t]");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }

    public interface IModelRound {
        Round Round { get; set; }
    }
}
