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
            btnClose.Click += (s, e) => Close();
            btnMax.Click +=
                (s, e) => WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;

        }
    }
}

public class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
}
