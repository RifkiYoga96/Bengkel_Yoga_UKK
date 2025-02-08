using Dapper;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormBooking : Form
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        private byte[] _pending = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Pending, 90, 90));
        private byte[] _dikerjakan = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Dikerjakan, 90, 90));
        private bool _rangeTanggal = false;
        public FormBooking(DateTime tanggal = default)
        {
            InitializeComponent();
            if (tanggal == default)
                tanggal = new DateTime(2025, 1, 1);
            InitComponen();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }

        #region EVENT
        private void RegisterEvent()
        {
            btnSearch.Click += (s, e) => 
            { 
                if (txtSearch.Text.Length > 0) LoadData();
            };
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            detailBookingToolStripMenuItem.Click += DetailBookingToolStripMenuItem_Click;


            //Filter
            txtSearch.KeyDown += (s, e) =>
            {
                if(e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadData();
                }
            };
            tgl1.ValueChanged += Tgl_ValueChanged;
            tgl2.ValueChanged += Tgl_ValueChanged;
            comboFilterWaktu.SelectedValueChanged += ComboFilterWaktu_SelectedValueChanged;
        }

        private void ComboFilterWaktu_SelectedValueChanged(object? sender, EventArgs e)
        {
            _rangeTanggal = false;
            LoadData();
        }

        private void Tgl_ValueChanged(object? sender, EventArgs e)
        {
            _rangeTanggal = true;
            LoadData();
        }

        private void DetailBookingToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            MainFormAdmin.ShowFormInPanel2(new FormBookingDetail(id));
        }

        private void DataGridView1_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                contextMenuStrip.Show(Cursor.Position);
            }
        }
        #endregion

        #region DATAGRID LOAD
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            string status = comboFilterStatus.SelectedItem?.ToString()?.ToLower() ?? string.Empty;

            DateTime filterWaktu1 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu1;
            DateTime filterWaktu2 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu2;

            DateTime tanggal1 = tgl1.Value.Date;
            DateTime tanggal2 = tgl2.Value.Date;


            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(b.ktp_pelanggan LIKE @search + '%' OR b.no_pol LIKE '%' + @search + '%' OR p.nama_pelanggan LIKE '%' + @search + '%')");
                dp.Add(@"search",search);
            }
            if(status != string.Empty && comboFilterStatus.SelectedIndex != 0)
            {
                fltr.Add("(b.status = @status)");
                dp.Add(@"status",status);
            }
            if(comboFilterWaktu.SelectedIndex != 0 && !_rangeTanggal)
            {
                fltr.Add("(b.tanggal BETWEEN @filterWaktu1 AND @filterWaktu2)");
                dp.Add(@"filterWaktu1",filterWaktu1);
                dp.Add(@"filterWaktu2",filterWaktu2);
            }
            if (_rangeTanggal)
            {
                fltr.Add("(b.tanggal BETWEEN @tanggal1 AND @tanggal2)");
                dp.Add(@"tanggal1",tanggal1);
                dp.Add(@"tanggal2",tanggal2);
            }


            if (fltr.Count > 0)
                sql += " WHERE " + string.Join(" AND ",fltr);


            var filterResult = new FilterDto
            {
                sql = sql,
                param = dp
            };
            MessageBox.Show($"{sql} --- {dp}");
            return filterResult;
        }

        private void LoadData()
        {
            int i = 1;
            var list = _bookingDal.ListData(Filter() ?? new FilterDto())
                .Select(x => new BookingDto
                {
                    id_booking = x.id_booking,
                    No = i++,
                    antrean = x.antrean,
                    ktp_pelanggan = x.ktp_pelanggan,
                    nama_pelanggan = x.nama_pelanggan,
                    no_pol = x.no_pol,
                    nama_kendaraan = $"{x.merk} {x.tipe} {x.kapasitas} {x.tahun}",
                    tanggal = x.tanggal,
                    keluhan = x.keluhan,
                    catatan = x.catatan,
                    statusImg = x.status == "pending" ? _pending : _dikerjakan
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<BookingDto>(list);
        }
        #endregion

        #region INIT COMPONENT
        private void InitComponen()
        {
            comboFilterStatus.DataSource = new List<string>() { "Semua(All)","Pending","Dikerjakan" };

            DateTime now = DateTime.Today;
            var listFilterWaktu = new List<FilterWaktu>()
            {
                new FilterWaktu{ nama = "--Pilih Waktu--", waktu1= now,waktu2=now},
                new FilterWaktu{ nama = "Hari ini", waktu1 = now, waktu2 = now },
                new FilterWaktu{ nama = "Kemarin", waktu1 = now.AddDays(-1), waktu2 = now.AddDays(-1) },
                new FilterWaktu{ nama = "7 hari sebelumnya", waktu1 = now.AddDays(-6), waktu2 = now },
                new FilterWaktu{ nama = "30 hari sebelumnya", waktu1 = now.AddDays(-29), waktu2 = now }
            };
            comboFilterWaktu.DataSource = listFilterWaktu;
            comboFilterWaktu.DisplayMember = "nama";
        }
        #endregion


        #region DATAGRID CUSTOM
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


            dataGridView1.Columns["id_booking"].Width = 10;
            dataGridView1.Columns["No"].Width = 70;
            dataGridView1.Columns["antrean"].Width = 100;
            dataGridView1.Columns["ktp_pelanggan"].Width = 200;
            dataGridView1.Columns["nama_pelanggan"].Width = 250;
            dataGridView1.Columns["no_pol"].Width = 150;
            dataGridView1.Columns["nama_kendaraan"].Width = 250;
            dataGridView1.Columns["tanggal"].Width = 200;
            dataGridView1.Columns["keluhan"].Width = 250;
            dataGridView1.Columns["catatan"].Width = 250;
            dataGridView1.Columns["statusImg"].Width = 180;

            dataGridView1.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["antrean"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["ktp_pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["nama_pelanggan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["no_pol"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["nama_kendaraan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["tanggal"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["keluhan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["catatan"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["statusImg"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            dataGridView1.Columns["id_booking"].Visible = false;

            dataGridView1.Columns["statusImg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["antrean"].HeaderText = "Antrean";
            dataGridView1.Columns["ktp_pelanggan"].HeaderText = "KTP Pelanggan";
            dataGridView1.Columns["nama_pelanggan"].HeaderText = "Pelanggan";
            dataGridView1.Columns["no_pol"].HeaderText = "Nomor Polisi";
            dataGridView1.Columns["nama_kendaraan"].HeaderText = "Kendaraan";
            dataGridView1.Columns["tanggal"].HeaderText = "Tanggal";
            dataGridView1.Columns["keluhan"].HeaderText = "Keluhan";
            dataGridView1.Columns["catatan"].HeaderText = "Catatan";
            dataGridView1.Columns["statusImg"].HeaderText = "Status";

            dataGridView1.Columns["id_booking"].Frozen = true;
            dataGridView1.Columns["No"].Frozen = true;
            dataGridView1.Columns["ktp_pelanggan"].Frozen = true;
            dataGridView1.Columns["nama_pelanggan"].Frozen = true;


            dataGridView1.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["antrean"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["ktp_pelanggan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["no_pol"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["keluhan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["catatan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["statusImg"].SortMode = DataGridViewColumnSortMode.NotSortable;
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
    }
}

public class FilterDto
{
    public string sql { get; set; } = string.Empty;
    public object param { get; set; } = new DynamicParameters();
}

public class FilterWaktu
{
    public string nama { get; set; }
    public DateTime waktu1 { get; set; }
    public DateTime waktu2 { get; set; }
}
