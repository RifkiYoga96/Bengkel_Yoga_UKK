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
    public partial class sFormInputBooking : Form
    {
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        public sFormInputBooking()
        {
            InitializeComponent();
            InitComponent();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            txtNoKTP.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    LoadData();
                }
            };
        }
        private void InitComponent()
        {
            txtNoKTP.MaxLength = 20;
            txtNama.MaxLength = 90;
            txtKeluhan.MaxLength = 100;
        }

        private void LoadData()
        {
            var kendaraanPelanggan = _kendaraanDal.ListDataPelanggan(txtNoKTP.Text.Trim());
            if (!kendaraanPelanggan.Any())
            {
                lblErrorKTP.Visible = true;
                return;
            }
            

        }
        private void ClearInput()
        {
            txtNama.Clear();
            txtNoPol.Clear();
            
        }

    }
}
