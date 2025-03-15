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
    public partial class Register : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        public Register()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InitComponent();
            RegisterEvent();
        }
        private void InitComponent()
        {
            txtPassword.PasswordChar = '*';
            txtCPassword.PasswordChar = '*';
        }
        private void RegisterEvent()
        {
            StyleComponent.TextChangeNull(txtNama, lblErrorNama, "⚠️ Harap masukkan nama!");
            StyleComponent.TextChangeNull(txtPassword, lblErrorPassword, "⚠️ Harap masukkan password!");

            linkLogin.Click += (s, e) =>
            {
                new Login().Show();
                this.Close();
            };
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
                else if (_pelangganDal.CekEmail(email) || _karyawanDal.CekEmail(email))
                {
                    lblErrorEmail.Text = "⚠️ Email sudah terdaftar!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                lblErrorEmail.Visible = false;
            };
            txtPassword.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string password = txtPassword.Text;
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";
                if (!Regex.IsMatch(password, pattern))
                {
                    lblErrorPassword.Text = "⚠️ Password minimal 8 karakter, huruf besar, kecil, dan angka.";
                    lblErrorPassword.Visible = true;
                    return;
                }
                lblErrorPassword.Visible = false;
            };
            txtCPassword.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string Cpassword = txtCPassword.Text;
                if(Cpassword != txtPassword.Text)
                {
                    lblErrorCPassword.Text = "⚠️ Konfirmasi password tidak valid!";
                    lblErrorCPassword.Visible = true;
                    return;
                }
                lblErrorCPassword.Visible = false;
            };
            btnRegister.Click += (s, e) => SaveData();
        }
        private void SaveData()
        {
            string nama = txtNama.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text.Trim();
            string Cpassword = txtCPassword.Text.Trim();

            bool valid = !lblErrorNama.Visible
                && !lblErrorEmail.Visible
                && !lblErrorPassword.Visible
                && !lblErrorCPassword.Visible;
            if (!valid)
            {
                MB.Warning("Data tidak valid, harap melengkapi data!");
                return;
            }
            
            string noKtp = _pelangganDal.GenerateUniqueTempKTP();
            string hash = PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Interactive);
            MB.Warning(hash);
            var pelanggan = new PelangganModelUpdate
            {
                ktp_pelanggan_new = noKtp,
                nama_pelanggan = nama,
                email = email,
                password = hash,
            };
            _pelangganDal.InsertData(pelanggan);
            MB.Informasi("Registrasi berhasil!");
            Login._loginForm.Show();
            this.Close();
        }
    }
}
