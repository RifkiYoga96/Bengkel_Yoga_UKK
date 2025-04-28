using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormKalender : Form
    {
        public static int _year, _month;
        private readonly RiwayatDal _riwayatDal = new RiwayatDal();
        private readonly BookingDal _bookingDal = new BookingDal();

        private Color _pending = Color.FromArgb(31, 133, 235);
        private Color _dikerjakan = Color.FromArgb(240, 177, 0);
        private Color _selesai = Color.FromArgb(0, 192, 0);
        private Color _dibatalkan = Color.FromArgb(210, 60, 60);
        public FormKalender()
        {
            InitializeComponent();
            InitComponent();
            ShowDays(DateTime.Now.Month, DateTime.Now.Year);
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

            var listDay = ListData(month, year);

            for (int i = 1; i < week; i++)
            {
                ucKalender uc = new ucKalender(0, startodTheMonth, false);
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++)
            {
                DateTime tanggal = new DateTime(year, month, i);
                var data = listDay.Where(x => x.tanggal == tanggal).OrderBy(x => x.tanggal);
                var showDay = new ShowDayDto
                {
                    nama_pelanggan = data.Take(3).Select(x => x.nama_pelanggan).ToList(),
                    warnaStatus = data.Take(3)
                        .Select(x => x.status == "pending" ? _pending
                              : x.status == "dibatalkan" ? _dibatalkan
                              : x.status == "dikerjakan" ? _dikerjakan
                              : _selesai)
                        .ToList(),
                    jumlah = data.Count(),
                    integratedTo = !data.Any() ? 0
                            : data.All(x => x.status == "pending" || x.status == "dikerjakan") ? 1
                            : data.All(x => x.status == "selesai" || x.status == "dibatalkan") ? 2
                            : 3
                };

                ucKalender uc = new ucKalender(i, tanggal, true, showDay);
                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        private IEnumerable<ShowDayModel> ListData(int month, int year)
        {
            const string sql = @"SELECT p.nama_pelanggan,b.status,b.tanggal
                                 FROM Pelanggan p
                                 INNER JOIN Bookings b
                                    ON p.ktp_pelanggan = b.ktp_pelanggan
                                 WHERE YEAR(Tanggal) = @year AND MONTH(Tanggal) = @month";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<ShowDayModel>(sql, new { month = month, year = year });
        }



    }
}

public class ShowDayDto
{
    public List<string> nama_pelanggan { get; set; }
    public List<Color> warnaStatus {  get; set; }
    public int jumlah { get; set; }
    public int integratedTo {  get; set; }
}

public class ShowDayModel
{
    public string nama_pelanggan { get; set; }
    public DateTime tanggal {  get; set; }
    public string status {  get; set; }
}
