using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Html2pdf;

namespace Leagueinator.utility_classes {
    public class ScoreCardPrinter {
        public static void Print(RoundCollection roundCollection) {
            Queue<Match> matchList = new Queue<Match>();
            foreach (var round in roundCollection.Rounds) {
                foreach(var match in round) {
                    matchList.Enqueue(match);
                }
            }

            int i = 0;
            while (matchList.Count > 0) {
                Match m1 = matchList.Count > 0 ? matchList.Dequeue() : null;
                Match m2 = matchList.Count > 0 ? matchList.Dequeue() : null;
                Match m3 = matchList.Count > 0 ? matchList.Dequeue() : null;
                Match m4 = matchList.Count > 0 ? matchList.Dequeue() : null;

                var inputHTML = GetInputHTML();
                var map = new Dictionary<string, string>();
                m1?.ToDictionary(map, "M1");
                m2?.ToDictionary(map, "M2");
                m3?.ToDictionary(map, "M3");
                m4?.ToDictionary(map, "M4");

                if (m1 != null) map["M1LANE"] = m1.Lane.ToString();
                if (m2 != null) map["M2LANE"] = m2.Lane.ToString();
                if (m3 != null) map["M3LANE"] = m3.Lane.ToString();
                if (m4 != null) map["M4LANE"] = m4.Lane.ToString();

                var markedUp = new StringInterpolator(inputHTML, map).ToString();                
                MakeMatchPDF(markedUp, $"output_{i++}.pdf");
            }
        }

        public static string GetInputHTML() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Leagueinator.Assets.input.html";
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName)) {
                using (StreamReader reader = new StreamReader(resourceStream)) {
                    return reader.ReadToEnd();
                }
            }
        }
        public static void MakeMatchPDF(string inputHTML,string filename) {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Debug.WriteLine(path);
            var fullpath = Path.Combine(path, "Leagueinator");
            Directory.CreateDirectory(fullpath);

            using (FileStream pdfDest = File.Open(filename, FileMode.Create)) {
                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(inputHTML, pdfDest, converterProperties);
            }
        }
    }
}
