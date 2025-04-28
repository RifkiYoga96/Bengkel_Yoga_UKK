    using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using Syncfusion.WinForms.Controls;
using System.Globalization;

namespace Bengkel_Yoga_UKK
{
    public partial class MainFormAdmin : SfForm
    {   
        public static MainFormAdmin? _mainForm { get; private set; }
        private static Dictionary<int, Button> _listButton = new Dictionary<int, Button>();
        private static Label _lblDisplay;
        private static int buttonActiveBefore = 0;
        public static int buttonActiveAfter = 1;
        private static Color active = System.Drawing.Color.FromArgb(41, 128, 185);
        private static Color over = System.Drawing.Color.FromArgb(44, 62, 80);
        private static Color hover = System.Drawing.Color.FromArgb(64, 82, 100);
        private bool _isLogout = false;

        public MainFormAdmin()
        {
            InitializeComponent();
            _mainForm = this;
            InitComponen();
            RegisterEvent();
        }

        private void InitComponen()
        {

            AddButton(1, btnDashboard);
            AddButton(2, btnBooking);
            AddButton(3, btnProduk);
            AddButton(4, btnRiwayat);
            AddButton(5, btnService);
            AddButton(6, btnPelanggan);
            AddButton(7, btnKaryawan);
            AddButton(8, btnKalender);

            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.HorizontalScroll.Enabled = false; // Matikan horizontal scroll bar
            flowLayoutPanel2.HorizontalScroll.Visible = false; // Sembunyikan horizontal scroll bar
            flowLayoutPanel2.VerticalScroll.Enabled = true;    // Aktifkan vertical scroll bar (opsional)
            flowLayoutPanel2.VerticalScroll.Visible = true;    // Tampilkan vertical scroll bar (opsional)

            this.Style.ShadowOpacity = 0;
            this.Style.TitleBar.BackColor = Color.FromArgb(52, 152, 219);
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BottomBorderColor = Color.White;
            this.Style.TitleBar.CloseButtonForeColor = Color.White;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.White;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.White;
            this.StyleForm();

            _listButton.Clear();

            //Role Visible Component
            if (GlobalVariabel._role == 1)
            {
                btnKaryawan.Visible = false;
                btnProduk.Visible = false;
                btnService.Visible = false;
            }
            PegawaiLogin();
        }
        private void RegisterEvent()
        {
            List<Button> btnStyle = new List<Button> { btnDashboard, btnBooking, btnProduk, btnRiwayat, btnService, btnPelanggan, btnKaryawan, btnKalender };
            foreach (var item in btnStyle)
            {
                item.FlatAppearance.MouseDownBackColor = active;
                item.FlatAppearance.MouseOverBackColor = hover;
            }

            btnDashboard.Click += (s, e) =>
            {
                NavigateToForm(GlobalVariabel._role == 1 ? new DashboardPetugas() : new DashboardAdmin(), 1);
            };
            btnBooking.Click += (s, e) => NavigateToForm(new FormBooking(), 2);
            btnProduk.Click += (s, e) => NavigateToForm(new FormProduk(), 3);
            btnRiwayat.Click += (s, e) => NavigateToForm(new FormRiwayat(), 4);
            btnService.Click += (s, e) => NavigateToForm(new JasaServisForm(), 5);
            btnPelanggan.Click += (s, e) => NavigateToForm(new FormPelanggan(), 6);
            btnKaryawan.Click += (s, e) => NavigateToForm(new FormKaryawan(), 7);
            btnKalender.Click += (s, e) => NavigateToForm(new FormKalender(), 8);
            btnKendaraan.Click += (s, e) => NavigateToForm(new FormKendaraan(), 9);

            this.FormClosing += MainFormAdmin_FormClosing;
            btnLogout.Click += BtnLogout_Click;

            btnDetailProfile.Click += (s, e) => contextMenuStripEx1.Show(Cursor.Position);
            editToolStripMenuItem.Click += (s, e) => new FormEditProfile(GlobalVariabel._ktp).ShowDialog();

            //this.FormClosed += (s, e) => _mainForm = null;
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            if (!MB.Konfirmasi("Apakah anda yakin ingin logout?")) return;
            _isLogout = true;
            GlobalVariabel._ktp = string.Empty; // hapus session
            FormDashboardUser._formDashboardUser?.Show();
            this.Close();
        }

