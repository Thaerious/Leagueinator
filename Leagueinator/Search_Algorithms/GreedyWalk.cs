using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model.Search_Algorithms;
using Leagueinator.Model;
namespace Leagueinator.Search_Algorithms {
    public class GreedyWalk {
        private int generation = 0;
        public int Generation {
            get => generation;
        }

        public AMember<T> Run<T>(AMember<T> member) {
            int bestScore = member.Evaluate();
            AMember<T> best = member;

            Debug.WriteLine($"Starting value {bestScore}");

            AMember<T> current = member;

            while (bestScore > 0 && generation++ < 100) {
                member.Mutate();
                current = current.Clone();
                current.Mutate();
                int eval = current.Evaluate();
                if (eval < bestScore) {
                    bestScore = eval;
                    best = current.Clone();
                }
            }

            Debug.WriteLine($"Final value {bestScore}");
            return best;
        }

    }
}
