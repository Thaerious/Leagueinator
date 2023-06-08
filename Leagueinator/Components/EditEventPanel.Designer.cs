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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.butAddRound = new System.Windows.Forms.Button();
            this.butRemoveRound = new System.Windows.Forms.Button();
            this.flowRounds = new System.Windows.Forms.FlowLayoutPanel();
            this.tablePlayers = new System.Windows.Forms.TableLayoutPanel();
            this.flowMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tablePlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.butAddRound, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.butRemoveRound, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowRounds, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 751);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // butAddRound
            // 
            this.butAddRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butAddRound.Location = new System.Drawing.Point(4, 652);
            this.butAddRound.Name = "butAddRound";
            this.butAddRound.Size = new System.Drawing.Size(321, 44);
            this.butAddRound.TabIndex = 0;
            this.butAddRound.Text = "Add";
            this.butAddRound.UseVisualStyleBackColor = true;
            this.butAddRound.Click += new System.EventHandler(this.AddRound);
            // 
            // butRemoveRound
            // 
            this.butRemoveRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butRemoveRound.Location = new System.Drawing.Point(4, 703);
            this.butRemoveRound.Name = "butRemoveRound";
            this.butRemoveRound.Size = new System.Drawing.Size(321, 44);
            this.butRemoveRound.TabIndex = 1;
            this.butRemoveRound.Text = "Remove";
            this.butRemoveRound.UseVisualStyleBackColor = true;
            this.butRemoveRound.Click += new System.EventHandler(this.RemoveRound);
            // 
            // flowRounds
            // 
            this.flowRounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRounds.Location = new System.Drawing.Point(4, 4);
            this.flowRounds.Name = "flowRounds";
            this.flowRounds.Size = new System.Drawing.Size(321, 641);
            this.flowRounds.TabIndex = 2;
            // 
            // tablePlayers
            // 
            this.tablePlayers.ColumnCount = 1;
            this.tablePlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePlayers.Controls.Add(this.listBox2, 0, 1);
            this.tablePlayers.Controls.Add(this.listBox1, 0, 0);
            this.tablePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePlayers.Location = new System.Drawing.Point(0, 0);
            this.tablePlayers.Name = "tablePlayers";
            this.tablePlayers.RowCount = 2;
            this.tablePlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePlayers.Size = new System.Drawing.Size(808, 751);
            this.tablePlayers.TabIndex = 1;
            // 
            // flowMatches
            // 
            this.flowMatches.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowMatches.Location = new System.Drawing.Point(808, 0);
            this.flowMatches.Name = "flowMatches";
            this.flowMatches.Size = new System.Drawing.Size(322, 751);
            this.flowMatches.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(802, 369);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(3, 378);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(802, 370);
            this.listBox2.TabIndex = 1;
            // 
            // EditEventPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tablePlayers);
            this.Controls.Add(this.flowMatches);
            this.Name = "EditEventPanel";
            this.Size = new System.Drawing.Size(1130, 751);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tablePlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button butAddRound;
        private System.Windows.Forms.Button butRemoveRound;
        private System.Windows.Forms.FlowLayoutPanel flowRounds;
        private System.Windows.Forms.TableLayoutPanel tablePlayers;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FlowLayoutPanel flowMatches;
    }
}
