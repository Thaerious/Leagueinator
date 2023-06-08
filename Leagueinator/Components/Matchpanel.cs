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

namespace Leagueinator
{
    public partial class Matchpanel : UserControl
    {
        public Matchpanel(int lane, Team team1, Team team2)
        {
            InitializeComponent();
            this.labelLane.Text = $"Lane {lane}";
            this.labelTeam1Player1.Text = team1.Player1;
            this.labelTeam1Player2.Text = team1.Player2;
            this.labelTeam2Player1.Text = team2.Player1;
            this.labelTeam2Player2.Text = team2.Player2;
        }

        private void labelStartDrag(object sender, MouseEventArgs e) {
            Debug.WriteLine("labelStartDrag");
            DoDragDrop(this.labelTeam1Player1.Text, DragDropEffects.Copy);
        }
    }
}
