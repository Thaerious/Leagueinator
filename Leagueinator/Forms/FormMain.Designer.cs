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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelContents = new System.Windows.Forms.Panel();
            this.editEventPanel = new Leagueinator.Components.EditEventPanel();
            this.eventsPanel = new Leagueinator.Components.EventsPanel();
            this.playersPanel = new Leagueinator.Components.PlayersPanel();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCurrentEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.tableRoot.SuspendLayout();
            this.panelContents.SuspendLayout();
            this.SuspendLayout();
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
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
            this.menuView.Size = new System.Drawing.Size(65, 29);
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
            this.menuEvents.Size = new System.Drawing.Size(79, 29);
            this.menuEvents.Text = "Events";
            // 
            // menuActionAddEvent
            // 
            this.menuActionAddEvent.Name = "menuActionAddEvent";
            this.menuActionAddEvent.Size = new System.Drawing.Size(196, 34);
            this.menuActionAddEvent.Text = "Add Event";
            this.menuActionAddEvent.Click += new System.EventHandler(this.newEvent);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuView,
            this.menuEvents,
            this.actionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1260, 33);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tableRoot
            // 
            this.tableRoot.ColumnCount = 1;
            this.tableRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Controls.Add(this.menuStrip, 0, 0);
            this.tableRoot.Controls.Add(this.panelContents, 0, 1);
            this.tableRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRoot.Location = new System.Drawing.Point(0, 0);
            this.tableRoot.Name = "tableRoot";
            this.tableRoot.RowCount = 2;
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Size = new System.Drawing.Size(1260, 815);
            this.tableRoot.TabIndex = 3;
            // 
            // panelContents
            // 
            this.panelContents.Controls.Add(this.editEventPanel);
            this.panelContents.Controls.Add(this.eventsPanel);
            this.panelContents.Controls.Add(this.playersPanel);
            this.panelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContents.Location = new System.Drawing.Point(3, 36);
            this.panelContents.Name = "panelContents";
            this.panelContents.Size = new System.Drawing.Size(1254, 776);
            this.panelContents.TabIndex = 3;
            // 
            // editEventPanel
            // 
            this.editEventPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editEventPanel.Location = new System.Drawing.Point(0, 0);
            this.editEventPanel.Name = "editEventPanel";
            this.editEventPanel.Size = new System.Drawing.Size(1254, 776);
            this.editEventPanel.TabIndex = 0;
            this.editEventPanel.Visible = false;
            // 
            // eventsPanel
            // 
            this.eventsPanel.BackColor = System.Drawing.Color.White;
            this.eventsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsPanel.Location = new System.Drawing.Point(0, 0);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(1254, 776);
            this.eventsPanel.TabIndex = 1;
            this.eventsPanel.Visible = false;
            // 
            // playersPanel
            // 
            this.playersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersPanel.Location = new System.Drawing.Point(0, 0);
            this.playersPanel.Name = "playersPanel";
            this.playersPanel.Size = new System.Drawing.Size(1254, 776);
            this.playersPanel.TabIndex = 0;
            this.playersPanel.Visible = false;
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printCurrentEventToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // printCurrentEventToolStripMenuItem
            // 
            this.printCurrentEventToolStripMenuItem.Name = "printCurrentEventToolStripMenuItem";
            this.printCurrentEventToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printCurrentEventToolStripMenuItem.Text = "Print Current Event";
            this.printCurrentEventToolStripMenuItem.Click += new System.EventHandler(this.menuPrintCurrentEvent);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 815);
            this.Controls.Add(this.tableRoot);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableRoot.ResumeLayout(false);
            this.tableRoot.PerformLayout();
            this.panelContents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuVPlayers;
        private System.Windows.Forms.ToolStripMenuItem menuVEvents;
        private System.Windows.Forms.ToolStripMenuItem menuEvents;
        private System.Windows.Forms.ToolStripMenuItem menuActionAddEvent;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TableLayoutPanel tableRoot;
        private System.Windows.Forms.Panel panelContents;
        private Components.PlayersPanel playersPanel;
        private Components.EventsPanel eventsPanel;
        private Components.EditEventPanel editEventPanel;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printCurrentEventToolStripMenuItem;
    }
}
