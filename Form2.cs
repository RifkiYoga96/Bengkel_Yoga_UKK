using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;


namespace Bengkel_Yoga_UKK
{
    public partial class Form2 : SfForm
    {
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _timerMenu2;
        private bool _dashboardExpand = false;
        private bool _layout2Expand = false;
        public Form2()
        {
            InitializeComponent();

            this.Style.TitleBar.BackColor = Color.FromArgb(46, 134, 171);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1;
            _timer.Tick += _timer_Tick;

            _timerMenu2 = new System.Windows.Forms.Timer();
            _timerMenu2.Interval = 1;
            _timerMenu2.Tick += _timerMenu2_Tick;

            InitComponent();
            RegisterEvent();

            //EnableDoubleBuffering(dataGridView1);



            SetupDataGridView();
            LoadData();


        }


        private void RegisterEvent()
        {
            /*btnDashboard.Click += (s, e) => _timer.Start();
            btnHome.Click += (s, e) => _timerMenu2.Start();

            Color colorHover = Color.FromArgb(35, 41, 44);
            Color colorLeave = Color.FromArgb(55, 65, 70);

            btnDashboard.FlatAppearance.MouseDownBackColor = colorHover;
            btnDashboard.FlatAppearance.MouseOverBackColor = colorLeave;

            button2.FlatAppearance.MouseDownBackColor = colorHover;
            button2.FlatAppearance.MouseOverBackColor = colorLeave;

            button3.FlatAppearance.MouseDownBackColor = colorHover;
            button3.FlatAppearance.MouseOverBackColor = colorLeave;

            button5.FlatAppearance.MouseDownBackColor = colorHover;
            button5.FlatAppearance.MouseOverBackColor = colorLeave;*/

            this.Load += Form2_Load1;
        }

        private void Form2_Load1(object? sender, EventArgs e)
        {
            //AddShadowToPanel(panel4);
            //panel3.BackColor = Color.FromArgb(50,Color.Black);
        }

        private void InitComponent()
        {
        }
        private void _timer_Tick(object? sender, EventArgs e)
        {
            /*if (!_dashboardExpand)
            {
                layoutDashboard.Height += 8;
                if (layoutDashboard.Height == layoutDashboard.MaximumSize.Height)
                {
                    _dashboardExpand = true;
                    _timer.Stop();
                }
            }
            else
            {
                layoutDashboard.Height -= 8;
                if (layoutDashboard.Height == layoutDashboard.MinimumSize.Height)
                {
                    _dashboardExpand = false;
                    _timer.Stop();
                }
            }*/
        }
        private void _timerMenu2_Tick(object? sender, EventArgs e)
        {
            /*if (!_layout2Expand)
            {
                layout2.Height += 8;
                if (layout2.Height == layout2.MaximumSize.Height)
                {
                    _layout2Expand = true;
                    _timerMenu2.Stop();
                }
            }
            else
            {
                layout2.Height -= 8;
                if (layout2.Height == layout2.MinimumSize.Height)
                {
                    _layout2Expand = false;
                    _timerMenu2.Stop();
                }
            }*/
        }

        private void SetupDataGridView()
        {

            //dataGridView1.RowTemplate.Height = 30;
        }
        private void AddShadowToPanel(Panel panel)
        {
            Panel shadowPanel = new Panel
            {
                Size = new Size(panel.Width, panel.Height),
                Location = new Point(panel.Left + 5, panel.Top + 5), // Geser untuk efek bayangan
                BackColor = Color.FromArgb(50, Color.Black)         // Warna transparan untuk bayangan
            };

            this.Controls.Add(shadowPanel);
            shadowPanel.SendToBack(); // Pastikan bayangan ada di belakang
            panel.BringToFront();     // Panel utama tetap di depan
        }
        private void LoadData()
        {
            // Membuat data dummy tanpa database
            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" },
                new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" },
                new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed" },
                new Order { OrderID = 3, CustomerName = "Mark Lee", Status = "Shipped" }
            };

            // Menambahkan data ke DataGridView
            /*dataGridView1.DataSource = orders;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Menyembunyikan garis vertikal
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.VirtualMode = true;

            dataGridView1.RowHeadersVisible = false;*/
        }

        // Metode untuk meresize gambar berdasarkan persentase
        private Image ResizeImageWithPercentage(Image img, float percentage)
        {
            // Menghitung ukuran baru berdasarkan persentase
            int newWidth = (int)(img.Width * (percentage / 100));
            int newHeight = (int)(img.Height * (percentage / 100));

            // Meresize gambar
            Bitmap bmp = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }
            return bmp;
        }



        private void EnableDoubleBuffering(DataGridView dgv)
        {
            // Mengakses DoubleBuffered menggunakan refleksi dan mengaktifkannya
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
