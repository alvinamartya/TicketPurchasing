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
    public partial class FrmPopUp : Form
    {
        #region Declaration
        private Support support = new Support();
        #endregion

        #region Constructor
        public FrmPopUp()
        {
            InitializeComponent();
            support.DragandDropForm(this);
        }
        #endregion

        #region Events
        private void FrmPopUp_Load(object sender, EventArgs e)
        {
            MenuAgency.UclCustomer customer = new MenuAgency.UclCustomer();
            pnlFlight.Controls.Add(customer);
        }
        #endregion
    }
}
