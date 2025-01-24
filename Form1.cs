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

           
        }


        

    }
}

public class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
}
