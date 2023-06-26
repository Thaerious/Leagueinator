using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Search_Algorithms {
    public abstract class AMember<T> {

        public abstract T Value { get; }

        public abstract AMember<T> Clone();

        public abstract int Evaluate();

        public abstract bool IsValid();

        public abstract void Mutate();
    }
}
