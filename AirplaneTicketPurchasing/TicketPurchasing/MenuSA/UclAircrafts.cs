using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketPurchasing.Class;

namespace TicketPurchasing.MenuSA
{
    public partial class UclAircrafts : UserControl
    {
        #region Declaration
        private Database database = new Database();
        private Validation valid = new Validation();
        private List<string> aircraftTypeid = new List<string>();
        private List<string> aircraftamenitiesid = new List<string>();
        private List<AircraftDetails> detailTypes = new List<AircraftDetails>();
        private List<AircraftAmenities> amenities = new List<AircraftAmenities>();
        private bool isUpdate = true, isUpdateAircraftDetails = true, isEdittedAmenities = false, isEdittedDetail = false, isEdittedAircraft = false;
        private DataGridViewRow row,row2,row3;
        private string message = "";

        #endregion
        #region Constructor
        public UclAircrafts()
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
        #region Aircrafts
        #region Create Table Aircrafts
        private void createTableAircrafts()
        {
            dgvAircrafts.Rows.Clear();
            dgvAircrafts.Columns.Clear();
            dgvAircrafts.Columns.Add("id", "ID");
            dgvAircrafts.Columns.Add("name", "Name");
            dgvAircrafts.Columns.Add("companyID", "Company ID");
            dgvAircrafts.Columns.Add("company", "Company");
            dgvAircrafts.Columns.Add("typeid", "Type ID");
            dgvAircrafts.Columns.Add("type", "Type");
            dgvAircrafts.Columns[0].Visible = false;
            dgvAircrafts.Columns[2].Visible = false;
            dgvAircrafts.Columns[4].Visible = false;
            dgvAircrafts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAircrafts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAircrafts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAircrafts.ForeColor = Color.Black;
            dgvAircrafts.HeaderForeColor = Color.White;
            dgvAircrafts.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagridAircrafts(string search)
        {
            createTableAircrafts();
            DataSet data = database.getDataFromDatabase("sp_view_aircrafts", null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    AircraftCompanyID = dataRow.Field<string>("AircraftCompanyID"),
                    Company = dataRow.Field<string>("Company"),
                    AircraftTypeID = dataRow.Field<string>("AircraftTypeID"),
                    Type = dataRow.Field<string>("Type")
                }).ToList();

            if(search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(
                    x => x.Name.Contains(search) || 
                    x.Company.Contains(search) || 
                    x.Type.Contains(search)).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                dgvAircrafts.Rows.Add(item.ID,item.Name,item.AircraftCompanyID,item.Company,item.AircraftTypeID,item.Type);
            }
        }
        #endregion
        private void clear()
        {
            cboCompany.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            txtName.Clear();
            isUpdate = true;
            row = null;
            createTableAircraftsDetails();
            clearAircraftDetails();
            enableFrmAircraftDetails(false);
            enableEdittedAircraftDetails(false);
            dgvAircraftAmenities.Rows.Clear();
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "") message = "Ensure you have filled aircraft name";
            else if (dgvAircraftDetails.RowCount <= 0) message = "Ensure you have filled aircraft details";
            else if (isEdittedDetail == true) message = "Ensure does not have process in aircraft details";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            cboCompany.Enabled = value;
            cboType.Enabled = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            isUpdate = value;
            isEdittedAircraft = value;
        }
        #endregion
        #region Aircraft Details
        #region Create Table Aircraft Details
        private void createTableAircraftsDetails()
        {
            dgvAircraftDetails.Rows.Clear();
            dgvAircraftDetails.Columns.Clear();
            dgvAircraftDetails.Columns.Add("id", "ID");
            dgvAircraftDetails.Columns.Add("cabin", "Cabin");
            dgvAircraftDetails.Columns.Add("price", "Price");
            dgvAircraftDetails.Columns.Add("pricecurrency", "Price");
            dgvAircraftDetails.Columns[0].Visible = false;
            dgvAircraftDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAircraftDetails.Columns[2].Visible = false;
            dgvAircraftDetails.ForeColor = Color.Black;
            dgvAircraftDetails.HeaderForeColor = Color.White;
            dgvAircraftDetails.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagridAircraftsDetails(string id)
        {
            createTableAircraftsDetails();
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@AircraftID", id));
            DataSet data = database.getDataFromDatabase("sp_view_aircraftdetails", param);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<int>("ID"),
                    CabinType = dataRow.Field<string>("CabinType"),
                    Price = dataRow.Field<decimal>("Price")
                }).ToList();

