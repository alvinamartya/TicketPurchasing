namespace TicketPurchasing.MenuAdmin
{
    partial class UclManageSchedules
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSch = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cmbAircraft = new System.Windows.Forms.ComboBox();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.cmbArrival = new System.Windows.Forms.ComboBox();
            this.dtDeparture = new System.Windows.Forms.DateTimePicker();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flatLabel22 = new FlatUI.FlatLabel();
            this.flatLabel23 = new FlatUI.FlatLabel();
            this.flatLabel19 = new FlatUI.FlatLabel();
            this.flatLabel18 = new FlatUI.FlatLabel();
            this.flatLabel16 = new FlatUI.FlatLabel();
            this.flatLabel17 = new FlatUI.FlatLabel();
            this.flatLabel15 = new FlatUI.FlatLabel();
            this.flatLabel11 = new FlatUI.FlatLabel();
            this.flatLabel12 = new FlatUI.FlatLabel();
            this.flatLabel7 = new FlatUI.FlatLabel();
            this.flatLabel8 = new FlatUI.FlatLabel();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.flatLabel6 = new FlatUI.FlatLabel();
            this.flatLabel3 = new FlatUI.FlatLabel();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.flatLabel13 = new FlatUI.FlatLabel();
            this.flatLabel14 = new FlatUI.FlatLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSch
            // 
            this.dgvSch.AllowUserToAddRows = false;
            this.dgvSch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSch.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSch.DoubleBuffered = true;
            this.dgvSch.EnableHeadersVisualStyles = false;
            this.dgvSch.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgvSch.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgvSch.Location = new System.Drawing.Point(20, 45);
            this.dgvSch.Name = "dgvSch";
            this.dgvSch.ReadOnly = true;
            this.dgvSch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSch.Size = new System.Drawing.Size(770, 172);
            this.dgvSch.TabIndex = 3;
            this.dgvSch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSch_CellClick);
            // 
            // cmbAircraft
            // 
            this.cmbAircraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAircraft.FormattingEnabled = true;
            this.cmbAircraft.Location = new System.Drawing.Point(379, 238);
            this.cmbAircraft.Name = "cmbAircraft";
            this.cmbAircraft.Size = new System.Drawing.Size(182, 21);
            this.cmbAircraft.TabIndex = 53;
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(379, 265);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(182, 21);
            this.cmbDepart.TabIndex = 56;
            // 
            // cmbArrival
            // 
            this.cmbArrival.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArrival.FormattingEnabled = true;
            this.cmbArrival.Location = new System.Drawing.Point(379, 292);
            this.cmbArrival.Name = "cmbArrival";
            this.cmbArrival.Size = new System.Drawing.Size(182, 21);
            this.cmbArrival.TabIndex = 59;
            // 
            // dtDeparture
            // 
            this.dtDeparture.CustomFormat = "dd MMMM yyyy,  hh:mm";
            this.dtDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeparture.Location = new System.Drawing.Point(379, 320);
            this.dtDeparture.Name = "dtDeparture";
            this.dtDeparture.Size = new System.Drawing.Size(200, 20);
            this.dtDeparture.TabIndex = 62;
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(412, 347);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(131, 20);
            this.txtFee.TabIndex = 68;
            this.txtFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(379, 373);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(43, 20);
            this.txtHour.TabIndex = 72;
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(477, 373);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(43, 20);
            this.txtMin.TabIndex = 74;
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(410, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 34);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(295, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(468, 414);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 34);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(353, 414);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(109, 34);
            this.btnUpdate.TabIndex = 77;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInsert.Location = new System.Drawing.Point(238, 414);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(109, 34);
            this.btnInsert.TabIndex = 76;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(89, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 90;
            // 
            // flatLabel22
            // 
            this.flatLabel22.AutoSize = true;
            this.flatLabel22.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel22.ForeColor = System.Drawing.Color.White;
            this.flatLabel22.Location = new System.Drawing.Point(72, 16);
            this.flatLabel22.Name = "flatLabel22";
            this.flatLabel22.Size = new System.Drawing.Size(11, 17);
            this.flatLabel22.TabIndex = 89;
            this.flatLabel22.Text = ":";
            // 
            // flatLabel23
            // 
            this.flatLabel23.AutoSize = true;
            this.flatLabel23.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel23.ForeColor = System.Drawing.Color.White;
            this.flatLabel23.Location = new System.Drawing.Point(19, 16);
            this.flatLabel23.Name = "flatLabel23";
            this.flatLabel23.Size = new System.Drawing.Size(47, 17);
            this.flatLabel23.TabIndex = 88;
            this.flatLabel23.Text = "Search";
            // 
            // flatLabel19
            // 
            this.flatLabel19.AutoSize = true;
            this.flatLabel19.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel19.ForeColor = System.Drawing.Color.White;
            this.flatLabel19.Location = new System.Drawing.Point(526, 373);
            this.flatLabel19.Name = "flatLabel19";
            this.flatLabel19.Size = new System.Drawing.Size(54, 17);
            this.flatLabel19.TabIndex = 75;
            this.flatLabel19.Text = "Minutes";
            // 
            // flatLabel18
            // 
            this.flatLabel18.AutoSize = true;
            this.flatLabel18.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel18.ForeColor = System.Drawing.Color.White;
            this.flatLabel18.Location = new System.Drawing.Point(428, 373);
            this.flatLabel18.Name = "flatLabel18";
            this.flatLabel18.Size = new System.Drawing.Size(43, 17);
            this.flatLabel18.TabIndex = 73;
            this.flatLabel18.Text = "Hours";
            // 
            // flatLabel16
            // 
            this.flatLabel16.AutoSize = true;
            this.flatLabel16.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel16.ForeColor = System.Drawing.Color.White;
            this.flatLabel16.Location = new System.Drawing.Point(362, 373);
            this.flatLabel16.Name = "flatLabel16";
            this.flatLabel16.Size = new System.Drawing.Size(11, 17);
            this.flatLabel16.TabIndex = 71;
            this.flatLabel16.Text = ":";
            // 
            // flatLabel17
            // 
            this.flatLabel17.AutoSize = true;
            this.flatLabel17.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel17.ForeColor = System.Drawing.Color.White;
            this.flatLabel17.Location = new System.Drawing.Point(230, 373);
            this.flatLabel17.Name = "flatLabel17";
            this.flatLabel17.Size = new System.Drawing.Size(71, 17);
            this.flatLabel17.TabIndex = 70;
            this.flatLabel17.Text = "Flight Time";
            // 
            // flatLabel15
            // 
            this.flatLabel15.AutoSize = true;
            this.flatLabel15.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel15.ForeColor = System.Drawing.Color.White;
            this.flatLabel15.Location = new System.Drawing.Point(379, 347);
            this.flatLabel15.Name = "flatLabel15";
            this.flatLabel15.Size = new System.Drawing.Size(27, 17);
            this.flatLabel15.TabIndex = 69;
            this.flatLabel15.Text = "Rp.";
            // 
            // flatLabel11
            // 
            this.flatLabel11.AutoSize = true;
            this.flatLabel11.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel11.ForeColor = System.Drawing.Color.White;
            this.flatLabel11.Location = new System.Drawing.Point(362, 347);
            this.flatLabel11.Name = "flatLabel11";
            this.flatLabel11.Size = new System.Drawing.Size(11, 17);
            this.flatLabel11.TabIndex = 67;
            this.flatLabel11.Text = ":";
            // 
            // flatLabel12
            // 
            this.flatLabel12.AutoSize = true;
            this.flatLabel12.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel12.ForeColor = System.Drawing.Color.White;
            this.flatLabel12.Location = new System.Drawing.Point(230, 347);
            this.flatLabel12.Name = "flatLabel12";
            this.flatLabel12.Size = new System.Drawing.Size(36, 17);
            this.flatLabel12.TabIndex = 66;
            this.flatLabel12.Text = "Price";
            // 
            // flatLabel7
            // 
            this.flatLabel7.AutoSize = true;
            this.flatLabel7.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel7.ForeColor = System.Drawing.Color.White;
            this.flatLabel7.Location = new System.Drawing.Point(361, 320);
            this.flatLabel7.Name = "flatLabel7";
            this.flatLabel7.Size = new System.Drawing.Size(11, 17);
            this.flatLabel7.TabIndex = 61;
            this.flatLabel7.Text = ":";
            // 
            // flatLabel8
            // 
            this.flatLabel8.AutoSize = true;
            this.flatLabel8.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel8.ForeColor = System.Drawing.Color.White;
            this.flatLabel8.Location = new System.Drawing.Point(229, 320);
            this.flatLabel8.Name = "flatLabel8";
            this.flatLabel8.Size = new System.Drawing.Size(130, 17);
            this.flatLabel8.TabIndex = 60;
            this.flatLabel8.Text = "Departure Date Time";
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(361, 292);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(11, 17);
            this.flatLabel5.TabIndex = 58;
            this.flatLabel5.Text = ":";
            // 
            // flatLabel6
            // 
            this.flatLabel6.AutoSize = true;
            this.flatLabel6.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel6.ForeColor = System.Drawing.Color.White;
            this.flatLabel6.Location = new System.Drawing.Point(229, 292);
            this.flatLabel6.Name = "flatLabel6";
            this.flatLabel6.Size = new System.Drawing.Size(70, 17);
            this.flatLabel6.TabIndex = 57;
            this.flatLabel6.Text = "Arrival City";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(361, 265);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(11, 17);
            this.flatLabel3.TabIndex = 55;
            this.flatLabel3.Text = ":";
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(229, 265);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(92, 17);
            this.flatLabel4.TabIndex = 54;
            this.flatLabel4.Text = "Departure City";
            // 
            // flatLabel13
            // 
            this.flatLabel13.AutoSize = true;
            this.flatLabel13.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel13.ForeColor = System.Drawing.Color.White;
            this.flatLabel13.Location = new System.Drawing.Point(361, 238);
            this.flatLabel13.Name = "flatLabel13";
            this.flatLabel13.Size = new System.Drawing.Size(11, 17);
            this.flatLabel13.TabIndex = 52;
            this.flatLabel13.Text = ":";
            // 
            // flatLabel14
            // 
            this.flatLabel14.AutoSize = true;
            this.flatLabel14.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel14.ForeColor = System.Drawing.Color.White;
            this.flatLabel14.Location = new System.Drawing.Point(229, 238);
            this.flatLabel14.Name = "flatLabel14";
            this.flatLabel14.Size = new System.Drawing.Size(50, 17);
            this.flatLabel14.TabIndex = 51;
            this.flatLabel14.Text = "Aircraft";
            // 
            // UclManageSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flatLabel22);
            this.Controls.Add(this.flatLabel23);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.flatLabel19);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.flatLabel18);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.flatLabel16);
            this.Controls.Add(this.flatLabel17);
            this.Controls.Add(this.flatLabel15);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.flatLabel11);
            this.Controls.Add(this.flatLabel12);
            this.Controls.Add(this.dtDeparture);
            this.Controls.Add(this.flatLabel7);
            this.Controls.Add(this.flatLabel8);
            this.Controls.Add(this.cmbArrival);
            this.Controls.Add(this.flatLabel5);
            this.Controls.Add(this.flatLabel6);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.flatLabel3);
            this.Controls.Add(this.flatLabel4);
            this.Controls.Add(this.cmbAircraft);
            this.Controls.Add(this.flatLabel13);
            this.Controls.Add(this.flatLabel14);
            this.Controls.Add(this.dgvSch);
            this.Name = "UclManageSchedules";
            this.Size = new System.Drawing.Size(808, 529);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvSch;
        private System.Windows.Forms.ComboBox cmbAircraft;
        private FlatUI.FlatLabel flatLabel13;
        private FlatUI.FlatLabel flatLabel14;
        private System.Windows.Forms.ComboBox cmbDepart;
        private FlatUI.FlatLabel flatLabel3;
        private FlatUI.FlatLabel flatLabel4;
        private System.Windows.Forms.ComboBox cmbArrival;
        private FlatUI.FlatLabel flatLabel5;
        private FlatUI.FlatLabel flatLabel6;
        private System.Windows.Forms.DateTimePicker dtDeparture;
        private FlatUI.FlatLabel flatLabel7;
        private FlatUI.FlatLabel flatLabel8;
        private System.Windows.Forms.TextBox txtFee;
        private FlatUI.FlatLabel flatLabel11;
        private FlatUI.FlatLabel flatLabel12;
        private FlatUI.FlatLabel flatLabel15;
        private System.Windows.Forms.TextBox txtHour;
        private FlatUI.FlatLabel flatLabel16;
        private FlatUI.FlatLabel flatLabel17;
        private FlatUI.FlatLabel flatLabel18;
        private FlatUI.FlatLabel flatLabel19;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtSearch;
        private FlatUI.FlatLabel flatLabel22;
        private FlatUI.FlatLabel flatLabel23;
    }
}
