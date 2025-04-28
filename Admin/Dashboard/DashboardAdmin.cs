using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class DashboardAdmin : Form
    {
        private readonly DashboardDal _dashboard = new DashboardDal();
        public DashboardAdmin()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();

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
            gridServisTerbanyak.CellPainting += dataGridView1_CellPainting;

            radioHariIni.CheckedChanged += (s, e) => GetRangeWaktu();
            radioKemarin.CheckedChanged += (s, e) => GetRangeWaktu();
            radio7H.CheckedChanged += (s, e) => GetRangeWaktu();
            radio30H.CheckedChanged += (s, e) => GetRangeWaktu();
            radio90H.CheckedChanged += (s, e) => GetRangeWaktu();

            radio30H.Checked = true;

            btnBatasBooking.Click += (s, e) => new FormBatasBooking().ShowDialog();
            btnJadwal.Click += (s, e) => new FormJadwal().ShowDialog();
        }

        private void StyleGrids()
        {
            //Grid Servis
            CustomGrids.CustomDataGrid(gridServisTerbanyak);

            gridServisTerbanyak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridServisTerbanyak.ColumnHeadersHeight = 40;
            gridServisTerbanyak.RowTemplate.Height = 50;

            gridServisTerbanyak.Columns["No"].FillWeight = 20;
            gridServisTerbanyak.Columns["Nama"].FillWeight = 50;
            gridServisTerbanyak.Columns["Total"].FillWeight = 30;

            gridServisTerbanyak.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            gridServisTerbanyak.Columns["No"].HeaderText = "    No";
            gridServisTerbanyak.Columns["Total"].HeaderText = "Total Servis";
            gridServisTerbanyak.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Grid Sparepart
            CustomGrids.CustomDataGrid(gridPenjualanSparepart);
            gridPenjualanSparepart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridPenjualanSparepart.ColumnHeadersHeight = 40;
            gridPenjualanSparepart.RowTemplate.Height = 50;

            gridPenjualanSparepart.Columns["No"].FillWeight = 10;
            gridPenjualanSparepart.Columns["Kode"].FillWeight = 20;
            gridPenjualanSparepart.Columns["Nama"].FillWeight = 30;
            gridPenjualanSparepart.Columns["TotalPenjualan"].FillWeight = 20;
            gridPenjualanSparepart.Columns["Terjual"].FillWeight = 20;

            gridPenjualanSparepart.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            gridPenjualanSparepart.Columns["No"].HeaderText = "    No";
            gridPenjualanSparepart.Columns["TotalPenjualan"].HeaderText = "Total Penjualan";
            gridPenjualanSparepart.Columns["Terjual"].HeaderText = "          Terjual";
            gridPenjualanSparepart.Columns["Terjual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void GetRangeWaktu()
        {
            DateTime now = DateTime.Now;
            var listFilterWaktu = new List<FilterWaktu>()
            {
                new FilterWaktu { nama = "Hari Ini", waktu1 = now.Date, waktu2 = now.Date.AddDays(1).AddSeconds(-1) },
                new FilterWaktu { nama = "Kemarin", waktu1 = now.Date.AddDays(-1), waktu2 = now.Date.AddSeconds(-1) },
                new FilterWaktu { nama = "7 Hari Lalu", waktu1 = now.Date.AddDays(-6), waktu2 = now.Date.AddDays(1).AddSeconds(-1) },
                new FilterWaktu { nama = "30 Hari Lalu", waktu1 = now.Date.AddDays(-29), waktu2 = now.Date.AddDays(1).AddSeconds(-1) },
                new FilterWaktu { nama = "90 Hari Lalu", waktu1 = now.Date.AddDays(-89), waktu2 = now.Date.AddDays(1).AddSeconds(-1) }
            };

            if (radioHariIni.Checked)
                LoadAdmin(listFilterWaktu[0].waktu1, listFilterWaktu[0].waktu2, listFilterWaktu[0].nama);
            else if(radioKemarin.Checked)
                LoadAdmin(listFilterWaktu[1].waktu1, listFilterWaktu[1].waktu2, listFilterWaktu[1].nama);
            else if (radio7H.Checked)
                LoadAdmin(listFilterWaktu[2].waktu1, listFilterWaktu[2].waktu2, listFilterWaktu[2].nama);
            else if(radio30H.Checked)
                LoadAdmin(listFilterWaktu[3].waktu1, listFilterWaktu[3].waktu2, listFilterWaktu[3].nama);
            else
                LoadAdmin(listFilterWaktu[4].waktu1, listFilterWaktu[4].waktu2, listFilterWaktu[4].nama);
        }

        private void LoadAdmin(DateTime tgl1, DateTime tgl2, string keterangan)
        {
            //Booking Card
            int jumlahBookingToday = _dashboard.GetJumlahBooking(tgl1, tgl2);
            lblBooking.Text = jumlahBookingToday.ToString();
            lblKetBooking.Text = "Jumlah Booking " + keterangan; 

            //Pelanggan Card
            int pelangganBaru = _dashboard.GetPelangganBaru(tgl1, tgl2);
            lblTotalPelanggan.Text = pelangganBaru.ToString();
            lblKetPelanggan.Text = "Pelanggan Baru " + keterangan;

            //Sparepart Meipis
            int sparepartMenipisHabis = _dashboard.GetSparepartMenipisHabis();
            lblSparepart.Text = sparepartMenipisHabis.ToString();

            //Pendapatan
            int pendapatan = _dashboard.GetPendapatan(tgl1, tgl2);
            lblPendapatan.Text = $"Rp {pendapatan:N2}";
            lblKetPendapatan.Text = "PENDAPATAN " + keterangan.ToUpper();

            //Servis Terbanyak
            var dataServis = _dashboard.ListServisTerbanyak(tgl1, tgl2)
                .Select((x, index) => new
                {
                    No = index + 1,
                    Nama = x.nama_pelanggan, 
                    Total = x.jumlah_servis
                }).ToList();
            gridServisTerbanyak.DataSource = dataServis;

            //Penjualan Sparepart
            var dataPenjualan = _dashboard.ListPenjualanSparepart(tgl1,tgl2)
                .Select((x,index) => new
                {
                    No = index + 1,
                    Kode = x.kode_sparepart,
                    Nama = x.nama_sparepart,
                    TotalPenjualan = x.total_penjualan.ToString("C", new CultureInfo("id-ID")),
                    Terjual = x.jumlah_penjualan
                }).ToList();
            gridPenjualanSparepart.DataSource = dataPenjualan;
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

