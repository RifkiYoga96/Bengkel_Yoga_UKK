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
    public partial class Form3 : SfForm
    {
        /*//Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Fields
        private int borderSize = 2;
        private Size formSize;*/
        
        private Dictionary<int, Button> _listButton = new Dictionary<int, Button>();
        private int buttonActiveBefore = 0;
        private int buttonActiveAfter = 1;
        Color active = System.Drawing.Color.FromArgb(41, 128, 185);
        //Color over = System.Drawing.Color.Transparent;
        Color over = System.Drawing.Color.FromArgb(44, 62, 80);
        Color hover = System.Drawing.Color.FromArgb(64, 82, 100);

       /* private bool isDragging = false;
        private Point startPoint = new Point(0, 0);*/

        private Form formShow;
        public Form3()
        {
            InitializeComponent();
            InitComponen();
            RegisterEvent();
            Image originalImage = Image.FromFile(@"D:\APenyimpanan\BENGKEL - UKK\Profile (5).png");
            //SetProfilePicture(originalImage, profilePicture);
        }
        //Overridden methods
        /*protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }*/
        private void InitComponen()
        {
            AddButton(1, btnDashboard);
            AddButton(2, btnBooking);
            AddButton(3, btnProduk);
            AddButton(4, btnInvoice);
            AddButton(5, btnService);
            AddButton(6, btnPelanggan);
            AddButton(7, btnKaryawan);

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
            foreach(var item in btnStyle)
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

            panelMain.Resize += PanelMain_Resize;

            btnDashboard.Click += (s, e) => ShowFormInPanel2(new Dashboard2());
            btnProduk.Click += (s, e) => ShowFormInPanel2(new FormProduk());

        }

        private void Form3_Load(object? sender, EventArgs e)
        {

        }

        /*private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(newPoint.X - startPoint.X, newPoint.Y - startPoint.Y);
            }
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }*/


        private void PanelMain_Resize(object? sender, EventArgs e)
        {
            //var size = panelMain.Size;
            //formShow.Size = new Size(size.Width,size.Height);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
