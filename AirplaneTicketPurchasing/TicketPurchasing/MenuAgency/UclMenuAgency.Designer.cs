namespace TicketPurchasing.MenuAgency
{
    partial class UclMenuAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UclMenuAgency));
            this.pnlModify = new System.Windows.Forms.Panel();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlPurchase = new System.Windows.Forms.Panel();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlModify
            // 
            this.pnlModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(201)))), ((int)(((byte)(175)))));
            this.pnlModify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModify.Controls.Add(this.flatLabel2);
            this.pnlModify.Controls.Add(this.pictureBox2);
            this.pnlModify.Location = new System.Drawing.Point(441, 97);
            this.pnlModify.Name = "pnlModify";
            this.pnlModify.Size = new System.Drawing.Size(292, 285);
            this.pnlModify.TabIndex = 9;
            this.pnlModify.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.flatLabel2.Text = "Refund";
            this.flatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatLabel2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(94, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pnlPurchase
            // 
            this.pnlPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(201)))), ((int)(((byte)(175)))));
            this.pnlPurchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPurchase.Controls.Add(this.flatLabel1);
            this.pnlPurchase.Controls.Add(this.pictureBox1);
            this.pnlPurchase.Location = new System.Drawing.Point(101, 97);
            this.pnlPurchase.Name = "pnlPurchase";
            this.pnlPurchase.Size = new System.Drawing.Size(292, 285);
            this.pnlPurchase.TabIndex = 8;
            this.pnlPurchase.Click += new System.EventHandler(this.pnlPurchase_Click);
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
            this.flatLabel1.Text = "Purchase";
            this.flatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatLabel1.Click += new System.EventHandler(this.pnlPurchase_Click);
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
            this.pictureBox1.Click += new System.EventHandler(this.pnlPurchase_Click);
            // 
            // UclMenuAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.pnlModify);
            this.Controls.Add(this.pnlPurchase);
            this.Name = "UclMenuAgency";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclMenuAgency_Load);
            this.pnlModify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlPurchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlModify;
        private FlatUI.FlatLabel flatLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlPurchase;
        private FlatUI.FlatLabel flatLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
