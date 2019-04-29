using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing.MenuSA
{
    public partial class UclMenuSA : UserControl
    {
        public UclMenuSA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UclAmenities amenities = new UclAmenities();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(amenities);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Amenities]";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UclCities cities = new UclCities();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(cities);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Cities]";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UclAircraftCompanies companies = new UclAircraftCompanies();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(companies);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Companies]";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UclAircraftTypes aircrafttype = new UclAircraftTypes();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(aircrafttype);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Aircraft Types]";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UclEmployees employees = new UclEmployees();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(employees);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Employees]";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UclAircrafts aircrafts = new UclAircrafts();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(aircrafts);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Aircrafts]";
        }
    }
}
