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
    public partial class UclManageSchedules : UserControl
    {
        public UclManageSchedules()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string date = txtDateTime.Value.ToString("yyyy-MM-dd");
            string time = txtDateTime.Value.ToString("hh:mm");
            Console.WriteLine("Date: " + date + " time: " + time);
        }
    }
}
