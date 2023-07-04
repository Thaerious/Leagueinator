namespace Leagueinator.Components {
    partial class MatchCard_3 {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.matchLabel1 = new Leagueinator.Components.MatchLabel();
            this.matchLabel2 = new Leagueinator.Components.MatchLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.matchLabel3 = new Leagueinator.Components.MatchLabel();
            this.matchLabel4 = new Leagueinator.Components.MatchLabel();
            this.SuspendLayout();
            // 
            // labelLane
            // 
            this.labelLane.AutoSize = true;
            this.labelLane.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLane.Location = new System.Drawing.Point(172, 30);
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 35);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // matchLabel1
            // 
            this.matchLabel1.AllowDrop = true;
            this.matchLabel1.AutoEllipsis = true;
            this.matchLabel1.BackColor = System.Drawing.Color.White;
            this.matchLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchLabel1.Location = new System.Drawing.Point(202, 32);
            this.matchLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.matchLabel1.Name = "matchLabel1";
            this.matchLabel1.PlayerInfo = null;
            this.matchLabel1.Position = 1;
            this.matchLabel1.Size = new System.Drawing.Size(113, 29);
            this.matchLabel1.TabIndex = 7;
            this.matchLabel1.Team = 0;
            // 
            // matchLabel2
            // 
            this.matchLabel2.AllowDrop = true;
            this.matchLabel2.AutoEllipsis = true;
            this.matchLabel2.BackColor = System.Drawing.Color.White;
            this.matchLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchLabel2.Location = new System.Drawing.Point(202, 3);
            this.matchLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.matchLabel2.Name = "matchLabel2";
            this.matchLabel2.PlayerInfo = null;
            this.matchLabel2.Position = 0;
            this.matchLabel2.Size = new System.Drawing.Size(113, 29);
            this.matchLabel2.TabIndex = 6;
            this.matchLabel2.Team = 0;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(318, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 35);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // matchLabel3
            // 
            this.matchLabel3.AllowDrop = true;
            this.matchLabel3.AutoEllipsis = true;
            this.matchLabel3.BackColor = System.Drawing.Color.White;
            this.matchLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchLabel3.Location = new System.Drawing.Point(202, 61);
            this.matchLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.matchLabel3.Name = "matchLabel3";
            this.matchLabel3.PlayerInfo = null;
            this.matchLabel3.Position = 1;
            this.matchLabel3.Size = new System.Drawing.Size(113, 29);
            this.matchLabel3.TabIndex = 10;
            this.matchLabel3.Team = 0;
            // 
            // matchLabel4
            // 
            this.matchLabel4.AllowDrop = true;
            this.matchLabel4.AutoEllipsis = true;
            this.matchLabel4.BackColor = System.Drawing.Color.White;
            this.matchLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchLabel4.Location = new System.Drawing.Point(56, 61);
            this.matchLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.matchLabel4.Name = "matchLabel4";
            this.matchLabel4.PlayerInfo = null;
            this.matchLabel4.Position = 1;
            this.matchLabel4.Size = new System.Drawing.Size(113, 29);
            this.matchLabel4.TabIndex = 9;
            this.matchLabel4.Team = 0;
            // 
            // MatchCard_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.matchLabel3);
            this.Controls.Add(this.matchLabel4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.matchLabel1);
            this.Controls.Add(this.matchLabel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelLane);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.labelP0);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MatchCard_3";
            this.Size = new System.Drawing.Size(373, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatchLabel labelP0;
        private MatchLabel labelP1;
        private System.Windows.Forms.Label labelLane;
        private System.Windows.Forms.TextBox textBox1;
        private MatchLabel matchLabel1;
        private MatchLabel matchLabel2;
        private System.Windows.Forms.TextBox textBox2;
        private MatchLabel matchLabel3;
        private MatchLabel matchLabel4;
    }
}
