using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketPurchasing.MenuAdmin;
using TicketPurchasing.MenuSA;

namespace TicketPurchasing
{
    public partial class FrmMenuAdmin : Form
    {
        #region Declaration
        private Button btn;
        private Support support = new Support();
        private Database database = new Database();
        private string role = "";
        #endregion
        #region Constructor
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        private void FrmMenuSA_Load(object sender, EventArgs e)
        {
            List<Parameter> param = new List<Parameter>();
            param.Add(new Parameter("@Username", Thread.CurrentPrincipal.Identity.Name));
            Support.frm = this;
            DataSet dataProfile = database.getDataFromDatabase("sp_login_getProfile",param);
            lblName.Text = dataProfile.Tables[0].Rows[0][0].ToString().ToUpper();
            role = dataProfile.Tables[0].Rows[0][2].ToString() == "admin" ? "Admin" : "Super Admin";
            lblPosition.Text = role;
            support.DragandDropForm(this);
            UclDashboard dashboard = new UclDashboard();
            addControltoPanel(dashboard);
            lblTitle.Text = "FLIGHTSI - DASHBOARD";
            btn = btnDashboard;
            buttonSeleted(btn);

            // photo
            string base64string = dataProfile.Tables[0].Rows[0][1].ToString();
            string extension = base64string.Substring(base64string.IndexOf('/'),
                                         base64string.IndexOf(';') - base64string.IndexOf('/'));
            string path = base64string.Substring(base64string.IndexOf(',') + 2,
                base64string.Length - (base64string.IndexOf(',') + 2));
            byte[] image = Convert.FromBase64String(path);
            photo.Image = support.byteArrayToImage(image);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            btn = btnManage;
            buttonSeleted(btn);
            lblTitle.Text = "FLIGHTSI - MANAGE";
            if (role.Equals("Super Admin"))
            {
                UclMenuSA menuSA = new UclMenuSA();
                addControltoPanel(menuSA);
            }
            else
            {
                UclMenuAdmin menuAdmin = new UclMenuAdmin();
                addControltoPanel(menuAdmin);
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            btn = btnReport;
            buttonSeleted(btn);
            lblTitle.Text = "FLIGHTSI - REPORT";
            UclReport uclReport = new UclReport();
            addControltoPanel(uclReport);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btn = btnDashboard;
            buttonSeleted(btn);
            lblTitle.Text = "FLIGHTSI - DASHBOARD";
            UclDashboard uclReport = new UclDashboard();
            addControltoPanel(uclReport);
        }
        #endregion
        #region Method
        private void buttonSeleted(Button b)
        {
            pnlButtonSelected.Top = b.Top;
        }

        public void addControltoPanel(UserControl control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            support.DragandDropForm(this);
        }
        #endregion
    }
}
