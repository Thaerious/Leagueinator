using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.utility_classes {
    public class StringInterpolator : Dictionary<string, string>{

        public string Interpolate(string input) {
            string content = string.Copy(input);

            foreach (string key in this.Keys) {
                content = content.Replace("${" + key + "}", this[key]);
            }

            return content;
        }
    }
}
