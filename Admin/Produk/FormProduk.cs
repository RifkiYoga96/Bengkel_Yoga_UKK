using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Core.Enums;
using Syncfusion.WinForms.Controls;
using static Syncfusion.Windows.Forms.Tools.MenuDropDown;
using Syncfusion.Windows.Forms.Tools.Win32API;

namespace Bengkel_Yoga_UKK
{
    public partial class FormProduk : Form
    {
        private BindingSource _bindingSource = new BindingSource();

        private readonly ProdukDal _produkDal = new ProdukDal();
        private int page = 1;
        Bitmap bitmap;
        public FormProduk()
        {
            InitializeComponent();
            LoadData();
            InitCombo();
            CostumGrid();
            //ImageGrid();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnAddData.Click += BtnAddData_Click; ;

            btnSearch.Click += BtnSearch_Click;
        }


        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            new FormInputProduk().ShowDialog();
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
        private void CostumGrid()
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

            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["NO"].FillWeight = 6;
            dataGridView1.Columns["KODE_SPAREPART"].FillWeight = 8;
            dataGridView1.Columns["GAMBAR"].FillWeight = 10;
            dataGridView1.Columns["PRODUK"].FillWeight = 25;
            dataGridView1.Columns["HARGA"].FillWeight = 15;
            dataGridView1.Columns["STOK"].FillWeight = 10;
            dataGridView1.Columns["STOK_MINIMUM"].FillWeight = 10;
            dataGridView1.Columns["KETERANGAN_STOK"].FillWeight = 16;

