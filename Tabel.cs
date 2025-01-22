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

namespace Bengkel_Yoga_UKK
{
    public partial class Tabel : Form
    {
        public Tabel()
        {
            InitializeComponent();
            InitDataGrid();
            CostumGrid();
            //ImageGrid();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
        }

        #region DATAGRID
        private void CostumGrid()
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[0].HeaderText = "";


            // Mengatur ukuran font header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Mengatur warna header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // Warna background header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;    // Warna teks header
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray; // Warna saat header "terselect"
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray;      // Warna teks saat header "terselect"
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
            byte[] ban1 = ImageToByteProduk(@"D:\APenyimpanan\BENGKEL - UKK\IRC NR72.jpg");
            byte[] ban2 = ImageToByteProduk(@"D:\APenyimpanan\BENGKEL - UKK\IRC SCT-004.jpg");
            byte[] velg = ImageToByteProduk(@"D:\APenyimpanan\BENGKEL - UKK\velg.jpeg");
            byte[] spion = ImageToByteProduk(@"D:\APenyimpanan\BENGKEL - UKK\Spion.jpg");

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
                    new DataItem { GAMBAR = ban1, PRODUK = "Ban Motor IRC DELVIRO", STOK = "20", HARGA = "Rp 220.000" },
                    new DataItem { GAMBAR = ban2, PRODUK = "Ban Motor IRC DELPHI", STOK = "10", HARGA = "Rp 300.000" },
                    new DataItem { GAMBAR = velg, PRODUK = "Ban Motor CDA DELVIRO", STOK = "11", HARGA = "Rp 450.000" },
                    new DataItem { GAMBAR = spion, PRODUK = "Ban Motor IRC TUNA", STOK = "34", HARGA = "Rp 190.000" },
                    new DataItem { GAMBAR = ban2, PRODUK = "Ban Motor ASC SORTIR", STOK = "23", HARGA = "Rp 240.000" },
                    new DataItem { GAMBAR = spion, PRODUK = "Spion LowASC", STOK = "20", HARGA = "Rp 89.000" },
                    new DataItem { GAMBAR = ban2, PRODUK = "Ban Motor IRC MOBONG", STOK = "20", HARGA = "Rp 520.000" },
                    new DataItem { GAMBAR = velg, PRODUK = "Velg LUCAS EMBE", STOK = "55", HARGA = "Rp 1.200.000" },
                };
        }

        /* private void DataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
         {
             if (e.RowIndex == -1 && e.ColumnIndex >= 0) // Hanya proses header kolom
             {
                 // Gambar latar belakang header default
                 e.PaintBackground(e.CellBounds, true);

                 // Gambar teks header
                 TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                 TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, flags);

                 // Jika kolom sedang diurutkan, gambar panah
                 if (dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection != SortOrder.None)
                 {
                     int arrowWidth = 8; // Lebar panah
                     int arrowHeight = 8; // Tinggi panah
                     int textWidth = TextRenderer.MeasureText(e.FormattedValue.ToString(), e.CellStyle.Font).Width;
                     int arrowX = e.CellBounds.Left + textWidth + 2; // Jarak antara teks dan panah
                     int arrowY = e.CellBounds.Top + (e.CellBounds.Height - arrowHeight) / 2; // Posisi vertikal tengah

                     using (var sortGlyph = CreateSortGlyph(arrowWidth, arrowHeight, dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection))
                     {
                         e.Graphics.DrawImage(sortGlyph, arrowX, arrowY);
                     }
                 }

                 e.Handled = true; // Tandai event sebagai sudah dihandle
             }
         }*/
        private void DataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0) // Hanya proses header kolom
            {
                // Gambar latar belakang header default
                e.PaintBackground(e.CellBounds, true);

                // Gambar teks header
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, flags);

                // Jika kolom sedang diurutkan, gambar panah
                if (dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    int arrowWidth = 10; // Lebar panah (ukuran kecil)
                    int arrowHeight = 10; // Tinggi panah (ukuran kecil)
                    int textWidth = TextRenderer.MeasureText(e.FormattedValue.ToString(), e.CellStyle.Font).Width;
                    int arrowX = e.CellBounds.Left + textWidth + 2; // Jarak antara teks dan panah
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
        /*private Bitmap CreateSortGlyph(int width, int height, SortOrder sortOrder)
        {
            Bitmap glyph = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(glyph))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Point[] points;
                if (sortOrder == SortOrder.Ascending)
                {
                    // Panah menghadap ke atas
                    points = new Point[]
                    {
                new Point(width / 2, 0),          // Puncak panah (atas tengah)
                new Point(0, height),             // Sudut kiri bawah
                new Point(width, height)          // Sudut kanan bawah
                    };
                }
                else
                {
                    // Panah menghadap ke bawah
                    points = new Point[]
                    {
                new Point(0, 0),                  // Sudut kiri atas
                new Point(width, 0),              // Sudut kanan atas
                new Point(width / 2, height)      // Puncak panah (bawah tengah)
                    };
                }

                g.FillPolygon(Brushes.DimGray, points); // Gambar panah
            }
            return glyph;
        }*/
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
            double persen = (double)persentase/100;
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

        private byte[] ImageToByteProduk(string imgDirectory)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImage(image, 55,55);
            byte[] byteimg = ImageToByteArray(imageResize);
            return byteimg;
        }
        #endregion
    }
}


public class DataItem
{
    public byte[] GAMBAR { get; set; }
    public string PRODUK { get; set; }
    public string HARGA { get; set; }
    public string STOK { get; set; }
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