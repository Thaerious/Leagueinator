using System.Collections.Generic;

namespace Leagueinator.utility_classes {
    public class StringInterpolator : Dictionary<string, string> {

        public string Interpolate(string input) {
            string content = string.Copy(input);

            foreach (string key in this.Keys) {
                content = content.Replace("${" + key + "}", this[key]);
            }

            return content;
        }
    }
}
