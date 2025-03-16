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
