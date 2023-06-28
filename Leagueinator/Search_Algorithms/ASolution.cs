namespace Leagueinator.Search_Algorithms {
    public abstract class ASolution {

        public abstract ASolution Clone();

        public abstract int Evaluate();

        public abstract bool IsValid();

        public abstract void Mutate();
    }
}
