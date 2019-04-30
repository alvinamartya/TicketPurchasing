using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing
{
    public partial class UclEmployees : UserControl
    {
        public UclEmployees()
        {
            InitializeComponent();
        }

        private void UclEmployees_Load(object sender, EventArgs e)
        {
            if (Support.role.Equals("Admin"))
            {
                cboRole.Visible = false;
                flatLabel13.Visible = false;
                flatLabel14.Visible = false;
                btnInsert.Location = new Point(245, 429);
                btnUpdate.Location = new Point(360, 429);
                btnDelete.Location = new Point(475, 429);
                btnSave.Location = new Point(302, 469);
                btnCancel.Location = new Point(417, 469);
                this.Size = new Size(808, 515);
            }
            else
            {
                cboRole.Visible = true;
                flatLabel13.Visible = true;
                flatLabel14.Visible = true;
                btnInsert.Location = new Point(241, 460);
                btnUpdate.Location = new Point(356, 460);
                btnDelete.Location = new Point(471, 460);
                btnSave.Location = new Point(298, 500);
                btnCancel.Location = new Point(413, 500);
                this.Size = new Size(808, 544);
            }
        }
    }
}
