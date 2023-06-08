namespace Leagueinator.Components {
    partial class EventCard {
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
            this.lblDate = new System.Windows.Forms.Label();
            this.butDeleteEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(3, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(194, 34);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "---";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butDeleteEvent
            // 
            this.butDeleteEvent.Location = new System.Drawing.Point(162, 158);
            this.butDeleteEvent.Name = "butDeleteEvent";
            this.butDeleteEvent.Size = new System.Drawing.Size(35, 39);
            this.butDeleteEvent.TabIndex = 1;
            this.butDeleteEvent.Text = "-";
            this.butDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // EventCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.butDeleteEvent);
            this.Controls.Add(this.lblDate);
            this.Name = "EventCard";
            this.Size = new System.Drawing.Size(196, 196);
            this.DoubleClick += new System.EventHandler(this.EventCard_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button butDeleteEvent;
    }
}
