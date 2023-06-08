using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leagueinator {
    public partial class BuyCard : UserControl {
        public BuyCard(string name) {
            InitializeComponent();
            this.labelName.Text = name;
        }
    }
}
