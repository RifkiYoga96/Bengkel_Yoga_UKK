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

namespace Bengkel_Yoga_UKK
{
    public partial class Tabel : Form
    {
        private int page = 1;
        public Tabel()
        {
            InitializeComponent();
            InitDataGrid();
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
            if(page <= 10)
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
                "Semua (All)","Stok Tersedia","Stok Habis"
            };
            comboBox1.DataSource = list;


        }
        #endregion

        #region DATAGRID
        private void CostumGrid()
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["NO"].FillWeight = 6;
            dataGridView1.Columns["KODE_SPAREPART"].FillWeight = 8;
            dataGridView1.Columns["GAMBAR"].FillWeight = 15;
            dataGridView1.Columns["PRODUK"].FillWeight = 30;
            dataGridView1.Columns["HARGA"].FillWeight = 15;
            dataGridView1.Columns["STOK"].FillWeight = 10;
            dataGridView1.Columns["KETERANGAN_STOK"].FillWeight = 16;

            dataGridView1.Columns["KODE_SPAREPART"].HeaderText = "KODE";
            dataGridView1.Columns["GAMBAR"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           



            // Mengatur ukuran font header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Mengatur warna header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 134, 171); // Warna background header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;    // Warna teks header
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 171); // Warna saat header "terselect"
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;      // Warna teks saat header "terselect"
            dataGridView1.ForeColor = Color.DimGray;


            // Menonaktifkan warna seleksi untuk sel
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.RowTemplate.Height = 55;

            dataGridView1.RowHeadersVisible = false;

            // Mencegah penggeseran kolom
            dataGridView1.AllowUserToOrderColumns = false;

            // Mencegah pengubahan ukuran kolom
            dataGridView1.AllowUserToResizeColumns = false;

            // Mencegah pengubahan ukuran baris
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            
            dataGridView1.DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dataGridView1.DataBindingComplete += (s, e) =>
            {
                //dataGridView1.Rows[2].Cells[2].Style = new DataGridViewCellStyle();
                //dataGridView1.Rows[2].Cells[3].Style.ForeColor = Color.Red;
                //dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
            };

