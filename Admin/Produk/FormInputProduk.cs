using System;
using System.Collections;
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
        private readonly ProdukDal _produkDal = new ProdukDal();
        private Image _imageProduk = Properties.Resources.defaultImage;
        private Image _defaultImage = Properties.Resources.defaultImage;
        private string _kode_produk = "";
        private bool _deleteProfile = false;
        private bool _isInsert = true;
        public FormInputProduk(string kode_produk = "", bool isInsert = true)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            RegisterEvent();
            
            if (!isInsert)
            {
                lblHeader.Text = "Edit Sparepart";
                _isInsert = false;
                _kode_produk = kode_produk;
                GetData();
            }
        }

        private void RegisterEvent()
        {
            StyleComponent.TextChangeNull(txtNamaProduk, lblErrorSparepart, "⚠️ Harap isi nama sparepart!");

            txtHarga.DecimalValueChanged += (s, e) =>
            {
                if (txtHarga.DecimalValue == 0) 
                    lblErrorHarga.Visible = true;
                else
                    lblErrorHarga.Visible = false;
            };

            txtStokMinimum.DoubleValueChanged += (s, e) =>
            {
                if (txtStokMinimum.DoubleValue == 0)
                    lblErrorStokMin.Visible = true;
                else
                    lblErrorStokMin.Visible = false;
            };

            txtStok.NumberDecimalDigits = 0;
            txtStokMinimum.NumberDecimalDigits = 0;
            btnPlusStok.Click += (s, e) => txtStok.DoubleValue += 1;
            btnMinStok.Click += (s, e) => txtStok.DoubleValue -= 1;
            btnPlusStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue += 1;
            btnMinStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue -= 1;

            btnSave.Click += BtnSave_Click;
            btnUpload.Click += BtnChooseFile_Click;
            btnHapus.Click += BtnHapus_Click;
        }

        private void BtnHapus_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus gambar?")) return;
            pictureBox1.BackgroundImage = _defaultImage;
            _deleteProfile = true;
        }

        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);


                    //if (new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK) return;

                    _imageProduk = ImageConvert.ResizeImageMax(originalImage, 400, 400);
                    //_anyProfile = !IsSameImage(_imageProduk, _defaultImage);

                    pictureBox1.BackgroundImage = _imageProduk;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string namaProduk = txtNamaProduk.Text;
            int harga = Convert.ToInt32(txtHarga.DecimalValue);
            int stok = Convert.ToInt32(txtStok.DoubleValue);
            int stokMinimum = Convert.ToInt32(txtStokMinimum.DoubleValue);
            Image foto = _imageProduk;

            bool valid = !lblErrorSparepart.Visible
                && !lblErrorHarga.Visible
                && !lblErrorStokMin.Visible;
            if (!valid || harga == 0)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            var produk = new ProdukModel
            {
                kode_sparepart = _kode_produk,
                nama_sparepart = namaProduk,
                harga = harga,
                stok = stok,
                stok_minimum = stokMinimum,
                image_data = _deleteProfile ? null : ImageConvert.ImageToByteArray(_imageProduk)
            };

            if (_kode_produk == "")
                _produkDal.InsertData(produk);
            else
                _produkDal.UpdateData(produk);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GetData()
        {
            if (_kode_produk == "") return;

            var data = _produkDal.GetData(_kode_produk);
            if (data is null) return;

            pictureBox1.BackgroundImage = data.image_data != null
                ? ImageConvert.Image_ByteToImage(data.image_data)
                : null;
            txtNamaProduk.Text = data.nama_sparepart;
            txtHarga.DecimalValue = data.harga;
            txtStok.DoubleValue = data.stok;
            txtStokMinimum.DoubleValue = data.stok_minimum;
        }
    }
}
