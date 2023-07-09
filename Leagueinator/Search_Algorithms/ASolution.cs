using System;
using System.Collections;
using System.Collections.Generic;

namespace Leagueinator.Search_Algorithms {

    public abstract class ASolution : IEnumerable<int> {
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

        public IEnumerator<int> GetEnumerator() {
            int index = 0;
            while (index < this.Size) {
                yield return this[index++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            int index = 0;
            while (index < this.Size) {
                yield return this[index++];
            }
        }

        private readonly int[] values;
    }
}
