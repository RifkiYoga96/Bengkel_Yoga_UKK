using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bengkel_Yoga_UKK
{
    public partial class FormAntrean : Form
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        public FormAntrean(DateTime tanggal)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

            var dataAntrean = _bookingDal.GetAntrean(tanggal, 1);

            lblAntreanUser.Text = "A" + dataAntrean?.Antrean.ToString("D3");
            if(dataAntrean?.ServisNow == 0)
            {
                lblAntreanDilayani.Font = new Font("Microsoft New Tai Lue", 16, FontStyle.Bold);
                lblAntreanDilayani.Text = "Belum ada";
            }
            else
            {
                lblAntreanDilayani.Font = new Font("Microsoft New Tai Lue", 36, FontStyle.Bold);
                lblAntreanDilayani.Text = "A" + dataAntrean?.ServisNow.ToString("D3");
            }


            btnYa.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                GlobalVariabel._antrean = dataAntrean.Antrean;
                this.Close();
            };

            btnTidak.Click += (s, e) => this.Close();
        }
    }
}
