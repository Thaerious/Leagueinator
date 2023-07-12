using System;
using System.Collections.Generic;

namespace Leagueinator.Utility_Classes {
    static class RandomExtensions {
        static Random rng = new Random();

        public static T SelectRandom<T>(this List<T> list) {
            int r = rng.Next(list.Count);
            return list[r];
        }

        public static T RemoveRandom<T>(this List<T> list) {
            int r = rng.Next(list.Count);
            T t =  list[r];
            list.Remove(t);
            return t;
        }

        public static void Shuffle<T>(this Random rng, T[] array) {
            int n = array.Length;
            while (n > 1) {
                int k = rng.Next(n--);
                (array[k], array[n]) = (array[n], array[k]);
            }
        }

        public static T RemoveFrom<T>(this Random rng, List<T> list) {
            if (list.Count == 0) return default(T);
            var r = rng.Next(list.Count);
            var team = list[r];
            list.RemoveAt(r);
            return team;
        }
    }
}
