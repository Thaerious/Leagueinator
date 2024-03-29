﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leagueinator.Utility_Classes;
using Leagueinator.Model.Settings;

namespace Leagueinator.Model {
    [Serializable]
    public class Team : HasDeepCopy<Team>{
        public readonly Setting settings;
        public int Score = 0;

        private PlayerInfo[] _players;
        public PlayerInfo this[int key] {
            get => this._players[key];
            set => this._players[key] = value;
        }

        public int MaxSize => this._players.Length;

        public bool IsFull => this.Players.Count == this.MaxSize;

        public bool IsEmpty => this.Players.Count == 0;

        [Model] public List<PlayerInfo> Players => new List<PlayerInfo>().AddUnique(this._players);

        public Team(Setting settings) {
            this.settings = settings;
            this._players = new PlayerInfo[settings.TeamSize];
        }

        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("Team", $"score='{this.Score}' hash='{this.GetHashCode().ToString("X")}'");
            
            foreach ( var player in this.Players ) {
                xsb.AppendXML( player.ToXML() );
            }
            
            xsb.CloseTag();

            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }

        public void Clear() {
            this._players.Fill(null);
        }

        public bool HasPlayer(PlayerInfo player) {
            return this.Players.Contains(player);
        }

        /// <summary>
        /// Add player to the next empty position.
        /// If there is no emptly position, no change is made.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True, if a change was made.</returns>
        public bool AddPlayer(PlayerInfo player) {
            for (int i = 0; i < this._players.Length; i++) {
                if (this._players[i] == null) {
                    this._players[i] = player;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove a player from this Team.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True, if a change was made.</returns>
        public bool RemovePlayer(PlayerInfo player) {
            for (int i = 0; i < this._players.Length; i++) {
                if (this._players[i] == player) {
                    this._players[i] = null;
                    return true;
                }
            }

            return false;
        }

        public Team DeepCopy() {
            var t = new Team(this.settings) {
                _players = this._players.DeepCopy()
            };

            return t;
        }
    }

    public class TeamBye : Team {
        public TeamBye(Setting settings)  : base(settings){
            for (int i = 0; i < settings.TeamSize; i++) {
                this[i] = new PlayerBye();
            }
        }
    }
}
