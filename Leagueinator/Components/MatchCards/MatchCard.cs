using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl {

        public static MatchCard NewMatchCard(int teamSize, int lane, Match match) {
            switch (teamSize) {
                case 1: {
                        return new MatchCard_1 {
                            Name = $"matchCard{lane}",
                            Match = match,
                            Lane = lane
                        };
                    }
                case 2: {
                        return new MatchCard_2 {
                            Name = $"matchCard{lane}",
                            Match = match,
                            Lane = lane
                        };
                    }
                case 3: {
                        return new MatchCard_3 {
                            Name = $"matchCard{lane}",
                            Match = match,
                            Lane = lane
                        };
                    }
                case 4: {
                        return new MatchCard_4 {
                            Name = $"matchCard{lane}",
                            Match = match,
                            Lane = lane
                        };
                    }
                default: throw new ArgumentOutOfRangeException("teamSize");
            }
        }

        public virtual int Lane {
            get => this._lane;
            set {
                this._lane = value;
            }
        }

        public virtual Match Match {
            get => this._match;
            set => this._match = value;
        }

        public virtual void InitializeComponent() {}

        public MatchCard() {
            this.InitializeComponent();
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

        internal void DoStartDrag(object sender, MouseEventArgs e) {
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

                srcLabel.PlayerInfo = destLabel.PlayerInfo;
                destLabel.PlayerInfo = data.PlayerInfo;

                this.Match.Teams[srcLabel.Team][srcLabel.Position] = srcLabel.PlayerInfo;
                this.Match.Teams[destLabel.Team][destLabel.Position] = destLabel.PlayerInfo;
                IsSaved.Singleton.Value = false;
            }
        }

        internal void DoEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        internal void DoExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }

        private int _lane = 0;
        private Match _match;
        internal Label labelLane = new System.Windows.Forms.Label();
    }
}

