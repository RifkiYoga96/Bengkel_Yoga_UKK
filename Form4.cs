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
        private DataGridView dataGridView;
        public Form4()
        {
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoGenerateColumns = false;

            // Tambahkan kolom biasa
            dataGridView.Columns.Add("PRODUK", "Produk");
            dataGridView.Columns.Add("HARGA", "Harga");
            dataGridView.Columns.Add("STOK", "Stok");

            // Tambahkan kolom button
            var buttonColumn = new DataGridViewButtonColumn
            {
                Name = "BUTTON",
                HeaderText = "Aksi",
                Text = "Klik Saya", // Teks default pada button
                UseColumnTextForButtonValue = true // Gunakan teks kolom sebagai teks button
            };
            dataGridView.Columns.Add(buttonColumn);

            // Contoh data
            dataGridView.Rows.Add("Produk 1", "Rp 100.000", "10");
            dataGridView.Rows.Add("Produk 2", "Rp 200.000", "5");

            // Atur background image dan style untuk kolom button
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var buttonCell = row.Cells["BUTTON"] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    buttonCell.Style.BackColor = Color.Transparent;
                    buttonCell.Style.SelectionBackColor = Color.Transparent;
                    buttonCell.Style.Padding = new Padding(0); // Hilangkan padding
                    buttonCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Pusatkan teks


                }
            }

            // Handle CellClick untuk menangani klik button
            dataGridView.CellClick += DataGridView_CellClick;

            this.Controls.Add(dataGridView);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle klik pada kolom button
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["BUTTON"].Index)
            {
                MessageBox.Show($"Button di baris {e.RowIndex + 1} diklik!");
            }
        }

    }
}
