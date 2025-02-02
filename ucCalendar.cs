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
    
    public partial class ucCalendar : UserControl
    {
        int _date;
        string _day;
        public ucCalendar(int date,DateTime dateTime, bool show)
        {
            InitializeComponent();
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

            if(DateTime.Today == dateTime)
            {
                this.BackColor = Color.LightGray;
            }

            btnBooking1.Click += (s, e) => 
            {
                MainFormAdmin.ShowFormInPanel2(new DaftarBookingForm());
            };
        }
    }
}
