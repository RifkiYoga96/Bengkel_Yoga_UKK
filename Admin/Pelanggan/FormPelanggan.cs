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
    public partial class FormPelanggan : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        public FormPelanggan()
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

        #region DATA GRID
        private void LoadData()
        {
            int no = 1;
            var list = _pelangganDal.ListData()
                .Select(x => new PelangganModel()
                {
                   No = no++,
                   ktp_pelanggan = x.ktp_pelanggan,
                   nama_pelanggan = x.nama_pelanggan,
                   email = x.email,
                   password = x.password,
                   alamat = x.alamat,
                   no_telp = x.no_telp
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<PelangganModel>(list);
        }

        private void CustomGrid()
        {
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["No"].FillWeight = 6;
            dgv.Columns["ktp_pelanggan"].FillWeight = 13;
            dgv.Columns["nama_pelanggan"].FillWeight = 18;
            dgv.Columns["email"].FillWeight = 17;
            dgv.Columns["password"].FillWeight = 14;
            dgv.Columns["alamat"].FillWeight = 18;
            dgv.Columns["no_telp"].FillWeight = 14;

            dgv.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["ktp_pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["nama_pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["email"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["password"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["alamat"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["no_telp"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);


            dgv.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["ktp_pelanggan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["password"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["no_telp"].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                    string[] targetColumns = {  };

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
