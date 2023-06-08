namespace Leagueinator
{
    partial class Matchpanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTeam2Player2 = new System.Windows.Forms.Label();
            this.labelTeam2Player1 = new System.Windows.Forms.Label();
            this.labelTeam1Player2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTeam1Player1 = new System.Windows.Forms.Label();
            this.labelLane = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTeam2Player2
            // 
            this.labelTeam2Player2.BackColor = System.Drawing.Color.White;
            this.labelTeam2Player2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTeam2Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam2Player2.Location = new System.Drawing.Point(329, 83);
            this.labelTeam2Player2.Name = "labelTeam2Player2";
            this.labelTeam2Player2.Size = new System.Drawing.Size(250, 32);
            this.labelTeam2Player2.TabIndex = 10;
            this.labelTeam2Player2.Text = "player4";
            this.labelTeam2Player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTeam2Player1
            // 
            this.labelTeam2Player1.BackColor = System.Drawing.Color.White;
            this.labelTeam2Player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTeam2Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam2Player1.Location = new System.Drawing.Point(329, 40);
            this.labelTeam2Player1.Name = "labelTeam2Player1";
            this.labelTeam2Player1.Size = new System.Drawing.Size(250, 32);
            this.labelTeam2Player1.TabIndex = 9;
            this.labelTeam2Player1.Text = "player3";
            this.labelTeam2Player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTeam1Player2
            // 
            this.labelTeam1Player2.BackColor = System.Drawing.Color.White;
            this.labelTeam1Player2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTeam1Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam1Player2.Location = new System.Drawing.Point(13, 83);
            this.labelTeam1Player2.Name = "labelTeam1Player2";
            this.labelTeam1Player2.Size = new System.Drawing.Size(250, 32);
            this.labelTeam1Player2.TabIndex = 8;
            this.labelTeam1Player2.Text = "player2";
            this.labelTeam1Player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "VS";
            // 
            // labelTeam1Player1
            // 
            this.labelTeam1Player1.BackColor = System.Drawing.Color.White;
            this.labelTeam1Player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTeam1Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam1Player1.Location = new System.Drawing.Point(13, 40);
            this.labelTeam1Player1.Name = "labelTeam1Player1";
            this.labelTeam1Player1.Size = new System.Drawing.Size(250, 32);
            this.labelTeam1Player1.TabIndex = 6;
            this.labelTeam1Player1.Text = "player1";
            this.labelTeam1Player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTeam1Player1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelStartDrag);
            // 
            // labelLane
            // 
            this.labelLane.AutoSize = true;
            this.labelLane.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLane.Location = new System.Drawing.Point(8, 0);
            this.labelLane.Name = "labelLane";
            this.labelLane.Size = new System.Drawing.Size(85, 29);
            this.labelLane.TabIndex = 11;
            this.labelLane.Text = "Lane 1";
            // 
            // Matchpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelLane);
            this.Controls.Add(this.labelTeam2Player2);
            this.Controls.Add(this.labelTeam2Player1);
            this.Controls.Add(this.labelTeam1Player2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTeam1Player1);
            this.Name = "Matchpanel";
            this.Size = new System.Drawing.Size(602, 153);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeam2Player2;
        private System.Windows.Forms.Label labelTeam2Player1;
        private System.Windows.Forms.Label labelTeam1Player2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTeam1Player1;
        private System.Windows.Forms.Label labelLane;
    }
}
