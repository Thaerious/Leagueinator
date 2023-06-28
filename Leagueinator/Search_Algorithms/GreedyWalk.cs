using System.Diagnostics;
namespace Leagueinator.Search_Algorithms {
    public class GreedyWalk {
        private int generation = 0;

        public int MaxGen = 100;

        public int Generation {
            get => generation;
        }

        public AMember<T> Run<T>(AMember<T> member) {
            int bestScore = member.Evaluate();
            AMember<T> best = member;

            Debug.WriteLine($"Starting value {bestScore}");

            AMember<T> current = member;

            while (bestScore > 0 && generation++ < MaxGen) {
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
