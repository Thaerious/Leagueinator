﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator {
    static class RandomExtensions {
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
