namespace MatchPrinter {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            butPrint = new Button();
            printPreview = new PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // butPrint
            // 
            butPrint.Location = new Point(427, 287);
            butPrint.Name = "butPrint";
            butPrint.Size = new Size(196, 71);
            butPrint.TabIndex = 0;
            butPrint.Text = "PRINT";
            butPrint.UseVisualStyleBackColor = true;
            butPrint.Click += this.butPrint_Click;
            // 
            // printPreview
            // 
            printPreview.AutoScrollMargin = new Size(0, 0);
            printPreview.AutoScrollMinSize = new Size(0, 0);
            printPreview.ClientSize = new Size(400, 300);
            printPreview.Enabled = true;
            printPreview.Icon = (Icon)resources.GetObject("printPreview.Icon");
            printPreview.Name = "printPreview";
            printPreview.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1062, 697);
            this.Controls.Add(butPrint);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDoc;
        private Button butPrint;
        private PrintPreviewDialog printPreview;
    }
}