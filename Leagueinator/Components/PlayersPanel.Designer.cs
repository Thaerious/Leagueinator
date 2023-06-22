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
            this.panel1 = new System.Windows.Forms.Panel();
            this.butRename = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelPlayerList = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelPlayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPlayers
            // 
            this.listPlayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.listPlayers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 27;
            this.listPlayers.Location = new System.Drawing.Point(0, 0);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(398, 787);
            this.listPlayers.TabIndex = 4;
            this.listPlayers.SelectedIndexChanged += new System.EventHandler(this.onSelect);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.butRename);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPlayerName);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(453, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 231);
            this.panel1.TabIndex = 5;
            // 
            // butRename
            // 
            this.butRename.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRename.Location = new System.Drawing.Point(253, 108);
            this.butRename.Name = "butRename";
            this.butRename.Size = new System.Drawing.Size(143, 44);
            this.butRename.TabIndex = 5;
            this.butRename.Text = "Rename";
            this.butRename.UseVisualStyleBackColor = true;
            this.butRename.Click += new System.EventHandler(this.ButRename_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerName.Location = new System.Drawing.Point(165, 48);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(335, 35);
            this.txtPlayerName.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(253, 158);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(143, 44);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.clickDelete);
            // 
            // panelPlayerList
            // 
            this.panelPlayerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayerList.Controls.Add(this.listPlayers);
            this.panelPlayerList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPlayerList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelPlayerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button butRename;
    }
}
