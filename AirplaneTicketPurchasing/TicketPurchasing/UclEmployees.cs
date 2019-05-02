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
                flatLabel14.Visible = false;
                flatLabel13.Visible = false;
                cboRole.Visible = false;
                txtAddress.Size = new Size(182, 81);
            }
            else
            {
                flatLabel14.Visible = true;
                flatLabel13.Visible = true;
                cboRole.Visible = true;
                txtAddress.Size = new Size(182, 43);
            }
        }
    }
}
