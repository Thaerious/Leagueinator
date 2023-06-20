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
        private int lane = 0;
        [Category("Appearance"),Description("The lane number displayed.")]        
        public int Lane { 
            get => lane; 
            set {
                lane = value;
                this.labelLane.Text = value.ToString();
            }
        }

        private Match _match;
        public Match Match {
            get {
                return _match;
            }
            set {
                Debug.WriteLine($"Match Card Set {value}");
                if (value != null) {
                    this.labelP0.Team = value.Teams[0];
                    this.labelP1.Team = value.Teams[0];
                    this.labelP2.Team = value.Teams[1];
                    this.labelP3.Team = value.Teams[1];

                    this.labelP0.AddPlayer(value.Teams[0]?.Players[0]);
                    this.labelP1.AddPlayer(value.Teams[0]?.Players[1]);
                    this.labelP2.AddPlayer(value.Teams[1]?.Players[0]);
                    this.labelP3.AddPlayer(value.Teams[1]?.Players[1]);
                }
                this._match = value;
            }
        }

        public MatchCard() {
            InitializeComponent();
        }

        /// <summary>
        /// Player name get's dragged onto a match label
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="e"></param>
        private void OnDrop(object receiver, DragEventArgs e) {
            if (!(receiver is MatchLabel matchLabel)) return;
            Debug.WriteLine($"Match Card Start Drop {matchLabel.Team} {matchLabel.Position}");
           
            DragData dragData = (DragData)e.Data.GetData(typeof(DragData));
            dragData.SwapWith(matchLabel);

            Debug.WriteLine("Match Card Exit Drop");
        }

        private void StartDrag(object sender, MouseEventArgs e) {
            if (!(sender is MatchLabel matchLabel)) return;
            if (matchLabel.PlayerInfo == null) return;

            Debug.WriteLine($"Match Card Start Drag {matchLabel.Team} {matchLabel.Position}");
            matchLabel.ForeColor = Color.LightGray;

            this.DoDragDrop(
                new DragData { Source = matchLabel, PlayerInfo = matchLabel.PlayerInfo }
                , DragDropEffects.Move
            );

            matchLabel.ForeColor = Color.Black;
            Debug.WriteLine("Match Card Exit Drag\n");
        }

        private void OnEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void OnExit(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
        }

        private void LabelUpdate(object sender, MatchLabelArgs args) {
            Debug.WriteLine(args.Team + ", " + args.Position + ", " + args.PlayerInfo?.Name);
            Debug.WriteLine(this.Match);
            this.Match.Teams[args.Team].Players[args.Position] = args.PlayerInfo;
        }
    }
}

