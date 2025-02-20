﻿using System;
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
    public partial class UclCustomer : UserControl
    {
        Support support = new Support();
        private DataGridViewRow row = null;
        private Database database = new Database();
        bool isUpdate = false;
        bool isEditted = false;
        private string message = "";
        private Validation valid = new Validation();

        public UclCustomer()
        {
            InitializeComponent();
            createTable();
            refreshDatagrid(txtSearch.Text);
        }

        private void clear()
        {
            isUpdate = false;
            txtName.Clear();
            txtIdentity.Clear();
            txtPassport.Clear();
            cbCountry.SelectedIndex = 0;
            rbFemale.Checked = false;
            rbMale.Checked = false;
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
            txtDate.Value = DateTime.Now;
            row = null;
        }

        private void enableFrm(bool value)
        {
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            txtName.Enabled = value;
            txtIdentity.Enabled = value;
            txtPassport.Enabled = value;
            cbCountry.Enabled = value;
            txtDate.Enabled = value;
            rbFemale.Enabled = value;
            rbMale.Enabled = value;
            txtPhone.Enabled = value;
            txtEmail.Enabled = value;
            txtAddress.Enabled = value;
            isEditted = value;
        }

        private void createTable()
        {
            dgvCustomers.Rows.Clear();
            dgvCustomers.Columns.Clear();
            dgvCustomers.Columns.Add("id", "ID");
            dgvCustomers.Columns.Add("name", "Name");
            dgvCustomers.Columns.Add("identityNumber", "Identity Number");
            dgvCustomers.Columns.Add("passport", "Passport");
            dgvCustomers.Columns.Add("dob", "Brith Date");
            dgvCustomers.Columns.Add("sex", "Sex");
            dgvCustomers.Columns.Add("address", "Address");
            dgvCustomers.Columns.Add("telp", "Phone Number");
            dgvCustomers.Columns.Add("email", "Email");
            dgvCustomers.Columns.Add("country", "Country");
            dgvCustomers.Columns[0].Visible = false;
            dgvCustomers.HeaderBgColor = Color.Teal;
            dgvCustomers.HeaderForeColor = Color.White;
        }

        private void refreshDatagrid(string search)
        {
            dgvCustomers.Rows.Clear();
            DataSet data = database.getDataFromDatabase("sp_view_customers", null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    identityNumber = dataRow.Field<string>("IdentityNumber"),
                    passport = dataRow.Field<string>("PassportNumber"),
                    dob = dataRow.Field<DateTime>("DateofBirth"),
                    sex = dataRow.Field<string>("Sex"),
                    address = dataRow.Field<string>("Address"),
                    telp = dataRow.Field<string>("TelpNumber"),
                    email = dataRow.Field<string>("Email"),
                    country = dataRow.Field<string>("Country")
                }).ToList();
            if (search != null)
            {
                convertDataSetToList = convertDataSetToList.Where(x => x.Name.Contains(search) || x.identityNumber.Contains(search) ||
                x.passport.Contains(search) || x.sex.Equals(search) || x.address.Contains(search) || 
                x.telp.Contains(search) || x.email.Contains(search) || x.country.Contains(search)).ToList();
            }
            foreach (var item in convertDataSetToList)
            {
                string sex = item.sex == "M" ? "Male" : "Female";
                dgvCustomers.Rows.Add(item.ID, item.Name, item.identityNumber, item.passport, item.dob.ToString("dd-MM-yyyy"), 
                    sex, item.address, item.telp, item.email, item.country);
            }
        }

        private void UclCustomer_Load(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
            createTable();
            refreshDatagrid(txtSearch.Text);
            isEditted = false;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!isUpdate && !isEditted && dgvCustomers.RowCount > 0)
                {
                    row = dgvCustomers.CurrentRow;
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtIdentity.Text = row.Cells[2].Value.ToString();
                    txtPassport.Text = row.Cells[3].Value.ToString();
                    string[] dateArr = row.Cells[4].Value.ToString().Split('-');
                    DateTime dob = new DateTime(Convert.ToInt32(dateArr[2]), Convert.ToInt32(dateArr[1]), Convert.ToInt32(dateArr[0]));
                    txtDate.Value = dob;
                    if (row.Cells[5].Value.ToString() == "Male")
                        rbMale.Checked = true;
                    else
                        rbFemale.Checked = true;
                    txtAddress.Text = row.Cells[6].Value.ToString();
                    txtPhone.Text = row.Cells[7].Value.ToString();
                    txtEmail.Text = row.Cells[8].Value.ToString();
                    cbCountry.Text = row.Cells[9].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool validation()
        {
            DateTime firstDate = new DateTime(txtDate.Value.Year, txtDate.Value.Month, txtDate.Value.Day);
            DateTime secondDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            bool result = false;
            if (txtName.Text == "" || txtAddress.Text == "" ||
                (rbMale.Checked == false && rbFemale.Checked == false)) message = "Ensure you have filled all fiels";
            else if (!valid.regexAlphabetic(txtName.Text)) message = "Ensure name must alphabetic";
            else if (firstDate >= secondDate) message = "Ensure date of birth must less than today";
            else
            {
                result = true;
                if(txtIdentity.Text != "")
                {
                    if (!valid.regexNumberic(txtIdentity.Text)) {
                        message = "Ensure identity number must numberic";
                        result = false;
                    }
                }
                    
                if (txtPassport.Text != "")
                {
                    if (!valid.regexAlphaNumberic(txtPassport.Text.ToUpper())){
                        message = "Ensure passport number must alpha numberic";
                        result = false;
                    }
                }
                    
                if (txtPhone.Text != "")
                {
                    if (!valid.regexNumberic(txtPhone.Text))
                    {
                        message = "Ensur phone number must numberic";
                        result = false;
                    }
                    else if (txtPhone.Text.Length < 10 || txtPhone.Text.Length > 15)
                    {
                        message = "Ensure phone numbe must between 10 and 15";
                        result = false;
                    }
                }

                if(txtEmail.Text != "")
                {
                    if (!valid.regexEmail(txtEmail.Text))
                    {
                        message = "Ensur phone number must numberic";
                        result = false;
                    }

                }   
            }
            return result;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(true);
            isUpdate = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (row != null)
            {
                enableFrm(true);
                isUpdate = true;
            }
            else
                MessageBox.Show("No Customer Selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                int result = 0;
                string process = "";
                string gender = rbMale.Checked == true ? "M" : "F";
                try
                {
                    if (!isUpdate)
                    {
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", database.autoGenerateID("M", "sp_last_customers", 5)));
                        param.Add(new Parameter("@Name", txtName.Text));
                        param.Add(new Parameter("@IdentityNumber", txtIdentity.Text));
                        param.Add(new Parameter("@PassportNumber", txtPassport.Text));
                        param.Add(new Parameter("@DateofBirth", txtDate.Value.ToString("yyyy-MM-dd")));
                        param.Add(new Parameter("@Sex", gender));
                        param.Add(new Parameter("@Address", txtAddress.Text));
                        param.Add(new Parameter("@TelpNumber", txtPhone.Text));
                        param.Add(new Parameter("@Email", txtEmail.Text));
                        param.Add(new Parameter("@Country", cbCountry.Text));
                        result = database.executeQuery("sp_insert_customers", param, "Add");
                        process = "Insertion";
                    }
                    else
                    {
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                        param.Add(new Parameter("@Name", txtName.Text));
                        param.Add(new Parameter("@IdentityNumber", txtIdentity.Text));
                        param.Add(new Parameter("@PassportNumber", txtPassport.Text));
                        param.Add(new Parameter("@DateofBirth", txtDate.Value.ToString("yyyy-MM-dd")));
                        param.Add(new Parameter("@Sex", gender));
                        param.Add(new Parameter("@Address", txtAddress.Text));
                        param.Add(new Parameter("@TelpNumber", txtPhone.Text));
                        param.Add(new Parameter("@Email", txtEmail.Text));
                        param.Add(new Parameter("@Country", cbCountry.Text));
                        result = database.executeQuery("sp_update_customers", param, "Update");
                        process = "Update";
                        row = null;
                    }
                    if (result == 1)
                    {
                        MessageBox.Show(process + " successful", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        enableFrm(false);
                        refreshDatagrid(null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    int result = database.executeQuery("sp_delete_customers", param, "Deletion");
                    if (result == 1)
                        MessageBox.Show("Data deleted", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clear();
            enableFrm(false);
            refreshDatagrid("");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagrid(txtSearch.Text);
        }
    }
}
