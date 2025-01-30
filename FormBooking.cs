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

            ShowDays(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void ShowDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;
            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lblBulan.Text = monthName. ToUpper() + " " + year; 
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < week; i++)
            {
                ucCalendar uc =  new ucCalendar("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++)
            {
                ucCalendar uc = new ucCalendar(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }
        } 
    }
}
