using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;
using Leagueinator.utility_classes;

namespace Leagueinator.Utility_Classes {
    public class ScoreCardPrinter {

        public static void Print(Round round) { 
            WebBrowser wb = new WebBrowser();
            StringInterpolator si = BuildInterpolationMap(round);
            var input = GetInputHTML(si);
            Debug.WriteLine(input);
            wb.DocumentCompleted += OnDocComplete;
            wb.DocumentText += input;
        }

        public static StringInterpolator BuildInterpolationMap(Round round) {
            var si = new StringInterpolator();

            int matchNo = 0;
            for (int lane = 0; lane < round.Matches.Length; lane++) {                
                Match match = round.Matches[lane];
                if (match.Players().Count > 0) {
                    matchNo++;
                    si[$"M{matchNo}LANE"] = $"{lane + 1}";
                    for (int t = 0; t < round.Matches[lane].Teams.Length; t++) {
                        Team team = round.Matches[lane].Teams[t];
                        for(int p = 0; p < team.Players.Length; p++) {
                            PlayerInfo player = team.Players[p];
                            if (player == null) {
                                si[$"M{matchNo}T{t + 1}P{p + 1}"] = "";
                            }
                            else {
                                si[$"M{matchNo}T{t + 1}P{p + 1}"] = player.Name;
                            }
                        }
                    }
                }
            }
            return si;
        }

        public static void OnDocComplete(object sender, WebBrowserDocumentCompletedEventArgs args) {
            WebBrowser browser = (WebBrowser)sender;
            browser.ShowPrintPreviewDialog();
        }

        public static string GetInputHTML(StringInterpolator si) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Leagueinator.Assets.input.html";
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName)) {
                using (StreamReader reader = new StreamReader(resourceStream)) {
                    string input = reader.ReadToEnd();
                    return si.Interpolate(input);
                }
            }
        }
    }
}

/* https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.webbrowser.print?redirectedfrom=MSDN&view=windowsdesktop-7.0#System_Windows_Forms_WebBrowser_Print */
