namespace Leagueinator.Forms {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVPlayers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActionAddEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsPanel = new Leagueinator.Components.EventsPanel();
            this.playersPanel = new Leagueinator.Components.PlayersPanel();
            this.editEventPanel = new Leagueinator.Components.EditEventPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuView,
            this.menuEvents});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1260, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.menuFileNew);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.menuFileLoad);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.menuFileClose);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.menuSettings);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVPlayers,
            this.menuVEvents});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(65, 30);
            this.menuView.Text = "View";
            // 
            // menuVPlayers
            // 
            this.menuVPlayers.Name = "menuVPlayers";
            this.menuVPlayers.Size = new System.Drawing.Size(169, 34);
            this.menuVPlayers.Text = "Players";
            this.menuVPlayers.Click += new System.EventHandler(this.menuViewPlayers);
            // 
            // menuVEvents
            // 
            this.menuVEvents.Name = "menuVEvents";
            this.menuVEvents.Size = new System.Drawing.Size(169, 34);
            this.menuVEvents.Text = "Events";
            this.menuVEvents.Click += new System.EventHandler(this.menuViewEvents);
            // 
            // menuEvents
            // 
            this.menuEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuActionAddEvent});
            this.menuEvents.Name = "menuEvents";
            this.menuEvents.Size = new System.Drawing.Size(79, 30);
            this.menuEvents.Text = "Events";
            // 
            // menuActionAddEvent
            // 
            this.menuActionAddEvent.Name = "menuActionAddEvent";
            this.menuActionAddEvent.Size = new System.Drawing.Size(196, 34);
            this.menuActionAddEvent.Text = "Add Event";
            this.menuActionAddEvent.Click += new System.EventHandler(this.newEvent);
            // 
            // eventsPanel
            // 
            this.eventsPanel.BackColor = System.Drawing.Color.White;
            this.eventsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsPanel.Location = new System.Drawing.Point(0, 0);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(1260, 815);
            this.eventsPanel.TabIndex = 3;
            this.eventsPanel.Visible = false;
            // 
            // playersPanel
            // 
            this.playersPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playersPanel.DBManager = null;
            this.playersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersPanel.Location = new System.Drawing.Point(0, 0);
            this.playersPanel.Name = "playersPanel";
            this.playersPanel.Size = new System.Drawing.Size(1260, 815);
            this.playersPanel.TabIndex = 1;
            this.playersPanel.Visible = false;
            // 
            // editEventPanel
            // 
            this.editEventPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editEventPanel.Location = new System.Drawing.Point(0, 0);
            this.editEventPanel.Name = "editEventPanel";
            this.editEventPanel.Size = new System.Drawing.Size(1260, 815);
            this.editEventPanel.TabIndex = 0;
            this.editEventPanel.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 815);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.editEventPanel);
            this.Controls.Add(this.eventsPanel);
            this.Controls.Add(this.playersPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.PlayersPanel playersPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuVPlayers;
        private System.Windows.Forms.ToolStripMenuItem menuVEvents;
        private Components.EventsPanel eventsPanel;
        private System.Windows.Forms.ToolStripMenuItem menuEvents;
        private System.Windows.Forms.ToolStripMenuItem menuActionAddEvent;
        private Components.EditEventPanel editEventPanel;
    }
}
