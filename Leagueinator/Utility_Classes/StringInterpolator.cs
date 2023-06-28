using System.Collections.Generic;

namespace Leagueinator.Utility_Classes {
    public class StringInterpolator : Dictionary<string, string> {

        public string Interpolate(string input) {
            string content = string.Copy(input);

            foreach (string key in Keys) {
                content = content.Replace("${" + key + "}", this[key]);
            }

            return content;
        }
    }
}
