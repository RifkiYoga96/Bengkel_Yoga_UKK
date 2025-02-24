using Sodium;
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
    public partial class FormInputPelanggan : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private bool _anyProfile = false;
        private bool _IsInsert = true;
        private string _ktp_pelanggan = string.Empty;
        public FormInputPelanggan(string ktp_pelanggan, bool IsInsert = true)
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();

            if (!IsInsert)
            {
                GetData(ktp_pelanggan);
                lblHeader.Text = "Edit Pegawai";
                _IsInsert = false;
                _ktp_pelanggan = ktp_pelanggan;
            }
        }

        #region INIT COMPONENT

        private void InitComponent()
        {
            txtPassword.ReadOnly = true;
            txtCPassword.ReadOnly = true;
            lblErrorNama.Visible = false;
            lblErrorKTP.Visible = false;
            lblErrorTelepon.Visible = false;
            lblErrorEmail.Visible = false;
            lblErrorPassword.Visible = false;
            lblErrorCPassword.Visible = false;
            lblErrorAlamat.Visible = false;

            StyleComponent.TextChangeNull(txtNama, lblErrorNama, "⚠️ Harap mengisi nama!");
            StyleComponent.TextChangeNull(txtNoKTP, lblErrorKTP, "⚠️ Harap mengisi nomor KTP!");
            StyleComponent.TextChangeNull(txtEmail, lblErrorEmail, "⚠️ Harap mengisi email!");
            StyleComponent.TextChangeNull(txtNoTelepon, lblErrorTelepon, "⚠️ Harap mengisi nomor telepon!");
            StyleComponent.TextChangeNull(txtPassword, lblErrorPassword, "⚠️ Harap mengisi password!");
            StyleComponent.TextChangeNull(txtCPassword, lblErrorCPassword, "⚠️ Harap mengisi konfirmasi password!");
            StyleComponent.TextChangeNull(txtAlamat, lblErrorAlamat, "⚠️ Harap mengisi alamat!");

            txtNoKTP.InputNumber();
            txtNoTelepon.InputNumber();

            txtEmail.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string email = txtEmail.Text;
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(email, pattern))
                {
                    lblErrorEmail.Text = "⚠️ Format email tidak valid!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                else if (_IsInsert ? _pelangganDal.CekEmail(email) : _pelangganDal.CekEmailUpdate(email, _ktp_pelanggan))
                {
                    lblErrorEmail.Text = "⚠️ Email sudah terdaftar!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                lblErrorEmail.Visible = false;
            };

            txtNoTelepon.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string telepon = txtNoTelepon.Text;
                if (_IsInsert ? _pelangganDal.CekTelepon(telepon) : _pelangganDal.CekTeleponUpdate(telepon, _ktp_pelanggan))
                {
                    lblErrorTelepon.Text = "⚠️ Nomor telepon sudah terdaftar!";
                    lblErrorTelepon.Visible = true;
                    return;
                }
                lblErrorTelepon.Visible = false;
            };

            txtNoKTP.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string noKtp = txtNoKTP.Text;
                if (_IsInsert ? _pelangganDal.CekKTP(noKtp) : !_pelangganDal.CekKTPUpdate(noKtp))
                {
                    lblErrorKTP.Text = "⚠️ Nomor KTP sudah terdaftar!";
                    lblErrorKTP.Visible = true;
                    return;
                }
                lblErrorKTP.Visible = false;
            };

            txtCPassword.TextChanged += async (s, e) =>
            {
                await Task.Delay(1000);
                string password = txtPassword.Text;
                string CPassword = txtCPassword.Text;
                if (password != CPassword)
                {
                    lblErrorCPassword.Text = "⚠️ Konfirmasi password salah/tidak sama!";
                    lblErrorCPassword.Visible = true;
                    return;
                }
                lblErrorCPassword.Visible = false;
            };
        }
        #endregion

        #region EVENT

        private void RegisterEvent()
        {

        }

        #endregion

        #region SAVE & GET

        private void SaveData()
        {
            string nama = txtNama.Text.Trim();
            string noKtp = txtNoKTP.Text.Trim();
            string telepon = txtNoTelepon.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string konfirmPass = txtCPassword.Text;
            string alamat = txtAlamat.Text;

            bool validationEvent = !lblErrorKTP.Visible
                 && !lblErrorTelepon.Visible
                 && !lblErrorEmail.Visible
                 && !lblErrorCPassword.Visible;
            bool validationEmpty = nama != ""
                && password != ""
                && alamat != "";
            if (!validationEvent || !validationEmpty)
            {
                MB.Warning("Data tidak valid, harap cek kembali!");
                return;
            }

            var dataPelanggan = new PelangganModelUpdate()
            {
                ktp_pelanggan_old = _ktp_pelanggan,
                ktp_pelanggan_new = noKtp,
                nama_pelanggan = nama,
                no_telp = telepon,
                email = email,
                password = PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Interactive),
                alamat = alamat
            };

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            if (_ktp_pelanggan == string.Empty)
            {
                _pelangganDal.InsertData(dataPelanggan);
            }
            else
            {
                _pelangganDal.UpdateData(dataPelanggan);
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void GetData(string ktp_pelanggan)
        {
            var data = _pelangganDal.GetData(ktp_pelanggan);
            if (data is null) return;

            txtNama.Text = data.nama_pelanggan;
            txtNoKTP.Text = data.ktp_pelanggan;
            txtNoTelepon.Text = data.no_telp;
            txtEmail.Text = data.email;
            txtPassword.Text = data.password;
            txtCPassword.Text = data.password;
            txtAlamat.Text = data.alamat;
        }

        #endregion
    }
}
