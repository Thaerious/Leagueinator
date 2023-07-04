using System.Drawing;
using System.Windows.Forms;
using Leagueinator.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard_3 : MatchCard {
        public override Match Match {
            set {
                if (value != null) {
                    //this.labelP0.PlayerInfo = value[0][0];
                    //this.labelP1.PlayerInfo = value[0][1];
                    //this.labelP2.PlayerInfo = value[1][0];
                    //this.labelP3.PlayerInfo = value[1][1];
                }
                base.Match = value;
            }
        }

        public void OnDrop(object sender, DragEventArgs e) => base.DoDrop(sender, e);
        public void StartDrag(object sender, MouseEventArgs e) => base.DoStartDrag(sender, e);
        public void OnEnter(object sender, DragEventArgs e) => base.DoEnter(sender, e);
        public void OnExit(object sender, DragEventArgs e) => base.DoExit(sender, e);
    }
}

