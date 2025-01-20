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
        }



        #region DATAGRID
        private void CostumGrid()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dataGridView1.Columns[0].Width = 150;
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
                dataGridView1.Rows[2].Cells[3].Style.ForeColor = Color.Red;
            };
        }


        private void InitDataGrid()
        {
            // Add data to DataGridView
            var data = new BindingList<DataItem>(GetData());
            dataGridView1.DataSource = data;

            // Pastikan kolom sudah dibuat
            if (dataGridView1.Columns.Count > 0)
            {
                // Mengatur SortMode untuk setiap kolom
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
            else
            {
                MessageBox.Show("Kolom belum dibuat. Pastikan DataSource diatur dengan benar.");
            }
        }

        private List<DataItem> GetData()
        {
            // Path gambar yang akan digunakan
            string pandingImg = @"D:\APenyimpanan\BENGKEL - UKK\Panding.png";
            string produkImg = @"D:\APenyimpanan\BENGKEL - UKK\FotoSaya.jpg";
            string selesaiImg = @"D:\APenyimpanan\BENGKEL - UKK\selesai.png";

            // Ubah ukuran gambar menjadi maksimal 100x100
            Image originalImage = Image.FromFile(pandingImg);
            Image resizedImage = ResizeImagePersentase(originalImage, 15); // Ubah ukuran gambar

            Image produkImageOri = Image.FromFile(produkImg);
            Image resizeProduk = ResizeImage(produkImageOri, 55, 55);

            Image selesaiImageOri = Image.FromFile(selesaiImg);
            Image resizeSelesai = ResizeImagePersentase(selesaiImageOri, 15);

            // Konversi gambar yang sudah diubah ukurannya ke byte[]
            byte[] pandingBytes = ImageToByteArray(resizedImage);
            byte[] produkBytes = ImageToByteArray(resizeProduk);
            byte[] selesaiBytes = ImageToByteArray(resizeSelesai);

            return new List<DataItem>
        {
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor IRC DELVIRO", STOK = "20", HARGA = "Rp 220.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor IRC DELPHI", STOK = "10", HARGA = "Rp 300.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor CDA DELVIRO", STOK = "11", HARGA = "Rp 450.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor IRC TUNA", STOK = "34", HARGA = "Rp 190.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor ASC SORTIR", STOK = "23", HARGA = "Rp 240.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Spion LowASC", STOK = "20", HARGA = "Rp 89.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Ban Motor IRC MOBONG", STOK = "20", HARGA = "Rp 520.000" },
            new DataItem { GAMBAR = produkBytes, PRODUK = "Velg LUCAS EMBE", STOK = "55", HARGA = "Rp 1.200.000" },
        };
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
