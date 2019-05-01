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
    public partial class UclTicket : UserControl
    {
        public UclTicket()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            UclPurchase purchase = new UclPurchase();
            ((FrmMenuAgency)Support.frm).addControltoPanel(purchase);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase]";
        }
    }
}
