using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;
using static Leagueinator.Components.MatchLabel;
using static Leagueinator.Components.PlayerInfoArgs;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl {
        private int _lane = 0;
        public int Lane {
            get => _lane;
            set {
                _lane = value;
                labelLane.Text = (value + 1).ToString();
            }
        }

        private Match _match;
        public Match Match {
            get {
                return _match;
            }
            set {
                if (value != null) {
                    labelP0.PlayerInfo = value[0][0];
                    labelP1.PlayerInfo = value[0][1];
                    labelP2.PlayerInfo = value[1][0];
                    labelP3.PlayerInfo = value[1][1];
                }
                _match = value;
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

            PlayerDragData data = (PlayerDragData)e.Data.GetData(typeof(PlayerDragData));
            data.Destination = receiver;
        }

        private void StartDrag(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            if (!(sender is MatchLabel srcLabel)) return;
            if (srcLabel.PlayerInfo == null) return;

            srcLabel.ForeColor = Color.LightGray;
            var data = new PlayerDragData { Source = srcLabel, PlayerInfo = srcLabel.PlayerInfo };

            DoDragDrop(data, DragDropEffects.Move);
            srcLabel.ForeColor = Color.Black;
            if (data.Destination == null) return;

            if (data.Destination.GetType() == typeof(PlayerListBox)) {
                PlayerListBox playerListBox = (PlayerListBox)data.Destination;
                playerListBox.Items.Add(data.PlayerInfo);
                srcLabel.PlayerInfo = null;

                Match.Teams[srcLabel.Team][srcLabel.Position] = null;
                IsSaved.Singleton.Value = false;

                playerListBox.Round.IdlePlayers.Add(data.PlayerInfo);
            }

            if (data.Destination.GetType() == typeof(MatchLabel)) {
                MatchLabel destLabel = (MatchLabel)data.Destination;

                srcLabel.PlayerInfo = destLabel.PlayerInfo;
                destLabel.PlayerInfo = data.PlayerInfo;

                Match.Teams[srcLabel.Team][srcLabel.Position] = srcLabel.PlayerInfo;
                Match.Teams[destLabel.Team][destLabel.Position] = destLabel.PlayerInfo;
                IsSaved.Singleton.Value = false;
            }
        }

        private void OnEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void OnExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }
    }
}

