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

        private void pnlYears_Click(object sender, EventArgs e)
        {
            UclReportYears reportYears = new UclReportYears();
            if (Support.frm is FrmMenuAgency)
            {
                ((FrmMenuAgency)Support.frm).addControltoPanel(reportYears);
                ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - REPORT [Years]";
            }
            else
            {
                ((FrmMenuAdmin)Support.frm).addControltoPanel(reportYears);
                ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - REPORT [Years]";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UclReportMonths reportMonths = new UclReportMonths();
            if (Support.frm is FrmMenuAgency)
            {
                ((FrmMenuAgency)Support.frm).addControltoPanel(reportMonths);
                ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - REPORT [Months]";
            }
            else
            {
                ((FrmMenuAdmin)Support.frm).addControltoPanel(reportMonths);
                ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - REPORT [Months]";
            }
        }
    }
}
