using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class EditEventPanel : UserControl {
        RoundButton currentRoundButton = null;

        /// <summary>
        /// Retrieve or set the currently selected round.
        /// On set the current round is replaced in both the league event
        /// and this panel.
        /// </summary>
        public Round CurrentRound {
            get {
                return currentRoundButton?.Round;
            }

            set {
                if (currentRoundButton?.Round == null) return;
                int index = this.leagueEvent.IndexOf(currentRoundButton?.Round);
                this.leagueEvent[index] = value;
                this.currentRoundButton.Round = value;
            }
        }

        public EditEventPanel() {
            InitializeComponent();
        }

        private LeagueEvent leagueEvent = null;
        public LeagueEvent LeagueEvent {
            get { return leagueEvent; }
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

            button.Click += new EventHandler(RoundButtonClick);

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
            this.playerListBox.Round = currentRoundButton.Round;
            this.PopulateMatches(button.Round);
        }

        private void PopulateMatches(Round round) {
            for (int lane = 1; lane <= this.leagueEvent.Settings.LaneCount; lane++) {
                Control[] controls = this.Controls.Find($"matchCard{lane}", true);
                MatchCard matchCard = controls[0] as MatchCard;
                matchCard.Match = round[lane - 1];
            }
        }

        private void AddRoundHnd(object sender, EventArgs e) {
            this.AddRound(this.leagueEvent.AddRound());
        }

        private void RemoveRoundHnd(object sender, EventArgs e) {
            if (this.currentRoundButton != null) {
                this.flowRounds.Controls.Remove(this.currentRoundButton);
                this.currentRoundButton = null;
            }
        }

        public void AddPlayer(PlayerInfo player) {
            if (this.LeagueEvent == null) return;

            if (this.LeagueEvent.SeekDeep<PlayerInfo>().Contains(player)) {
                return;
            }

            foreach (Round round in this.LeagueEvent) {
                round.IdlePlayers.Add(player);
            }

            this.playerListBox.Items.Add(player);
        }

        internal void RefreshRound() {
            this.playerListBox.Round = currentRoundButton.Round;
            this.PopulateMatches(currentRoundButton.Round);
        }
    }
}
