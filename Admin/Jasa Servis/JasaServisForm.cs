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
    public partial class JasaServisForm : Form
    {
        private readonly JasaServisDal _jasaServisDal = new JasaServisDal();
        private int _page = 1;
        private int _Totalpage = 1;
        private bool _btnMain = true;
        public JasaServisForm()
        {
            InitializeComponent();
            RegisterEvent();
            InitComponent();
            LoadData();
            CustomGrid();
        }

        #region EVENT
        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            btnNext.Click += BtnNext_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnAddData.Click += BtnAddData_Click;
            btnDataDihapus.Click += BtnDataDihapus_Click;

            //btnSearch.Click += BtnSearch_Click;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            restoreStripMenuItem2.Click += RestoreStripMenuItem2_Click;

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
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_jasaServis"].Value);
            _jasaServisDal.SoftDeleteData(id);
            LoadData();
        }

        private void RestoreStripMenuItem2_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin memulihkan data?")) return;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_jasaServis"].Value);
            _jasaServisDal.RestoreData(id);
            LoadData();
        }

        private void EditToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_jasaServis"].Value);
           // if (new FormProduk(id).ShowDialog() != DialogResult.OK) return;
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

        #region LOAD DATAGRID
        private FilterDto? Filter()
        {
            string search = txtSearch.Text;
            bool dataActive = _btnMain;

            string sql = @"";
            var dp = new DynamicParameters();
            List<string> fltr = new List<string>();

            if (search != string.Empty)
            {
                fltr.Add("(nama_jasaServis LIKE  '%' + @search + '%')");
                dp.Add(@"search", search);
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
            var totalRows = _jasaServisDal.GetTotalRows(sqlFilter);

            int showData = (int)numericEntries.Value;
            _Totalpage = Convert.ToInt32(Math.Ceiling((double)totalRows / showData));
            int offset = (_page - 1) * showData;
            sqlFilter.param.Add("@offset", offset);
            sqlFilter.param.Add("@fetch", showData);

            lblHalaman.Text = _page.ToString();
            int toValue = Math.Min(offset + showData, totalRows);
            lblShowingEntries.Text = $"Showing {offset + 1} to {toValue} of {totalRows} entries";

            var list = _jasaServisDal.ListData(sqlFilter)
                .Select((x, index) => new JasaServisModel
                {
                    No = offset + index + 1,
                    id_jasaServis = x.id_jasaServis,
                    nama_jasaServis = x.nama_jasaServis,
                    harga = x.harga
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<JasaServisModel>(list);
        }
        #endregion

        private void InitComponent() 
        {
        
        }

        private void CustomGrid()
        {
            DataGridView dgv = dataGridView1;
            CustomGrids.CustomDataGrid(dgv);

            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["No"].FillWeight = 6;
            dgv.Columns["id_jasaServis"].FillWeight = 6;
            dgv.Columns["nama_jasaServis"].FillWeight = 30;
            dgv.Columns["harga"].FillWeight = 64;

            dgv.Columns["id_jasaServis"].Visible = false;

            dgv.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["nama_jasaServis"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["harga"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);


            dgv.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Columns["nama_jasaServis"].HeaderText = "Nama Jasa";
            dgv.Columns["harga"].HeaderText = "Harga";
        }
    }
}
