namespace Bengkel_Yoga_UKK
{
    public partial class Dashboardd : Form
    {
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _timerMenu2;
        private bool _dashboardExpand = false;
        private bool _layout2Expand = false;
        public Dashboardd()
        {
            InitializeComponent();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1;
            _timer.Tick += _timer_Tick;

            _timerMenu2 = new System.Windows.Forms.Timer();
            _timerMenu2.Interval = 1;
            _timerMenu2.Tick += _timer_Tick;

            InitComponent();
            RegisterEvent();

            EnableDoubleBuffering(dataGridView1);



            SetupDataGridView();
            LoadData();
        }


        private void RegisterEvent()
        {
            btnDashboard.Click += BtnDashboard_Click;

            Color colorHover = Color.FromArgb(35, 41, 44);
            Color colorLeave = Color.FromArgb(55, 65, 70);

            btnDashboard.FlatAppearance.MouseDownBackColor = colorHover;
            btnDashboard.FlatAppearance.MouseOverBackColor = colorLeave;

            button2.FlatAppearance.MouseDownBackColor = colorHover;
            button2.FlatAppearance.MouseOverBackColor = colorLeave;

            button3.FlatAppearance.MouseDownBackColor = colorHover;
            button3.FlatAppearance.MouseOverBackColor = colorLeave;

            button5.FlatAppearance.MouseDownBackColor = colorHover;
            button5.FlatAppearance.MouseOverBackColor = colorLeave;

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }


        private void InitComponent()
        {
        }

        private void BtnDashboard_Click(object? sender, EventArgs e)
        {
            _timer.Start();
        }
        private void _timer_Tick(object? sender, EventArgs e)
        {
            if (!_dashboardExpand)
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
            }
        }








        private void SetupDataGridView()
        {
            // Menambahkan kolom gambar untuk status
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Status";
            imageColumn.Name = "StatusColumn";
            dataGridView1.Columns.Add(imageColumn);

            // Menambahkan kolom teks untuk data
            dataGridView1.Columns.Add("OrderID", "Order ID");
            dataGridView1.Columns.Add("CustomerName", "Customer Name");

            // Menyesuaikan ukuran kolom gambar
            imageColumn.Width = 100;
            dataGridView1.RowTemplate.Height = 30;
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
            dataGridView1.DataSource = orders;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Menyembunyikan garis vertikal
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.VirtualMode = true;
        }
        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Menentukan gambar berdasarkan status
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["StatusColumn"].Index)
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                // Menampilkan gambar berdasarkan status
                if (status == "Pending")
                {
                    e.Value = ResizeImageWithPercentage(Properties.Resources.BelumBayar, 50); // Gambar untuk status Pending, 50% ukuran asli
                }
                else if (status == "Completed")
                {
                    e.Value = ResizeImageWithPercentage(Properties.Resources.Selesai, 30); // Gambar untuk status Completed, 30% ukuran asli
                }
                else if (status == "Shipped")
                {
                    e.Value = ResizeImageWithPercentage(Properties.Resources.Antre, 40); // Gambar untuk status Shipped, 40% ukuran asli
                }
            }
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

    }
}

public class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
}
