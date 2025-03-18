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
    public partial class DashboardAdmin : Form
    {
        private readonly DashboardDal _dashboardDal = new DashboardDal();
        public DashboardAdmin()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();


            //Servis Petugas
            LoadGridServisTerbanyak();
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
            gridServisTerbanyak.CellPainting += dataGridView1_CellPainting;
        }

        private void LoadGridServisTerbanyak()
        {
            var dataServis = _dashboardDal.ListServisTerbanyak()
                .Select( (x,index) => new
                {
                    No = index + 1,
                    Nama = x.nama_pelanggan,
                    Total = x.jumlah_servis
                }).ToList();
            gridServisTerbanyak.DataSource = dataServis;
        }

        private void StyleGrids()
        {
            //Grid Servis
            DataGridView gst = gridServisTerbanyak;
            CustomGrids.CustomDataGrid(gst);

            gst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gst.Columns["No"].FillWeight = 20;
            gst.Columns["Nama"].FillWeight = 50;
            gst.Columns["Total"].FillWeight = 30;

            gst.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            gst.Columns["No"].HeaderText = "    No";
            gst.Columns["Total"].HeaderText = "Total Servis";
            gst.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void SetTotalPendapatan()
        {
            //Petugas dulu
            DateTime tanggal1 = DateTime.Today;
            DateTime tanggal2 = DateTime.Today.AddDays(1).AddSeconds(-1);

            int pendapatan = _dashboardDal.GetPendapatan(tanggal1, tanggal2);

            //set to label
            lblPendapatan.Text = $"Rp {pendapatan:N2}";
        }

        private void SetCards()
        {
            /*//Petugas
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
            lblSparepart.Text = sparepartMenipisHabis.ToString();*/

        }

        private List<string> kolomTengah = new List<string> { "Total" };
        private void dataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Hindari header
            {
                string namaKolom = gridServisTerbanyak.Columns[e.ColumnIndex].Name;

                if (kolomTengah.Contains(namaKolom)) // Cek apakah kolom termasuk dalam daftar
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center; // Tengah horizontal
                        sf.LineAlignment = StringAlignment.Center; // Tengah vertikal

                        e.Graphics.DrawString(
                            e.FormattedValue?.ToString(),
                            e.CellStyle.Font,
                            new SolidBrush(e.CellStyle.ForeColor),
                            e.CellBounds,
                            sf
                        );
                    }

                    e.Handled = true; // Mencegah double painting
                }
            }
        }
    }
}

