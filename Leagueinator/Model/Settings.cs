using Newtonsoft.Json;

namespace Leagueinator.Model {
    public class Settings {
        public int TeamSize;
        public int LaneCount;
        public int MatchSize;
        public string Date;
        public string Name; 

        public static Settings FromJSON(string json) {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
