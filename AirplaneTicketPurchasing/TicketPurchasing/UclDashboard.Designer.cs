namespace TicketPurchasing
{
    partial class UclDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.piechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTopCities = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.columnChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.columnchart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.piechart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnchart2)).BeginInit();
            this.SuspendLayout();
            // 
            // piechart
            // 
            chartArea1.Name = "ChartArea1";
            this.piechart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.piechart.Legends.Add(legend1);
            this.piechart.Location = new System.Drawing.Point(20, 23);
            this.piechart.Name = "piechart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.piechart.Series.Add(series1);
            this.piechart.Size = new System.Drawing.Size(349, 187);
            this.piechart.TabIndex = 0;
            this.piechart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.piechart_MouseClick);
            this.piechart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.piechart_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTopCities);
            this.groupBox2.Location = new System.Drawing.Point(392, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 166);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Top Cities";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // dgvTopCities
            // 
            this.dgvTopCities.AllowUserToAddRows = false;
            this.dgvTopCities.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTopCities.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopCities.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTopCities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopCities.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopCities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTopCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopCities.DoubleBuffered = true;
            this.dgvTopCities.EnableHeadersVisualStyles = false;
            this.dgvTopCities.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgvTopCities.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgvTopCities.Location = new System.Drawing.Point(6, 19);
            this.dgvTopCities.MultiSelect = false;
            this.dgvTopCities.Name = "dgvTopCities";
            this.dgvTopCities.ReadOnly = true;
            this.dgvTopCities.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopCities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopCities.Size = new System.Drawing.Size(415, 141);
            this.dgvTopCities.TabIndex = 0;
            this.dgvTopCities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopCities_CellClick);
            // 
            // columnChart
            // 
            chartArea2.Name = "ChartArea1";
            this.columnChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.columnChart.Legends.Add(legend2);
            this.columnChart.Location = new System.Drawing.Point(20, 227);
            this.columnChart.Name = "columnChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.columnChart.Series.Add(series2);
            this.columnChart.Size = new System.Drawing.Size(399, 220);
            this.columnChart.TabIndex = 3;
            // 
            // columnchart2
            // 
            chartArea3.Name = "ChartArea1";
            this.columnchart2.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.columnchart2.Legends.Add(legend3);
            this.columnchart2.Location = new System.Drawing.Point(425, 227);
            this.columnchart2.Name = "columnchart2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.columnchart2.Series.Add(series3);
            this.columnchart2.Size = new System.Drawing.Size(388, 220);
            this.columnchart2.TabIndex = 4;
            // 
            // UclDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.columnchart2);
            this.Controls.Add(this.columnChart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.piechart);
            this.Name = "UclDashboard";
            this.Size = new System.Drawing.Size(835, 479);
            this.Load += new System.EventHandler(this.UclDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.piechart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnchart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart piechart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart columnChart;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvTopCities;
        private System.Windows.Forms.DataVisualization.Charting.Chart columnchart2;
    }
}
