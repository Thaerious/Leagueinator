using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl {
        public delegate void UpdateScoreEvent(int laneIndex, int teamIndex, int value);
        public event UpdateScoreEvent UpdateScoreListeners;

        public static MatchCard NewMatchCard(int teamSize, int lane, Round round, Match match) {

            MatchCard card = null;
            switch (teamSize) {
                case 1: {
                        card = new MatchCard_1 {
                            Name = $"matchCard{lane}",
                            Round = round,
                            Match = match,
                            Lane = lane
                        };
                    }
                    break;
                case 2: {
                        card = new MatchCard_2 {
                            Name = $"matchCard{lane}",
                            Round = round,
                            Match = match,
                            Lane = lane
                        };
                    }
                    break;
                case 3: {
                        card = new MatchCard_3 {
                            Name = $"matchCard{lane}",
                            Round = round,
                            Match = match,
                            Lane = lane
                        };
                    }
                    break;
                case 4: {
                        card = new MatchCard_4 {
                            Name = $"matchCard{lane}",
                            Round = round,
                            Match = match,
                            Lane = lane
                        };
                    }
                    break;
                default: throw new ArgumentOutOfRangeException("teamSize");
            }

            foreach(Control control in card.Controls) {
                if (control.Name.StartsWith("txtScore")){
                    var index = control.Name.Substring("txtScore".Length);
                    control.TextChanged += card.DoUpdateScore;
                }
            }

            return card;
        }

        private void DoUpdateScore(Object sender, EventArgs args) {
            TextBox textBox = sender as TextBox;

            var index = textBox.Name.Substring("txtScore".Length);
            var value = textBox.Text;

            if (this.UpdateScoreListeners != null) {
                this.UpdateScoreListeners(this.Lane, Int32.Parse(index), Int32.Parse(value));
            }
        }

        public virtual int Lane {
            get => this._lane;
            set {
                this._lane = value;
            }
        }

        public virtual Round Round {
            get => this._round;
            set {
                this._round = value;
            }
        }

        public virtual Match Match {
            get => this._match;
            set {
                var txtScore0 = this.Controls.Find("txtScore0", true)[0];
                var txtScore1 = this.Controls.Find("txtScore1", true)[0];                

                this._match = value;
                if (value != null) {
                    if (txtScore0 != null) txtScore0.Text = value[0].Score.ToString();
                    if (txtScore1 != null) txtScore1.Text = value[1].Score.ToString();
                }
            }
        }

        public virtual void InitializeComponent() { }

        public MatchCard() {
            this.InitializeComponent();
            var dragDropCard = new DragDropCard(this);
        }

        public void Clear() {
            foreach (var control in this.Controls.OfType<MatchLabel>()) {
                control.PlayerInfo = null;
            }
        }

        /// <summary>
        /// Player name get's dragged onto a match label
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="e"></param>
        internal virtual void DoDrop(object receiver, DragEventArgs e) {
            if (!(receiver is MatchLabel matchLabel)) return;
            PlayerDragData data = (PlayerDragData)e.Data.GetData(typeof(PlayerDragData));
            data.Destination = receiver;
        }

        public virtual void StartDragCard(object sender, MouseEventArgs e) {
            Debug.WriteLine("Start Drag Card");
        }

        internal void StartDragLabel(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            if (!(sender is MatchLabel srcLabel)) return;
            if (srcLabel.PlayerInfo == null) return;

            srcLabel.ForeColor = Color.LightGray;
            var data = new PlayerDragData { Source = srcLabel, PlayerInfo = srcLabel.PlayerInfo };
            this.DoDragDrop(data, DragDropEffects.Move);

            srcLabel.ForeColor = Color.Black;
            if (data.Destination == null) return;

            if (data.Destination.GetType() == typeof(PlayerListBox)) {
                PlayerListBox playerListBox = (PlayerListBox)data.Destination;
                playerListBox.Items.Add(data.PlayerInfo);
                srcLabel.PlayerInfo = null;

                this.Match.Teams[srcLabel.Team][srcLabel.Position] = null;
                IsSaved.Singleton.Value = false;

                playerListBox.Round.IdlePlayers.Add(data.PlayerInfo);
            }

            if (data.Destination.GetType() == typeof(MatchLabel)) {
                MatchLabel destLabel = (MatchLabel)data.Destination;

                (srcLabel.PlayerInfo, destLabel.PlayerInfo) = (destLabel.PlayerInfo, srcLabel.PlayerInfo);

                this.Round[srcLabel.Lane][srcLabel.Team][srcLabel.Position] = srcLabel.PlayerInfo;
                this.Round[destLabel.Lane][destLabel.Team][destLabel.Position] = destLabel.PlayerInfo;
                IsSaved.Singleton.Value = false;
            }
        }

        internal void DoEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        internal void DoExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }

        public List<MatchLabel> Labels() {
            var list = new List<MatchLabel>();

            this.Controls
                .Cast<Control>()
                .Where(c => c is MatchLabel)
                .ToList()
                .ForEach(c => list.Add((MatchLabel)c));

            return list;
        }
        

        private int _lane = 0;
        private Match _match;
        private Round _round;
        internal Label labelLane = new System.Windows.Forms.Label();
    }
}

