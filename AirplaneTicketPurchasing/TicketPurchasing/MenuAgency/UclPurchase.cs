using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TicketPurchasing.MenuAgency
{
    public partial class UclPurchase : UserControl
    {
        #region Declaration
        private Database database = new Database();
        private bool isSelected = false;
        private DataGridViewRow row = null;
        private Support support = new Support();
        private ButtonSeat button_seat = null, button_seat_selected = null;
        private FrmMenuAgency agency;
        private DataGridViewRow row2;
        private List<ButtonSeat> btnList = new List<ButtonSeat>();
        private int posButton = 0;
        private decimal totalTransaction = 0;
        private TicketDataSet ticketdataset = new TicketDataSet();
        #endregion
        #region Constructor
        public UclPurchase()
        {
            InitializeComponent();
        }

        public UclPurchase(FrmMenuAgency agency)
        {
            InitializeComponent();
            this.agency = agency;
        }
        #endregion
        #region Method
        private void createTable()
        {
            dgvCustomer.Rows.Clear();
            dgvCustomer.Columns.Clear();
            dgvCustomer.Columns.Add("customerID", "CustomerID");
            dgvCustomer.Columns.Add("customerName", "Customer Name");
            dgvCustomer.Columns.Add("realSeatNumber", "Real Seat Number");
            dgvCustomer.Columns.Add("seatNumber", "Seat Number");
            dgvCustomer.Columns.Add("cabinType", "Cabin Type");
            dgvCustomer.Columns.Add("price", "Price");
            dgvCustomer.Columns[0].Visible = false;
            dgvCustomer.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns[2].Visible = false;
            dgvCustomer.Columns[5].Visible = false;
            dgvCustomer.HeaderBgColor = Color.Teal;
            dgvCustomer.HeaderForeColor = Color.White;
            dgvCustomer.ForeColor = Color.Black;
        }

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
            double pos = 0;
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
                                            left, mid, right, seat, (int)pos, firstclass,this);
                    pos = (double)seat / (double)(left + mid + right);
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
                    if (pos.ToString().Split('.').Length == 2) pos = Convert.ToDouble(pos.ToString().Split('.')[0]) + 1;
                    UclSeat seatFlight = new UclSeat(scheduleID, cabintype,
                                            left, mid, right, seat, (int)pos, business,this);
                    pos += (double)seat / (double)(left + mid + right);
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
                    if (pos.ToString().Split('.').Length == 2) pos = Convert.ToDouble(pos.ToString().Split('.')[0]) + 1;
                    UclSeat seatFlight = new UclSeat(scheduleID, cabintype, 
                        left, mid, right, seat, (int)pos, economy,this);
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

        private string getBookingRef()
        {
            string bookingref = "";
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            bool isSuccessed = false;
            Random rand = new Random();
            do
            {
                isSuccessed = true;
                bookingref = "";
                for(int i = 0; i < 6; i++)
                {
                    int x = rand.Next(alphabet.Length - 1);
                    Console.WriteLine(x);
                    bookingref += alphabet[x];
                }


                SqlConnection conn = new SqlConnection(database.getConnectionString());
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_check_bookingRef", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingRef", bookingref);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        isSuccessed = false;
                    }
                    else
                    {
                        isSuccessed = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            } while (!isSuccessed);

            return bookingref;
        }

        private string getID()
        {
            string id = "";
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Username", Thread.CurrentPrincipal.Identity.Name));
            DataSet ds = database.getDataFromDatabase("sp_get_id_employees", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    id = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            return id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticketdataset = new TicketDataSet();
            ticketdataset.DataTable1.Clear();
            if (dgvCustomer.Rows.Count > 0)
            {
                try
                {
                    string bookingref = getBookingRef();
                    string id = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", id));
                    param.Add(new Parameter("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd")));
                    param.Add(new Parameter("@BookingRef", bookingref));
                    param.Add(new Parameter("@Status", "P"));
                    param.Add(new Parameter("@EmployeeID", getID()));
                    param.Add(new Parameter("@Schedule", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@TotalPrice", totalTransaction.ToString()));
                    int result = database.executeQuery("sp_insert_tickets", param, "Add");

                    if (result > 0)
                    {
                        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                        {
                            List<Parameter> param2 = new List<Parameter>();
                            param2.Add(new Parameter("@SeatNumber", dgvCustomer.Rows[i].Cells[2].Value.ToString()));
                            param2.Add(new Parameter("@Price", dgvCustomer.Rows[i].Cells[5].Value.ToString()));
                            param2.Add(new Parameter("@CabinType", dgvCustomer.Rows[i].Cells[4].Value.ToString()));
                            param2.Add(new Parameter("@TicketID", id));
                            param2.Add(new Parameter("@CustomerID", dgvCustomer.Rows[i].Cells[0].Value.ToString()));

                            ticketdataset.DataTable1.AddDataTable1Row(
                                dgvCustomer.Rows[i].Cells[1].Value.ToString(),
                                dgvCustomer.Rows[i].Cells[3].Value.ToString(),
                                dgvCustomer.Rows[i].Cells[4].Value.ToString());
                            int x = database.executeQuery("sp_insert_detailtickets", param2, "Add");
                        }

                        MessageBox.Show("Purchase ticket has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string[] dateArray = new string[3];
                        try
                        {
                            dateArray = row.Cells[5].Value.ToString().Split('/');
                            UclSaveToPDF ticket = new UclSaveToPDF(bookingref,
                           "Aircraft: " + row.Cells[8].Value.ToString(),
                           row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(),
                            "Departure Date: " + (new DateTime(Convert.ToInt32(dateArray[2]),
                            Convert.ToInt32(dateArray[1]),
                            Convert.ToInt32(dateArray[0]))).ToString("dd MMMM yyyy"),
                            "Departure Time: " + row.Cells[6].Value.ToString(), ticketdataset, "Transaction Date: " + DateTime.Now.ToString("dd MMMM yyyy"));
                            ((FrmMenuAgency)Support.frm).addControltoPanel(ticket);
                            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase - Ticket]";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            dateArray = row.Cells[5].Value.ToString().Split('-');
                            UclSaveToPDF ticket = new UclSaveToPDF(bookingref,
                           "Aircraft: " + row.Cells[8].Value.ToString(),
                           row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(),
                            "Departure Date: " + (new DateTime(Convert.ToInt32(dateArray[2]),
                            Convert.ToInt32(dateArray[1]),
                            Convert.ToInt32(dateArray[0]))).ToString("dd MMMM yyyy"),
                            "Departure Time: " + row.Cells[6].Value.ToString(), ticketdataset, "Transaction Date: " + DateTime.Now.ToString("dd MMMM yyyy"));
                            ((FrmMenuAgency)Support.frm).addControltoPanel(ticket);
                            ((FrmMenuAgency)Support.frm).lblTitle.Text = "FLIGHTSI - TRANSACTION [Purchase - Ticket]";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase ticket is failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Ensure you have customer in list passenger", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UclPurchase_Load(object sender, EventArgs e)
        {
            btnList = new List<ButtonSeat>();
            createTable();
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
            try
            {
                if (!isSelected && dgvFlightSchedule.RowCount > 0)
                {
                    row = dgvFlightSchedule.CurrentRow;
                    lblDepartureCity.Text = row.Cells[2].Value.ToString();
                    lblArrivalCity.Text = row.Cells[4].Value.ToString();
                    string[] dateArray = new string[3];
                    try
                    {
                        dateArray = row.Cells[5].Value.ToString().Split('/');
                        lblDepartureDate.Text = (new DateTime(Convert.ToInt32(dateArray[2]),
                        Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]))).ToString("dd MMMM yyyy");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        dateArray = row.Cells[5].Value.ToString().Split('-');
                        lblDepartureDate.Text = (new DateTime(Convert.ToInt32(dateArray[2]),
                        Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]))).ToString("dd MMMM yyyy");
                    }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            btnList = new List<ButtonSeat>();
            createTable();
            defaultFrm(false);
            refreshDatagridSchedule(false);
            buttonSeat = null;
            row2 = null;
            posButton = 0;
            totalTransaction = 0;
            try
            {
                cboCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(database.getConnectionString());
            try
            {
                string[] dateArray = new string[3];
                try
                {
                    dateArray = row.Cells[5].Value.ToString().Split('/');
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    dateArray = row.Cells[5].Value.ToString().Split('-');
                }
                DateTime departureDate = new DateTime(Convert.ToInt32(dateArray[2]),
                    Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]));

                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_check_passenger", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", cboCustomer.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DepartureDate", departureDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@DepartureTime", row.Cells[6].Value.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Customer " + cboCustomer.Text + " is already flight on " + 
                        departureDate.ToString("dd-MMM-yyyyy") + " " + row.Cells[6].Value.ToString(), "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            try
            {
                DataGridViewRow row = dgvCustomer.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value.ToString() == cboCustomer.SelectedValue.ToString()).FirstOrDefault();
                if(row != null)
                {
                    MessageBox.Show("Passenger already exists in customer list", "Warning", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (button_seat_selected != null)
                {
                    MessageBox.Show("Ensure you don't chose selected seat", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                totalTransaction += buttonSeat.Price;
                Console.WriteLine("Price: " + buttonSeat.Price);
                btnList.Add(buttonSeat);
                dgvCustomer.Rows.Add(cboCustomer.SelectedValue.ToString(),
                    cboCustomer.Text, buttonSeat.SeatNumber, buttonSeat.Text,
                    buttonSeat.CabinType, buttonSeat.Price);
                buttonSeat.Condition = 3;
                buttonSeat = null;
                lblTotalTransaction.Text = "Rp. " + totalTransaction.ToString("N");
                MessageBox.Show("Add passenger has been success", "Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FrmPopUp popup = new FrmPopUp(agency);
            popup.Show();
            agency.enabledFrm(false);
        }
        #endregion

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            fillCboCustomer();
        }

        private void cboCustomer_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(cboCustomer, "Message");
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isSelected)
                {
                    if(row2 != null)
                        btnList[row2.Index].Condition = 3;
                    row2 = dgvCustomer.CurrentRow;
                    posButton = e.RowIndex;
                    btnList[posButton].Condition = 4;
                    button_seat_selected = btnList[posButton];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        private void btnDeletePassenger_Click(object sender, EventArgs e)
        {
            if(button_seat != null)
            {
                MessageBox.Show("Ensure you don't choose seat", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (row2 != null && button_seat_selected != null)
            {
                if(MessageBox.Show("Are you sure?","Delete Data",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvCustomer.Rows.Remove(row2);
                    btnList[posButton].Condition = 0;
                    btnList[posButton].Clicked = false;
                    totalTransaction -= btnList[posButton].Price;
                    lblTotalTransaction.Text = "Rp. " + totalTransaction.ToString("N");
                    btnList.Remove(btnList[posButton]);
                    MessageBox.Show("Remove Passenger has been success", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    row2 = null;
                }
            }
            else
                MessageBox.Show("Ensure you have selected customer",
                    "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {

            if(buttonSeat != null)
            {
                buttonSeat.Condition = 0;
                buttonSeat.Clicked = false;
            }

            if(btnList[posButton] != null)
            {
                btnList[posButton].Condition = 3;
            }

            button_seat = null;
            button_seat_selected = null;
        }
    }
}
