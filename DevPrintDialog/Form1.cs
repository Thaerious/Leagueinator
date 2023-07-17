using System.Windows.Forms;
using zoomprint;

namespace DevPrintDialog {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            ZPrintForm ZPF = new ZPrintForm(null);
            ZPF.ShowDialog(this);
            ZPF.Dispose();
        }
    }
}
