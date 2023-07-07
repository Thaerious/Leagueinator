using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard_4 : MatchCard {
        public override Match Match {
            set {
                if (value != null) {
                    this.labelP0.PlayerInfo = value[0][0];
                    this.labelP1.PlayerInfo = value[0][1];
                    this.labelP2.PlayerInfo = value[0][2];
                    this.labelP3.PlayerInfo = value[0][3];
                    this.labelP4.PlayerInfo = value[1][0];
                    this.labelP5.PlayerInfo = value[1][1];
                    this.labelP6.PlayerInfo = value[1][2];
                    this.labelP7.PlayerInfo = value[1][3];
                }
                base.Match = value;
            }
        }

        public override int Lane {
            set {
                this.labelLane.Text = (value + 1).ToString();
                base.Lane = value;
            }
        }

        public void OnDrop(object sender, DragEventArgs e) => base.DoDrop(sender, e);
        public void StartDrag(object sender, MouseEventArgs e) => base.StartDragLabel(sender, e);
        public void OnEnter(object sender, DragEventArgs e) => base.DoEnter(sender, e);
        public void OnExit(object sender, DragEventArgs e) => base.DoExit(sender, e);
    }
}

