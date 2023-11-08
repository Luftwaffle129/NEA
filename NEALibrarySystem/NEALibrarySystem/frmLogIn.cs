﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmLogIn : Form
    {
        FrmMainSystem frmMainSystem;
        frmForgottenPassword frmForgottenPassword;
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMainSystem = new FrmMainSystem();
            frmMainSystem.Show();
            this.Hide();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgottenPassword = new frmForgottenPassword();
            frmForgottenPassword.Show();
        }
    }
}
