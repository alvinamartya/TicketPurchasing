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
    public partial class UclSeatRefund : UserControl
    {
        private Database database = new Database();
        private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private UclRefund refund = null;//added
        private string ticketID = null;//added

        public UclSeatRefund()
        {
            InitializeComponent();
        }

        public UclSeatRefund(string scheduleID, string cabintype, int left, int mid, int right, int totalSeat,
            int start, decimal price, UclRefund refund, string ticketID,string bookingref)//changed
        {
            InitializeComponent();
            lblTitle.Text = cabintype.ToUpper();
            this.refund = refund;
            this.ticketID = ticketID;
            makeSeat(scheduleID, cabintype, left, mid, right, start, totalSeat, price,bookingref);
        }

        public void makeSeat(string scheduleID, string cabintype, int left,
            int mid, int right,int start, int totalSeat, decimal price,string bookingref)
        {
            int totalColumn = left + mid + right;

            DataSet passengers =
                database.getDataFromDatabase("sp_get_passenger",
                new List<Parameter>()
                {
                    new Parameter("@ScheduleID",scheduleID),
                    new Parameter("@CabinType",cabintype)
                });

            var convertDataSetToList = passengers.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    seatNumber = dataRow.Field<int>("SeatNumber")
                }).ToList();

            DataSet passengersBooking =
                database.getDataFromDatabase("sp_get_passenger_booking",
                new List<Parameter>()
                {
                    new Parameter("@BookingRef",bookingref),
                    new Parameter("@CabinType",cabintype)
                });

            var convertDataSetToList2 = passengersBooking.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    seatNumber = dataRow.Field<int>("SeatNumber")
                }).ToList();

            // make seat
            int pos = 0;
            int seatnum = 0;
            for (int i = 0; i < totalSeat; i++)
            {
                ButtonSeat buttonSeat = new ButtonSeat();
                buttonSeat.Name = cabintype.Substring(0, 1).ToUpper() + seatnum.ToString();
                buttonSeat.Text = alphabet[start] + (++pos).ToString();
                buttonSeat.CabinType = cabintype;
                buttonSeat.SeatNumber = ++seatnum;
                buttonSeat.Price = price;

                if (convertDataSetToList
                    .Where(x => x.seatNumber == seatnum)
                    .FirstOrDefault() != null) buttonSeat.Condition = 2;
                if (convertDataSetToList2
                    .Where(x => x.seatNumber == seatnum)
                    .FirstOrDefault() != null) buttonSeat.Condition = 3;

                if (mid == 0)
                {
                    if (left + right == 6)
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(55, 3, 3, 0);
                    }
                    else if (left + right == 4)
                    {
                        buttonSeat.Size = new Size(50, 50);
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(87, 3, 3, 0);
                    }
                    else
                    {
                        buttonSeat.Size = new Size(100, 50);
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(80, 3, 3, 0);
                    }
                }
                else
                {
                    //chaged
                    if (left + mid + right == 4)//added
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(20, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(70, 3, 3, 0);
                        if (pos == left + mid + 1)
                            buttonSeat.Margin = new Padding(70, 3, 3, 0);
                    }
                    else if (left + mid + right == 6)
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(25, 3, 3, 0);
                        if (pos == left + mid + 1)
                            buttonSeat.Margin = new Padding(25, 3, 3, 0);
                    }
                    else if (left + mid + right == 8)
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(5, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + mid + 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                    }
                    else
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(5, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(10, 3, 3, 0);
                        if (pos == left + mid + 1)
                            buttonSeat.Margin = new Padding(10, 3, 3, 0);
                    }
                }
                panelSeat.Controls.Add(buttonSeat);

                if ((i + 1) % totalColumn == 0)
                {
                    panelSeat.SetFlowBreak(buttonSeat, true);
                    start = start + 1;
                    pos = 0;
                }
            }
        }
    }
}
