using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatchPrinter {

 
    public class MatchCardPrinter : IDisposable {
        int rowHeight = 40;
        Brush lightGrayBrush = new SolidBrush(Color.LightGray);
        Pen blackPen = new Pen(Color.Black, 2);
        Pen grayPen = new Pen(Color.Gray, 2);
        Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

        int lane = 4;

        int pageWidth = 850;
        int pageHeight = 1100;

        private readonly Round round;
        private readonly int roundIndex;
        private int matchIndex = -1;
        private Match match = null;
        private int countCardsPrinted = 0;

        public MatchCardPrinter(Round currentRound, int currentRoundIndex) {
            this.round = currentRound;
            this.roundIndex = currentRoundIndex;
            this.match = this.AdvanceMatch();
        }

        private Match AdvanceMatch() {
            while (++matchIndex < this.round.Settings.LaneCount) {
                if (this.round[matchIndex].Players.Count > 0) {
                    return this.round[matchIndex];
                }
            }
            return null;
        }

        StringFormat centered = new StringFormat {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public void HndPrint(object sender, PrintPageEventArgs e) {
            e.HasMorePages = this.DrawNextPage(e.Graphics);
        }


        private Rectangle DrawTitle(Graphics g, Rectangle loc, int round, int lane) {
            Rectangle[] split = loc.SplitHorz(2);
            g.DrawString($"Round {round}", font, Brushes.Black, split[0], centered);
            g.DrawString($"Lane {lane}", font, Brushes.Black, split[1], centered);
            return loc;
        }

        private Rectangle DrawInfo(Graphics g, Rectangle loc, string[] names1, string[] names2) {
            Rectangle[] split = loc.SplitHorz(45, 10, 45);

            this.DrawNames(g, split[0], names1);
            g.DrawString("VS", font, Brushes.Black, split[1], centered);
            this.DrawNames(g, split[2], names2);

            g.DrawRectangle(blackPen, loc);
            return loc;
        }

        private Rectangle DrawNames(Graphics g, Rectangle loc, string[] names) {
            Rectangle[] split = loc.SplitVert(names.Length).Shrink(10);

            for (int i = 0; i < names.Length; i++) {
                g.DrawString(names[i], font, Brushes.Black, split[i], centered);
                g.DrawRectangle(grayPen, split[i]);
            }

            return loc;
        }

        private Rectangle DrawTable(Graphics g, Rectangle loc, int numEnds) {
            Rectangle[] split = loc.SplitVert(numEnds + 1);
            this.DrawHeader(g, split[0]);

            for (int i = 0; i < numEnds; i++) {
                DrawRow(g, split[i + 1], i + 1);
            }

            return loc;
        }

        private Rectangle DrawHeader(Graphics g, Rectangle loc) {
            string[] strings = new string[5] { "Shots", "Total", "End", "Shots", "Total" };
            Rectangle[] split = loc.SplitHorz(5);

            g.FillRectangle(lightGrayBrush, loc);

            for (int i = 0; i < strings.Length; i++) {
                g.DrawString(strings[i], font, Brushes.Black, split[i], centered);
                g.DrawRectangle(blackPen, split[i]);
            }

            return loc;
        }

        private Rectangle DrawRow(Graphics g, Rectangle loc, int lane) {
            Rectangle[] split = loc.SplitHorz(5);

            g.FillRectangle(lightGrayBrush, split[2]);

            foreach (Rectangle r in split) {
                g.DrawRectangle(blackPen, r);
            }

            g.DrawString(lane.ToString(), font, Brushes.Black, split[2], centered);

            return loc;
        }

        private Bitmap DrawTable(Match match, int lane, int roundIDX) {
            Bitmap bmp = new Bitmap(1100, 850);
            Graphics g = Graphics.FromImage(bmp);

            string[] n1 = match[0].Players.Select(pi => pi.Name).ToArray();
            string[] n2 = match[1].Players.Select(pi => pi.Name).ToArray();
            int numEnds = match.Settings.NumberOfEnds;

            var rect1 = this.DrawTitle(g, new Rectangle(0, 0, 350, 40), roundIDX, lane);
            var rect2 = this.DrawInfo(g, rect1.Below(this.rowHeight * match.Settings.TeamSize), n1, n2);
            var rect3 = this.DrawTable(g, rect2.Below(this.rowHeight * (numEnds + 1)).MoveDown(5), numEnds);
            Rectangle area = RectangleExtensions.Merge(rect1, rect2, rect3);

            return bmp.Clone(area, bmp.PixelFormat);
        }

        /// <summary>
        /// Main entry point for printing.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="round"></param>
        /// <param name="roundIDX"></param>
        /// <returns>True if there are more pages to print, otherwise false</returns>
        private bool DrawNextPage(Graphics g) {
            int y = 50;

            while (match != null) {
                int x = countCardsPrinted % 2 == 0 ? 50 : 450;

                Bitmap bmp = DrawTable(match, this.matchIndex, this.roundIndex);

                if (y + bmp.Height > 1100) {
                    return true;
                }
                else {
                    Debug.WriteLine(countCardsPrinted);
                    Debug.WriteLine($"{x} {y}");
                    Debug.WriteLine(match);
                    g.DrawImage(bmp, x, y);
                    y += countCardsPrinted % 2 == 1 ? bmp.Height + 50 : 0;
                }

                countCardsPrinted++;
                match = this.AdvanceMatch();
            }

            return false;
        }

        public void Dispose() {
            this.lightGrayBrush.Dispose();
            this.blackPen.Dispose();
            this.grayPen.Dispose();
            this.font.Dispose();
        }
    }
}
