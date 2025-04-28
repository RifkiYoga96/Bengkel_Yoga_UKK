using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class DashboardPetugas : Form
    {
        private readonly DashboardDal _dashboardDal = new DashboardDal();
        public DashboardPetugas()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();


            //Servis Petugas
            SetCards();
            StyleGrids();
        }

        private void InitComponent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            yogaPanel2.Resize += (s, e) => yogaPanel2.Invalidate();
            yogaPanel3.Resize += (s, e) => yogaPanel3.Invalidate();
            yogaPanel5.Resize += (s, e) => yogaPanel5.Invalidate();
        }

        private void RegisterEvent()
        {
            btnViewBooking.Click += BtnViewBooking_Click;
        }

        private void BtnViewBooking_Click(object? sender, EventArgs e)
        {
            //MainFormAdmin._mainForm.
        }

        private void StyleGrids()
        {
            //Grid Servis
            DataGridView gst = gridServisToday;
            CustomGrids.CustomDataGrid(gst);

            gst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gst.Columns["Antrean"].FillWeight = 25;
            gst.Columns["Nama"].FillWeight = 35;
            gst.Columns["Kendaraan"].FillWeight = 40;

            gst.Columns["Antrean"].DefaultCellStyle.Padding = new Padding(20,0,0,0);
            gst.Columns["Antrean"].HeaderText = "    Antrean";


            DataGridView gs = gridSparepart;
            CustomGrids.CustomDataGrid(gs);

            gs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gs.Columns["No"].FillWeight = 15;
            gs.Columns["Kode"].FillWeight = 20;
            gs.Columns["Nama"].FillWeight = 25;
            gs.Columns["TotalPenjualan"].FillWeight = 20;
            gs.Columns["Terjual"].FillWeight = 20;

            gs.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            gs.Columns["TotalPenjualan"].HeaderText = "    Total Penjualan";

        }

        private void SetCards()
        {
            DateTime tanggal1 = DateTime.Today;
            DateTime tanggal2 = DateTime.Today.AddDays(1).AddSeconds(-1);

            //Booking Card
            int jumlahBookingToday = _dashboardDal.GetJumlahBooking(tanggal1, tanggal2);
            lblBooking.Text = jumlahBookingToday.ToString();

            //Servis Pending
            int bookingBelumDitangani = _dashboardDal.GetBookingBelumDitangani(tanggal1, tanggal2);
            lblServis.Text = bookingBelumDitangani.ToString();

            //Servis Selesai
            int servisSelesai = _dashboardDal.GetServisSelesai(tanggal1, tanggal2);
            lblServisSelesai.Text = servisSelesai.ToString();

            //Pendapatan
            int pendapatan = _dashboardDal.GetPendapatan(tanggal1, tanggal2);
            lblPendapatan.Text = $"Rp {pendapatan:N2}";

            //Servis Hari Ini
            var dataServis = _dashboardDal.ListDataServis()
                .Select(x => new
                {
                    Antrean = (x.tipe_antrean == 1 ? "A" : "B") + (x.antrean.ToString("D3")),
                    Nama = x.nama_pelanggan,
                    Kendaraan = x.nama_kendaraan
                }).ToList();
            gridServisToday.DataSource = dataServis;

            //Penjualan Sparepart Hari Ini
            //Penjualan Sparepart
            var dataPenjualan = _dashboardDal.ListPenjualanSparepart(tanggal1, tanggal2)
                .Select((x, index) => new
                {
                    No = index + 1,
                    Kode = x.kode_sparepart,
                    Nama = x.nama_sparepart,
                    TotalPenjualan = x.total_penjualan.ToString("C", new CultureInfo("id-ID")),
                    Terjual = x.jumlah_penjualan
                }).ToList();
            gridSparepart.DataSource = dataPenjualan;
        }
    }
}

