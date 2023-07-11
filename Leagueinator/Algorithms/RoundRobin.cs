using Leagueinator.Model;
using System.Diagnostics;

namespace Leagueinator.Algorithms {
    public class RoundRobin {
        private readonly Round Reference;

        public RoundRobin(Round round) {
            this.Reference = round;
        }

        public Round Value(int count) {
            Team[] teams = BuildArray();
            if (teams.Length == 0) return new Round(this.Reference.Settings);
            Shift(teams, count);
            return AssignTeams(teams);
        }

        private Team[] BuildArray() {
            Team[] teamsBefore = this.Reference.Teams.ToArray();
            Team[] teams = new Team[teamsBefore.Length];

            int i = 0;
            int j = teams.Length - 1;
            int idx = 0;
            while (idx < teamsBefore.Length) {
                teams[i++] = teamsBefore[idx++];
                if (idx >= teamsBefore.Length) break;
                teams[j--] = teamsBefore[idx++];
            }
            return teams;
        }

        private Team[] Shift(Team[] teams, int count) {
            while (count-- > 0) {
                Team temp = teams[1];
                for (int i = 1; i < teams.Length - 1; i++) {
                    teams[i] = teams[i + 1];
                }
                teams[teams.Length - 1] = temp;
            }
            return teams;
        }

        private Round AssignTeams(Team[] teams) {
            Round round = new Round(this.Reference.Settings);

            int i = 0;
            int j = teams.Length - 1;
            int lane = 0;
            while(i < j) { 
                Debug.WriteLine($"round[{lane}][0] = teams[{i}]");
                Debug.WriteLine($"round[{lane}][1] = teams[{j}]");
                round[lane][0] = teams[i++];
                round[lane][1] = teams[j--];
                lane++;
            }

            return round;
        }
    }
}
