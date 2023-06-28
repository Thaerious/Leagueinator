using System;
using System.Diagnostics;
namespace Leagueinator.Search_Algorithms {
    public class GreedyWalk {
        private int generation = 0;

        public int MaxGen = 100;

        public int Generation {
            get => generation;
        }

        public T Run<T>(T member, Action<T> func = null) where T : ASolution
        {
            int bestScore = member.Evaluate();
            T current = (T)member.Clone();
            T best = member;
            
            Debug.WriteLine($"Starting value {bestScore}");            

            func?.Invoke(current);
            while (bestScore > 0 && generation++ < MaxGen) {
                current = (T)current.Clone();
                current.Mutate();
                int eval = current.Evaluate();
                if (eval <= bestScore) {
                    bestScore = eval;
                    best = (T)current.Clone();
                }
                else {
                    current = best;
                }
                func?.Invoke(current);
            }

            Debug.WriteLine($"Final value {bestScore}");
            return best;
        }

    }
}
