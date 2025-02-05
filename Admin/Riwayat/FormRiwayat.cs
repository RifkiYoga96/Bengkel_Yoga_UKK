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
    public partial class FormRiwayat : Form
    {
        private readonly RiwayatDal _riwayatDal = new RiwayatDal();
        private byte[] _selesai = ImageConvert.ImageToByteArray(ImageConvert.ResizeImagePersentase(Properties.Resources.Selesai2,15));
        private byte[] _dibatalkan = ImageConvert.ImageToByteArray(ImageConvert.ResizeImagePersentase(Properties.Resources.Dibatalkan,15));
        public FormRiwayat()
        {
            InitializeComponent();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }

        private void RegisterEvent()
        {
            dataGridView1.CellPainting += DataGridView1_CellPainting;
        }


        #region DATAGRID
        private void CustomGrid()
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Mengatur ukuran font header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Mengatur warna header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ForeColor = Color.DimGray;


            // Menonaktifkan warna seleksi untuk sel
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.RowTemplate.Height = 55;

            dataGridView1.RowHeadersVisible = false;

            // Mencegah penggeseran kolom
            dataGridView1.AllowUserToOrderColumns = false;

            // Mencegah pengubahan ukuran kolom
            dataGridView1.AllowUserToResizeColumns = true;

            // Mencegah pengubahan ukuran baris
            dataGridView1.AllowUserToResizeRows = false;

            // Mencegah penambahan baris baru
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns["id_riwayat"].Width = 10;
            dataGridView1.Columns["No"].Width = 70;
            dataGridView1.Columns["ktp_pelanggan"].Width = 200;
            dataGridView1.Columns["Pelanggan"].Width = 200;
            dataGridView1.Columns["no_pol"].Width = 170;
            dataGridView1.Columns["Kendaraan"].Width = 200;
            dataGridView1.Columns["Keluhan"].Width = 250;
            dataGridView1.Columns["Tanggal"].Width = 200;
            dataGridView1.Columns["Pegawai"].Width = 200;
            dataGridView1.Columns["Catatan"].Width = 200;
            dataGridView1.Columns["Sparepart"].Width = 250;
            dataGridView1.Columns["total_harga"].Width = 180;
            dataGridView1.Columns["Status"].Width = 150;

            dataGridView1.Columns["id_riwayat"].Visible = false;

            dataGridView1.Columns["No"].Frozen = true;
            dataGridView1.Columns["ktp_pelanggan"].Frozen = true;
            dataGridView1.Columns["Pelanggan"].Frozen = true;

            dataGridView1.Columns["id_riwayat"].DefaultCellStyle.Padding = new Padding(0,0,0,0);
            dataGridView1.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["ktp_pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Kendaraan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["no_pol"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Keluhan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Tanggal"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Pegawai"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Catatan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Sparepart"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["total_harga"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Status"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            dataGridView1.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["ktp_pelanggan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["no_pol"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Keluhan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Catatan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Sparepart"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Status"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["ktp_pelanggan"].HeaderText = "KTP Pelanggan";
            dataGridView1.Columns["total_harga"].HeaderText = "Total Harga";
            dataGridView1.Columns["no_pol"].HeaderText = "Nomor Polisi";
        }
        private void LoadData()
        {
            int i = 1;
            var listSparepart = _riwayatDal.ListDataSparepart();
            var list = _riwayatDal.ListData()
                .Select(x => new RiwayatDto{
                    No = i++,
                    id_riwayat = x.id_riwayat,
                    ktp_pelanggan = x.ktp_pelanggan,
                    Pelanggan = x.nama_pelanggan,
                    no_pol = x.no_pol,
                    Kendaraan = $"{x.merk} {x.tipe} {x.kapasitas} ({x.tahun})",
                    Keluhan = x.keluhan,
                    Tanggal = x.tanggal,
                    Pegawai = x.nama_admin,
                    Catatan = x.catatan,
                    Sparepart = string.Join(", ",listSparepart.Where(a => a.id_riwayat == x.id_riwayat).Select(a => a.nama_sparepart)),
                    total_harga = x.total_harga,
                    Status = x.status == "selesai" ? _selesai : _dibatalkan
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<RiwayatDto>(list);
        }

        private void DataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0) // Hanya proses header kolom
            {
                // Gambar latar belakang header default
                e.PaintBackground(e.CellBounds, true);

                // Tambahkan padding ke teks header
                Rectangle paddedBounds = e.CellBounds;
                paddedBounds.X += 20; // Padding kiri 20 piksel
                paddedBounds.Width -= 20; // Sesuaikan lebar setelah padding

                // Gambar teks header dengan padding
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, paddedBounds, e.CellStyle.ForeColor, flags);

                // Jika kolom sedang diurutkan, gambar panah
                if (dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    int arrowWidth = 10; // Lebar panah (ukuran kecil)
                    int arrowHeight = 10; // Tinggi panah (ukuran kecil)
                    int textWidth = TextRenderer.MeasureText(e.FormattedValue.ToString(), e.CellStyle.Font).Width;
                    int arrowX = paddedBounds.Left + textWidth + 2; // Jarak antara teks dan panah (gunakan paddedBounds)
                    int arrowY = e.CellBounds.Top + (e.CellBounds.Height - arrowHeight) / 2; // Posisi vertikal tengah

                    using (var sortGlyph = CreateSortGlyph(dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection))
                    {
                        // Aktifkan interpolasi berkualitas tinggi
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        // Gambar panah dengan ukuran yang disesuaikan
                        e.Graphics.DrawImage(sortGlyph, arrowX, arrowY, arrowWidth, arrowHeight);
                    }
                }

                if (e.RowIndex == -1 && e.ColumnIndex >= 0) // Hanya proses header kolom
                {
                    // Daftar kolom yang ingin diterapkan CellPainting
                    string[] targetColumns = { "Status" };

                    // Periksa apakah kolom saat ini termasuk dalam daftar target
                    if (targetColumns.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
                    {
                        // Gambar latar belakang header default
                        e.PaintBackground(e.CellBounds, true);

                        // Gambar teks header dengan alignment tengah
                        TextFormatFlags flagss = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                        TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, flagss);

                        e.Handled = true; // Tandai event sebagai sudah dihandle
                    }
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["NO"].Value = i + 1;
                }
                e.Handled = true; // Tandai event sebagai sudah dihandle
            }
        }

        private Bitmap CreateSortGlyph(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
                return (Bitmap)Properties.Resources.ArrowUp;
            else
                return (Bitmap)Properties.Resources.ArrowDown;

        }
        #endregion
    }
}
