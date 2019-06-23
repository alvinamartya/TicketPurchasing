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
            this.cboReport = new System.Windows.Forms.ComboBox();
            this.txtStartDatePeriod = new System.Windows.Forms.DateTimePicker();
            this.txtEndPeriodDate = new System.Windows.Forms.DateTimePicker();
            this.cboStartPeriod = new System.Windows.Forms.ComboBox();
            this.cboEndPeriod = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dataReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.lblEndPeriod = new FlatUI.FlatLabel();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.lblStartPeriod = new FlatUI.FlatLabel();
            this.flatLabel7 = new FlatUI.FlatLabel();
            this.flatLabel8 = new FlatUI.FlatLabel();
            this.SuspendLayout();
            // 
            // cboReport
            // 
            this.cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Items.AddRange(new object[] {
            "Period",
            "Month",
            "Year"});
            this.cboReport.Location = new System.Drawing.Point(152, 22);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(143, 21);
            this.cboReport.TabIndex = 51;
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            // 
            // txtStartDatePeriod
            // 
            this.txtStartDatePeriod.CustomFormat = "dddd, dd MMMM yyyy";
            this.txtStartDatePeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartDatePeriod.Location = new System.Drawing.Point(152, 49);
            this.txtStartDatePeriod.Name = "txtStartDatePeriod";
            this.txtStartDatePeriod.Size = new System.Drawing.Size(200, 20);
            this.txtStartDatePeriod.TabIndex = 54;
            // 
            // txtEndPeriodDate
            // 
            this.txtEndPeriodDate.CustomFormat = "dddd, dd MMMM yyyy";
            this.txtEndPeriodDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEndPeriodDate.Location = new System.Drawing.Point(152, 75);
            this.txtEndPeriodDate.Name = "txtEndPeriodDate";
            this.txtEndPeriodDate.Size = new System.Drawing.Size(200, 20);
            this.txtEndPeriodDate.TabIndex = 57;
            // 
            // cboStartPeriod
            // 
            this.cboStartPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartPeriod.FormattingEnabled = true;
            this.cboStartPeriod.Location = new System.Drawing.Point(152, 48);
            this.cboStartPeriod.Name = "cboStartPeriod";
            this.cboStartPeriod.Size = new System.Drawing.Size(143, 21);
            this.cboStartPeriod.TabIndex = 58;
            // 
            // cboEndPeriod
            // 
            this.cboEndPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndPeriod.FormattingEnabled = true;
            this.cboEndPeriod.Location = new System.Drawing.Point(152, 74);
            this.cboEndPeriod.Name = "cboEndPeriod";
            this.cboEndPeriod.Size = new System.Drawing.Size(143, 21);
            this.cboEndPeriod.TabIndex = 59;
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
            // 
            // dataReport
            // 
            this.dataReport.Location = new System.Drawing.Point(19, 104);
            this.dataReport.Name = "dataReport";
            this.dataReport.ShowBackButton = false;
            this.dataReport.ShowFindControls = false;
            this.dataReport.Size = new System.Drawing.Size(794, 356);
            this.dataReport.TabIndex = 93;
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
            this.Controls.Add(this.dataReport);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cboEndPeriod);
            this.Controls.Add(this.cboStartPeriod);
            this.Controls.Add(this.txtEndPeriodDate);
            this.Controls.Add(this.flatLabel1);
            this.Controls.Add(this.lblEndPeriod);
            this.Controls.Add(this.txtStartDatePeriod);
            this.Controls.Add(this.flatLabel5);
            this.Controls.Add(this.lblStartPeriod);
            this.Controls.Add(this.cboReport);
            this.Controls.Add(this.flatLabel7);
            this.Controls.Add(this.flatLabel8);
            this.Name = "UclReport";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUI.FlatLabel flatLabel7;
        private FlatUI.FlatLabel flatLabel8;
        private System.Windows.Forms.ComboBox cboReport;
        private System.Windows.Forms.DateTimePicker txtStartDatePeriod;
        private FlatUI.FlatLabel flatLabel5;
        private FlatUI.FlatLabel lblStartPeriod;
        private System.Windows.Forms.DateTimePicker txtEndPeriodDate;
        private FlatUI.FlatLabel flatLabel1;
        private FlatUI.FlatLabel lblEndPeriod;
        private System.Windows.Forms.ComboBox cboStartPeriod;
        private System.Windows.Forms.ComboBox cboEndPeriod;
        private System.Windows.Forms.Button btnShow;
        private Microsoft.Reporting.WinForms.ReportViewer dataReport;
    }
}
