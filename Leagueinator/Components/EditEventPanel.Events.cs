using System;
using System.Diagnostics;
using System.Linq;
using Leagueinator.Forms;
using Leagueinator.Model.Settings;
using Leagueinator.Model;
using static Leagueinator.Components.PlayerInfoArgs;
using Leagueinator.Algorithms;
using Leagueinator.Controller;

namespace Leagueinator.Components {

    public partial class EditEventPanel {
        public event PlayerInfoEvent RenamePlayer {
            add {
                foreach (var control in this.panelMatchCard.Controls.OfType<MatchCard>()) {
                    control.RenamePlayer += value;
                }
                this.PlayerListBox.RenamePlayer += value;
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchCard>()) {
                    control.RenamePlayer -= value;
                }
                this.PlayerListBox.RenamePlayer -= value;
            }
        }

        public event PlayerInfoEvent DeletePlayer {
            add {
                foreach (var control in this.panelMatchCard.Controls.OfType<MatchCard>()) {
                    control.DeletePlayer += value;
                }
                this.PlayerListBox.DeletePlayer += value;
            }
            remove {
                foreach (var control in this.Controls.OfType<MatchCard>()) {
                    control.DeletePlayer -= value;
                }
                this.PlayerListBox.DeletePlayer -= value;
            }
        }

        private Round SetupRound() {
            Setting setting = this.LeagueEvent.Settings;

            switch (setting.MatchType) {
                case MATCH_TYPE.RoundRobin: {
                        var round = this.leagueEvent.NewRound();
                        this.LeagueEvent.CopyPlayersTo(round);
                        round = this.LeagueEvent.DoRoundRobin(round);
                        round = this.LeagueEvent.DoAssignLanes(round);
                        return round;
                    }
                case MATCH_TYPE.Ranked: {
                        var round = this.DoRankedBracket();
                        return round;
                    }
                case MATCH_TYPE.Penache: {
                        var round = this.leagueEvent.NewRound();
                        this.LeagueEvent.CopyPlayersTo(round);
                        round = this.LeagueEvent.DoPenache(round);
                        round = this.LeagueEvent.DoAssignLanes(round);
                        return round;
                    }
                default:
                    return this.leagueEvent.NewRound();
            }
        }

        private Round DoRankedBracket() {
            var scoreKeeper = new ScoreKeeper(this.LeagueEvent);
            return new RankedBracket(this.LeagueEvent, scoreKeeper).GenerateRound();
        }

        private void HndAddRound(object sender, EventArgs e) {
            var round = this.SetupRound();
            this.leagueEvent.AddRound(round);
            this.AddRound(round);
            this.RefreshRound();
            IsSaved.Singleton.Value = false;
        }

        private void HndRemoveRound(object sender, EventArgs e) {
            if (this.currentRoundButton == null) return;
            this.panelMatchCard.Visible = false;
            this.playerListBox.Items.Clear();
            this.LeagueEvent.RemoveRound(this.CurrentRound);
            this.flowRounds.Controls.Remove(this.currentRoundButton);
            this.currentRoundButton = null;
            IsSaved.Singleton.Value = false;
        }

        /// <summary>
        /// Triggered when a player updates a match card score.
        /// </summary>
        /// <param name="laneIndex"></param>
        /// <param name="teamIndex"></param>
        /// <param name="value"></param>
        private void HndScoreUpdate(int laneIndex, int teamIndex, int value) {
            this.CurrentRound[laneIndex][teamIndex].Score = value;
        }
    }
}
