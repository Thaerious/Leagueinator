﻿using Leagueinator.Utility_Classes;
using System;
using System.Diagnostics;
namespace Leagueinator.Algorithms {
    public class GreedyWalk {
        private int generation = 0;
        private Random random = new Random();

        public int MaxGen = 100;

        public int Generation {
            get => this.generation;
        }

        public T Run<T>(T member, Action<T> cb = null) where T : ASolution {
            int bestScore = member.Evaluate();
            T current = (T)member.Clone();
            T best = current;

            cb?.Invoke(best);
            while (bestScore > 0 && this.generation++ < this.MaxGen) {
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
                cb?.Invoke(best);
            }

            return best;
        }

        public void Mutate(ASolution sol) {
            int r1 = 0, r2 = 0;

            while (r1 == r2) {
                r1 = random.Next(sol.Size);
                r2 = random.Next(sol.Size);
            }

            (sol[r1], sol[r2]) = (sol[r2], sol[r1]);
        }
    }
}
