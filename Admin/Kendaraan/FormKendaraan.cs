
using Dapper;
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
    public partial class FormKendaraan : Form
    {
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private int _page = 1;
        private int _Totalpage = 1;
        private bool _btnMain = true;
        public FormKendaraan()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }
        #region INIT COMPONENT & STYLE GRID
        private void InitComponent()
        {
            numericEntries.Minimum = 3;
            List<string> list = new List<string>() { "Default","Servis Terbanyak", "Servis Tersedikit" };
            comboFilter.DataSource = list;
        }

        private void CustomGrid()
        {
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            List<string> list = new List<string>() { "No", "nama_pelanggan", "no_pol", "merk", "tipe", "kapasitas", "tahun", "transmisi" };
            foreach (string s in list)
            {
                dgv.Columns[s].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            }


            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Columns["No"].FillWeight = 6;
            dgv.Columns["nama_pelanggan"].FillWeight = 25;
            dgv.Columns["no_pol"].FillWeight = 13;
            dgv.Columns["merk"].FillWeight = 15;
            dgv.Columns["tipe"].FillWeight = 13;
            dgv.Columns["kapasitas"].FillWeight = 10;
            dgv.Columns["tahun"].FillWeight = 10;
            dgv.Columns["transmisi"].FillWeight = 10;
            dgv.Columns["total_servis"].FillWeight = 13;

            dgv.Columns["nama_pelanggan"].HeaderText = "Pemilik";
            dgv.Columns["no_pol"].HeaderText = "No. Polisi";
            dgv.Columns["merk"].HeaderText = "Merk";
            dgv.Columns["tipe"].HeaderText = "Tipe";
            dgv.Columns["kapasitas"].HeaderText = "Kapasitas (cc)";
            dgv.Columns["tahun"].HeaderText = "Tahun";
            dgv.Columns["transmisi"].HeaderText = "Transmisi";
            dgv.Columns["total_servis"].HeaderText = " Total Servis";

            dgv.Columns["id_kendaraan"].Visible = false;

            dgv.Columns["total_servis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
        }
        #endregion

        #region EVENT
        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnAddData.Click += BtnAddData_Click;
            btnDataDihapus.Click += BtnDataDihapus_Click;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            restoreStripMenuItem2.Click += RestoreStripMenuItem2_Click;
            comboFilter.SelectedIndexChanged += (s, e) => FilterChange();
            numericEntries.ValueChanged += (s,e) => FilterChange();
            txtSearch.TextChanged += async (s, e) =>
            {
                await Task.Delay(500);
                FilterChange();
            };
        }


        private void FilterChange()
        {
            _page = 1;
            LoadData();
        }
        private void RestoreStripMenuItem2_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin memulihkan data?")) return;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_kendaraan"].Value);
            _kendaraanDal.RestoreData(id);
            LoadData();
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus data?")) return;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_kendaraan"].Value);
            _kendaraanDal.SoftDeleteData(id);
            LoadData();
        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_kendaraan"].Value);
            if (new FormInputKendaraan(id).ShowDialog() != DialogResult.OK) return;
            LoadData();
        }

        private void DataGridView1_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (_btnMain)
                    contextMenuStripEx1.Show(Cursor.Position);
                else
                    contextMenuStripEx2.Show(Cursor.Position);
            }
        }

        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            if (!_btnMain)
            {
                Image img = Properties.Resources.plusDark;
                StyleComponent.ControlButtonMainDelete(btnAddData, btnDataDihapus, img, true, "Kendaraan");
                _btnMain = true;
                LoadData();
                return;
            }
            if (new FormInputKendaraan(0).ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void BtnDataDihapus_Click(object? sender, EventArgs e)
        {
            if (_btnMain)
            {
                Image img = Properties.Resources.plusPutih;
                StyleComponent.ControlButtonMainDelete(btnAddData, btnDataDihapus, img, false, "Pegawai");
                _btnMain = false;
                LoadData();
            }
        }

        private void BtnPrevious_Click(object? sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page--;
                lblHalaman.Text = _page.ToString();
                LoadData();
            }
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (_page <= 10)
            {
                _page++;
                lblHalaman.Text = _page.ToString();
                LoadData();
            }
        }

        #endregion
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            int index = comboFilter.SelectedIndex;
            bool dataActive = _btnMain;

            string sql = @"";
            string sql2 = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(k.merk LIKE '%' + @search + '%' OR k.tipe LIKE '%' + @search + '%' OR k.tahun LIKE '%' + @search + '%' OR k.no_pol LIKE '%' + @search + '%' OR p.nama_pelanggan LIKE '%' + @search + '%')");
                dp.Add(@"search", search);
            }
            if (dataActive)
                fltr.Add("(k.deleted_at IS NULL)");
            else
                fltr.Add("(k.deleted_at IS NOT NULL)");

            if (fltr.Count > 0)
                sql += " WHERE " + string.Join(" AND ", fltr);


            if (index == 0) sql2 += "ORDER BY k.id_kendaraan DESC";
            if (index == 1) sql2 += "ORDER BY k.total_servis DESC";
            if (index == 2) sql2 += "ORDER BY k.total_servis ASC";

            var filterResult = new FilterDto
            {
                sql = sql,
                sql2 = sql2,
                param = dp
            };
            return filterResult;
        }
        private void LoadData()
        {
            var sqlFilter = Filter() ?? new FilterDto();
            var totalRows = _kendaraanDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";

            var list = _kendaraanDal.ListData(sqlFilter)
                .Select((x,index) => new
                {
                    id_kendaraan = x.id_kendaraan,
                    No = offset + index + 1,
                    nama_pelanggan = x.nama_pelanggan,
                    no_pol = x.no_pol,
                    merk = x.merk,
                    tipe = x.tipe,
                    transmisi = x.transmisi,
                    kapasitas = x.kapasitas + "cc",
                    tahun = x.tahun,
                    total_servis = x.total_servis
                }).ToList();

            dataGridView1.DataSource = list;
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
                    string[] targetColumns = { "total_servis" };

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
    }
}
