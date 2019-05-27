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

namespace TicketPurchasing.MenuSA
{
    public partial class UclCities : UserControl
    {

        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private string message = "";
        private bool isUpdate = false, isInserting = false, isEnable = false;

        public UclCities()
        {
            InitializeComponent();
            refreshDatagrid(txtSearch.Text);
            enableFrm(false);
        }

        private void clear()
        {
            cbCountry.SelectedItem = null;
            txtName.Text = null;
            txtSearch.Text = null;
            isUpdate = false;
            if (isInserting) isInserting = false;
        }

        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            cbCountry.Enabled = value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            isEnable = value;
        }

        private void createTable()
        {
            DgvCities.Rows.Clear();
            DgvCities.Columns.Clear();
            DgvCities.Columns.Add("id", "ID");
            DgvCities.Columns.Add("name", "Name");
            DgvCities.Columns.Add("country", "Country");
            DgvCities.Columns[0].Visible = false;
            DgvCities.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCities.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCities.HeaderBgColor = Color.Teal;
            DgvCities.HeaderForeColor = Color.White;
        }

        private void refreshDatagrid(string s)
        {
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_cities", null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Country = dataRow.Field<string>("Country")
                }).ToList();
            if (s != null)
            {
                convertDataSetToList = convertDataSetToList.Where(z =>
                z.ID.ToLower().Contains(s.ToLower())||
                z.Name.ToLower().Contains(s.ToLower())||
                z.Country.ToLower().Contains(s.ToLower())).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                DgvCities.Rows.Add(item.ID, item.Name, item.Country);
            }
        }

        private bool validation()
        {
            return cbCountry.SelectedItem != null && txtName.Text != null;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isInserting = true;
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
                MessageBox.Show("Ensure you have selected cities", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = DgvCities.CurrentRow;
            if (!isUpdate&&!isInserting)
            {
                txtName.Text = row.Cells[1].Value.ToString();
                cbCountry.Text = row.Cells[2].Value.ToString();
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
                    int x = database.executeQuery("sp_delete_cities", param, "Delete");
                    if (x == 1)
                    {
                        MessageBox.Show("Data deleted successfully", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableFrm(false);
                        refreshDatagrid(txtSearch.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ensure you have selected cities", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshDatagrid(txtSearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                int x = 0;
                string proc = "";
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("C", "sp_last_cities", 5)));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Country", cbCountry.SelectedItem.ToString()));
                    x = database.executeQuery("sp_insert_cities", param, "Add");
                    proc = "Added";
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Country", cbCountry.SelectedItem.ToString()));
                    x = database.executeQuery("sp_update_cities", param, "Update");
                    proc = "Updated";
                }

                if (x == 1)
                {
                    MessageBox.Show("Data "+proc+" Successfully", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    enableFrm(false);
                    refreshDatagrid(txtSearch.Text);
                }
            }else
            {
                MessageBox.Show("Please fill all required field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
