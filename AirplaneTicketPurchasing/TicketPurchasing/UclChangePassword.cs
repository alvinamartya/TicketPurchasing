using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TicketPurchasing
{
    public partial class UclChangePassword : UserControl
    {
        #region Declaration
        private Database database = new Database();
        private string message = "";
        private Validation valid = new Validation();
        #endregion
        #region Constructor
        public UclChangePassword()
        {
            InitializeComponent();
        }
        #endregion
        #region Method
        private bool validation()
        {
            bool result = false;
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Username", Thread.CurrentPrincipal.Identity.Name));
            DataSet dataProfile = database.getDataFromDatabase("sp_login_getPassword", param);
            string oldPassword = dataProfile.Tables[0].Rows[0][0].ToString();
            Console.WriteLine(oldPassword);
            if (txtConfirmPassword.Text == "" || txtNewPassword.Text == "" || txtOldPassword.Text == "")
                message = "Ensure you have filled all fields";
            else if (!txtOldPassword.Text.Equals(oldPassword)) message = "Ensure old password must correct";
            else if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text)) message = "Ensure new password must same with confirm password";
            else if (!valid.regexPassword(txtNewPassword.Text)) message = "Ensure new password must consist of lower case, upper case and numberic";
            else if (txtNewPassword.Text.Length > 16) message = "Ensure new password must be less or equal than 16 characters";
            else result = true;
            return result;
        }

        private void clear()
        {
            txtConfirmPassword.Clear();
            txtNewPassword.Clear();
            txtOldPassword.Clear();
        }
        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                List<Parameter> param = new List<Parameter>();
                param.Add(new Parameter("@Username", Thread.CurrentPrincipal.Identity.Name));
                param.Add(new Parameter("@Password", txtNewPassword.Text));
                int x = database.executeQuery("sp_change_password", param, "Change Password");
                if (x > 0)
                {
                    MessageBox.Show("Change password has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
            else
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Support.frm is FrmMenuAdmin) ((FrmMenuAdmin)Support.frm).cancel();
            else ((FrmMenuAgency)Support.frm).cancel();
        }
        #endregion
    }
}
