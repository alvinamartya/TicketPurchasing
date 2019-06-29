using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing.MenuSA
{
    public partial class UclAircraftTypes : UserControl
    {
        #region Declaration
        private DataGridViewRow row = null, row2 = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private string message = "";
        private bool isUpdate = false, isUpdateDetail = false, isDetail = false, isEnable = false;
        private List<AircraftType> listAircraftTypes = new List<AircraftType>();
        #endregion
        #region Constructor
        public UclAircraftTypes()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        #region General

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isUpdate = false;
            enableFrm(true);
            enableFrmDetail2(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                isUpdate = true;
                enableFrm(true);
                enableFrmDetail2(true);
            }
            else
            {
                MessageBox.Show("Ensure you have selected aircraft type", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    int x = database.executeQuery("sp_delete_aircrafttypes", param, "Delete");
                    if (x == 1)
                    {
                        MessageBox.Show("Delete data has been success", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableFrm(false);
                        refreshDatagrid(txtSearch.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected aircraft type", "Warning",
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
                    id = database.autoGenerateID("T", "sp_last_aircrafttypes", 5);
                    param.Add(new Parameter("@ID", id));
                    param.Add(new Parameter("@Name",txtName.Text));
                    param.Add(new Parameter("@MakeModel", txtMakeModel.Text));
                    param.Add(new Parameter("@TotalSeats", txtTotalSeat.Text));
                    param.Add(new Parameter("@Status", "A"));
                    x = database.executeQuery("sp_insert_aircrafttypes", param, "Add");
                    process = "Add";
                }
                else
                {
                    id = row.Cells[0].Value.ToString();
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", id));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@MakeModel", txtMakeModel.Text));
                    param.Add(new Parameter("@TotalSeats", txtTotalSeat.Text));
                    x = database.executeQuery("sp_update_aircrafttypes", param, "Update");
                    process = "Update";
                }

                if (x == 1)
                {
                    foreach (AircraftType item in listAircraftTypes)
                    {
                        List<Parameter> param2 = new List<Parameter>();
                        int y = 0;
                        if (item.Status == 2)
                        {
                            param2.Add(new Parameter("@ID", item.ID.ToString()));
                            param2.Add(new Parameter("@Seat", item.Seat.ToString()));
                            param2.Add(new Parameter("@SeatTypeID", item.SeatTypeID));
                            y = database.executeQuery("sp_update_aircrafttypedetails", param2, "Update");
                        }
                        else if(item.Status == 1)
                        {
                            param2.Add(new Parameter("@Seat", item.Seat.ToString()));
                            param2.Add(new Parameter("@CabinType", item.Cabin));
                            param2.Add(new Parameter("@AircraftTypeID", id));
                            param2.Add(new Parameter("@SeatTypeID", item.SeatTypeID));
                            y = database.executeQuery("sp_insert_aircrafttypedetails", param2, "Add");
                        }
                        else
                        {
                            param2.Add(new Parameter("@ID", item.ID.ToString()));
                            y = database.executeQuery("sp_delete_aircrafttypedetails", param2, "Delete");
                        }
                    }

                    MessageBox.Show(process + " data has been success", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    enableFrm(false);
                    refreshDatagrid(txtSearch.Text);
                }
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isDetail == false)
            {
                clear();
                clearDetail();
                enableFrm(false);
                enableFrmDetail2(false);
                enableFrmDetail(false);
            }
            else
                MessageBox.Show("Ensure you have finished add/update detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.White, Color.Gray);
        }

        private void UclAircraftTypes_Load(object sender, EventArgs e)
        {
            clear();
            createTableDetails();
            refreshDatagrid("");
            enableFrm(false);
            enableFrmDetail(false);
            enableFrmDetail2(false);
            cboCabinType.SelectedIndex = 0;
            DataSet getDataSeatType = database.getDataFromDatabase("sp_view_seattype_Cmb", null);
            cboSeatType.DataSource = getDataSeatType.Tables[0];
            cboSeatType.ValueMember = "ID";
            cboSeatType.DisplayMember = "Name";
        }
        #endregion
        #region Detail
        private void btnInsertDetail_Click(object sender, EventArgs e)
        {
            clearDetail();
            isUpdateDetail = false;
            enableFrmDetail(true);
        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            if(row2 != null)
            {
                isUpdateDetail = true;
                enableFrmDetail(true);
            }
            else
            {
                MessageBox.Show("Ensure you have selected detail", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (row2 != null)
            {
                if (MessageBox.Show("Are you sure?", "Delete Data",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int x = 0;
                    AircraftType item = listAircraftTypes.Where(z => z.Cabin == cboCabinType.Text).FirstOrDefault();
                    if(item != null)
                    {
                        if (item.Status == 2) item.Status = 3;
                    }
                    else
                    {
                        listAircraftTypes.Add(new AircraftType(
                            Convert.ToInt32(row2.Cells[0].Value.ToString()),
                            cboCabinType.Text,
                            Convert.ToInt32(txtSeat.Value), cboSeatType.SelectedValue.ToString(), cboSeatType.Text ,3));
                    }
                    DgvAircraftTypeDetail.Rows.Remove(row2);
                    MessageBox.Show("Delete data has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearDetail();
                    calculateSeat();
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected detail", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (validationdetail())
            {
                string process = "";
                if (!isUpdateDetail)
                {
                    DataGridViewRow hasDataDetail = DgvAircraftTypeDetail.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == cboCabinType.Text).FirstOrDefault();
                    if(hasDataDetail != null)
                    {
                        MessageBox.Show(cboCabinType.Text + " is exists in database!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AircraftType aircrafttype = listAircraftTypes.Where(z => z.Cabin.Equals(cboCabinType.Text)).FirstOrDefault();
                    if(aircrafttype != null)
                    {
                        aircrafttype.Seat = Convert.ToInt32(txtSeat.Value);
                        if (aircrafttype.ID > 0) aircrafttype.Status = 2;
                        else aircrafttype.Status = 1;
                        DgvAircraftTypeDetail.Rows.Add(aircrafttype.ID, aircrafttype.Cabin, aircrafttype.SeatTypeID, aircrafttype.SeatType, aircrafttype.Seat);
                    }
                    else
                    {
                        listAircraftTypes.Add(new AircraftType(cboCabinType.Text, Convert.ToInt32(txtSeat.Value),cboSeatType.SelectedValue.ToString(),cboSeatType.Text, 1));
                        DgvAircraftTypeDetail.Rows.Add("", cboCabinType.Text, cboSeatType.SelectedValue.ToString(),cboSeatType.Text, Convert.ToInt32(txtSeat.Value));
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

                    AircraftType aircrafttype = listAircraftTypes.Where(z => z.Cabin.Equals(cboCabinType.Text)).FirstOrDefault();
                    if(aircrafttype != null)
                    {
                        aircrafttype.Seat = Convert.ToInt32(txtSeat.Value);
                        aircrafttype.Cabin = cboCabinType.Text;
                        aircrafttype.SeatTypeID = cboSeatType.SelectedValue.ToString();
                    }
                    else
                        listAircraftTypes.Add(new AircraftType(
                            Convert.ToInt32(row2.Cells[0].Value.ToString()),
                            cboCabinType.Text, 
                            Convert.ToInt32(txtSeat.Value),cboSeatType.SelectedValue.ToString(), cboSeatType.Text, 2));
                    
                    row2.Cells[1].Value = cboCabinType.Text;
                    row2.Cells[2].Value = cboSeatType.SelectedValue.ToString();
                    row2.Cells[3].Value = cboSeatType.Text;
                    row2.Cells[4].Value = Convert.ToInt32(txtSeat.Value);
                    process = "Edit";
                }

                MessageBox.Show(process + " data has been success", "Information",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearDetail();
                enableFrmDetail(false);
                calculateSeat();
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCancelDetail_Click(object sender, EventArgs e)
        {
            clearDetail();
            enableFrmDetail(false);
        }
        #endregion
        #endregion
        #region Method
        #region General
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

        // back to default
        private void clear()
        {
            txtName.Clear();
            txtMakeModel.Clear();
            txtTotalSeat.Text = 0.ToString();
            isUpdate = true;
            row = null;
            listAircraftTypes = new List<AircraftType>();
            createTableDetails();
            enableFrmDetail2(false);
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "" || txtMakeModel.Text == "" ||
                txtTotalSeat.Text == "" || txtTotalSeat.Text == 0.ToString()) message = "Ensure you have filled all fields";
            else if (isDetail == true) message = "Ensure you have finished add/update detail";
            else if (DgvAircraftTypeDetail.RowCount == 0) message = "Ensure you have added cabin type";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            txtMakeModel.Enabled = value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            isEnable = value;
        }

        private void createTable()
        {
            DgvAircraftType.Rows.Clear();
            DgvAircraftType.Columns.Clear();
            DgvAircraftType.Columns.Add("id", "ID");
            DgvAircraftType.Columns.Add("name", "Name");
            DgvAircraftType.Columns.Add("makemode", "Make Model");
            DgvAircraftType.Columns.Add("totalseats", "Total Seat");
            DgvAircraftType.Columns[0].Visible = false;
            DgvAircraftType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvAircraftType.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvAircraftType.ForeColor = Color.Black;
            DgvAircraftType.HeaderForeColor = Color.White;
            DgvAircraftType.HeaderBgColor = Color.Teal;
        }


        private void refreshDatagrid(string search)
        {
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_aircrafttype",null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    MakeModel = dataRow.Field<string>("MakeModel"),
                    TotalSeat = dataRow.Field<int>("Totalseats")
                }).ToList();

            // search
            if (search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(z =>
                    z.Name.ToLower().Contains(search.ToLower()) || z.MakeModel.ToLower().Contains(search.ToLower()) ||
                    z.TotalSeat.ToString().ToLower().Contains(search.ToLower())
                ).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                DgvAircraftType.Rows.Add(item.ID, item.Name, item.MakeModel, item.TotalSeat);
            }
        }
        #endregion
        #region Detail

        private void calculateSeat()
        {
            int totalSeat = 0;
            foreach(DataGridViewRow itemRow in DgvAircraftTypeDetail.Rows.Cast<DataGridViewRow>().ToList())
            {
                totalSeat = totalSeat + Convert.ToInt32(itemRow.Cells[4].Value.ToString());
            }
            txtTotalSeat.Text = totalSeat.ToString();
        }

        private void clearDetail()
        {
            try
            {
                cboCabinType.SelectedIndex = 0;
                cboSeatType.SelectedIndex = 0;
                txtSeat.Value = 0;
                isUpdateDetail = true;
                row2 = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validationdetail()
        {
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@ID", cboSeatType.SelectedValue.ToString()));
            DataSet getSingleDataSeatType = database.getDataFromDatabase("sp_view_seattype_single", param);
            int maxseatincol = Convert.ToInt32(getSingleDataSeatType.Tables[0].Rows[0][0]);

            bool result = false;
            if (txtSeat.Value <= 0) message = "Ensure seat must bigger than now";
            else if (txtSeat.Value % maxseatincol != 0) message = "Ensure total seat must correct";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrmDetail(bool value)
        {
            cboCabinType.Enabled = value;
            cboSeatType.Enabled = value;
            txtSeat.Enabled = value;
            btnInsertDetail.Visible = !value;
            btnUpdateDetail.Visible = !value;
            btnDeleteDetail.Visible = !value;
            btnSaveDetail.Visible = value;
            btnCancelDetail.Visible = value;
            isDetail = value;
        }

        private void DgvAircraftTypeDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!isDetail && DgvAircraftTypeDetail.RowCount > 0)
                {
                    row2 = DgvAircraftTypeDetail.CurrentRow;
                    cboCabinType.Text = row2.Cells[1].Value.ToString();
                    cboSeatType.SelectedValue = row2.Cells[2].Value.ToString();
                    txtSeat.Value = Convert.ToInt32(row2.Cells[4].Value.ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DgvAircraftType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isUpdate && !isDetail && !isEnable && DgvAircraftType.RowCount > 0)
                {
                    clearDetail();
                    row = DgvAircraftType.CurrentRow;
                    refreshDatagridDetails(row.Cells[0].Value.ToString());
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtMakeModel.Text = row.Cells[2].Value.ToString();
                    txtTotalSeat.Text = row.Cells[3].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtSeat_MouseUp(object sender, MouseEventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(txtSeat, "Message");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagrid(txtSearch.Text);
        }

        private void enableFrmDetail2(bool value)
        {
            btnInsertDetail.Enabled = value;
            btnUpdateDetail.Enabled = value;
            btnDeleteDetail.Enabled = value;
        }

        private void createTableDetails()
        {
            DgvAircraftTypeDetail.Rows.Clear();
            DgvAircraftTypeDetail.Columns.Clear();
            DgvAircraftTypeDetail.Columns.Add("id", "ID");
            DgvAircraftTypeDetail.Columns.Add("cabintype", "Cabin Type");
            DgvAircraftTypeDetail.Columns.Add("seattypeid", "SeatTypeID");
            DgvAircraftTypeDetail.Columns.Add("seattype", "SeatType");
            DgvAircraftTypeDetail.Columns.Add("seat", "Seat");
            DgvAircraftTypeDetail.Columns[0].Visible = false;
            DgvAircraftTypeDetail.Columns[2].Visible = false;
            DgvAircraftTypeDetail.ForeColor = Color.Black;
            DgvAircraftTypeDetail.HeaderForeColor = Color.White;
            DgvAircraftTypeDetail.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagridDetails(string id)
        {
            createTableDetails();
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@AircraftTypeID", id));
            DataSet data = database.getDataFromDatabase("sp_view_aircrafttypedetails", param);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<int>("ID"),
                    Seat = dataRow.Field<int>("Seat"),
                    CabinType = dataRow.Field<string>("CabinType"),
                    SeatTypeID = dataRow.Field<string>("seattypeID"),
                    SeatType = dataRow.Field<string>("SeatType")
                }).ToList();

            foreach (var item in convertDataSetToList)
            {
                DgvAircraftTypeDetail.Rows.Add(item.ID, item.CabinType,item.SeatTypeID,item.SeatType,item.Seat);
            }
        }
        #endregion
        #endregion
    }
}
