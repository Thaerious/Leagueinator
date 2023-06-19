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
            set {
                if (value != null) {
                    this.flowRounds.Controls.Clear();
                    this.listPlayers.Items.Clear();

                    this.leagueEvent = value.DeepCopy();
                    this.leagueEvent.Rounds.ForEach(r => this.AddRound(r));
                    this.currentRoundButton = null;
                }
            }
        }

        private Round GetCurrentRound() {
            Round round = new Round();

            for (int lane = 1; lane <= FormMain.Settings.LaneCount; lane++) {
                Control[] controls = this.Controls.Find($"matchCard{lane}", true);
                MatchCard matchCard = controls[0] as MatchCard;

                if (matchCard.Match.Players().Count > 0) {
                    round.Matches.Add(lane - 1, matchCard.Match);
                }
            }

            foreach (PlayerInfo player in this.listPlayers.Items) {
                round.IdlePlayers.Add(player);
            }

            return round;
        }

        private void ShowRound(Round round) {
            Debug.WriteLine($"Show Round");
            Debug.WriteLine(round);
            Debug.WriteLine("--------------------");

            this.listPlayers.Items.Clear();
            round.IdlePlayers.ForEach(p => this.listPlayers.Items.Add(p));

            for (int lane = 1; lane <= FormMain.Settings.LaneCount; lane++) {
                Control[] controls = this.Controls.Find($"matchCard{lane}", true);
                MatchCard matchCard = controls[0] as MatchCard;

                if (round.Matches.ContainsKey(lane)) {
                    Debug.WriteLine($"round match has key {lane}");
                    Debug.WriteLine(round.Matches[lane]);
                    matchCard.Match = round.Matches[lane];
                } else {
                    matchCard.Clear();
                }
            }
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
            this.ShowRound(button.Round);
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
    }
}
