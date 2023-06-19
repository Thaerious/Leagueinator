using System.Collections.Generic;
using System.Diagnostics;
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
    }

    public interface IModelRound {
        Round Round { get; set; }
    }
}
