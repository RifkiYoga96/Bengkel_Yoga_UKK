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
    public partial class Login : Form
    {
        public static Form _loginForm = new Login();
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private bool _showPassword = false;
        public Login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _loginForm = this;
            InitComponent();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            btnShowPassword.Click += (s, e) =>
            {
                if (_showPassword)
                {
                    txtPassword.PasswordChar = '*';
                    btnShowPassword.Image = Properties.Resources.hidden;
                }
                else
                {
                    txtPassword.PasswordChar = '\0';
                    btnShowPassword.Image = Properties.Resources.eye;
                }
                _showPassword = !_showPassword;
                txtPassword.Focus();
            };
            txtEmail.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(txtEmail.Text, pattern))
                    lblErrorEmail.Visible = true;
                else
                    lblErrorEmail.Visible = false;
            };
            btnLogin.Click += (s,e) => CekLogin();
            linkRegister.Click += (s, e) =>
            {
                new Register().Show();
                this.Hide();
            };
        }

        private void InitComponent()
        {
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 100;
            txtEmail.MaxLength = 100;
        }

        private void CekLogin()
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email == string.Empty || password == string.Empty || lblErrorEmail.Visible)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }
            var dataPelanggan = _pelangganDal.GetLogin(email, password);
            var dataAdmin = _karyawanDal.GetLogin(email, password);

            bool loginPelanggan = dataPelanggan != null ? true : false;
            bool loginAdmin = dataAdmin != null ? true : false;

            if (loginPelanggan && loginAdmin)
            {
                MB.Warning("Pel dan Admin");
                new MainFormAdmin().Show();
                this.Hide();
            }
            else if (loginPelanggan)
            {
                MB.Warning("Pel");
            }
            else if (loginAdmin)
            {
                new MainFormAdmin().Show();
                this.Hide();
            }
            else
            {
                MB.Warning("Harap melengkapi data!");
                return;
            }

        }



    }
}
