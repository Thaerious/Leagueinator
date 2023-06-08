using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("Hello World");
            button1.BackColor = Color.CadetBlue;
            button2.BackColor = System.Drawing.SystemColors.Control;
            button3.BackColor = System.Drawing.SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e) {
            button1.BackColor = System.Drawing.SystemColors.Control;
            button2.BackColor = Color.CadetBlue;
            button3.BackColor = System.Drawing.SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e) {
            button1.BackColor = System.Drawing.SystemColors.Control;
            button2.BackColor = System.Drawing.SystemColors.Control;
            button3.BackColor = Color.CadetBlue;
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.matchpanel1.Names = new List<String>{ "Adam", "Eve", "Cain", "Able" };
        }

        private void label1_Click(object sender, EventArgs e) {
            Debug.WriteLine("label1_Click");
            DoDragDrop(this.label1.Text, DragDropEffects.Copy);
        }
    }
}
