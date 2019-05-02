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
        Support support = new Support();
        #endregion

        public UclMenuAgency()
        {
            InitializeComponent();
        }

        private void UclMenuAgency_Load(object sender, EventArgs e)
        {
            support.panelMouse(pnlPurchase);
            support.panelMouse(pnlModify);
        }

        private void pnlPurchase_Click(object sender, EventArgs e)
        {
            UclPurchase purchase = new UclPurchase();
            ((FrmMenuAgency)Support.frm).addControltoPanel(purchase);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase]";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UclRefund refund = new UclRefund();
            ((FrmMenuAgency)Support.frm).addControltoPanel(refund);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Refund]";
        }

    }
}
