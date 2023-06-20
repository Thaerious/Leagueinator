
using System;

namespace Leagueinator.Model {
    [Serializable]
    public class PlayerInfo : HasDeepCopy<PlayerInfo>{
        public string Name { get; set; }

        public PlayerInfo(string name) {
            Name = name;
        }

        override public string ToString() {
            return Name;
        }

        public PlayerInfo DeepCopy() {
            return new PlayerInfo(this.Name);
        }
    }
    public interface IModelPlayer {
        PlayerInfo AddPlayer(PlayerInfo playerInfo);
        void ClearPlayer(PlayerInfo playerInfo);
    }
}