            foreach (var item in convertDataSetToList)
            {
                dgvAircraftDetails.Rows.Add(item.ID, item.CabinType, item.Price.ToString().Replace(".0000",""), Convert.ToDouble(item.Price.ToString().Replace(".0000", "")).ToString("N"));
            }
        }
        #endregion
        private bool validationdetail()
        {
            bool result = false;
            if (txtPrice.Value <= 0) message = "Ensure price must greater than 0";
            else if (dgvAircraftAmenities.Rows.Count <= 0) message = "Ensure you have add amenities for this cabin type";
            else if (isEdittedAmenities) message = "Ensure does not have process in amenities";
            else result = true;
            return result;
        }

        private void clearAircraftDetails()
        {
            cboCabinType.SelectedIndex = 0;
            txtPrice.Value = 0;
            isUpdateAircraftDetails = true;
            row2 = null;
            enableFrmAircraftsAmenities(false);
            enableEdittedAircraftsAmenities(false);
            enableFrmAircraftDetails(false);
        }

        private bool validationAircraftDetails()
        {
            bool result = false;
            if (txtPrice.Value <= 0) message = "Ensure price must bigger than 0";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrmAircraftDetails(bool value)
        {
            cboCabinType.Enabled = value;
            txtPrice.Enabled = value;
            btnInsertDetail.Visible = !value;
            btnUpdateDetails.Visible = !value;
            btnDeleteDetails.Visible = !value;
            btnSaveDetails.Visible = value;
            btnCancelDetails.Visible = value;
            isEdittedDetail = value;
        }

        private void enableEdittedAircraftDetails(bool value)
        {
            btnInsertDetail.Enabled = value;
            btnUpdateDetails.Enabled = value;
            btnDeleteDetails.Enabled = value;
        }
        #endregion
        #region Aircraft Amenities
        #region Create Table Aircraft Amenities
        private void createTableAircraftsAmenities()
        {
            dgvAircraftAmenities.Rows.Clear();
            dgvAircraftAmenities.Columns.Clear();
            dgvAircraftAmenities.Columns.Add("id", "ID");
            dgvAircraftAmenities.Columns.Add("amenitiesid", "Amenities ID");
            dgvAircraftAmenities.Columns.Add("amenities", "Amenities");
            dgvAircraftAmenities.Columns[0].Visible = false;
            dgvAircraftAmenities.Columns[1].Visible = false;
            dgvAircraftAmenities.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAircraftAmenities.ForeColor = Color.Black;
            dgvAircraftAmenities.HeaderForeColor = Color.White;
            dgvAircraftAmenities.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagridAircraftsAmenities(string id,string cabintype)
        {
            createTableAircraftsAmenities();
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@AircraftID", id));
            param.Add(new Parameter("@CabinType", cabintype));
            DataSet data = database.getDataFromDatabase("sp_view_aircraftamenities", param);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<int>("ID"),
                    AmenitiesID = dataRow.Field<string>("AmenitiesID"),
                    Amenities = dataRow.Field<string>("Amenities")
                }).ToList();

            foreach (var item in convertDataSetToList)
            {
                AircraftAmenities amenity = amenities.Where(x => x.ID == item.ID).FirstOrDefault();
                if(amenity == null) dgvAircraftAmenities.Rows.Add(item.ID, item.AmenitiesID,item.Amenities);
            }
        }
        #endregion
        private void clearAircraftsAmenities()
        {
            cboAmenities.SelectedIndex = 0;
            row3 = null;
        }

        private bool validationAircraftsAmenities()
        {
            bool result = false;
            DataGridViewRow row = dgvAircraftAmenities.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells[0].Value.ToString() == aircraftamenitiesid[cboAmenities.SelectedIndex].ToString())
                .FirstOrDefault();
            if (row != null) message = "Amenities already exist in this aircraft";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrmAircraftsAmenities(bool value)
        {
            cboAmenities.Enabled = value;
            btnInsertAmenities.Visible = !value;
            btnDeleteAmenities.Visible = !value;
            btnSaveAmenities.Visible = value;
            btnCancelAmenities.Visible = value;
            isEdittedAmenities = value;
        }

        private void enableEdittedAircraftsAmenities(bool value)
        {
            btnInsertAmenities.Enabled = value;
            btnDeleteAmenities.Enabled = value;
        }
        #endregion
        #endregion

        #region Events
        #region Aircraft
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.White, Color.Gray);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
            createTableAircraftsDetails();
            amenities = new List<AircraftAmenities>();
        }

        private void UclAircrafts_Load(object sender, EventArgs e)
        {
            cboCabinType.SelectedIndex = 0;
            refreshDatagridAircrafts("");
            createTableAircraftsAmenities();
            createTableAircraftsDetails();
            DataSet dsCompanies = database.getDataFromDatabase("sp_view_aircraftcompanies", null);
            DataSet dsType = database.getDataFromDatabase("sp_view_aircrafttype", null);
            DataSet dsAmenitites = database.getDataFromDatabase("sp_view_amenities", null);

            cboCompany.DataSource = dsCompanies.Tables[0];
            cboCompany.DisplayMember = "Name";
            cboCompany.ValueMember = "ID";

            for (int i = 0; i < dsType.Tables[0].Rows.Count; i++){
                aircraftTypeid.Add(dsType.Tables[0].Rows[i][0].ToString());
                cboType.Items.Add(dsType.Tables[0].Rows[i][1].ToString() + " (" + dsType.Tables[0].Rows[i][2].ToString() + ")");
            }
            cboType.SelectedIndex = 0;

            for (int i = 0; i < dsAmenitites.Tables[0].Rows.Count; i++)
            {
                aircraftamenitiesid.Add(dsAmenitites.Tables[0].Rows[i][0].ToString());
                cboAmenities.Items.Add(dsAmenitites.Tables[0].Rows[i][1].ToString() + " (" + dsAmenitites.Tables[0].Rows[i][2].ToString() + " " + dsAmenitites.Tables[0].Rows[i][3].ToString() + ")");
            }
            cboAmenities.SelectedIndex = 0;

            clear();
            enableFrm(false);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(true);
            enableEdittedAircraftDetails(true);
            isUpdate = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                enableFrm(true);
                enableEdittedAircraftDetails(true);
            }
        }
        #endregion
        #region Aircraft Details
        private void btnInsertDetail_Click(object sender, EventArgs e)
        {
            clearAircraftDetails();
            enableFrmAircraftDetails(true);
            enableEdittedAircraftsAmenities(true);
            isUpdateAircraftDetails = false;
            createTableAircraftsAmenities();
        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            if (row2 != null)
            {
                enableFrmAircraftDetails(true);
                enableEdittedAircraftsAmenities(true);
            }
            else
                MessageBox.Show("Ensure you have selected detail", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            if (validationdetail())
            {
                string process = "";
                if (!isUpdateAircraftDetails)
                {

                    DataGridViewRow hasDataDetail = dgvAircraftDetails.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == cboCabinType.Text).FirstOrDefault();
                    if (hasDataDetail != null)
                    {
                        MessageBox.Show(cboCabinType.Text + " is exists in database!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AircraftDetails detail = detailTypes.Where(z => z.Cabin.Equals(cboCabinType.Text)).FirstOrDefault();
                    if (detail != null)
                    {
                        detail.Price = Convert.ToDouble(txtPrice.Value);
                        if (detail.ID > 0) detail.Status = 2;
                        else detail.Status = 1;
                        dgvAircraftDetails.Rows.Add(detail.ID, detail.Cabin, detail.Price, Convert.ToDouble(detail.Price).ToString("N"));
                    }
                    else
                    {
                        detailTypes.Add(new AircraftDetails(cboCabinType.Text, Convert.ToDouble(txtPrice.Value), 1));
                        dgvAircraftDetails.Rows.Add("", cboCabinType.Text, Convert.ToDouble(txtPrice.Value), Convert.ToDouble(txtPrice.Value).ToString("N"));
                    }

                    process = "Add";
                }
                else
                {
                    if (row2.Cells[1].Value.ToString() != cboCabinType.Text)
                    {
                        MessageBox.Show("Prohibited from changing cabin type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AircraftDetails detail = detailTypes.Where(z => z.Cabin.Equals(cboCabinType.Text)).FirstOrDefault();
                    if (detail != null)
                    {
                        detail.Price = Convert.ToDouble(txtPrice.Value);
                        detail.Cabin = cboCabinType.Text;
                    }
                    else
                        detailTypes.Add(new AircraftDetails(
                            Convert.ToInt32(row2.Cells[0].Value.ToString()),
                            cboCabinType.Text,
                            Convert.ToDouble(txtPrice.Value), 2));

                    row2.Cells[1].Value = cboCabinType.Text;
                    row2.Cells[2].Value = Convert.ToDouble(txtPrice.Value);
                    row2.Cells[3].Value = Convert.ToDouble(txtPrice.Value).ToString("N");
                    process = "Edit";
                }

                List<AircraftAmenities> aircraftamenities = amenities.Where(z => z.Cabin == "temp").ToList();
                if(aircraftamenities.Count > 0)
                {
                    foreach (AircraftAmenities item in aircraftamenities) item.Cabin = cboCabinType.Text;
                }

                foreach (AircraftAmenities item in amenities) Console.WriteLine("amenities: " + item.Amenities + "; cabin: " + item.Cabin + "; status" + item.Status);


                MessageBox.Show(process + " data has been success", "Information",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAircraftDetails();
                createTableAircraftsAmenities();
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagridAircrafts(txtSearch.Text);
        }

        private void btnCancelDetails_Click(object sender, EventArgs e)
        {
            clearAircraftsAmenities();
            clearAircraftDetails();
            createTableAircraftsAmenities();
            enableFrmAircraftDetails(false);
            List<AircraftAmenities> aircraftamenities = amenities.Where(z => z.Cabin == "temp").ToList();
            if(aircraftamenities.Count() > 0)
            {
                foreach (AircraftAmenities item in aircraftamenities) amenities.Remove(item);
            }
        }

        #endregion
        #region Amenities
        private void btnSaveAmenities_Click(object sender, EventArgs e)
        {
            if (validationAircraftsAmenities())
            {
                string cabin = "temp";
                if (isUpdateAircraftDetails)
                {
                    cabin = cboCabinType.Text;
                }

                DataGridViewRow hasDataAmenities = dgvAircraftAmenities.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == aircraftamenitiesid[cboAmenities.SelectedIndex]).FirstOrDefault();
                if (hasDataAmenities != null)
                {
                    MessageBox.Show(cboAmenities.Text + " already available!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AircraftAmenities aircraftamenities = amenities.Where(z =>
                z.AmenitiesID.Equals(aircraftamenitiesid[cboAmenities.SelectedIndex]) &&
                z.Cabin == cabin && z.Status == 2).FirstOrDefault();
                if (aircraftamenities != null)
                {
                    if (aircraftamenities.ID > 0) aircraftamenities.Status = 1;
                    dgvAircraftAmenities.Rows.Add(aircraftamenities.ID, aircraftamenities.AmenitiesID, aircraftamenities.Amenities);
                }
                else
                {
                    amenities.Add(new AircraftAmenities(aircraftamenitiesid[cboAmenities.SelectedIndex], cboAmenities.Text, cabin, 1));
                    dgvAircraftAmenities.Rows.Add("", aircraftamenitiesid[cboAmenities.SelectedIndex], cboAmenities.Text);
                }
                MessageBox.Show("Add data has been success", "Information",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAircraftsAmenities();
                enableFrmAircraftsAmenities(false);
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDetails_Click(object sender, EventArgs e)
        {
            if (row2 != null)
            {
                if (MessageBox.Show("Are you sure?", "Delete Data",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AircraftDetails item = detailTypes.Where(z => z.Cabin == cboCabinType.Text).FirstOrDefault();
                    if (item != null)
                    {
                        if (item.Status == 2) item.Status = 3;
                    }
                    else
                    {
                        detailTypes.Add(new AircraftDetails(
                            Convert.ToInt32(row2.Cells[0].Value.ToString()),
                            cboCabinType.Text,
                            Convert.ToDouble(txtPrice.Value), 3));
                    }


                    List<Parameter> param2 = new List<Parameter>();
                    param2.Add(new Parameter("@AircraftID", row.Cells[0].Value.ToString()));
                    param2.Add(new Parameter("@CabinType", row2.Cells[1].Value.ToString()));
                    DataSet getAmenitiesFromDatabase = database.getDataFromDatabase("sp_data_aircraftamenities", param2);
                    if(getAmenitiesFromDatabase.Tables.Count > 0)
                    {
                        for(int i = 0; i < getAmenitiesFromDatabase.Tables[0].Rows.Count; i++)
                        {
                            Console.WriteLine(getAmenitiesFromDatabase.Tables[0].Rows[i][0].ToString());
                            amenities.Add(new AircraftAmenities(Convert.ToInt32(getAmenitiesFromDatabase.Tables[0].Rows[i][0].ToString()), getAmenitiesFromDatabase.Tables[0].Rows[i][1].ToString(), getAmenitiesFromDatabase.Tables[0].Rows[i][2].ToString(), row2.Cells[1].Value.ToString(), 2));
                        }
                    }

                    List<AircraftAmenities> deleteAmenities = amenities.Where(x => x.Cabin == row2.Cells[1].Value.ToString() && x.Status != 2).ToList();
                    Console.WriteLine("Count: " + deleteAmenities.Count);
                    foreach (AircraftAmenities x in deleteAmenities) x.Status = 2;
                    List<AircraftAmenities> deletedAmenities = amenities.Where(x => x.Cabin == row2.Cells[1].Value.ToString() && x.Status == 2).ToList();
                    foreach (AircraftAmenities x in deletedAmenities) Console.WriteLine("amenities: " + x.Amenities + "; cabin: " + x.Cabin);
                    dgvAircraftDetails.Rows.Remove(row2);
                    createTableAircraftsAmenities();
                    MessageBox.Show("Delete data has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAircraftDetails();
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected detail", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = "";
            if (validation())
            {
                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    id = database.autoGenerateID("A", "sp_last_aircraft", 5);
                    param.Add(new Parameter("@ID", id));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@AircraftCompany", cboCompany.SelectedValue.ToString()));
                    param.Add(new Parameter("@AircraftTypeID", aircraftTypeid[cboType.SelectedIndex]));
                    param.Add(new Parameter("@Status", "A"));
                    x = database.executeQuery("sp_insert_aircraft", param, "Add");
                    process = "Add";
                }
                else
                {
                    id = row.Cells[0].Value.ToString();
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", id));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@AircraftCompany", cboCompany.SelectedValue.ToString()));
                    param.Add(new Parameter("@AircraftTypeID", aircraftTypeid[cboType.SelectedIndex]));
                    x = database.executeQuery("sp_update_aircraft", param, "Update");
                    process = "Update";
                }

                if (x == 1)
                {
                    foreach (AircraftAmenities item in amenities)
                    {
                        List<Parameter> param2 = new List<Parameter>();
                        int y = 0;
                        if (item.Status == 2)
                        {
                            if(item.ID > 0)
                            {
                                param2.Add(new Parameter("@ID", item.ID.ToString()));
                                y = database.executeQuery("sp_delete_aircraftamenities", param2, "Delete");
                            }
                        }
                        else
                        {
                            param2.Add(new Parameter("@AmenitiesID", item.AmenitiesID));
                            param2.Add(new Parameter("@CabinType", item.Cabin));
                            param2.Add(new Parameter("@AircraftID", id));
                            y = database.executeQuery("sp_insert_aircraftamenities", param2, "Add");
                        }
                    }

                    foreach (AircraftDetails item in detailTypes)
                    {
                         List<Parameter> param2 = new List<Parameter>();
                        int y = 0;
                        if (item.Status == 2)
                        {
                            param2.Add(new Parameter("@ID", item.ID.ToString()));
                            param2.Add(new Parameter("@CabinType", item.Cabin));
                            param2.Add(new Parameter("@Price", item.Price.ToString()));
                            y = database.executeQuery("sp_update_aircraftdetail", param2, "Update");
                        }
                        else if (item.Status == 1)
                        {
                            param2.Add(new Parameter("@AircraftID", id));
                            param2.Add(new Parameter("@CabinType", item.Cabin));
                            param2.Add(new Parameter("@Price", item.Price.ToString()));
                            y = database.executeQuery("sp_insert_aircraftdetail", param2, "Add");
                        }
                        else
                        {
                            param2.Add(new Parameter("@ID", item.ID.ToString()));
                            y = database.executeQuery("sp_delete_aircraftdetail", param2, "Delete");
                        }
                    }

                    MessageBox.Show(process + " data has been success", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    enableFrm(false);
                    refreshDatagridAircrafts(txtSearch.Text);
                }
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                if (MessageBox.Show("Are you sure?", "Delete Data",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    int x = database.executeQuery("sp_delete_aircraft", param, "Delete");
                    if (x == 1)
                    {
                        MessageBox.Show("Delete data has been success", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableFrm(false);
                        refreshDatagridAircrafts(txtSearch.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected aircraft type", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == (int)Keys.Back)
            {
                SendKeys.Send("{ENTER}");
                txtPrice.Select();
                SendKeys.Send("{END}");
            }
        }

        private void dgvAircraftDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!isEdittedDetail && isUpdateAircraftDetails)
            {
                row2 = dgvAircraftDetails.CurrentRow;
                if (row != null) refreshDatagridAircraftsAmenities(row.Cells[0].Value.ToString(), row2.Cells[1].Value.ToString());
                cboCabinType.Text = row2.Cells[1].Value.ToString();
                txtPrice.Value = Convert.ToDecimal(row2.Cells[2].Value.ToString());
                if (amenities.Count > 0)
                {
                    foreach (AircraftAmenities item in amenities.Where(x=>x.Status == 1 && x.Cabin == row2.Cells[1].Value.ToString()))
                    {
                        DataGridViewRow amenitieRow = dgvAircraftAmenities.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == item.AmenitiesID).FirstOrDefault();
                        if (amenitieRow == null) dgvAircraftAmenities.Rows.Add("", item.AmenitiesID, item.Amenities);
                    }
                }
            }
        }

        private void dgvAircrafts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!isEdittedAircraft)
            {
                row = dgvAircrafts.CurrentRow;
                refreshDatagridAircraftsDetails(row.Cells[0].Value.ToString());
                txtName.Text = row.Cells[1].Value.ToString();
                cboCompany.SelectedValue = row.Cells[2].Value.ToString();
                cboType.SelectedValue = aircraftTypeid.FindIndex(x => x == row.Cells[4].Value.ToString());
            }
        }

        private void btnInsertAmenities_Click(object sender, EventArgs e)
        {
            clearAircraftsAmenities();
            enableFrmAircraftsAmenities(true);
        }

        private void btnCancelAmenities_Click(object sender, EventArgs e)
        {
            clearAircraftsAmenities();
            enableFrmAircraftsAmenities(false);
        }

        private void btnDeleteAmenities_Click(object sender, EventArgs e)
        {
            if (row3 != null)
            {
               if(MessageBox.Show("Are you sure?","Delete Amenities",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AircraftAmenities aircraftamenities = amenities.Where(z => z.Cabin == "temp" && z.AmenitiesID == aircraftamenitiesid[cboAmenities.SelectedIndex]).FirstOrDefault();
                    AircraftAmenities aircraftamenities2 = amenities.Where(z => z.Cabin == cboCabinType.Text && z.AmenitiesID == aircraftamenitiesid[cboAmenities.SelectedIndex]).FirstOrDefault();
                    if (aircraftamenities != null) amenities.Remove(aircraftamenities);
                    else if (aircraftamenities2 != null) aircraftamenities2.Status = 2;
                    else
                    {
                        amenities.Add(new AircraftAmenities(Convert.ToInt32(row3.Cells[0].Value.ToString()), row3.Cells[1].Value.ToString(), row3.Cells[2].Value.ToString(), row2.Cells[1].Value.ToString(), 2));
                    }
                    dgvAircraftAmenities.Rows.Remove(row3);
                    clearAircraftsAmenities();
                    MessageBox.Show("Delete amenities has been success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Ensure you have selected amenities", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvAircraftAmenities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isEdittedAmenities)
            {
                row3 = dgvAircraftAmenities.CurrentRow;
                cboAmenities.SelectedIndex = aircraftamenitiesid.FindIndex(x => x.Equals(row3.Cells[1].Value.ToString()));
            }
        }
        #endregion
        #endregion
    }
}
