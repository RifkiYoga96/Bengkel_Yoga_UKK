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
    public partial class FormKaryawan : Form
    {
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private int page = 1;
        private byte[] _defaultProfile = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.defaultProfile, 45, 45));
        private int _page = 1;
        private int _Totalpage = 1;
        private bool _btnMain = true;
        public FormKaryawan()
        {
            InitializeComponent();
            RegisterEvent();
            InitCombo();

            LoadData();
            CustomGrid();
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
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            restoreStripMenuItem2.Click += RestoreStripMenuItem2_Click;
            comboFilter.SelectedIndexChanged += (s, e) => LoadData();
            txtSearch.TextChanged += async (s, e) =>
            {
                await Task.Delay(500);
                LoadData();
            };
        }


        private void RestoreStripMenuItem2_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin memulihkan data?")) return;
            string ktp = dataGridView1.CurrentRow.Cells["ktp_admin"].Value?.ToString() ?? string.Empty;
            _karyawanDal.RestoreData(ktp);
            LoadData();
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus data?")) return;
            string ktp = dataGridView1.CurrentRow.Cells["ktp_admin"].Value?.ToString() ?? string.Empty;
            _karyawanDal.SoftDeleteData(ktp);
            LoadData();
        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string ktp = dataGridView1.CurrentRow.Cells["ktp_admin"].Value?.ToString() ?? string.Empty;
            if (new FormInputKaryawan(ktp, false).ShowDialog() != DialogResult.OK) return;
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
                StyleComponent.ControlButtonMainDelete(btnAddData, btnDataDihapus, img, true, "Pegawai");
                _btnMain = true;
                LoadData();
                return;
            }
            if (new FormInputKaryawan("",true).ShowDialog() == DialogResult.OK)
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
            if (page > 1)
            {
                page--;
                lblHalaman.Text = page.ToString();
                LoadData();
            }
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (page <= 10)
            {
                page++;
                lblHalaman.Text = page.ToString();
                LoadData();
            }
        }
        #endregion

        #region COMBO BOX
        private void InitCombo()
        {
            List<string> list = new List<string>()
            {
                "Semua (All)","Mekanik","Petugas","Super Admin"
            };
            comboFilter.DataSource = list;
        }
        #endregion

        #region LOAD DATAGRID
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            int status = comboFilter.SelectedIndex - 1;
            bool dataActive = _btnMain;

            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(ktp_admin LIKE @search + '%' OR nama_admin LIKE '%' + @search + '%' OR alamat LIKE '%' + @search + '%' + @search + '%' OR email LIKE '%' + @search + '%' + @search + '%' OR no_telp LIKE '%' + @search + '%')");
                dp.Add(@"search", search);
            }
            if (comboFilter.SelectedIndex != 0)
            {
                fltr.Add("(role = @role)");
                dp.Add(@"role", status);
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
            var totalRows = _karyawanDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";

            var list = _karyawanDal.ListData(sqlFilter)
                .Select((x,index) => new KaryawanDto()
                {
                    No = offset + index + 1,
                    ktp_admin = x.ktp_admin,
                    Foto = x.image_data != null ? ImageConvert.ImageToByteArray(ImageConvert.SmoothImagePictureBox(ImageConvert.Image_ByteToImage(x.image_data), 45, 45))
                        : _defaultProfile,
                    Nama = x.nama_admin,
                    Email = x.email,
                    Password = x.password,
                    Telepon = x.no_telp,
                    Alamat = x.alamat,
                    Role = x.role == 0 ? "Mekanik" 
                        : x.role == 1 ? "Petugas"
                        : "Super Admin"
                }).ToList();
            dataGridView1.DataSource = new SortableBindingList<KaryawanDto>(list);
        }

        #endregion

        #region DATAGRID CUSTOM
        private void CustomGrid()
        {
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["No"].FillWeight = 6;
            dgv.Columns["ktp_admin"].FillWeight = 9;
            dgv.Columns["Foto"].FillWeight = 10;
            dgv.Columns["Nama"].FillWeight = 16;
            dgv.Columns["Email"].FillWeight = 15;
            dgv.Columns["Password"].FillWeight = 10;
            dgv.Columns["Telepon"].FillWeight = 12;
            dgv.Columns["Alamat"].FillWeight = 12;
            dgv.Columns["Role"].FillWeight = 10;

            dgv.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["ktp_admin"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Foto"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dgv.Columns["Nama"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Email"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Password"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Telepon"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Alamat"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["Role"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            dgv.Columns["Foto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Role"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgv.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["ktp_admin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["Password"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["Telepon"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns["Role"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Columns["ktp_admin"].HeaderText = "No KTP";

            dgv.Columns["password"].Visible = false;
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
                    string[] targetColumns = { "Foto","Role" };

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

public class KaryawanDto
{
    public int No { get; set; }
    public string ktp_admin { get; set; }
    public byte[] Foto { get; set; }
    public string Nama { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telepon { get; set; }
    public string Alamat { get; set; }
    public string Role { get; set; }
}