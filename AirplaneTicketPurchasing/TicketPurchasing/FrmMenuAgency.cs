using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketPurchasing.MenuAgency;

namespace TicketPurchasing
{
    public partial class FrmMenuAgency : Form
    {
        #region Declaration
        private Button btn;
        Support support = new Support();
        #endregion

        #region Constructor
        public FrmMenuAgency()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            buttonSelected(sender);
            btn = btnManageCustomer;
            UclCustomer uclCustomer = new UclCustomer();
            addControltoPanel(uclCustomer);
            lblTitle.Text = "FLIGHTSI - MANAGE [Customers]";
        }

        private void FrmMenuAgency_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "FLIGHTSI - TRANSACTION";
            Support.frm = this;
            lblName.Text = Support.name;
            lblPosition.Text = Support.role;
            support.DragandDropForm(this);
            btn = btnDashboard;

            UclDashboard dashboard = new UclDashboard();
            addControltoPanel(dashboard);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            buttonSelected(sender);
            btn = btnReport;
            UclReport uclReport = new UclReport();
            addControltoPanel(uclReport);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "FLIGHTSI - TRANSACTION";
            buttonSelected(sender);
            btn = btnTransaction;
            UclMenuAgency menuagency = new UclMenuAgency();
            addControltoPanel(menuagency);
        }
        #endregion

        #region Method
        public void addControltoPanel(UserControl control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            support.DragandDropForm(this);
        }

        private void buttonSelected(object b)
        {
            Button btn = (Button)b;
            pnlButtonSelected.Top = btn.Top;
        }
        #endregion

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            buttonSelected(sender);
            btn = btnDashboard;
            UclDashboard ucldashboard = new UclDashboard();
            addControltoPanel(ucldashboard);
            lblTitle.Text = "FLIGHTSI - MANAGE [Dashboard]";
        }
    }
}
