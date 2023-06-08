using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.utility_classes;

namespace Leagueinator {
    public interface HasPlayerInfo {
        PlayerInfoMap GetPlayerInfo();
    }

    public class PlayerInfoBox : System.Windows.Forms.ListBox, HasPlayerInfo {
        public PlayerInfoBox() : base(){ }

        public PlayerInfoMap GetPlayerInfo() {
            List<PlayerInfo> names = this.Items.Cast<PlayerInfo>().ToList();
            IEnumerable<PlayerInfo> r = from pinfo in names select new PlayerInfo(pinfo);

            return new PlayerInfoMap(r);
        }
    }
}
