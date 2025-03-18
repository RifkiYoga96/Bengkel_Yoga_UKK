using MimeKit;
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
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;


namespace Bengkel_Yoga_UKK
{
    public partial class RegisterLanjutan : Form
    {
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private bool _resetPassword = false;
        public static string _passwordHash = string.Empty;
        public RegisterLanjutan()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
        }
        private void InitComponent()
        {
            txtPassword.PasswordChar = '*';
            StyleComponent.InputNumber(txtNoKTP);
            StyleComponent.InputNumber(txtNoTelp);

            StyleComponent.TextChangeNull(txtNama,lblErrorNama, "⚠️ Harap mengisi nama!");
            StyleComponent.TextChangeNull(txtEmail,lblErrorEmail, "⚠️ Harap mengisi email!",true);
            StyleComponent.TextChangeNull(txtNoKTP,lblErrorKTP, "⚠️ Harap mengisi nomor KTP!",true);
            StyleComponent.TextChangeNull(txtNoTelp,lblErrorTelepon, "⚠️ Harap mengisi nomor telepon!",true);
            StyleComponent.TextChangeNull(txtAlamat,lblErrorAlamat, "⚠️ Harap mengisi alamat!");

            string ktp_old = GlobalVariabel._ktp_pelanggan;
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
                else if (!_pelangganDal.CekEmailUpdate(email,ktp_old) || !_karyawanDal.CekEmailUpdate(email,ktp_old))
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
                if (!_pelangganDal.CekTeleponUpdate(telepon,ktp_old))
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
                string ktp_new = txtNoKTP.Text;
                if (!Regex.IsMatch(ktp_new, @"^\d{16}$"))
                {
                    lblErrorKTP.Visible = true;
                    lblErrorKTP.Text = "⚠️ NIK harus 16 digit!";
                    return;
                }
                if (!_pelangganDal.CekKTPUpdate(ktp_new,ktp_old) || !_karyawanDal.CekKTPUpdate(ktp_new,ktp_old))
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
        }

        private void GetData(string ktp)
        {
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


        }
    }
    /*public class EmailService
    {
        private readonly string smtpServer = "smtp.gmail.com"; // Bisa diganti sesuai penyedia email
        private readonly int smtpPort = 587;
        private readonly string smtpUser = "your-email@gmail.com";  // Ganti dengan email pengirim
        private readonly string smtpPass = "your-app-password"; // Gunakan App Password (bukan password biasa)

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", smtpUser));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(smtpUser, smtpPass);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Gagal mengirim email: {ex.Message}");
                }
            }
        }

        public class EmailServices
    {
        private readonly string smtpServer = "smtp.gmail.com"; // Sesuaikan dengan provider email Anda
        private readonly int smtpPort = 587;
        private readonly string smtpUser = "your-email@gmail.com";
        private readonly string smtpPass = "your-app-password"; // Pakai App Password jika pakai Gmail

        public async Task SendResetPasswordEmail(string toEmail)
        {
            string resetToken = Guid.NewGuid().ToString(); // Buat token unik
            string resetLink = $"https://yourdomain.com/reset-password?token={resetToken}"; // Buat link reset

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", smtpUser));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "Reset Password";

            message.Body = new TextPart("html")
            {
                Text = $"Klik link berikut untuk mereset password: <a href='{resetLink}'>Reset Password</a>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpUser, smtpPass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            // Simpan token ke database atau file untuk validasi nanti
            Console.WriteLine($"Token Reset: {resetToken}");
        }
    }*/
}
