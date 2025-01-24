using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Bengkel_Yoga_UKK
{
    public partial class Form3 : Form
    {
        private Dictionary<int,Button> _listButton = new Dictionary<int,Button>();
        private int buttonActiveBefore = 0;
        private int buttonActiveAfter = 1;
        Color active = System.Drawing.Color.FromArgb(255, 150, 50);
        Color over = System.Drawing.Color.FromArgb(46, 134, 171);
        Color hover = System.Drawing.Color.FromArgb(80, 160, 200);

        private Form formShow;
        public Form3()
        {
            InitializeComponent();
            InitComponen();
            RegisterEvent();
            Image originalImage = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Profile (5).png");
            //SetProfilePicture(originalImage, profilePicture);
        }

        private void InitComponen()
        {
            AddButton(1,rjButton1);
            AddButton(2,rjButton2);
            AddButton(3,rjButton3);
            AddButton(4,rjButton4);
            AddButton(5,rjButton5);
            AddButton(6,rjButton6);
            AddButton(7,rjButton7);

            /*rjButton1.FlatAppearance.MouseDownBackColor = active;
            rjButton2.FlatAppearance.MouseDownBackColor = active;
            rjButton3.FlatAppearance.MouseDownBackColor = active;
            rjButton4.FlatAppearance.MouseDownBackColor = active;
            rjButton5.FlatAppearance.MouseDownBackColor = active;
            rjButton6.FlatAppearance.MouseDownBackColor = active;
            rjButton7.FlatAppearance.MouseDownBackColor = active;*/

            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.HorizontalScroll.Enabled = false; // Matikan horizontal scroll bar
            flowLayoutPanel2.HorizontalScroll.Visible = false; // Sembunyikan horizontal scroll bar
            flowLayoutPanel2.VerticalScroll.Enabled = true;    // Aktifkan vertical scroll bar (opsional)
            flowLayoutPanel2.VerticalScroll.Visible = true;    // Tampilkan vertical scroll bar (opsional)
        }
        private void RegisterEvent()
        {
            rjButton1.Click += (s, e) => buttonActiveAfter = 1;
            rjButton1.Click += BtnSideBar_Click;
            rjButton2.Click += (s, e) => buttonActiveAfter = 2;
            rjButton2.Click += BtnSideBar_Click;
            rjButton3.Click += (s, e) => buttonActiveAfter = 3;
            rjButton3.Click += BtnSideBar_Click;
            rjButton4.Click += (s, e) => buttonActiveAfter = 4;
            rjButton4.Click += BtnSideBar_Click;
            rjButton5.Click += (s, e) => buttonActiveAfter = 5;
            rjButton5.Click += BtnSideBar_Click;
            rjButton6.Click += (s, e) => buttonActiveAfter = 6;
            rjButton6.Click += BtnSideBar_Click;
            rjButton7.Click += (s, e) => buttonActiveAfter = 7;
            rjButton7.Click += BtnSideBar_Click;

            panelMain.Resize += PanelMain_Resize;

            rjButton1.Click += (s, e) => ShowFormInPanel2(new Dashboard2());
            rjButton2.Click += (s, e) => ShowFormInPanel2(new Tabel());
            
        }

        private void PanelMain_Resize(object? sender, EventArgs e)
        {
            //var size = panelMain.Size;
            //formShow.Size = new Size(size.Width,size.Height);
        }

        private void AddButton(int key, Button value)
        {
            _listButton.Add(key,value);
        }

        private void BtnSideBar_Click(object? sender, EventArgs e)
        {
            if (_listButton.ContainsKey(buttonActiveAfter) && buttonActiveBefore != buttonActiveAfter)
            {
                var button = _listButton[buttonActiveAfter];
                button.BackColor = active;
                button.FlatAppearance.MouseDownBackColor = active;
                button.FlatAppearance.MouseOverBackColor = active;
                if(buttonActiveBefore != 0)
                {
                    _listButton[buttonActiveBefore].BackColor = over;
                    _listButton[buttonActiveBefore].FlatAppearance.MouseOverBackColor = hover;
                }
                buttonActiveBefore = buttonActiveAfter;
            }
        }



        private void ShowFormInPanel2(Form form)
        {
            if (panelMain.Controls.Count > 0)
                panelMain.Controls.RemoveAt(0);

            if (form == null) return;

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            panelMain.Tag = form;

            panelMain.Controls.Add(form);
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
            formShow.Location = new Point(0,0); // Posisi relatif terhadap panelMain
            formShow.Size = new Size(panelMain.Width,panelMain.Height); // Ukuran Form2

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
