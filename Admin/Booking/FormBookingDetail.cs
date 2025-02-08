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
        private int _id_booking;
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
            
        }

        private void InitComponent()
        {
            label1.ForeColor = SystemColors.ControlText;
            label10.ForeColor = SystemColors.ControlText;

            var listServis = _jasaServisDal.ListData();
            comboServis.DataSource = listServis;
            comboServis.DisplayMember = "nama_jasaServis";
            comboServis.ValueMember = "id_jasaServis";

            comboEstimasi.DataSource = new List<string>() { "Menit","Jam" };

           

        }

        private void GetData()
        {
            var data = _bookingDal.GetData(_id_booking);
            if (data is null) return;

            txtIdBooking.Text = data.id_booking.ToString();
            txtNama.Text = data.nama_pelanggan;
            txtKTP.Text = data.ktp_pelanggan;
            txtKendaraan.Text = $"{data.merk} {data.tipe} {data.kapasitas} ({data.tahun})";
            txtNoPol.Text = data.tanggal.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
            txtKeluhan.Text = data.keluhan;
        }
    }
}
