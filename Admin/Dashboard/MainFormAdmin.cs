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
        private Dictionary<int, Button> _listButton = new Dictionary<int, Button>();
        private int buttonActiveBefore = 0;
        private int buttonActiveAfter = 1;
        Color active = System.Drawing.Color.FromArgb(41, 128, 185);
        Color over = System.Drawing.Color.FromArgb(44, 62, 80);
        Color hover = System.Drawing.Color.FromArgb(64, 82, 100);
        public static MainFormAdmin _mainForm { get; private set; }


        private Form formShow;
        public MainFormAdmin()
        {
            InitializeComponent();
            _mainForm = this;
            InitComponen();
            RegisterEvent();
            Image originalImage = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Profile (5).png");
            //SetProfilePicture(originalImage, profilePicture);
        }

        private void InitComponen()
        {
            AddButton(1, btnDashboard);
            AddButton(2, btnBooking);
            AddButton(3, btnProduk);
            AddButton(4, btnInvoice);
            AddButton(5, btnService);
            AddButton(6, btnPelanggan);
            AddButton(7, btnKaryawan);

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
            List<Button> btnStyle = new List<Button> { btnDashboard, btnBooking, btnProduk, btnInvoice, btnService, btnPelanggan, btnKaryawan };
            foreach (var item in btnStyle)
            {
                item.FlatAppearance.MouseDownBackColor = active;
                item.FlatAppearance.MouseOverBackColor = hover;
            }

            btnDashboard.Click += (s, e) => buttonActiveAfter = 1;
            btnDashboard.Click += BtnSideBar_Click;
            btnBooking.Click += (s, e) => buttonActiveAfter = 2;
            btnBooking.Click += BtnSideBar_Click;
            btnProduk.Click += (s, e) => buttonActiveAfter = 3;
            btnProduk.Click += BtnSideBar_Click;
            btnInvoice.Click += (s, e) => buttonActiveAfter = 4;
            btnInvoice.Click += BtnSideBar_Click;
            btnService.Click += (s, e) => buttonActiveAfter = 5;
            btnService.Click += BtnSideBar_Click;
            btnPelanggan.Click += (s, e) => buttonActiveAfter = 6;
            btnPelanggan.Click += BtnSideBar_Click;
            btnKaryawan.Click += (s, e) => buttonActiveAfter = 7;
            btnKaryawan.Click += BtnSideBar_Click;

            btnDashboard.Click += (s, e) => ShowFormInPanel2(new Dashboard2());
            btnProduk.Click += (s, e) => ShowFormInPanel2(new FormProduk());
            btnKaryawan.Click += (s, e) => ShowFormInPanel2(new FormKaryawan());
            btnCalendar.Click += (s, e) => ShowFormInPanel2(new FormBooking());
            btnBooking.Click += (s, e) => ShowFormInPanel2(new DaftarBookingForm());


        }

        private void Form3_Load(object? sender, EventArgs e)
        {

        }

        private void AddButton(int key, Button value)
        {
            _listButton.Add(key, value);
        }

        private void BtnSideBar_Click(object? sender, EventArgs e)
        {
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
        }


       /* public void ShowFormInPanel2(Form form)
        {
            if (panelMain.Controls.Count > 0)
                panelMain.Controls.RemoveAt(0);

            if (form == null) return;

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            panelMain.Tag = form;

            panelMain.Controls.Add(form);
            //form.BringToFront();
            form.Show();
        }*/

        public static void ShowFormInPanel2(Form form)
        {
            if (MainFormAdmin._mainForm == null || MainFormAdmin._mainForm.panelMain == null)
                return; // Pastikan instance dan panelMain ada

            Panel panelMain = MainFormAdmin._mainForm.panelMain; // Akses panel dari instance FormUtama

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls[0].Dispose(); // Hapus form lama dari memory
                panelMain.Controls.Clear(); // Bersihkan semua controls di panel
            }

            if (form == null) return;

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            panelMain.Controls.Add(form);
            panelMain.Tag = form;
            form.Show();
        }


        // Method untuk menampilkan Form2 di atas Panel
        private void ShowFormOverPanel()
        {
            formShow = new DashboardForm();

            // Atur Form2 agar tidak ditampilkan sebagai jendela terpisah
            formShow.TopLevel = false;

            // Atur Parent dari Form2 ke panelMain
            formShow.Parent = panelMain;

            // Atur ukuran dan posisi Form2 di dalam panelMain
            formShow.Location = new Point(0, 0); // Posisi relatif terhadap panelMain
            formShow.Size = new Size(panelMain.Width, panelMain.Height); // Ukuran Form2

            // Tampilkan Form2
            formShow.Show();
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
