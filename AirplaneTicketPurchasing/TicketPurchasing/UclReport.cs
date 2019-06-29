using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace TicketPurchasing
{
    public partial class UclReport : UserControl
    {
        ReportDataSet reportdataset;
        Database database = new Database();

        #region Constructor
        public UclReport()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void UclReport_Load(object sender, EventArgs e)
        {
            cmbReport.SelectedIndex = 0;
            loadCmbYear();
        }

        private void loadCmbYear()
        {
            DataSet ds = database.getDataFromDatabase("sp_report_get_year", null);
            cmbYear1.DataSource = ds.Tables[0];
            cmbYear1.DisplayMember = "year";
            ds = database.getDataFromDatabase("sp_report_get_year", null);
            cmbYear2.DataSource = ds.Tables[0];
            cmbYear2.DisplayMember = "year";
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeReport(cmbReport.Text);
        }
        #endregion

        #region Method
        private void changeReport(string report)
        {
            if (report.Equals("Daily"))
            {
                cmbYear1.Visible = false;
                cmbYear2.Visible = false;
                dateStart.Visible = true;
                dateEnd.Visible = true;
                lblEndPeriod.Visible = true;
                btnShow.Location = new Point(358, 73);
                lblStartPeriod.Text = "Start Period";
                lblEndPeriod.Text = "End Period";
                lblEndPeriod.Visible = true;
                flatLabel1.Visible = true;
                rvPeriod.Size = new Size(794, 356);
                rvPeriod.Location = new Point(19, 104);
            }
            else if (report.Equals("Yearly"))
            {
                lblStartPeriod.Text = "Year Start";
                lblEndPeriod.Text = "Year End";
                cmbYear1.Visible = true;
                cmbYear2.Visible = true;
                dateStart.Visible = false;
                dateEnd.Visible = false;
                lblEndPeriod.Visible = true;
                flatLabel1.Visible = true;
                btnShow.Location = new Point(301, 72);
                rvPeriod.Size = new Size(794, 356);
                rvPeriod.Location = new Point(19, 104);
            }
            else
            {
                cmbYear1.Visible = true;
                cmbYear2.Visible = false;
                dateStart.Visible = false;
                dateEnd.Visible = false;
                lblEndPeriod.Visible = true;
                btnShow.Location = new Point(301, 47);
                lblStartPeriod.Text = "Year";
                lblEndPeriod.Visible = false;
                flatLabel1.Visible = false;
                rvPeriod.Size = new Size(794, 384);
                rvPeriod.Location = new Point(19, 76);
            }
        }
        #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {
            rvPeriod.Clear();
            DateTime dtStart = dateStart.Value;
            DateTime dtEnd = dateEnd.Value;

            if ((dtStart > dtEnd && cmbReport.Text=="Daily") || (cmbReport.Text=="Yearly" && Convert.ToInt32(cmbYear1.Text) > Convert.ToInt32(cmbYear2.Text)))
            {
                MessageBox.Show("Ensure Start Period Date is Before End Prdiod Date","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            ReportParameterCollection rParam = new ReportParameterCollection();
            DataSet dataset = new DataSet();

            reportdataset = new ReportDataSet();
            reportdataset.tblReport.Clear();

            string sp = "";
            switch (cmbReport.Text)
            {
                case "Daily":
                    sp = "sp_report_period_daily";
                    rParam.Add(new ReportParameter("dateStart", dtStart.Date.ToString("dd MMMM yyyy")));
                    rParam.Add(new ReportParameter("dateEnd", dtEnd.Date.ToString("dd MMMM yyyy")));
                    dataset = database.getDataFromDatabase(sp, new List<Parameter>
                    {
                        new Parameter("dateStart", dtStart.ToString("yyyy-MM-dd")),
                        new Parameter("dateEnd", dtEnd.ToString("yyyy-MM-dd"))
                    });
                    break;

                case "Monthly":
                    sp = "sp_report_period_monthly";
                    rParam.Add(new ReportParameter("dateStart", cmbYear1.Text));
                    rParam.Add(new ReportParameter("dateEnd", Convert.ToString(Convert.ToInt32(cmbYear1.Text) + 1)));
                    dataset = database.getDataFromDatabase(sp, new List<Parameter>
                    {
                        new Parameter("dateStart", cmbYear1.Text),
                        new Parameter("dateEnd", "0")
                    });
                    break;
                case "Yearly":
                    sp = "sp_report_period_yearly";
                    rParam.Add(new ReportParameter("dateStart", cmbYear1.Text));
                    rParam.Add(new ReportParameter("dateEnd", cmbYear2.Text));
                    dataset = database.getDataFromDatabase(sp, new List<Parameter>
                    {
                        new Parameter("dateStart", cmbYear1.Text),
                        new Parameter("dateEnd", cmbYear2.Text)
                    });
                    break;
            }

            if(dataset.Tables.Count > 0)
            {
                if(dataset.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                    {
                        decimal total = Convert.ToDecimal(dataset.Tables[0].Rows[i][3].ToString());
                        decimal refund = Convert.ToDecimal(dataset.Tables[0].Rows[i][4].ToString());
                        decimal totalClean = Convert.ToDecimal(dataset.Tables[0].Rows[i][5].ToString());
                        reportdataset.tblReport.AddtblReportRow(
                            dataset.Tables[0].Rows[i][0].ToString(),
                            dataset.Tables[0].Rows[i][1].ToString(),
                            dataset.Tables[0].Rows[i][2].ToString(),
                            "Rp. " + total.ToString("N"),
                            "Rp. " + refund.ToString("N"),
                            "Rp. " + totalClean.ToString("N"),
                            Convert.ToInt32(totalClean));
                    }
                    ReportDataSource reportDS = new ReportDataSource();
                    reportDS.Name = "reportDS";
                    reportDS.Value = reportdataset.tblReport;
                    rvPeriod.LocalReport.DataSources.Clear();
                    rvPeriod.LocalReport.DataSources.Add(reportDS);
                    rvPeriod.LocalReport.SetParameters(rParam);
                    rvPeriod.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No Record Found", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSaveToPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF|*.pdf";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = rvPeriod.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
