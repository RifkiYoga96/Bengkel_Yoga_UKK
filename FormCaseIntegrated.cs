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
    public partial class FormCaseIntegrated : Form
    {
        public FormCaseIntegrated(DateTime tgl)
        {
            InitializeComponent();
            lblTanggal.Text = tgl.ToString("d MMMM yyy", new CultureInfo("id-ID"));
            btnBooking.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            };

            btnRiwayat.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }
    }
}
