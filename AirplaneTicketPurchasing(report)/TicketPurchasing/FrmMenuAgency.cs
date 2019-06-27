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
using TicketPurchasing.MenuAgency;

namespace TicketPurchasing
{
    public partial class FrmMenuAgency : Form
    {
        #region Declaration
        private Button btn;
        private Support support = new Support();
        private Database database = new Database();
        #endregion
        #region Constructor
        public FrmMenuAgency()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        private void flatClose1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
        }

        private void FrmMenuAgency_Load(object sender, EventArgs e)
        {
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Username", Thread.CurrentPrincipal.Identity.Name));
            DataSet dataProfile = database.getDataFromDatabase("sp_login_getProfile", param);
            Support.frm = this;
            lblName.Text = dataProfile.Tables[0].Rows[0][0].ToString().ToUpper();
            lblPosition.Text = "Agency";

            lblTitle.Text = "FLIGHTSI - DASHBOARD";
            support.DragandDropForm(this);
            btn = btnDashboard;

            UclDashboard dashboard = new UclDashboard();
            addControltoPanel(dashboard);

            // photo
            string base64string = dataProfile.Tables[0].Rows[0][1].ToString();
            string extension = base64string.Substring(base64string.IndexOf('/'),
                                         base64string.IndexOf(';') - base64string.IndexOf('/'));
            string path = base64string.Substring(base64string.IndexOf(',') + 2,
                base64string.Length - (base64string.IndexOf(',') + 2));
            byte[] image = Convert.FromBase64String(path);
            photo.Image = support.byteArrayToImage(image);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            btn = btnReport;
            buttonSelected();
            UclReport uclReport = new UclReport();
            addControltoPanel(uclReport);
            lblTitle.Text = "FLIGHTSI - REPORT";
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            btn = btnTransac;
            buttonSelected();
            UclMenuAgency menuagency = new UclMenuAgency(this);
            addControltoPanel(menuagency);
            lblTitle.Text = "FLIGHTSI - TRANSACTION";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            btn = btnChangePassword;
            buttonSelected();
            UclChangePassword uclChangePassword = new UclChangePassword();
            addControltoPanel(uclChangePassword);
            lblTitle.Text = "FLIGHTSI - CHANGE PASSWORD";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btn = btnDashboard;
            buttonSelected();
            UclDashboard ucldashboard = new UclDashboard();
            addControltoPanel(ucldashboard);
            lblTitle.Text = "FLIGHTSI - DASHBOARD";
        }
        #endregion
        #region Method
        public void enabledFrm(bool value)
        {
            Enabled = value;
        }

        public void addControltoPanel(UserControl control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            support.DragandDropForm(this);
        }

        private void buttonSelected()
        {
            pnlButtonSelected.Top = btn.Top;
        }

        public void cancel()
        {
            btn = btnDashboard;
            buttonSelected();
            UclDashboard ucldashboard = new UclDashboard();
            addControltoPanel(ucldashboard);
            lblTitle.Text = "FLIGHTSI - DASHBOARD";
        }
        #endregion
    }
}
