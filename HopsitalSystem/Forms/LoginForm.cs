using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopsitalSystem.Forms
{
    public partial class LoginForm : Form
    {
        const string username = "admin";
        const string password = "pass";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pass))
            {
                lblError.Text = "Please enter username and password.";
                return;
            }
            if(uname == username && pass == password)
            {
                Form1 frm = new Form1();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            } else
            {
                lblError.Text = "Invalid username or password";
                txtUsername.BackColor = Color.MistyRose;
                txtPassword.BackColor = Color.MistyRose;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            lblError.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            lblError.Text = "";
        }

        private void btnSwitchLang_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (languageBox.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr");
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es");
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {

        }
    }
}
