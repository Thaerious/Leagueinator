using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leagueinator
{
    public partial class Matchpanel : UserControl {
        public Matchpanel() {
            InitializeComponent();
            Debug.WriteLine("Initialize Match Panel");
        }


        public List<string> Names {
            get {
                var list = new List<string>();
                list.Add(labelTeam1Player1.Text);
                list.Add(labelTeam1Player2.Text);
                list.Add(labelTeam2Player1.Text);
                list.Add(labelTeam2Player2.Text);
                return list;
            }
            set {
                labelTeam1Player1.Text = value[0];
                labelTeam1Player2.Text = value[1];
                labelTeam2Player1.Text = value[2];
                labelTeam2Player2.Text = value[3];
            }
        }

        public Matchpanel(int lane, List<string> names)
        {
            InitializeComponent();
            this.labelLane.Text = $"Lane {lane}";
            this.labelTeam1Player1.Text = names[0];
            this.labelTeam1Player2.Text = names[0];
            this.labelTeam2Player1.Text = names[0];
            this.labelTeam2Player2.Text = names[0];
        }

        private void startDragDrop(object sender, MouseEventArgs e) {
            Debug.WriteLine(((System.Windows.Forms.Label)sender).Text);
            DoDragDrop(((System.Windows.Forms.Label)sender).Text, DragDropEffects.Copy);
        }
    }
}
