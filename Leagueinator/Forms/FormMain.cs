using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.utility_classes;
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
                if (value == null) return;
                foreach (var playerInfo in value.Players) {
                    this.playersPanel.AddPlayer(playerInfo);
                }
            }
        }

        public FormMain() {
            InitializeComponent();

            this.playersPanel.PlayerAdded += PlayersPanel_PlayerAdded;

            //// TODO REMOVE
            //League league = new League();
            //league.AddPlayers(new String[] { "Ed", "Tim", "Bill", "Steve" });
            //this.League = league;
        }

        private void PlayersPanel_PlayerAdded(PlayersPanel source, PlayerArgs args) {
            this.League.Players.Add(args.PlayerInfo);
        }

        //private void menuFileNew(object sender, EventArgs e) {
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
        //        this.useDialog(saveFileDialog);
        //    }
        //}

        private void menuFileClose(object sender, EventArgs e) {
            Properties.Settings.Default.last_save_name = "";
            this.menuView.Enabled = false;
            this.Text = "Leagueinator";
            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = false;
            this.editEventPanel.LeagueEvent = null;
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

        private void menuEventViewActive(object sender, EventArgs e) {
            if (this.editEventPanel.LeagueEvent == null) return;
            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;
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

        private void menuFileLoad(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.InitialDirectory = Properties.Settings.Default.save_dir;
                dialog.Filter = "league files (*.league)|*.league|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.FileName = Properties.Settings.Default.last_save_name;

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.load(dialog.FileName);
                }
            }
        }

        private void menuFileSaveAs(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {
                dialog.InitialDirectory = Properties.Settings.Default.save_dir;
                dialog.Filter = "league files (*.league)|*.league|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.FileName = "my.league";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.saveAs(dialog.FileName);
                    Properties.Settings.Default.last_save_name = dialog.FileName;
                    openFilename = dialog.FileName;
                }
            }
        }

        private void menuFileSave(object sender, EventArgs e) {
            Debug.WriteLine(Properties.Settings.Default.last_save_name);
            if (openFilename == null) {
                menuFileSaveAs(sender, e);
            } else {
                this.saveAs(openFilename);
            }
        }

        private void saveAs(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)){
                formatter.Serialize(stream, this.League);
            }
        }

        private void load(string filename) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.Open)) {
                this.League = (League)formatter.Deserialize(stream);
                this.editEventPanel.LeagueEvent = null;
                this.playersPanel.Visible = true;
                this.editEventPanel.Visible = false;
            }
        }

        private void menuActionsPrintLeague(object sender, EventArgs e) {
            Debug.WriteLine(this.League);
        }

        private void menuFileNew(object sender, EventArgs e) {
            this.League = new League();
            this.editEventPanel.LeagueEvent = null;
            this.playersPanel.Visible = true;
            this.editEventPanel.Visible = false;
            this.openFilename = null;
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
