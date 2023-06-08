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
        private DBManager dbManager;
        private EventDB eventDb;
        private Settings settings = new Settings(true, 2, 4);

        public FormMain() {
            InitializeComponent();
                        
            if (File.Exists(Properties.Settings.Default.last_save_name)) {
                loadFile(Properties.Settings.Default.last_save_name);                
            }
                        
            this.eventsPanel.OnEventCardSelect += (s, e) => this.editEvent(e.LeagueEvent);            
        }                

        private void loadFile(string fullpath) {
            Properties.Settings.Default.save_dir = Path.GetDirectoryName(fullpath);
            Properties.Settings.Default.last_save_name = fullpath;
            Properties.Settings.Default.Save();

            this.dbManager = new DBManager(fullpath);
            this.dbManager.CreateTables();
            this.eventDb = new EventDB(fullpath);
            this.eventDb.CreateTables();

            this.menuView.Enabled = true;
            this.Text = fullpath;

            this.playersPanel.Visible = true;
            this.playersPanel.DBManager = this.dbManager;

            this.settings = this.retrieveSettings();
            this.eventsPanel.SetEvents(this.eventDb.AllEvents());
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                this.useDialog(openFileDialog);
            }
        }

        private void menuFileClose(object sender, EventArgs e) {
            Properties.Settings.Default.last_save_name = "";
            this.dbManager = null;
            this.menuView.Enabled = false;
            this.Text = "Leagueinator";
            this.playersPanel.Visible = false;
            this.playersPanel.DBManager = null;
        }

        private void menuSettings(object sender, EventArgs e) {            
            using (FormSettings form = new FormSettings()) {
                form.Settings = this.settings;

                if (form.ShowDialog() == DialogResult.OK) {
                    this.settings = form.Settings;
                    this.dbManager.SetValue("regenerate", this.settings.Regenerate ? "true" : "false");
                    this.dbManager.SetValue("teamsize", this.settings.TeamSize.ToString());
                    this.dbManager.SetValue("lanecount", this.settings.LaneCount.ToString());
                }
            }
        }

        private Settings retrieveSettings() {
            Debug.WriteLine("Retrieve Settings");
            string regenerate = this.dbManager.GetValue("regenerate", "true");
            string teamSize = this.dbManager.GetValue("teamsize", "2");
            string laneCount = this.dbManager.GetValue("lanecount", "4");

            Debug.WriteLine(regenerate);
            Debug.WriteLine(teamSize);
            Debug.WriteLine(laneCount);

            return new Settings(
                regenerate == "true",
                int.Parse(teamSize),
                int.Parse(laneCount)
            );
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
        }

        private void newEvent(object sender, EventArgs e) {
            var idx = this.eventDb.AddEvent();
            LeagueEvent lEvent = this.eventDb.GetEvent(idx);
            this.eventsPanel.AddEvent(lEvent);
        }
    }
}


// [1] https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=windowsdesktop-7.0#system-windows-forms-form-showdialog
