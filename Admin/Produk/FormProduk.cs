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
using Dapper;
using Syncfusion.Windows.Forms.Tools;

namespace Bengkel_Yoga_UKK
{
    public partial class FormProduk : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        private Dictionary<string, SortOrder> columnSortOrder = new Dictionary<string, SortOrder>();
        private readonly ProdukDal _produkDal = new ProdukDal();
        private int _page = 1;
        private int _Totalpage = 1;
        private bool _btnMain = true;
        Bitmap bitmap;

        private byte[] _habis = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Habis, 100, 100));
        private byte[] _menipis = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Menipis,100, 100));
        private byte[] _tersedia = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.Tersedia, 100, 100));
        private byte[] _defaultImage = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.defaultImage,55,55));
        public FormProduk()
        {
            InitializeComponent();
            InitComponent();
            LoadData();
            RegisterEvent();
            CostumGrid();
        }

        #region EVENT

        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnAddData.Click += BtnAddData_Click;
            btnDataDihapus.Click += BtnDataDihapus_Click;

            btnSearch.Click += BtnSearch_Click;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            restoreStripMenuItem2.Click += RestoreStripMenuItem2_Click;

            dataGridView1.ColumnHeaderMouseClick += SortingData;

            comboFilter.SelectedIndexChanged += (s, e) => LoadData();

            txtSearch.TextChanged += (s, e) =>
            {
                if (txtSearch.TextLength == 0) LoadData();
            };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadData();
                }
            };
        }


        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus data?")) return;
            string ktp = dataGridView1.CurrentRow.Cells["kode_sparepart"].Value?.ToString() ?? string.Empty;
            _produkDal.SoftDeleteData(ktp);
            LoadData();
        }

        private void RestoreStripMenuItem2_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin memulihkan data?")) return;
            string ktp = dataGridView1.CurrentRow.Cells["kode_sparepart"].Value?.ToString() ?? string.Empty;
            _produkDal.RestoreData(ktp);
            LoadData();
        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string kode = dataGridView1.CurrentRow.Cells["kode_sparepart"].Value?.ToString() ?? string.Empty;
            if (new FormInputProduk(kode,false).ShowDialog() != DialogResult.OK) return;
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

        private void BtnDataDihapus_Click(object? sender, EventArgs e)
        {
            if (_btnMain)
            {
                Image img = Properties.Resources.plusPutih;
                StyleComponent.ControlButtonMainDelete(btnAddData, btnDataDihapus, img, false, "Sparepart");
                _btnMain = false;
                LoadData();
            }
        }
        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            if (!_btnMain)
            {
                Image img = Properties.Resources.plusDark;
                StyleComponent.ControlButtonMainDelete(btnAddData, btnDataDihapus, img, true, "Sparepart");
                _btnMain = true;
                LoadData();
                return;
            }
            if (new FormInputProduk("").ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BtnPrevious_Click(object? sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page--;
                LoadData();
            }
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (_page < _Totalpage)
            {
                _page++;
                LoadData();
            }
        }

        #endregion

        #region INIT COMPONENT
        private void InitComponent()
        {
            List<string> list = new List<string>()
            {
                "Semua (All)","Stok Tersedia","Stok Menipis","Stok Habis"
            };
            comboFilter.DataSource = list;

            numericEntries.Minimum = 10;
        }
        #endregion

        #region LOAD DATAGRID
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            int status = comboFilter.SelectedIndex;
            bool dataActive = _btnMain;

            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(kode_sparepart LIKE  @search + '%' OR nama_sparepart LIKE '%' +  @search + '%')");
                dp.Add(@"search", search);
            }
            if (comboFilter.SelectedIndex != 0)
            {
                if(status == 1) fltr.Add("(stok > stok_minimum)");
                if(status == 2) fltr.Add("(stok <= stok_minimum AND stok > 0)");
                if(status == 3) fltr.Add("(stok = 0)");
            }
            if (dataActive)
                fltr.Add("(deleted_at IS NULL)");
            else
                fltr.Add("(deleted_at IS NOT NULL)");

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
            var totalRows = _produkDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";

            int i = 1;
            var list = _produkDal.ListData(sqlFilter)
                .Select((x,index) => new ProdukDto
                {
                    No = offset + index + 1,
                    kode_sparepart = x.kode_sparepart,
                    Foto = x.image_data != null ? ImageConvert.ResizeImageBytes(x.image_data, 45, 45) : _defaultImage,
                    Sparepart = x.nama_sparepart,
                    Harga = x.harga,
                    Stok = x.stok,
                    stok_minimum = x.stok_minimum,
                    keterangan_stok = x.stok == 0 ? _habis
                        : x.stok < x.stok_minimum ? _menipis
                        : _tersedia
                }).ToList();

            // Lakukan sorting berdasarkan kolom yang aktif
            var sortedColumn = columnSortOrder.Keys.FirstOrDefault();
            if (sortedColumn != null)
            {
                var sortOrder = columnSortOrder[sortedColumn];
                if (sortOrder != SortOrder.None)
                {
                    var propertyInfo = typeof(ProdukDto).GetProperty(sortedColumn);
                    if (propertyInfo != null)
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            list = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
                        }
                        else
                        {
                            list = list.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
                        }
                    }
                }
            }

            dataGridView1.DataSource = list;
        }

        #endregion

        #region GET DATA

        private void GetData()
        {

        }

        #endregion

        #region CUSTOM DATAGRID
        private void CostumGrid()
        {
            DataGridView dgv = dataGridView1;

            CustomGrids.CustomDataGrid(dgv);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["No"].FillWeight = 6;
            dgv.Columns["kode_sparepart"].FillWeight = 8;
            dgv.Columns["Foto"].FillWeight = 10;
            dgv.Columns["Sparepart"].FillWeight = 24;
            dgv.Columns["Harga"].FillWeight = 14;
            dgv.Columns["Stok"].FillWeight = 10;
            dgv.Columns["stok_minimum"].FillWeight = 12;
            dgv.Columns["keterangan_stok"].FillWeight = 16;

            dgv.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["kode_sparepart"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Sparepart"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Harga"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dgv.Columns["Foto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["stok_minimum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["kode_sparepart"].HeaderText = "Kode";
            dgv.Columns["keterangan_stok"].HeaderText = "Keterangan";
            dgv.Columns["stok_minimum"].HeaderText = "Stok Minimum";
            dgv.Columns["Stok"].HeaderText = "Stok";
        }

        private void SortingData(object? sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridView1.Columns[e.ColumnIndex];
            var columnName = column.Name;

            // Tentukan mode sorting berikutnya
            if (!columnSortOrder.ContainsKey(columnName) || columnSortOrder[columnName] == SortOrder.None)
            {
                columnSortOrder[columnName] = SortOrder.Descending;
            }
            else if (columnSortOrder[columnName] == SortOrder.Descending)
            {
                columnSortOrder[columnName] = SortOrder.Ascending;
            }
            else
            {
                columnSortOrder[columnName] = SortOrder.None;
            }

            // Update gambar sorting
            UpdateSortGlyph(column);

            // Lakukan sorting dan load data
            LoadData();
        }

        private void UpdateSortGlyph(DataGridViewColumn column)
        {
            // Reset semua kolom ke None
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // Set sort glyph untuk kolom yang aktif
            if (columnSortOrder.ContainsKey(column.Name))
            {
                column.HeaderCell.SortGlyphDirection = columnSortOrder[column.Name];
            }
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
                    string[] targetColumns = { "Foto", "keterangan_stok", "Stok" };

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
            else if (sortOrder == SortOrder.Descending)
                return (Bitmap)Properties.Resources.ArrowDown;
            else
                return (Bitmap)Properties.Resources.edit__2_; // Gambar untuk mode None
        }
        #endregion


        #region PRINT
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
        #endregion
    }
}