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
    public partial class UclSeat : UserControl
    {
        #region declaration
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private string message = "";
        private bool isUpdate = false, isEnable = false;
        #endregion

        #region Constructor
        public UclSeat()
        {
            InitializeComponent();
        }
        #endregion

        #region method
        // back to default
        private void clear()
        {
            txtLeft.Value = 0;
            txtMid.Value = 0;
            txtRight.Value = 0;
            isUpdate = true;
            row = null;
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtMid.Enabled = value;
            txtLeft.Enabled = value;
            txtRight.Enabled = value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            isEnable = value;
        }

        private void createTable()
        {
            DgvSeatType.Rows.Clear();
            DgvSeatType.Columns.Clear();
            DgvSeatType.Columns.Add("id", "ID");
            DgvSeatType.Columns.Add("name", "Name");
            DgvSeatType.Columns.Add("left", "Left");
            DgvSeatType.Columns.Add("mid", "Mid");
            DgvSeatType.Columns.Add("right", "Right");
            DgvSeatType.Columns[0].Visible = false;
            DgvSeatType.Columns[1].Visible = false;
            DgvSeatType.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvSeatType.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvSeatType.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void refreshDatagrid()
        {
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_seattype", null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Left = dataRow.Field<int>("Left"),
                    Mid = dataRow.Field<int>("Mid"),
                    Right = dataRow.Field<int>("Right"),
                    Status = dataRow.Field<string>("status")
                }).ToList();

            foreach (var item in convertDataSetToList)
            {
                if (item.Status == "A")
                {
                    DgvSeatType.Rows.Add(item.ID, item.Name,item.Left,item.Mid,item.Right);
                }
            }
        }

        private bool validation()
        {
            bool result = false;
            if (txtLeft.Value <= 0 && txtMid.Value <= 0 && txtRight.Value <= 0)
                message = "Ensure you have filled all fields";
            else if (
                (txtLeft.Value > 0 && txtMid.Value > 0 && txtRight.Value <= 0) ||
                (txtLeft.Value <= 0 && txtMid.Value > 0 && txtRight.Value > 0) ||
                (txtLeft.Value > 0 && txtMid.Value <= 0 && txtRight.Value <= 0) ||
                (txtLeft.Value <= 0 && txtMid.Value <= 0 && txtRight.Value > 0))
                message = "Ensure format seat must correct";
            else if (txtLeft.Value + txtMid.Value + txtRight.Value > 8) message = "Invalid count seat";
            else if (txtLeft.Value != txtRight.Value) message = "Ensure left seat must same with right seat";
            else if (txtMid.Value == 1) message = "Ensure mid must bigger than now";
            else result = true;
            return result;
        }
        #endregion

        #region Events
        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isUpdate = false;
            enableFrm(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                isUpdate = true;
                enableFrm(true);
            }
            else
            {
                MessageBox.Show("Ensure you have selected seat type", "Warning",
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
                    int x = database.executeQuery("sp_delete_seattype", param, "Delete");
                    if (x == 1)
                    {
                        MessageBox.Show("Delete data has been success", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableFrm(false);
                        refreshDatagrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected seat type", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                DataSet data = database.getDataFromDatabase("sp_view_seattype", null);
                var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                    dataRow => new {
                        ID = dataRow.Field<string>("ID"),
                        Name = dataRow.Field<string>("Name"),
                        Left = dataRow.Field<int>("Left"),
                        Mid = dataRow.Field<int>("Mid"),
                        Right = dataRow.Field<int>("Right"),
                        Status = dataRow.Field<string>("status")
                    }).ToList();

                List<string> name = new List<string>();
                if (txtLeft.Value > 0)
                    name.Add("Left " + txtLeft.Value);
                if (txtMid.Value > 0)
                    name.Add("Mid " + txtMid.Value);
                if (txtRight.Value > 0)
                    name.Add("Right " + txtRight.Value);

                string realName = String.Join(" ", name);
                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    if (DgvSeatType.Rows.Cast<DataGridViewRow>().Where(z =>
                    z.Cells[2].Value.ToString() == txtLeft.Value.ToString() &&
                    z.Cells[3].Value.ToString() == txtMid.Value.ToString() &&
                    z.Cells[4].Value.ToString() == txtRight.Value.ToString()).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Seat type already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var seatType = convertDataSetToList.Where(z => z.Name.Equals(realName)).FirstOrDefault();
                    if(seatType != null)
                    {
                        if(seatType.Status == "A")
                        {
                            MessageBox.Show("Seat type already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            List<Parameter> param2 = new List<Parameter>();
                            param2.Add(new Parameter("@ID", seatType.ID));
                            x = database.executeQuery("sp_insert_seattype2", param2, "Add");
                            process = "Add";
                        }
                    }
                    else
                    {
                        DataGridViewRow row2 = DgvSeatType.Rows.Cast<DataGridViewRow>().Where(z =>
                    z.Cells[2].Value.ToString().Equals(txtLeft.Value) &&
                    z.Cells[3].Value.ToString().Equals(txtMid.Value) &&
                    z.Cells[4].Value.ToString().Equals(txtRight.Value)).FirstOrDefault();
                        if (row2 != null)
                        {
                            Console.WriteLine("Ada");
                            if (row != row2)
                            {
                                MessageBox.Show("Amenity already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", database.autoGenerateID("S", "sp_last_seattype", 5)));
                        param.Add(new Parameter("@Name", realName));
                        param.Add(new Parameter("@Left", txtLeft.Value.ToString()));
                        param.Add(new Parameter("@Mid", txtMid.Value.ToString()));
                        param.Add(new Parameter("@Right", txtRight.Value.ToString()));
                        param.Add(new Parameter("@Status", "A"));
                        x = database.executeQuery("sp_insert_seattype", param, "Add");
                        process = "Add";
                    }
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@Name", realName));
                    param.Add(new Parameter("@Left", txtLeft.Value.ToString()));
                    param.Add(new Parameter("@Mid", txtMid.Value.ToString()));
                    param.Add(new Parameter("@Right", txtRight.Value.ToString()));
                    x = database.executeQuery("sp_update_seattype", param, "Update");
                    process = "Update";
                }

                if (x == 1)
                {
                    MessageBox.Show(process + " data has been success", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    enableFrm(false);
                    refreshDatagrid();
                }
            }
            else
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvSeatType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isUpdate && !isEnable && DgvSeatType.RowCount > 0)
                {
                    row = DgvSeatType.CurrentRow;
                    txtLeft.Value = Convert.ToInt32(row.Cells[2].Value.ToString());
                    txtMid.Value = Convert.ToInt32(row.Cells[3].Value.ToString());
                    txtRight.Value = Convert.ToInt32(row.Cells[4].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void UclSeat_Load(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
            refreshDatagrid();
        }
        #endregion
    }
}
