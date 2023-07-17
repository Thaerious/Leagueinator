using System;
using Newtonsoft.Json;

namespace Leagueinator.Model.Settings {

    public enum MATCH_TYPE {
        RoundRobin, Brackets, Ranked, Penache, None
    }

    [Serializable]
    public class Setting {
        public int TeamSize = 2;
        public int LaneCount = 8;
        public int MatchSize = 2;
        public int NumberOfEnds = 10;

        public MATCH_TYPE MatchType = MATCH_TYPE.RoundRobin;
        public string Date = DateTime.Now.ToShortDateString();
        public string Name = "N/A";

        public static Setting FromJSON(string json) {
            return JsonConvert.DeserializeObject<Setting>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
