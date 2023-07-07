namespace Leagueinator.Components {
    partial class MatchCard_1 {
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
            this.labelP0 = new Leagueinator.Components.MatchLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelP1 = new Leagueinator.Components.MatchLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            // labelP0
            // 
            this.labelP0.AllowDrop = true;
            this.labelP0.AutoEllipsis = true;
            this.labelP0.BackColor = System.Drawing.Color.White;
            this.labelP0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP0.Location = new System.Drawing.Point(56, 19);
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
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 35);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelP1
            // 
            this.labelP1.AllowDrop = true;
            this.labelP1.AutoEllipsis = true;
            this.labelP1.BackColor = System.Drawing.Color.White;
            this.labelP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.Location = new System.Drawing.Point(202, 19);
            this.labelP1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelP1.Name = "labelP1";
            this.labelP1.PlayerInfo = null;
            this.labelP1.Position = 0;
            this.labelP1.Size = new System.Drawing.Size(113, 29);
            this.labelP1.TabIndex = 6;
            this.labelP1.Team = 1;
            this.labelP1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.labelP1.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnEnter);
            this.labelP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(318, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 35);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MatchCard_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelLane);
            this.Controls.Add(this.labelP0);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MatchCard_1";
            this.Size = new System.Drawing.Size(373, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatchLabel labelP0;
        private new System.Windows.Forms.Label labelLane;
        private System.Windows.Forms.TextBox textBox1;
        private MatchLabel labelP1;
        private System.Windows.Forms.TextBox textBox2;
    }
}
