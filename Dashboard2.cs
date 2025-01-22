using Syncfusion.Windows.Forms.Chart;
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

namespace Bengkel_Yoga_UKK
{
    public partial class Dashboard2 : Form
    {
        public Dashboard2()
        {
            InitializeComponent();
            this.Load += Dashboard2_Load;
            RegisterEvent();
            ChartControlStyle();
        }

        private void RegisterEvent()
        {
            yogaPanel1.Resize += (s, e) => yogaPanel1.Invalidate();
            yogaPanel2.Resize += (s, e) => yogaPanel2.Invalidate();
            yogaPanel3.Resize += (s, e) => yogaPanel3.Invalidate();
            yogaPanel4.Resize += (s, e) => yogaPanel4.Invalidate();
            yogaPanel5.Resize += (s, e) => yogaPanel5.Invalidate();
        }

        private void ChartControlStyle()
        {
           //Line
           chartControl1 = new ChartControl();
        }

        private void Dashboard2_Load(object? sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

public static class PanelUtility
{
    // Fungsi untuk menerapkan corner radius ke panel berdasarkan nama
    public static void ApplyCornerRadiusByName(Control parentControl, string namaPanel, int cornerRadius)
    {
        // Cari panel berdasarkan nama
        Control[] controls = parentControl.Controls.Find(namaPanel, true);

        // Jika panel ditemukan
        if (controls.Length > 0 && controls[0] is Panel panel)
        {
            // Pastikan panel memiliki ukuran yang valid
            if (panel.Width <= 0 || panel.Height <= 0)
            {
                MessageBox.Show($"Ukuran panel '{namaPanel}' tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pastikan corner radius tidak negatif
            if (cornerRadius < 0)
            {
                MessageBox.Show($"Corner radius tidak boleh negatif.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pastikan corner radius tidak melebihi ukuran panel
            int maxRadius = Math.Min(panel.Width, panel.Height) / 2;
            if (cornerRadius > maxRadius)
            {
                cornerRadius = maxRadius;
            }

            // Buat GraphicsPath untuk rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                try
                {
                    // Buat rounded rectangle
                    path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Kiri atas
                    path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Kanan atas
                    path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Kanan bawah
                    path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Kiri bawah
                    path.CloseFigure();

                    // Set region panel sesuai dengan rounded rectangle
                    panel.Region = new Region(path);

                    // Handle event Paint untuk menggambar background dan border
                    panel.Paint += (sender, e) =>
                    {
                        // Gambar background panel
                        using (SolidBrush brush = new SolidBrush(panel.BackColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        // Gambar border panel (opsional)
                        using (Pen pen = new Pen(panel.ForeColor, 1))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat membuat rounded corners: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show($"Panel dengan nama '{namaPanel}' tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
