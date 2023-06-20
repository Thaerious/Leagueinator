using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leagueinator.Components;

namespace Leagueinator.Model {
    [Serializable]
    public class Round {
        public List<PlayerInfo> IdlePlayers { get; private set; } = new List<PlayerInfo>();
        public readonly Match[] Matches;

        public Round(Settings settings) {
            this.Matches = new Match[settings.LaneCount];
            for (int i = 0; i < this.Matches.Length; i++) {
                Matches[i] = new Match(settings);
            }
        }

        public Round(List<PlayerInfo> idlePlayers, Settings settings) : this(settings) {
            var copy = idlePlayers.DeepCopy();
            this.IdlePlayers = copy;
        }

        public override string ToString() {
            var idle = string.Join(",", this.IdlePlayers.ConvertAll<string>(p => p.Name));

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            builder.AppendLine($"\tIdle: [{idle}]");
            builder.AppendLine($"\tMatches: [");

            for (int i = 0; i < this.Matches.Length; i++) {
                builder.AppendLine($"\t\t{i} : {this.Matches[i]}");
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
