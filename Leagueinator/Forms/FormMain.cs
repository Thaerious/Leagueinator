using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.Algorithms.Solutions;
using Leagueinator.Algorithms;
using Leagueinator.Utility_Classes;
using System.Drawing.Printing;
using MatchPrinter;
using Leagueinator.Controller;
using System.Collections.Generic;
using System.Linq;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        private League _league = new League();

        private string filename = "";

        public League League {
            get { return this._league; }
            set {
                this._league = value;

                if (value == null) {
                    this.menuEvents.Enabled = false;
                    this.editEventPanel.Visible = false;
                    this.editEventPanel.LeagueEvent = null;
                    return;
                };

                if (this.League.Events.Count > 0) {
                    // Display the latest event if there is one.
                    this.editEventPanel.LeagueEvent = this.League.Events[this.League.Events.Count - 1];
                    this.editEventPanel.Visible = true;
                }
                else {
                    this.editEventPanel.LeagueEvent = null;
                    this.editEventPanel.Visible = false;
                }

                this.menuEvents.Enabled = true;
            }
        }

        public FormMain() {
            this.InitializeComponent();
            IsSaved.Singleton.Value = true;

            IsSaved.Singleton.Update += value => {
                if (value) this.Text = this.filename;
                else this.Text = this.filename + " *";
            };

            this.editEventPanel.RenamePlayer += new Leagueinator.Components.PlayerInfoArgs.PlayerInfoEvent(this.HndRenamePlayer);
            this.editEventPanel.DeletePlayer += new Leagueinator.Components.PlayerInfoArgs.PlayerInfoEvent(this.HndDeletePlayer);
        }

        private void Menu_File_New(object sender, EventArgs e) {
            this.League = new League();
        }

        private void Menu_File_Close(object sender, EventArgs e) {
            this.Text = "Leagueinator";
            this.League = null;
        }

        private void Menu_File_Exit(object sender, EventArgs e) {
            this.Close();
        }

        private void Menu_Events_Add(object _ = null, EventArgs __ = null) {
            var childForm = new FormAddEvent();
            if (childForm.ShowDialog() == DialogResult.Cancel) return;

            var lEvent = this.League.AddEvent(
                childForm.EventName,
                childForm.Date,
                childForm.Settings
            );

            IsSaved.Singleton.Value = false;
            this.editEventPanel.Visible = true;
            this.editEventPanel.LeagueEvent = lEvent;
        }

        private void menuPrintCurrentEvent(object sender, EventArgs e) {
            Debug.WriteLine(this.editEventPanel.LeagueEvent);
        }

        private void Menu_Event_AddPlayer(object sender, EventArgs e) {
            var form = new FormAddPlayer();
            form.OnAddPlayer += this.editEventPanel.AddPlayer;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void Menu_Event_Select(object sender, EventArgs e) {
            FormSelectEvent childForm = new FormSelectEvent();
            childForm.SetEvents(this.League.Events);

            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            if (childForm.Action == "Select") {
                LeagueEvent lEvent = childForm.LeagueEvent;
                this.editEventPanel.LeagueEvent = lEvent;
                this.editEventPanel.Visible = true;
            }
            else if (childForm.Action == "Delete") {
                this.League.Events.Remove(childForm.LeagueEvent);
                if (this.editEventPanel.LeagueEvent == childForm.LeagueEvent) {
                    this.editEventPanel.Visible = false;
                    this.editEventPanel.LeagueEvent = null;
                }
            }
        }

        private void SetupDialog(FileDialog dialog) {
            dialog.InitialDirectory = Properties.Settings.Default.save_dir;
            dialog.Filter = "league files (*.league)|*.league|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
        }

        private void Menu_File_Load(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                this.SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.LoadFile(dialog.FileName);
                }
            }
        }

        private void Menu_File_SaveAs(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
                this.SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.SaveAs(dialog.FileName);
                }
            }
        }

        private void Menu_File_Save(object sender, EventArgs e) {
            if (this.filename.IsEmpty()) {
                this.Menu_File_SaveAs(sender, e);
            }
            else {
                this.SaveAs(this.filename);
            }
        }

        private void SaveAs(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)) {
                formatter.Serialize(stream, this.League);
                this.filename = filename;
                IsSaved.Singleton.Value = true;
            }
        }

        private void LoadFile(string filename) {
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open)) {
                    this.League = (League)formatter.Deserialize(stream);
                }
                this.filename = filename;
                IsSaved.Singleton.Value = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Excepion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void menuActionsPrintLeague(object sender, EventArgs e) {
            Debug.WriteLine(this.League);
        }

        private void Menu_File_Print_Preview(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;
            //ScoreCardPrinter.Print(round);

            int currentRoundIndex = this.editEventPanel.LeagueEvent.Rounds.IndexOf(this.editEventPanel.CurrentRound);
            var mcp = new MatchCardPrinter(round, currentRoundIndex);
            this.printDocument.PrintPage += mcp.HndPrint;

            this.printPreview.Document = this.printDocument;
            this.printPreview.ShowDialog();
        }

        private void Menu_File_Print(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;
            //ScoreCardPrinter.Print(round);

            int currentRoundIndex = this.editEventPanel.LeagueEvent.Rounds.IndexOf(this.editEventPanel.CurrentRound);
            var mcp = new MatchCardPrinter(round, currentRoundIndex);

            if (this.printDialog.ShowDialog() == DialogResult.OK) {
                this.printDocument.PrintPage += mcp.HndPrint;
                this.printDocument.Print();
            }
        }

        private void Menu_Dev_PrintRound(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;
            Debug.WriteLine(round);
        }

        private void Menu_Help_About(object sender, EventArgs e) {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
            string msg = $"Version\n{version}\n({buildDate})";
            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_Events_Assign_Partners(object sender, EventArgs e) {
            LeagueEvent lEvent = this.editEventPanel.LeagueEvent;
            Round round = this.editEventPanel.CurrentRound;
            if (lEvent == null || round == null) return;

            round.ResetPlayers();

            var solution = new PartnerSolution(lEvent, round);
            var algo = new GreedyWalk();
            solution.Randomize();

            var best = algo.Run(solution, s => {
                Debug.WriteLine($"{algo.Generation} : {s.Round.GetHashCode()} {s.Round.SeekDeep<PlayerInfo>().DelString()} [{s.Evaluate()}]");
            });

            this.editEventPanel.CurrentRound.CopyFrom(best.Round);
            this.editEventPanel.RefreshRound();
        }

        private void Menu_Dev_EvaluateRound(object sender, EventArgs e) {
            var lEvent = this.editEventPanel.LeagueEvent;
            var round = this.editEventPanel.CurrentRound;
            var g = new PartnerSolution(lEvent, round);
            string msg = $"Round Partner Weight : {g.Evaluate() - round.Teams.Count}";
            MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_Events_Assign_Copy(object sender, EventArgs e) {
            Round current = this.editEventPanel.CurrentRound;
            Round prev = null;
            foreach (Round round in this.editEventPanel.LeagueEvent) {
                if (round == current) break;
                prev = round;
            }
            if (prev == null) return;

            current.ResetPlayers();

            for (int i = 0; i < prev.MaxSize; i++) {
                var match = prev.Matches[i];
                for (int j = 0; j < match.MaxSize; j++) {
                    var team = match[j];
                    for (int k = 0; k < team.MaxSize; k++) {
                        current.IdlePlayers.Remove(team[k]);
                        current[i][j][k] = team[k];
                    }
                }
            }

            this.editEventPanel.RefreshRound();
        }

        private void Menu_Events_Assign_Clear(object sender, EventArgs e) {
            this.editEventPanel.CurrentRound.ResetPlayers();
            this.editEventPanel.RefreshRound();
        }

        private void Menu_Dev_PrintPlayers(object sender, EventArgs e) {
            string s = this.League.SeekDeep<PlayerInfo>().DelString();
            Debug.WriteLine($"[{s}]");
        }

        private void refreshRoundToolStripMenuItem_Click(object sender, EventArgs e) {
            this.editEventPanel.RefreshRound();
        }

        private void Menu_Event_AssignLanes(object sender, EventArgs e) {
            var lEvent = this.editEventPanel.LeagueEvent;
            Round round = this.editEventPanel.CurrentRound;

            var solution = new LaneSolution(lEvent, round);
            var algo = new GreedyWalk();
            
            int index = lEvent.IndexOf(round);

            var best = algo.Run(solution, s => {
                Debug.WriteLine($"{algo.Generation} : [{s.Evaluate()}]");
            });

            lEvent.ReplaceRound(round, best.Value());
            this.editEventPanel.SetCurrentRound(best.Value());
            this.editEventPanel.RefreshRound();
        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e) {
            LeagueEvent lEvent = this.editEventPanel.LeagueEvent;
            Round round = this.editEventPanel.CurrentRound;
            if (lEvent == null || round == null) return;

            var solution = new PartnerSolution(lEvent, round);
            solution.Randomize();

            this.editEventPanel.CurrentRound.CopyFrom(solution.Round);
            this.editEventPanel.RefreshRound();
        }

        private void butAddEvent_Click(object sender, EventArgs e) {
            Menu_Events_Add();
        }

        private void roundRobinToolStripMenuItem_Click(object sender, EventArgs e) {
            LeagueEvent lEvent = this.editEventPanel.LeagueEvent;
            Round current = this.editEventPanel.CurrentRound;

            if (current == null) return;

            Round reference = lEvent[0];
            RoundRobin rr = new RoundRobin(reference);
            int index = lEvent.IndexOf(current);
            Round newRound = rr.Value(index);
            lEvent.ReplaceRound(current, newRound);
            this.editEventPanel.SetCurrentRound(newRound);
            this.editEventPanel.RefreshRound();
        }

        private void Menu_Events_Settings_Click(object sender, EventArgs e) {
            var childForm = new FormAddEvent();
            childForm.Text = "Event Settings";
            childForm.Settings = this.editEventPanel.LeagueEvent.Settings;
            childForm.Reassign = true;

            if (childForm.ShowDialog() == DialogResult.Cancel) return;

            IsSaved.Singleton.Value = false;
            this.editEventPanel.Visible = true;            
        }

        private void printScoreKeeperToolStripMenuItem_Click(object sender, EventArgs e) {
            var scoreKeeper = new ScoreKeeper(this.editEventPanel.LeagueEvent);
            var lables = scoreKeeper.Labels.ToList();
            lables.Insert(0, "name");
            Debug.WriteLine(lables.ToArray().DelString(12, "| "));

            List<PlayerInfo> list = this.editEventPanel.LeagueEvent.SeekDeep<PlayerInfo>();
            list.Unique();
            list.Sort(new ScoreComparer(scoreKeeper));
            list.Reverse();

            foreach (PlayerInfo player in list) {
                var data = scoreKeeper[player].ToArray().Select(i => i.ToString()).ToList();
                data.Insert(0, player.Name);
                Debug.WriteLine(data.ToArray().DelString(12, "| "));
            }
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
