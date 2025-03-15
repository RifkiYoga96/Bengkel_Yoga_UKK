using Dapper;
using System.ComponentModel;
using System.Data;

namespace Bengkel_Yoga_UKK
{
    public partial class FormBooking : Form
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly BatasBookingDal _batasBookingDal = new BatasBookingDal();
        private readonly JadwalDal _jadwalDal = new JadwalDal();
        private readonly JadwalOperasionalDal _jadwalOperasionalDal = new JadwalOperasionalDal();

        private byte[] _pending = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Pending, 110, 110));
        private byte[] _dikerjakan = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Dikerjakan, 110, 110));
        private byte[] _belum_bayar = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.BelumBayar, 110, 110));
        private bool _rangeTanggal = false;
        private int _page = 1;
        private int _Totalpage = 1;
        private DateTime _tanggal;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public FormBooking(DateTime tanggal = default)
        {
            InitializeComponent();
            InitComponen();
            RegisterEvent();
            //UpdateAntrean();
            LoadData();
            CustomGrid();
            if (tanggal == default)
                tanggal = new DateTime(2025, 1, 1);
            _timer.Interval = 10000;
            _timer.Tick += (s,e) => UpdateAntrean();
            _timer.Start();
        }


        private async void UpdateAntrean()
        {
            if (!await CekAntreanUpdate()) return;
            DateTime now = DateTime.Today;
            var listAntrean = await _bookingDal.ListDataAntrean(now);
            if (!listAntrean.Any()) return;
            int antrean = 1;
            foreach (var item in listAntrean)
            {
                var booking = new BookingModel
                {
                    id_booking = item.id_booking,
                    antrean = antrean++,
                    tipe_antrean = 2
                };
                _bookingDal.UpdateAntrean(booking);
            }
            LoadData();
            _timer.Stop();
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
            dataGridView1.CellDoubleClick += (s,e) => ShowDetail();
            detailBookingToolStripMenuItem.Click += (s,e) => ShowDetail();
            btnAddData.Click += BtnAddData_Click;
            btnEditBatasBooking.Click += (s, e) =>
            {
                new FormBatasBooking().ShowDialog();
                InitBatasBooking();
            };


            //Filter
            /*txtSearch.KeyDown += (s, e) =>
            {
                if(e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadData();
                }
            };*/
            txtSearch.KeyDown += TxtSearch_KeyDown;

            comboFilterWaktu.SelectedValueChanged += ComboFilterWaktu_SelectedValueChanged;
            comboFilterStatus.SelectedIndexChanged += ComboFilterStatus_SelectedIndexChanged;

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

            this.Load += FormBooking_Load;
            btnJadwal.Click += (s, e) => new FormJadwal().ShowDialog();
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

        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            if (new FormInputBooking2().ShowDialog() != DialogResult.OK) return;
            LoadData();
        }

        private void ComboFilterWaktu_SelectedValueChanged(object? sender, EventArgs e)
        {
            _rangeTanggal = false;
            ResetPage();
            LoadData();
        }

        private void Tgl_ValueChanged(object? sender, EventArgs e)
        {
            _rangeTanggal = true;
            ResetPage();
            LoadData();
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

        private void ShowDetail()
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            MainFormAdmin.ShowFormInPanel2(new FormDetailBooking(id));
        }

        private void ResetPage()
        {
            _page = 1;
        }
        #endregion

        #region DATAGRID LOAD
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            string status = comboFilterStatus.SelectedItem?.ToString()?.ToLower() ?? string.Empty;

            DateTime filterWaktu1 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu1;
            DateTime filterWaktu2 = ((FilterWaktu)comboFilterWaktu.SelectedItem).waktu2;


            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(b.ktp_pelanggan LIKE @search + '%' OR COALESCE(b.no_pol, k.no_pol) LIKE '%' + @search + '%' OR COALESCE(b.nama_pelanggan, p.nama_pelanggan) LIKE '%' + @search + '%')");
                dp.Add(@"search",search);
            }
            if(status != string.Empty && comboFilterStatus.SelectedIndex != 0)
            {
                fltr.Add("(b.status = @status)");
                dp.Add(@"status",status);
            }
            if(comboFilterWaktu.SelectedIndex != 0 && !_rangeTanggal)
            {
                if(comboFilterWaktu.SelectedIndex == 1)
                {
                    fltr.Add("(b.tanggal <= @tanggalNow)");
                    dp.Add(@"tanggalNow", DateTime.Today);
                }
                else
                {
                    fltr.Add("(b.tanggal BETWEEN @filterWaktu1 AND @filterWaktu2)");
                    dp.Add(@"filterWaktu1", filterWaktu1);
                    dp.Add(@"filterWaktu2", filterWaktu2);
                }
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
            var sqlFilter = Filter() ?? new FilterDto();
            var totalRows = _bookingDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";

            var list = _bookingDal.ListData(sqlFilter)
                .Select((x,index) => new BookingDto
                {
                    id_booking = x.id_booking,
                    No = offset + index + 1,
                    antrean = (x.tipe_antrean == 1 ? "A" : "B") + x.antrean.ToString("D3"),
                    ktp_pelanggan = x.ktp_pelanggan == null ? "(Tamu)" : x.ktp_pelanggan,
                    nama_pelanggan = x.nama_pelanggan,
                    no_pol = x.no_pol,
                    nama_kendaraan = x.nama_kendaraan,
                    tanggal = x.tanggal,
                    keluhan = x.keluhan,
                    catatan = x.catatan == null ? "(Belum ada catatan)" : x.catatan,
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

            numericEntries.Maximum = 1000;
            numericEntries.Minimum = 4;
            txtBatas.ReadOnly = true;
            txtBatas.TextAlign = HorizontalAlignment.Center;

            InitBatasBooking();
        }

        private void InitBatasBooking()
        {
            int batas = _batasBookingDal.GetBatasBooking(DateTime.Today);
            txtBatas.Text = batas.ToString();
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
            dgv.Columns["antrean"].Width = 120;
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

            string[] columnSort = { "No","ktp_pelanggan","nama_pelanggan","no_pol","keluhan","catatan","statusImg" };
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
     
        private void FormBooking_Load(object? sender, EventArgs e)
        {
            DataGridViewColumn targetColumn = dataGridView1.Columns["Antrean"];

            if (targetColumn != null)
            {
                // Atur pengurutan ascending pada kolom tersebut
                dataGridView1.Sort(targetColumn, ListSortDirection.Ascending);

                // Atur tanda panah (sort glyph) pada header kolom
                targetColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }

            comboFilterWaktu.SelectedIndex = 1;
        }
        #endregion

        #region HELPER

        private async Task<bool> CekAntreanUpdate()
        {
            DateTime tanggal = DateTime.Today;

            var libur = await _jadwalDal.CekLibur(tanggal);
            if (libur) return true;

            var tutup = await _jadwalOperasionalDal.CekTutup(tanggal);
            if (tutup) return true;
            return false;
        }

        #endregion
    }
}

public class FilterDto
{
    public string sql { get; set; } = string.Empty;
    public DynamicParameters param { get; set; } = new DynamicParameters();
}


public class FilterWaktu
{
    public string nama { get; set; }
    public DateTime waktu1 { get; set; }
    public DateTime waktu2 { get; set; }
}
