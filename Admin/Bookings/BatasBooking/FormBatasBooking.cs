using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormBatasBooking : Form
    {
        private readonly BatasBookingDal _batasBookingDal = new BatasBookingDal();
        private int _id_batas_booking = 0;
        private bool _isDefault = false;
        private string _tglFormat = "dddd, dd-MM-yyyy";
        private bool _InsertReady = false;
        public FormBatasBooking()
        {
            InitializeComponent();
            this.IsDialogForm();
            InitComponent();
            RegisterEvent();
            _batasBookingDal.DeleteDataTerlewat();
            LoadData();
            CustomGrid();
            ClearInput();
        }
        private void InitComponent()
        {
            TglEditSync.StyleDateTimeEdit();
            TglEditSync.MinDateTime = DateTime.Today;
            TglEditSync.Format = _tglFormat;
            txtBatas.MaxValue = 1000;
            txtBatas.MinValue = 1;
            txtBatas.BorderColor = Color.FromArgb(156, 156, 156);
        }

        private void RegisterEvent()
        {
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin membuat data baru?")) return;
            ClearInput();
            TglEditSync.Enabled = true;
            EnableTxt(txtBatas, true);
            TglEditSync.Format = _tglFormat;
            lblHeader.Text = "Insert Batas Booking";
            _InsertReady = true;
            _isDefault = false;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!_InsertReady) return;
            DateTime tgl = Convert.ToDateTime(TglEditSync.Value);
            
            if (_batasBookingDal.CekTanggal(tgl,_id_batas_booking == 0 ? true : false, _id_batas_booking) != null && !_isDefault)
            {
                MB.Error("Tanggal sudah tersedia !");
                return;
            }

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data !")) return;
            var data = new BatasBookingModel
            {
                id_batas_booking = _id_batas_booking,
                tanggal = _isDefault ? null : TglEditSync.Value,
                batas_booking = (int)txtBatas.IntegerValue
            };
            if (_id_batas_booking == 0)
                _batasBookingDal.InsertData(data);
            else
                _batasBookingDal.UpdateData(data);
            LoadData();
            ClearInput();
            _id_batas_booking = 0;
            _InsertReady = false;
            _isDefault = false;
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var data = _batasBookingDal.GetData(id);
            if (data is null) return;

            if(data.tanggal is null)
            {
                TglEditSync.Enabled = false;
                TglEditSync.Format = " ";
                _isDefault = true;
            }
            else
            {
                TglEditSync.Enabled = true;
                TglEditSync.Format = _tglFormat;
                TglEditSync.Value = (DateTime)data.tanggal;
                _isDefault = false;
            }
            _id_batas_booking = id;
            txtBatas.IntegerValue = (int)data.batas_booking;
            lblHeader.Text = "Edit Batas Booking";
            EnableTxt(txtBatas,true);
            _InsertReady = true;
        }

        private void DeleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            bool data = (bool)dataGridView1.CurrentRow.Cells[4].Value;
            if (data)
            {
                MB.Warning("Data default tidak dapat dihapus!");
            }
            else if (MB.Konfirmasi("Apakah anda yakin ingin menghapus data ini?"))
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                if (id == _id_batas_booking) ClearInput();
                _batasBookingDal.DeleteData(id);
                LoadData();
            }
        }

        private void DataGridView1_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _batasBookingDal.ListData()
                .Select((x,index) => new
                {
                    Id = x.id_batas_booking,
                    No = index + 1,
                    Tanggal = x.tanggal?.ToString(_tglFormat, new System.Globalization.CultureInfo("id_ID")) ?? "Default",
                    BatasBooking = x.batas_booking,
                    IsDefault = x.tanggal == null
                }).ToList();
        }
        private void ClearInput()
        {
            TglEditSync.Enabled = false;
            txtBatas.Enabled = false;
            TglEditSync.Value = DateTime.Today;
            txtBatas.IntegerValue = 1;
            TglEditSync.Format = " ";
            lblHeader.Text = "Batas Booking";
            EnableTxt(txtBatas,false);
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


            dgv.Columns[1].FillWeight = 20;
            dgv.Columns[2].FillWeight = 50;
            dgv.Columns[3].FillWeight = 30;

            dgv.Columns[0].Visible = false;
            dgv.Columns[4].Visible = false;


            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dgv.Columns[1].HeaderText = "  No";
            dgv.Columns[3].HeaderText = "Batas Booking"; 

            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.Columns[1].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.Columns[3].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);

        }

        private void EnableTxt(IntegerTextBox txt, bool active)
        {
            if (active)
            {
                txt.BackGroundColor = Color.White;
                txt.Enabled = true;
            }
            else
            {
                txt.BackGroundColor = SystemColors.Control;
                txt.Enabled = false;
            }
        }
    }
}
