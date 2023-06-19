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
    public partial class MatchCard : UserControl {
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
                return match;
            }
            set {
                if (value != null) {
                    this.match = value.DeepCopy();
                    this.labelP0.PlayerInfo = value.Teams[0].Players[0];
                    this.labelP1.PlayerInfo = value.Teams[0].Players[1];
                    this.labelP2.PlayerInfo = value.Teams[1].Players[0];
                    this.labelP3.PlayerInfo = value.Teams[1].Players[1];
                }
            }
        }

        public MatchCard() {
            InitializeComponent();
        }

        private void OnDrop(object receiver, DragEventArgs e) {
            if (!(receiver is MatchLabel matchLabel)) return;
            Debug.WriteLine($"Match Card Start Drop {matchLabel.Team} {matchLabel.Position}");

            DragData dragData = (DragData)e.Data.GetData(typeof(DragData));
            matchLabel.SwapPlayers(dragData.Source);

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
            this.Match.Teams[args.Team].Players[args.Position] = args.PlayerInfo;
        }
    }
}

