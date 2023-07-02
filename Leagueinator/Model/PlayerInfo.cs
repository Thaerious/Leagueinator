
using System;

namespace Leagueinator.Model {
    [Serializable]
    public class PlayerInfo : IEquatable<PlayerInfo> {
        private string _name;

        public string Name {
            get => _name;
            set {
                if (value == null) throw new ArgumentNullException();
                if (value.Trim() == "") throw new ArgumentException();
                _name = value.Trim();
            }
        }

        public PlayerInfo(string name) => Name = name;

        override public string ToString() => Name;

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            return Equals((PlayerInfo)obj);
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

        public bool Equals(PlayerInfo obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            PlayerInfo that = (PlayerInfo)obj;
            return Name.ToLower().Trim() == that.Name.ToLower().Trim();
        }
    }
}
