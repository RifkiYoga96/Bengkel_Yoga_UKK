using Bengkel_Yoga_UKK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormBookingDetail : Form
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly JasaServisDal _jasaServisDal = new JasaServisDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private readonly ProdukDal _produkDal = new ProdukDal();    
        public static int _id_booking;
        private int _servisKeterangan = 0;
        Color _hijau = Color.FromArgb(0, 192, 0);
        Color _oren = Color.FromArgb(240, 177, 0);
        Color _biru = Color.FromArgb(52, 152, 219);

        public FormBookingDetail(int id)
        {
            InitializeComponent();
            InitComponent();

            _id_booking = id;
            RegisterEvent();

            GetData();
            ProgresServis();
        }

        private void RegisterEvent()
        {
            btnSparepart.Click += (s,e) => 
            {
                if (new FormAddSparepart().ShowDialog() != DialogResult.OK) return;
                GetData();
            };
            btnServisProses.Click += (s, e) =>
            {
                if (_servisKeterangan == 1)
                {
                    btnServisProses.BorderSize = 2;
                    btnServisProses.BackColor = Color.Transparent;
                    btnServisProses.ForeColor = SystemColors.ControlDarkDark;

                    _servisKeterangan = 0;
                    ProgresServis();
                }
                else if (_servisKeterangan == 0 || _servisKeterangan == 2)
                {
                    btnServisProses.BorderSize = 0;
                    btnServisProses.BackColor = _oren;
                    btnServisProses.ForeColor = Color.White;

                    btnServisSelesai.BorderSize = 2;
                    btnServisSelesai.BackColor = Color.Transparent;
                    btnServisSelesai.ForeColor = SystemColors.ControlDarkDark;

                    _servisKeterangan = 1;
                    ProgresServis();
                }
                
            };
            btnServisSelesai.Click += (s, e) =>
            {
                if(_servisKeterangan == 2)
                {
                    btnServisSelesai.BorderSize = 2;
                    btnServisSelesai.BackColor = Color.Transparent;
                    btnServisSelesai.ForeColor = SystemColors.ControlDarkDark;

                    _servisKeterangan = 0;
                    ProgresServis();
                }
                else if (_servisKeterangan == 1)
                {
                    btnServisProses.BorderSize = 2;
                    btnServisProses.BackColor = Color.Transparent;
                    btnServisProses.ForeColor = SystemColors.ControlDarkDark;

                    btnServisSelesai.BorderSize = 0;
                    btnServisSelesai.BackColor = _hijau;
                    btnServisSelesai.ForeColor = Color.White;

                    _servisKeterangan = 2;
                    ProgresServis();
                }
                
            };
            btnInvoice.Click += (s, e) =>
            {
                if (_servisKeterangan != 2) return;
                bool valid = comboServis.SelectedIndex != 0
                    && comboMekanik.SelectedIndex != 0
                    && txtCatatan.TextLength != 0
                    && txtCatatan.Text.Trim() != string.Empty;
                if (!valid)
                {
                    MB.Warning("Mohon melengkapi jenis servis, mekanik dan catatan!");
                    return;
                }



                btnInvoice.BorderSize = 0;
                btnInvoice.BackColor = _biru;
                btnInvoice.ForeColor = Color.White;
            };
        }

        private void ProgresServis()
        {
            if(_servisKeterangan == 0)
            {
                lblBookingToServis.ForeColor = SystemColors.ControlDarkDark;
                pictureServis.BackgroundImage = null;
                pictureServis.BorderSize = 2;
                lblServisToSelesai.ForeColor = SystemColors.ControlDarkDark;
                pictureSelesai.BackgroundImage = null;
                pictureSelesai.BorderSize = 2;
            }
            else if (_servisKeterangan == 1)
            {
                lblBookingToServis.ForeColor = _oren;
                pictureServis.BackgroundImage = Properties.Resources.oren;
                pictureServis.BorderSize = 0;
                lblServisToSelesai.ForeColor = SystemColors.ControlDarkDark;
                pictureSelesai.BackgroundImage = null;
                pictureSelesai.BorderSize = 2;
            }
            else if(_servisKeterangan == 2)
            {
                lblBookingToServis.ForeColor = _hijau;
                pictureServis.BackgroundImage = Properties.Resources.hijau;
                pictureServis.BorderSize = 0;
                lblServisToSelesai.ForeColor = _oren;
                pictureSelesai.BackgroundImage = Properties.Resources.oren;
                pictureSelesai.BorderSize = 0;
            }
            else
            {
                lblBookingToServis.ForeColor = _hijau;
                pictureServis.BackgroundImage = Properties.Resources.hijau;
                pictureServis.BorderSize = 0;
                lblServisToSelesai.ForeColor = _hijau;
                pictureSelesai.BackgroundImage = Properties.Resources.hijau;
                pictureSelesai.BorderSize = 0;
            }
            label19.Text = _servisKeterangan.ToString();

        }


        private void InitComponent()
        {
            label1.ForeColor = SystemColors.ControlText;
            label10.ForeColor = SystemColors.ControlText;

            var listServis = new List<JasaServisModel>() 
            {
                new JasaServisModel{ id_jasaServis = 0, nama_jasaServis ="--Pilih jasa servis--" }
            };
            //listServis.AddRange(_jasaServisDal.ListData());
            comboServis.DataSource = listServis;
            comboServis.DisplayMember = "nama_jasaServis";
            comboServis.ValueMember = "id_jasaServis";

            var listMekanik = new List<MekanikModelCombo>() 
            {
                new MekanikModelCombo{ ktp_mekanik = string.Empty,nama_mekanik = "--Pilih Mekanik--" }
            }; 
            listMekanik.AddRange(_karyawanDal.ListData(new FilterDto())
               .Where(x => x.role == 0)
               .Select(x => new MekanikModelCombo
               {
                   ktp_mekanik = x.ktp_admin,
                   nama_mekanik = x.nama_admin
               }).ToList());
            comboMekanik.DataSource = listMekanik;
            comboMekanik.DisplayMember = "nama_mekanik";
            comboMekanik.ValueMember = "ktp_mekanik";
        }

        private void GetData()
        {
            var data = _bookingDal.GetData(_id_booking);
            if (data is null) return;

            txtIdBooking.Text = data.id_booking.ToString();
            txtNama.Text = data.nama_pelanggan;
            txtKTP.Text = data.ktp_pelanggan;
            txtKendaraan.Text = data.nama_kendaraan;
            txtNoPol.Text = data.no_pol;
            txtTanggal.Text = data.tanggal.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
            txtKeluhan.Text = data.keluhan;

            foreach (var item in comboServis.Items)
                if (item is JasaServisModel js)
                    if (js.id_jasaServis == data.id_jasaServis)
                        comboServis.SelectedItem = item;

            foreach (var item in comboMekanik.Items)
                if (item is MekanikModelCombo m)
                    if (m.ktp_mekanik == data.ktp_mekanik)
                        comboMekanik.SelectedItem = item;

            var listSparepart = _bookingDal.ListDataProduk(_id_booking);
            txtSparepart.Text = string.Join(", ",listSparepart.Select(x => x.nama_sparepart));
        }

    
    }
}


public class MekanikModelCombo
{
    public string ktp_mekanik { get; set; }
    public string nama_mekanik { get; set; }
}



