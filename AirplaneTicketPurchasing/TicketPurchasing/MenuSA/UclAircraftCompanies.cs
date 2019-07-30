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

namespace TicketPurchasing.MenuSA
{
    public partial class UclAircraftCompanies : UserControl
    {
        #region Declaration
        private DataGridViewRow row = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private Support support = new Support();
        private string base64string = "";
        private string message = "";
        private string photoPath = "";
        private bool isUpdate = false,isEnable = false;
        #endregion
        #region Constructor
        public UclAircraftCompanies()
        {
            InitializeComponent();
        }
        #endregion
        #region Method
        private void createTable()
        {
            DgvCompanies.Rows.Clear();
            DgvCompanies.Columns.Clear();
            DgvCompanies.Columns.Add("id", "ID");
            DgvCompanies.Columns.Add("name", "Name");
            DgvCompanies.Columns.Add("phone", "Phone");
            DgvCompanies.Columns.Add("companycode", "IATA");
            DgvCompanies.Columns.Add("address", "Address");
            DgvCompanies.Columns.Add("photo", "Photo");
            DgvCompanies.Columns[0].Visible = false;
            DgvCompanies.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCompanies.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCompanies.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCompanies.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgvCompanies.Columns[5].Visible = false;
            DgvCompanies.ForeColor = Color.Black;
        }

        private void refreshDatagrid(string search)
        {
            int x = 1;
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_aircraftcompanies",null);
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Address = dataRow.Field<string>("Address"),
                    TelpNumber = dataRow.Field<string>("TelpNumber"),
                    CompanyCode = dataRow.Field<string>("IATA"),
                    Photo = dataRow.Field<string>("Photo")
                }).ToList();

            // search
            if (search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(z =>
                    z.Name.ToLower().Contains(search.ToLower()) || z.Address.ToLower().Contains(search.ToLower()) || 
                    z.TelpNumber.ToLower().Contains(search.ToLower()) || z.CompanyCode.ToLower().Contains(search.ToLower())
                ).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                DgvCompanies.Rows.Add(item.ID, item.Name, item.TelpNumber,item.CompanyCode,item.Address,item.Photo);
            }
        }

        // back to default
        private void clear()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtCompanyCode.Clear();
            txtAddress.Clear();
            photo.Image = null;
            base64string = "";
            isUpdate = true;
            row = null;
            photo.ImageLocation = Application.StartupPath + @"\noimage.jpg";
            photoPath = "";
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            txtPhone.Enabled = value;
            txtCompanyCode.Enabled = value;
            txtAddress.Enabled = value;
            btnPath.Enabled = value;
            btnCancel.Visible = value;
            btnSave.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
            isEnable = value;
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "" || txtPhone.Text == "" || txtCompanyCode.Text == "" ||
                txtAddress.Text == "" || photoPath == "") message = "Ensure you have filled all fields";
            else if (!valid.regexAlphabetic(txtName.Text)) message = "Ensure name must alphabetic";
            else if (!valid.regexAlphabetic(txtCompanyCode.Text)) message = "Ensure IATA must alphabetic";
            else if (!valid.regexNumberic(txtPhone.Text)) message = "Ensure telp number must numberic";
            else if (txtPhone.Text.Length < 10 || txtPhone.Text.Length > 15) message = "Ensure telp number must between 10 and 15";
            else if (txtCompanyCode.Text.Length != 2) message = "Ensure IATA must have 2 characters";
            else result = true;
            return result;
        }
        #endregion
        #region Events
        private void UclAircraftCompanies_Load(object sender, EventArgs e)
        {
            refreshDatagrid("");
            clear();
            enableFrm(false);
        }

        private void btnPath_Click(object sender, EventArgs e)
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
                MessageBox.Show("Ensure you have selected aircraft company", "Warning",
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
                    int x = database.executeQuery("sp_delete_aircraftcompanies", param, "Delete");
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
                MessageBox.Show("Ensure you have selected aircraft company", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                if(base64string == "")
                {
                    byte[] image = support.imgToByteArray(photo.Image);
                    base64string = Class.MIME.GetMimeType(Path.GetExtension(photoPath)) + ";base64,/" + Convert.ToBase64String(image, 0, image.Length);
                }

                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("C", "sp_last_aircraftcompanies", 5)));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Address", txtAddress.Text));
                    param.Add(new Parameter("@TelpNumber", txtPhone.Text));
                    param.Add(new Parameter("@Photo", base64string));
                    param.Add(new Parameter("@IATA", txtCompanyCode.Text));
                    param.Add(new Parameter("@Status", "A"));
                    x = database.executeQuery("sp_insert_aircraftcompanies", param, "Add");
                    process = "Add";
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
                    param.Add(new Parameter("@Name", txtName.Text));
                    param.Add(new Parameter("@Address", txtAddress.Text));
                    param.Add(new Parameter("@TelpNumber", txtPhone.Text));
                    param.Add(new Parameter("@Photo", base64string));
                    param.Add(new Parameter("@IATA", txtCompanyCode.Text));
                    x = database.executeQuery("sp_update_aircraftcompanies", param, "Update");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
        }

        private void DgvCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isUpdate && !isEnable && DgvCompanies.RowCount > 0)
                {
                    row = DgvCompanies.CurrentRow;
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtPhone.Text = row.Cells[2].Value.ToString();
                    txtCompanyCode.Text = row.Cells[3].Value.ToString();
                    txtAddress.Text = row.Cells[4].Value.ToString();

                    // get image from database then show to picturebox
                    base64string = row.Cells[5].Value.ToString();
                    string extension = base64string.Substring(base64string.IndexOf('/'),
                        base64string.IndexOf(';') - base64string.IndexOf('/'));
                    string path = base64string.Substring(base64string.IndexOf(',') + 2,
                        base64string.Length - (base64string.IndexOf(',') + 2));
                    photoPath = @".\sqlexpress\" + txtName.Text.ToLower().Replace(' ', '-') + "." + extension.Remove(0, 1);
                    byte[] image = Convert.FromBase64String(path);
                    photo.Image = support.byteArrayToImage(image);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshDatagrid(txtSearch.Text);
        }
        #endregion
    }
}
