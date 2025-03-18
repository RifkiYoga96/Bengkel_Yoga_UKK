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
    public partial class ServisUC : UserControl
    {
        public ServisUC()
        {
            InitializeComponent();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            btnBooking.Click += (s, e) =>
            {
                if (GlobalVariabel._ktp == string.Empty)
                {
                    if (!MB.Konfirmasi("Anda harus login terlebih dahulu!\nApakah anda ingin login")) return;
                    new Login().Show();
                    FormDashboardUser._formDashboardUser.Hide();
                    return;
                }
                else if (Regex.IsMatch(GlobalVariabel._ktp, @"[A-Za-z]"))
                {
                    if (!MB.Konfirmasi("Anda harus melengkapi data terlebih dahulu!\nApakah anda ingin melengkapi?")) return;
                    new RegisterLanjutan().Show();
                    FormDashboardUser._formDashboardUser.Hide();
                    return;
                }

                FormDashboardUser._route = new RouteDto
                {
                    uc = new ServisUC(),
                    sideBar = true
                };
                ServisUserUC._child = false;
                FormDashboardUser.InitComponent(false);
                FormDashboardUser.ControlTab(4);
                FormDashboardUser.ShowControlInPanel(new ServisUserUC());
            };
        }
    }
}
