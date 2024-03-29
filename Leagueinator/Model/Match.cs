﻿using System;
using System.Collections.Generic;
using System.Linq;
using Leagueinator.Utility_Classes;
using Leagueinator.Model.Settings;

namespace Leagueinator.Model {
    [Serializable]
    public class Match : HasDeepCopy<Match>{
        public readonly Setting Settings;
        
        private Team[] _teams;

        public Team this[int key] {
            get => this._teams[key];
            set => this._teams[key] = value;
        }

        [Model] public List<Team> Teams => new List<Team>().AddUnique(this._teams);

        public List<PlayerInfo> Players => this.SeekDeep<PlayerInfo>().Unique();

        /// <summary>
        /// The maximum number of teams this match can have.
        /// </summary>
        public int MaxSize => this._teams.Length;

        /// <summary>
        /// Count the number of teams that have more than 0 players.
        /// </summary>
        public int Count => this._teams.Where(e => e != null).Count();

        public Match(Setting settings) {
            this.Settings = settings;
            this._teams = new Team[settings.MatchSize].Populate(() => new Team(settings));
        }

        public XMLStringBuilder ToXML(int lane) {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Match", $"lane='{lane}'", $"hash='{this.GetHashCode().ToString("X")}'");
            foreach (var team in this.Teams) {
                xsb.AppendXML(team.ToXML());
            }
            xsb.CloseTag();
            return xsb;
        }

        public override String ToString() {
            return this.ToXML(0).ToString();
        }

        public void ClearPlayers() {
            for (int i = 0; i < this.MaxSize; i++) {
                this[i].Clear();
            }
        }

        public Match DeepCopy() {
            return new Match(this.Settings) {
                _teams = this._teams.DeepCopy()
            };
        }

        public Team WinningTeam() {
            Team best = null;
            int bestScore = 0;

            foreach(var team in this.Teams) {
                if (team.Score > bestScore) {
                    best = team;
                    bestScore = team.Score;
                }
            }
            return best;
        }
    }
}
