using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class PlayerListBox : ListBox, IModelPlayer {
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
            
            DragData dragData = (DragData)e.Data.GetData(typeof(DragData));
            dest.SwapPlayers(dragData.Source);

            Debug.WriteLine("Player List Box Exit Drop");
        }

        public void OnDragStart(object sender, MouseEventArgs e) {
            Debug.WriteLine($"Player List Box Start Drag");
            this.DoDragDrop(new DragData{ Source = this}, DragDropEffects.Move);
            Debug.WriteLine("Player List Box Exit Drag");
        }

        public void OnDragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        public void SwapPlayers(IModelPlayer that) {
            if (that == this) return;
            (that.PlayerInfo, this.PlayerInfo) = (this.PlayerInfo, that.PlayerInfo);
        }
    }
}
