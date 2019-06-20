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
    public partial class UclPurchase : UserControl
    {
        #region Declaration
        private Database database = new Database();
        private bool isSelected = false;
        private DataGridViewRow row = null;
        private Support support = new Support();
        private ButtonSeat button_seat = null;
        #endregion
        #region Constructor
        public UclPurchase()
        {
            InitializeComponent();
        }
        #endregion
        #region Method
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                g.Clear(this.BackColor);
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        public ButtonSeat buttonSeat
        {
            get { return button_seat; }
            set { button_seat = value; }
        }

        private void defaultFrm(bool value)
        {
            flightGroup.Visible = value;
            customerGroup.Visible = value;
            FinalGroup.Visible = value;
            btnSelect.Visible = value;
            isSelected = value;

            if(value == false)
                Size = new Size(819, 329);
            else
                Size = new Size(819, 700);
        }

        private void fillcboCity()
        {
            DataSet dsDepartureCity = database.getDataFromDatabase("sp_view_cities", null);
            DataSet dsArrivalCity = database.getDataFromDatabase("sp_view_cities", null);
            cboDepartureCity.DataSource = dsDepartureCity.Tables[0];
            cboDepartureCity.DisplayMember = "name";
            cboDepartureCity.ValueMember = "id";
            cboArrivalCity.DataSource = dsArrivalCity.Tables[0];
            cboArrivalCity.DisplayMember = "name";
            cboArrivalCity.ValueMember = "id";
        }

        private void createTableSchedule()
        {
            dgvFlightSchedule.Rows.Clear();
            dgvFlightSchedule.Columns.Clear();
            dgvFlightSchedule.Columns.Add("id", "ID");
            dgvFlightSchedule.Columns.Add("departureCityID", "Departure City ID");
            dgvFlightSchedule.Columns.Add("departureCity", "Departure City");
            dgvFlightSchedule.Columns.Add("arrivalCityID", "Arrival CIty ID");
            dgvFlightSchedule.Columns.Add("arrivalCity", "Arrival City");
            dgvFlightSchedule.Columns.Add("departureDate", "Departure Date");
            dgvFlightSchedule.Columns.Add("departureTime", "Departure Time");
            dgvFlightSchedule.Columns.Add("aircraftID", "Aircraft ID");
            dgvFlightSchedule.Columns.Add("aircraft", "Aircraft");
            dgvFlightSchedule.Columns.Add("company", "Company");
            dgvFlightSchedule.Columns.Add("photo", "Photo");
            dgvFlightSchedule.Columns.Add("realeconomyPrice", "Real Economy Price");
            dgvFlightSchedule.Columns.Add("economyPrice", "Economy Price");
            dgvFlightSchedule.Columns.Add("realbusinessPrice", "Real Business Price");
            dgvFlightSchedule.Columns.Add("businessPrice", "Business Price");
            dgvFlightSchedule.Columns.Add("realfirstPrice", "Real First Price");
            dgvFlightSchedule.Columns.Add("firstPrice", "First Price");
            dgvFlightSchedule.Columns[0].Visible = false;
            dgvFlightSchedule.Columns[1].Visible = false;
            dgvFlightSchedule.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFlightSchedule.Columns[3].Visible = false;
            dgvFlightSchedule.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFlightSchedule.Columns[7].Visible = false;
            dgvFlightSchedule.Columns[8].Visible = false;
            dgvFlightSchedule.Columns[9].Visible = false;
            dgvFlightSchedule.Columns[10].Visible = false;
            dgvFlightSchedule.Columns[11].Visible = false;
            dgvFlightSchedule.Columns[12].Visible = false;
            dgvFlightSchedule.Columns[13].Visible = false;
            dgvFlightSchedule.Columns[14].Visible = false;
            dgvFlightSchedule.Columns[15].Visible = false;
            dgvFlightSchedule.Columns[16].Visible = false;
            dgvFlightSchedule.ForeColor = Color.Black;
            dgvFlightSchedule.HeaderForeColor = Color.White;
            dgvFlightSchedule.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagridSchedule(bool search)
        {
            bool isSearchNotFound = false;
            createTableSchedule();
            DataSet data = database.getDataFromDatabase("sp_view_transaction_schedule", null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    DepartureDate = dataRow.Field<DateTime>("DepartureDate"),
                    DepartureTime = dataRow.Field<TimeSpan>("DepartureTime"),
                    DepartureCityID = dataRow.Field<string>("DepartureCityID"),
                    DepartureCity = dataRow.Field<string>("DepCity"),
                    ArrivalCityID = dataRow.Field<string>("ArrivalCityID"),
                    ArrivalCity = dataRow.Field<string>("ArrCity"),
                    AircraftID = dataRow.Field<string>("AircraftID"),
                    Aircraft = dataRow.Field<string>("Aircraft"),
                    Company = dataRow.Field<string>("Company"),
                    Photo = dataRow.Field<string>("Photo"),
                    EconomyPrice = dataRow.Field<decimal>("EconomyPrice"),
                    BusinessPrice = dataRow.Field<decimal>("BusinessPrice"),
                    FirstPrice = dataRow.Field<decimal>("FirstPrice")
                }).ToList();

            if (search == true)
            {
                var searchData = convertDataSetToList.Where(x=>
                x.DepartureCityID.Equals(cboDepartureCity.SelectedValue.ToString()) && 
                x.ArrivalCityID.Equals(cboArrivalCity.SelectedValue.ToString()) &&
                x.DepartureDate.ToString("yyyy-MM-dd").Contains(txtDepartureDate.Value.ToString("yyyy-MM-dd"))).ToList();
                if (searchData.Count > 0) convertDataSetToList = searchData;
                else isSearchNotFound = true;
            }

            foreach (var item in convertDataSetToList)
            {
                string economyPrice = item.EconomyPrice == 0 ? "-" : item.EconomyPrice.ToString("N");
                string businessPrice = item.BusinessPrice == 0 ? "-" : item.BusinessPrice.ToString("N");
                string firstPrice = item.FirstPrice == 0 ? "-" : item.FirstPrice.ToString("N");
                dgvFlightSchedule.Rows.Add(item.ID, item.DepartureCityID, item.DepartureCity,
                    item.ArrivalCityID, item.ArrivalCity, item.DepartureDate.ToString("dd/MM/yyyy"), 
                    item.DepartureTime, item.AircraftID, item.Aircraft, item.Company, 
                    item.Photo, item.EconomyPrice, economyPrice, item.BusinessPrice, businessPrice, 
                    item.FirstPrice, firstPrice);
            }

            if(isSearchNotFound)
                MessageBox.Show("Data not found!", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void fillCboCustomer()
        {
            DataSet dsCustomer = database.getDataFromDatabase("sp_view_customers", null);
            cboCustomer.DataSource = dsCustomer.Tables[0];
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "ID";
        }

        private void setSeat(string scheduleID,string aircraftID, 
            decimal economy, decimal business, decimal firstclass)
        {
            panelSeat.Controls.Clear();

            // First Class
            DataSet dsFirst = database.getDataFromDatabase("sp_view_transaction_get_seat",
               new List<Parameter> {
                    new Parameter("@AircraftID", aircraftID),
                    new Parameter("@CabinType", "First Class")
               });

            if (dsFirst.Tables.Count > 0)
            {
                if (dsFirst.Tables[0].Rows.Count > 0)
                {
                    string cabintype = dsFirst.Tables[0].Rows[0][0].ToString();
                    int seat = Convert.ToInt32(dsFirst.Tables[0].Rows[0][1].ToString());
                    int left = Convert.ToInt32(dsFirst.Tables[0].Rows[0][2].ToString());
                    int mid = Convert.ToInt32(dsFirst.Tables[0].Rows[0][3].ToString());
                    int right = Convert.ToInt32(dsFirst.Tables[0].Rows[0][4].ToString());
                    UclSeat seatFlight = new UclSeat(scheduleID, cabintype,
                                            left, mid, right, seat, 0, firstclass,this);
                    seatFlight.Margin = new Padding(0, 5, 0, 5);
                    panelSeat.Controls.Add(seatFlight);
                }
            }

            // Business Class
            DataSet dsBusiness = database.getDataFromDatabase("sp_view_transaction_get_seat",
                new List<Parameter> {
                    new Parameter("@AircraftID", aircraftID),
                    new Parameter("@CabinType", "Business Class")
                });

            if (dsBusiness.Tables.Count > 0)
            {
                if (dsBusiness.Tables[0].Rows.Count > 0)
                {
                    string cabintype = dsBusiness.Tables[0].Rows[0][0].ToString();
                    int seat = Convert.ToInt32(dsBusiness.Tables[0].Rows[0][1].ToString());
                    int left = Convert.ToInt32(dsBusiness.Tables[0].Rows[0][2].ToString());
                    int mid = Convert.ToInt32(dsBusiness.Tables[0].Rows[0][3].ToString());
                    int right = Convert.ToInt32(dsBusiness.Tables[0].Rows[0][4].ToString());
                    UclSeat seatFlight = new UclSeat(scheduleID, cabintype,
                                            left, mid, right, seat, 0, business,this);
                    seatFlight.Margin = new Padding(0, 5, 0, 5);
                    panelSeat.Controls.Add(seatFlight);
                }
            }

            // Economy Class
            DataSet dsEconomy = database.getDataFromDatabase("sp_view_transaction_get_seat",
                new List<Parameter> {
                    new Parameter("@AircraftID", aircraftID),
                    new Parameter("@CabinType", "Economy Class")
                });

            if (dsEconomy.Tables.Count > 0)
            {
                if (dsEconomy.Tables[0].Rows.Count > 0)
                {
                    string cabintype = dsEconomy.Tables[0].Rows[0][0].ToString();
                    int seat = Convert.ToInt32(dsEconomy.Tables[0].Rows[0][1].ToString());
                    int left = Convert.ToInt32(dsEconomy.Tables[0].Rows[0][2].ToString());
                    int mid = Convert.ToInt32(dsEconomy.Tables[0].Rows[0][3].ToString());
                    int right = Convert.ToInt32(dsEconomy.Tables[0].Rows[0][4].ToString());
                    UclSeat seatFlight = new UclSeat(scheduleID, cabintype, 
                        left, mid, right, seat, 0, economy,this);
                    seatFlight.Margin = new Padding(0, 5, 0, 5);
                    panelSeat.Controls.Add(seatFlight);
                }
            }
        }
        #endregion
        #region Events
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.White, Color.Gray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UclTicket ticket = new UclTicket();
            ((FrmMenuAgency)Support.frm).addControltoPanel(ticket);
            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase - Ticket]";
        }

        private void UclPurchase_Load(object sender, EventArgs e)
        {
            defaultFrm(false);
            fillcboCity();
            fillCboCustomer();
            refreshDatagridSchedule(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshDatagridSchedule(true);
        }

        private void dgvFlightSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (!isSelected && dgvFlightSchedule.RowCount > 0)
            {
                row = dgvFlightSchedule.CurrentRow;
                lblDepartureCity.Text = row.Cells[2].Value.ToString();
                lblArrivalCity.Text = row.Cells[4].Value.ToString();
                string[] dateArray = row.Cells[5].Value.ToString().Split('/');
                lblDepartureDate.Text = (new DateTime(Convert.ToInt32(dateArray[2]), 
                    Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]))).ToString("dd MMMM yyyy");
                lblDepartureTime.Text = row.Cells[6].Value.ToString();
                lblAircraft.Text = row.Cells[8].Value.ToString();
                lblEconomyPrice.Text = "Rp. " + row.Cells[12].Value.ToString();
                lblBusinessPrice.Text = "Rp. " + row.Cells[14].Value.ToString();
                lblFirstPrice.Text = "Rp. " + row.Cells[16].Value.ToString();
                flightGroup.Visible = true;
                btnSelect.Visible = true;

                string base64string = row.Cells[10].Value.ToString();
                string extension = base64string.Substring(base64string.IndexOf('/'),
                    base64string.IndexOf(';') - base64string.IndexOf('/'));
                string path = base64string.Substring(base64string.IndexOf(',') + 2,
                    base64string.Length - (base64string.IndexOf(',') + 2));
                byte[] image = Convert.FromBase64String(path);
                photo.Image = support.byteArrayToImage(image);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            defaultFrm(true);
            customerGroup.Enabled = true;
            FinalGroup.Enabled = true;
            setSeat(row.Cells[0].Value.ToString(),row.Cells[7].Value.ToString(),
                Convert.ToDecimal(row.Cells[11].Value.ToString()), Convert.ToDecimal(row.Cells[13].Value.ToString()),
                Convert.ToDecimal(row.Cells[15].Value.ToString()));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshDatagridSchedule(false);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            defaultFrm(false);
            refreshDatagridSchedule(false);
            buttonSeat = null;
        }

        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Cabin Type: " + buttonSeat.CabinType);
            Console.WriteLine("Seat Number: " + buttonSeat.SeatNumber);
            Console.WriteLine("Text: " + buttonSeat.Text);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FrmPopUp popup = new FrmPopUp();
            popup.Show();
        }
        #endregion
    }
}
