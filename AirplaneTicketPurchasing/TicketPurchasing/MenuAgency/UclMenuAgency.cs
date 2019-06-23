using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing.MenuAgency
{
    public partial class UclMenuAgency : UserControl
    {
        #region Declaration
        private Support support = new Support();
        private FrmMenuAgency agency;
        #endregion

        #region Constructor
        public UclMenuAgency()
        {
            InitializeComponent();
        }

        public UclMenuAgency(FrmMenuAgency agency)
        {
            InitializeComponent();
            this.agency = agency;
        }
        #endregion
        #region Events
        private void UclMenuAgency_Load(object sender, EventArgs e)
        {
            support.panelMouse(pnlPurchase);
            support.panelMouse(pnlModify);
        }

        private void pnlPurchase_Click(object sender, EventArgs e)
        {
            UclPurchase purchase = new UclPurchase(agency);
            ((FrmMenuAgency)Support.frm).addControltoPanel(purchase);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase]";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UclRefund refund = new UclRefund();
            ((FrmMenuAgency)Support.frm).addControltoPanel(refund);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Refund]";
        }
        #endregion
    }
}
