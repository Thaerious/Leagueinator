namespace Leagueinator.Forms {
    public class IsSaved {
        public delegate void IsSavedEvent(bool value);
        public event IsSavedEvent Update;
        public static IsSaved Singleton = new IsSaved();

        private IsSaved() { }

        public bool _value = false;
        public bool Value {
            get => this._value;
            set {
                if (value != this._value) {
                    this._value = value;
                    Update?.Invoke(value);
                }
            }
        }
    }
}
