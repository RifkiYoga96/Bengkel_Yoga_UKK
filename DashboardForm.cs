
using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class DashboardForm : Form
    {
        private DataTable dataTable = new DataTable();
        public DashboardForm()
        {
            InitializeComponent();
            InitComponen();
            InitChart();
        }
        private void InitChart()
        {
            // Tambahkan series
            ChartSeries series = new ChartSeries();
            series.Name = "Series1";
            series.Type = ChartSeriesType.Line;
            chartControl1.Series.Add(series);

            chartControl1.Legend.Visible = false;
        }
        private void InitComponen()
        {
           
        }

        private void AddDataTable(int id, string nama, string alamat, string no_telp)
        {
            dataTable.Rows.Add(id,nama,alamat,no_telp);
        }
    }
}
