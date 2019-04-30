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
        #region Declaration
        Support support = new Support();
        #endregion

        public UclMenuSA()
        {
            InitializeComponent();
        }


        private void panelAmenities_Click(object sender, MouseEventArgs e)
        {
            UclAmenities amenities = new UclAmenities();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(amenities);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Amenities]";
        }

        private void panelCompanies_Click(object sender, MouseEventArgs e)
        {
            UclAircraftCompanies companies = new UclAircraftCompanies();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(companies);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Companies]";
        }

        private void panelAircraftTypes_Click(object sender, MouseEventArgs e)
        {
            UclAircraftTypes aircrafttype = new UclAircraftTypes();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(aircrafttype);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Aircraft Types]";
        }

        private void panelAircrafts_CLick(object sender, MouseEventArgs e)
        {
            UclAircrafts aircrafts = new UclAircrafts();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(aircrafts);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Aircrafts]";
        }

        private void panelCities_Click(object sender, MouseEventArgs e)
        {
            UclCities cities = new UclCities();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(cities);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Cities]";
        }

        private void panelEmployees_Click(object sender, MouseEventArgs e)
        {
            UclEmployees employees = new UclEmployees();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(employees);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Employees]";
        }

        private void UclMenuSA_Load(object sender, EventArgs e)
        {
            support.panelMouse(pnlAmenities);
            support.panelMouse(pnlCompanies);
            support.panelMouse(pnlAircraftTypes);
            support.panelMouse(pnlAircrafts);
            support.panelMouse(pnlCities);
            support.panelMouse(pnlEmployees);
        }

    }
}
