using Newtonsoft.Json;

namespace Leagueinator.Model {
    public class Settings {
        public readonly int TeamSize;
        public readonly int LaneCount;

        public Settings(int teamSize, int laneCount) {
            this.TeamSize = teamSize;
            this.LaneCount = laneCount;
        }

        public static Settings FromJSON(string json) {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
