using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            LoadGridServis();
            StyleGrids();
            SetTotalPendapatan();
            SetCards();
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


        private void LoadGridServis()
        {
            var dataServis = _dashboardDal.ListDataServis()
                .Select(x => new
                {
                    Antrean = (x.tipe_antrean == 1 ? "A" : "B") + (x.antrean.ToString("D3")),
                    Nama = x.nama_pelanggan,
                    Kendaraan = x.nama_kendaraan
                }).ToList();
            gridServisToday.DataSource = dataServis;
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

        }

        private void SetTotalPendapatan()
        {
            //Petugas dulu
            DateTime tanggal1 = DateTime.Today;
            DateTime tanggal2 = DateTime.Today.AddDays(1).AddSeconds(-1);

            int pendapatan = _dashboardDal.GetPendapatan(tanggal1,tanggal2);

            //set to label
            lblPendapatan.Text = $"Rp {pendapatan:N2}";
        }

        private void SetCards()
        {
            //Petugas
            DateTime tanggal1 = DateTime.Today;
            DateTime tanggal2 = DateTime.Today.AddDays(1).AddSeconds(-1);

            //Booking Card
            int jumlahBookingToday = _dashboardDal.GetJumlahBooking(tanggal1, tanggal2);
            lblBooking.Text = jumlahBookingToday.ToString();

            //Servis Card
            int bookingBelumDitangani = _dashboardDal.GetBookingBelumDitangani(tanggal1, tanggal2);
            lblServis.Text = bookingBelumDitangani.ToString();

            //Sparepart Meipis
            int sparepartMenipisHabis = _dashboardDal.GetSparepartMenipisHabis();
            lblSparepart.Text = sparepartMenipisHabis.ToString();

        }
    }
}

