using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leagueinator.Components {
    public partial class EditEventPanel : UserControl {
        Button currentRound = null;

        public EditEventPanel() {
            InitializeComponent();
        }

        private void AddRound(object sender, EventArgs e) {
            var button = new Button {
                Text = $"Round #{this.flowRounds.Controls.Count + 1}"
            };
            this.flowRounds.Controls.Add(button);

            button.Click += new EventHandler((object source, EventArgs _) => {
                if (this.currentRound != null) {
                    this.currentRound.BackColor = Color.White;
                }
                (source as Button).BackColor = Color.GreenYellow;
                this.currentRound = button;
            });
        }

        private void RemoveRound(object sender, EventArgs e) {
            if (this.currentRound != null) {
                this.flowRounds.Controls.Remove(this.currentRound);
                this.currentRound = null;
            }
        }
    }
}
