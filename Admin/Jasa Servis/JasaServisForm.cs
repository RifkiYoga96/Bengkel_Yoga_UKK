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
        public JasaServisForm()
        {
            InitializeComponent();
            RegisterEvent();
            InitComponent();
            LoadData();
            CustomGrid();
        }

        private void RegisterEvent()
        {

        }

        private void LoadData()
        {
            int no = 1;
            var list = _jasaServisDal.ListData()
                .Select(x => new JasaServisModel
                {
                    No = no++,
                    id_jasaServis = x.id_jasaServis,
                    nama_jasaServis = x.nama_jasaServis,
                    harga = x.harga
                }).ToList();

            dataGridView1.DataSource = new SortableBindingList<JasaServisModel>(list);
        }

        private void InitComponent() 
        {
        
        }

        private void CustomGrid()
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Mengatur ukuran font header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Mengatur warna header kolom
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ForeColor = Color.DimGray;


            // Menonaktifkan warna seleksi untuk sel
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.RowTemplate.Height = 55;

            dataGridView1.RowHeadersVisible = false;

            // Mencegah penggeseran kolom
            dataGridView1.AllowUserToOrderColumns = false;

            // Mencegah pengubahan ukuran kolom
            dataGridView1.AllowUserToResizeColumns = true;

            // Mencegah pengubahan ukuran baris
            dataGridView1.AllowUserToResizeRows = false;

            // Mencegah penambahan baris baru
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 0, 0, 0);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["No"].FillWeight = 6;
            dataGridView1.Columns["id_jasaServis"].FillWeight = 6;
            dataGridView1.Columns["nama_jasaServis"].FillWeight = 30;
            dataGridView1.Columns["harga"].FillWeight = 64;

            dataGridView1.Columns["id_jasaServis"].Visible = false;

            dataGridView1.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["nama_jasaServis"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.Columns["harga"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);


            dataGridView1.Columns["No"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["nama_jasaServis"].HeaderText = "Nama Jasa";
            dataGridView1.Columns["harga"].HeaderText = "Harga";
        }
    }
}
