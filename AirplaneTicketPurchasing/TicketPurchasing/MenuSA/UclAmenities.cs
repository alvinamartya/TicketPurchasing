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
            //enableFrm(false);
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
            btnSave.Visible = value;
            btnCancel.Visible = value;
            btnInsert.Visible = !value;
            btnUpdate.Visible = !value;
            btnDelete.Visible = !value;
        }
        #endregion
    }
}
