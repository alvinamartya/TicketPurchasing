﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        Support support = new Support();
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
            Support.frm = this;
            lblName.Text = Support.name;
            lblPosition.Text = Support.role;
            support.DragandDropForm(this);
            if(Support.role.Equals("Super Admin"))
            {
                UclMenuSA menuSA = new UclMenuSA();
                addControltoPanel(menuSA);
            }
            else
            {
                UclMenuAdmin menuAdmin = new UclMenuAdmin();
                addControltoPanel(menuAdmin);
            }

            lblTitle.Text = "FLIGHTSI - MANAGE";
            btn = btnManage;
            disableButton();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            enableButton();
            btn = btnManage;
            disableButton();
            lblTitle.Text = "FLIGHTSI - MANAGE";
            if (Support.role.Equals("Super Admin"))
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
            enableButton();
            btn = btnReport;
            disableButton();
            lblTitle.Text = "FLIGHTSI - REPORT";
            UclReport uclReport = new UclReport();
            addControltoPanel(uclReport);
        }
        #endregion

        #region Method
        private void disableButton()
        {
            Color disableColor = Color.FromArgb(215, 180, 157);
            btn.BackColor = disableColor;
        }

        private void enableButton()
        {
            Color enableColor = Color.FromArgb(239, 201, 175);
            btn.BackColor = enableColor;
        }

        public void addControltoPanel(UserControl control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
            support.DragandDropForm(this);
        }
        #endregion

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}