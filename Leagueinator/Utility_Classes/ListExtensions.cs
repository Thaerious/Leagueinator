using System.Collections.Generic;

namespace Leagueinator.Utility_Classes {
    public static class ListExtensions {

        public static List<T> AddUnique<T>(this List<T> list, T t) {
            if (t == null) return list;
            if (!list.Contains(t)) list.Add(t);
            return list;
        }

        public static List<T> AddUnique<T>(this List<T> list, IEnumerable<T> that) {
            foreach (T t in that) list.AddUnique(t);
            return list;
        }
    }
}
