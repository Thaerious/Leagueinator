using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.Model.Search_Algorithms;
using Leagueinator.Search_Algorithms;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        private League _league;

        private string filename = "";

        public League League {
            get { return _league; }
            set {
                _league = value;

                if (value == null) {
                    menuEvents.Enabled = false;
                    editEventPanel.Visible = false;
                    editEventPanel.LeagueEvent = null;
                    return;
                };

                if (League.Events.Count > 0) {
                    // Display the latest event if there is one.
                    editEventPanel.LeagueEvent = League.Events[League.Events.Count - 1];
                    editEventPanel.Visible = true;
                }
                else {
                    editEventPanel.LeagueEvent = null;
                    editEventPanel.Visible = false;
                }

                menuEvents.Enabled = true;
            }
        }

        public FormMain() {
            InitializeComponent();

            IsSaved.Singleton.Update += value => {
                if (value) this.Text = this.filename;
                else this.Text = this.filename + " *";
            };
        }

        private void Menu_File_New(object sender, EventArgs e) {
            League = new League();
        }

        private void Menu_File_Close(object sender, EventArgs e) {
            Text = "Leagueinator";
            League = null;
        }

        private void Menu_File_Exit(object sender, EventArgs e) {
            Close();
        }

        private void Menu_View_Players(object sender, EventArgs e) {
            editEventPanel.Visible = false;
        }

        private void Menu_View_Event
            (object sender, EventArgs e) {
            if (editEventPanel.LeagueEvent == null) return;

            editEventPanel.RefreshRound();
            editEventPanel.LeagueEvent = editEventPanel.LeagueEvent;
            editEventPanel.Visible = true;
        }

        private void Menu_Events_Add(object sender, EventArgs e) {
            FormAddEvent childForm = new FormAddEvent();
            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            editEventPanel.Visible = true;

            LeagueEvent lEvent = _league.AddEvent(
                childForm.EventName,
                childForm.Date,
                childForm.Settings
            );
            editEventPanel.LeagueEvent = lEvent;
        }

        private void menuPrintCurrentEvent(object sender, EventArgs e) {
            Debug.WriteLine(editEventPanel.LeagueEvent);
        }

        private void Menu_Event_AddPlayer(object sender, EventArgs e) {
            var form = new FormAddPlayer();
            form.OnAddPlayer += editEventPanel.AddPlayer;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void Menu_Event_Select(object sender, EventArgs e) {
            FormSelectEvent childForm = new FormSelectEvent();
            childForm.SetEvents(League.Events);

            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            if (childForm.Action == "Select") {
                LeagueEvent lEvent = childForm.LeagueEvent;
                editEventPanel.LeagueEvent = lEvent;
                editEventPanel.Visible = true;
            }
            else if (childForm.Action == "Delete") {
                League.Events.Remove(childForm.LeagueEvent);
                if (editEventPanel.LeagueEvent == childForm.LeagueEvent) {
                    editEventPanel.Visible = false;
                    editEventPanel.LeagueEvent = null;
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
                SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    LoadFile(dialog.FileName);
                }
            }
        }

        private void Menu_File_SaveAs(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
                SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    SaveAs(dialog.FileName);
                }
            }
        }

        private void Menu_File_Save(object sender, EventArgs e) {
            if (this.filename == null) {
                Menu_File_SaveAs(sender, e);
            }
            else {
                SaveAs(this.filename);
            }
        }

        private void SaveAs(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)) {
                formatter.Serialize(stream, League);
                this.filename = filename;
                IsSaved.Singleton.Value = true;
            }
        }

        private void LoadFile(string filename) {
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open)) {
                    League = (League)formatter.Deserialize(stream);
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
            Debug.WriteLine(League);
        }

        private void Menu_File_Print(object sender, EventArgs e) {
            var round = editEventPanel.CurrentRound;
            if (round == null) return;
            ScoreCardPrinter.Print(round);
        }

        private void Menu_Dev_PrintRound(object sender, EventArgs e) {
            var round = editEventPanel.CurrentRound;
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
            LeagueEvent lEvent = editEventPanel.LeagueEvent;
            Round round = editEventPanel.CurrentRound;
            if (lEvent == null || round == null) return;

            round.ResetPlayers();

            var solution = new PartnerSolution(lEvent, round);
            var algo = new GreedyWalk();
            solution.Randomize();

            var best = algo.Run(solution, s => {
                Debug.WriteLine($"{algo.Generation} : {s.Round.GetHashCode()} {s.Round.SeekDeep<PlayerInfo>().DelString()} [{s.Evaluate()}]");
            });

            editEventPanel.CurrentRound.CopyFrom(best.Round);
            editEventPanel.RefreshRound();
        }

        private void Menu_Dev_EvaluateRound(object sender, EventArgs e) {
            var lEvent = editEventPanel.LeagueEvent;
            var round = editEventPanel.CurrentRound;
            var g = new PartnerSolution(lEvent, round);
            string msg = $"Round Partner Weight : {g.Evaluate() - round.Teams.Count}";
            MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_Events_Assign_Copy(object sender, EventArgs e) {
            Round current = editEventPanel.CurrentRound;
            Round prev = null;
            foreach (Round round in editEventPanel.LeagueEvent) {
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

            editEventPanel.RefreshRound();
        }

        private void Menu_Events_Assign_Clear(object sender, EventArgs e) {
            editEventPanel.CurrentRound.ResetPlayers();
            editEventPanel.RefreshRound();
        }

        private void Menu_Dev_PrintPlayers(object sender, EventArgs e) {
            string s = League.SeekDeep<PlayerInfo>().DelString();
            Debug.WriteLine($"[{s}]");
        }

        private void refreshRoundToolStripMenuItem_Click(object sender, EventArgs e) {
            editEventPanel.RefreshRound();
        }

        private void Menu_Event_AssignLanes(object sender, EventArgs e) {

        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
