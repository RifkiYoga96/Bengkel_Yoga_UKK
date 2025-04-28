using Syncfusion.Windows.Forms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bengkel_Yoga_UKK
{
    public partial class KendaraanUC : UserControl
    {
        private readonly UserKendaraanDal _userKendaraanDal = new UserKendaraanDal();
        private readonly KendaraanDal _kendaraanDal = new KendaraanDal();
        private int _id_kendaraan = 0;
        private bool _isBooking = false;
        private int _id_terkait = 0;
        // Buat instance SfToolTip
        
        public KendaraanUC(int id_kendaraan)
        {
            InitializeComponent();
            _id_kendaraan = id_kendaraan;
            RegisterEvent();
        }

        private void LoadData(int id_kendaraan)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.OwnerDraw = true;
            lblCatatanServis.AutoSize = true;

            int maxWidth = 230;

            var kendaraan = _userKendaraanDal.GetDataKendaraan(_id_kendaraan);
            if (kendaraan is null) return;
            lblMerk.Text = kendaraan.merk;
            lblTipe.Text = kendaraan.tipe;
            lblNoPol.Text = kendaraan.no_pol;

            Color kodeWarna = WarnaMerk.GetWarnaMerek(kendaraan.merk.Trim().ToLower());
            Image colorProfile = ImageConvert.GenerateCircleImage(kodeWarna, 80);
            panelProfile.BackgroundImageLayout = ImageLayout.Zoom;
            panelProfile.BackgroundImage = colorProfile;

            lblProfile.Text = kendaraan.merk.Substring(0,1).ToUpper();

            var dataBooking = _userKendaraanDal.GetServisBooking(id_kendaraan);
            var dataRiwayat = _userKendaraanDal.GetServisRiwayat(id_kendaraan);
            if(dataBooking != null)
            {
                //keterangan servis
                lblTanggal.Text = dataBooking.tanggal.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
                lblTanggal.ForeColor = SystemColors.ControlText;
                lblCatatanServis.Visible = true;

                var antrean = Convert.ToInt32(dataBooking?.antrean).ToString("D3");
                string tipeAntrean = dataBooking?.tipe_antrean == 1 ? "A" : "B";

                Color colorStatus = dataBooking?.status == "pending" ?
                    Color.FromArgb(41, 128, 185) :
                    Color.FromArgb(240, 177, 0);
                string status = dataBooking?.status == "pending" ? "Sedang Menunggu" : "Sedang dikerjakan";

                lblTanggal.Text = $"Antrean {tipeAntrean}{antrean} - ";
                lblCatatanServis.Text = status;
                lblCatatanServis.ForeColor = colorStatus;

                int location = lblTanggal.Width + lblTanggal.Location.X - 11;
                lblCatatanServis.Location = new Point(location, lblCatatanServis.Location.Y);

                if(lblCatatanServis.Width >= maxWidth)
                {
                    lblCatatanServis.AutoSize = false;
                    lblCatatanServis.AutoEllipsis = true;
                    lblCatatanServis.Width = 230;
                }
                btnDetail.Location = new Point(lblCatatanServis.Location.X + lblCatatanServis.Width + 5, btnDetail.Location.Y);

                _isBooking = true;
                _id_terkait = dataBooking?.id_terkait ?? 0;
            }
            else if (dataRiwayat != null)
            {
                lblTanggal.ForeColor = SystemColors.ControlText;
                lblCatatanServis.Visible = true;
                lblCatatanServis.ForeColor = dataRiwayat.status != "selesai" ? Color.FromArgb(239, 7, 7) : Color.FromArgb(41, 128, 185);

                lblTanggal.Text = dataRiwayat.tanggal.ToString("d MMMM yyyy", new CultureInfo("id-ID")) + " - ";
                lblCatatanServis.Text = dataRiwayat.status != "selesai" ? "Dibatalkan" : dataRiwayat.catatan;

                int location = lblTanggal.Width + lblTanggal.Location.X - 11;
                lblCatatanServis.Location = new Point(location, lblCatatanServis.Location.Y);

                if (lblCatatanServis.Width >= maxWidth)
                {
                    lblCatatanServis.AutoSize = false;
                    lblCatatanServis.AutoEllipsis = true;
                    lblCatatanServis.Width = 230;
                }
                btnDetail.Location = new Point(lblCatatanServis.Location.X + lblCatatanServis.Width + 5, btnDetail.Location.Y);

                _isBooking = false;
                _id_terkait = dataRiwayat?.id_terkait ?? 0;
            }
            else
            {
                lblTanggal.Text = "Belum pernah servis";
                lblTanggal.ForeColor = SystemColors.ControlDarkDark;
                lblCatatanServis.Visible = false;
                btnDetail.Visible = false;
                return;
            }
            toolTip.Draw += ToolTip_Draw;
        }

        private void ToolTip_Draw(object? sender, DrawToolTipEventArgs e)
        {
            Font font = new Font("Segoe UI", 12.75f, FontStyle.Bold);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, font, Brushes.Black, e.Bounds);
        }
        private void RegisterEvent()
        {
            btnDetail.Click += BtnDetail_Click;
            btnEdit.Click += BtnEdit_Click;

            this.Load += KendaraanUC_Load;
            btnBooking.Click += BtnBooking_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin menghapus kendaraan ini?")) return;
            _kendaraanDal.SoftDeleteData(_id_kendaraan);
            //ServisUserUC.LoadComponent();
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (new InputKendaraanForm(_id_kendaraan).ShowDialog() != DialogResult.OK) return;
            LoadData(_id_kendaraan);
        }

        private void BtnDetail_Click(object? sender, EventArgs e)
        {
            FormDashboardUser._route = new RouteDto
            {
                uc = new ServisUserUC(),
                sideBar = false
            };
            FormDashboardUser.InitComponent(false);
            FormDashboardUser.ControlTab(4);
            FormDashboardUser.ShowControlInPanel(new BookingDetailUserUC(_isBooking, _id_terkait));
        }

        private void BtnBooking_Click(object? sender, EventArgs e)
        {
            int id = _id_kendaraan;
            var dataBooking = _userKendaraanDal.GetServisBooking(id);
            if (dataBooking != null)
            {
                MB.Warning("Anda tidak dapat melakukan booking karena kendaraan ini sedang dalam proses servis!");
                return;
            }

            if (new FormBookingUser(_id_kendaraan).ShowDialog() != DialogResult.OK) return;
            LoadData(_id_kendaraan);
        }

        private void KendaraanUC_Load(object? sender, EventArgs e)
        {
            LoadData(_id_kendaraan);
            int locationCenter = (this.Width - panelKendaraan.Width)*2;
        }
    }
}
