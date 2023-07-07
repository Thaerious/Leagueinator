using System;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

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

            set {
                if (this.currentRoundButton?.Round == null) return;
                int index = this.leagueEvent.IndexOf(this.currentRoundButton?.Round);
                this.leagueEvent[index] = value;
                this.currentRoundButton.Round = value;
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

                    this.leagueEvent = value;
                    this.currentRoundButton = null;
                    this.PopulateMatches(value.Settings);
                    this.leagueEvent.ForEach(r => this.AddRound(r));
                }
            }
        }

        private void AddRound(Round round) {
            var button = new RoundButton(round) {
                Text = $"Round #{this.flowRounds.Controls.Count + 1}"
            };
            this.flowRounds.Controls.Add(button);

            button.Click += new EventHandler(this.RoundButtonClick);

            if (this.currentRoundButton == null) {
                this.RoundButtonClick(button, null);
            }
        }

        private void RoundButtonClick(object source, EventArgs _) {
            RoundButton button = (RoundButton)source;

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
        /// <param name="round"></param>
        private void PopulateMatches(Settings settings) {
            this.panelMatchCard.Controls.Clear();

            for (int lane = 0; lane < settings.LaneCount; lane++) {
                MatchCard matchCard = MatchCard.NewMatchCard(
                    settings.TeamSize,
                    lane,
                    null,
                    null
                );
                this.panelMatchCard.Controls.Add(matchCard);
            }
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

        public void ReplaceCurrentRound(Round round) {
            this.currentRoundButton.Round = round;
        }
    }
}
