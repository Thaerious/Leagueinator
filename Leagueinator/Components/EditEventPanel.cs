using System;
using System.Diagnostics;
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
                return currentRoundButton?.Round;
            }

            set {
                if (currentRoundButton?.Round == null) return;
                int index = leagueEvent.IndexOf(currentRoundButton?.Round);
                leagueEvent[index] = value;
                currentRoundButton.Round = value;
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
                    flowRounds.Controls.Clear();
                    playerListBox.Items.Clear();

                    leagueEvent = value;
                    currentRoundButton = null;
                    leagueEvent.ForEach(r => AddRound(r));
                }
            }
        }

        private void AddRound(Round round) {
            var button = new RoundButton(round) {
                Text = $"Round #{flowRounds.Controls.Count + 1}"
            };
            flowRounds.Controls.Add(button);

            button.Click += new EventHandler(RoundButtonClick);

            if (currentRoundButton == null) {
                RoundButtonClick(button, null);
            }
        }

        private void RoundButtonClick(object source, EventArgs _) {
            RoundButton button = (RoundButton)source;

            if (currentRoundButton != null) {
                currentRoundButton.BackColor = Color.White;
            }

            button.BackColor = Color.GreenYellow;

            currentRoundButton = button;
            playerListBox.Round = currentRoundButton.Round;
            PopulateMatches(button.Round);
        }

        private void PopulateMatches(Round round) {
            for (int lane = 1; lane <= leagueEvent.Settings.LaneCount; lane++) {
                Control[] controls = Controls.Find($"matchCard{lane}", true);
                MatchCard matchCard = controls[0] as MatchCard;
                matchCard.Match = round[lane - 1];
            }
        }

        public void AddPlayer(PlayerInfo player, bool currentRoundOnly = true) {
            if (LeagueEvent == null) return;

            if (!this.CurrentRound.SeekDeep<PlayerInfo>().Contains(player)) {
                this.CurrentRound.IdlePlayers.Add(player);
                playerListBox.Items.Add(player);
                IsSaved.Singleton.Value = false;
            }

            if (!currentRoundOnly) {
                foreach (Round round in LeagueEvent) {
                    if (round.SeekDeep<PlayerInfo>().Contains(player)) continue;
                    round.IdlePlayers.Add(player);
                    IsSaved.Singleton.Value = false;
                }
            }
        }

        internal void RefreshRound() {
            playerListBox.Round = currentRoundButton.Round;
            PopulateMatches(currentRoundButton.Round);
        }
    }
}
