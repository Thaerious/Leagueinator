﻿using System.Collections.Generic;
using System.Linq;

namespace Leagueinator.Utility_Classes {
    public static class StringExtensions {
        public static string DelString<T>(this IEnumerable<T> list, string del = ", ") {
            return string.Join(del, list.Select(t => t?.ToString()).ToArray());
        }

        public static bool IsEmpty(this string str) {
            if (str == null) return true;
            if (str.Length == 0) return true;
            return false;
        }
    }
}