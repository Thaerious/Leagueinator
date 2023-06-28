using System;
using System.Collections.Generic;

namespace Leagueinator.Utility_Classes {
    public static class CollectionExtensions {

        public static List<T> AddUnique<T>(this List<T> list, T t) {
            if (t == null) return list;
            if (!list.Contains(t)) list.Add(t);
            return list;
        }

        public static List<T> AddUnique<T>(this List<T> list, IEnumerable<T> that) {
            foreach (T t in that) list.AddUnique(t);
            return list;
        }

        public static List<T> Unique<T>(this IEnumerable<T> list) {
            List<T> newList = new List<T>();
            foreach (T t in list) newList.AddUnique(t);
            return newList;
        }

        public static List<T> NotNull<T>(this IEnumerable<T> list) {
            List<T> newList = new List<T>();
            foreach (T t in list) if (t != null) newList.Add(t);
            return newList;
        }

        public static T[] Populate<T>(this T[] array, Func<T> provider) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = provider();
            }
            return array;
        }

        public static T[] Fill<T>(this T[] array, T value) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = value;
            }
            return array;
        }
    }
}
