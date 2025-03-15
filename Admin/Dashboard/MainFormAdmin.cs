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

namespace Bengkel_Yoga_UKK      
{
    public partial class MainFormAdmin : SfForm
    {   
        public static MainFormAdmin _mainForm { get; private set; }
        private static Dictionary<int, Button> _listButton = new Dictionary<int, Button>();
        private static Label _lblDisplay;
        private static int buttonActiveBefore = 0;
        public static int buttonActiveAfter = 1;
        private static Color active = System.Drawing.Color.FromArgb(41, 128, 185);
        private static Color over = System.Drawing.Color.FromArgb(44, 62, 80);
        private static Color hover = System.Drawing.Color.FromArgb(64, 82, 100);

        public MainFormAdmin()
        {
            InitializeComponent();
            _mainForm = this;
            InitComponen();
            RegisterEvent();
            Image originalImage = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Profile (5).png");
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
        }
        private void RegisterEvent()
        {
            List<Button> btnStyle = new List<Button> { btnDashboard, btnBooking, btnProduk, btnRiwayat, btnService, btnPelanggan, btnKaryawan, btnKalender };
            foreach (var item in btnStyle)
            {
                item.FlatAppearance.MouseDownBackColor = active;
                item.FlatAppearance.MouseOverBackColor = hover;
            }

            btnDashboard.Click += (s, e) => NavigateToForm(new Dashboard2(), 1);
            btnBooking.Click += (s, e) => NavigateToForm(new FormBooking(), 2);
            btnProduk.Click += (s, e) => NavigateToForm(new FormProduk(), 3);
            btnRiwayat.Click += (s, e) => NavigateToForm(new FormRiwayat(), 4);
            btnService.Click += (s, e) => NavigateToForm(new JasaServisForm(), 5);
            btnPelanggan.Click += (s, e) => NavigateToForm(new FormPelanggan(), 6);
            btnKaryawan.Click += (s, e) => NavigateToForm(new FormKaryawan(), 7);
            btnKalender.Click += (s, e) => NavigateToForm(new FormKalender(), 8);

            this.FormClosing += (s, e) =>
            {
                if (MB.Konfirmasi("Apakah anda yakin ingin menutup aplikasi ini?"))
                    Login._loginForm.Close();
                else
                    e.Cancel = true;
            };
        }

        private void NavigateToForm(Form form, int buttonId)
        {
            buttonActiveAfter = buttonId;
            ShowFormInPanel2(form);
            ControlSideBar();
        }

        private bool FormKhusus()
        {
            Control[] existingControls = panelMain.Controls.Cast<Control>().ToArray();

            foreach (var control in existingControls)
            {
                if (control is Form specificForm && specificForm.Name == "FormDetailBooking")
                {
                    if (!MB.Konfirmasi("Apakah anda ingin menutup bagian ini tanpa menyimpan perubahan?")) return true;
                }
            }
            return false;
        }


        private void AddButton(int key, Button value)
        {
            _listButton.Add(key, value);
        }

        private void BtnSideBar_Click(object? sender, EventArgs e)
        {
            ControlSideBar();
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


        private void SetProfilePicture(Image image, PictureBox pictureBox)
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
