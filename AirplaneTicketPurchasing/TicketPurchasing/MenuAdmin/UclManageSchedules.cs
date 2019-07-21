using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;

namespace TicketPurchasing.MenuAdmin
{
    public partial class UclManageSchedules : UserControl
    {
        Support support = new Support();
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation validate = new Validation();
        private bool isInserting = false, isUpdating = false, isoldest = false;
        private string messege = "";

        public UclManageSchedules()
        {
            InitializeComponent();
            enableForm(false);
            createTable();
            refreshDg(txtSearch.Text,cbofilterby.Text);
            initCmb();
            clear();
        }

        private void initCmb()
        {
            DataSet aircraft = database.getDataFromDatabase("sp_view_aircrafts", null);
            DataSet from = database.getDataFromDatabase("sp_view_cities", null);
            DataSet dest = database.getDataFromDatabase("sp_view_cities", null);

            cmbAircraft.DataSource = aircraft.Tables[0];
            cmbAircraft.DisplayMember = "Name";
            cmbAircraft.ValueMember = "ID";
            cmbArrival.DataSource = dest.Tables[0];
            cmbArrival.DisplayMember = "Name";
            cmbArrival.ValueMember = "ID";
            cmbDepart.DataSource = from.Tables[0];
            cmbDepart.DisplayMember = "Name";
            cmbDepart.ValueMember = "ID";
        }

        private void clear()
        {
            txtFee.Value = 0;
            txtHour.Clear();
            txtMin.Clear();
            txtSearch.Clear();
            cmbAircraft.SelectedItem = null;
            cmbArrival.SelectedItem = null;
            cmbDepart.SelectedItem = null;
            isInserting = false;
            isUpdating = false;
            dtDeparture.Value = DateTime.Now;
            row = null;
        }

        private void enableForm(bool value)
        {
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            txtFee.Enabled = value;
            txtHour.Enabled = value;
            txtMin.Enabled = value;
            cmbAircraft.Enabled = value;
            cmbArrival.Enabled = value;
            cmbDepart.Enabled = value;
            dtDeparture.Enabled = value;
        }

        private void createTable()
        {
            dgvSch.Rows.Clear();
            dgvSch.Columns.Clear();
            dgvSch.Columns.Add("id", "ID");
            dgvSch.Columns.Add("aircraftID", "Aircraft ID");
            dgvSch.Columns.Add("aircraft", "Aircraft");
            dgvSch.Columns.Add("depCityID", "Dep City ID");
            dgvSch.Columns.Add("depCity", "Dep. City");
            dgvSch.Columns.Add("arrCityID", "Arr. CItyID");
            dgvSch.Columns.Add("arrCity", "Arr. CIty");
            dgvSch.Columns.Add("date", "Date");
            dgvSch.Columns.Add("time", "Time");
            dgvSch.Columns.Add("flightTime", "Flight Duration");
            dgvSch.Columns.Add("price", "Price");
            dgvSch.Columns.Add("fee", "Fee");
            dgvSch.Columns[0].Visible = false;
            dgvSch.Columns[1].Visible = false;
            dgvSch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSch.Columns[3].Visible = false;
            dgvSch.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSch.Columns[5].Visible = false;
            dgvSch.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSch.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSch.Columns[10].Visible = false;
            dgvSch.HeaderForeColor = Color.White;
            dgvSch.HeaderBgColor = Color.Teal;
        }

