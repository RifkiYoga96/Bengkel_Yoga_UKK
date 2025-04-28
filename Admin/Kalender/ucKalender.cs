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
    
    public partial class ucKalender : UserControl
    {
        private readonly RiwayatDal _riwayatDal = new RiwayatDal();
        private readonly BookingDal _bookingDal = new BookingDal();
        int _date;
        private Dictionary<int, Button> _btnControl = new Dictionary<int, Button>();
        DateTime NowTgl;
        public ucKalender(int date, DateTime dateTime, bool show, ShowDayDto? showDay = null)
        {
            InitializeComponent();
            if (showDay is null) return;
            NowTgl = dateTime;
            if (!show)
            {
                this.BackColor = Color.Transparent;
                label1.Text = "";
                return;
            }
            _date = date;
            if (dateTime.DayOfWeek.ToString() == "Sunday")
            {
                label1.Text = date.ToString();
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.Text = date.ToString();
                label1.ForeColor = Color.Black;
            }

            if (DateTime.Today == dateTime)
            {
                this.BackColor = Color.LightGray;
            }

            _btnControl.Add(0, btnBooking1);
            _btnControl.Add(1, btnBooking2);
            _btnControl.Add(2, btnBooking3);

            if (showDay?.jumlah > 3)
            {
                for (int i = 0; i < showDay.nama_pelanggan.Count; i++)
                {
                    _btnControl[i].BackColor = showDay.warnaStatus[i];
                    _btnControl[i].Text = showDay.nama_pelanggan[i];
                    _btnControl[i].FlatAppearance.MouseDownBackColor = showDay.warnaStatus[i];
                    _btnControl[i].FlatAppearance.MouseOverBackColor = showDay.warnaStatus[i];
                    _btnControl[i].Visible = true;
                }
                this.btnCountNotif.Visible = showDay.jumlah> 3;
                btnCountNotif.Text = showDay?.jumlah > 9 ? "9+"
                    : showDay?.jumlah.ToString();
            }
            else if (showDay?.jumlah > 0)
            {
                for (int i = 0; i < showDay.nama_pelanggan.Count; i++)
                {
                    _btnControl[i].BackColor = showDay.warnaStatus[i];
                    _btnControl[i].Text = showDay.nama_pelanggan[i];
                    _btnControl[i].FlatAppearance.MouseDownBackColor = showDay.warnaStatus[i];
                    _btnControl[i].FlatAppearance.MouseOverBackColor = showDay.warnaStatus[i];
                    _btnControl[i].Visible = true;
                }
            }

            switch (showDay?.integratedTo)
            {
                case 1:
                    btnBooking1.Click += Click_ToBooking;
                    btnBooking2.Click += Click_ToBooking;
                    btnBooking3.Click += Click_ToBooking;
                    btnCountNotif.Click += Click_ToBooking;
                    this.Click += Click_ToBooking;
                    break;
                case 2:
                    btnBooking1.Click += Click_ToRiwayat;
                    btnBooking2.Click += Click_ToRiwayat;
                    btnBooking3.Click += Click_ToRiwayat;
                    btnCountNotif.Click += Click_ToRiwayat;
                    this.Click += Click_ToRiwayat;
                    break;
                case 3:
                    btnBooking1.Click += Click_ToBookingRiwayat;
                    btnBooking2.Click += Click_ToBookingRiwayat;
                    btnBooking3.Click += Click_ToBookingRiwayat;
                    btnCountNotif.Click += Click_ToBookingRiwayat;
                    this.Click += Click_ToBookingRiwayat;
                    break;
            }
        }

        private void Click_ToRiwayat(object? sender, EventArgs e)
        {
            MainFormAdmin.buttonActiveAfter = 4;
            MainFormAdmin.ControlSideBar();
            MainFormAdmin.ShowFormInPanel2(new FormRiwayat(NowTgl));
        }

        private void Click_ToBooking(object? sender, EventArgs e)
        {
            MainFormAdmin.buttonActiveAfter = 2;
            MainFormAdmin.ControlSideBar();
            MainFormAdmin.ShowFormInPanel2(new FormBooking(NowTgl));
        }

        private void Click_ToBookingRiwayat(object? sender, EventArgs e)
        {
            var dialog = new FormCaseIntegrated(NowTgl).ShowDialog();
            if (dialog == DialogResult.Yes)
            {
                MainFormAdmin.buttonActiveAfter = 2;
                MainFormAdmin.ControlSideBar();
                MainFormAdmin.ShowFormInPanel2(new FormBooking(NowTgl));
            }
            else if (dialog == DialogResult.OK)
            {
                MainFormAdmin.buttonActiveAfter = 4;
                MainFormAdmin.ControlSideBar();
                MainFormAdmin.ShowFormInPanel2(new FormRiwayat(NowTgl));
            }
        }
    }
}
