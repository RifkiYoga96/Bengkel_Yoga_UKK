using Syncfusion.UI.Xaml.Charts;
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
    public partial class FormBooking : Form
    {
        public static int _year, _month;

        public FormBooking()
        {
            InitializeComponent();
            InitComponent();
            ShowDays(DateTime.Now.Month + 2, DateTime.Now.Year);
            RegisterEvent();
        }

        private void InitComponent()
        {
            lblBulan.ForeColor = Color.Black;
            flowLayoutPanel1.Controls.Clear();
            lblDetails.ForeColor = SystemColors.ControlDarkDark;
            lblDone.ForeColor = SystemColors.ControlDarkDark;
            lblPending.ForeColor = SystemColors.ControlDarkDark;
            lblCancel.ForeColor = SystemColors.ControlDarkDark;
        }
        private void RegisterEvent()
        {
            btnNext.Click += (s, e) =>
            {
                if (_month >= 12)
                {
                    _month = 1;
                    _year += 1;
                }
                else
                {
                    _month += 1;
                }
                ShowDays(_month, _year);
            };

            btnPrevious.Click += (s, e) =>
            {
                if (_month <= 1)
                {
                    _month = 12;
                    _year -= 1;
                }
                else
                {
                    _month -= 1;
                }
                ShowDays(_month, _year);
            };

        }

        private void ShowDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;
            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lblBulan.Text = monthName.ToUpper() + " " + year;
            DateTime startodTheMonth = new DateTime(year, month, 1);

            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1; // sabtu = 6, minggu = 0, senin = 1 => 0-6
            for (int i = 1; i < week; i++)
            {
                ucCalendar uc = new ucCalendar(0, startodTheMonth, false);
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++)
            {
                DateTime tanggal = new DateTime(year, month, i);
                ucCalendar uc = new ucCalendar(i, tanggal, true);
                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void yogaButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
