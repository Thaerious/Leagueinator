using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public class MatchLabel : Label, IModelPlayer {
        public delegate void MatchLabelUpdate(object sender, MatchLabelArgs args);
        public event MatchLabelUpdate OnUpdate;


        [Category("Misc"), Description("The team number for this label.")]
        public int Team { get; set; } = 0;

        public int Position { get; set; } = 0;

        private PlayerInfo _playerInfo;

        public PlayerInfo PlayerInfo { 
            get => this._playerInfo;
            set {
                this._playerInfo = value;
                if (value == null) this.Text = "";
                else this.Text = value.Name;

                if (this.OnUpdate == null) return;
                this.OnUpdate(this, new MatchLabelArgs {
                    PlayerInfo = value,
                    Team = this.Team,
                    Position = this.Position
                });
            }
        }

        public void SwapPlayers(IModelPlayer that) {
            if (this == that) return;
            (that.PlayerInfo, this.PlayerInfo) = (this.PlayerInfo, that.PlayerInfo);
        }
    }

    public class MatchLabelArgs {
        public PlayerInfo PlayerInfo;
        public int Team;
        public int Position;
    }
}
