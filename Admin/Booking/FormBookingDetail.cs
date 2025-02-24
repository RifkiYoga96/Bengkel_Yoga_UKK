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
        private int _currentStep = 1;
        public FormBookingDetail(int id)
        {
            InitializeComponent();
            InitComponent();

            _id_booking = id;
            RegisterEvent();

            GetData();
        }

        private void RegisterEvent()
        {
            btnSparepart.Click += (s,e) => 
            {
                if (new FormAddSparepart().ShowDialog() != DialogResult.OK) return;
            };

            this.Load += FormBookingDetail_Load;
        }

        private void FormBookingDetail_Load(object? sender, EventArgs e)
        {


        }

        private void InitComponent()
        {
            label1.ForeColor = SystemColors.ControlText;
            label10.ForeColor = SystemColors.ControlText;

            var listServis = new List<JasaServisModel>() 
            {
                new JasaServisModel{ id_jasaServis = 0, nama_jasaServis ="--Pilih jasa servis--" }
            };
            listServis.AddRange(_jasaServisDal.ListData());
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

