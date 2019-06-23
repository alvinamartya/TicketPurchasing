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

namespace TicketPurchasing.MenuAgency
{
    public partial class UclSaveToPDF : UserControl
    {
        private string image = "";
        private string bookingref = "";
        private string aircraft = "";
        private string departurecity = "";
        private string arrivalcity = "";
        private string departuredate = "";
        private string departuretime = "";
        private TicketDataSet ticketdataset;
        #region Constructor
        public UclSaveToPDF()
        {
            InitializeComponent();
        }

        public UclSaveToPDF(string image, string bookingref, string aircraft,
            string departurecity, string arrivalcity, string departuredate, string departuretime,
            TicketDataSet ticketdataset)
        {
            InitializeComponent();
            this.image = image;
            this.bookingref = bookingref;
            this.aircraft = aircraft;
            this.departurecity = departurecity;
            this.arrivalcity = arrivalcity;
            this.departuredate = departuredate;
            this.departuretime = departuretime;
            this.ticketdataset = ticketdataset;
        }
        #endregion

        #region Events
        private void btnShow_Click(object sender, EventArgs e)
        {
            UclPurchase purchase = new UclPurchase();
            ((FrmMenuAgency)Support.frm).addControltoPanel(purchase);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase]";
        }
        #endregion

        private void UclSaveToPDF_Load(object sender, EventArgs e)
        {
            ReportParameter[] reportParameter =
            {
                new ReportParameter("imageUrl",image),
                new ReportParameter("bookingref",bookingref),
                new ReportParameter("Aircraft",aircraft),
                new ReportParameter("DepartureCity",departurecity),
                new ReportParameter("ArrivalCity",arrivalcity),
                new ReportParameter("DepartureDate",departuredate),
                new ReportParameter("DepartureTime",departuretime)
            };

            Console.WriteLine("Size: " + ticketdataset.DataTable1.Rows.Count);
            ReportDataSource reportDatasource = new ReportDataSource();
            reportDatasource.Name = "DataSet1";
            reportDatasource.Value = ticketdataset.DataTable1;
            reportViewer1.LocalReport.DataSources.Add(reportDatasource);
            reportViewer1.LocalReport.SetParameters(reportParameter);
            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF|*.pdf";
            sfd.FileName = "";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
