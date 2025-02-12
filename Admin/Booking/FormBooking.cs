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
            btnAddData.Click += BtnAddData_Click;


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

        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            if (new FormInputBooking2().ShowDialog() != DialogResult.OK) return;
            LoadData();
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
                new FilterWaktu{ nama = "Semua (All)", waktu1= now,waktu2=now},
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
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            dgv.Columns["id_kendaraan"].Visible = false;

            dgv.Columns["id_booking"].Width = 10;
            dgv.Columns["No"].Width = 70;
            dgv.Columns["antrean"].Width = 100;
            dgv.Columns["ktp_pelanggan"].Width = 200;
            dgv.Columns["nama_pelanggan"].Width = 250;
            dgv.Columns["no_pol"].Width = 150;
            dgv.Columns["nama_kendaraan"].Width = 250;
            dgv.Columns["tanggal"].Width = 200;
            dgv.Columns["keluhan"].Width = 250;
            dgv.Columns["catatan"].Width = 250;
            dgv.Columns["statusImg"].Width = 180;

            dgv.Columns["antrean"].HeaderText = "Antrean";
            dgv.Columns["ktp_pelanggan"].HeaderText = "KTP Pelanggan";
            dgv.Columns["nama_pelanggan"].HeaderText = "Pelanggan";
            dgv.Columns["no_pol"].HeaderText = "Nomor Polisi";
            dgv.Columns["nama_kendaraan"].HeaderText = "Kendaraan";
            dgv.Columns["tanggal"].HeaderText = "Tanggal";
            dgv.Columns["keluhan"].HeaderText = "Keluhan";
            dgv.Columns["catatan"].HeaderText = "Catatan";
            dgv.Columns["statusImg"].HeaderText = "Status";

            string[] columnPadding = { "No", "antrean", "ktp_pelanggan", "nama_pelanggan", "no_pol", "nama_kendaraan", "tanggal", "keluhan", "catatan"};
            foreach (var col in columnPadding)
                dgv.Columns[col].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            

            dgv.Columns["id_booking"].Visible = false;
            dgv.Columns["statusImg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["id_booking"].Frozen = true;
            dgv.Columns["No"].Frozen = true;
            dgv.Columns["ktp_pelanggan"].Frozen = true;
            dgv.Columns["nama_pelanggan"].Frozen = true;

            string[] columnSort = { "No","antrean","ktp_pelanggan","no_pol","keluhan","catatan","statusImg" };
            foreach (var col in columnSort)
                dgv.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
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
