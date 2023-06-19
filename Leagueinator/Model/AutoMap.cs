using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Model {
    public class AutoMap<K,T> : Dictionary<K,T> where T : new() {

        public new T this[K key] {
            get { 
                if (!base.Keys.Contains(key)) {
                    base[key] = new T();
                }
                return base[key]; 
            }
            set { base[key] = value; }
        }

    }
}
