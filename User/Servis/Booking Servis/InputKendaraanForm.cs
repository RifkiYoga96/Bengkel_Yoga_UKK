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
    public partial class InputKendaraanForm : Form
    {
        private int _id_kendaraan = 0;
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        public InputKendaraanForm(int id_kendaraan)
        {
            InitializeComponent();
            this.IsDialogForm();
            _id_kendaraan = id_kendaraan;
            InitComponent();
            RegisterEvent();
        }

        private void InitComponent()
        {
            numericKapasitas.Minimum = 1;

            StyleComponent.TextChangeNull(txtMerk,lblErrorMerk, "⚠️ Harap mengisi merk!");
            StyleComponent.TextChangeNull(txtTipe,lblErrorTipe, "⚠️ Harap mengisi tipe kendaraan!");
            StyleComponent.TextChangeNull(txtNoPol,lblErrorNoPol, "⚠️ Harap mengisi nomor polisi!", true);
            StyleComponent.TextChangeNull(txtTahun,lblErrorTahun, "⚠️ Harap mengisi tahun produksi!");

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
                    : _kendaraanDal.CekNoPolUpdate(no_pol.Trim(), _id_kendaraan);
                if (tersedia)
                {
                    lblErrorNoPol.Text = "⚠️ Nomor polisi sudah tersedia!";
                    lblErrorNoPol.Visible = true;
                    return;
                }
                lblErrorNoPol.Visible = false;
            };

            List<string> list = new List<string>() { "Matic","Manual","Kopling" };
            comboTransmisi.DataSource = list;
        }

        private void RegisterEvent()
        {
            btnSave.Click += (s, e) => SaveData();
            btnCancel.Click += (s, e) => this.Close();
        }

        private void SaveData()
        {
            string ktp = GlobalVariabel._ktp;
            string merk = txtMerk.Text;
            string tipe = txtTipe.Text;
            string transmisi = comboTransmisi.SelectedValue?.ToString() ?? string.Empty;
            int kapasitas = Convert.ToInt32(numericKapasitas.Value);
            string noPol = txtNoPol.Text;
            string tahun = txtTahun.Text;

            bool valid = !lblErrorMerk.Visible &&
                !lblErrorTipe.Visible &&
                !lblErrorNoPol.Visible &&
                !lblErrorTahun.Visible;

            if (!valid)
            {
                MB.Warning("Data tidak valid, harap cek kembali!");
                return;
            }

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            var kendaraan = new KendaraanModel()
            {
                ktp_pelanggan = ktp,
                merk = merk,
                tipe = tipe,
                transmisi = transmisi,
                kapasitas = kapasitas,
                no_pol = noPol,
                tahun = tahun,
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
