using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.Model;
using Leagueinator.utility_classes;

namespace Leagueinator.Forms {
    public partial class FormMain : Form {
        public static Settings Settings = new Settings(
            teamSize : 2,
            laneCount: 8,
            matchSize: 2
        );

        public FormMain() {
            InitializeComponent();
                        
            if (File.Exists(Properties.Settings.Default.last_save_name)) {
                loadFile(Properties.Settings.Default.last_save_name);                
            }
                        
            this.eventsPanel.OnEventCardSelect += (s, e) => this.editEvent(e.LeagueEvent);            
        }                

        public FormMain DebugSetup() {
            // TODO Remove this method in production.
            var league = new League();

            league.AddPlayers(new String[] { "Ed", "Tim", "Bill", "Steve" });
            LeagueEvent leagueEvent = league.AddEvent(FormMain.Settings);
            Round round = leagueEvent.AddRound();

            this.SetModel(league);
            this.playersPanel.Visible = false;
            this.eventsPanel.Visible = false;
            this.editEventPanel.Visible = true;

            this.editEventPanel.LeagueEvent = leagueEvent;

            return this;
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

        private void menuSettings(object sender, EventArgs e) {            
            using (FormSettings form = new FormSettings()) {
                form.Settings = FormMain.Settings;

                if (form.ShowDialog() == DialogResult.OK) {
                    FormMain.Settings = form.Settings;
                }
            }
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

        private void newEvent(object sender, EventArgs e) {
            this.eventsPanel.AddEvent(new LeagueEvent(FormMain.Settings));
        }

        public void SetModel(League league) {
            foreach(var playerInfo in league.Players) {
                this.playersPanel.AddPlayer(playerInfo);
            }

            foreach (var lEvent in league.Events) {
                this.eventsPanel.AddEvent(lEvent);
            }
        }

        private void menuPrintCurrentEvent(object sender, EventArgs e) {
            Debug.WriteLine(this.editEventPanel.LeagueEvent);
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
