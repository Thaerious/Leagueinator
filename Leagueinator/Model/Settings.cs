using System;
using Newtonsoft.Json;

namespace Leagueinator.Model {
    [Serializable]
    public class Settings {
        public int TeamSize = 2;
        public int LaneCount = 8;
        public int MatchSize = 2;
        public string Date = DateTime.Now.ToShortDateString();
        public string Name = "N/A";

        public static Settings FromJSON(string json) {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
