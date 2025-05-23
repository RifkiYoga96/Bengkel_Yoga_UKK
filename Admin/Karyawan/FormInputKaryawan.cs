﻿using Sodium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputKaryawan : Form
    {
        private Image _fotoAdmin = Properties.Resources.defaultProfile;
        private Image _defaultProfile = Properties.Resources.defaultProfile;
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private readonly PelangganDal _pelangganDal = new PelangganDal();
        private bool _IsInsert = true;
        private bool _resetPassword = false;
        private string _ktp_admin = string.Empty;
        public FormInputKaryawan(string ktp_admin,bool IsInsert = true)
        {
            InitializeComponent();
            InitComponen();
            RegisterEvent();
            if (!IsInsert)
            {
                GetData(ktp_admin);
                lblHeader.Text = "Edit Pegawai";
                _IsInsert = false;
                _ktp_admin = ktp_admin;
                txtPassword.ReadOnly = true;
                txtKonfirPassword.ReadOnly = true;
            }
        }

        private void RegisterEvent()
        {
            btnChooseFile.Click += BtnChooseFile_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += (s, e) => this.Close();
            linkReset.Click += (s, e) => ResetPassword(true);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah Anda yakin ingin menghapus foto ini!")) return;
            _fotoAdmin = _defaultProfile;
            pictureBoxProfile.BackgroundImage = Properties.Resources.defaultProfile;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveData();
        }

        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);

                    if (new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    pictureBoxProfile.BackgroundImage = ImageConvert.SmoothImagePictureBox(ImageDirectory._imageResult, pictureBoxProfile.Width, pictureBoxProfile.Height);
                    pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;
                    _fotoAdmin = ImageDirectory._imageResult;
                }
            }
        }

        private bool IsSameImage(Image img1, Image img2)
        {
            if (img1 == null || img2 == null) return false;

            using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
            {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imgBytes1 = ms1.ToArray();
                byte[] imgBytes2 = ms2.ToArray();

                return StructuralComparisons.StructuralEqualityComparer.Equals(imgBytes1, imgBytes2);
            }
        }

        #region INIT COMPONEN

        private void InitComponen()
        {
            txtNama.MaxLength = 90;
            txtNoKTP.MaxLength = 16;
            txtNoTelepon.MaxLength = 20;
            txtEmail.MaxLength = 90;
            txtAlamat.MaxLength = 99;


            StyleComponent.TextChangeNull(txtNama, lblErrorNama, "⚠️ Harap mengisi nama!");
            StyleComponent.TextChangeNull(txtNoKTP, lblErrorKTP, "⚠️ Harap mengisi nomor KTP!",true);
            StyleComponent.TextChangeNull(txtEmail, lblErrorEmail, "⚠️ Harap mengisi email!",true);
            StyleComponent.TextChangeNull(txtNoTelepon, lblErrorTelepon, "⚠️ Harap mengisi nomor telepon!",true);
            StyleComponent.TextChangeNull(txtKonfirPassword, lblErrorCPassword, "⚠️ Harap mengisi konfirmasi password!",true);
            StyleComponent.TextChangeNull(txtAlamat, lblErrorAlamat, "⚠️ Harap mengisi alamat!");
            
            txtNoKTP.InputNumber();
            txtNoTelepon.InputNumber();

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
                else if (_IsInsert ? !_karyawanDal.CekEmail(email) : !_karyawanDal.CekEmailUpdate(email,_ktp_admin))
                {
                    lblErrorEmail.Text = "⚠️ Email sudah terdaftar!";
                    lblErrorEmail.Visible = true;
                    return;
                }
                lblErrorEmail.Visible = false;
            };

            txtNoTelepon.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string telepon = txtNoTelepon.Text;
                if (_IsInsert ? !_karyawanDal.CekTelepon(telepon) : !_karyawanDal.CekTeleponUpdate(telepon, _ktp_admin))
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
                string noKtp = txtNoKTP.Text;

                if (!Regex.IsMatch(noKtp, @"^\d{16}$"))
                {
                    lblErrorKTP.Visible = true;
                    lblErrorKTP.Text = "⚠️ NIK harus 16 digit!";
                    return;
                }

                bool valid_pelanggan = _pelangganDal.CekKTP(noKtp);
                bool valid_admin = _ktp_admin == noKtp ? true : _karyawanDal.CekKTPUpdate(noKtp,_ktp_admin);

                if (!valid_pelanggan || !valid_admin)
                {
                    lblErrorKTP.Text = "⚠️ Nomor KTP sudah terdaftar!";
                    lblErrorKTP.Visible = true; 
                    return;
                }
                lblErrorKTP.Visible = false;
            };
            txtPassword.TextChanged += async (s, e) =>
            {
                lblErrorPassword.Location = new Point(563, lblErrorPassword.Location.Y);
                await Task.Delay(1500);
                string password = txtPassword.Text;
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";
                if (!Regex.IsMatch(password, pattern) && !txtPassword.ReadOnly)
                {
                    lblErrorPassword.Text = "⚠️ Password minimal 8 karakter, huruf besar, kecil, dan angka.";
                    lblErrorPassword.Visible = true;
                    return;
                }
                lblErrorPassword.Visible = false;
            };
            txtKonfirPassword.TextChanged += async (s, e) =>
            {
                await Task.Delay(1500);
                string password = txtPassword.Text;
                string CPassword = txtKonfirPassword.Text;
                if(password != CPassword)
                {
                    lblErrorCPassword.Text = "⚠️ Konfirmasi password tidak valid!";
                    lblErrorCPassword.Visible = true;
                    return;
                }
                lblErrorCPassword.Visible = false;
            };


            comboJabatan.DataSource = new List<string>() { "Mekanik","Petugas","Super Admin" };
        }

        #endregion

        #region SAVE DATA

        private void SaveData()
        {
            string nama = txtNama.Text.Trim();
            string noKtp = txtNoKTP.Text.Trim();
            string telepon = txtNoTelepon.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string konfirmPass = txtKonfirPassword.Text;
            string alamat = txtAlamat.Text;
            int jabatan = comboJabatan.SelectedIndex == 0 ? 0
                :comboJabatan.SelectedIndex == 1 ? 1
                : 2;
            byte[]? profile = !IsSameImage(_defaultProfile, _fotoAdmin) ? ImageConvert.ImageToByteArray(_fotoAdmin) : null;

            bool validationEvent = !lblErrorKTP.Visible
                 && !lblErrorTelepon.Visible
                 && !lblErrorEmail.Visible
                 && !lblErrorCPassword.Visible;
            bool validationEmpty = nama != ""
                && password != ""
                && alamat != "";
            if(!validationEvent || !validationEmpty)
            {
                MB.Warning("Data tidak valid, harap cek kembali!");
                return;
            }

            var dataPegawai = new KaryawanModelUpdate()
            {
                ktp_admin_old = _ktp_admin,
                ktp_admin_new = noKtp,
                nama_admin = nama,
                no_telp = telepon,
                email = email,
                password = _IsInsert || _resetPassword ?
                    PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Interactive) 
                    : null,
                alamat = alamat,
                role = jabatan,
                image_data = profile
            };

            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            if (_ktp_admin == string.Empty)
            {
                _karyawanDal.InsertData(dataPegawai);
            }
            else
            {
                _karyawanDal.UpdateData(dataPegawai);
                _karyawanDal.UpdateKTP(dataPegawai.ktp_admin_new, dataPegawai.ktp_admin_old);
            }

            if(dataPegawai.ktp_admin_old == GlobalVariabel._ktp)
                GlobalVariabel._ktp = dataPegawai.ktp_admin_new; //reset session

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GetData(string ktp_admin)
        {
            var data = _karyawanDal.GetData(ktp_admin);
            if (data is null) return;

            txtNama.Text = data.nama_admin;
            txtNoKTP.Text = data.ktp_admin;
            txtNoTelepon.Text = data.no_telp;
            txtEmail.Text = data.email;
            txtPassword.Text = data.password;
            txtKonfirPassword.Text = data.password;
            txtAlamat.Text = data.alamat;
            comboJabatan.SelectedIndex = data.role;

            //Set Profile
            Image profile = data.image_data != null ?
                ImageConvert.ByteArrayToImage(data.image_data)
                : _defaultProfile;
            pictureBoxProfile.BackgroundImage = profile;
            _fotoAdmin = profile;
        }

        private void ResetPassword(bool reset)
        {
            if (!reset) return;
            if (!MB.Konfirmasi("Apakah anda yakin ingin mereset password?")) return;
            txtPassword.ReadOnly = false;
            txtKonfirPassword.ReadOnly = false;
            txtPassword.Clear();
            txtKonfirPassword.Clear();
            _resetPassword = true;
        }

        #endregion
    }
}
