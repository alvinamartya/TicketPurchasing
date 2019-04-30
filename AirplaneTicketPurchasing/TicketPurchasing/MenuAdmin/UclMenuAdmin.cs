using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing.MenuAdmin
{
    public partial class UclMenuAdmin : UserControl
    {
        #region Declaration
        Support support = new Support();
        #endregion

        
        public UclMenuAdmin()
        {
            InitializeComponent();
        }

        private void UclMenuAdmin_Load(object sender, EventArgs e)
        {
            support.panelMouse(pnlSchedules);
            support.panelMouse(pnlEmployees);
        }

        private void pnlSchedules_Click(object sender, EventArgs e)
        {
            UclManageSchedules schedules = new UclManageSchedules();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(schedules);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Schedules]";
        }

        private void pnlEmployees_Click(object sender, EventArgs e)
        {
            UclEmployees employees = new UclEmployees();
            ((FrmMenuAdmin)Support.frm).addControltoPanel(employees);
            ((FrmMenuAdmin)Support.frm).lblTitle.Text = "FLIGHTSI - MANAGE [Employees]";
        }
    }
}
