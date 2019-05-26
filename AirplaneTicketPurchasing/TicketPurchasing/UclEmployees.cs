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
        private string base64string = "";
        private bool isUpdate = false;
        private string connectionString = ConfigurationManager.ConnectionStrings["TicketPurchasing"].ConnectionString;
        private SqlConnection sqlCon;
        private OpenFileDialog pathDialog = new OpenFileDialog();
        #endregion

        #region Constructor
        public UclEmployees()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshDatagrid(txsSearch.Text);
        }

        private void UclEmployees_Load(object sender, EventArgs e)
        {
            clear();
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
            if (isUpdate)
            {
                txtName.Text = row.Cells[1].Value.ToString();
                txtUsername.Text = row.Cells[2].Value.ToString();
                txtPassword.Text = row.Cells[3].Value.ToString();
                
                string[] dayArray = row.Cells[4].Value.ToString().Split('-');
                Console.WriteLine(row.Cells[4].Value.ToString());
                DateTime date = new DateTime(Convert.ToInt32(dayArray[2]), Convert.ToInt32(dayArray[1]), Convert.ToInt32(dayArray[0]));
                txtDateofBirth.Value = date;

                if (row.Cells[5].Value.ToString() == "Male")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                txtAddress.Text = row.Cells[6].Value.ToString();
                txtPhoneNumber.Text = row.Cells[7].Value.ToString();
                cboRole.Text = row.Cells[8].Value.ToString();

                if (row.Cells[9].Value.ToString() != "")
                {
                    base64string = row.Cells[9].Value.ToString();
                    string extension = base64string.Substring(base64string.IndexOf('/'),
                                                 base64string.IndexOf(';') - base64string.IndexOf('/'));
                    txtPhoto.Text = @".\sqlexpress\" + txtName.Text.ToLower().Replace(' ', '-') + "." + extension.Remove(0, 1);
                    string path = base64string.Substring(base64string.IndexOf(',') + 2,
                        base64string.Length - (base64string.IndexOf(',') + 2));
                    byte[] image = Convert.FromBase64String(path);
                    photo.Image = support.byteArrayToImage(image);
                }
                else
                {
                    txtPhoto.Text = "";
                    photo.ImageLocation = Application.StartupPath + @"\img\noimage.jpg";
                }

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
                base64string = Class.MIME.GetMimeType(Path.GetExtension(txtPhoto.Text)) +
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
                    refreshDatagrid("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isUpdate = false;
            enableFrm(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(row != null)
            {
                isUpdate = true;
                enableFrm(true);
            }
            else
            {
                MessageBox.Show("No Employee Selected", "Warning",
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
                    string id = row.Cells[0].Value.ToString();
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@id", id));
                    int result = database.executeQuery("sp_delete_employees", param, "Deletion");
                    if (result == 1)
                        MessageBox.Show("Data deleted", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No Employee Selected", "Warning",
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
        #endregion


        #region Methods
        // enable and disable form
        private void clear()
        {
            txtName.Clear();
            txtDateofBirth.Value = DateTime.Now;
            rbFemale.Checked = false;
            rbMale.Checked = false;
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            cboRole.SelectedIndex = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            photo.ImageLocation = Application.StartupPath + @"\img\noimage.jpg";
            txtPhoto.Clear();
            isUpdate = true;
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
            DgvEmployees.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvEmployees.Columns[0].Visible = false;
            DgvEmployees.Columns[9].Visible = false;
            DgvEmployees.Columns[3].Visible = false;
            DgvEmployees.HeaderForeColor = Color.White;
            DgvEmployees.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagrid(string search)
        {
            DgvEmployees.Rows.Clear();
            string role = Support.role.ToLower().Replace(" ", "");
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Role", role));
            DataSet data = database.getDataFromDatabase("sp_view_employees",param);
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

            if (search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(x => x.Name.Contains(search) || x.Username.Contains(search) ||
                x.DateofBirth.ToString().Contains(search) || x.Sex.Contains(search) || x.Address.Contains(search) ||
                x.TelpNumber.Contains(search)).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                string sex = item.Sex == "M" ? "Male" : "Female";
                DgvEmployees.Rows.Add(item.ID, item.Name, item.Username, item.Password,
                    item.DateofBirth.ToString("dd-MM-yyyy"), sex, item.Address, item.TelpNumber, item.Role, item.Photo);
            }
        }
        #endregion
    }
}
