using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Leagueinator.Forms;
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

        public PlayerListBox(IContainer container) {
            container.Add(this);
            this.InitializeComponent();
            this.AllowDrop = true;
            DragDrop += new DragEventHandler(this.OnDropStart);
            DragEnter += new DragEventHandler(this.OnDragEnter);
            MouseDown += new MouseEventHandler(this.OnDragStart);

            this.menuDelete.Click += new System.EventHandler(this.HndMenuDelete);
            this.menuRename.Click += new System.EventHandler(this.HndMenuRename);
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

            PlayerDragData data = (PlayerDragData)e.Data.GetData(typeof(PlayerDragData));
            if (receiver == data.Source) return;

            data.Destination = receiver;
        }

        public void OnDragStart(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            var data = new PlayerDragData { Source = this, PlayerInfo = (PlayerInfo)this.SelectedItem };

            this.DoDragDrop(data, DragDropEffects.Move);
            if (data.Destination == null) return;

            if (data.Destination.GetType() == typeof(MatchLabel)) {
                MatchLabel matchLabel = (MatchLabel)data.Destination;
                if (matchLabel.PlayerInfo != null) {
                    this.Items.Add(matchLabel.PlayerInfo);
                }

                matchLabel.PlayerInfo = data.PlayerInfo;
                this.Items.Remove(data.PlayerInfo);

                this.Round.IdlePlayers.Remove(data.PlayerInfo);
                this.Round[matchLabel.Lane][matchLabel.Team][matchLabel.Position] = data.PlayerInfo;
                IsSaved.Singleton.Value = false;
            }
        }

        public void OnDragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        public PlayerInfo SetPlayer(PlayerInfo playerInfo) {
            if (playerInfo == null) return null;
            this.Items.Add(playerInfo);
            this.Round.IdlePlayers.Add(playerInfo);
            IsSaved.Singleton.Value = false;
            return null;
        }

        public PlayerInfo ClearPlayer(PlayerInfo playerInfo) {
            PlayerInfo prev = this.PlayerInfo;
            this.Items.Remove(playerInfo);
            this.Round.IdlePlayers.Remove(playerInfo);
            IsSaved.Singleton.Value = false;
            return prev;
        }

        private void Context_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            Debug.WriteLine("Context_Opening");
            if (this.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }
    }
}
