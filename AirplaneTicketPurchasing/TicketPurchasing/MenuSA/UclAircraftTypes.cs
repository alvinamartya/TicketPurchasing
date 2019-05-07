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
        private DataGridViewRow 
            row = null, row2 = null;
        private Database database = new Database();
        private Validation valid = new Validation();
        private string message = "";
        private bool isUpdate = false, isUpdateDetail = false;
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
                MessageBox.Show("Ensure you have selected aircraft type", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("A", "sp_last_amenities", 5)));
                    x = database.executeQuery("sp_insert_amenities", param, "Add");
                    process = "Add";
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            clearDetail();
            enableFrm(false);
            enableFrmDetail2(false);
            enableFrmDetail(false);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.White, Color.Gray);
        }

        private void UclAircraftTypes_Load(object sender, EventArgs e)
        {
            createTableDetails();
            refreshDatagrid("");
            enableFrm(false);
            enableFrmDetail(false);
            enableFrmDetail2(false);
            cboCabinType.SelectedIndex = 0;
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
                int x = 0;
                string process = "";
                if (!isUpdate)
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", database.autoGenerateID("A", "sp_last_amenities", 5)));
                    x = database.executeQuery("sp_insert_amenities", param, "Add");
                    process = "Add";
                }
                else
                {
                    List<Parameter> param = new List<Parameter>();
                    param.Add(new Parameter("@ID", row.Cells[0].Value.ToString()));
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
            txtTotalSeats.Value = 0;
            isUpdate = true;
            row = null;
        }

        private bool validation()
        {
            bool result = false;
            if (txtName.Text == "") message = "Ensure you have filled all fields";
            else if (!valid.regexAlphabetic(txtName.Text)) message = "Ensure name must alphabetic";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrm(bool value)
        {
            txtName.Enabled = value;
            txtMakeModel.Enabled = value;
            txtTotalSeats.Enabled = value;
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
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
        }


        private void refreshDatagrid(string search)
        {
            createTable();
            DataSet data = database.getDataFromDatabase("sp_view_aircrafttype");
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    MakeModel = dataRow.Field<string>("MakeModel"),
                    TotalSeat = dataRow.Field<string>("Totalseats")
                }).ToList();

            // search
            if (search != "")
            {
                convertDataSetToList = convertDataSetToList.Where(z =>
                    z.Name.ToLower().Contains(search.ToLower()) || z.MakeModel.ToLower().Contains(search.ToLower()) ||
                    z.TotalSeat.ToLower().Contains(search.ToLower())
                ).ToList();
            }

            foreach (var item in convertDataSetToList)
            {
                DgvAircraftType.Rows.Add(item.ID, item.Name, item.MakeModel, item.TotalSeat);
            }
        }
        #endregion
        #region Detail
        private void clearDetail()
        {
            cboCabinType.SelectedIndex = 0;
            txtSeat.Value = 0;
            isUpdateDetail = true;
            row2 = null;
        }

        private bool validationdetail()
        {
            bool result = false;
            if (txtName.Text == "") message = "Ensure you have filled all fields";
            else if (!valid.regexAlphabetic(txtName.Text)) message = "Ensure name must alphabetic";
            else result = true;
            return result;
        }

        // enable and disable form
        private void enableFrmDetail(bool value)
        {
            cboCabinType.Enabled = value;
            txtSeat.Enabled = value;
            btnInsertDetail.Visible = !value;
            btnUpdateDetail.Visible = !value;
            btnDeleteDetail.Visible = !value;
            btnSaveDetail.Visible = value;
            btnCancelDetail.Visible = value;
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
            DgvAircraftTypeDetail.Columns.Add("seat", "Seat");
            DgvAircraftTypeDetail.Columns[0].Visible = false;
            DgvAircraftTypeDetail.ForeColor = Color.Black;
            DgvAircraftTypeDetail.HeaderForeColor = Color.White;
        }



        private void refreshDatagridDetails()
        {
            createTableDetails();
            DataSet data = database.getDataFromDatabase("");
            var convertDataSetToList = data.Tables[0].AsEnumerable().Select(
                dataRow => new {
                    ID = dataRow.Field<string>("ID"),
                    Name = dataRow.Field<string>("Name"),
                    Qty = dataRow.Field<int>("Qty"),
                    Unit = dataRow.Field<string>("Unit")
                }).ToList();

            foreach (var item in convertDataSetToList)
            {
                DgvAircraftTypeDetail.Rows.Add(item.ID, item.Name, item.Qty, item.Unit);
            }
        }
        #endregion
        #endregion
    }
}
