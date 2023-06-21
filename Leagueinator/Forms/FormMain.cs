using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.Utility_Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

                foreach (var playerInfo in value.Players) {
                    this.playersPanel.AddPlayer(playerInfo);
                }

                if (League.Events.Count > 0) {
                    this.editEventPanel.LeagueEvent = League.Events[League.Events.Count - 1];
                    this.playersPanel.Visible = false;
                    this.editEventPanel.Visible = true;
                } else {
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
            this.playersPanel.PlayerAdded += (s,a)=> this.League.Players.Add(a.PlayerInfo);

            if (this.LastSave != null && this.LastSave != "") {
                this.load(this.LastSave);
            }
        }

        private void menuFileNew(object sender, EventArgs e) {
            this.League = new League();
        }

        private void menuFileClose(object sender, EventArgs e) {
            this.LastSave = "";
            this.Text = "Leagueinator";
            this.League = null;
        }

        private void menuFileExit(object sender, EventArgs e) {
            this.Close();
        }

        private void menuViewPlayers(object sender, EventArgs e) {
            this.playersPanel.Visible = true;
            this.editEventPanel.Visible = false;
        }

        private void menuEventsAdd(object sender, EventArgs e) {
            FormAddEvent childForm = new FormAddEvent();
            DialogResult result = childForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;

            LeagueEvent lEvent = this._league.AddEvent(childForm.Settings);
            lEvent.AddRound();
            this.editEventPanel.LeagueEvent = lEvent;
        }

        private void menuPrintCurrentEvent(object sender, EventArgs e) {
            Debug.WriteLine(this.editEventPanel.LeagueEvent);
        }

        private void MenuViewEvent(object sender, EventArgs e) {
            if (this.editEventPanel.LeagueEvent == null) return;
            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;            
        }

        private void MenuEventAddPlayer(object sender, EventArgs e) {
            var form = new FormAddPlayer();
            if (form.ShowDialog() == DialogResult.OK) {
                var playerInfo = this.League.AddPlayer(form.PlayerName);
                this.editEventPanel.AddPlayer(playerInfo);
            }
        }

        private void menuEventSelect(object sender, EventArgs e) {
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

        private void setupDialog(FileDialog dialog) {
            dialog.InitialDirectory = Properties.Settings.Default.save_dir;
            dialog.Filter = "league files (*.league)|*.league|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.FileName = this.LastSave;
        }

        private void menuFileLoad(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                this.setupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.load(dialog.FileName);
                    this.LastSave = dialog.FileName;
                }
            }
        }

        private void menuFileSaveAs(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
                this.setupDialog(dialog);

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.saveAs(dialog.FileName);
                    this.LastSave = dialog.FileName;
                    openFilename = dialog.FileName;
                }
            }
        }

        private void menuFileSave(object sender, EventArgs e) {
            if (this.openFilename == null) {
                menuFileSaveAs(sender, e);
            } else {
                this.saveAs(this.openFilename);
            }
        }

        private void saveAs(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)){
                formatter.Serialize(stream, this.League);
            }
        }

        private void load(string filename) {
            Debug.WriteLine("Load " + filename);

            try {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open)) {
                    this.League = (League)formatter.Deserialize(stream);
                }
            }catch (Exception ex) {
                MessageBox.Show(ex.Message, "Excepion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuActionsPrintLeague(object sender, EventArgs e) {
            Debug.WriteLine(this.League);
        }

        private void menuFilePrint(object sender, EventArgs e) {
            var round = this.editEventPanel.CurrentRound;
            if (round == null) return;                
            ScoreCardPrinter.Print(round);
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
