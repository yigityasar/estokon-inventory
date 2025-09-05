using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Stokon_App
{
    public partial class FormLogin : Form
    {
        private DatabaseHelper _dbHelper;
        public FormLogin()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.SavedPassword))
            {
                txtUsername.Text = Properties.Settings.Default.SavedUsername;
                txtPassword.Text = Properties.Settings.Default.SavedPassword;
                chkBeniHatirla.Checked = true;
            }

            else
            {
                txtUsername.Text = "Kullanıcı Adı";
                txtUsername.ForeColor = Color.Gray;

                txtPassword.Text = "Parola";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_dbHelper.GirisBilgileriDogruMu(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            {
                if (chkBeniHatirla.Checked)
                {
                    Properties.Settings.Default.SavedUsername = txtUsername.Text;
                    Properties.Settings.Default.SavedPassword = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.SavedPassword = "";
                    Properties.Settings.Default.Save();
                }

                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                labelHatalı.Text = "Kullanıcı adı ya da parola hatalı!";
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DarkBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DodgerBlue;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Kullanıcı Adı")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }
        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Parola")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