        private void MainFormAdmin_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isLogout) return;
            if (MB.Konfirmasi("Apakah anda yakin ingin menutup aplikasi ini?"))
                FormDashboardUser._formDashboardUser?.Close();
            else
                e.Cancel = true;
        }

        private void NavigateToForm(Form form, int buttonId)
        {
            buttonActiveAfter = buttonId;
            ShowFormInPanel2(form);
            ControlSideBar();
        }

        private void AddButton(int key, Button value)
        {
            _listButton.Add(key, value);
        }


        public static void ControlSideBar()
        {
            if (MainFormAdmin._mainForm == null) return;

            if (_listButton.ContainsKey(buttonActiveAfter) && buttonActiveBefore != buttonActiveAfter)
            {
                var button = _listButton[buttonActiveAfter];
                button.BackColor = active;
                button.FlatAppearance.MouseDownBackColor = active;
                button.FlatAppearance.MouseOverBackColor = active;
                if (buttonActiveBefore != 0)
                {
                    _listButton[buttonActiveBefore].BackColor = over;
                    _listButton[buttonActiveBefore].FlatAppearance.MouseOverBackColor = hover;
                }
                buttonActiveBefore = buttonActiveAfter;
                MainFormAdmin._mainForm.btnBooking.BackColor = Color.Red;
            }
            string text = "";
            switch (buttonActiveAfter)
            {
                case 1:
                    text = "DASHBOARD";
                    break;
                case 2:
                    text ="BOOKING";
                    break;
                case 3:
                    text = "SPAREPART";
                    break;
                case 4:
                    text = "RIWAYAT";
                    break;
                case 5:
                    text = "SERVIS";
                    break;
                case 6:
                    text = "PELANGGAN";
                    break;
                case 7:
                    text = "PEGAWAI";
                    break;
                case 8:
                    text = "KALENDER";
                    break;
                case 9:
                    text = "KENDARAAN";
                    break;
            }
            _mainForm.lblDisplay.Text = text;
        }


        public static void ShowFormInPanel2(Form form)
        {
            if (MainFormAdmin._mainForm == null || MainFormAdmin._mainForm.panelMain == null)
                return; // Pastikan instance dan panelMain ada

            Panel panelMain = MainFormAdmin._mainForm.panelMain; // Akses panel dari instance FormUtama

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls[0].Dispose();
                panelMain.Controls.Clear(); 
            }

            if (form == null) return;

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            panelMain.Controls.Add(form);
            panelMain.Tag = form;
            form.Show();
        }

        public static void PegawaiLogin()
        {
            MainFormAdmin? main = MainFormAdmin._mainForm;
            if (main is null) return;
            var karyawanDal = new KaryawanDal();
            var data = karyawanDal.GetData(GlobalVariabel._ktp);

            if (main == null || data is null) return;

            RJCircularPictureBox pictureBox = main.pictureBoxProfile;
            Label lblRole = main.lblRole;
            Label lblNamaAdmin = main.lblNamaAdmin;

            //PictureBox
            Image fotoProfile = data.image_data is null ?
                Properties.Resources.defaultProfile
                : ImageConvert.ByteArrayToImage(data.image_data);
            SetProfilePicture(fotoProfile, pictureBox);

            lblRole.Text = data.role == 1 ? "Petugas" : "Super Admin";
            lblNamaAdmin.Text = data.nama_admin;

            //change Auto size label
            lblNamaAdmin.AutoSize = true;
            int maxWidth = 144;
            lblNamaAdmin.AutoSize = lblNamaAdmin.Width > maxWidth ? false : true;
            //lblNamaAdmin.Width = maxWidth;
        }

        public static void SetProfilePicture(Image image, PictureBox pictureBox)
        {
            // Buat bitmap baru dengan ukuran PictureBox
            Bitmap resizedImage = new Bitmap(pictureBox.Width, pictureBox.Height);

            // Gunakan Graphics untuk menggambar gambar asli ke bitmap baru
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Atur InterpolationMode ke HighQualityBicubic
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox.Width, pictureBox.Height);
            }

            // Set gambar yang sudah di-resize ke PictureBox
            pictureBox.Image = resizedImage;
        }
    }
}
