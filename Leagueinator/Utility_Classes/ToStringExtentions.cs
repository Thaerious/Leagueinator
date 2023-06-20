using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model;

namespace Leagueinator {
    public static class ToStringExtensions {
        public static string DelString<T>(this IEnumerable<T> list) {
            return string.Join(", ", list.Select(t => t?.ToString()).ToArray());
        }
    }
}
