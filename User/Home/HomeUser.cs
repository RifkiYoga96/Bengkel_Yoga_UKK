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
    public partial class HomeUser : UserControl
    {
        public HomeUser()
        {
            InitializeComponent();

            btnBookingServis.Click += BtnBookingServis_Click;
        }

        private void BtnBookingServis_Click(object? sender, EventArgs e)
        {
            if (GlobalVariabel._ktp == string.Empty)
                {
                    if (!MB.Konfirmasi("Anda harus login terlebih dahulu!\nApakah anda ingin login")) return;
                    new Login().Show();
                    FormDashboardUser._formDashboardUser.Hide();
                    return;
                }

                FormDashboardUser._route = new RouteDto
                {
                    uc = new HomeUser(),
                    sideBar = true
                };
                ServisUserUC._child = false;
                FormDashboardUser.InitComponent(false);
                FormDashboardUser.ControlTab(4);
                FormDashboardUser.ShowControlInPanel(new ServisUserUC());
        }
    }
}
