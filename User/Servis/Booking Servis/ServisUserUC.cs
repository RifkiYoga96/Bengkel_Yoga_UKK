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
        public static ServisUserUC? _servisUserUC { get; private set; }
        public static bool _child = false;
        private readonly BookingDal _bookingDal = new BookingDal();

        public ServisUserUC()
        {
            InitializeComponent();
            _servisUserUC = this;
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

        public void LoadComponent()
        {
            if (ServisUserUC._servisUserUC == null) return;
            FlowLayoutPanel flow = ServisUserUC._servisUserUC.flowLayoutPanel1;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            int width = flow.ClientSize.Width;

            var kendaraanDal = new KendaraanDal();
            string ktp_pelanggan = GlobalVariabel._ktp;
            var listDataKendaraan = kendaraanDal.ListDataPelanggan(ktp_pelanggan);


            flow.Controls.Clear();

            var tambahKendaraan = new TambahKendaraanUC();
            tambahKendaraan.Width = flow.ClientSize.Width - 2;
            flow.Controls.Add(tambahKendaraan);

            foreach (var itm in listDataKendaraan)
            {
                UserControl kendaraan = new KendaraanUC(itm.id_kendaraan);
                kendaraan.Width = width - 2;
                flow.Controls.Add(kendaraan);
            }
            this.Resize -= ServisUser_Resize;
            this.Resize += ServisUser_Resize;

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
            this.Disposed += (s,e) => _servisUserUC = null;
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