            dataGridView1.Columns["PRODUK"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["STOK"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["HARGA"].SortMode = DataGridViewColumnSortMode.Automatic;
        }


        private void InitDataGrid()
        {
            // Add data to DataGridView
            dataGridView1.DataSource = GetData();
        }

        private SortableBindingList<DataItem> GetData()
        {
            byte[] ban1 = ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\IRC NR72.jpg");
            byte[] ban2 = ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\IRC SCT-004.jpg");
            byte[] velg = ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\velg.jpeg");
            byte[] spion = ImageToByteMaxSize(@"D:\APenyimpanan\BENGKEL - UKK\Spion.jpg");
            byte[] habis = ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Habis.png", 15);
            byte[] menipis = ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Menipis.png", 15);
            byte[] tersedia = ImageToBytePercent(@"D:\APenyimpanan\BENGKEL - UKK\Image\Tersedia.png", 15);

            // Path gambar yang akan digunakan
            string pandingImg = @"D:\APenyimpanan\BENGKEL - UKK\Panding.png";
            string selesaiImg = @"D:\APenyimpanan\BENGKEL - UKK\selesai.png";

            // Ubah ukuran gambar menjadi maksimal 100x100
            Image originalImage = Image.FromFile(pandingImg);
            Image resizedImage = ResizeImagePersentase(originalImage, 15); // Ubah ukuran gambar

            Image selesaiImageOri = Image.FromFile(selesaiImg);
            Image resizeSelesai = ResizeImagePersentase(selesaiImageOri, 15);

            // Konversi gambar yang sudah diubah ukurannya ke byte[]
            byte[] pandingBytes = ImageToByteArray(resizedImage);
            byte[] selesaiBytes = ImageToByteArray(resizeSelesai);

            return new SortableBindingList<DataItem>
                {
                    new DataItem { NO = 1, KODE_SPAREPART = "PF01", GAMBAR = ban1, PRODUK = "Ban Motor IRC DELVIRO", STOK = "20", HARGA = "Rp 220.000",KETERANGAN_STOK = tersedia },
                    new DataItem { NO = 2, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor IRC DELPHI", STOK = "0", HARGA = "Rp 300.000", KETERANGAN_STOK = habis },
                    new DataItem { NO = 3, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Ban Motor CDA DELVIRO", STOK = "11", HARGA = "Rp 450.000",KETERANGAN_STOK=menipis },
                    new DataItem { NO = 4, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Ban Motor IRC TUNA", STOK = "5", HARGA = "Rp 190.000",KETERANGAN_STOK=menipis },
                    new DataItem { NO = 5, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor ASC SORTIR", STOK = "23", HARGA = "Rp 240.000",KETERANGAN_STOK=tersedia },
                    new DataItem { NO = 6, KODE_SPAREPART = "PF01", GAMBAR = spion, PRODUK = "Spion LowASC", STOK = "20", HARGA = "Rp 89.000",KETERANGAN_STOK=tersedia },
                    new DataItem { NO = 7, KODE_SPAREPART = "PF01", GAMBAR = ban2, PRODUK = "Ban Motor IRC MOBONG", STOK = "20", HARGA = "Rp 520.000",KETERANGAN_STOK=tersedia },
                    new DataItem { NO = 8, KODE_SPAREPART = "PF01", GAMBAR = velg, PRODUK = "Velg LUCAS EMBE", STOK = "55", HARGA = "Rp 1.200.000",KETERANGAN_STOK=tersedia },
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
                    string[] targetColumns = { "GAMBAR" };

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

                e.Handled = true; // Tandai event sebagai sudah dihandle
            }
        }
        private Bitmap CreateSortGlyph(SortOrder sortOrder)
        {
            /* if (sortOrder == SortOrder.Ascending)
                 return Properties.Resources.Arroww; // Gambar panah ke atas dari resource
             else
                 return Properties.Resources.ArrowUpL; // Gambar panah ke bawah dari resource*/

            if (sortOrder == SortOrder.Ascending)
                return (Bitmap)Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\ArrowDownKotak4.png");
            else
                return (Bitmap)Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\ArrowUpKotak4.png");
        }
        #endregion

        #region IMAGE
        public Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            // Hitung rasio aspek gambar
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY); // Gunakan rasio yang lebih kecil untuk mempertahankan aspek rasio

            // Hitung ukuran baru
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Buat gambar baru dengan ukuran yang diubah
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Kualitas tinggi
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public Image ResizeImagePersentase(Image image, int persentase)
        {
            double persen = (double)persentase / 100;
            // Hitung rasio aspek gambar
            double ratioX = image.Width * persen;
            double ratioY = image.Height * persen;

            // Hitung ukuran baru
            int newWidth = (int)Math.Round(ratioX);
            int newHeight = (int)Math.Round(ratioY);

            // Buat gambar baru dengan ukuran yang diubah
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Kualitas tinggi
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private byte[] ImageToByteMaxSize(string imgDirectory)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImage(image, 55, 55);
            byte[] byteimg = ImageToByteArray(imageResize);
            return byteimg;
        }
        private byte[] ImageToBytePercent(string imgDirectory,int percent)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImagePersentase(image,percent);
            return ImageToByteArray(imageResize);
        }
        #endregion
    }
}


public class DataItem
{
    public int NO {  get; set; }
    public string KODE_SPAREPART {  get; set; }
    public byte[] GAMBAR { get; set; }
    public string PRODUK { get; set; }
    public string HARGA { get; set; }
    public string STOK { get; set; }
    public byte[] KETERANGAN_STOK { get; set; }
    //public byte[] KETERANGAN { get; set; }
}

public class SortableBindingList<T> : BindingList<T>
{
    private bool _isSorted;
    private ListSortDirection _sortDirection;
    private PropertyDescriptor _sortProperty;

    public SortableBindingList() : base(new List<T>()) { }

    public SortableBindingList(IEnumerable<T> collection) : base(collection.ToList()) { }

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => _isSorted;
    protected override ListSortDirection SortDirectionCore => _sortDirection;
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        _sortProperty = prop;
        _sortDirection = direction;
        _isSorted = true;

        var items = this.Items as List<T>;
        if (items == null) return;

        // Urutkan data
        if (direction == ListSortDirection.Ascending)
            items.Sort((x, y) => Compare(prop.GetValue(x), prop.GetValue(y)));
        else
            items.Sort((x, y) => Compare(prop.GetValue(y), prop.GetValue(x)));

        // Beri tahu DataGridView bahwa data telah diurutkan
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore()
    {
        _isSorted = false;
        _sortDirection = ListSortDirection.Ascending;
        _sortProperty = null;
    }

    private int Compare(object x, object y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        if (x is IComparable xComparable)
            return xComparable.CompareTo(y);

        if (y is IComparable yComparable)
            return yComparable.CompareTo(x);

        return x.ToString().CompareTo(y.ToString());
    }
}