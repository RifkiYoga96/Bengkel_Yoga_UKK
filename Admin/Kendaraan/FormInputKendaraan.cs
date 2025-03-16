using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputKendaraan : Form
    {
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        public static string _ktp_pelanggan = string.Empty;
        public int _id_kendaraan = 0;
        public FormInputKendaraan(int id_kendaraan = 0)
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
            if(id_kendaraan != 0)
            {
                _id_kendaraan = id_kendaraan;
                GetData(id_kendaraan);
            }
        }

        #region EVENT
        private void RegisterEvent()
        {
            txtKTP.TextChanged += TxtKTP_TextChanged;
            btnCariKTP.Click += BtnCariKTP_Click;
            btnSave.Click += (s, e) => SaveData();
            btnCancel.Click += (s, e) => this.Close();
        }

        private async void TxtKTP_TextChanged(object? sender, EventArgs e)
        {
            await Task.Delay(1500);
            GetPelanggan();
        }

        private void BtnCariKTP_Click(object? sender, EventArgs e)
        {
            if (new FormPilihPelanggan().ShowDialog() != DialogResult.OK) return;
            txtKTP.Text = GlobalVariabel._ktp_pelanggan;
            GetPelanggan();
        }

     
        #endregion

        #region INIT COMPONENT
        private void InitComponent()
        {
            List<string> list = new List<string>() { "Manual","Matic","Kopling" };
            comboTransmisi.DataSource = list;

            txtKTP.MaxLength = 16;
            txtMerk.MaxLength = 50;
            txtTipe.MaxLength = 50;
            txtKapasitas.MaxLength = 50;
            txtTahun.MaxLength = 10;
            txtNoPol.MaxLength = 20;

            txtTahun.InputNumber();
            txtKapasitas.InputNumber();

            StyleComponent.TextChangeNull(txtKTP,lblErrorKTP, "⚠️ Harap mengisi KTP Pemilik!", true);
            StyleComponent.TextChangeNull(txtMerk,lblErrorMerk, "⚠️ Harap mengisi merk kendaraan!");
            StyleComponent.TextChangeNull(txtTipe,lblErrorTipe, "⚠️ Harap mengisi tipe kendaraan!");
            StyleComponent.TextChangeNull(txtKapasitas,lblErrorKapasitas, "⚠️ Harap mengisi kapasitas mesin!");
            StyleComponent.TextChangeNull(txtTahun,lblErrorTahun, "⚠️ Harap mengisi tahun produksi!");
            StyleComponent.TextChangeNull(txtNoPol,lblErrorNoPol, "⚠️ Harap mengisi nomor polisi!",true);

            txtNoPol.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string no_pol = txtNoPol.Text;
                string pola = @"^[A-Z]{1,2} \d{1,4} [A-Z]{1,3}$";
                if (!Regex.IsMatch(no_pol, pola) || no_pol.Length == 0)
                {
                    lblErrorNoPol.Text = "⚠️ Format No Pol tidak valid!";
                    lblErrorNoPol.Visible = true;
                    return;
                }
                bool tersedia = _id_kendaraan == 0 ? _kendaraanDal.CekNoPol(no_pol.Trim()) 
                    : _kendaraanDal.CekNoPolUpdate(no_pol.Trim(),_id_kendaraan);
                if (tersedia)
                {
                    lblErrorNoPol.Text = "⚠️ Nomor polisi sudah tersedia!";
                    lblErrorNoPol.Visible = true;
                    return;
                }
                lblErrorNoPol.Visible = false;
            };

        }
        #endregion

        private void GetPelanggan()
        {
            string ktp = txtKTP.Text;
            var data = _pelangganDal.GetData(ktp);
            if (data is null)
            {
                lblErrorKTP.Visible = true;
                lblErrorKTP.Text = "⚠️ Pelanggan tidak ditemukan!";
                txtPemilik.Clear();
                return;
            }
            lblErrorKTP.Visible = false;
            txtPemilik.Text = data.nama_pelanggan;
        }

        private void GetData(int id)
        {
            var data = _kendaraanDal.GetData(id);
            if (data is null) return;

            txtKTP.Text = data.ktp_pelanggan;
            txtPemilik.Text = data.nama_pelanggan;
            txtMerk.Text = data.merk;
            txtTipe.Text = data.tipe;
            txtKapasitas.Text = data.kapasitas.ToString();
            txtTahun.Text = data.tahun;
            txtNoPol.Text = data.no_pol;
            foreach (var item in comboTransmisi.Items)
                if ((string)item == (string)data.transmisi)
                    comboTransmisi.SelectedItem = item;
        }

        private void SaveData()
        {
            string ktp = txtKTP.Text;
            string pemilik = txtPemilik.Text;
            string merk = txtMerk.Text;
            string tipe = txtTipe.Text;
            string transmisi = comboTransmisi.SelectedValue?.ToString() ?? string.Empty;
            int kapasitas = Convert.ToInt32(txtKapasitas.Text);
            string tahun = txtTahun.Text;
            string noPol = txtNoPol.Text;

            bool valid = !lblErrorKTP.Visible &&
                !lblErrorMerk.Visible &&
                !lblErrorTipe.Visible &&
                !lblErrorKapasitas.Visible &&
                !lblErrorTahun.Visible &&
                !lblErrorNoPol.Visible;

            if (!valid)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }
            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            var kendaraan = new KendaraanModel
            {
                id_kendaraan = _id_kendaraan,
                ktp_pelanggan = ktp,
                merk = merk,
                tipe = tipe,
                transmisi = transmisi,
                kapasitas = kapasitas,
                tahun = tahun,
                no_pol = noPol
            };

            if (_id_kendaraan == 0)
                _kendaraanDal.InsertData(kendaraan);
            else
                _kendaraanDal.UpdateData(kendaraan);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
