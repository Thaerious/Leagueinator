﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leagueinator.Forms {
    public partial class FormAddPlayer : Form {

        public string PlayerName {
            get {
                return this.txtName.Text;
            }
        }
        public FormAddPlayer() {
            InitializeComponent();
        }
    }
}
