using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Utility {
    public class StringInterpolator {
        public string Content {
            get;
            private set;
        }

        public StringInterpolator(string input, Dictionary<string, string> dictionary) {
            this.Content = input;

            foreach (string key in dictionary.Keys) {
                this.Content = this.Content.Replace("${" + key + "}", dictionary[key]);
            }
        }

        public override string ToString() {
            return this.Content;
        }
    }
}
