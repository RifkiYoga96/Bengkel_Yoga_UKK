using Syncfusion.Windows.Forms.Edit.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormJadwal : Form
    {
        private readonly JadwalDal _jadwalLiburDal = new JadwalDal();
        private readonly JadwalOperasionalDal _jadwalOperasionalDal = new JadwalOperasionalDal();
        private List<JadwalDto> _listJadwalLibur = new List<JadwalDto>();
        private int _controlLibur = 0;
        private bool _isInsertLibur = true;
        private bool _isDefaultOperasional = true;
        private List<string> _hariLibur = new List<string>();
        private List<string> _hariOperasional = new List<string>();
        private string _tglFormat = "dddd, dd-MM-yyyy";
        private int _id_jadwal_libur = 0;
        private int _id_jadwal_operasional = 0;
        public FormJadwal()
        {
            InitializeComponent();
            this.IsDialogForm();

            InitComponentOperasional();
            RegisterEventOperasional();
            ClearInputOperasional();
            LoadDataOperasional();
            CustomGridOperasional();

            InitComponentLibur();
            RegisterEventLibur();
            LoadDataLibur();
            CustomGridLibur();
        }


        #region JAM OPERASIONAL

        private void InitComponentOperasional()
        {
            _hariOperasional = new List<string>()
            {
                 "--Pilih Hari--","Senin","Selasa","Rabu","Kamis","Jum'at","Sabtu","Minggu"
            };
            comboHari.DataSource = _hariOperasional;
            comboHari.SelectedIndex = 0;
        }

        private void RegisterEventOperasional()
        {
            btnSave.Click += (s, e) => SaveDataOperasional();
            gridOperasional.CellDoubleClick += (s, e) =>
            {
                int id = Convert.ToInt32(gridOperasional.CurrentRow.Cells[0].Value);
                GetDataOperasional(id);
            };
            btnNew.Click += (s, e) =>
            {
                if (!MB.Konfirmasi("Apakah anda yakin ingin membuat data baru?")) return;
                ClearInputOperasional(false);
                lblMode.Text = "Mode : Insert";
                _id_jadwal_operasional = 0;
            };
            gridOperasional.CellMouseClick += GridOperasional_CellMouseClick;
            toolStripDeleteOperasional.Click += ToolStripDeleteOperasional_Click;
        }

        private void ToolStripDeleteOperasional_Click(object? sender, EventArgs e)
        {
            var currentRow = gridOperasional.CurrentRow;
            if (currentRow.Cells[2].Value.ToString() == "Default")
            {
                MB.Warning("Data default tidak bisa dihapus!");
                return;
            }
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus datggga?")) return;
            int id = Convert.ToInt32(currentRow.Cells[0].Value);
            _jadwalOperasionalDal.DeleteData(id);
            if (_id_jadwal_operasional == id)
                ClearInputOperasional();
            LoadDataOperasional();
        }

        private void GridOperasional_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                gridOperasional.ClearSelection();
                gridOperasional.CurrentCell = gridOperasional.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuOperasional.Show(Cursor.Position);
            }
        }

        private void LoadDataOperasional()
        {
            var data = _jadwalOperasionalDal.ListData()
                .Select((x,index) => new
                {
                    id_jadwal_operasional = x.id_jadwal_operasional,
                    No = index + 1,
                    Hari = x.hari ?? "Default",
                    JamBuka = x.jam_buka.ToString(@"hh\:mm") ?? string.Empty,
                    JamTutup = x.jam_tutup.ToString(@"hh\:mm") ?? string.Empty,
                }).ToList();
            gridOperasional.DataSource = data;
        }
        private void GetDataOperasional(int id)
        {
            var data = _jadwalOperasionalDal.GetData(id);
            if (data is null) return;

            ClearInputOperasional(false);
            lblMode.Text = "Mode : Edit";
            if(data.hari is null)
            {
                comboHari.DataSource = null;
                comboHari.Enabled = false;
                _isDefaultOperasional = true;
            }
            else
            {
                _isDefaultOperasional = false;
            }

            if(data.hari != null)
                foreach (var item in comboHari.Items)
                    if ((string)item == (string)data.hari)
                        comboHari.SelectedItem = item;
            jam1.Value = DateTime.Today.Add(data.jam_buka);
            jam2.Value = DateTime.Today.Add(data.jam_tutup);

            _id_jadwal_operasional = id;
        }
        private void ClearInputOperasional(bool clean = true)
        {
            if (clean)
            {
                comboHari.Enabled = false;
                jam1.Enabled = false;
                jam2.Enabled = false;

                comboHari.DataSource = null;
                jam1.CustomFormat = " ";
                jam2.CustomFormat = " ";
                lblMode.Text = "Mode : Normal";
            }
            else
            {
                comboHari.Enabled = true;
                jam1.Enabled = true;
                jam2.Enabled = true;

                jam1.CustomFormat = "   HH:mm";
                jam2.CustomFormat = "   HH:mm";
                comboHari.DataSource = _hariOperasional;
                jam1.Value = DateTime.Parse("00:00");
                jam2.Value = DateTime.Parse("00:00");
            }
        }

        private void SaveDataOperasional()
        {
            string? hari = comboHari.SelectedIndex == 0 ? null :comboHari.SelectedValue?.ToString();
            TimeSpan jamBuka = jam1.Value.TimeOfDay;
            TimeSpan jamTutup = jam2.Value.TimeOfDay;

            if(jamBuka == jamTutup)
            {
                MB.Warning("Jam buka dan jam tutup tidak boleh sama!");
                return;
            }
            if(hari is null && !_isDefaultOperasional)
            {
                MB.Warning("Data tidak valid!");
                return;
            }

            if (hari != null)
            {
                var cek = _jadwalOperasionalDal.CekHari(hari, _id_jadwal_operasional == 0 ? true : false, _id_jadwal_operasional);
                if (cek != null)
                {
                    MB.Error($"Hari {hari} sudah tersedia!");
                    return;
                }
            }

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;
            var data = new JadwalOperasionalModel
            {
                id_jadwal_operasional = _id_jadwal_operasional,
                hari = hari,
                jam_buka = jamBuka,
                jam_tutup = jamTutup
            };

            if (_id_jadwal_operasional == 0)
                _jadwalOperasionalDal.InsertData(data);
            else
                _jadwalOperasionalDal.UpdateData(data);

            ClearInputOperasional();
            LoadDataOperasional();
        }

        private void CustomGridOperasional()
        {
            DataGridView dgv = gridOperasional;
            CustomGrids.CustomDataGrid(dgv);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 126, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 126, 34);

            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 40;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns[1].FillWeight = 15;
            dgv.Columns[2].FillWeight = 35;
            dgv.Columns[3].FillWeight = 25;
            dgv.Columns[4].FillWeight = 25;

            dgv.Columns[0].Visible = false;

            dgv.Columns[3].HeaderText = "Jam Buka";
            dgv.Columns[4].HeaderText = "Jam Tutup";

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
        }
        #endregion


        #region LIBUR
        private void InitComponentLibur()
        {
            _hariLibur = new List<string>()
            {
                "--Pilih Hari--","Senin","Selasa","Rabu","Kamis","Jum'at","Sabtu","Minggu"
            };
            comboHari2.DataSource = null;
            comboHari2.Enabled = false;
            TglEditSync2.StyleDateTimeEdit();
        }

        private void RegisterEventLibur()
        {
            btnTanggal2.Click += (s, e) => btnTanggalControl();
            btnHarian2.Click += (s, e) => btnHarianControl();

            gridLibur.CellDoubleClick += (s, e) =>
            {
                int id = Convert.ToInt32(gridLibur.CurrentRow.Cells[0].Value);
                GetDataLibur(id);
            };
            btnSave2.Click += (s, e) => SaveDataLibur();
            btnNew2.Click += BtnNew_Click;
            gridLibur.CellMouseClick += GridLibur_CellMouseClick;
            toolStripDeleteLibur.Click += ToolStripDeleteLibur_Click;
        }

        private void ToolStripDeleteLibur_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus data?")) return;
            int id = Convert.ToInt32(gridLibur.CurrentRow.Cells[0].Value);
            _jadwalLiburDal.DeleteData(id);
            if (_id_jadwal_libur == id)
                ClearDataLibur();
            LoadDataLibur();
        }

        private void GridLibur_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                gridLibur.ClearSelection();
                gridLibur.CurrentCell = gridLibur.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStripLibur.Show(Cursor.Position);
            }
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin membuat data baru?")) return;

            _isInsertLibur = true;
            _controlLibur = 0;
            btnTanggalControl();
            TglEditSync2.Value = DateTime.Today;
            _id_jadwal_libur = 0;
            lblHeader.Text = "Input Jadwal Libur";
        }

        private void btnHarianControl()
        {
            btnHarian2.Enabled = true;
            btnTanggal2.Enabled = true;
            if (_controlLibur == 2) return;
            btnTanggal2.ForeColor = SystemColors.ControlDarkDark;
            btnTanggal2.BackColor = Color.Gainsboro;
            btnHarian2.ForeColor = Color.White;
            btnHarian2.BackColor = Color.FromArgb(128, 128, 255);
            comboHari2.Enabled = true;
            TglEditSync2.Enabled = false;
            TglEditSync2.Format = " ";
            comboHari2.DataSource = _hariLibur;
            comboHari2.SelectedIndex = 0;

            _controlLibur = 2;
        }

        private void btnTanggalControl()
        {
            btnHarian2.Enabled = true;
            btnTanggal2.Enabled = true;
            if (_controlLibur == 1) return;
            btnTanggal2.ForeColor = Color.White;
            btnTanggal2.BackColor = Color.FromArgb(128, 128, 255);
            btnHarian2.ForeColor = SystemColors.ControlDarkDark;
            btnHarian2.BackColor = Color.Gainsboro;
            comboHari2.Enabled = false;
            TglEditSync2.Enabled = true;
            TglEditSync2.Format = _tglFormat;
            comboHari2.DataSource = null;

            _controlLibur = 1;
        }

        private void ClearDataLibur()
        {
            _id_jadwal_libur = 0;
            _controlLibur = 0;

            TglEditSync2.Format = " ";
            TglEditSync2.Enabled = false;
            comboHari2.DataSource = null;
            comboHari2.Enabled = false;
            btnTanggal2.BackColor = Color.Gainsboro;
            btnHarian2.BackColor = Color.Gainsboro;
            btnTanggal2.Enabled = false;
            btnHarian2.Enabled = false;

            lblHeader.Text = "Jadwal Libur";
        }

        private void LoadDataLibur()
        {
            var today = DateTime.Today;
            var hariUrutan = new Dictionary<string, int>
            {
                { "Senin", 1 }, { "Selasa", 2 }, { "Rabu", 3 }, { "Kamis", 4 },
                { "Jumat", 5 }, { "Sabtu", 6 }, { "Minggu", 7 }
            };

            var data = _jadwalLiburDal.ListData()
                 .Select(x => new
                 {
                     id_jadwal_libur = x.id_jadwal_libur,
                     Libur = x.hari ?? x.tanggal?.ToString(_tglFormat, new System.Globalization.CultureInfo("id-ID")) ?? string.Empty,
                     Tanggal = x.tanggal,
                     HariUrutan = x.hari != null && hariUrutan.ContainsKey(x.hari) ? hariUrutan[x.hari] : int.MaxValue
                 })
                 .OrderBy(x => x.Tanggal.HasValue ? 0 : 1)
                 .ThenBy(x => x.Tanggal.HasValue ? (x.Tanggal >= today ? x.Tanggal : x.Tanggal.Value.AddYears(1)) : DateTime.MaxValue)
                 .ThenBy(x => x.HariUrutan)
                 .Select((x, index) => new JadwalDto
                 {
                     id_jadwal_libur = x.id_jadwal_libur,
                     No = index + 1,
                     Libur = x.Libur
                 })
                 .ToList();

            _listJadwalLibur.Clear();
            foreach (var itm in data)
                _listJadwalLibur.Add(itm);
            gridLibur.DataSource = data;
        }

        private void CustomGridLibur()
        {
            DataGridView dgv = gridLibur;
            CustomGrids.CustomDataGrid(dgv);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 126, 34);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 126, 34);

            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 40;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns[1].FillWeight = 30;
            dgv.Columns[2].FillWeight = 70;

            dgv.Columns[0].Visible = false;



            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
        }

        private void GetDataLibur(int id)
        {
            var data = _jadwalLiburDal.GetData(id);
            if (data is null) return;

            if (data.hari != null)
            {
                btnHarianControl();
                foreach (var item in comboHari2.Items)
                    if ((string)item == (string)data.hari)
                        comboHari2.SelectedItem = item;
            }
            else
            {
                btnTanggalControl();
                TglEditSync2.Value = data.tanggal;
            }
            _id_jadwal_libur = id;
            lblHeader.Text = "Edit Jadwal Libur";
            _isInsertLibur = false;
        }

        private void SaveDataLibur()
        {
            if (_controlLibur == 2 && comboHari2.SelectedIndex == 0)
            {
                MB.Warning("Mohon pilih hari yang valid!");
                return;
            }

            if (_controlLibur == 2)
            {
                string hari = comboHari2.SelectedValue?.ToString() ?? string.Empty;
                var cek = _listJadwalLibur
                    .FirstOrDefault(x => _isInsertLibur ? x.Libur == hari : x.Libur == hari && x.id_jadwal_libur != _id_jadwal_libur);
                if (cek != null)
                {
                    MB.Error($"Hari {hari} sudah tersedia!");
                    return;
                }
                if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;
                var data = new JadwalModel
                {
                    id_jadwal_libur = _id_jadwal_libur,
                    hari = hari
                };
                if (_id_jadwal_libur == 0)
                    _jadwalLiburDal.InsertData(data);
                else
                    _jadwalLiburDal.UpdateData(data);
            }
            else if (_controlLibur == 1)
            {
                DateTime tanggal = Convert.ToDateTime(TglEditSync2.Value);
                string strTanggal = tanggal.ToString(_tglFormat, new System.Globalization.CultureInfo("id-ID"));
                var cek = _listJadwalLibur
                    .FirstOrDefault(x => _isInsertLibur ? x.Libur == strTanggal : x.Libur == strTanggal && x.id_jadwal_libur != _id_jadwal_libur);
                if (cek != null)
                {
                    MB.Error($"Tanggal {strTanggal} sudah tersedia!");
                    return;
                }
                if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;
                var data = new JadwalModel
                {
                    id_jadwal_libur = _id_jadwal_libur,
                    tanggal = tanggal
                };
                if (_id_jadwal_libur == 0)
                    _jadwalLiburDal.InsertData(data);
                else
                    _jadwalLiburDal.UpdateData(data);
            }
            LoadDataLibur();
            ClearDataLibur();
        }
        #endregion
    }
}
