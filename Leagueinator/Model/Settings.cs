using Newtonsoft.Json;

namespace Leagueinator.Model {
    public class Settings {
        public readonly int TeamSize;
        public readonly int LaneCount;
        public readonly int MatchSize;

        public Settings(int teamSize = 2, int laneCount = 8, int matchSize = 2) {
            this.TeamSize = teamSize;
            this.LaneCount = laneCount;
            this.MatchSize = matchSize;
        }

        public static Settings FromJSON(string json) {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public string ToJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
