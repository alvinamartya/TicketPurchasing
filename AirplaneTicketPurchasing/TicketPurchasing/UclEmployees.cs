using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace TicketPurchasing
{
    public partial class UclEmployees : UserControl
    {
        #region Declaration
        Support support = new Support();
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private const string defaultbase64string = "data:image/";
        private string base64string = "";
        private bool isUpdate = false;
        private string connectionString = ConfigurationManager.ConnectionStrings["TicketPurchasing"].ConnectionString;
        private SqlConnection sqlCon;
        #endregion Declaration

        #region Constructor
        public UclEmployees()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void UclEmployees_Load(object sender, EventArgs e)
        {
            
            if (Support.role.Equals("Admin"))
            {
                flatLabel14.Visible = false;
                flatLabel13.Visible = false;
                cboRole.Visible = false;
                txtAddress.Size = new Size(182, 81);
                cboRole.SelectedIndex = 1;
            }
            else
            {
                flatLabel14.Visible = true;
                flatLabel13.Visible = true;
                cboRole.Visible = true;
                txtAddress.Size = new Size(182, 43);
                cboRole.SelectedIndex = 0;
            }
            enableFrm(false);
            createTable();
            refreshDatagrid(txsSearch.Text);
        }
        private void DgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = DgvEmployees.CurrentRow;
            if (!isUpdate)
            {
                txtName.Text = row.Cells[1].Value.ToString();
                txtUsername.Text = row.Cells[2].Value.ToString();
                txtPassword.Text = row.Cells[3].Value.ToString();
                txtDateofBirth.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                if (row.Cells[5].Value.ToString() == "M")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                txtAddress.Text = row.Cells[6].Value.ToString();
                txtPhoneNumber.Text = row.Cells[7].Value.ToString();
                cboRole.SelectedText = row.Cells[8].Value.ToString();

                if(row.Cells[9].Value.ToString() != "")
                {
                    base64string = row.Cells[9].Value.ToString();
                    string extension = base64string.Substring(base64string.IndexOf('/'),
                        base64string.IndexOf(';') - base64string.IndexOf('/'));
                    txtPhoto.Text = @".\sqlexpress\" + txtName.Text.ToLower().Replace(' ', '-') + "." + extension.Remove(0, 1);
                    string path = base64string.Substring(base64string.IndexOf(',') + 2,
                        base64string.Length - (base64string.IndexOf(',') + 2));
                    byte[] image = Convert.FromBase64String(path);
                    photo.Image = support.byteArrayToImage(image);
                }else
                {
                    txtPhoto.Text = null;
                    photo.Image = null;
                }
                
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            pathDialog.FileName = "";
            pathDialog.Filter = "Image Files|*.JPG;*.JPEG;*.PNG";
            if (pathDialog.ShowDialog() == DialogResult.OK)
            {
                txtPhoto.Text = pathDialog.FileName;
                photo.ImageLocation = pathDialog.FileName;
                base64string = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            string process = "";
            string gender = rbMale.Checked == true ? "M" : "F";
            if (base64string == "" && photo.Image != null)
            {
                byte[] image = support.imgToByteArray(photo.Image);
                base64string = defaultbase64string + Path.GetExtension(txtPhoto.Text).Remove(0, 1) +
                    ";base64,/" + Convert.ToBase64String(image, 0, image.Length);
            }

            try
            {
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("E", "sp_last_employees", 5)));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Username", txtUsername.Text));
                    param.Add(new Parameter("@Password", txtPassword.Text));
                    param.Add(new Parameter("@Photo", base64string));
                    param.Add(new Parameter("@DateofBirth", txtDateofBirth.Value.ToString("yyyy-MM-dd")));
                    param.Add(new Parameter("@Sex", gender));
                    param.Add(new Parameter("@Address", txtAddress.Text));
                    param.Add(new Parameter("@TelpNumber", txtPhoneNumber.Text));
                    param.Add(new Parameter("@Role", cboRole.SelectedItem.ToString().ToLower()));
                    param.Add(new Parameter("@Status", "A"));
                    result = database.executeQuery("sp_insert_employee", param, "Add");
                    process = "Insertion";
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Username", txtUsername.Text));
                    param.Add(new Parameter("@Password", txtPassword.Text));
                    param.Add(new Parameter("@Photo", base64string));
                    param.Add(new Parameter("@DateofBirth", txtDateofBirth.Value.ToString("yyyy-MM-dd")));
                    param.Add(new Parameter("@Sex", gender));
                    param.Add(new Parameter("@Address", txtAddress.Text));
                    param.Add(new Parameter("@TelpNumber", txtPhoneNumber.Text));
                    param.Add(new Parameter("@Role", cboRole.SelectedItem.ToString().ToLower()));
                    param.Add(new Parameter("@Status", "A"));
                    result = database.executeQuery("sp_update_employees", param, "Update");
                    process = "Update";
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            enableFrm(true);
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            enableFrm(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshDatagrid(txsSearch.Text);
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
                    int result = database.executeQuery("sp_delete_employees", param, "Deletion");
                    if (result == 1)
                        MessageBox.Show("Data deleted", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else
            {
                MessageBox.Show("No Employee Selected", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clear();
            enableFrm(false);
            refreshDatagrid(null);
        }
        #endregion

        #region Methods

        // enable and disable form
        private void clear()
        {
            txtName.Text = null;
            txtDateofBirth.Text = null;
            rbFemale.Checked = false;
            rbMale.Checked = false;
            txtPhoneNumber.Text = null;
            txtAddress.Text = null;
            cboRole.SelectedText = null;
            txtUsername.Text = null;
            txtPassword.Text = null;
            photo.Image = null;
            txtPhoto.Text = null;
            isUpdate = false;
            pathDialog = null;
        }
        private void enableFrm(bool value)
        {
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            txtName.Enabled = value;
            txtDateofBirth.Enabled = value;
            rbFemale.Enabled = value;
            rbMale.Enabled = value;
            txtPhoneNumber.Enabled = value;
            txtAddress.Enabled = value;
            cboRole.Enabled = value;
            txtUsername.Enabled = value;
            txtPassword.Enabled = value;
            btnBrowser.Enabled = value;
        }

        private void createTable()
        {
            DgvEmployees.Rows.Clear();
            DgvEmployees.Columns.Clear();
            DgvEmployees.Columns.Add("id", "ID");
            DgvEmployees.Columns.Add("name", "Name");
            DgvEmployees.Columns.Add("username", "Username");
            DgvEmployees.Columns.Add("password", "Password");
            DgvEmployees.Columns.Add("birthDay", "Date of Birth");
            DgvEmployees.Columns.Add("sex", "Sex");
            DgvEmployees.Columns.Add("address", "Address");
            DgvEmployees.Columns.Add("number", "Phone Number");
            DgvEmployees.Columns.Add("role", "Role");
            DgvEmployees.Columns.Add("photo", "Photo");
            DgvEmployees.Columns[9].Visible = false;
        }

        private void refreshDatagrid(string search)
        {
            DgvEmployees.Rows.Clear();
            string role = Support.role.ToLower().Replace(" ","");
            DataSet data = database.getDataFromDatabase("sp_view_employees", role);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Username = dataRow.Field<string>("Username"),
                    Password = dataRow.Field<string>("Password"),
                    Photo = dataRow.Field<string>("Photo"),
                    DateofBirth = dataRow.Field<DateTime>("DateofBirth"),
                    Sex = dataRow.Field<string>("Sex"),
                    Address = dataRow.Field<string>("Address"),
                    TelpNumber = dataRow.Field<string>("TelpNumber"),
                    Role = dataRow.Field<string>("Role")
                }).ToList();

            if(search != "")
            {
                //not yet implemented
            }

            foreach (var item in convertDataSetToList)
            {
                DgvEmployees.Rows.Add(item.ID, item.Name, item.Username, item.Password, 
                    item.DateofBirth.ToString("dd-MM-yyyy"), item.Sex, item.Address, item.TelpNumber, item.Role, item.Photo);
            }
        }
        #endregion Methods  
    }
}
