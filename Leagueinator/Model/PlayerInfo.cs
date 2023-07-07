
using Leagueinator.Utility_Classes;
using System;

namespace Leagueinator.Model {
    [Serializable]
    public class PlayerInfo : IEquatable<PlayerInfo> {
        private string _name;

        public string Name {
            get => this._name;
            set {
                if (value == null) throw new ArgumentNullException();
                if (value.Trim() == "") throw new ArgumentException();
                this._name = value.Trim();
            }
        }

        public PlayerInfo(string name) => this.Name = name;

        override public string ToString() => this.Name;

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            return this.Equals((PlayerInfo)obj);
        }

        public override int GetHashCode() {
            return this.Name.GetHashCode();
        }

        public bool Equals(PlayerInfo obj) {
            if (obj == null) return false;
            if (!(obj is PlayerInfo)) return false;
            PlayerInfo that = (PlayerInfo)obj;
            return this.Name.ToLower().Trim() == that.Name.ToLower().Trim();
        }
                public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.InlineTag("Player", this.Name, $"hash='{this.GetHashCode().ToString("X")}'");
            return xsb;
        }
    }
}
