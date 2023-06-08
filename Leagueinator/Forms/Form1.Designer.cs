namespace Leagueinator
{
    partial class formMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMatch = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.panelTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPlayers = new System.Windows.Forms.Button();
            this.buttonRound1 = new System.Windows.Forms.Button();
            this.buttonRound2 = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.buttonAddSelected = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.panelRound = new System.Windows.Forms.Panel();
            this.listNames = new Leagueinator.PlayerInfoBox();
            this.listPlayers = new Leagueinator.PlayerInfoBox();
            this.panelTasks.SuspendLayout();
            this.panelPlayers.SuspendLayout();
            this.panelRound.SuspendLayout();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(45, 562);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(357, 39);
            this.textName.TabIndex = 1;
            this.textName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textName_KeyUp);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(45, 631);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(357, 35);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(45, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "REMOVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelMatch
            // 
            this.panelMatch.AutoScroll = true;
            this.panelMatch.BackColor = System.Drawing.SystemColors.Window;
            this.panelMatch.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMatch.Location = new System.Drawing.Point(23, 23);
            this.panelMatch.Name = "panelMatch";
            this.panelMatch.Size = new System.Drawing.Size(993, 700);
            this.panelMatch.TabIndex = 8;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(3, 242);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(200, 61);
            this.buttonPrint.TabIndex = 9;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.buttonPlayers);
            this.panelTasks.Controls.Add(this.buttonRound1);
            this.panelTasks.Controls.Add(this.buttonRound2);
            this.panelTasks.Controls.Add(this.buttonGenerate);
            this.panelTasks.Controls.Add(this.buttonPrint);
            this.panelTasks.Location = new System.Drawing.Point(0, 0);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(208, 747);
            this.panelTasks.TabIndex = 10;
            // 
            // buttonPlayers
            // 
            this.buttonPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayers.Location = new System.Drawing.Point(3, 3);
            this.buttonPlayers.Name = "buttonPlayers";
            this.buttonPlayers.Size = new System.Drawing.Size(200, 53);
            this.buttonPlayers.TabIndex = 2;
            this.buttonPlayers.Text = "Players";
            this.buttonPlayers.UseVisualStyleBackColor = true;
            this.buttonPlayers.Click += new System.EventHandler(this.buttonPlayers_Click);
            // 
            // buttonRound1
            // 
            this.buttonRound1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRound1.Location = new System.Drawing.Point(3, 62);
            this.buttonRound1.Name = "buttonRound1";
            this.buttonRound1.Size = new System.Drawing.Size(200, 53);
            this.buttonRound1.TabIndex = 0;
            this.buttonRound1.Text = "Round 1";
            this.buttonRound1.UseVisualStyleBackColor = true;
            this.buttonRound1.Click += new System.EventHandler(this.buttonRound1_Click);
            // 
            // buttonRound2
            // 
            this.buttonRound2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRound2.Location = new System.Drawing.Point(3, 121);
            this.buttonRound2.Name = "buttonRound2";
            this.buttonRound2.Size = new System.Drawing.Size(200, 53);
            this.buttonRound2.TabIndex = 1;
            this.buttonRound2.Text = "Round 2";
            this.buttonRound2.UseVisualStyleBackColor = true;
            this.buttonRound2.Click += new System.EventHandler(this.buttonRound2_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerate.Location = new System.Drawing.Point(3, 180);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(200, 56);
            this.buttonGenerate.TabIndex = 15;
            this.buttonGenerate.Text = "Regenerate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click_1);
            // 
            // panelPlayers
            // 
            this.panelPlayers.Controls.Add(this.listNames);
            this.panelPlayers.Controls.Add(this.listPlayers);
            this.panelPlayers.Controls.Add(this.buttonRemoveSelected);
            this.panelPlayers.Controls.Add(this.buttonAddSelected);
            this.panelPlayers.Controls.Add(this.buttonRemoveAll);
            this.panelPlayers.Controls.Add(this.buttonAddAll);
            this.panelPlayers.Controls.Add(this.textName);
            this.panelPlayers.Controls.Add(this.buttonAdd);
            this.panelPlayers.Controls.Add(this.button1);
            this.panelPlayers.Location = new System.Drawing.Point(215, 0);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(1037, 747);
            this.panelPlayers.TabIndex = 11;
            // 
            // buttonRemoveSelected
            // 
            this.buttonRemoveSelected.Location = new System.Drawing.Point(417, 307);
            this.buttonRemoveSelected.Name = "buttonRemoveSelected";
            this.buttonRemoveSelected.Size = new System.Drawing.Size(167, 61);
            this.buttonRemoveSelected.TabIndex = 12;
            this.buttonRemoveSelected.Text = "< Selected";
            this.buttonRemoveSelected.UseVisualStyleBackColor = true;
            this.buttonRemoveSelected.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // buttonAddSelected
            // 
            this.buttonAddSelected.Location = new System.Drawing.Point(417, 242);
            this.buttonAddSelected.Name = "buttonAddSelected";
            this.buttonAddSelected.Size = new System.Drawing.Size(167, 61);
            this.buttonAddSelected.TabIndex = 11;
            this.buttonAddSelected.Text = "Selected >";
            this.buttonAddSelected.UseVisualStyleBackColor = true;
            this.buttonAddSelected.Click += new System.EventHandler(this.buttonAddSelected_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(417, 374);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(167, 61);
            this.buttonRemoveAll.TabIndex = 10;
            this.buttonRemoveAll.Text = "<< ALL <<";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(417, 175);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(167, 61);
            this.buttonAddAll.TabIndex = 9;
            this.buttonAddAll.Text = ">> ALL >>";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.buttonAddAll_Click);
            // 
            // panelRound
            // 
            this.panelRound.Controls.Add(this.panelMatch);
            this.panelRound.Location = new System.Drawing.Point(215, 0);
            this.panelRound.Name = "panelRound";
            this.panelRound.Size = new System.Drawing.Size(1037, 745);
            this.panelRound.TabIndex = 13;
            // 
            // listNames
            // 
            this.listNames.FormattingEnabled = true;
            this.listNames.ItemHeight = 20;
            this.listNames.Location = new System.Drawing.Point(45, 12);
            this.listNames.Name = "listNames";
            this.listNames.Size = new System.Drawing.Size(357, 544);
            this.listNames.TabIndex = 15;
            // 
            // listPlayers
            // 
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 20;
            this.listPlayers.Location = new System.Drawing.Point(605, 23);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(392, 684);
            this.listPlayers.TabIndex = 14;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1277, 763);
            this.Controls.Add(this.panelTasks);
            this.Controls.Add(this.panelPlayers);
            this.Controls.Add(this.panelRound);
            this.Name = "formMain";
            this.Text = "League-inator";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.panelTasks.ResumeLayout(false);
            this.panelPlayers.ResumeLayout(false);
            this.panelPlayers.PerformLayout();
            this.panelRound.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel panelMatch;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.FlowLayoutPanel panelTasks;
        private System.Windows.Forms.Button buttonPlayers;
        private System.Windows.Forms.Button buttonRound1;
        private System.Windows.Forms.Button buttonRound2;
        private System.Windows.Forms.Panel panelPlayers;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.Button buttonRemoveSelected;
        private System.Windows.Forms.Button buttonAddSelected;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Panel panelRound;
        private PlayerInfoBox listPlayers;
        private System.Windows.Forms.Button buttonGenerate;
        private PlayerInfoBox listNames;
    }
}

