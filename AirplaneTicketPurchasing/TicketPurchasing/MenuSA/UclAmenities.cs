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
    public partial class UclAmenities : UserControl
    {
        #region declaration
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private string message = "";
        private bool isUpdate = false,isEnable = false;
        #endregion

        #region Constructor
        public UclAmenities()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void UclAmenities_Load(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
            refreshDatagrid("");
        }

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
                MessageBox.Show("Ensure you have selected a amenity", "Warning",
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
                    int x = database.executeQuery("sp_delete_amenities", param, "Delete");
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
                MessageBox.Show("Ensure you have selected a amenity", "Warning",
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
                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    if (DgvAmenities.Rows.Cast<DataGridViewRow>().Where(z =>
                        z.Cells[1].Value.ToString() == txtName.Text &&
                        z.Cells[2].Value.ToString() == txtQty.Value.ToString()).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Amenity already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("A", "sp_last_amenities", 5)));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Qty", txtQty.Value.ToString()));
                    param.Add(new Parameter("@Unit", cboUnit.Text.ToString()));
                    param.Add(new Parameter("@Status", "A"));
                    x = database.executeQuery("sp_insert_amenities", param, "Add");
                    process = "Add";
                }
                else
                {
                    DataGridViewRow row2 = DgvAmenities.Rows.Cast<DataGridViewRow>().Where(z =>
                        z.Cells[1].Value.ToString() == txtName.Text &&
                        z.Cells[2].Value.ToString() == txtQty.Value.ToString()).FirstOrDefault();

                    if (row2 != null)
                    {
                        if(row != row2)
                        {
                            MessageBox.Show("Amenity already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Qty", txtQty.Value.ToString()));
                    param.Add(new Parameter("@Unit", cboUnit.Text.ToString()));
                    x = database.executeQuery("sp_update_amenities", param, "Update");
                    process = "Update";
                }

                if (x == 1)
                {
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

        private void DgvAmenities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isUpdate && !isEnable && DgvAmenities.RowCount > 0)
                {
                    row = DgvAmenities.CurrentRow;
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtQty.Value = Convert.ToInt32(row.Cells[2].Value.ToString());
                    cboUnit.SelectedItem = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagrid(txtSearch.Text);
        }


        #endregion

        #region method
        // back to default
        private void clear()
        {
            cboUnit.SelectedIndex = 0;
            txtName.Clear();
            txtQty.Value = 0;
            isUpdate = true;
            row = null;
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            txtQty.Enabled = value;
            cboUnit.Enabled = value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            isEnable = value;
        }

        private void createTable()
        {
            DgvAmenities.Rows.Clear();
            DgvAmenities.Columns.Clear();
            DgvAmenities.Columns.Add("id", "ID");
            DgvAmenities.Columns.Add("name", "Name");
            DgvAmenities.Columns.Add("qty", "Qty");
            DgvAmenities.Columns.Add("unit", "Unit");
            DgvAmenities.Columns[0].Visible = false;
            DgvAmenities.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvAmenities.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void refreshDatagrid(string search)
        {
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_amenities",null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Qty = dataRow.Field<int>("Qty"),
                    Unit = dataRow.Field<string>("Unit")
                }).ToList();

            // search
            if(search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(z =>
                    z.Name.ToLower().Contains(search.ToLower()) || z.Qty.ToString().ToLower().Contains(search.ToLower()) || 
                    z.Unit.ToLower().Contains(search.ToLower())
                ).ToList();
            }

            foreach(var item in convertDataSetToList)
            {
                DgvAmenities.Rows.Add(item.ID, item.Name, item.Qty, item.Unit);
            }
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "" || txtQty.Value == 0) message = "Ensure you have filled all fields";
            else if (!valid.regexAlphaNumberic(txtName.Text)) message = "Ensure name must alpha numberic";
            else if (txtQty.Value < 0) message = "Ensure qty must bigger than now";
            else result = true;
            return result;
        }
        #endregion
    }
}
