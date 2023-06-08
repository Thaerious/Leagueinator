namespace Leagueinator.Forms {
    partial class FormSettings {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.spinLaneCount = new System.Windows.Forms.NumericUpDown();
            this.spinTeamSize = new System.Windows.Forms.NumericUpDown();
            this.chkRegenerate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Number of Lanes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Team Size";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(99, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 61);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // spinLaneCount
            // 
            this.spinLaneCount.Location = new System.Drawing.Point(99, 175);
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
            this.spinLaneCount.TabIndex = 8;
            this.spinLaneCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // spinTeamSize
            // 
            this.spinTeamSize.Location = new System.Drawing.Point(99, 109);
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
            this.spinTeamSize.TabIndex = 7;
            this.spinTeamSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkRegenerate
            // 
            this.chkRegenerate.AutoSize = true;
            this.chkRegenerate.Checked = true;
            this.chkRegenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRegenerate.Location = new System.Drawing.Point(99, 53);
            this.chkRegenerate.Name = "chkRegenerate";
            this.chkRegenerate.Size = new System.Drawing.Size(172, 24);
            this.chkRegenerate.TabIndex = 6;
            this.chkRegenerate.Text = "Regenerate Teams";
            this.chkRegenerate.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spinLaneCount);
            this.Controls.Add(this.spinTeamSize);
            this.Controls.Add(this.chkRegenerate);
            this.Name = "FormSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown spinLaneCount;
        private System.Windows.Forms.NumericUpDown spinTeamSize;
        private System.Windows.Forms.CheckBox chkRegenerate;
    }
}