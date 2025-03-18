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
    public partial class FormBookingUser : Form
    {
        private readonly UserKendaraanDal _userKendaraanDal = new UserKendaraanDal();
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly BatasBookingDal _batasBookingDal = new BatasBookingDal();
        private readonly JadwalDal _jadwalDal = new JadwalDal();
        private readonly JadwalOperasionalDal _jadwalOperasionalDal = new JadwalOperasionalDal();
        private int _id_kendaraan = 0;
        public FormBookingUser(int id_kendaraan)
        {
            InitializeComponent();
            this.IsDialogForm();
            InitComponent();
            RegisterEvent();
            GetData(id_kendaraan);
            _id_kendaraan = id_kendaraan;
        }
        private void InitComponent()
        {
            txtKeluhan.MaxLength = 100;
            TglEditSync.MinDateTime = DateTime.Today;
            TglEditSync.StyleDateTimeEdit();
        }
        private void RegisterEvent()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string noKTP = GlobalVariabel._ktp;
            int id_kendaraan = _id_kendaraan;
            DateTime tanggal = TglEditSync.Value ?? DateTime.Today;
            string keluhan = txtKeluhan.Text;

            if (keluhan == string.Empty)
            {
                MB.Warning("Harap mengisi keluhan!");
                return;
            }

            bool valid = !lblErrorKeluhan.Visible &&
                         !lblErrorTanggal.Visible;
            if (!valid)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }
            if (new FormAntrean(tanggal).ShowDialog() == DialogResult.OK)
            {
                var data = new BookingModel
                {
                    ktp_pelanggan = noKTP,
                    id_kendaraan = id_kendaraan,
                    tanggal = tanggal,
                    keluhan = keluhan,
                    antrean = GlobalVariabel._antrean
                };
                _bookingDal.InsertDataBooking(data, true);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void GetData(int id)
        {
            var kendaraan = _userKendaraanDal.GetDataKendaraan(id);
            if (kendaraan is null) return;
            lblMerk.Text = kendaraan.merk;
            lblTipe.Text = kendaraan.tipe;
            lblNoPol.Text = kendaraan.no_pol;

            Color kodeWarna = WarnaMerk.GetWarnaMerek(kendaraan.merk.Trim().ToLower());
            Image colorProfile = ImageConvert.GenerateCircleImage(kodeWarna, 80);
            panelProfile.BackgroundImageLayout = ImageLayout.Zoom;
            panelProfile.BackgroundImage = colorProfile;

            CekKetersediaan();
        }

        private async void CekKetersediaan()
        {
            //Cek Ketersediaan Tanggal
            DateTime tanggal = TglEditSync.Value ?? DateTime.Today;

            var libur = await _jadwalDal.CekLibur(tanggal);
            if (libur)
            {
                lblErrorTanggal.Text = "Bengkel sedang libur, Mohon pilih tanggal lain!";
                lblErrorTanggal.Visible = true;
                return;
            }

            var tutup = await _jadwalOperasionalDal.CekTutup(tanggal);
            if (tutup)
            {
                lblErrorTanggal.Text = "Bengkel sudah tutup, Mohon pilih tanggal lain!";
                lblErrorTanggal.Visible = true;
                return;
            }

            var totalBooking = _bookingDal.GetAntrean(tanggal, 1)?.Antrean - 1;
            var maxBooking = _batasBookingDal.GetBatasBooking(tanggal);

            if (totalBooking >= maxBooking)
            {
                lblErrorTanggal.Text = "Antrean sudah penuh, Mohon pilih tanggal lain!";
                lblErrorTanggal.Visible = true;
                return;
            }
            lblErrorTanggal.Visible = false;
        }

    }
}
