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
        private void PanelMouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            Enter = new Thread(() => changeColor(p, p.BackColor, dark));
            Enter.Start();
        }

        private void PanelMouseLeave(object sender, EventArgs e)
        {
            if (Enter != null)
                Enter.Abort();
            Panel p = (Panel)sender;
            Leave = new Thread(() => changeColor(p, p.BackColor, light));
            Leave.Start();
        }

        private Color colorInterpolate(int r, int g, int b, float frac, Color init)
        {
            double newR = r * frac + init.R - 1;
            double newG = g * frac + init.G - 1;
            double newB = b * frac + init.B - 1;
            return Color.FromArgb((int)newR, (int)newG, (int)newB);
        }

        private void changeColor(Panel panel, Color init, Color end)
        {
            //Color start = Color.FromArgb(239, 201, 175);
            float frac = 0;

            int r = end.R - init.R;
            int g = end.G - init.G;
            int b = end.B - init.B;

            for (int i = 0; i < 10; i++)
            {
                frac += 0.1F;
                panel.BackColor = colorInterpolate(r, g, b, frac, init);
                Thread.Sleep(30);
            }
            Console.WriteLine("----");
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
    }
}
