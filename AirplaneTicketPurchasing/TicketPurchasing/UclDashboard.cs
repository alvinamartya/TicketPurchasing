using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TicketPurchasing
{
    public partial class UclDashboard : UserControl
    {
        #region Declaration
        private Database database = new Database();
        private int getpoint = 0;
        private bool haspoint = false;

        private Color[] pieColor = {
            ColorTranslator.FromHtml("#e53935"),
            ColorTranslator.FromHtml("#1e88e5"),
            ColorTranslator.FromHtml("#8bc34a"),
            ColorTranslator.FromHtml("#e65100"),
            ColorTranslator.FromHtml("#dd2c00")
        };
        private Color[] pieSecondColor = {
            ColorTranslator.FromHtml("#f44336"),
            ColorTranslator.FromHtml("#2196f3"),
            ColorTranslator.FromHtml("#9ccc65"),
            ColorTranslator.FromHtml("#ef6c00"),
            ColorTranslator.FromHtml("#ff3d00")
        };
        #endregion

        #region Constructor
        public UclDashboard()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                g.Clear(this.BackColor);
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void createTable()
        {
            dgvTopCities.Rows.Clear();
            dgvTopCities.Columns.Clear();
            dgvTopCities.Columns.Add("id", "ID");
            dgvTopCities.Columns.Add("destination", "Destination");
            dgvTopCities.Columns.Add("count", "Count");
            dgvTopCities.Columns.Add("revenue", "Revenue");
            dgvTopCities.ForeColor = Color.Black;
            dgvTopCities.HeaderBgColor = Color.Teal;
            dgvTopCities.HeaderForeColor = Color.White;
            dgvTopCities.Columns[0].Visible = false;
            dgvTopCities.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTopCities.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTopCities.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region Events
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.White, Color.Gray);
        }
        #endregion


        private void UclDashboard_Load(object sender, EventArgs e)
        {
            createTable();
            piechart.Titles.Clear();
            piechart.Titles.Add("Top Flight Destination");
            piechart.Series[0].Points.Clear();
            piechart.Series.Clear();
            piechart.Series.Add("sr1");
            columnChart.Series[0].Points.Clear();
            columnChart.Series.Clear();
            columnChart.Series.Add("Revenue");
            columnchart2.Series[0].Points.Clear();
            columnchart2.Series.Clear();
            columnchart2.Series.Add("Count");
            piechart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            DataSet dsTopDestination = database.getDataFromDatabase("sp_view_dashboard_arrival_city", null);
            if(dsTopDestination.Tables.Count > 0)
            {
                if(dsTopDestination.Tables[0].Rows.Count > 0)
                {
                    for(int i = 0; i < dsTopDestination.Tables[0].Rows.Count; i++)
                    {
                        piechart.Series[0].Points.AddXY(
                            dsTopDestination.Tables[0].Rows[i][1].ToString(), 
                            dsTopDestination.Tables[0].Rows[i][2].ToString());
                        dgvTopCities.Rows.Add(
                            dsTopDestination.Tables[0].Rows[i][0].ToString(), 
                            dsTopDestination.Tables[0].Rows[i][1].ToString(), 
                            dsTopDestination.Tables[0].Rows[i][2].ToString(), 
                            Convert.ToDouble(dsTopDestination.Tables[0].Rows[i][3].ToString()).ToString("N"));
                        piechart.Series[0].Points[i].Color = pieColor[i];
                        piechart.Series[0].Points[i].BackSecondaryColor = pieSecondColor[i];
                    }

                    DataPoint datapoint = piechart.Series[0].Points[0];
                    selectPieData(datapoint, 0);
                    fillsubChart(dsTopDestination.Tables[0].Rows[0][0].ToString());
                    fillsubChart2(dsTopDestination.Tables[0].Rows[0][0].ToString());
                }
            }
        }

        private void fillsubChart(string cityID)
        {
            columnChart.Titles.Clear();
            columnChart.Titles.Add("Revenue departure city");
            columnChart.Series[0].Points.Clear();
            columnChart.Series.Clear();
            columnChart.Series.Add("Revenue");
            DataSet dsDepartureCity = database.getDataFromDatabase(
                "sp_view_dashboard_dpearture_city", 
                new List<Parameter> { new Parameter("@cityID", cityID) });
            if (dsDepartureCity.Tables.Count > 0)
            {
                if (dsDepartureCity.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDepartureCity.Tables[0].Rows.Count; i++)
                    {
                        columnChart.Series[0].Points.AddXY(
                            dsDepartureCity.Tables[0].Rows[0][0].ToString(),
                            dsDepartureCity.Tables[0].Rows[0][1].ToString()
                            );
                    }
                }
            }
        }

        private void fillsubChart2(string cityID)
        {
            columnchart2.Titles.Clear();
            columnchart2.Titles.Add("Count departure city");
            columnchart2.Series[0].Points.Clear();
            columnchart2.Series.Clear();
            columnchart2.Series.Add("Count");
            DataSet dsDepartureCity = database.getDataFromDatabase(
                "sp_view_dashboard_dpearture_city2",
                new List<Parameter> { new Parameter("@cityID", cityID) });
            if (dsDepartureCity.Tables.Count > 0)
            {
                if (dsDepartureCity.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDepartureCity.Tables[0].Rows.Count; i++)
                    {
                        columnchart2.Series[0].Points.AddXY(
                            dsDepartureCity.Tables[0].Rows[0][0].ToString(),
                            dsDepartureCity.Tables[0].Rows[0][1].ToString()
                            );
                    }
                }
            }
        }

        private void resetPointPieChart()
        {
            int countpoint = piechart.Series[0].Points.Count();
            for(int i = 0; i< countpoint; i++)
            {
                DataPoint dataPoint = piechart.Series[0].Points[i];
                dataPoint.BorderColor = Color.Black;
                dataPoint.BorderWidth = 0;
                if(haspoint == true && i == getpoint)
                {
                    Color tempColor = dataPoint.Color;
                    dataPoint.Color = dataPoint.BackSecondaryColor;
                    dataPoint.BackSecondaryColor = tempColor;
                    haspoint = false;
                }
            }
        }

        private void piechart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = piechart.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if(hit.PointIndex >= 0 && hit.Series != null)
            {
                resetPointPieChart();
                dgvTopCities.ClearSelection();
                DataPoint datapoint = piechart.Series[0].Points[hit.PointIndex];
                selectPieData(datapoint, hit.PointIndex);

                DataGridViewRow row = dgvTopCities.Rows[hit.PointIndex];
                row.Selected = true;
            }
        }

        private void selectPieData(DataPoint datapoint, int index)
        {
            datapoint.BorderWidth = 3;
            datapoint.BorderColor = Color.White;

            Color tempColor = datapoint.Color;
            datapoint.Color = datapoint.BackSecondaryColor;
            datapoint.BackSecondaryColor = tempColor;
            haspoint = true;
            getpoint = index;
            fillsubChart(dgvTopCities.Rows[index].Cells[0].Value.ToString());
            fillsubChart2(dgvTopCities.Rows[index].Cells[0].Value.ToString());
        }

        private void piechart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hit = piechart.HitTest(e.X, e.Y);
            DataPoint dp = hit.Object as DataPoint;
            Cursor = (dp != null) ? Cursors.Hand : Cursors.Arrow;
        }

        private void dgvTopCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvTopCities.CurrentRow;
                resetPointPieChart();

                DataPoint datapoint = piechart.Series[0].Points[e.RowIndex];
                selectPieData(datapoint, e.RowIndex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
