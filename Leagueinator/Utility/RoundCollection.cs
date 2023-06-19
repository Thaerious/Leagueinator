using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leagueinator.Utility {
    public class RoundCollection {
        private readonly Dictionary<int, Round> rounds = new Dictionary<int, Round>();
        private HasPlayerInfo playerInfoSource;
        public int Round = 0;        
        public List<Round> Rounds => new List<Round>(this.rounds.Values.ToList());

        public RoundCollection(HasPlayerInfo source, int numRounds) {
            Debug.WriteLine("RoundCollection Constructor");
            this.playerInfoSource = source;

            PlayerInfoMap current = playerInfoSource.GetPlayerInfo();            
            for(int i = 0; i < numRounds; i++) {
                Round round = this.NewRound(current);
                current = round.GetPlayerInfo();
                rounds[i] = round;

                Debug.WriteLine($"Round[{i}].LaneWeight = {rounds[i].LaneWeight}");
            }
        }

        private Round NewRound(PlayerInfoMap source) {
            Round best = new Round(source);

            for (int i = 0; i < 100; i++) {
                Debug.WriteLine($"Best Weight = {best.LaneWeight}");
                if (best.LaneWeight == 0) return best;
                Round next = new Round(source);
                if (next.LaneWeight < best.LaneWeight) best = next;
            }

            return best;
        }

        public Round CurrentRound() {
            if (Round == 0) return null;
            return rounds[Round - 1];
        }
    }
}
