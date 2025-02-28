using Syncfusion.GridHelperClasses;
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
    public partial class FormInputBooking2 : Form
    {
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly BatasBookingDal _batasBookingDal = new BatasBookingDal();
        private readonly JadwalDal _jadwalDal = new JadwalDal();
        private readonly JadwalOperasionalDal _jadwalOperasionalDal = new JadwalOperasionalDal();

        public static int _antrean;
        public FormInputBooking2()
        {
            InitializeComponent();
            InitComponent_Pelanggan();
            RegisterEvent_Pelanggan();

            InitComponent_Tamu();
            RegisterEvent_Tamu();
            CekKetersediaanBoking();
        }

        #region PELANGGAN
        private void RegisterEvent_Pelanggan()
        {
            StyleComponent.TextChangeNull(txtKeluhan,lblErrorKeluhan, "⚠️ Harap isi keluhan!");

            txtNoKTP.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadData_Pelanggan();
                }
            };
            comboKendaraan.SelectedIndexChanged += (s, e) =>
            {
                txtNoPol.Text = ((KendaraanDto)comboKendaraan.SelectedItem)?.no_pol ?? string.Empty;
            };
            btnSearch.Click += (s, e) => LoadData_Pelanggan();
            btnSave.Click += (s, e) => SaveData_Pelanggan();
            btnCancel.Click += (s, e) => this.Close();
            TglEditSync.ValueChanged += async (s, e) =>
            {
                await Task.Delay(500);
                CekKetersediaanBoking();
            };
            tabControl1.SelectedIndexChanged += (s, e) =>
            {
                CekKetersediaanBoking();
            };
        }

        private void CekKetersediaanBoking()
        {
            int indexTab = tabControl1.SelectedIndex;

            if (indexTab == 0)
            {
                DateTime tanggal = TglEditSync.Value ?? DateTime.Today;

                var libur = _jadwalDal.CekLibur(tanggal);
                if (libur)
                {
                    lblErrorTanggal.Text = "Bengkel sedang libur, Mohon pilih tanggal lain!";
                    lblErrorTanggal.Visible = true;
                    return;
                }

                var tutup = _jadwalOperasionalDal.CekTutup(tanggal);
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
            else if (indexTab == 1)
            {
                DateTime tanggal = TglEditSync2.Value ?? DateTime.Today;

                var libur = _jadwalDal.CekLibur(tanggal);
                if (libur)
                {
                    lblErrorTanggal2.Text = "Bengkel sedang libur, Mohon pilih tanggal lain!";
                    lblErrorTanggal2.Visible = true;
                    return;
                }

                var tutup = _jadwalOperasionalDal.CekTutup(tanggal);
                if (tutup)
                {
                    lblErrorTanggal2.Text = "Bengkel sudah tutup, Mohon pilih tanggal lain!";
                    lblErrorTanggal2.Visible = true;
                    return;
                }

                var totalBooking = _bookingDal.GetAntrean(tanggal, 1)?.Antrean - 1;
                var maxBooking = _batasBookingDal.GetBatasBooking(tanggal);

                if (totalBooking >= maxBooking)
                {
                    lblErrorTanggal2.Text = "Antrean sudah penuh, Mohon pilih tanggal lain!";
                    lblErrorTanggal2.Visible = true;
                    return;
                }
                lblErrorTanggal2.Visible = false;
            }
        }

        private void InitComponent_Pelanggan()
        {
            txtNama.MaxLength = 100;
            txtNoKTP.MaxLength = 90;
            txtKeluhan.MaxLength = 100;
            TglEditSync.MinDateTime = DateTime.Today;
            TglEditSync.StyleDateTimeEdit();
        }

        private void LoadData_Pelanggan()
        {
            ClearInput();
            var kendaraanPelanggan = _kendaraanDal.ListDataPelanggan(txtNoKTP.Text.Trim());
            if (!kendaraanPelanggan.Any())
            {
                lblErrorKTP.Visible = true;
                comboKendaraan.DataSource = null;
                return;
            }
            lblErrorKTP.Visible = false;
            var data = kendaraanPelanggan.FirstOrDefault();

            txtNama.Text = data?.nama_pelanggan;
            var listkendaraan = kendaraanPelanggan
                .Select(x => new KendaraanDto
                {
                    id_kendaraan = x.id_kendaraan,
                    nama_kendaraan = $"{x.merk} {x.tipe} {x.kapasitas}cc ({x.tahun})",
                    no_pol = x.no_pol
                }).ToList();
            comboKendaraan.DataSource = listkendaraan;
            comboKendaraan.DisplayMember = "nama_kendaraan";
            comboKendaraan.ValueMember = "id_kendaraan";

            txtNoPol.Text = ((KendaraanDto)comboKendaraan.SelectedItem)?.no_pol ?? string.Empty;
        }
        private void ClearInput()
        {
            txtNama.Clear();
            txtNoPol.Clear();
        }

        private void SaveData_Pelanggan()
        {
            string noKTP = txtNoKTP.Text;
            int id_kendaraan = Convert.ToInt32(comboKendaraan?.SelectedValue);
            DateTime tanggal = TglEditSync.Value ?? DateTime.Today;
            string keluhan = txtKeluhan.Text;

            if(noKTP == string.Empty || id_kendaraan == 0 || keluhan == string.Empty)
            {
                MB.Warning("Harap melengkapi data!");
                return;
            }

            bool valid = !lblErrorKTP.Visible &&
                         !lblErrorKeluhan.Visible &&
                         !lblErrorTanggal.Visible;
            if (!valid)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }
            if (new FormAntrean(tanggal).ShowDialog() == DialogResult.OK)
            {
                var data = new BookingModel2
                {
                    ktp_pelanggan = noKTP,
                    id_kendaraan = id_kendaraan,
                    tanggal = tanggal,
                    keluhan = keluhan,
                    antrean = _antrean
                };
                _bookingDal.InsertDataBooking(data, true);
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
        }
        #endregion

        #region TAMU
        private void RegisterEvent_Tamu()
        {
            StyleComponent.TextChangeNull(txtNama2, lblErrorNama2, "⚠️ Harap masukkan nama!");
            StyleComponent.TextChangeNull(txtKendaraan2, lblErrorKendaraan2, "⚠️ Masukkan nama kendaraan!");
            StyleComponent.TextChangeNull(txtNoPol2, lblErrorNoPol, "⚠️ Harap masukkan nomor polisi!");
            StyleComponent.TextChangeNull(txtKeluhan2, lblErrorKeluhan2, "⚠️ Harap isi keluhan!");

            txtNoPol2.TextChanged += async (s, e) =>
            {
                await Task.Delay(2000);
                string no_pol = txtNoPol2.Text;
                string pola = @"^[A-Z]{1,2} \d{1,4} [A-Z]{1,3}$";
                if (!Regex.IsMatch(no_pol, pola) || no_pol.Length == 0)
                {
                    lblErrorNoPol.Text = "⚠️ Format No Pol tidak valid!";
                    lblErrorNoPol.Visible = true;
                    return;
                }
                if (_bookingDal.CekNoPol(txtNoPol2.Text.Trim()))
                {
                    lblErrorNoPol.Text = "⚠️ Nomor polisi sudah tersedia!";
                    lblErrorNoPol.Visible = true;
                    return;
                }
                lblErrorNoPol.Visible = false;
            };

            btnCancel2.Click += (s, e) => this.Close();
            btnSave2.Click += (s, e) => SaveData_Tamu();
            TglEditSync2.ValueChanged += (s, e) => CekKetersediaanBoking();
        }

        private void InitComponent_Tamu()
        {
            txtNama2.MaxLength = 100;
            txtKeluhan2.MaxLength = 100;
            txtKendaraan2.MaxLength = 50;
            txtNoPol2.MaxLength = 50;
            TglEditSync2.MinDateTime = DateTime.Today;
            TglEditSync2.StyleDateTimeEdit();
            txtKeluhan2.MaxLength = 100;
        }

        private void SaveData_Tamu()
        {
            string nama = txtNama2.Text;
            string nama_kendaraan = txtKendaraan2.Text;
            string no_pol = txtNoPol2.Text;
            DateTime tanggal = TglEditSync2.Value ?? DateTime.Today;
            string keluhan = txtKeluhan2.Text;

            if (nama == string.Empty || nama_kendaraan == string.Empty || keluhan == string.Empty || no_pol == string.Empty)
            {
                MB.Warning("Harap melengkapi data!");
                return;
            }

            bool valid = !lblErrorNama2.Visible &&
             !lblErrorKendaraan2.Visible &&
             !lblErrorNoPol.Visible &&
             !lblErrorKeluhan2.Visible &&
             !lblErrorTanggal2.Visible;

            if (!valid)
            {
                MB.Warning("Data tidak valid, mohon cek kembali!");
                return;
            }

            if (new FormAntrean(tanggal).ShowDialog() == DialogResult.OK)
            {
                var data = new BookingModel2
                {
                    nama_pelanggan = nama,
                    nama_kendaraan = nama_kendaraan,
                    tanggal = tanggal,
                    keluhan = keluhan,
                    no_pol = no_pol,
                    antrean = _antrean
                };
                _bookingDal.InsertDataBooking(data, false);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        #region HELPER

        

        #endregion
    }
}

public class KendaraanDto
{
    public int id_kendaraan { get; set; }
    public string nama_kendaraan { get; set; }
    public string no_pol {  get; set; }
}
