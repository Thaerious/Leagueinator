using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        private League _league;
        private string openFilename = null;

        public League League {
            get { return _league; }
            set {
                this._league = value;
                this.playersPanel.Clear();

                if (value == null) {
                    this.menuView.Enabled = false;
                    this.menuEvents.Enabled = false;
                    this.playersPanel.Visible = false;
                    this.editEventPanel.Visible = false;
                    this.editEventPanel.LeagueEvent = null;
                    return;
                };

                if (League.Events.Count > 0) {
                    this.editEventPanel.LeagueEvent = League.Events[League.Events.Count - 1];
                    this.playersPanel.Visible = false;
                    this.editEventPanel.Visible = true;
                }
                else {
                    this.editEventPanel.LeagueEvent = null;
                    this.playersPanel.Visible = true;
                    this.editEventPanel.Visible = false;
                }

                this.menuEvents.Enabled = true;
                this.menuView.Enabled = true;
            }
        }

        private string LastSave {
            get {
                return Properties.Settings.Default.last_save_name;
            }
            set {
                Properties.Settings.Default.last_save_name = value;
                Properties.Settings.Default.Save();
            }
        }

        public FormMain() {
            InitializeComponent();

            if (this.LastSave != null && this.LastSave != "") {
                this.LoadFile(this.LastSave);
            }
        }

        private void Menu_File_New(object sender, EventArgs e) {
            this.League = new League();
        }

        private void Menu_File_Close(object sender, EventArgs e) {
            this.LastSave = "";
            this.Text = "Leagueinator";
            this.League = null;
        }

        private void Menu_File_Exit(object sender, EventArgs e) {
            this.Close();
        }

        private void Menu_View_Players(object sender, EventArgs e) {
            this.playersPanel.League = this.League;
            this.playersPanel.Visible = true;
            this.editEventPanel.Visible = false;
        }

        private void Menu_View_Event
            (object sender, EventArgs e) {
            if (this.editEventPanel.LeagueEvent == null) return;
            this.editEventPanel.LeagueEvent = this.editEventPanel.LeagueEvent;
            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;
        }

        private void Menu_Events_Add(object sender, EventArgs e) {
            FormAddEvent childForm = new FormAddEvent();
            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;

            LeagueEvent lEvent = this._league.AddEvent(
                childForm.EventName,
                childForm.Date,
                childForm.Settings
            );
            this.editEventPanel.LeagueEvent = lEvent;
        }

        private void menuPrintCurrentEvent(object sender, EventArgs e) {
            Debug.WriteLine(this.editEventPanel.LeagueEvent);
        }

        private void Menu_Event_AddPlayer(object sender, EventArgs e) {
            var form = new FormAddPlayer();
            form.StartPosition = FormStartPosition.CenterParent;

            if (form.ShowDialog() == DialogResult.OK) {
                this.editEventPanel.AddPlayer(new PlayerInfo(form.PlayerName));
            }
        }

        private void Menu_Event_Select(object sender, EventArgs e) {
            FormSelectEvent childForm = new FormSelectEvent();
            childForm.SetEvents(this.League.Events);

            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            if (childForm.Action == "Select") {
                LeagueEvent lEvent = childForm.LeagueEvent;
                this.editEventPanel.LeagueEvent = lEvent;
                this.playersPanel.Visible = false;
                this.editEventPanel.Visible = true;
            }
            else if (childForm.Action == "Delete") {
                this.League.Events.Remove(childForm.LeagueEvent);
                if (this.editEventPanel.LeagueEvent == childForm.LeagueEvent) {
                    this.playersPanel.Visible = true;
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
            dialog.FileName = this.LastSave;
        }

        private void Menu_File_Load(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                this.SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.LoadFile(dialog.FileName);
                    this.LastSave = dialog.FileName;
                }
            }
        }

        private void Menu_File_SaveAs(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
                this.SetupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.SaveAs(dialog.FileName);
                    this.LastSave = dialog.FileName;
                    openFilename = dialog.FileName;
                }
            }
        }

        private void Menu_FIle_Save(object sender, EventArgs e) {
            if (this.openFilename == null) {
                Menu_File_SaveAs(sender, e);
            }
            else {
                this.SaveAs(this.openFilename);
            }
        }

        private void SaveAs(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)) {
                formatter.Serialize(stream, this.League);
            }
        }

        private void LoadFile(string filename) {
            this.Text = filename;

            try {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open)) {
                    this.League = (League)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Excepion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuActionsPrintLeague(object sender, EventArgs e) {
            Debug.WriteLine(this.League);
        }

        private void Menu_File_Print(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;
            ScoreCardPrinter.Print(round);
        }

        private void Menu_Dev_PrintRound(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;
            Debug.WriteLine(round);
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
