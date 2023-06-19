using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model;

namespace Leagueinator.Components {
    internal class RoundButton : System.Windows.Forms.Button {
        public readonly Round Round;


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
