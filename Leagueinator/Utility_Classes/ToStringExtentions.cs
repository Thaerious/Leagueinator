using System.Collections.Generic;
using System.Linq;

namespace Leagueinator.Utility_Classes {
    public static class ToStringExtensions {
        public static string DelString<T>(this IEnumerable<T> list, string del = ", ") {
            return string.Join(del, list.Select(t => t?.ToString()).ToArray());
        }
    }
}
