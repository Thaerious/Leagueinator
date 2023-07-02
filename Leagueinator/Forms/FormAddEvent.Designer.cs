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
            ((System.ComponentModel.ISupportInitialize)(this.spinLaneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTeamSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Number of Lanes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Team Size";
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(63, 307);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(174, 45);
            this.butOK.TabIndex = 8;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // spinLaneCount
            // 
            this.spinLaneCount.Location = new System.Drawing.Point(119, 203);
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
            this.spinTeamSize.Location = new System.Drawing.Point(119, 128);
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
            this.label3.Location = new System.Drawing.Point(99, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Event Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 26);
            this.txtName.TabIndex = 12;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(51, 265);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 13;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(63, 368);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(174, 46);
            this.butCancel.TabIndex = 14;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // FormAddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 444);
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
    }
}