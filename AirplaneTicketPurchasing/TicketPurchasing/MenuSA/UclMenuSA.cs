using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TicketPurchasing.MenuSA
{
    public partial class UclMenuSA : UserControl
    {
        private Color light = Color.FromArgb(239, 201, 175);
        private Color dark = Color.FromArgb(240, 160, 124);
        Thread Enter;
        Thread Leave;
        Thread WhithinPanel;

        public UclMenuSA()
        {
            InitializeComponent();
        }

        private void PanelMouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            Enter = new Thread(() => changeColor(p, dark));
            Enter.Start();
        }

        private void PanelMouseLeave(object sender, EventArgs e)
        {
            if (Enter != null)
                Enter.Abort();
            Panel p = (Panel)sender;
            Leave = new Thread(() => changeColor(p, light));
            Leave.Start();
        }
        private void changeColor(Panel panel, Color color)
        {
            panel.BackColor = color;
        }

        private void PictBoxMouseEnter(object sender, EventArgs e)
        {
            if (Leave != null)
                Leave.Abort();
            var obj = (PictureBox)sender;
            PanelMouseEnter(obj.Parent, e);
        }

        private void LableMouseEnter(object sender, EventArgs e)
        {
            if (Leave != null)
                Leave.Abort();
            var obj = (Label)sender;
            PanelMouseEnter(obj.Parent, e);
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
    }
}
