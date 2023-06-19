using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Utility.Model {
    public class Player {
        public readonly string Name;

        public Player(string name) {
            Name = name;
        }

        public Player(Player that) {            
            this.Name = that.Name;
        }

        public override string ToString() {
            return this.Name;
        }

        public bool Equals(PlayerInfo other) {
            return this.Name.Equals(other.Name);
        }
    }
}
