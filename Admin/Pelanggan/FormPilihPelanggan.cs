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
    public partial class FormPilihPelanggan : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private int _page = 1;
        private int _Totalpage = 1;
        public FormPilihPelanggan()
        {
            InitializeComponent();
            this.IsDialogForm();
            InitComponent();
            RegisterEvent();
            LoadData();
            StyleGrid();
        }
        private void InitComponent()
        {
            numericEntries.Minimum = 10;
            txtSearch.TextChanged += (s, e) =>
            {
                if (txtSearch.Text.Length == 0)
                    LoadData();
            };
        }

        private void RegisterEvent()
        {
            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnSearch.Click += (s, e) => LoadData();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            btnPilih.Click += (s, e) => SetPelanggan();

        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            SetPelanggan();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData();
            }
        }

        private void SetPelanggan()
        {
            string ktp = dataGridView1.CurrentRow.Cells["KTP"].Value?.ToString()??string.Empty;
            GlobalVariabel.SetKTPPelanggan(ktp);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadData()
        {
            string search = txtSearch.Text;
            string sql = string.Empty;
            var dp = new DynamicParameters();
            if(search != "")
            {
                sql = "WHERE nama_pelanggan LIKE '%' + @search + '%'";
                dp.Add("@search",search);
            }

            var filterDto = new FilterDto
            {
                sql = sql,
                param = dp
            };

            var totalRows = _pelangganDal.GetTotalRows(filterDto);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            filterDto.param.Add("@offset", offset);
            filterDto.param.Add("@fetch", showData);

            var listPelanggan = _pelangganDal.ListData(filterDto)
                .Select((x,index) => new
                {
                    No = offset + index + 1,
                    KTP = x.ktp_pelanggan,
                    Nama = x.nama_pelanggan,
                }).ToList();
            dataGridView1.DataSource = listPelanggan;
        }

        private void StyleGrid()
        {
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["No"].FillWeight = 10;
            dgv.Columns["KTP"].FillWeight = 40;
            dgv.Columns["Nama"].FillWeight = 50;

            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 40;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
        }
    }
}
