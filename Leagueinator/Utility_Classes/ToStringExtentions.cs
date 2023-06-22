using System.Collections.Generic;
using System.Linq;

namespace Leagueinator {
    public static class ToStringExtensions {
        public static string DelString<T>(this IEnumerable<T> list) {
            return string.Join(", ", list.Select(t => t?.ToString()).ToArray());
        }
    }
}
