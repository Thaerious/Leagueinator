using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leagueinator.utility_classes;

namespace Leagueinator
{
    public partial class formMain : Form
    {
        private RoundCollection rounds = null;

        public formMain()
        {
            InitializeComponent();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.addName(this.textName.Text);            
        }

        private void formMain_Load(object sender, EventArgs e) {
            //new DBManager("deleteme.db").CreateTable();
            //DBManager dBManager = new DBManager("deleteme.db");
            //List<string> names = dBManager.GetNames();

            //foreach(string name in names) {
            //    var index = this.listNames.Items.Add(new PlayerInfo(name));
            //}

            //this.panelRound.Hide();
        }

        private void PopulateMatchCards(Round round) {
            this.panelMatch.Controls.Clear();

            foreach (var match in round) {
                this.AddMatch(match);
            }

            foreach (PlayerInfo pinfo in round.Buys) {
                this.AddBuy(pinfo.Name);
            }
        }

        private void AddMatch(Match match) {
            this.panelMatch.Controls.Add(new Matchpanel(match.Lane, match.teams[0], match.teams[1]));
        }

        private void AddBuy(string name) {
            this.panelMatch.Controls.Add(new BuyCard(name));
        }

        private void textName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.addName(this.textName.Text);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            ScoreCardPrinter.Print(this.rounds);
        }

        private void addName(string name) {
            //try {
            //    var index = this.listNames.Items.Add(new PlayerInfo(name));
            //    new DBManager("deleteme.db").AddName(this.textName.Text);
            //    this.textName.Text = "";
            //}catch(Exception ex) {
            //    Debug.WriteLine(ex.Message);
            //    Debug.WriteLine(ex.StackTrace);
            //    MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        
        private void buttonAddAll_Click(object sender, EventArgs e) {
            foreach (var item in this.listNames.Items) {
                if (this.listPlayers.Items.Contains(item)) continue;
                this.listPlayers.Items.Add(item);
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e) {
            this.listPlayers.Items.Clear();
        }

        private void buttonAddSelected_Click(object sender, EventArgs e) {
            var index = this.listNames.SelectedIndex;            
            if (index == -1) return;   
            var item = this.listNames.SelectedItems[0];
            
            if (this.listPlayers.Items.Contains(item)) return;
            this.listPlayers.Items.Add(item);
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e) {
            var index = this.listPlayers.SelectedIndex;
            if (index == -1) return;    
            this.listPlayers.Items.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e) {
            //var index = this.listNames.SelectedIndex;
            //if (index == -1) return;
            //PlayerInfo pinfo = (PlayerInfo)this.listNames.SelectedItems[0];
            //this.listNames.Items.RemoveAt(index);
            //new DBManager("deleteme.db").RemoveName(pinfo.Name);
        }

        private void buttonPlayers_Click(object sender, EventArgs e) {
            this.panelPlayers.Show();
            this.panelRound.Hide();
        }

        private void buttonRound1_Click(object sender, EventArgs e) {
            try {
                if (this.rounds == null) {
                    this.rounds = new RoundCollection(this.listPlayers, 2);
                }

                this.panelPlayers.Hide();
                this.panelRound.Show();
                rounds.Round = 1;
                PopulateMatchCards(this.rounds.CurrentRound());

                this.buttonRound1.BackColor = Color.Green;
                this.buttonRound2.BackColor = Color.White;
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonRound2_Click(object sender, EventArgs e) {
            try {
                if (this.rounds == null) {
                    this.rounds = new RoundCollection(this.listPlayers, 2);
                }

                this.panelPlayers.Hide();
                this.panelRound.Show();
                rounds.Round = 2;
                PopulateMatchCards(this.rounds.CurrentRound());

                this.buttonRound1.BackColor = Color.White;
                this.buttonRound2.BackColor = Color.Green;
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonGenerate_Click_1(object sender, EventArgs e) {
            try {
                var roundIndex = this.rounds == null ? 0 : this.rounds.Round;
                this.rounds = new RoundCollection(this.listPlayers, 2);
                this.rounds.Round = roundIndex;
                PopulateMatchCards(this.rounds.CurrentRound());
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
