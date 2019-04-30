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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UclReport));
            this.pnlMonths = new System.Windows.Forms.Panel();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlYears = new System.Windows.Forms.Panel();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMonths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlYears.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMonths
            // 
            this.pnlMonths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(201)))), ((int)(((byte)(175)))));
            this.pnlMonths.Controls.Add(this.flatLabel2);
            this.pnlMonths.Controls.Add(this.pictureBox2);
            this.pnlMonths.Location = new System.Drawing.Point(441, 97);
            this.pnlMonths.Name = "pnlMonths";
            this.pnlMonths.Size = new System.Drawing.Size(292, 285);
            this.pnlMonths.TabIndex = 11;
            // 
            // flatLabel2
            // 
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.Black;
            this.flatLabel2.Location = new System.Drawing.Point(49, 167);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(192, 23);
            this.flatLabel2.TabIndex = 1;
            this.flatLabel2.Text = "Months";
            this.flatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(87, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnlYears
            // 
            this.pnlYears.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(201)))), ((int)(((byte)(175)))));
            this.pnlYears.Controls.Add(this.flatLabel1);
            this.pnlYears.Controls.Add(this.pictureBox1);
            this.pnlYears.Location = new System.Drawing.Point(101, 97);
            this.pnlYears.Name = "pnlYears";
            this.pnlYears.Size = new System.Drawing.Size(292, 285);
            this.pnlYears.TabIndex = 10;
            // 
            // flatLabel1
            // 
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.Black;
            this.flatLabel1.Location = new System.Drawing.Point(49, 167);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(192, 23);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "Years";
            this.flatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(87, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UclReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(129)))));
            this.Controls.Add(this.pnlMonths);
            this.Controls.Add(this.pnlYears);
            this.Name = "UclReport";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclReport_Load);
            this.pnlMonths.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlYears.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMonths;
        private FlatUI.FlatLabel flatLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlYears;
        private FlatUI.FlatLabel flatLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
