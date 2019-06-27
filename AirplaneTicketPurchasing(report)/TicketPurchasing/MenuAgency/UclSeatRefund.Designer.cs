namespace TicketPurchasing.MenuAgency
{
    partial class UclSeatRefund
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSeat = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new FlatUI.FlatLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panelSeat);
            this.panel1.Location = new System.Drawing.Point(8, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 166);
            this.panel1.TabIndex = 69;
            // 
            // panelSeat
            // 
            this.panelSeat.AutoScroll = true;
            this.panelSeat.AutoSize = true;
            this.panelSeat.Enabled = false;
            this.panelSeat.Location = new System.Drawing.Point(3, 3);
            this.panelSeat.Name = "panelSeat";
            this.panelSeat.Size = new System.Drawing.Size(330, 158);
            this.panelSeat.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.TabIndex = 68;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UclSeatRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "UclSeatRefund";
            this.Size = new System.Drawing.Size(350, 222);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel panelSeat;
        private FlatUI.FlatLabel lblTitle;
    }
}
