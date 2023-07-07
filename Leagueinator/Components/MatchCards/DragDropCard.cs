using Leagueinator.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Leagueinator.Components {

    internal class DragDropCard {
        private static MatchCard source;
        private static MatchCard destination;

        public DragDropCard(MatchCard matchCard) {
            matchCard.AllowDrop = true;
            matchCard.MouseDown += new MouseEventHandler(this.StartDrag);
            matchCard.DragDrop += new DragEventHandler(this.OnDrop);
            matchCard.DragEnter += new DragEventHandler(this.OnEnter);
            matchCard.DragLeave += new EventHandler(this.OnExit);
        }

        private void OnExit(object sender, EventArgs e) {
            DragDropCard.SwapDestAndSrc();
            DragDropCard.source.Labels().ForEach(c => c.ForeColor = Color.Black);
            DragDropCard.destination.Labels().ForEach(c => c.ForeColor = Color.Black);

            DragDropCard.destination = DragDropCard.source;
        }

        private void OnEnter(object sender, DragEventArgs e) {
            if (!(sender is MatchCard currentCard)) return;
            e.Effect = DragDropEffects.Move;

            DragDropCard.destination = sender as MatchCard;
            DragDropCard.SwapDestAndSrc();
            DragDropCard.source.Labels().ForEach(c => c.ForeColor = Color.LightGray);
            DragDropCard.destination.Labels().ForEach(c => c.ForeColor = Color.LightGray);
        }

        private void OnDrop(object sender, DragEventArgs e) {
            if (!(sender is MatchCard currentCard)) return;
            DragDropCard.source.Labels().ForEach(c => c.ForeColor = Color.Black);
        }

        private void StartDrag(object sender, MouseEventArgs e) {
            DragDropCard.source = sender as MatchCard;
            DragDropCard.destination = sender as MatchCard;

            DragDropCard.source.Labels().ForEach(c => c.ForeColor = Color.LightGray);

            DragDropCard.source.DoDragDrop(sender, DragDropEffects.Move);

            DragDropCard.source.Labels().ForEach(c => c.ForeColor = Color.Black);
            DragDropCard.destination.Labels().ForEach(c => c.ForeColor = Color.Black);
        }

        private static void SwapDestAndSrc() {
            (DragDropCard.destination.Match, DragDropCard.source.Match) =
            (DragDropCard.source.Match, DragDropCard.destination.Match);

            Match m1 = DragDropCard.destination.Match;
            Match m2 = DragDropCard.source.Match;
            Round r = DragDropCard.destination.Round;
            int i1 = r.Matches.IndexOf(m1);
            int i2 = r.Matches.IndexOf(m2);
            (r[i1], r[i2]) = (r[i2], r[i1]);
        }
    }
}
