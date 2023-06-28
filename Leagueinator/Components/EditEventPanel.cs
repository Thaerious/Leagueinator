using System;
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

        private void AddRoundHnd(object sender, EventArgs e) {
            AddRound(leagueEvent.AddRound());
        }

        private void RemoveRoundHnd(object sender, EventArgs e) {
            if (currentRoundButton != null) {
                flowRounds.Controls.Remove(currentRoundButton);
                currentRoundButton = null;
            }
        }

        public void AddPlayer(PlayerInfo player) {
            if (LeagueEvent == null) return;

            if (LeagueEvent.SeekDeep<PlayerInfo>().Contains(player)) {
                return;
            }

            foreach (Round round in LeagueEvent) {
                round.IdlePlayers.Add(player);
            }

            playerListBox.Items.Add(player);
        }

        internal void RefreshRound() {
            playerListBox.Round = currentRoundButton.Round;
            PopulateMatches(currentRoundButton.Round);
        }
    }
}
