using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing
{
    public partial class FrmLogin : Form
    {
        #region Declaration
        private string username = "";
        private bool filledUsername = false;
        private string password = "";
        private bool filledPassword = false;
        private Support support = new Support();
        private Database database = new Database();
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
            txtUsername.ForeColor = Color.White;
            filledUsername = true;
            if (username.Equals(""))
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.ForeColor = Color.White;
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
            if(username == "" && password == "")
            {
                MessageBox.Show("Ensure you have filled username and password", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (isAuthentic(username, password))
            {
                GenericIdentity myIdentity = new GenericIdentity(username);
                DataSet getAllRoles = database.getDataFromDatabase("sp_login_getallroles", null);
                string[] myRole = new string[getAllRoles.Tables[0].Rows.Count];
                for(int i =0; i< getAllRoles.Tables[0].Rows.Count; i++)
                {
                    myRole[i] = getAllRoles.Tables[0].Rows[i][0].ToString();
                }

                // membuat generic principal
                GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, myRole);

                // simpan dalam thread principal
                Thread.CurrentPrincipal = myPrincipal;
                string role = getRole(username);

                if(role == "sa")
                {
                    FrmMenuAdmin menuAdmin = new FrmMenuAdmin();
                    menuAdmin.Show();
                }
                else if(role == "admin")
                {
                    FrmMenuAdmin menuAdmin = new FrmMenuAdmin();
                    menuAdmin.Show();
                }
                else
                {
                    FrmMenuAgency menuAgency = new FrmMenuAgency();
                    menuAgency.Show();
                }
                this.Hide();
            }
        }

        private bool isAuthentic(string username, string password)
        {
            bool autentik = false;

            try
            {
                List<Parameter> param = new List<Parameter>();
                param.Add(new Parameter("@Username", username));
                DataSet ds = database.getDataFromDatabase("sp_login_authentication", param);
                if (ds.Tables[0].Rows[0][0].ToString() != password)
                    MessageBox.Show("Your password incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else autentik = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Your username incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return autentik;
        }

        private string getRole(string username)
        {
            string result = "";
            try
            {
                List<Parameter> param = new List<Parameter>();
                param.Add(new Parameter("@Username", username));
                DataSet data = database.getDataFromDatabase("sp_login_getrole",param);
                result = data.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
    }
}
