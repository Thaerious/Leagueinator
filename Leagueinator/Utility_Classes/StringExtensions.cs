using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Leagueinator.Utility_Classes {
    public static class StringExtensions {
        public static string DelString<T>(this IEnumerable<T> list, string del = ", ") {
            return string.Join(del, list.Select(t => t?.ToString()).ToArray());
        }

        public static string DelString<T>(this IEnumerable<T> list, int colsize, string del = ", ") {
            var array = list.Select(t => t?.ToString())
                .Select(t => t.PadRight(colsize, ' '))
                .ToArray();
            return string.Join(del, array);
        }

        public static bool IsEmpty(this string str) {
            if (str == null) return true;
            if (str.Length == 0) return true;
            return false;
        }

        public static string GetHashCode(this object obj, string format) {
            if (obj == null) return null;
            return obj.GetHashCode().ToString(format);
        }
    }
}
