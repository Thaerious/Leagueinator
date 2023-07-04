using System;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class EditEventPanel : UserControl {
        RoundButton currentRoundButton = null;
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
            this.PopulateMatches(button.Round);
        }

        private void PopulateMatches(Round round) {
            this.panelMatchCard.Controls.Clear();

            for (int lane = 0; lane < this.leagueEvent.Settings.LaneCount; lane++) {
                MatchCard matchCard = MatchCard.NewMatchCard(
                    this.CurrentRound.Settings.TeamSize,
                    lane,
                    this.CurrentRound.Matches[lane]
                );
                this.panelMatchCard.Controls.Add(matchCard);
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
            this.PopulateMatches(this.currentRoundButton.Round);
        }
    }
}
