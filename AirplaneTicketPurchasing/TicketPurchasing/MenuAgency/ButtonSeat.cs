using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing.MenuAgency
{
    public partial class ButtonSeat : Button
    {
        public ButtonSeat()
        {
            InitializeComponent();
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            ForeColor = Color.White;
            Height = 30;
            Width = 35;
            Condition = 0;
        }

        // condition
        int condition = 0;
        [Description("This is for condition button"),Category("Design"),DefaultValue(0)]
        public int Condition
        {
            get { return condition; }
            set
            {
                condition = value;
                if(condition == 0)
                {
                    BackColor = ColorTranslator.FromHtml("#2e7d32");
                    Enabled = true;
                }
                else if(condition == 1)
                {
                    BackColor = ColorTranslator.FromHtml("#ff6f00");
                    Enabled = true;
                }
                else if(condition == 2)
                {
                    BackColor = ColorTranslator.FromHtml("#a30000");
                    Enabled = false;
                }
                else if(condition == 3)
                {
                    BackColor = ColorTranslator.FromHtml("#1976d2");
                    Enabled = false;
                }
                else if (condition == 4)
                {
                    BackColor = ColorTranslator.FromHtml("#81d4fa");
                    Enabled = false;
                }
            }
        }

        // price
        decimal price = 0;
        [Description("This is for price button"), Category("Data"), DefaultValue(0)]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        // Seat number
        int seatNumber = 0;
        [Description("This is for seat number button"), Category("Data"), DefaultValue(0)]
        public int SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        // Cabin Type
        string cabinType = "";
        [Description("This is for cabin type button"), Category("Data")]
        public string CabinType
        {
            get { return cabinType; }
            set { cabinType = value; }
        }

        // clicked
        bool clicked = false;
        [Description("This is for clicked button"), Category("Data"), DefaultValue(false)]
        public bool Clicked
        {
            get { return clicked; }
            set { clicked = value; }
        }
    }
}
