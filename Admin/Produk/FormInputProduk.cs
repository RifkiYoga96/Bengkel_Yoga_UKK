using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputProduk : Form
    {
        private Image _imageProduk = Properties.Resources.defaultImage;
        public FormInputProduk()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            txtStok.NumberDecimalDigits = 0;
            txtStokMinimum.NumberDecimalDigits = 0;
            btnPlusStok.Click += (s, e) => txtStok.DoubleValue += 1;
            btnMinStok.Click += (s, e) => txtStok.DoubleValue -= 1;
            btnPlusStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue += 1;
            btnMinStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue -= 1;

            btnSave.Click += BtnSave_Click;
            btnChooseFile.Click += BtnChooseFile_Click;
        }

        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);


                    if (new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK) return;

                    pictureBox1.BackgroundImage = ImageDirectory._imageResult;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                    _imageProduk = ImageDirectory._imageResult;
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string produk = txtNamaProduk.Text;
            int harga = Convert.ToInt32(txtHarga.DecimalValue);
            int stok = Convert.ToInt32(txtStok.DoubleValue);
            int stokMinimum = Convert.ToInt32(txtStokMinimum.DoubleValue);
            Image foto = _imageProduk;

            lblErrorProduk.Visible = produk == "" ? true : false;
            lblErrorHarga.Visible = harga == 0 ? true : false;
            lblErrorStokMin.Visible = stokMinimum == 0 ? true : false;
            return;


        }
    }
}
