using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Bengkel_Yoga_UKK
{
    public partial class FormAddSparepart : Form
    {
        private readonly ProdukDal _produkDal = new ProdukDal();
        private BindingList<ProdukAddDto> _bindingList = new BindingList<ProdukAddDto>();
        private BindingSource _bindingSource = new BindingSource();
        private BindingList<ProdukAddDto> _bindingListUse = new BindingList<ProdukAddDto>();
        private BindingSource _bindingSourceUse = new BindingSource();
        private CancellationTokenSource _cts;
        private int _click = 0;
        public FormAddSparepart()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
            LoadData();
            CustomGrid();
        }

        private void InitComponent()
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _bindingSource.DataSource = _bindingList;
            gridSparepart.DataSource = _bindingSource;

            _bindingSourceUse.DataSource = _bindingListUse;
            gridSparepartUse.DataSource = _bindingSourceUse;

            gridSparepart.AllowUserToAddRows = false;
            gridSparepart.ReadOnly = true;
            gridSparepartUse.AllowUserToAddRows = false;

            if (_bindingList.Count > 0) return;

            int i = 0;
            foreach(var item in _bindingList)
            {
                if (item.Stok == 0)
                    gridSparepart.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                i++;
            }

        }

        private void CustomGrid()
        {
            DataGridView gs = gridSparepart;
            DataGridView gsu = gridSparepartUse;

            DataGridView[] dgvs = { gs, gsu };

            foreach(var dgv in dgvs)
            {
                CustomGrids.CustomDataGrid(dgv);

                dgv.ColumnHeadersHeight = 25;
                dgv.RowTemplate.Height = 30;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv.Columns[0].FillWeight = 20;
                dgv.Columns[1].FillWeight = 30;
                dgv.Columns[2].FillWeight = 25;
                dgv.Columns[3].FillWeight = 25;

                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                dgv.Columns[0].HeaderText = "  Kode";

                dgv.Columns[0].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            }
            gs.Columns[3].Visible = false;
            gsu.Columns[2].Visible = false;

            gsu.Columns[0].ReadOnly = true;
            gsu.Columns[1].ReadOnly = true;
            gsu.Columns[2].ReadOnly = true;
            gsu.Columns[3].ReadOnly = false;
        }

        private void LoadData()
        {
            var listSparepart = _produkDal.ListData()
                .OrderBy(x =>  x.nama_sparepart)
                .Select(x => new ProdukAddDto
                {
                    Kode = x.kode_sparepart,
                    Sparepart = x.nama_sparepart,
                    Stok = x.stok,
                    Jumlah = 1
                }).ToList();

            _bindingList.Clear();
            foreach (var item in listSparepart)
                _bindingList.Add(item);
        }


        private void RegisterEvent()
        {
            btnCancel.Click += (s, e) => this.Close();
            gridSparepart.CellDoubleClick += GridSparepart_CellDoubleClick;
            gridSparepartUse.CellDoubleClick += GridSparepartUse_CellDoubleClick;
        }
        

        private void GridSparepartUse_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _bindingListUse.Count == 0) return;
            _bindingList.Add(_bindingListUse[e.RowIndex]);
            _bindingListUse.RemoveAt(e.RowIndex);
        }

        private void GridSparepart_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _bindingList.Count == 0 || _bindingList[e.RowIndex].Stok == 0) return;

            _bindingListUse.Add(_bindingList[e.RowIndex]);
            _bindingList.RemoveAt(e.RowIndex);
        }

    }
}

public class ProdukAddDto
{
    public string Kode { get; set; }
    public string Sparepart { get; set; }
    public int Stok {  get; set; }
    public int Jumlah {  get; set; }
}
