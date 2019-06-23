namespace TicketPurchasing.MenuAdmin
{
    partial class UclMenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UclMenuAdmin));
            this.pnlSchedules = new System.Windows.Forms.Panel();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlSchedules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSchedules
            // 
            this.pnlSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.pnlSchedules.Controls.Add(this.flatLabel1);
            this.pnlSchedules.Controls.Add(this.pictureBox1);
            this.pnlSchedules.Location = new System.Drawing.Point(101, 97);
            this.pnlSchedules.Name = "pnlSchedules";
            this.pnlSchedules.Size = new System.Drawing.Size(292, 285);
            this.pnlSchedules.TabIndex = 8;
            this.pnlSchedules.Click += new System.EventHandler(this.pnlSchedules_Click);
            // 
            // flatLabel1
            // 
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(216)))));
            this.flatLabel1.Location = new System.Drawing.Point(49, 167);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(192, 23);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "Schedules";
            this.flatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatLabel1.Click += new System.EventHandler(this.pnlSchedules_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(87, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pnlSchedules_Click);
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.pnlEmployees.Controls.Add(this.flatLabel4);
            this.pnlEmployees.Controls.Add(this.pictureBox4);
            this.pnlEmployees.Location = new System.Drawing.Point(441, 97);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(292, 285);
            this.pnlEmployees.TabIndex = 11;
            this.pnlEmployees.Click += new System.EventHandler(this.pnlEmployees_Click);
            // 
            // flatLabel4
            // 
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(216)))));
            this.flatLabel4.Location = new System.Drawing.Point(49, 167);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(192, 23);
            this.flatLabel4.TabIndex = 1;
            this.flatLabel4.Text = "Employees";
            this.flatLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatLabel4.Click += new System.EventHandler(this.pnlEmployees_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(87, 70);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(103, 93);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pnlEmployees_Click);
            // 
            // UclMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.pnlEmployees);
            this.Controls.Add(this.pnlSchedules);
            this.Name = "UclMenuAdmin";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclMenuAdmin_Load);
            this.pnlSchedules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSchedules;
        private FlatUI.FlatLabel flatLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlEmployees;
        private FlatUI.FlatLabel flatLabel4;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
