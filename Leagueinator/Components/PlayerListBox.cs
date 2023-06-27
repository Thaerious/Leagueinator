using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class PlayerListBox : ListBox {

        private Round _round = null;
        public Round Round {
            get {
                return this._round;
            }
            set {
                this._round = value;
                this.Items.Clear();
                if (value == null) return;
                foreach (PlayerInfo pi in value.IdlePlayers) {
                    this.Items.Add(pi);
                }
            }
        }

        public PlayerListBox() {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.OnDropStart);
            this.DragEnter += new DragEventHandler(this.OnDragEnter);
            this.MouseDown += new MouseEventHandler(this.OnDragStart);
        }

        public PlayerListBox(IContainer container) {
            container.Add(this);
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.OnDropStart);
            this.DragEnter += new DragEventHandler(this.OnDragEnter);
            this.MouseDown += new MouseEventHandler(this.OnDragStart);
        }

        public PlayerInfo PlayerInfo {
            get {
                if (this.SelectedIndex == -1) return null;
                return (PlayerInfo)this.SelectedItem;
            }
            set {
                if (value == null) {
                    this.Items.Remove(this.SelectedItem);
                }
                else if (this.SelectedItem != value) {
                    this.Items.Remove(this.SelectedItem);
                    this.Items.Add(value);
                }
            }
        }

        private void OnDropStart(object receiver, DragEventArgs e) {
            if (!(receiver is PlayerListBox dest)) return;

            Debug.WriteLine($"Player List Box Start Drop");

            PlayerDragData data = (PlayerDragData)e.Data.GetData(typeof(PlayerDragData));
            if (receiver == data.Source) return;

            data.Destination = receiver;

            Debug.WriteLine("Player List Box Exit Drop");
        }

        public void OnDragStart(object sender, MouseEventArgs e) {
            Debug.WriteLine($"Player List Box Start Drag");

            var data = new PlayerDragData { Source = this, PlayerInfo = (PlayerInfo)this.SelectedItem };            

            this.DoDragDrop(data, DragDropEffects.Move);
            if (data.Destination == null) return;

            if (data.Destination.GetType() == typeof(MatchLabel)) {
                MatchLabel matchLabel = (MatchLabel)data.Destination;
                matchLabel.PlayerInfo = data.PlayerInfo;
                this.Items.Remove(data.PlayerInfo);

                this.Round.IdlePlayers.Remove(data.PlayerInfo);
                this.Round
                    .Matches[matchLabel.Lane]
                    .Teams[matchLabel.Team]
                    [matchLabel.Position] = data.PlayerInfo;
            }

            Debug.WriteLine("Player List Box Exit Drag\n");
        }

        public void OnDragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        public PlayerInfo SetPlayer(PlayerInfo playerInfo) {
            if (playerInfo == null) return null;
            this.Items.Add(playerInfo);
            this.Round.IdlePlayers.Add(playerInfo);
            return null;
        }

        public PlayerInfo ClearPlayer(PlayerInfo playerInfo) {
            PlayerInfo prev = this.PlayerInfo;
            this.Items.Remove(playerInfo);
            this.Round.IdlePlayers.Remove(playerInfo);
            return prev;
        }
    }
}
