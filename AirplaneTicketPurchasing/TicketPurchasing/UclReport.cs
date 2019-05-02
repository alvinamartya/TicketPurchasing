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
        public UclReport()
        {
            InitializeComponent();
        }

        private void UclReport_Load(object sender, EventArgs e)
        {
            cboReport.SelectedIndex = 0;
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeReport(cboReport.Text);
        }

        #region Method
        private void changeReport(string report)
        {
            if (report.Equals("Period"))
            {
                txtStartDatePeriod.Visible = true;
                txtEndPeriodDate.Visible = true;
                cboStartPeriod.Visible = false;
                cboEndPeriod.Visible = false;
                lblEndPeriod.Visible = true;
                btnShow.Location = new Point(358, 73);
                lblStartPeriod.Text = "Start Period";
                lblEndPeriod.Text = "End Period";
                lblEndPeriod.Visible = true;
                flatLabel1.Visible = true;
                dataReport.Size = new Size(794, 356);
                dataReport.Location = new Point(19, 104);
            }
            else if (report.Equals("Year"))
            {
                txtStartDatePeriod.Visible = false;
                txtEndPeriodDate.Visible = false;
                cboStartPeriod.Visible = true;
                cboEndPeriod.Visible = false;
                lblEndPeriod.Visible = false;
                flatLabel1.Visible = false;
                btnShow.Location = new Point(301, 47);
                dataReport.Size = new Size(794, 385);
                dataReport.Location = new Point(19, 75);
            }
            else
            {
                txtStartDatePeriod.Visible = false;
                txtEndPeriodDate.Visible = false;
                cboStartPeriod.Visible = true;
                cboEndPeriod.Visible = true;
                lblEndPeriod.Visible = true;
                btnShow.Location = new Point(301, 72);
                lblStartPeriod.Text = "Month";
                lblEndPeriod.Text = "Year";
                lblEndPeriod.Visible = true;
                flatLabel1.Visible = true;
                dataReport.Size = new Size(794, 356);
                dataReport.Location = new Point(19, 104);
            }
        }
        #endregion
    }
}
