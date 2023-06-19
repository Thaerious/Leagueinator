using System.Collections.Generic;
using Leagueinator.Model;

namespace Leagueinator {
    public interface HasDeepCopy <T> {
        T DeepCopy ();
    }

    public static class DeepCopyExtension {
        public static List<T> DeepCopy<T>(this List<T> that) where T : HasDeepCopy<T> {
            List<T> list = new List<T>();
            that.ForEach(x => list.Add(x.DeepCopy()));
            return list;
        }

        public static Dictionary<K,V> DeepCopy<K,V>(this Dictionary<K,V> that) where V : HasDeepCopy<V> {
            Dictionary<K,V> map = new Dictionary<K,V>();
            foreach(K key in that.Keys) {
                map[key] = that[key].DeepCopy();
            }
            return map;
        }

        public static AutoMap<K, V> DeepCopy<K, V>(this AutoMap<K, V> that) where V : HasDeepCopy<V>, new() {
            AutoMap<K, V> map = new AutoMap<K, V>();
            foreach (K key in that.Keys) {
                map[key] = that[key].DeepCopy();
            }
            return map;
        }

        public static List<T> ShallowCopy<T>(this List<T> that) {
            List<T> list = new List<T>();
            list.AddRange(that);
            return list;
        }
    }
}
