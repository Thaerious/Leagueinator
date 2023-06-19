using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Utility {
    public class PlayerInfo {
        public long SQLIndex { get; }
        public string Name { get; set; }
        public List<string> PreviousPartners { get;} = new List<string>();
        public List<int> PreviousLanes { get; } = new List<int>();

        public int CountBuys = 0;

        public PlayerInfo(string name, long index) {
            Name = name;
            SQLIndex = index;
        }

        public PlayerInfo(PlayerInfo that) {
            this.Name = that.Name;
            this.CountBuys = that.CountBuys;
            this.PreviousPartners = new List<string>(that.PreviousPartners);
            this.PreviousLanes = new List<int>(that.PreviousLanes);
            this.SQLIndex = that.SQLIndex;
        }

        public override string ToString() {
            return Name;
        }

        public bool Equals(PlayerInfo other) {
            return this.Name.Equals(other.Name);
        }
    }

    public class PlayerInfoMap : Dictionary<string, PlayerInfo> {
        private static Random rng = new Random();

        public PlayerInfoMap() : base(){}

        public PlayerInfoMap(PlayerInfoMap playerInfoMap) : base(playerInfoMap) {}

        public PlayerInfoMap(IEnumerable<PlayerInfo> source) {
            foreach(PlayerInfo pinfo in source) {
                this[pinfo.Name] = pinfo; 
            }
        }

        public PlayerInfoMap DeepCopy() {
            var r = new PlayerInfoMap();
            foreach(PlayerInfo pinfo in this) {
                r.Add(new PlayerInfo(pinfo));
            }
            return r;
        }

        public PlayerInfoMap ShallowCopy() {
            var r = new PlayerInfoMap();
            foreach (PlayerInfo pinfo in this) {
                r.Add(pinfo);
            }
            return r;
        }

        public void Add(PlayerInfo info) {
            this[info.Name] = info;
        }

        public PlayerInfo Remove(PlayerInfo info) {
            var removed = this[info.Name];
            this.Remove(info.Name);
            return removed;
        }

        public new IEnumerator<PlayerInfo> GetEnumerator() {
            return this.Values.GetEnumerator();
        }

        public PlayerInfo RemoveRandom() {
            if (this.Values.Count == 0) return null;
            int r = rng.Next(this.Values.Count);
            return this.Remove(this.Values.ToList()[r]);
        }

        /// <summary>
        /// Removes the player info with the lowest buy.
        /// If tied, removes one of the lowest at random.
        /// </summary>
        /// <returns>The player info removed</returns>
        public PlayerInfo LowestRandomBuy() {
            var lowestbuys = new PlayerInfoMap();
            List <PlayerInfo> list = this.Values.ToList();

            list.Sort(delegate (PlayerInfo a, PlayerInfo b) {
                return a.CountBuys.CompareTo(b.CountBuys);
            });

            var target = list[0].CountBuys;
            var listOfLowest = list
                .Where(pinfo => pinfo.CountBuys == target)
                .ToList();

            var lowest = new Random().RemoveFrom(listOfLowest);
            this.Remove(lowest);
            return lowest;
        }
    }
}
