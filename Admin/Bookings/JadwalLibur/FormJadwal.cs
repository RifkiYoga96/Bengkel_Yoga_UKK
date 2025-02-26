using Syncfusion.Windows.Forms.Edit.Utils;
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
    public partial class FormJadwal : Form
    {
        private readonly JadwalLiburDal _jadwalLiburDal = new JadwalLiburDal();
        private List<JadwalLiburDto> _listJadwalLibur = new List<JadwalLiburDto>();
        private bool _tanggal = true;
        private List<string> _hari;
        public FormJadwal()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }
        private void InitComponent()
        {
            _hari = new List<string>() 
            {
                "--Pilih Hari--","Senin","Selasa","Rabu","Kamis","Jum'at","Sabtu","Minggu"
            };
            comboHari.DataSource = null;
            comboHari.Enabled = false;
            TglEditSync.StyleDateTimeEdit();
        }

        private void RegisterEvent()
        {
            btnTanggal.Click += (s, e) => btnTanggalControl();
            btnHarian.Click += (s, e) => btnHarianControl();

            dataGridView1.CellDoubleClick += (s, e) =>
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                GetData(id);
            };
        }

        private void btnHarianControl()
        {
            if (!_tanggal) return;
            btnTanggal.ForeColor = SystemColors.ControlDarkDark;
            btnTanggal.BackColor = Color.Gainsboro;
            btnHarian.ForeColor = Color.White;
            btnHarian.BackColor = Color.FromArgb(128, 128, 255);
            comboHari.Enabled = true;
            TglEditSync.Enabled = false;
            TglEditSync.Format = " ";
            comboHari.DataSource = _hari;
            comboHari.SelectedIndex = 0;
            _tanggal = !_tanggal;
        }

        private void btnTanggalControl()
        {
            if (_tanggal) return;
            btnTanggal.ForeColor = Color.White;
            btnTanggal.BackColor = Color.FromArgb(128, 128, 255);
            btnHarian.ForeColor = SystemColors.ControlDarkDark;
            btnHarian.BackColor = Color.Gainsboro;
            comboHari.Enabled = false;
            TglEditSync.Enabled = true;
            TglEditSync.Format = "dddd, dd-MM-yyyy";
            comboHari.DataSource = null;

            _tanggal = !_tanggal;
        }

        private void LoadData()
        {
            var data = _jadwalLiburDal.ListData()
                .Select((x, index) => new JadwalLiburDto
                {
                    id_jadwal_libur = x.id_jadwal_libur,
                    No = index + 1,
                    Libur = x.hari ?? x.tanggal?.ToString("dddd, dd-MM-yyyy", new System.Globalization.CultureInfo("id-ID")) ?? string.Empty
                }).ToList();
            foreach (var itm in data)
                _listJadwalLibur.Add(itm);
            dataGridView1.DataSource = data;
        }

        private void CustomGrid()
        {
            DataGridView dgv = dataGridView1;
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


/*          dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.Columns[1].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.Columns[3].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);*/
        }

        private void GetData(int id)
        {
            var data = _jadwalLiburDal.GetData(id);
            if (data is null) return;

            if (data.hari != null)
            {
                btnHarianControl();
                foreach (var item in comboHari.Items)
                    if ((string)item == (string)data.hari)
                        comboHari.SelectedItem = item;
                _tanggal = false;
            }
            else
            {
                btnTanggalControl();
                TglEditSync.Value = data.tanggal;
                _tanggal = true;
            }
        }

        private void SaveData()
        {
            if (!_tanggal && comboHari.SelectedIndex == 0)
            {
                MB.Warning("Mohon pilih hari yang valid!");
                return;
            }

            

            if (!_tanggal)
            {
                string hari = comboHari.SelectedValue.ToString();
                var cek = _listJadwalLibur.FirstOrDefault(x => x.Libur == );
            }
            else
            {

            }

        }
    }
}
