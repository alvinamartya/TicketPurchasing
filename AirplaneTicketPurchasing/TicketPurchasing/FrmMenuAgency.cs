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

        private void FrmMenuAgency_Load(object sender, EventArgs e)
        {
            lblName.Text = Support.name;
            lblPosition.Text = Support.role;
            support.DragandDropForm(this);
            btn = btnTransaction;

            UclMenuAgency menuagency = new UclMenuAgency();
            addControltoPanel(menuagency);
            disableButton();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            enableButton();
            btn = btnReport;
            disableButton();
            UclReport uclReport = new UclReport();
            addControltoPanel(uclReport);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            enableButton();
            btn = btnTransaction;
            disableButton();
            UclMenuAgency menuagency = new UclMenuAgency();
            addControltoPanel(menuagency);
        }
        #endregion

        #region Method
        private void addControltoPanel(UserControl control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            support.DragandDropForm(this);
        }

        private void disableButton()
        {
            Color disableColor = Color.FromArgb(215, 180, 157);
            btn.BackColor = disableColor;
        }

        private void enableButton()
        {
            Color enableColor = Color.FromArgb(239, 201, 175);
            btn.BackColor = enableColor;
        }
        #endregion
    }
}
