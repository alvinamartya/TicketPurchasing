namespace TicketPurchasing
{
    partial class UclReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TicketDataSet = new TicketPurchasing.TicketDataSet();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.rvPeriod = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbYear1 = new System.Windows.Forms.ComboBox();
            this.cmbYear2 = new System.Windows.Forms.ComboBox();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.lblEndPeriod = new FlatUI.FlatLabel();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.lblStartPeriod = new FlatUI.FlatLabel();
            this.flatLabel7 = new FlatUI.FlatLabel();
            this.flatLabel8 = new FlatUI.FlatLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.TicketDataSet;
            // 
            // TicketDataSet
            // 
            this.TicketDataSet.DataSetName = "TicketDataSet";
            this.TicketDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbReport
            // 
            this.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Yearly"});
            this.cmbReport.Location = new System.Drawing.Point(152, 22);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(143, 21);
            this.cmbReport.TabIndex = 51;
            this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "dddd, dd MMMM yyyy";
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(152, 49);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 54;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "dddd, dd MMMM yyyy";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(152, 75);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 57;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ForeColor = System.Drawing.SystemColors.Control;
            this.btnShow.Location = new System.Drawing.Point(358, 73);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(69, 25);
            this.btnShow.TabIndex = 92;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // rvPeriod
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.rvPeriod.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPeriod.LocalReport.ReportEmbeddedResource = "TicketPurchasing.Report.Report2.rdlc";
            this.rvPeriod.Location = new System.Drawing.Point(19, 104);
            this.rvPeriod.Name = "rvPeriod";
            this.rvPeriod.ShowBackButton = false;
            this.rvPeriod.ShowFindControls = false;
            this.rvPeriod.Size = new System.Drawing.Size(794, 356);
            this.rvPeriod.TabIndex = 93;
            // 
            // cmbYear1
            // 
            this.cmbYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear1.FormattingEnabled = true;
            this.cmbYear1.Items.AddRange(new object[] {
            "Period",
            "Month",
            "Year"});
            this.cmbYear1.Location = new System.Drawing.Point(152, 49);
            this.cmbYear1.Name = "cmbYear1";
            this.cmbYear1.Size = new System.Drawing.Size(143, 21);
            this.cmbYear1.TabIndex = 94;
            this.cmbYear1.Visible = false;
            // 
            // cmbYear2
            // 
            this.cmbYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear2.FormattingEnabled = true;
            this.cmbYear2.Items.AddRange(new object[] {
            "Period",
            "Month",
            "Year"});
            this.cmbYear2.Location = new System.Drawing.Point(152, 75);
            this.cmbYear2.Name = "cmbYear2";
            this.cmbYear2.Size = new System.Drawing.Size(143, 21);
            this.cmbYear2.TabIndex = 95;
            this.cmbYear2.Visible = false;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(134, 75);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(11, 17);
            this.flatLabel1.TabIndex = 56;
            this.flatLabel1.Text = ":";
            // 
            // lblEndPeriod
            // 
            this.lblEndPeriod.AutoSize = true;
            this.lblEndPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblEndPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndPeriod.ForeColor = System.Drawing.Color.White;
            this.lblEndPeriod.Location = new System.Drawing.Point(16, 75);
            this.lblEndPeriod.Name = "lblEndPeriod";
            this.lblEndPeriod.Size = new System.Drawing.Size(72, 17);
            this.lblEndPeriod.TabIndex = 55;
            this.lblEndPeriod.Text = "End Period";
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(134, 49);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(11, 17);
            this.flatLabel5.TabIndex = 53;
            this.flatLabel5.Text = ":";
            // 
            // lblStartPeriod
            // 
            this.lblStartPeriod.AutoSize = true;
            this.lblStartPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblStartPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPeriod.ForeColor = System.Drawing.Color.White;
            this.lblStartPeriod.Location = new System.Drawing.Point(16, 49);
            this.lblStartPeriod.Name = "lblStartPeriod";
            this.lblStartPeriod.Size = new System.Drawing.Size(77, 17);
            this.lblStartPeriod.TabIndex = 52;
            this.lblStartPeriod.Text = "Start Period";
            // 
            // flatLabel7
            // 
            this.flatLabel7.AutoSize = true;
            this.flatLabel7.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel7.ForeColor = System.Drawing.Color.White;
            this.flatLabel7.Location = new System.Drawing.Point(135, 22);
            this.flatLabel7.Name = "flatLabel7";
            this.flatLabel7.Size = new System.Drawing.Size(11, 17);
            this.flatLabel7.TabIndex = 41;
            this.flatLabel7.Text = ":";
            // 
            // flatLabel8
            // 
            this.flatLabel8.AutoSize = true;
            this.flatLabel8.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel8.ForeColor = System.Drawing.Color.White;
            this.flatLabel8.Location = new System.Drawing.Point(16, 22);
            this.flatLabel8.Name = "flatLabel8";
            this.flatLabel8.Size = new System.Drawing.Size(48, 17);
            this.flatLabel8.TabIndex = 40;
            this.flatLabel8.Text = "Report";
            // 
            // UclReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.cmbYear2);
            this.Controls.Add(this.cmbYear1);
            this.Controls.Add(this.rvPeriod);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.flatLabel1);
            this.Controls.Add(this.lblEndPeriod);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.flatLabel5);
            this.Controls.Add(this.lblStartPeriod);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.flatLabel7);
            this.Controls.Add(this.flatLabel8);
            this.Name = "UclReport";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUI.FlatLabel flatLabel7;
        private FlatUI.FlatLabel flatLabel8;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.DateTimePicker dateStart;
        private FlatUI.FlatLabel flatLabel5;
        private FlatUI.FlatLabel lblStartPeriod;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private FlatUI.FlatLabel flatLabel1;
        private FlatUI.FlatLabel lblEndPeriod;
        private System.Windows.Forms.Button btnShow;
        private Microsoft.Reporting.WinForms.ReportViewer rvPeriod;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private TicketDataSet TicketDataSet;
        private System.Windows.Forms.ComboBox cmbYear1;
        private System.Windows.Forms.ComboBox cmbYear2;
    }
}
