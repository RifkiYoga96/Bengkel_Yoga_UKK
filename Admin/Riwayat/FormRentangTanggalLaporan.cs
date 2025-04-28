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
    public partial class FormRentangTanggalLaporan : Form
    {
        Laporan _laporan = new Laporan();
        public FormRentangTanggalLaporan()
        {
            InitializeComponent();
            this.IsDialogForm();
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            DateTime tanggal1 = TglEditSync1.Value ?? DateTime.Today;
            DateTime tanggal2 = TglEditSync2.Value ?? DateTime.Today;

            _laporan.GenerateLaporan(tanggal1,tanggal2);
        }
    }
}
