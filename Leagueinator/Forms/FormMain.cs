using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Components;
using Leagueinator.Model;
using Leagueinator.utility_classes;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        private League _league;
        public League League {
            get { return _league; }
            set {
                this._league = value;
                this.playersPanel.Visible = true;
                this.editEventPanel.Visible = false;

                foreach (var playerInfo in value.Players) {
                    this.playersPanel.AddPlayer(playerInfo);
                }

                foreach (var lEvent in value.Events) {
                    this.eventsPanel.AddEvent(lEvent);
                }
            }
        }

        public FormMain() {
            InitializeComponent();

            if (File.Exists(Properties.Settings.Default.last_save_name)) {
                loadFile(Properties.Settings.Default.last_save_name);
            }

            this.eventsPanel.OnEventCardSelect += (s, e) => this.editEvent(e.LeagueEvent);
            this.playersPanel.PlayerAdded += (s, e) => {
                this.League.Players.Add(e.PlayerInfo);
                this.editEventPanel.AddPlayer(e.PlayerInfo);
            };

            // TODO REMOVE
            League league = new League();
            league.AddPlayers(new String[] { "Ed", "Tim", "Bill", "Steve" });
            this.League = league;
        }

        private void loadFile(string fullpath) {
            //Properties.Settings.Default.save_dir = Path.GetDirectoryName(fullpath);
            //Properties.Settings.Default.last_save_name = fullpath;
            //Properties.Settings.Default.Save();

            //this.menuView.Enabled = true;
            //this.Text = fullpath;

            //this.playersPanel.Visible = true;
        }

        private void useDialog(FileDialog dialog) {
            dialog.InitialDirectory = Properties.Settings.Default.save_dir;
            dialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.FileName = "event.db";

            if (dialog.ShowDialog() == DialogResult.OK) {
                this.loadFile(dialog.FileName);
            }
        }

        private void menuFileNew(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                this.useDialog(saveFileDialog);
            }
        }

        private void menuFileLoad(object sender, EventArgs e) {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
            //    this.useDialog(openFileDialog);
            //}
        }

        private void menuFileClose(object sender, EventArgs e) {
            Properties.Settings.Default.last_save_name = "";
            this.menuView.Enabled = false;
            this.Text = "Leagueinator";
            this.playersPanel.Visible = false;
        }

        private void menuViewPlayers(object sender, EventArgs e) {
            this.playersPanel.Visible = true;
            this.eventsPanel.Visible = false;
            this.editEventPanel.Visible = false;
        }

        private void menuViewEvents(object sender, EventArgs e) {
            this.playersPanel.Visible = false;
            this.eventsPanel.Visible = true;
            this.editEventPanel.Visible = false;
        }

        private void editEvent(LeagueEvent leagueEvent) {
            this.playersPanel.Visible = false;
            this.eventsPanel.Visible = false;
            this.editEventPanel.Visible = true;
            this.editEventPanel.LeagueEvent = leagueEvent;
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
            this.playersPanel.Visible = false;
            this.editEventPanel.Visible = true;
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
