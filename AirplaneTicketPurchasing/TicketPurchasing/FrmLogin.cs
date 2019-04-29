using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing
{
    public partial class FrmLogin : Form
    {
        #region declaration
        private string username = "";
        private bool filledUsername = false;
        private string password = "";
        private bool filledPassword = false;
        Support support = new Support();
        #endregion
        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
            txtUsername.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;
            support.DragandDropForm(this);
        }
        #endregion
        #region Events
        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            if (filledUsername)
            {
                username = txtUsername.Text;
            }
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            if (filledPassword)
            {
                password = txtPassword.Text;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            filledUsername = false;
            if (username.Equals(""))
            {
                txtUsername.ForeColor = Color.Gray;
                txtUsername.Text = "Username";
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.ForeColor = Color.Black;
            filledUsername = true;
            if (username.Equals(""))
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.ForeColor = Color.Black;
            filledPassword = true;
            if (password.Equals(""))
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            filledPassword = false;
            if (password.Equals(""))
            {
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "Password";
                txtPassword.isPassword = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Support.name = "Alvin Amartya Azro";
            if (username.Equals("sa") && password.Equals("sa"))
            {
                Support.role = "Super Admin";
                FrmMenuAdmin menuAdmin = new FrmMenuAdmin();
                menuAdmin.Show();
                this.Hide();
            }
            else if (username.Equals("admin") && password.Equals("admin"))
            {
                Support.role = "Admin";
                FrmMenuAdmin menuAdmin = new FrmMenuAdmin();
                menuAdmin.Show();
                this.Hide();
            }
            else if (username.Equals("agency") && password.Equals("agency"))
            {
                Support.role = "Agency";
                FrmMenuAgency menuAgency = new FrmMenuAgency();
                menuAgency.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
