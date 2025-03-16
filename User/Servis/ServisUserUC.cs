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
        
        

        private Image _H = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Image\H.png");
        private Image _Y = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Image\Y.png");
        private Image _K = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Image\K.png");
        private Image _S = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Image\S.png");
        public ServisUserUC()
        {
            InitializeComponent();
            LoadComponent();
            this.Resize += ServisUser_Resize;
            RegisterEvent();
            
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

            /*UserControl item = new KendaraanUC();
            item.Width = width-2;

            UserControl item2 = new KendaraanUC();
            item.Width = width - 2;

            UserControl item3 = new KendaraanUC();
            item.Width = width - 2;

            UserControl buttonAdd = new TambahKendaraanUC();
            buttonAdd.Width = width - 2;

            flowLayoutPanel1.Controls.Add(buttonAdd);
            flowLayoutPanel1.Controls.Add(item);
            flowLayoutPanel1.Controls.Add(item2);
            flowLayoutPanel1.Controls.Add(item3);*/

            string ktp_pelanggan = FormDashboardUser._ktp_pelanggan;
            var listDataKendaraan = _kendaraanDal.ListDataPelanggan(ktp_pelanggan);
            if (!listDataKendaraan.Any())
            {
                return;
                // penanganan jika belum ada kendaraan
            }

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
    }
}
