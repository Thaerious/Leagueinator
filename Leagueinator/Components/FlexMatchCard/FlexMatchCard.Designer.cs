namespace Leagueinator.Components {
    partial class FlexMatchCard {
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
            this.panelRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelScore0 = new System.Windows.Forms.Panel();
            this.labelScore0 = new System.Windows.Forms.Label();
            this.panelNames0 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelP1 = new Leagueinator.Components.MatchLabel();
            this.labelP0 = new Leagueinator.Components.MatchLabel();
            this.panelLane = new System.Windows.Forms.Panel();
            this.labelLane = new System.Windows.Forms.Label();
            this.panelNames1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelP3 = new Leagueinator.Components.MatchLabel();
            this.labelP2 = new Leagueinator.Components.MatchLabel();
            this.panelScore1 = new System.Windows.Forms.Panel();
            this.labelScore1 = new System.Windows.Forms.Label();
            this.panelRoot.SuspendLayout();
            this.panelScore0.SuspendLayout();
            this.panelNames0.SuspendLayout();
            this.panelLane.SuspendLayout();
            this.panelNames1.SuspendLayout();
            this.panelScore1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRoot
            // 
            this.panelRoot.ColumnCount = 5;
            this.panelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.panelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.panelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.panelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.panelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.panelRoot.Controls.Add(this.panelScore0, 0, 0);
            this.panelRoot.Controls.Add(this.panelNames0, 1, 0);
            this.panelRoot.Controls.Add(this.panelLane, 2, 0);
            this.panelRoot.Controls.Add(this.panelNames1, 3, 0);
            this.panelRoot.Controls.Add(this.panelScore1, 4, 0);
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.RowCount = 1;
            this.panelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRoot.Size = new System.Drawing.Size(400, 201);
            this.panelRoot.TabIndex = 5;
            // 
            // panelScore0
            // 
            this.panelScore0.Controls.Add(this.labelScore0);
            this.panelScore0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore0.Location = new System.Drawing.Point(3, 3);
            this.panelScore0.Name = "panelScore0";
            this.panelScore0.Size = new System.Drawing.Size(51, 195);
            this.panelScore0.TabIndex = 0;
            // 
            // labelScore0
            // 
            this.labelScore0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelScore0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelScore0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore0.Location = new System.Drawing.Point(12, 83);
            this.labelScore0.Name = "labelScore0";
            this.labelScore0.Size = new System.Drawing.Size(27, 29);
            this.labelScore0.TabIndex = 5;
            // 
            // panelNames0
            // 
            this.panelNames0.Controls.Add(this.labelP1);
            this.panelNames0.Controls.Add(this.labelP0);
            this.panelNames0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNames0.Location = new System.Drawing.Point(60, 3);
            this.panelNames0.Name = "panelNames0";
            this.panelNames0.Size = new System.Drawing.Size(108, 195);
            this.panelNames0.TabIndex = 6;
            // 
            // labelP1
            // 
            this.labelP1.AllowDrop = true;
            this.labelP1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelP1.AutoEllipsis = true;
            this.labelP1.BackColor = System.Drawing.Color.White;
            this.labelP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.Location = new System.Drawing.Point(3, 0);
            this.labelP1.Name = "labelP1";
            this.labelP1.PlayerInfo = null;
            this.labelP1.Position = 1;
            this.labelP1.Size = new System.Drawing.Size(113, 29);
            this.labelP1.TabIndex = 1;
            this.labelP1.Team = 0;
            this.labelP1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP1.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP0
            // 
            this.labelP0.AllowDrop = true;
            this.labelP0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelP0.AutoEllipsis = true;
            this.labelP0.BackColor = System.Drawing.Color.White;
            this.labelP0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP0.Location = new System.Drawing.Point(3, 29);
            this.labelP0.Name = "labelP0";
            this.labelP0.PlayerInfo = null;
            this.labelP0.Position = 0;
            this.labelP0.Size = new System.Drawing.Size(113, 29);
            this.labelP0.TabIndex = 0;
            this.labelP0.Team = 0;
            this.labelP0.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP0.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // panelLane
            // 
            this.panelLane.Controls.Add(this.labelLane);
            this.panelLane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLane.Location = new System.Drawing.Point(174, 3);
            this.panelLane.Name = "panelLane";
            this.panelLane.Size = new System.Drawing.Size(51, 195);
            this.panelLane.TabIndex = 2;
            // 
            // labelLane
            // 
            this.labelLane.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelLane.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLane.Location = new System.Drawing.Point(12, 83);
            this.labelLane.Name = "labelLane";
            this.labelLane.Size = new System.Drawing.Size(27, 29);
            this.labelLane.TabIndex = 7;
            this.labelLane.Text = "0";
            this.labelLane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelNames1
            // 
            this.panelNames1.Controls.Add(this.labelP3);
            this.panelNames1.Controls.Add(this.labelP2);
            this.panelNames1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNames1.Location = new System.Drawing.Point(231, 3);
            this.panelNames1.Name = "panelNames1";
            this.panelNames1.Size = new System.Drawing.Size(108, 195);
            this.panelNames1.TabIndex = 7;
            // 
            // labelP3
            // 
            this.labelP3.AllowDrop = true;
            this.labelP3.AutoEllipsis = true;
            this.labelP3.BackColor = System.Drawing.Color.White;
            this.labelP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP3.Location = new System.Drawing.Point(3, 0);
            this.labelP3.Name = "labelP3";
            this.labelP3.PlayerInfo = null;
            this.labelP3.Position = 1;
            this.labelP3.Size = new System.Drawing.Size(113, 29);
            this.labelP3.TabIndex = 3;
            this.labelP3.Team = 1;
            this.labelP3.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP3.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP2
            // 
            this.labelP2.AllowDrop = true;
            this.labelP2.AutoEllipsis = true;
            this.labelP2.BackColor = System.Drawing.Color.White;
            this.labelP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.Location = new System.Drawing.Point(3, 29);
            this.labelP2.Name = "labelP2";
            this.labelP2.PlayerInfo = null;
            this.labelP2.Position = 0;
            this.labelP2.Size = new System.Drawing.Size(113, 29);
            this.labelP2.TabIndex = 2;
            this.labelP2.Team = 1;
            this.labelP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP2.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // panelScore1
            // 
            this.panelScore1.Controls.Add(this.labelScore1);
            this.panelScore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScore1.Location = new System.Drawing.Point(345, 3);
            this.panelScore1.Name = "panelScore1";
            this.panelScore1.Size = new System.Drawing.Size(52, 195);
            this.panelScore1.TabIndex = 1;
            // 
            // labelScore1
            // 
            this.labelScore1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelScore1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore1.Location = new System.Drawing.Point(13, 83);
            this.labelScore1.Name = "labelScore1";
            this.labelScore1.Size = new System.Drawing.Size(27, 29);
            this.labelScore1.TabIndex = 6;
            // 
            // FlexMatchCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panelRoot);
            this.Name = "FlexMatchCard";
            this.Size = new System.Drawing.Size(400, 201);
            this.panelRoot.ResumeLayout(false);
            this.panelScore0.ResumeLayout(false);
            this.panelNames0.ResumeLayout(false);
            this.panelLane.ResumeLayout(false);
            this.panelNames1.ResumeLayout(false);
            this.panelScore1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MatchLabel labelP0;
        private MatchLabel labelP1;
        private MatchLabel labelP3;
        private MatchLabel labelP2;
        private System.Windows.Forms.TableLayoutPanel panelRoot;
        private System.Windows.Forms.Panel panelScore1;
        private System.Windows.Forms.Panel panelLane;
        private System.Windows.Forms.Panel panelScore0;
        private System.Windows.Forms.FlowLayoutPanel panelNames0;
        private System.Windows.Forms.FlowLayoutPanel panelNames1;
        private System.Windows.Forms.Label labelScore0;
        private System.Windows.Forms.Label labelScore1;
        private System.Windows.Forms.Label labelLane;
    }
}
