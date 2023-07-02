using System.Drawing;
using Leagueinator.Model;

namespace Leagueinator.Components {
    internal class RoundButton : System.Windows.Forms.Button, IModelRound {
        public Round Round { get; set; }


        public bool Selected {
            get {
                return this.BackColor == Color.GreenYellow;
            }
            set {
                this.BackColor = Color.GreenYellow;
            }
        }

        public RoundButton(Round round) : base() {
            this.Round = round;
        }
    }
}
