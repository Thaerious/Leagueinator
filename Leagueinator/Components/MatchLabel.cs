using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchLabel : Label {
        private PlayerInfo _playerInfo;
        private ContextMenuStrip contextMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem menuDelete;
        private ToolStripMenuItem menuRename;

        public int Team { get; set; } = 0;
        public int Position { get; set; } = 0;
        public int Lane => this.Parent != null ? (this.Parent as MatchCard).Lane : -1;

        public MatchLabel() : base() {
            this.InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            switch (e.Button) {
                case MouseButtons.Right: {
                        if (this.PlayerInfo == null) return;
                        this.contextMenu.Show(this, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        public PlayerInfo PlayerInfo {
            get { return this._playerInfo; }
            set {
                this._playerInfo = value;
                if (value == null) this.Text = "";
                else this.Text = this._playerInfo.Name;
            }
        }

        public override string ToString() {
            return $"MatchLabel [lane = {this?.Lane}, team = {this?.Team}, pos = {this?.Position}]";
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete,
            this.menuRename});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(200, 68);
            this.contextMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ContextClosing);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextOpening);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(199, 32);
            this.menuDelete.Text = "Delete Player";
            this.menuDelete.Click += new System.EventHandler(this.Menu_Delete);
            // 
            // menuRename
            // 
            this.menuRename.Name = "menuRename";
            this.menuRename.Size = new System.Drawing.Size(199, 32);
            this.menuRename.Text = "Rename Player";
            this.menuRename.Click += new System.EventHandler(this.Menu_Rename);
            // 
            // MatchLabel
            // 
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void ContextOpening(object sender, System.ComponentModel.CancelEventArgs e) {
            this.ForeColor = Color.Blue;
        }

        private void ContextClosing(object sender, ToolStripDropDownClosingEventArgs e) {
            this.ForeColor = Color.Black;
        }
        private void Menu_Delete(object sender, EventArgs e) {
            this.TriggerDeleteEvent();
            this.PlayerInfo = null;
        }

        private void Menu_Rename(object sender, EventArgs e) {
            this.TriggerRenameEvent();
        }
    }
}
