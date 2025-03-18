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
    public partial class ResetPasswordForm : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private bool _showPassword = false;
        private string _passwordHash = string.Empty;
        public ResetPasswordForm(string hash)
        {
            InitializeComponent();
            _passwordHash = hash;
            InitComponent();
            btnResetPassword.Click += (s,e) => SaveData();
        }

        private void InitComponent()
        {
            this.IsDialogForm();

            StyleComponent.TextChangeNull(txtPasswordLama,lblErrorOldPassword,"Harap isi password lama!", true);
            StyleComponent.TextChangeNull(txtPasswordBaru,lblErrorNewPassword,"Harap isi password baru!", true);
            StyleComponent.TextChangeNull(txtKonfirmasiPassword,lblErrorCPassword,"Harap isi konfirmasi password!", true);
          
            txtPasswordLama.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string password = txtPasswordLama.Text;
                bool valid = PasswordHash.ArgonHashStringVerify(_passwordHash, password);
                if (!valid)
                {
                    lblErrorOldPassword.Text = "⚠️ Password lama salah!";
                    lblErrorOldPassword.Visible = true;
                    return;
                }
                lblErrorOldPassword.Visible = false;
            };

            txtPasswordBaru.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string passwordLama = txtPasswordLama.Text;
                string password = txtPasswordBaru.Text;
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";
                if (!Regex.IsMatch(password, pattern))
                {
                    lblErrorNewPassword.Text = "⚠️ Password minimal 8 karakter, huruf besar, kecil, dan angka.";
                    lblErrorNewPassword.Visible = true;
                    return;
                }

                bool samePassword = PasswordHash.ArgonHashStringVerify(_passwordHash, password);
                if (samePassword)
                {
                    lblErrorNewPassword.Text = "⚠️ Password lama dan password baru tidak boleh sama!";
                    lblErrorNewPassword.Visible = true;
                    return;
                }
                lblErrorNewPassword.Visible = false;
            };

            txtKonfirmasiPassword.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string password = txtPasswordBaru.Text;
                string Cpassword = txtKonfirmasiPassword.Text;
                if (password != Cpassword)
                {
                    lblErrorCPassword.Text = "⚠️ Konfirmasi password tidak valid!";
                    lblErrorCPassword.Visible = true;
                    return;
                }
                lblErrorCPassword.Visible = false;
            };
        }

        private void SaveData()
        {
            string passwordOld = txtPasswordLama.Text;
            string passwordNew = txtPasswordLama.Text;
            string CPassword = txtKonfirmasiPassword.Text;

            lblErrorOldPassword.Visible = false;

            bool validInput = !lblErrorOldPassword.Visible &&
                !lblErrorNewPassword.Visible &&
                !lblErrorCPassword.Visible;
            if (!validInput)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }

            if (!MB.Konfirmasi("Apakah anda yakin ingin mereset password?")) return;

            RegisterLanjutan._passwordHash = passwordNew;
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}
