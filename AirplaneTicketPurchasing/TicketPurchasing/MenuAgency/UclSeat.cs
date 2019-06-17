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
    public partial class UclSeat : UserControl
    {
        private Database database = new Database();
        private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private UclPurchase purchase = null;

        public UclSeat()
        {
            InitializeComponent();
        }

        public UclSeat(string scheduleID, string cabintype, int left, 
            int mid, int right,int totalSeat, int start, decimal price, UclPurchase purchase)
        {
            InitializeComponent();
            lblTitle.Text = cabintype.ToUpper();
            this.purchase = purchase;
            makeSeat(scheduleID, cabintype, left, mid, right, totalSeat, start, price);
        }

        public void makeSeat(string scheduleID, string cabintype, int left, 
            int mid, int right, int totalSeat, int start, decimal price)
        {
            int totalColumn = left + mid + right;
            DataSet passengers = 
                database.getDataFromDatabase("sp_view_transaction_checkPassenger",
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

                if(convertDataSetToList
                    .Where(x=>x.seatNumber == seatnum)
                    .FirstOrDefault() != null) buttonSeat.Condition = 2;

                if (mid == 0)
                {
                    if(left + right == 6)
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(55, 3, 3, 0);
                    }
                    else if(left + right == 4)
                    {
                        buttonSeat.Size = new Size(50,50);
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
                    if(left + mid + right == 6)
                    {
                        if (pos == 1)
                            buttonSeat.Margin = new Padding(15, 3, 3, 0);
                        if (pos == left + 1)
                            buttonSeat.Margin = new Padding(25, 3, 3, 0);
                        if (pos == left + mid + 1)
                            buttonSeat.Margin = new Padding(25, 3, 3, 0);
                    }
                    else if(left + mid + right == 8)
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
                buttonSeat.Click += btn_click;

                panelSeat.Controls.Add(buttonSeat);

                if((i + 1) % totalColumn == 0)
                {
                    panelSeat.SetFlowBreak(buttonSeat, true);
                    start = start + 1;
                    pos = 0;
                }                
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            ButtonSeat btn = (ButtonSeat)sender;
            if (btn.Clicked == false && purchase.buttonSeat == null)
            {
                purchase.buttonSeat = btn;
                btn.Clicked = true;
                btn.Condition = 1;
            }
            else if(btn.Clicked == true && purchase.buttonSeat != null)
            {
                purchase.buttonSeat = null;
                btn.Clicked = false;
                btn.Condition = 0;
            }
        }
    }
}
