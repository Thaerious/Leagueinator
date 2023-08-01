namespace Leagueinator.Components {
    partial class MatchCard_2 {
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
            this.labelP3 = new Leagueinator.Components.MatchLabel();
            this.labelP2 = new Leagueinator.Components.MatchLabel();
            this.txtScore1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelLane
            // 
            this.labelLane.AutoSize = true;
            this.labelLane.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLane.Location = new System.Drawing.Point(172, 19);
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
            this.txtScore0.Location = new System.Drawing.Point(3, 16);
            this.txtScore0.Name = "txtScore0";
            this.txtScore0.Size = new System.Drawing.Size(50, 35);
            this.txtScore0.TabIndex = 5;
            this.txtScore0.Text = "0";
            this.txtScore0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelP3
            // 
            this.labelP3.AllowDrop = true;
            this.labelP3.AutoEllipsis = true;
            this.labelP3.BackColor = System.Drawing.Color.White;
            this.labelP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP3.Location = new System.Drawing.Point(202, 32);
            this.labelP3.Margin = new System.Windows.Forms.Padding(0);
            this.labelP3.Name = "labelP3";
            this.labelP3.PlayerInfo = null;
            this.labelP3.Position = 1;
            this.labelP3.Size = new System.Drawing.Size(113, 29);
            this.labelP3.TabIndex = 7;
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
            this.labelP2.Location = new System.Drawing.Point(202, 3);
            this.labelP2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelP2.Name = "labelP2";
            this.labelP2.PlayerInfo = null;
            this.labelP2.Position = 0;
            this.labelP2.Size = new System.Drawing.Size(113, 29);
            this.labelP2.TabIndex = 6;
            this.labelP2.Team = 1;
            this.labelP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP2.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // txtScore1
            // 
            this.txtScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore1.Location = new System.Drawing.Point(318, 16);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(50, 35);
            this.txtScore1.TabIndex = 8;
            this.txtScore1.Text = "0";
            this.txtScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MatchCard_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.txtScore1);
            this.Controls.Add(this.labelP3);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.txtScore0);
            this.Controls.Add(this.labelLane);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.labelP0);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MatchCard_2";
            this.Size = new System.Drawing.Size(373, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatchLabel labelP0;
        private MatchLabel labelP1;
        private new System.Windows.Forms.Label labelLane;
        private System.Windows.Forms.TextBox txtScore0;
        private MatchLabel labelP3;
        private MatchLabel labelP2;
        private System.Windows.Forms.TextBox txtScore1;
    }
}