            dataGridView1.Columns["NO"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["KODE_SPAREPART"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["GAMBAR"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dataGridView1.Columns["PRODUK"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["HARGA"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["STOK"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dataGridView1.Columns["STOK_MINIMUM"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dataGridView1.Columns["KETERANGAN_STOK"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            dataGridView1.Columns["GAMBAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["STOK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["STOK_MINIMUM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["KODE_SPAREPART"].HeaderText = "KODE";
            dataGridView1.Columns["KETERANGAN_STOK"].HeaderText = "KETERANGAN";
            dataGridView1.Columns["STOK_MINIMUM"].HeaderText = "STOK MINIMUM";

            dataGridView1.Columns["PRODUK"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["STOK"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["HARGA"].SortMode = DataGridViewColumnSortMode.Automatic;
        }


        private void LoadData()
        {
            /*var list = _produkDal.ListData()
                .Select();*/
        }

        private SortableBindingList<ProdukModelS> GetData()
        {
            byte[] ban1 = ImageConvert.ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\IRC NR72.jpg", 55, 55);
            byte[] ban2 = ImageConvert.ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\IRC SCT-004.jpg", 55, 55);
            byte[] velg = ImageConvert.ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\velg.jpeg", 55, 55);
            byte[] rcb = ImageConvert.ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\rcb.jpg", 55, 55);
            byte[] spion = ImageConvert.ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\Spion.jpg", 55, 55);
            byte[] habis = ImageConvert.ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Habis.png", 15);
            byte[] menipis = ImageConvert.ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Menipis.png", 15);
            byte[] tersedia = ImageConvert.ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Tersedia.png", 15);

            // Path gambar yang akan digunakan
            string pandingImg = @"D:\APenyimpanan\BENGKEL - UKK\Panding.png";
            string selesaiImg = @"D:\APenyimpanan\BENGKEL - UKK\selesai.png";

            // Ubah ukuran gambar menjadi maksimal 100x100
            Image originalImage = Image.FromFile(pandingImg);
            Image resizedImage = ImageConvert.ResizeImagePersentase(originalImage, 15); // Ubah ukuran gambar

            Image selesaiImageOri = Image.FromFile(selesaiImg);
            Image resizeSelesai = ImageConvert.ResizeImagePersentase(selesaiImageOri, 15);

            // Konversi gambar yang sudah diubah ukurannya ke byte[]
            byte[] pandingBytes = ImageConvert.ImageToByteArray(resizedImage);
            byte[] selesaiBytes = ImageConvert.ImageToByteArray(resizeSelesai);

            return new SortableBindingList<ProdukModelS>
                {
                    new ProdukModelS { NO = 1, KODE_SPAREPART = "PF01", GAMBAR = rcb, PRODUK = "Ban Motor RCB", STOK = 20,STOK_MINIMUM = 15, HARGA = "Rp 220.000",KETERANGAN_STOK = tersedia },
                    new ProdukModelS { NO = 2, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor IRC DELPHI", STOK = 0,STOK_MINIMUM=15, HARGA = "Rp 300.000", KETERANGAN_STOK = habis },
                    new ProdukModelS { NO = 3, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Ban Motor CDA DELVIRO", STOK = 11,STOK_MINIMUM=20, HARGA = "Rp 450.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 4, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Ban Motor IRC TUNA", STOK = 5,STOK_MINIMUM=15, HARGA = "Rp 190.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 5, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor ASC SORTIR", STOK = 23,STOK_MINIMUM=20, HARGA = "Rp 240.000",KETERANGAN_STOK=tersedia },
                    new ProdukModelS { NO = 6, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Spion LowASC", STOK = 20,STOK_MINIMUM=15, HARGA = "Rp 89.000",KETERANGAN_STOK=tersedia },
                    new ProdukModelS { NO = 7, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor IRC MOBONG", STOK = 20,STOK_MINIMUM=30, HARGA = "Rp 520.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 8, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Velg LUCAS EMBE", STOK = 55,STOK_MINIMUM=30, HARGA = "Rp 1.200.000",KETERANGAN_STOK=tersedia },
                    new ProdukModelS { NO = 9, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Ban Motor CDA DELVIRO", STOK = 11,STOK_MINIMUM=20, HARGA = "Rp 450.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 10, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Ban Motor IRC TUNA", STOK = 5,STOK_MINIMUM=15, HARGA = "Rp 190.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 11, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor ASC SORTIR", STOK = 23,STOK_MINIMUM=20, HARGA = "Rp 240.000",KETERANGAN_STOK=tersedia },
                    new ProdukModelS { NO = 12, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Spion LowASC", STOK = 20,STOK_MINIMUM=15, HARGA = "Rp 89.000",KETERANGAN_STOK=tersedia },
                    new ProdukModelS { NO = 13, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor IRC MOBONG", STOK = 20,STOK_MINIMUM=30, HARGA = "Rp 520.000",KETERANGAN_STOK=menipis },
                    new ProdukModelS { NO = 14, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Velg LUCAS EMBE", STOK = 55,STOK_MINIMUM=30, HARGA = "Rp 1.200.000",KETERANGAN_STOK=tersedia },
                };
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
                    string[] targetColumns = { "statusImg" };

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


        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            // Ukuran asli panel
            int originalWidth = yogaPanel1.Width;
            int originalHeight = yogaPanel1.Height;

            // Skala yang diinginkan (misalnya, 50% dari ukuran asli)
            float scaleFactor = 0.5f;
            int newWidth = (int)(originalWidth * scaleFactor);
            int newHeight = (int)(originalHeight * scaleFactor);

            // Buat bitmap dengan ukuran asli panel
            using (Bitmap originalBitmap = new Bitmap(originalWidth, originalHeight))
            {
                using (Graphics g = Graphics.FromImage(originalBitmap))
                {
                    // Menangkap seluruh isi panel (termasuk yang tidak terlihat di viewport)
                    g.CopyFromScreen(yogaPanel1.PointToScreen(Point.Empty), Point.Empty, new Size(originalWidth, originalHeight));
                }

                // Resize gambar ke ukuran lebih kecil
                bitmap = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(originalBitmap, new Rectangle(0, 0, newWidth, newHeight));
                }
            }

            // Hubungkan dokumen ke PrintPreview
            printDocument1.PrintPage -= printDocument1_PrintPage; // Hindari event berulang
            printDocument1.PrintPage += printDocument1_PrintPage;
            printPreviewDialog1.Document = printDocument1;

            // Tampilkan preview cetak
            printPreviewDialog1.ShowDialog();
        }


        private Size GetScaledSize(int originalWidth, int originalHeight, int maxSize)
        {
            float scale = Math.Min((float)maxSize / originalWidth, (float)maxSize / originalHeight);
            return new Size((int)(originalWidth * scale), (int)(originalHeight * scale));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (bitmap != null)
            {
                // Cetak gambar dengan ukuran yang sudah di-scaling
                e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            }
        }
    }
}