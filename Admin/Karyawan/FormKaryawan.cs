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
    public partial class FormKaryawan : Form
    {
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private int page = 1;
        private byte[] _defaultProfile = ImageDirectory._defaultProfile;
        public FormKaryawan()
        {
            InitializeComponent();
            RegisterEvent();
            InitCombo();

            LoadData();
            CustomGrid();
        }
        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnAddData.Click += BtnAddData_Click;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            
        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string ktp_admin = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
            if (new FormInputKaryawan(ktp_admin, false).ShowDialog() != DialogResult.OK) return;
        }

        private void DataGridView1_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            new FormInputKaryawan("",true).ShowDialog();
        }

        private void BtnPrevious_Click(object? sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
            }
            lblHalaman.Text = page.ToString();
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (page <= 10)
            {
                page++;
            }
            lblHalaman.Text = page.ToString();
        }
        #region COMBO BOX
        private void InitCombo()
        {
            List<string> list = new List<string>()
            {
                "Semua (All)","Stok Tersedia","Stok Menipis","Stok Habis"
            };
            comboFilter.DataSource = list;
        }
        #endregion

        #region DATAGRID
        private void CustomGrid()
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Mengatur ukuran font header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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

            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["No"].FillWeight = 6;
            dataGridView1.Columns["ktp_admin"].FillWeight = 9;
            dataGridView1.Columns["Foto"].FillWeight = 10;
            dataGridView1.Columns["Nama"].FillWeight = 16;
            dataGridView1.Columns["Email"].FillWeight = 15;
            dataGridView1.Columns["Password"].FillWeight = 10;
            dataGridView1.Columns["Telepon"].FillWeight = 12;
            dataGridView1.Columns["Alamat"].FillWeight = 12;
            dataGridView1.Columns["Role"].FillWeight = 10;

            dataGridView1.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["ktp_admin"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Foto"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dataGridView1.Columns["Nama"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Email"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Password"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Telepon"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Alamat"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["Role"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            dataGridView1.Columns["Foto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Role"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["ktp_admin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Password"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Telepon"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Role"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["ktp_admin"].HeaderText = "No KTP";
        }


        private void LoadData()
        {
            int number = 1;
            var list = _karyawanDal.ListData()
                .Select(x => new KaryawanDto()
                {
                    No = number ++,
                    ktp_admin = x.ktp_admin,
                    Foto = x.image_data != null ? ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(ImageConvert.CropToCircle(ImageConvert.ResizeImageMax(ImageConvert.Image_ByteToImage(x.image_data),400,400)), 45,45)) 
                        : _defaultProfile,
                    Nama = x.nama_admin,
                    Email = x.email,
                    Password = x.password,
                    Telepon = x.no_telp,
                    Alamat = x.alamat,
                    Role = x.role==1 ? "Petugas" : "Super Admin",
                }).ToList();
            dataGridView1.DataSource = new SortableBindingList<KaryawanDto>(list);
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
                    string[] targetColumns = { "Foto","Role" };

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

public class KaryawanDto
{
    public int No { get; set; }
    public string ktp_admin { get; set; }
    public byte[] Foto { get; set; }
    public string Nama { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telepon { get; set; }
    public string Alamat { get; set; }
    public string Role { get; set; }
}