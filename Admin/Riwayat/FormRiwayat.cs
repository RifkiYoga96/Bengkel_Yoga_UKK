using Dapper;
using Syncfusion.Windows.Forms.Tools;
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
        private byte[] _selesai = ImageConvert.ImageToByteArray(ImageConvert.ResizeImagePersentase(Properties.Resources.Selesai, 15));
        private byte[] _dibatalkan = ImageConvert.ImageToByteArray(ImageConvert.ResizeImagePersentase(Properties.Resources.Dibatalkan, 15));
        private bool _filterTanggal = false;
        private int _page = 1;
        private int _Totalpage = 1;
        public FormRiwayat(DateTime tanggal = default)
        {
            InitializeComponent();
            if (tanggal == default)
                tanggal = new DateTime(2025,1,1);
            InitComponent();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }

        private void InitComponent()
        {
            lblTo.ForeColor = SystemColors.ControlDarkDark;
            tgl1.StyleDateTimeEdit();
            tgl2.StyleDateTimeEdit();

            panelComboFilter.Visible = true;
            panelTanggalFilter.Visible = false;

            comboFilterStatus.DataSource = new List<string>() { "Semua(All)", "Pending", "Dikerjakan" };

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

            numericEntries.Maximum = 1000;
            numericEntries.Minimum = 10;

            ControlTgl1();
            ControlTgl2();
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
           

            txtSearch.KeyDown += TxtSearch_KeyDown;

            comboFilterWaktu.SelectedValueChanged += ComboFilterWaktu_SelectedValueChanged;
            comboFilterStatus.SelectedIndexChanged += ComboFilterStatus_SelectedIndexChanged;

            tgl1.ValueChanged += (s, e) => ControlTgl1();
            tgl2.ValueChanged += (s, e) => ControlTgl2();

            tgl1.ValueChanged += Tgl_ValueChanged;
            tgl2.ValueChanged += Tgl_ValueChanged;

            btnNext.Click += (s, e) =>
            {
                if (_page < _Totalpage)
                {
                    _page++;
                    LoadData();
                }
            };
            btnPrevious.Click += (s, e) =>
            {
                if (_page > 1)
                {
                    _page--;
                    LoadData();
                }
            };

            numericEntries.ValueChanged += async (s, e) =>
            {
                await Task.Delay(1000);
                ResetPage();
                LoadData();
            };

            //this.Load += FormBooking_Load;
        }



        private void ComboFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ResetPage();
            LoadData();
        }

        private async void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            await Task.Delay(500);
            ResetPage();
            LoadData();
        }

        private void ComboFilterWaktu_SelectedValueChanged(object? sender, EventArgs e)
        {
            panelComboFilter.Visible = true;
            panelTanggalFilter.Visible = false;
            _filterTanggal = false;
            ResetPage();
            LoadData();
        }

        private void Tgl_ValueChanged(object? sender, EventArgs e)
        {
            panelComboFilter.Visible = false;
            panelTanggalFilter.Visible = true;
            _filterTanggal = true;
            ResetPage();
            LoadData();
        }

        private void DetailBookingToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            MainFormAdmin.ShowFormInPanel2(new FormDetailBooking(id));
        }

        private void DataGridView1_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void ResetPage()
        {
            _page = 1;
        }
        #endregion

        #region LOAD DATAGRID
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            string status = comboFilterStatus.SelectedItem?.ToString()?.ToLower() ?? string.Empty;

            DateTime filterWaktu1 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu1;
            DateTime filterWaktu2 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu2;

            DateTime tanggal1 = tgl1.Value.GetValueOrDefault(DateTime.Today);
            DateTime tanggal2 = tgl2.Value.GetValueOrDefault(DateTime.Today);


            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(r.ktp_pelanggan LIKE @search + '%' OR COALESCE(r.no_pol, k.no_pol) LIKE '%' + @search + '%' OR COALESCE(r.nama_pelanggan, p.nama_pelanggan) LIKE '%' + @search + '%')");
                dp.Add(@"search", search);
            }
            if (status != string.Empty && comboFilterStatus.SelectedIndex != 0)
            {
                fltr.Add("(r.status = @status)");
                dp.Add(@"status", status);
            }
            if (comboFilterWaktu.SelectedIndex != 0 && !_filterTanggal)
            {
                fltr.Add("(r.tanggal BETWEEN @filterWaktu1 AND @filterWaktu2)");
                dp.Add(@"filterWaktu1", filterWaktu1);
                dp.Add(@"filterWaktu2", filterWaktu2);
            }
            if (_filterTanggal)
            {
                fltr.Add("(r.tanggal BETWEEN @filterWaktu1 AND @filterWaktu2)");
                dp.Add(@"filterWaktu1", tanggal1.Date);
                dp.Add(@"filterWaktu2", tanggal2.Date);
            }


            if (fltr.Count > 0)
                sql += " WHERE " + string.Join(" AND ", fltr);


            var filterResult = new FilterDto
            {
                sql = sql,
                param = dp
            };
            return filterResult;
        }

        private void LoadData()
        {
            var sqlFilter = Filter() ?? new FilterDto();
            var totalRows = _riwayatDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";


            var listSparepart = _riwayatDal.ListDataSparepart();

            var list = _riwayatDal.ListData(sqlFilter)
                .Select((x,index) => new RiwayatDto
                {
                    id_riwayat = x.id_riwayat,
                    No = offset + index + 1,
                    Status = x.status == "selesai" ? _selesai : _dibatalkan,
                    ktp_pelanggan = x.ktp_pelanggan == null ? "(Tamu)" : x.ktp_pelanggan,
                    Pelanggan = x.nama_pelanggan,
                    no_pol = x.no_pol,
                    Kendaraan = x.nama_kendaraan,
                    Keluhan = x.keluhan,
                    Tanggal = x.tanggal,
                    Pegawai = x.nama_admin,
                    Mekanik = x.nama_mekanik,
                    Catatan = x.catatan,
                    Sparepart = listSparepart.Any(a => a.id_riwayat == x.id_riwayat)
                        ? string.Join(", ", listSparepart.Where(a => a.id_riwayat == x.id_riwayat).Select(a => a.nama_sparepart))
                        : "(Tidak Ada Sparepart)",
                    catatan = x.catatan,
                    total_harga = x.total_harga
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<RiwayatDto>(list);
        }
        #endregion


        #region CUSTOM DATAGRID
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
            dataGridView1.Columns["Status"].Frozen = true;
            dataGridView1.Columns["ktp_pelanggan"].Frozen = true;
            dataGridView1.Columns["Pelanggan"].Frozen = true;

            dataGridView1.Columns["id_riwayat"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
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

            dataGridView1.Columns["id_kendaraan"].Visible = false;
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

        #region HELPER

        private void ControlTgl1()
        {
            string tgl1Str = tgl1.Value?.ToString("yyyy-MM-dd") ?? "";
            if (DateTime.TryParse(tgl1Str, out DateTime tglParsed1))
            {
                tgl2.MinDateTime = tglParsed1;
            }
            else
            {
                tgl2.MinDateTime = DateTime.Today;
            }
        }

        private void ControlTgl2()
        {
            string tgl2Str = tgl2.Value?.ToString("yyyy-MM-dd") ?? "";
            if (DateTime.TryParse(tgl2Str, out DateTime tglParsed2))
            {
                tgl1.MaxDateTime = tglParsed2;
            }
            else
            {
                tgl1.MaxDateTime = DateTime.Today;
            }
        }

        #endregion

    }
}
