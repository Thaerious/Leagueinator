using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl, HasModelMatch {
        private int _lane = 0;
        public int Lane {
            get => _lane;
            set {
                _lane = value;
                this.labelLane.Text = (value + 1).ToString();
            }
        }

        private Match _match;
        public Match Match {
            get {
                return _match;
            }
            set {
                if (value != null) {
                    this.labelP0.PlayerInfo = value[0][0];
                    this.labelP1.PlayerInfo = value[0][1];
                    this.labelP2.PlayerInfo = value[1][0];
                    this.labelP3.PlayerInfo = value[1][1];
                }
                this._match = value;
            }
        }

        public MatchCard() {
            InitializeComponent();
        }

        /// <summary>
        /// Player name get's dragged onto a match label
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="e"></param>
        private void OnDrop(object receiver, DragEventArgs e) {
            if (!(receiver is MatchLabel matchLabel)) return;
            Debug.WriteLine($"Match Card Start Drop");

            PlayerDragData data = (PlayerDragData)e.Data.GetData(typeof(PlayerDragData));
            data.Destination = receiver;
            
            Debug.WriteLine("Match Card Exit Drop");
        }

        private void StartDrag(object sender, MouseEventArgs e) {
            if (!(sender is MatchLabel matchLabel)) return;
            if (matchLabel.PlayerInfo == null) return;

            Debug.WriteLine($"Match Card Start Drag");
            matchLabel.ForeColor = Color.LightGray;

            var data = new PlayerDragData { Source = matchLabel, PlayerInfo = matchLabel.PlayerInfo };

            this.DoDragDrop(data, DragDropEffects.Move);
            matchLabel.ForeColor = Color.Black;
            if (data.Destination == null) return;

            if (data.Destination.GetType() == typeof(PlayerListBox)) {
                PlayerListBox playerListBox = (PlayerListBox)data.Destination;
                playerListBox.Items.Add(data.PlayerInfo);
                matchLabel.PlayerInfo = null;

                Debug.WriteLine(this.Match);
                this.Match.Teams[matchLabel.Team][matchLabel.Position] = null;

                playerListBox.Round.IdlePlayers.Add(data.PlayerInfo);
            }

            Debug.WriteLine("Match Card Exit Drag\n");
        }

        private void OnEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void OnExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }
    }
}

