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
    public partial class UclAmenities : UserControl
    {
        #region declaration
        Database database = new Database();
        #endregion

        #region Constructor
        public UclAmenities()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void UclAmenities_Load(object sender, EventArgs e)
        {
            clear();
            enableFrm(false);
        }

        private void btnInsert_EnabledChanged(object sender, EventArgs e)
        {
            if(((Button)sender).Enabled == false)
            {
                ((Button)sender).ForeColor = Color.Gray;
            }
        }
        #endregion

        #region method
        private void clear()
        {
            cboUnit.SelectedIndex = 0;
        }

        private void enableFrm(bool value)
        {

            txtName.Enabled = value;
            txtQty.Enabled = value;
            cboUnit.Enabled = value;
            btnSave.Enabled = value;
            btnCancel.Enabled = value;
            btnInsert.Enabled = !value;
            btnUpdate.Enabled = !value;
            btnDelete.Enabled = !value;
        }
        #endregion
    }
}
