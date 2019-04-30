using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing
{
    public partial class UclReport : UserControl
    {
        #region Declaration
        Support support = new Support();
        #endregion

        public UclReport()
        {
            InitializeComponent();
        }

        private void UclReport_Load(object sender, EventArgs e)
        {
            support.panelMouse(pnlYears);
            support.panelMouse(pnlMonths);
        }
    }
}
