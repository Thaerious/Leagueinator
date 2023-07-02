using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Forms {
    public class IsSaved {
        public delegate void IsSavedEvent(bool value);
        public event IsSavedEvent Update;
        public static IsSaved Singleton = new IsSaved();

        private IsSaved() { }

        public bool _value = false;
        public bool Value {
            get => _value;
            set {
                if (value != _value) {
                    _value = value;
                    Update?.Invoke(value);
                }
            }
        }
    }
}
