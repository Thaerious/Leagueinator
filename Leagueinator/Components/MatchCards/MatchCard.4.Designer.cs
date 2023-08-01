namespace Leagueinator.Components {
    partial class MatchCard_4 {
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
        public override void InitializeComponent() {
            this.labelLane = new System.Windows.Forms.Label();
            this.labelP1 = new Leagueinator.Components.MatchLabel();
            this.labelP0 = new Leagueinator.Components.MatchLabel();
            this.txtScore0 = new System.Windows.Forms.TextBox();
            this.labelP5 = new Leagueinator.Components.MatchLabel();
            this.labelP4 = new Leagueinator.Components.MatchLabel();
            this.txtScore1 = new System.Windows.Forms.TextBox();
            this.labelP6 = new Leagueinator.Components.MatchLabel();
            this.labelP2 = new Leagueinator.Components.MatchLabel();
            this.labelP7 = new Leagueinator.Components.MatchLabel();
            this.labelP3 = new Leagueinator.Components.MatchLabel();
            this.SuspendLayout();
            // 
            // labelLane
            // 
            this.labelLane.AutoSize = true;
            this.labelLane.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLane.Location = new System.Drawing.Point(172, 49);
            this.labelLane.Name = "labelLane";
            this.labelLane.Size = new System.Drawing.Size(27, 29);
            this.labelLane.TabIndex = 4;
            this.labelLane.Text = "1";
            // 
            // labelP1
            // 
            this.labelP1.AllowDrop = true;
            this.labelP1.AutoEllipsis = true;
            this.labelP1.BackColor = System.Drawing.Color.White;
            this.labelP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.Location = new System.Drawing.Point(56, 32);
            this.labelP1.Margin = new System.Windows.Forms.Padding(0);
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
            this.labelP0.AutoEllipsis = true;
            this.labelP0.BackColor = System.Drawing.Color.White;
            this.labelP0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP0.Location = new System.Drawing.Point(56, 3);
            this.labelP0.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
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
            // txtScore0
            // 
            this.txtScore0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore0.Location = new System.Drawing.Point(3, 46);
            this.txtScore0.Name = "txtScore0";
            this.txtScore0.Size = new System.Drawing.Size(50, 35);
            this.txtScore0.TabIndex = 5;
            this.txtScore0.Text = "0";
            this.txtScore0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelP5
            // 
            this.labelP5.AllowDrop = true;
            this.labelP5.AutoEllipsis = true;
            this.labelP5.BackColor = System.Drawing.Color.White;
            this.labelP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP5.Location = new System.Drawing.Point(202, 32);
            this.labelP5.Margin = new System.Windows.Forms.Padding(0);
            this.labelP5.Name = "labelP5";
            this.labelP5.PlayerInfo = null;
            this.labelP5.Position = 1;
            this.labelP5.Size = new System.Drawing.Size(113, 29);
            this.labelP5.TabIndex = 7;
            this.labelP5.Team = 1;
            this.labelP5.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP5.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP4
            // 
            this.labelP4.AllowDrop = true;
            this.labelP4.AutoEllipsis = true;
            this.labelP4.BackColor = System.Drawing.Color.White;
            this.labelP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP4.Location = new System.Drawing.Point(202, 3);
            this.labelP4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelP4.Name = "labelP4";
            this.labelP4.PlayerInfo = null;
            this.labelP4.Position = 0;
            this.labelP4.Size = new System.Drawing.Size(113, 29);
            this.labelP4.TabIndex = 6;
            this.labelP4.Team = 1;
            this.labelP4.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP4.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // txtScore1
            // 
            this.txtScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore1.Location = new System.Drawing.Point(318, 46);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(50, 35);
            this.txtScore1.TabIndex = 8;
            this.txtScore1.Text = "0";
            this.txtScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelP6
            // 
            this.labelP6.AllowDrop = true;
            this.labelP6.AutoEllipsis = true;
            this.labelP6.BackColor = System.Drawing.Color.White;
            this.labelP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP6.Location = new System.Drawing.Point(202, 61);
            this.labelP6.Margin = new System.Windows.Forms.Padding(0);
            this.labelP6.Name = "labelP6";
            this.labelP6.PlayerInfo = null;
            this.labelP6.Position = 2;
            this.labelP6.Size = new System.Drawing.Size(113, 29);
            this.labelP6.TabIndex = 10;
            this.labelP6.Team = 1;
            this.labelP6.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP6.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP2
            // 
            this.labelP2.AllowDrop = true;
            this.labelP2.AutoEllipsis = true;
            this.labelP2.BackColor = System.Drawing.Color.White;
            this.labelP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.Location = new System.Drawing.Point(56, 61);
            this.labelP2.Margin = new System.Windows.Forms.Padding(0);
            this.labelP2.Name = "labelP2";
            this.labelP2.PlayerInfo = null;
            this.labelP2.Position = 2;
            this.labelP2.Size = new System.Drawing.Size(113, 29);
            this.labelP2.TabIndex = 9;
            this.labelP2.Team = 0;
            this.labelP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP2.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP7
            // 
            this.labelP7.AllowDrop = true;
            this.labelP7.AutoEllipsis = true;
            this.labelP7.BackColor = System.Drawing.Color.White;
            this.labelP7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP7.Location = new System.Drawing.Point(202, 90);
            this.labelP7.Margin = new System.Windows.Forms.Padding(0);
            this.labelP7.Name = "labelP7";
            this.labelP7.PlayerInfo = null;
            this.labelP7.Position = 3;
            this.labelP7.Size = new System.Drawing.Size(113, 29);
            this.labelP7.TabIndex = 12;
            this.labelP7.Team = 1;
            this.labelP7.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP7.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // labelP3
            // 
            this.labelP3.AllowDrop = true;
            this.labelP3.AutoEllipsis = true;
            this.labelP3.BackColor = System.Drawing.Color.White;
            this.labelP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP3.Location = new System.Drawing.Point(56, 90);
            this.labelP3.Margin = new System.Windows.Forms.Padding(0);
            this.labelP3.Name = "labelP3";
            this.labelP3.PlayerInfo = null;
            this.labelP3.Position = 3;
            this.labelP3.Size = new System.Drawing.Size(113, 29);
            this.labelP3.TabIndex = 11;
            this.labelP3.Team = 0;
            this.labelP3.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP3.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // MatchCard_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.labelP7);
            this.Controls.Add(this.labelP3);
            this.Controls.Add(this.labelP6);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.txtScore1);
            this.Controls.Add(this.labelP5);
            this.Controls.Add(this.labelP4);
            this.Controls.Add(this.txtScore0);
            this.Controls.Add(this.labelLane);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.labelP0);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MatchCard_4";
            this.Size = new System.Drawing.Size(373, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatchLabel labelP0;
        private MatchLabel labelP1;
        private new System.Windows.Forms.Label labelLane;
        private System.Windows.Forms.TextBox txtScore0;
        private MatchLabel labelP5;
        private MatchLabel labelP4;
        private System.Windows.Forms.TextBox txtScore1;
        private MatchLabel labelP6;
        private MatchLabel labelP2;
        private MatchLabel labelP7;
        private MatchLabel labelP3;
    }
}
