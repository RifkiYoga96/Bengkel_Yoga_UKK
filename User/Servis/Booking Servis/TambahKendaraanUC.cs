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
    public partial class TambahKendaraanUC : UserControl
    {
        public TambahKendaraanUC()
        {
            InitializeComponent();
            btnTambah.Click += (s, e) => 
            {
                /*FormDashboardUser._route = new RouteDto
                {
                    uc = new ServisUserUC(),
                    sideBar = false
                };
                FormDashboardUser.InitComponent(false);
                FormDashboardUser.ControlTab(4);
                FormDashboardUser.ShowControlInPanel(new InputKendaraanUC());*/

                new InputKendaraanForm().ShowDialog();
            };
            ServisUserUC._child = true;
        }
    }
}
