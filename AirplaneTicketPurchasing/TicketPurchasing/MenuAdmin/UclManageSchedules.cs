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

namespace TicketPurchasing.MenuAdmin
{
    public partial class UclManageSchedules : UserControl
    {
        Support support = new Support();
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation validate = new Validation();
        private bool isInserting = false, isUpdating = false;
        private string messege;

        public UclManageSchedules()
        {
            InitializeComponent();
            enableForm(false);
            clear();
            createTable();
            refreshDg(txtSearch.Text);
            initCmb();
            Console.Write(DateTime.Now);
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
            txtFee.Clear();
            txtHour.Clear();
            txtMin.Clear();
            txtSearch.Clear();
            cmbAircraft.SelectedItem = null;
            cmbArrival.SelectedItem = null;
            cmbDepart.SelectedItem = null;
            isInserting = false;
            isUpdating = false;
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
            txtSearch.Enabled = value;
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
            dgvSch.Columns.Add("depCity", "Dep.  City");
            dgvSch.Columns.Add("arrCity", "Arr. CIty");
            dgvSch.Columns.Add("date", "Date");
            dgvSch.Columns.Add("time", "Time");
            dgvSch.Columns.Add("flightTime", "Flight Duration");
            dgvSch.Columns.Add("fee", "Fee");
            dgvSch.Columns.Add("aircraftID", "Aircraft");
            dgvSch.Columns.Add("item", "item");
            dgvSch.Columns[7].Visible = false;
            dgvSch.HeaderForeColor = Color.White;
            dgvSch.HeaderBgColor = Color.Teal;
            dgvSch.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSch.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSch.Columns[8].Visible = false;
        }

        private void refreshDg(string search)
        {
            dgvSch.Rows.Clear();
            List<Parameter> param = new List<Parameter>();
            DataSet data = database.getDataFromDatabase("sp_view_schedule", null);
            DataSet city = database.getDataFromDatabase("sp_view_cities", null);
            DataSet aircraft = database.getDataFromDatabase("sp_view_aircrafts", null);
            var aircraftList = aircraft.Tables[0].AsEnumerable();
            var cityList = city.Tables[0].AsEnumerable();
            var dsToList = data.Tables[0].AsEnumerable().Select(
                x => new
                {
                    id = x.Field<string>("ID"),
                    depDate = x.Field<DateTime>("DepartureDate"),
                    depTime = x.Field<TimeSpan>("DepartureTime"),
                    fee = x.Field<Decimal>("Price"),
                    flightTIme = x.Field<Int32>("FlightTime"),
                    depCity = x.Field<string>("DepartureCityID"),
                    arrCIty = x.Field<string>("ArrivalCityID"),
                    aircraft = x.Field<string>("AircraftID")
                }).ToList();

            if (search != null)
            {
                dsToList = dsToList.Where(x => x.id.Contains(search) || x.depDate.ToString().Contains(search) ||
                x.depTime.ToString().Contains(search) || x.fee == Convert.ToInt32(search) || x.flightTIme == Convert.ToInt32(search) ||
                x.depCity.Contains(search) || x.arrCIty.Contains(search) || x.aircraft.Contains(search)).ToList();
            }

            foreach(var item in dsToList)
            {
                DataRow[] references = new DataRow[3];
                references[0] = city.Tables[0].Select("ID = '" + item.depCity + "'").FirstOrDefault();
                references[1] = city.Tables[0].Select("ID = '" + item.arrCIty + "'").FirstOrDefault();
                references[2] = aircraft.Tables[0].Select("ID = '" + item.aircraft + "'").FirstOrDefault();

                dgvSch.Rows.Add(item.id, references[0].Field<string>("Name"), references[1].Field<string>("Name"), item.depDate.ToString("dd-MMMM-yyyy"),
                    item.depTime,item.flightTIme+" Min",item.fee.ToString("C2", CultureInfo.GetCultureInfo("id")),references[2].Field<string>("Name"),item.fee);
            }
        }

        private bool validation()
        {
            bool res = false;

            DateTime firstDate = new DateTime(dtDeparture.Value.Year, dtDeparture.Value.Month, dtDeparture.Value.Day);
            DateTime secondDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (firstDate <= secondDate) messege = "Date Must Be in The Future";
            else if (txtFee.Text == "" || txtHour.Text == "" || txtMin.Text == "" || cmbAircraft.SelectedValue == null ||
                cmbArrival.SelectedValue == null || cmbDepart.SelectedValue == null || dtDeparture.Value == null)
                messege = "Ensure you have fill all field";
            else
                res = true;
            return res;
        }

        private void dgvSch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInserting && !isUpdating)
            {
                row = dgvSch.CurrentRow;
                cmbDepart.Text = row.Cells[1].Value.ToString();
                cmbArrival.Text = row.Cells[2].Value.ToString();
                cmbAircraft.Text = row.Cells[7].Value.ToString();
                DateTime date = Convert.ToDateTime(row.Cells[3].Value.ToString()+" "+row.Cells[4].Value.ToString());
                dtDeparture.Value = date;
                int hour = Convert.ToInt16(Regex.Match(row.Cells[5].Value.ToString(), @"\d+").Value) / 60;
                int min = Convert.ToInt16(Regex.Match(row.Cells[5].Value.ToString(), @"\d+").Value) % 60;
                txtHour.Text = hour.ToString();
                txtMin.Text = min.ToString();
                txtFee.Text = Convert.ToInt32(row.Cells[8].Value).ToString();
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
            refreshDg(null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string date = dtDeparture.Value.ToString("yyyy-MM-dd");
            string time = dtDeparture.Value.ToString("hh:mm");
            int duration = Convert.ToInt16(txtHour.Text) * 60 + Convert.ToInt16(txtMin.Text);
            Console.WriteLine("Date: " + date + " time: " + time);
            if (validation())
            {
                int result = 0;
                try
                {
                    if (isInserting)
                    {
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", database.autoGenerateID("S", "sp_last_schedule", 5)));
                        param.Add(new Parameter("@DepartureDate", date));
                        param.Add(new Parameter("@DepartureTime", time));
                        param.Add(new Parameter("@price", txtFee.Text));
                        param.Add(new Parameter("@FlightTime", duration.ToString()));
                        param.Add(new Parameter("@DepartureCityId", cmbDepart.SelectedValue.ToString()));
                        param.Add(new Parameter("@ArrivalCityId", cmbArrival.SelectedValue.ToString()));
                        param.Add(new Parameter("@AircraftId", cmbAircraft.SelectedValue.ToString()));
                        result = database.executeQuery("sp_insert_schedule", param, "Insertion");
                    }
                    else
                    {
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                        param.Add(new Parameter("@DepartureDate", date));
                        param.Add(new Parameter("@DepartureTime", time));
                        param.Add(new Parameter("@price", txtFee.Text));
                        param.Add(new Parameter("@FlightTime", duration.ToString()));
                        param.Add(new Parameter("@DepartureCityId", cmbDepart.SelectedValue.ToString()));
                        param.Add(new Parameter("@ArrivalCityId", cmbArrival.SelectedValue.ToString()));
                        param.Add(new Parameter("@AircraftId", cmbAircraft.SelectedValue.ToString()));
                        result = database.executeQuery("sp_update_schedule", param, "Update");
                    }

                    if (result == 1)
                    {
                        MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableForm(false);
                        refreshDg(null);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
