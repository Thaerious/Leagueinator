using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class EditEventPanel : UserControl {
        RoundButton currentRoundButton = null;
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
                    this.leagueEvent.Rounds.ForEach(r => this.AddRound(r));
                    this.currentRoundButton = null;
                }
            }
        }

        private Round GetCurrentRound() {
            return currentRoundButton.Round;
        }

        private void AddRound(Round round) {
            var button = new RoundButton(round) {
                Text = $"Round #{this.flowRounds.Controls.Count + 1}"
            };
            this.flowRounds.Controls.Add(button);

            button.Click += new EventHandler(RoundButtonClick);
        }

        private void RoundButtonClick(object source, EventArgs _) {
            RoundButton button = (RoundButton)source;

            if (this.currentRoundButton != null) {
                this.currentRoundButton.BackColor = Color.White;
            }

            button.BackColor = Color.GreenYellow;

            if (this.currentRoundButton != null) {
                this.currentRoundButton.Round = this.GetCurrentRound();
            }

            this.currentRoundButton = button;
            this.playerListBox.Round = currentRoundButton.Round;
            this.PopulateMatches(button.Round);
        }

        private void PopulateMatches(Round round) {
            for (int lane = 1; lane <= this.leagueEvent.settings.LaneCount; lane++) {
                Control[] controls = this.Controls.Find($"matchCard{lane}", true);
                MatchCard matchCard = controls[0] as MatchCard;
                matchCard.Match = round.Matches[lane - 1];
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

            this.LeagueEvent.Players.Add(player);
            foreach(Round round in this.LeagueEvent.Rounds) {
                round.IdlePlayers.Add(player);
            }

            this.playerListBox.Items.Add(player);
        }
    }
}
