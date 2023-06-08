namespace Leagueinator.Components {
    partial class PlayersPanel {
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
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIndex = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPlayerList = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelPlayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPlayers
            // 
            this.listPlayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 20;
            this.listPlayers.Location = new System.Drawing.Point(0, 0);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(398, 764);
            this.listPlayers.TabIndex = 4;
            this.listPlayers.SelectedIndexChanged += new System.EventHandler(this.onSelect);
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtName.Location = new System.Drawing.Point(0, 772);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(398, 26);
            this.txtName.TabIndex = 6;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNameKeyUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblIndex);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPlayerName);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(453, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 231);
            this.panel1.TabIndex = 5;
            // 
            // lblIndex
            // 
            this.lblIndex.Location = new System.Drawing.Point(98, 22);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(200, 20);
            this.lblIndex.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(102, 48);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(324, 26);
            this.txtPlayerName.TabIndex = 3;
            this.txtPlayerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRenameKeyUp);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(32, 170);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(98, 44);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.clickDelete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Index";
            // 
            // panelPlayerList
            // 
            this.panelPlayerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayerList.Controls.Add(this.txtName);
            this.panelPlayerList.Controls.Add(this.listPlayers);
            this.panelPlayerList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPlayerList.Location = new System.Drawing.Point(0, 0);
            this.panelPlayerList.Name = "panelPlayerList";
            this.panelPlayerList.Size = new System.Drawing.Size(400, 800);
            this.panelPlayerList.TabIndex = 7;
            // 
            // PlayersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPlayerList);
            this.Controls.Add(this.panel1);
            this.Name = "PlayersPanel";
            this.Size = new System.Drawing.Size(1200, 800);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPlayerList.ResumeLayout(false);
            this.panelPlayerList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPlayerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblIndex;
    }
}
