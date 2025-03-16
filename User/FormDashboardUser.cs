using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormDashboardUser : Form
    {
        public static FormDashboardUser _formDashboardUser { get; private set; }
        private static Color _active = Color.FromArgb(52, 152, 219);
        private static Color _inActive = Color.FromArgb(44, 62, 80);
        public static RouteDto _route = new RouteDto();

        private readonly PelangganDal _pelangganDal = new PelangganDal();
        public static string _ktp_pelanggan = string.Empty;

        public FormDashboardUser()
        {
            InitializeComponent();
            _formDashboardUser = this;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            GetDataSimulation();
            InitComponent();
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            lblBeranda.Click += (s, e) => ControlTab(1);
            lblServis.Click += (s, e) => ControlTab(2);
            lblTentangKami.Click += (s, e) => ControlTab(5);

            btnBack.Click += (s, e) =>
            {
                FormDashboardUser.InitComponent(_route.sideBar);
                FormDashboardUser.ShowControlInPanel(_route.uc);
            };

            this.FormClosing += (s, e) =>
            {
                Login._loginForm.Close();
            };
        }

        public static void ControlTab(int panel)
        {
            if (FormDashboardUser._formDashboardUser == null || FormDashboardUser._formDashboardUser.panelMain == null) return;

            Panel panelMain = FormDashboardUser._formDashboardUser.panelMain;
            Panel panelBeranda = FormDashboardUser._formDashboardUser.panelBeranda;
            Panel panelServis = FormDashboardUser._formDashboardUser.panelServis;
            Panel panelTentangKami = FormDashboardUser._formDashboardUser.panelTentangKami;
            switch (panel)
            {
                case 1:
                    panelBeranda.BackColor = _active;
                    panelServis.BackColor = _inActive;
                    panelTentangKami.BackColor = _inActive;
                    ShowControlInPanel(new HomeUser());
                    break;
                case 2:
                    panelBeranda.BackColor = _inActive;
                    panelServis.BackColor = _active;
                    panelTentangKami.BackColor = _inActive;
                    ShowControlInPanel(new ServisUC());
                    break;
                case 3:
                    panelBeranda.BackColor = _inActive;
                    panelServis.BackColor = _inActive;
                    panelTentangKami.BackColor = _active;
                    break;
                case 4:
                    panelBeranda.BackColor = _inActive;
                    panelServis.BackColor = _active;
                    panelTentangKami.BackColor = _inActive;
                    break;
                case 5:
                    panelBeranda.BackColor = _inActive;
                    panelServis.BackColor = _inActive;
                    panelTentangKami.BackColor = _active;
                    ShowControlInPanel(new AboutUsUC());
                    break;

            }
        }

        public static void ShowControlInPanel(UserControl control)
        {
            if (control == null) return;
            Panel panelMain = FormDashboardUser._formDashboardUser.panelMain;
            panelMain.SuspendLayout();
            panelMain.Controls.Clear();

            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);

            panelMain.ResumeLayout(true);
        }

        public static void InitComponent(bool sideBar = true)
        {
            FormDashboardUser fds = FormDashboardUser._formDashboardUser;
            if (fds == null || fds.panelMain == null) return;

            Panel panelSide = fds.panelSide2;
            YogaButton btnBack = fds.btnBack;

            if (sideBar)
            {
                btnBack.Visible = false;
                panelSide.Dock = DockStyle.Fill;
                panelSide.Visible = true;
            }
            else
            {
                panelSide.Visible = false;
                panelSide.Dock = DockStyle.None;
                btnBack.Visible = true;
            }
            
        }

        private void yogaButton1_Click(object sender, EventArgs e)
        {

        }

        private void GetDataSimulation()
        {
            ControlTab(1);
            var data = _pelangganDal.GetData(GlobalVariabel._ktp);
            if (data is null) return;
            _ktp_pelanggan = data.ktp_pelanggan;

            MB.Warning(GlobalVariabel._ktp);
        }
    }
}

public class RouteDto
{
    public UserControl uc { get; set; }
    public bool sideBar { get; set; }
}
