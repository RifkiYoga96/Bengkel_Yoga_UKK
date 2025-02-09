using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputKaryawan : Form
    {
        private Image _fotoKaryawan = Properties.Resources.defaultProfile;
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        public FormInputKaryawan(string ktp_admin,bool IsInsert = true)
        {
            InitializeComponent();
            RegisterEvent();
            if (!IsInsert)
                GetData(ktp_admin);
        }

        private void RegisterEvent()
        {
            btnChooseFile.Click += BtnChooseFile_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            
        }

        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);


                    if (new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK) return;

                    pictureBoxProfile.BackgroundImage = ImageDirectory._imageResult;
                    pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;

                }
            }
        }



        #region SAVE DATA

        private void SaveData()
        {
            string nama = txtNama.Text;
            string noKtp = txtNoKTP.Text;
        }

        private void GetData(string ktp_admin)
        {
            var data = _karyawanDal.GetData(ktp_admin);
            if (data is null) return;

            txtPassword.ReadOnly = true;
            txtKonfirPassword.ReadOnly = true;

            txtNama.Text = data.nama_admin;
            txtNoKTP.Text = data.ktp_admin;
            txtTelepon.Text = data.no_telp;
            txtEmail.Text = data.email;
            txtPassword.Text = data.password;
            txtKonfirPassword.Text = data.password;
            txtAlamat.Text = data.alamat;
            radioSuperAdmin.Checked = data.role == 2 ? true: false;
            radioKaryawan.Checked = data.role == 1 ? true: false;
            pictureBoxProfile.BackgroundImage = data.image_data != null ? ImageConvert.Image_ByteToImage(data.image_data) : _fotoKaryawan;
        }

        #endregion
    }
}
