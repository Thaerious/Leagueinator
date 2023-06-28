using System.Drawing;
using Leagueinator.Model;

namespace Leagueinator.Components {
    internal class RoundButton : System.Windows.Forms.Button, IModelRound {
        public Round Round { get; set; }


        public bool Selected {
            get {
                return BackColor == Color.GreenYellow;
            }
            set {
                BackColor = Color.GreenYellow;
            }
        }

        public RoundButton(Round round) : base() {
            Round = round;
        }
    }
}
