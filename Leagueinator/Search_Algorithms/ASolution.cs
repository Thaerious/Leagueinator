using System;
using System.Collections;
using System.Collections.Generic;

namespace Leagueinator.Search_Algorithms {

    public class Allele {
        public int Index;
        public int Value;

        public override string ToString() => $"[{Index}, {Value}]";
    }

    public abstract class ASolution : IEnumerable<Allele> {
        public int this[int i] {
            get => this.values[i];
            set => this.values[i] = value;
        }

        public ASolution(int size) {
            this.values = new int[size];
        }

        public int Size => this.values.Length;

        public abstract ASolution Clone();

        public abstract int Evaluate();

        public abstract bool IsValid();

        public abstract void Mutate();

        public IEnumerator<Allele> GetEnumerator() {
            int index = 0;
            while (index < this.Size) {
                yield return new Allele {
                    Index = index,
                    Value = this[index]
                };
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            int index = 0;
            while (index < this.Size) {
                yield return new Allele {
                    Index = index++,
                    Value = this[index]
                };
            }
        }

        private readonly int[] values;
    }
}
