
using System;

namespace Leagueinator.Model {
    [Serializable]
    public class PlayerInfo : HasDeepCopy<PlayerInfo>, IEquatable<PlayerInfo> {
        public string Name { get; set; }

        public PlayerInfo(string name) => Name = name;

        override public string ToString() => Name;

        public PlayerInfo DeepCopy() => new PlayerInfo(this.Name);

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            PlayerInfo that = (PlayerInfo)obj;
            return this.Name == that.Name;
        }

        public override int GetHashCode() {
            return this.Name.GetHashCode();
        }

        public bool Equals(PlayerInfo obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            PlayerInfo that = (PlayerInfo)obj;
            return this.Name == that.Name;
        }
    }
    public interface HasPlayerInfo {
        PlayerInfo AddPlayer(PlayerInfo playerInfo);
        void ClearPlayer(PlayerInfo playerInfo);
    }
}
