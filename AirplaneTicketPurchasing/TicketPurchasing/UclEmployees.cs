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
using System.Threading;

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
        private bool isUpdate = false, isInserting = false;
        private OpenFileDialog pathDialog = new OpenFileDialog();
        private string message = "",role = "";
        private string photoPath = "";
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
                string pathPhoto = pathDialog.FileName;
                if (valid.validateImage(pathPhoto))
                {
                    photo.ImageLocation = pathPhoto;
                    photoPath = pathPhoto;
                    base64string = "";
                }
                else
                {
                    MessageBox.Show("Ensure you have selected valid image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    photo.ImageLocation = Application.StartupPath + @"\noimage.jpg";
                }
            }
        }

        private void UclEmployees_Load(object sender, EventArgs e)
        {
            role = getRole(Thread.CurrentPrincipal.Identity.Name);
            clear();
            enableFrm(false);
            createTable();
            refreshDatagrid(txsSearch.Text);
        }

        private void DgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!isUpdate && !isInserting && DgvEmployees.RowCount > 0)
                {
                    row = DgvEmployees.CurrentRow;
                    txtName.Text = row.Cells[1].Value.ToString();

                    string[] dayArray = row.Cells[2].Value.ToString().Split('-');
                    DateTime date = new DateTime(Convert.ToInt32(dayArray[2]), Convert.ToInt32(dayArray[1]), Convert.ToInt32(dayArray[0]));
                    txtDateofBirth.Value = date;

                    if (row.Cells[3].Value.ToString() == "Male")
                        rbMale.Checked = true;
                    else
                        rbFemale.Checked = true;
                    txtAddress.Text = row.Cells[4].Value.ToString();
                    txtPhoneNumber.Text = row.Cells[5].Value.ToString();
                    cboRole.Text = row.Cells[6].Value.ToString();

                    if (row.Cells[7].Value.ToString() != "")
                    {
                        base64string = row.Cells[7].Value.ToString();
                        string extension = base64string.Substring(base64string.IndexOf('/'),
                                                     base64string.IndexOf(';') - base64string.IndexOf('/'));
                        string path = base64string.Substring(base64string.IndexOf(',') + 2,
                            base64string.Length - (base64string.IndexOf(',') + 2));
                        photoPath = @".\sqlexpress\" + txtName.Text.ToLower().Replace(' ', '-') + "." + extension.Remove(0, 1);
                        byte[] image = Convert.FromBase64String(path);
                        photo.Image = support.byteArrayToImage(image);
                    }
                    else
                    {
                        photo.ImageLocation = Application.StartupPath + @"\noimage.jpg";
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txsSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagrid(txsSearch.Text);
        }

        private string getUsername(string name)
        {
            Random rand = new Random();
            string randNumb = "";
            char[] numberic = "1234567890".ToCharArray();
            for (int i = 0; i < 2; i++) randNumb += numberic[rand.Next(numberic.Length)];
            if(name.Length < 18)
                return name.ToLower().Replace(' ','_') + randNumb;
            else
            {
                return name.ToLower().Replace(' ', '_').Substring(0,18) + randNumb;
            }
        }

        private string getPassword(string name, DateTime dob)
        {
            return name.ToLower().Split(' ')[0] + dob.Year.ToString().Remove(0, 2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                int result = 0;
                string process = "";
                string username = "";
                string gender = rbMale.Checked == true ? "M" : "F";
                if (base64string == "" && photo.Image != null)
                {
                    byte[] image = support.imgToByteArray(photo.Image);
                    base64string = Class.MIME.GetMimeType(Path.GetExtension(photoPath)) +
                        ";base64,/" + Convert.ToBase64String(image, 0, image.Length);
                }

                try
                {
                    if (!isUpdate)
                    {
                        username = getUsername(txtName.Text);
                        List<Parameter> param = new List<Parameter>();
                        param.Add(new Parameter("@ID", database.autoGenerateID("E", "sp_last_employees", 5)));
                        param.Add(new Parameter("@Name", txtName.Text));
                        param.Add(new Parameter("@Username", username));
                        param.Add(new Parameter("@Password", getPassword(txtName.Text, txtDateofBirth.Value)));
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
                        if(!isUpdate)
                        {
                            MessageBox.Show(process + " successful\nYour username: " + username, "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(process + " has been success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
            else
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "" || txtPhoneNumber.Text == "" ||
                txtAddress.Text == "" || photoPath == "" ||
                (rbMale.Checked == false && rbFemale.Checked == false)) message = "Ensure you have filled all fiels";
            else if (!valid.regexAlphabetic(txtName.Text)) message = "Ensure name must alphabetic";
            else if (!valid.regexAddress(txtAddress.Text)) message = "Ensure address must alphabetic, numberic, and point symbol";
            else if ((DateTime.Now.Year - txtDateofBirth.Value.Year) < 17) message = "Ensure your age must bigger than 17 years old";
            else result = true;
            return result;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            clear();
            isInserting = true;
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

            photo.ImageLocation = Application.StartupPath + @"\noimage.jpg";
            Console.WriteLine(Application.StartupPath + @"\noimage.jpg");
            photoPath = "";
            isUpdate = false; isInserting = false;
            row = null;

            if (role.Equals("admin"))
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
            btnBrowser.Enabled = value;
        }

        private void createTable()
        {
            DgvEmployees.Rows.Clear();
            DgvEmployees.Columns.Clear();
            DgvEmployees.Columns.Add("id", "ID");
            DgvEmployees.Columns.Add("name", "Name");
            DgvEmployees.Columns.Add("birthDay", "Date of Birth");
            DgvEmployees.Columns.Add("sex", "Gender");
            DgvEmployees.Columns.Add("address", "Address");
            DgvEmployees.Columns.Add("number", "Phone Number");
            DgvEmployees.Columns.Add("role", "Role");
            DgvEmployees.Columns.Add("photo", "Photo");
            DgvEmployees.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvEmployees.Columns[0].Visible = false;
            DgvEmployees.Columns[7].Visible = false;
            DgvEmployees.HeaderForeColor = Color.White;
            DgvEmployees.HeaderBgColor = Color.Teal;
        }

        private void refreshDatagrid(string search)
        {
            DgvEmployees.Rows.Clear();
            string dataRole = role == "admin" ? "admin" : "sa";
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Role", dataRole));
            DataSet data = database.getDataFromDatabase("sp_view_employees",param);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new
                {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Photo = dataRow.Field<string>("Photo"),
                    DateofBirth = dataRow.Field<DateTime>("DateofBirth"),
                    Sex = dataRow.Field<string>("Sex"),
                    Address = dataRow.Field<string>("Address"),
                    TelpNumber = dataRow.Field<string>("TelpNumber"),
                    Role = dataRow.Field<string>("Role")
                }).ToList();

            if (search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(x => x.Name.Contains(search) ||
                x.DateofBirth.ToString().Contains(search) || x.Address.Contains(search) ||
                x.TelpNumber.Contains(search) || x.Role.Contains(search)).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                string sex = item.Sex == "M" ? "Male" : "Female";
                DgvEmployees.Rows.Add(item.ID, item.Name, item.DateofBirth.ToString("dd-MM-yyyy"), 
                    sex, item.Address, item.TelpNumber, item.Role, item.Photo);
            }
        }

        private string getRole(string username)
        {
            string result = "";
            try
            {
                List<Parameter> param = new List<Parameter>();
                param.Add(new Parameter("@Username", username));
                DataSet data = database.getDataFromDatabase("sp_login_getrole", param);
                result = data.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion


    }
}
