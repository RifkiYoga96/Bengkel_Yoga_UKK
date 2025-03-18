using Syncfusion.Windows.Forms.Tools;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Bengkel_Yoga_UKK
{
    public partial class ServisUserUC : UserControl
    {
        public static bool _child = false;
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private readonly BookingDal _bookingDal = new BookingDal();

        public ServisUserUC()
        {
            InitializeComponent();
            LoadComponent();
            this.Resize += ServisUser_Resize;
            RegisterEvent();
            UpdateAntrean();
            
        }

        private void ServisUser_Resize(object? sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                ctrl.Width = flowLayoutPanel1.ClientSize.Width - 2;
            }
        }

        private void LoadComponent()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            int width = this.ClientSize.Width;

            string ktp_pelanggan = GlobalVariabel._ktp;
            var listDataKendaraan = _kendaraanDal.ListDataPelanggan(ktp_pelanggan);
            if (!listDataKendaraan.Any())
            {
                return;
                // penanganan jika belum ada kendaraan
            }

            flowLayoutPanel1.Controls.Add(new TambahKendaraanUC());
            foreach (var itm in listDataKendaraan)
            {
                UserControl kendaraan = new KendaraanUC(itm.id_kendaraan);
                kendaraan.Width = width - 2;
                flowLayoutPanel1.Controls.Add(kendaraan);
            }
        }
        private void RegisterEvent()
        {
            this.Load += (s, e) =>
            {
                if (!_child) return;
                FormDashboardUser._route = new RouteDto
                {
                    uc = new ServisUC(),
                    sideBar = true
                };
            };
        }

        private async void UpdateAntrean()
        {
            DateTime now = DateTime.Today;
            var listAntrean = await _bookingDal.ListDataAntrean(now);
            if (!listAntrean.Any()) return;
            int antrean = 1;
            foreach (var item in listAntrean)
            {
                var booking = new BookingModel
                {
                    id_booking = item.id_booking,
                    antrean = antrean++,
                    tipe_antrean = 2
                };
                _bookingDal.UpdateAntrean(booking);
            }
        }
    }
}
