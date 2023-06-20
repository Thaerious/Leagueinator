namespace Leagueinator.Components {
    partial class EditEventPanel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.layoutRounds = new System.Windows.Forms.TableLayoutPanel();
            this.butAddRound = new System.Windows.Forms.Button();
            this.butRemoveRound = new System.Windows.Forms.Button();
            this.flowRounds = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.matchCard5 = new Leagueinator.Components.MatchCard();
            this.matchCard6 = new Leagueinator.Components.MatchCard();
            this.matchCard7 = new Leagueinator.Components.MatchCard();
            this.matchCard8 = new Leagueinator.Components.MatchCard();
            this.matchCard3 = new Leagueinator.Components.MatchCard();
            this.matchCard4 = new Leagueinator.Components.MatchCard();
            this.matchCard2 = new Leagueinator.Components.MatchCard();
            this.matchCard1 = new Leagueinator.Components.MatchCard();
            this.playerListBox = new Leagueinator.Components.PlayerListBox(this.components);
            this.layoutRounds.SuspendLayout();
            this.layoutRoot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutRounds
            // 
            this.layoutRounds.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.layoutRounds.ColumnCount = 1;
            this.layoutRounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRounds.Controls.Add(this.butAddRound, 0, 1);
            this.layoutRounds.Controls.Add(this.butRemoveRound, 0, 2);
            this.layoutRounds.Controls.Add(this.flowRounds, 0, 0);
            this.layoutRounds.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutRounds.Location = new System.Drawing.Point(3, 3);
            this.layoutRounds.Name = "layoutRounds";
            this.layoutRounds.RowCount = 4;
            this.layoutRounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layoutRounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layoutRounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutRounds.Size = new System.Drawing.Size(370, 745);
            this.layoutRounds.TabIndex = 0;
            // 
            // butAddRound
            // 
            this.butAddRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butAddRound.Location = new System.Drawing.Point(4, 625);
            this.butAddRound.Name = "butAddRound";
            this.butAddRound.Size = new System.Drawing.Size(362, 44);
            this.butAddRound.TabIndex = 0;
            this.butAddRound.Text = "Add";
            this.butAddRound.UseVisualStyleBackColor = true;
            this.butAddRound.Click += new System.EventHandler(this.AddRoundHnd);
            // 
            // butRemoveRound
            // 
            this.butRemoveRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butRemoveRound.Location = new System.Drawing.Point(4, 676);
            this.butRemoveRound.Name = "butRemoveRound";
            this.butRemoveRound.Size = new System.Drawing.Size(362, 44);
            this.butRemoveRound.TabIndex = 1;
            this.butRemoveRound.Text = "Remove";
            this.butRemoveRound.UseVisualStyleBackColor = true;
            this.butRemoveRound.Click += new System.EventHandler(this.RemoveRoundHnd);
            // 
            // flowRounds
            // 
            this.flowRounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRounds.Location = new System.Drawing.Point(4, 4);
            this.flowRounds.Name = "flowRounds";
            this.flowRounds.Size = new System.Drawing.Size(362, 614);
            this.flowRounds.TabIndex = 2;
            // 
            // layoutRoot
            // 
            this.layoutRoot.ColumnCount = 3;
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutRoot.Controls.Add(this.panel1, 2, 0);
            this.layoutRoot.Controls.Add(this.playerListBox, 0, 0);
            this.layoutRoot.Controls.Add(this.layoutRounds, 0, 0);
            this.layoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutRoot.Name = "layoutRoot";
            this.layoutRoot.RowCount = 1;
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 751F));
            this.layoutRoot.Size = new System.Drawing.Size(1130, 751);
            this.layoutRoot.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.matchCard5);
            this.panel1.Controls.Add(this.matchCard6);
            this.panel1.Controls.Add(this.matchCard7);
            this.panel1.Controls.Add(this.matchCard8);
            this.panel1.Controls.Add(this.matchCard3);
            this.panel1.Controls.Add(this.matchCard4);
            this.panel1.Controls.Add(this.matchCard2);
            this.panel1.Controls.Add(this.matchCard1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(773, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 745);
            this.panel1.TabIndex = 1;
            // 
            // matchCard5
            // 
            this.matchCard5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard5.Lane = 8;
            this.matchCard5.Location = new System.Drawing.Point(43, 579);
            this.matchCard5.Match = null;
            this.matchCard5.Name = "matchCard5";
            this.matchCard5.Size = new System.Drawing.Size(273, 74);
            this.matchCard5.TabIndex = 7;
            // 
            // matchCard6
            // 
            this.matchCard6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard6.Lane = 7;
            this.matchCard6.Location = new System.Drawing.Point(43, 499);
            this.matchCard6.Match = null;
            this.matchCard6.Name = "matchCard6";
            this.matchCard6.Size = new System.Drawing.Size(273, 74);
            this.matchCard6.TabIndex = 6;
            // 
            // matchCard7
            // 
            this.matchCard7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard7.Lane = 6;
            this.matchCard7.Location = new System.Drawing.Point(43, 419);
            this.matchCard7.Match = null;
            this.matchCard7.Name = "matchCard7";
            this.matchCard7.Size = new System.Drawing.Size(273, 74);
            this.matchCard7.TabIndex = 5;
            // 
            // matchCard8
            // 
            this.matchCard8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard8.Lane = 5;
            this.matchCard8.Location = new System.Drawing.Point(43, 339);
            this.matchCard8.Match = null;
            this.matchCard8.Name = "matchCard8";
            this.matchCard8.Size = new System.Drawing.Size(273, 74);
            this.matchCard8.TabIndex = 4;
            // 
            // matchCard3
            // 
            this.matchCard3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard3.Lane = 4;
            this.matchCard3.Location = new System.Drawing.Point(43, 259);
            this.matchCard3.Match = null;
            this.matchCard3.Name = "matchCard3";
            this.matchCard3.Size = new System.Drawing.Size(273, 74);
            this.matchCard3.TabIndex = 3;
            // 
            // matchCard4
            // 
            this.matchCard4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard4.Lane = 3;
            this.matchCard4.Location = new System.Drawing.Point(43, 179);
            this.matchCard4.Match = null;
            this.matchCard4.Name = "matchCard4";
            this.matchCard4.Size = new System.Drawing.Size(273, 74);
            this.matchCard4.TabIndex = 2;
            // 
            // matchCard2
            // 
            this.matchCard2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard2.Lane = 2;
            this.matchCard2.Location = new System.Drawing.Point(43, 99);
            this.matchCard2.Match = null;
            this.matchCard2.Name = "matchCard2";
            this.matchCard2.Size = new System.Drawing.Size(273, 74);
            this.matchCard2.TabIndex = 1;
            // 
            // matchCard1
            // 
            this.matchCard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchCard1.Lane = 1;
            this.matchCard1.Location = new System.Drawing.Point(43, 19);
            this.matchCard1.Match = null;
            this.matchCard1.Name = "matchCard1";
            this.matchCard1.Size = new System.Drawing.Size(273, 74);
            this.matchCard1.TabIndex = 0;
            // 
            // playerListBox
            // 
            this.playerListBox.AllowDrop = true;
            this.playerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.ItemHeight = 32;
            this.playerListBox.Location = new System.Drawing.Point(379, 3);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.PlayerInfo = null;
            this.playerListBox.Round = null;
            this.playerListBox.Size = new System.Drawing.Size(370, 745);
            this.playerListBox.TabIndex = 0;
            // 
            // EditEventPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutRoot);
            this.Name = "EditEventPanel";
            this.Size = new System.Drawing.Size(1130, 751);
            this.layoutRounds.ResumeLayout(false);
            this.layoutRoot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutRounds;
        private System.Windows.Forms.Button butAddRound;
        private System.Windows.Forms.Button butRemoveRound;
        private System.Windows.Forms.FlowLayoutPanel flowRounds;
        private System.Windows.Forms.TableLayoutPanel layoutRoot;
        private PlayerListBox playerListBox;
        private System.Windows.Forms.Panel panel1;
        private MatchCard matchCard1;
        private MatchCard matchCard2;
        private MatchCard matchCard5;
        private MatchCard matchCard6;
        private MatchCard matchCard7;
        private MatchCard matchCard8;
        private MatchCard matchCard3;
        private MatchCard matchCard4;
    }
}
