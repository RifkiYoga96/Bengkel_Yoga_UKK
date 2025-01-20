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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            InitDataGrid();
        }

        private void InitDataGrid()
        {
            // Menambahkan kolom ke DataGridView
            dataGridView1.Columns.Add("Column1", "Kolom 1");
            dataGridView1.Columns.Add("Column2", "Kolom 2");
            dataGridView1.Columns.Add("Column3", "Kolom 3");

            // Menambahkan baris data acak
            Random random = new Random();
            for (int i = 0; i < 10; i++) // Menambahkan 10 baris
            {
                // Data acak untuk setiap kolom
                string col1 = "Data " + (i + 1);
                string col2 = (random.Next(100)).ToString(); // Angka acak antara 0-99
                string col3 = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"); // Tanggal acak

                // Menambahkan baris ke DataGridView
                dataGridView1.Rows.Add(col1, col2, col3);
            }

            dataGridView1.Rows[2].Cells[2].Style.ForeColor = Color.White;
        }
    }
}
