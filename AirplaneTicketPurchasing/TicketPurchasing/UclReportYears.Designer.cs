namespace TicketPurchasing
{
    partial class UclReportYears
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
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.flatLabel13 = new FlatUI.FlatLabel();
            this.flatLabel14 = new FlatUI.FlatLabel();
            this.btnShow = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(101, 18);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(117, 21);
            this.cboRole.TabIndex = 53;
            // 
            // flatLabel13
            // 
            this.flatLabel13.AutoSize = true;
            this.flatLabel13.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel13.ForeColor = System.Drawing.Color.White;
            this.flatLabel13.Location = new System.Drawing.Point(83, 18);
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
            this.flatLabel14.Location = new System.Drawing.Point(17, 18);
            this.flatLabel14.Name = "flatLabel14";
            this.flatLabel14.Size = new System.Drawing.Size(33, 17);
            this.flatLabel14.TabIndex = 51;
            this.flatLabel14.Text = "Year";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ForeColor = System.Drawing.SystemColors.Control;
            this.btnShow.Location = new System.Drawing.Point(224, 13);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(71, 29);
            this.btnShow.TabIndex = 63;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(20, 48);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.Size = new System.Drawing.Size(794, 410);
            this.reportViewer1.TabIndex = 64;
            // 
            // UclReportYears
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.flatLabel13);
            this.Controls.Add(this.flatLabel14);
            this.Name = "UclReportYears";
            this.Size = new System.Drawing.Size(835, 479);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRole;
        private FlatUI.FlatLabel flatLabel13;
        private FlatUI.FlatLabel flatLabel14;
        private System.Windows.Forms.Button btnShow;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
