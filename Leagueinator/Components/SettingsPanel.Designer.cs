namespace Leagueinator.Components {
    partial class SettingsPanel {
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
            this.chkRegenerate = new System.Windows.Forms.CheckBox();
            this.spinTeamSize = new System.Windows.Forms.NumericUpDown();
            this.spinLaneCount = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRegenerate
            // 
            this.chkRegenerate.AutoSize = true;
            this.chkRegenerate.Checked = true;
            this.chkRegenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRegenerate.Location = new System.Drawing.Point(108, 79);
            this.chkRegenerate.Name = "chkRegenerate";
            this.chkRegenerate.Size = new System.Drawing.Size(172, 24);
            this.chkRegenerate.TabIndex = 0;
            this.chkRegenerate.Text = "Regenerate Teams";
            this.chkRegenerate.UseVisualStyleBackColor = true;
            // 
            // spinTeamSize
            // 
            this.spinTeamSize.Location = new System.Drawing.Point(108, 135);
            this.spinTeamSize.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spinTeamSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTeamSize.Name = "spinTeamSize";
            this.spinTeamSize.Size = new System.Drawing.Size(46, 26);
            this.spinTeamSize.TabIndex = 1;
            this.spinTeamSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // spinLaneCount
            // 
            this.spinLaneCount.Location = new System.Drawing.Point(108, 201);
            this.spinLaneCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spinLaneCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinLaneCount.Name = "spinLaneCount";
            this.spinLaneCount.Size = new System.Drawing.Size(46, 26);
            this.spinLaneCount.TabIndex = 2;
            this.spinLaneCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Team Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Lanes";
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spinLaneCount);
            this.Controls.Add(this.spinTeamSize);
            this.Controls.Add(this.chkRegenerate);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(381, 364);
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRegenerate;
        private System.Windows.Forms.NumericUpDown spinTeamSize;
        private System.Windows.Forms.NumericUpDown spinLaneCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
