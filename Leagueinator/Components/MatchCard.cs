using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;

namespace Leagueinator.Components {
    public partial class MatchCard : UserControl, IModelMatch {
        private int lane = 1;
        [Category("Appearance"),Description("The lane number displayed.")]        
        public int Lane { 
            get => lane; 
            set {
                lane = value;
                this.labelLane.Text = value.ToString();
            }
        }

        private Match match = new Match();
        public Match Match {
            get {
                Match match = new Match();
                match.Teams.Add(0, new Team());
                match.Teams.Add(1, new Team());
                if (this.labelP0.PlayerInfo != null) match.Teams[0].AddPlayer(this.labelP0.PlayerInfo);
                if (this.labelP1.PlayerInfo != null) match.Teams[0].AddPlayer(this.labelP1.PlayerInfo);
                if (this.labelP2.PlayerInfo != null) match.Teams[1].AddPlayer(this.labelP2.PlayerInfo);
                if (this.labelP3.PlayerInfo != null) match.Teams[1].AddPlayer(this.labelP3.PlayerInfo);
                return match;
            }
            set {
                Debug.WriteLine($"Match Card Set {value}");
                if (value != null) {
                    this.match = value.DeepCopy();
                    if (value.Teams[0].Players.ContainsKey(0)) {
                        this.labelP0.PlayerInfo = value.Teams[0].Players[0];
                    }

                    if (value.Teams[0].Players.ContainsKey(1)) {
                        this.labelP0.PlayerInfo = value.Teams[0].Players[1];
                    }

                    if (value.Teams[1].Players.ContainsKey(0)) {
                        this.labelP0.PlayerInfo = value.Teams[0].Players[0];
                    }

                    if (value.Teams[1].Players.ContainsKey(1)) {
                        this.labelP0.PlayerInfo = value.Teams[1].Players[1];
                    }
                }
            }
        }

        public MatchCard() {
            InitializeComponent();
        }

        public void Clear() {
            this.labelP0.PlayerInfo = null;
            this.labelP1.PlayerInfo = null;
            this.labelP2.PlayerInfo = null;
            this.labelP3.PlayerInfo = null;
        }

        private void OnDrop(object receiver, DragEventArgs e) {
            if (!(receiver is MatchLabel matchLabel)) return;
            Debug.WriteLine($"Match Card Start Drop {matchLabel.Team} {matchLabel.Position}");
           
            DragData dragData = (DragData)e.Data.GetData(typeof(DragData));
            matchLabel.SwapPlayers(dragData.Source);

            Debug.WriteLine(this.Match.ToString());

            Debug.WriteLine("Match Card Exit Drop");
        }

        private void StartDrag(object sender, MouseEventArgs e) {
            if (!(sender is MatchLabel matchLabel)) return;
            if (matchLabel.PlayerInfo == null) return;

            Debug.WriteLine($"Match Card Start Drag {matchLabel.Team} {matchLabel.Position}");
            matchLabel.ForeColor = Color.LightGray;
            matchLabel.DoDragDrop(new DragData { Source = matchLabel }, DragDropEffects.Move);
            matchLabel.ForeColor = Color.Black;
            Debug.WriteLine("Match Card Exit Drag");
        }

        private void OnEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void OnExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }

        private void LabelUpdate(object sender, MatchLabelArgs args) {
            Debug.WriteLine("Label Update");
            this.Match.Teams[args.Team].Players[args.Position] = args.PlayerInfo;
        }
    }
}

