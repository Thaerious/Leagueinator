using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Algorithms;
using Leagueinator.Algorithms.Solutions;
using Leagueinator.Forms;
using Leagueinator.Model;
using Leagueinator.Model.Settings;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Components {
    public partial class EditEventPanel : UserControl {
        private RoundButton currentRoundButton = null;
        public PlayerListBox PlayerListBox => this.playerListBox;

        /// <summary>
        /// Retrieve or set the currently selected round.
        /// On set the current round is replaced in both the league event
        /// and this panel.
        /// </summary>
        public Round CurrentRound {
            get {
                return this.currentRoundButton?.Round;
            }
        }

        public EditEventPanel() {
            this.InitializeComponent();
        }

        private LeagueEvent leagueEvent = null;
        public LeagueEvent LeagueEvent {
            get { return this.leagueEvent; }
            set {
                if (value != null) {
                    this.flowRounds.Controls.Clear();
                    this.playerListBox.Items.Clear();
                    this.currentRoundButton = null;

                    this.leagueEvent = value; 
                    this.PopulateMatches(value.Settings);
                    
                    foreach(Round r  in value.Rounds) {
                        this.AddRound(r);
                    }
                }
            }
        }

        /// <summary>
        /// Add a round to this panel.<br>
        /// Does not manipulate the underlying model.<br>
        /// Set the current round to the added round.<br>
        /// </summary>
        /// <param name="round"></param>
        private RoundButton AddRound(Round round) {
            var button = new RoundButton(round) {
                Text = $"Round #{this.flowRounds.Controls.Count + 1}"
            };
            this.flowRounds.Controls.Add(button);

            button.Click += new EventHandler(this.RoundButtonClick);

            if (this.currentRoundButton == null) {
                this.RoundButtonClick(button, null);
            }

            return button;
        }

        private Round SetupRound(Round round) {
            Setting setting = this.LeagueEvent.Settings;

            switch (setting.MatchType) {
                case MATCH_TYPE.RoundRobin:
                    this.LeagueEvent.CopyPlayersTo(round);
                    round = this.LeagueEvent.DoRoundRobin(round);
                    round = this.LeagueEvent.DoAssignLanes(round);
                    break;
                case MATCH_TYPE.Ranked:
                    break;
                case MATCH_TYPE.Brackets:
                    break;
                case MATCH_TYPE.Penache:
                    this.LeagueEvent.CopyPlayersTo(round);
                    round = this.LeagueEvent.DoPenache(round);
                    round = this.LeagueEvent.DoAssignLanes(round);
                    break;
            }

            return round;
        }

        private void RoundButtonClick(object source, EventArgs _) {
            RoundButton button = (RoundButton)source;
            this.panelMatchCard.Visible = true;

            if (this.currentRoundButton != null) {
                this.currentRoundButton.BackColor = Color.White;
            }

            button.BackColor = Color.GreenYellow;

            this.currentRoundButton = button;
            this.playerListBox.Round = this.currentRoundButton.Round;
            this.RePopulateMatches(button.Round);
        }

        /// <summary>
        /// Populate the match card panel with new match cards.
        /// </summary>
        /// <return>The last card added</return>
        /// <param name="round"></param>
        private MatchCard PopulateMatches(Setting settings) {
            this.panelMatchCard.Controls.Clear();
            MatchCard matchCard = null;

            for (int lane = 0; lane < settings.LaneCount; lane++) {
                matchCard = MatchCard.NewMatchCard(
                    settings.TeamSize,
                    lane,
                    null,
                    null
                );
                this.panelMatchCard.Controls.Add(matchCard);
            }
            return matchCard;
        }

        /// <summary>
        /// Fill the match cards with values from 'round'.
        /// Retains the match cards currently in place.
        /// </summary>
        /// <param name="round"></param>
        private void RePopulateMatches(Round round) {            
            for (int lane = 0; lane < this.leagueEvent.Settings.LaneCount; lane++) {
                MatchCard matchCard = this.panelMatchCard.Controls[lane] as MatchCard;
                matchCard.Round = round;
                matchCard.Match = round[lane];
            }
        }

        public void AddPlayer(PlayerInfo player, bool currentRoundOnly = true) {
            if (this.LeagueEvent == null) return;
            if (this.CurrentRound == null) throw new Exception();

            if (!this.CurrentRound.SeekDeep<PlayerInfo>().Contains(player)) {
                this.CurrentRound.IdlePlayers.Add(player);
                this.playerListBox.Items.Add(player);
                IsSaved.Singleton.Value = false;
            }

            if (!currentRoundOnly) {
                foreach (Round round in this.LeagueEvent) {
                    if (round.SeekDeep<PlayerInfo>().Contains(player)) continue;
                    round.IdlePlayers.Add(player);
                    IsSaved.Singleton.Value = false;
                }
            }
        }

        internal void RefreshRound() {
            this.playerListBox.Round = this.currentRoundButton.Round;
            this.RePopulateMatches(this.currentRoundButton.Round);
        }

        public void SetCurrentRound(Round round) {
            this.currentRoundButton.Round = round;
        }
    }
}
