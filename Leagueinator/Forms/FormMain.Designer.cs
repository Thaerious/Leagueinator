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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActionAddEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.selectEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPrevRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignLanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundRobinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCurrentRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCurrentEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevTeamSumWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelContents = new System.Windows.Forms.Panel();
            this.editEventPanel = new Leagueinator.Components.EditEventPanel();
            this.butAddEvent = new System.Windows.Forms.Button();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.menuStrip.SuspendLayout();
            this.tableRoot.SuspendLayout();
            this.panelContents.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_New);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_Load);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_SaveAs);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_Print);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_Close);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Menu_File_Exit);
            // 
            // menuEvents
            // 
            this.menuEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuActionAddEvent,
            this.selectEventToolStripMenuItem,
            this.addPlayerToolStripMenuItem,
            this.assignPlayersToolStripMenuItem,
            this.assignLanesToolStripMenuItem,
            this.assignMatchesToolStripMenuItem});
            this.menuEvents.Name = "menuEvents";
            this.menuEvents.Size = new System.Drawing.Size(79, 29);
            this.menuEvents.Text = "&Events";
            // 
            // menuActionAddEvent
            // 
            this.menuActionAddEvent.Name = "menuActionAddEvent";
            this.menuActionAddEvent.Size = new System.Drawing.Size(238, 34);
            this.menuActionAddEvent.Text = "Add Event";
            this.menuActionAddEvent.Click += new System.EventHandler(this.Menu_Events_Add);
            // 
            // selectEventToolStripMenuItem
            // 
            this.selectEventToolStripMenuItem.Name = "selectEventToolStripMenuItem";
            this.selectEventToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.selectEventToolStripMenuItem.Text = "Select Event";
            this.selectEventToolStripMenuItem.Click += new System.EventHandler(this.Menu_Event_Select);
            // 
            // addPlayerToolStripMenuItem
            // 
            this.addPlayerToolStripMenuItem.Name = "addPlayerToolStripMenuItem";
            this.addPlayerToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.addPlayerToolStripMenuItem.Text = "Add Player";
            this.addPlayerToolStripMenuItem.Click += new System.EventHandler(this.Menu_Event_AddPlayer);
            // 
            // assignPlayersToolStripMenuItem
            // 
            this.assignPlayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.rToolStripMenuItem,
            this.copyPrevRoundToolStripMenuItem,
            this.randomizeToolStripMenuItem});
            this.assignPlayersToolStripMenuItem.Name = "assignPlayersToolStripMenuItem";
            this.assignPlayersToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.assignPlayersToolStripMenuItem.Text = "Assign Players";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.Menu_Events_Assign_Clear);
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.rToolStripMenuItem.Text = "Assign Partners";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.Menu_Events_Assign_Partners);
            // 
            // copyPrevRoundToolStripMenuItem
            // 
            this.copyPrevRoundToolStripMenuItem.Name = "copyPrevRoundToolStripMenuItem";
            this.copyPrevRoundToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.copyPrevRoundToolStripMenuItem.Text = "Copy Prev Round";
            this.copyPrevRoundToolStripMenuItem.Click += new System.EventHandler(this.Menu_Events_Assign_Copy);
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(252, 34);
            this.randomizeToolStripMenuItem.Text = "Randomize";
            this.randomizeToolStripMenuItem.Click += new System.EventHandler(this.randomizeToolStripMenuItem_Click);
            // 
            // assignLanesToolStripMenuItem
            // 
            this.assignLanesToolStripMenuItem.Name = "assignLanesToolStripMenuItem";
            this.assignLanesToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.assignLanesToolStripMenuItem.Text = "Assign Lanes";
            this.assignLanesToolStripMenuItem.Click += new System.EventHandler(this.Menu_Event_AssignLanes);
            // 
            // assignMatchesToolStripMenuItem
            // 
            this.assignMatchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roundRobinToolStripMenuItem});
            this.assignMatchesToolStripMenuItem.Name = "assignMatchesToolStripMenuItem";
            this.assignMatchesToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.assignMatchesToolStripMenuItem.Text = "Assign Matches";
            // 
            // roundRobinToolStripMenuItem
            // 
            this.roundRobinToolStripMenuItem.Name = "roundRobinToolStripMenuItem";
            this.roundRobinToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.roundRobinToolStripMenuItem.Text = "Round Robin";
            this.roundRobinToolStripMenuItem.Click += new System.EventHandler(this.roundRobinToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuEvents,
            this.actionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1260, 33);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printCurrentRoundToolStripMenuItem,
            this.printCurrentEventToolStripMenuItem,
            this.printLeagueToolStripMenuItem,
            this.prevTeamSumWeightToolStripMenuItem,
            this.printPlayersToolStripMenuItem,
            this.refreshRoundToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.actionsToolStripMenuItem.Text = "Dev";
            // 
            // printCurrentRoundToolStripMenuItem
            // 
            this.printCurrentRoundToolStripMenuItem.Name = "printCurrentRoundToolStripMenuItem";
            this.printCurrentRoundToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printCurrentRoundToolStripMenuItem.Text = "Print Current Round";
            this.printCurrentRoundToolStripMenuItem.Click += new System.EventHandler(this.Menu_Dev_PrintRound);
            // 
            // printCurrentEventToolStripMenuItem
            // 
            this.printCurrentEventToolStripMenuItem.Name = "printCurrentEventToolStripMenuItem";
            this.printCurrentEventToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printCurrentEventToolStripMenuItem.Text = "Print Current Event";
            this.printCurrentEventToolStripMenuItem.Click += new System.EventHandler(this.menuPrintCurrentEvent);
            // 
            // printLeagueToolStripMenuItem
            // 
            this.printLeagueToolStripMenuItem.Name = "printLeagueToolStripMenuItem";
            this.printLeagueToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printLeagueToolStripMenuItem.Text = "Print League";
            this.printLeagueToolStripMenuItem.Click += new System.EventHandler(this.menuActionsPrintLeague);
            // 
            // prevTeamSumWeightToolStripMenuItem
            // 
            this.prevTeamSumWeightToolStripMenuItem.Name = "prevTeamSumWeightToolStripMenuItem";
            this.prevTeamSumWeightToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.prevTeamSumWeightToolStripMenuItem.Text = "Evaluate Round";
            this.prevTeamSumWeightToolStripMenuItem.Click += new System.EventHandler(this.Menu_Dev_EvaluateRound);
            // 
            // printPlayersToolStripMenuItem
            // 
            this.printPlayersToolStripMenuItem.Name = "printPlayersToolStripMenuItem";
            this.printPlayersToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printPlayersToolStripMenuItem.Text = "Print Players";
            this.printPlayersToolStripMenuItem.Click += new System.EventHandler(this.Menu_Dev_PrintPlayers);
            // 
            // refreshRoundToolStripMenuItem
            // 
            this.refreshRoundToolStripMenuItem.Name = "refreshRoundToolStripMenuItem";
            this.refreshRoundToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.refreshRoundToolStripMenuItem.Text = "Refresh Round";
            this.refreshRoundToolStripMenuItem.Click += new System.EventHandler(this.refreshRoundToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.Menu_Help_About);
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
            this.panelContents.Controls.Add(this.butAddEvent);
            this.panelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContents.Location = new System.Drawing.Point(3, 36);
            this.panelContents.Name = "panelContents";
            this.panelContents.Size = new System.Drawing.Size(1254, 776);
            this.panelContents.TabIndex = 3;
            // 
            // editEventPanel
            // 
            this.editEventPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editEventPanel.LeagueEvent = null;
            this.editEventPanel.Location = new System.Drawing.Point(0, 0);
            this.editEventPanel.Name = "editEventPanel";
            this.editEventPanel.Size = new System.Drawing.Size(1254, 776);
            this.editEventPanel.TabIndex = 0;
            this.editEventPanel.Visible = false;
            // 
            // butAddEvent
            // 
            this.butAddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAddEvent.Location = new System.Drawing.Point(485, 322);
            this.butAddEvent.Name = "butAddEvent";
            this.butAddEvent.Size = new System.Drawing.Size(316, 56);
            this.butAddEvent.TabIndex = 1;
            this.butAddEvent.Text = "Add Event";
            this.butAddEvent.UseVisualStyleBackColor = true;
            this.butAddEvent.Click += new System.EventHandler(this.butAddEvent_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(147, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(147, 32);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 68);
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "printPreview";
            this.printPreview.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 815);
            this.Controls.Add(this.tableRoot);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Leaguinator";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableRoot.ResumeLayout(false);
            this.tableRoot.PerformLayout();
            this.panelContents.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuEvents;
        private System.Windows.Forms.ToolStripMenuItem menuActionAddEvent;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TableLayoutPanel tableRoot;
        private System.Windows.Forms.Panel panelContents;
        private Components.EditEventPanel editEventPanel;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printCurrentEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printCurrentRoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevTeamSumWeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPrevRoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshRoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem assignLanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.Button butAddEvent;
        private System.Windows.Forms.ToolStripMenuItem assignMatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundRobinToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}