        private void refreshDg(string search,string status)
        {
            dgvSch.Rows.Clear();
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@status", status));
            DataSet data = database.getDataFromDatabase("sp_view_schedule", param);
            var dsToList = data.Tables[0].AsEnumerable().Select(
                x => new
                {
                    id = x.Field<string>("ID"),
                    depDate = x.Field<DateTime>("DepartureDate"),
                    depTime = x.Field<TimeSpan>("DepartureTime"),
                    fee = x.Field<decimal>("Price"),
                    flightTIme = x.Field<string>("FlightTime"),
                    depCityID = x.Field<string>("DepartureCityID"),
                    depCity = x.Field<string>("DepCity"),
                    arrCItyID = x.Field<string>("ArrivalCityID"),
                    arrCIty = x.Field<string>("ArrCity"),
                    aircraftID = x.Field<string>("AircraftID"),
                    aircraft = x.Field<string>("Aircraft")
                }).ToList();

            if (search != null)
            {
                dsToList = dsToList.Where(x => x.aircraft.Contains(search) || x.depCity.Contains(search) ||
                    x.arrCIty.Contains(search) || x.depDate.ToString().Contains(search) || x.depTime.ToString().Contains(search) ||
                    x.flightTIme.ToString().Contains(search) || x.fee.ToString().Contains(search)).ToList();
            }

            foreach (var item in dsToList)
            {
                dgvSch.Rows.Add(item.id, item.aircraftID, item.aircraft, item.depCityID, item.depCity,
                    item.arrCItyID, item.arrCIty, item.depDate.ToString("dd MMMM yyyy"), item.depTime, item.flightTIme,item.fee,item.fee.ToString("N"));
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isInserting = true;
            enableForm(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isUpdating = true;
            enableForm(true);
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                if(isoldest)
                {
                    MessageBox.Show("Can't edit old schedule", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure?", "Delete Data",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = row.Cells[0].Value.ToString();
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@id", id));
                    int result = database.executeQuery("sp_delete_schedule", param, "Deletion");
                    if (result == 1)
                        MessageBox.Show("Data deleted", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No Schedule Selected", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clear();
            enableForm(false);
            refreshDg(null,cbofilterby.Text);
        }

        private bool Validation()
        {
            bool result = false;
            try
            {
                DateTime date = new DateTime(dtDeparture.Value.Year, dtDeparture.Value.Month, dtDeparture.Value.Day, dtDeparture.Value.Hour, dtDeparture.Value.Minute, 0);
                DateTime date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    DateTime.Now.Hour, DateTime.Now.Minute, 0);
                DateTime lastdate = date2.AddDays(6);
                Console.WriteLine(date + " " + lastdate);
                if (cmbAircraft.Text == "" || cmbArrival.Text == "" || cmbArrival.Text == "" ||
                    txtHour.Text == "" || txtMin.Text == "" || txtFee.Value <= 0)
                    messege = "Ensure you have filled all fields";
                else if (date < lastdate)
                    messege = "Ensure Departure time must bigger 7 days than today";
                else if (Convert.ToInt32(txtHour.Text) < 0 || Convert.ToInt32(txtHour.Text) > 23 ||
                    Convert.ToInt32(txtMin.Text) < 0 || Convert.ToInt32(txtMin.Text) > 59)
                    messege = "Format Flight time is not valid";
                else if(cmbDepart.Text.ToString() == cmbArrival.Text.ToString())
                {
                    messege = "Ensure departure city not same with arrival city";
                }
                else if (isoldest)
                {
                    messege = "Can't edit old schedule";
                }
                else
                {
                    SqlConnection conn = new SqlConnection(database.getConnectionString());
                    try
                    {
                        conn.Open();
                        SqlCommand cmd;
                        if(isInserting)
                            cmd = new SqlCommand("sp_check_flight", conn);
                        else
                            cmd = new SqlCommand("sp_check_flight2", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if(isUpdating)
                            cmd.Parameters.AddWithValue("@ID", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@DepartureDate", dtDeparture.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@DepartureTime", dtDeparture.Value.ToString("hh:mm"));
                        cmd.Parameters.AddWithValue("@DepartureCityID", cmbDepart.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ArrivalCityID", cmbArrival.SelectedValue.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            messege = "Flight already exists on " + dtDeparture.Value.ToString("dd-MM-yyyy") + " " + dtDeparture.Value.ToString("hh:mm");
                        }
                        else
                        {
                            result = true;
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableForm(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDg(txtSearch.Text,cbofilterby.Text);
        }

        private void txtFee_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == (int)Keys.Back)
            {
                SendKeys.Send("{ENTER}");
                txtFee.Select();
                SendKeys.Send("{END}");
            }
        }

        private void UclManageSchedules_Load(object sender, EventArgs e)
        {
            cbofilterby.SelectedIndex = 0;
        }

        private void cbofilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clear();
                refreshDg(txtSearch.Text,cbofilterby.Text);
                if (cbofilterby.Text.Equals("Oldest")) isoldest = true;
                else isoldest = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvSch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (!isInserting && !isUpdating && dgvSch.Rows.Count > 0)
                {
                    try
                    {
                        row = dgvSch.CurrentRow;
                        cmbDepart.SelectedValue = row.Cells[3].Value.ToString();
                        cmbArrival.SelectedValue = row.Cells[5].Value.ToString();
                        cmbAircraft.SelectedValue = row.Cells[1].Value.ToString();
                        DateTime date = Convert.ToDateTime(row.Cells[7].Value.ToString() + " " + row.Cells[8].Value.ToString());
                        dtDeparture.Value = date;
                        txtFee.Value = Convert.ToDecimal(row.Cells[10].Value.ToString());
                        int hour = Convert.ToInt16(Regex.Match(row.Cells[9].Value.ToString().Split(' ')[0], @"\d+").Value) / 60;
                        int min = Convert.ToInt16(Regex.Match(row.Cells[9].Value.ToString().Split(' ')[0], @"\d+").Value) % 60;
                        txtHour.Text = hour.ToString();
                        txtMin.Text = min.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvSch_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                string proses = "";
                string date = dtDeparture.Value.ToString("yyyy-MM-dd");
                string time = dtDeparture.Value.ToString("hh:mm");
                int duration = Convert.ToInt16(txtHour.Text) * 60 + Convert.ToInt16(txtMin.Text);
                int result = 0;
                try
                {
                    if (isInserting)
                    {
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", database.autoGenerateID("S", "sp_last_schedule", 5)));
                        param.Add(new Parameter("@DepartureDate", date));
                        param.Add(new Parameter("@DepartureTime", time));
                        param.Add(new Parameter("@price", txtFee.Value.ToString()));
                        param.Add(new Parameter("@FlightTime", duration.ToString()));
                        param.Add(new Parameter("@DepartureCityId", cmbDepart.SelectedValue.ToString()));
                        param.Add(new Parameter("@ArrivalCityId", cmbArrival.SelectedValue.ToString()));
                        param.Add(new Parameter("@AircraftId", cmbAircraft.SelectedValue.ToString()));
                        result = database.executeQuery("sp_insert_schedule", param, "Insertion");
                        proses = "Add";
                    }
                    else
                    {
                        DateTime departureDate = new DateTime(dtDeparture.Value.Year, dtDeparture.Value.Month, dtDeparture.Value.Day, dtDeparture.Value.Hour, dtDeparture.Value.Minute, 0);
                        DateTime lastUpdateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            DateTime.Now.Hour, DateTime.Now.Minute, 0);
                        lastUpdateDate.AddDays(-7);
                        if (departureDate < lastUpdateDate)
                        {
                            MessageBox.Show("You can't change fixed date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                        param.Add(new Parameter("@DepartureDate", date));
                        param.Add(new Parameter("@DepartureTime", time));
                        param.Add(new Parameter("@price", txtFee.Value.ToString()));
                        param.Add(new Parameter("@FlightTime", duration.ToString()));
                        param.Add(new Parameter("@DepartureCityId", cmbDepart.SelectedValue.ToString()));
                        param.Add(new Parameter("@ArrivalCityId", cmbArrival.SelectedValue.ToString()));
                        param.Add(new Parameter("@AircraftId", cmbAircraft.SelectedValue.ToString()));
                        result = database.executeQuery("sp_update_schedule", param, "Update");
                        proses = "Update";
                    }

                    if (result == 1)
                    {
                        MessageBox.Show(proses+ " data has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableForm(false);
                        refreshDg(null,cbofilterby.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show(messege, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
