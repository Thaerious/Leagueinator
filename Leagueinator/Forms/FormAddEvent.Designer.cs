namespace Leagueinator.Components {
    partial class FormAddEvent {
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
            this.butOK = new System.Windows.Forms.Button();
            this.spinLaneCount = new System.Windows.Forms.NumericUpDown();
            this.spinTeamSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.butCancel = new System.Windows.Forms.Button();
            this.radRoundRobin = new System.Windows.Forms.RadioButton();
            this.radBracket = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.radRanked = new System.Windows.Forms.RadioButton();
            this.radPenache = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.spinNumEnds = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinNumEnds)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Number of Lanes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Team Size";
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(38, 471);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(148, 45);
            this.butOK.TabIndex = 8;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // spinLaneCount
            // 
            this.spinLaneCount.Location = new System.Drawing.Point(165, 139);
            this.spinLaneCount.Maximum = new decimal(new int[] {
            32,
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
            this.spinLaneCount.TabIndex = 7;
            this.spinLaneCount.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // spinTeamSize
            // 
            this.spinTeamSize.Location = new System.Drawing.Point(165, 87);
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
            this.spinTeamSize.TabIndex = 6;
            this.spinTeamSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Event Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 26);
            this.txtName.TabIndex = 12;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(88, 234);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 13;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(192, 471);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(152, 46);
            this.butCancel.TabIndex = 14;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // radRoundRobin
            // 
            this.radRoundRobin.AutoSize = true;
            this.radRoundRobin.Checked = true;
            this.radRoundRobin.Location = new System.Drawing.Point(6, 25);
            this.radRoundRobin.Name = "radRoundRobin";
            this.radRoundRobin.Size = new System.Drawing.Size(128, 24);
            this.radRoundRobin.TabIndex = 15;
            this.radRoundRobin.TabStop = true;
            this.radRoundRobin.Text = "Round Robin";
            this.radRoundRobin.UseVisualStyleBackColor = true;
            // 
            // radBracket
            // 
            this.radBracket.AutoSize = true;
            this.radBracket.Enabled = false;
            this.radBracket.Location = new System.Drawing.Point(6, 55);
            this.radBracket.Name = "radBracket";
            this.radBracket.Size = new System.Drawing.Size(89, 24);
            this.radBracket.TabIndex = 16;
            this.radBracket.TabStop = true;
            this.radBracket.Text = "Bracket";
            this.radBracket.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNone);
            this.groupBox1.Controls.Add(this.radRanked);
            this.groupBox1.Controls.Add(this.radPenache);
            this.groupBox1.Controls.Add(this.radRoundRobin);
            this.groupBox1.Controls.Add(this.radBracket);
            this.groupBox1.Location = new System.Drawing.Point(88, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 179);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matchup";
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Location = new System.Drawing.Point(6, 145);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(72, 24);
            this.radNone.TabIndex = 18;
            this.radNone.Text = "None";
            this.radNone.UseVisualStyleBackColor = true;
            // 
            // radRanked
            // 
            this.radRanked.AutoSize = true;
            this.radRanked.Location = new System.Drawing.Point(6, 85);
            this.radRanked.Name = "radRanked";
            this.radRanked.Size = new System.Drawing.Size(90, 24);
            this.radRanked.TabIndex = 17;
            this.radRanked.TabStop = true;
            this.radRanked.Text = "Ranked";
            this.radRanked.UseVisualStyleBackColor = true;
            // 
            // radPenache
            // 
            this.radPenache.AutoSize = true;
            this.radPenache.Location = new System.Drawing.Point(6, 115);
            this.radPenache.Name = "radPenache";
            this.radPenache.Size = new System.Drawing.Size(97, 24);
            this.radPenache.TabIndex = 16;
            this.radPenache.Text = "Penaché";
            this.radPenache.UseVisualStyleBackColor = true;
            this.radPenache.CheckedChanged += new System.EventHandler(this.radPenache_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Number of Ends";
            // 
            // spinNumEnds
            // 
            this.spinNumEnds.Location = new System.Drawing.Point(165, 192);
            this.spinNumEnds.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.spinNumEnds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinNumEnds.Name = "spinNumEnds";
            this.spinNumEnds.Size = new System.Drawing.Size(46, 26);
            this.spinNumEnds.TabIndex = 18;
            this.spinNumEnds.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // FormAddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 529);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.spinNumEnds);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.spinLaneCount);
            this.Controls.Add(this.spinTeamSize);
            this.Name = "FormAddEvent";
            this.Text = "AddEventForm";
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinNumEnds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.NumericUpDown spinLaneCount;
        private System.Windows.Forms.NumericUpDown spinTeamSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.RadioButton radRoundRobin;
        private System.Windows.Forms.RadioButton radBracket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radRanked;
        private System.Windows.Forms.RadioButton radPenache;
        private System.Windows.Forms.RadioButton radNone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spinNumEnds;
    }
}
