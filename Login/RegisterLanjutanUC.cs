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
    public partial class RegisterLanjutanUC : UserControl
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private bool _resetPassword = false;
        public static string _passwordHash = string.Empty;
        public RegisterLanjutanUC()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
            GetData();
        }
        private void InitComponent()
        {
            txtNama.MaxLength = 90;
            txtEmail.MaxLength = 90;
            txtAlamat.MaxLength = 90;
            txtNoKTP.MaxLength = 16;
            txtNoTelp.MaxLength = 15;


            txtPassword.PasswordChar = '*';
            StyleComponent.InputNumber(txtNoKTP);
            StyleComponent.InputNumber(txtNoTelp);

            StyleComponent.TextChangeNull(txtNama, lblErrorNama, "⚠️ Harap mengisi nama!");
            StyleComponent.TextChangeNull(txtEmail, lblErrorEmail, "⚠️ Harap mengisi email!", true);
            StyleComponent.TextChangeNull(txtNoKTP, lblErrorKTP, "⚠️ Harap mengisi nomor KTP!", true);
            StyleComponent.TextChangeNull(txtNoTelp, lblErrorTelepon, "⚠️ Harap mengisi nomor telepon!", true);
            StyleComponent.TextChangeNull(txtAlamat, lblErrorAlamat, "⚠️ Harap mengisi alamat!");

            string ktp_old = GlobalVariabel._ktp;
            txtEmail.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string email = txtEmail.Text;
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(email, pattern))
                {
                    lblErrorEmail.Text = "⚠️ Format email tidak valid!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                else if (!_pelangganDal.CekEmailUpdate(email, ktp_old) || !_karyawanDal.CekEmailUpdate(email, ktp_old))
                {
                    lblErrorEmail.Text = "⚠️ Email sudah terdaftar!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                lblErrorEmail.Visible = false;
            };
            txtNoTelp.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string telepon = txtNoTelp.Text;
                if (!_pelangganDal.CekTeleponUpdate(telepon, ktp_old))
                {
                    lblErrorTelepon.Text = "⚠️ Nomor telepon sudah terdaftar!";
                    lblErrorTelepon.Visible = true;
                    return;
                }
                lblErrorTelepon.Visible = false;
            };
            txtNoKTP.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string ktp = txtNoKTP.Text;
                if (!Regex.IsMatch(ktp, @"^\d{16}$"))
                {
                    lblErrorKTP.Visible = true;
                    lblErrorKTP.Text = "⚠️ NIK harus 16 digit!";
                    return;
                }
                if (!_pelangganDal.CekKTPUpdate(ktp, ktp_old) || !_karyawanDal.CekKTPUpdate(ktp, ktp_old))
                {
                    lblErrorKTP.Visible = true;
                    lblErrorKTP.Text = "⚠️ Nomor KTP sudah terdaftar!";
                    return;
                }
                lblErrorKTP.Visible = false;
            };
        }

        private void RegisterEvent()
        {
            linkReset.Click += async (s, e) =>
            {
                if (new ResetPasswordForm(_passwordHash).ShowDialog() != DialogResult.OK) return;
                txtPassword.Text = _passwordHash;
                await Task.Delay(1000);
                MB.Informasi("Password berhasil diganti");
            };
            btnSave.Click += (s,e) => SaveData();
        }


        private void GetData()
        {
            string ktp = GlobalVariabel._ktp;
            var data = _pelangganDal.GetData(ktp);
            if (data is null) return;

            txtNama.Text = data.nama_pelanggan;
            txtEmail.Text = data.email;
            txtPassword.Text = data.password;
            txtNoKTP.Text = Regex.IsMatch(data.ktp_pelanggan, @"[A-Za-z]") ?
                string.Empty : data.ktp_pelanggan;
            txtNoTelp.Text = data.no_telp;
            txtAlamat.Text = data.alamat;

            _passwordHash = data.password;
        }

        private void SaveData()
        {
            string ktp_old = GlobalVariabel._ktp;
            string ktp_new = txtNoKTP.Text;
            string nama = txtNama.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string telepon = txtNoTelp.Text;
            string alamat = txtAlamat.Text;

            bool valid = !lblErrorKTP.Visible &&
                !lblErrorEmail.Visible &&
                !lblErrorNama.Visible &&
                !lblErrorPassword.Visible &&
                !lblErrorTelepon.Visible &&
                !lblErrorAlamat.Visible;

            if (!valid)
            {
                MB.Warning("Data tidak valid, harap cek kembali!");
                return;
            }

            if (!MB.Konfirmasi("Apakah anda ingin menyimpan data?")) return;

            var dataPelanggan = new PelangganModelUpdate
            {
                ktp_pelanggan_new = ktp_new,
                ktp_pelanggan_old = ktp_old,
                nama_pelanggan = nama,
                email = email,
                password = password,
                no_telp = telepon,
                alamat = alamat
            };

            _pelangganDal.UpdateData(dataPelanggan);
            GlobalVariabel.SetSession(ktp_new);
        }
    }
}
