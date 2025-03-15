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
        private BindingList<ProdukAddDto> _bindingListFilter = new BindingList<ProdukAddDto>();
        private BindingSource _bindingSource = new BindingSource();
        private BindingList<ProdukAddDto> _bindingListUse = new BindingList<ProdukAddDto>();
        private BindingSource _bindingSourceUse = new BindingSource();
        private readonly BookingDal _bookingDal = new BookingDal();
        private int _stokBeginEdit = 0;

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

                dgv.ColumnHeadersHeight = 30;
                dgv.RowTemplate.Height = 35;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv.Columns[0].FillWeight = 20;
                dgv.Columns[1].FillWeight = 30;
                dgv.Columns[2].FillWeight = 25;
                dgv.Columns[3].FillWeight = 25;

                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

                dgv.Columns[0].HeaderText = "  Kode";

                dgv.Columns[0].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            }
            gs.Columns[3].Visible = false;
            gs.Columns[4].Visible = false;
            gsu.Columns[4].Visible = false;

            gsu.Columns[0].ReadOnly = true;
            gsu.Columns[1].ReadOnly = true;
            gsu.Columns[2].ReadOnly = true;
            gsu.Columns[3].ReadOnly = false;
        }

        private void LoadData()
        {
            var listBookingSparepart = _bookingDal.ListDataProduk(FormDetailBooking._id_booking);
            var bookedKodeSpareparts = listBookingSparepart.Select(x => x.kode_sparepart).ToHashSet();

            var listSparepart = _bookingDal.ListDataSparepart()
                .OrderBy(x => x.Sparepart);

            var listNoUse = listSparepart
                .Where(x => !bookedKodeSpareparts.Contains(x.Kode))
                .ToList();


            var listUse = listSparepart.Where(x => bookedKodeSpareparts.Contains(x.Kode)).ToList();

            _bindingList.Clear();
            foreach (var item in listNoUse)
                _bindingList.Add(item);

            _bindingListUse.Clear();
            foreach (var item in listUse)
                _bindingListUse.Add(item);
        }


        private void RegisterEvent()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += (s, e) =>
            {
                SaveComponent();
            };
            gridSparepart.CellDoubleClick += GridSparepart_CellDoubleClick;
            gridSparepartUse.CellDoubleClick += GridSparepartUse_CellDoubleClick;
            txtSearch.TextChanged += async (s, e) =>
            {
                await Task.Delay(800);
                Filtering();
            };
            gridSparepartUse.CellValueChanged += GridSparepartUse_CellValueChanged;
            gridSparepartUse.EditingControlShowing += GridSparepartUse_EditingControlShowing;
            gridSparepartUse.CellBeginEdit += GridSparepartUse_CellBeginEdit;
        }

        private void GridSparepartUse_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            int stok = Convert.ToInt32(gridSparepartUse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            _stokBeginEdit = stok;
        }

        private void GridSparepartUse_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridSparepartUse.CurrentCell.ColumnIndex == gridSparepartUse.Columns["Jumlah"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= TextBox_KeyPress;
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }
        }
        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void GridSparepartUse_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            await Task.Delay(500);
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var indexRow = gridSparepartUse.Rows[e.RowIndex];
            var currentRow = indexRow.Cells[e.ColumnIndex].Value;
            if(!int.TryParse(currentRow.ToString(), out int jumlah))
            {
                MB.Warning("Jumlah harus berupa angka!");
            }
            else
            {
                int stok = Convert.ToInt32(indexRow.Cells["Stok"].Value);
                if(jumlah > stok)
                {
                    MB.Warning("Jumlah tidak boleh melebihi sparepart!");
                    gridSparepartUse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _stokBeginEdit;
                }
            }
        }

        private void GridSparepartUse_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _bindingListUse.Count == 0) return;

            _bindingList.Add(_bindingListUse[e.RowIndex]);
            _bindingListUse.RemoveAt(e.RowIndex);

            txtSearch.Text = string.Empty;
            _bindingSource.DataSource = _bindingList;
        }

        private void GridSparepart_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _bindingList.Count == 0 || _bindingList[e.RowIndex].Stok == 0) return;

            string kode = gridSparepart.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
            int index = _bindingList.ToList().FindIndex(x => x.Kode == kode);
            int indexFilter = _bindingListFilter.ToList().FindIndex(x => x.Kode == kode);

            _bindingListUse.Add(_bindingList[index]);
            _bindingList.RemoveAt(index);

            if(indexFilter != -1)
                _bindingListFilter.RemoveAt(indexFilter);
        }

        private void Filtering()
        {
            if (txtSearch.Text.Length > 0)
            {
                var filter = _bindingList.Where(x => x.Sparepart.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                _bindingListFilter.Clear();
                foreach (var item in filter)
                    _bindingListFilter.Add(item);
                _bindingSource.DataSource = _bindingListFilter;
            }
            else
            {
                _bindingSource.DataSource = _bindingList;
            }
        }

        private void SaveComponent()
        {
            _bookingDal.DeleteBookingSparepart(FormDetailBooking._id_booking);
            var list = _bookingDal.ListDataProduk(FormDetailBooking._id_booking);
            foreach (var item in list)
            {
                _bookingDal.InsertDataBookingSparepart(new ProdukAddDto
                {
                    id_booking = FormDetailBooking._id_booking,
                    Kode = item.kode_sparepart,
                    Jumlah = item.jumlah
                });
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

public class ProdukAddDto
{
    public string Kode { get; set; }
    public string Sparepart { get; set; }
    public int Stok {  get; set; }
    public int Jumlah {  get; set; }
    public int id_booking { get; set; }
}
