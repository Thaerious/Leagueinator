using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatchPrinter {
    internal class MatchCardGenerator {


        int rowHeight = 40;
        Brush lightGrayBrush = new SolidBrush(Color.LightGray);
        Pen blackPen = new Pen(Color.Black, 2);
        Pen grayPen = new Pen(Color.Gray, 2);
        Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

        int numEnds = 5;
        int round = 1;
        int lane = 4;

        StringFormat centered = new StringFormat {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        private void HndPrint(object sender, PrintPageEventArgs e) {
            Debug.WriteLine("Print Handler");
            if (e.Graphics == null) return;

            string[] n1 = new string[] { "Adam", "Beth" };
            string[] n2 = new string[] { "Cain", "Dave" };

            int countNames = Math.Max(n1.Length, n2.Length);
            var r1 = this.DrawTitle(e.Graphics, new Rectangle(25, 50, 350, 40), round, lane);
            var r2 = this.DrawInfo(e.Graphics, r1.Below(this.rowHeight * countNames), n1, n2);
            this.DrawTable(e.Graphics, r2.Below(this.rowHeight * (numEnds + 1)).MoveDown(5), (numEnds + 1));
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
            this.DrawNames(g, split[2], names1);

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
            Debug.WriteLine(split[0]);
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
    }
}
