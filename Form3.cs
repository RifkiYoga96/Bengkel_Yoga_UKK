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
    public partial class Form3 : Form
    {
        private System.Windows.Forms.Timer timer;
        private float angle = 0f; // Sudut rotasi
        private Image buttonImage;

        public Form3()
        {
            InitializeComponent();

            // Load gambar
            buttonImage = Image.FromFile("D:\\Frame 44.png"); // Ganti path sesuai gambar Anda

            // Tambahkan Button
            Button rotatingButton = new Button
            {
                Size = new Size(100, 100),
                Location = new Point(100, 100),
            };
            rotatingButton.Paint += RotatingButton_Paint; // Event untuk menggambar ulang gambar
            this.Controls.Add(rotatingButton);

            // Setup Timer
            timer = new System.Windows.Forms.Timer
            {
                Interval = 50 // Kecepatan animasi (ms)
            };
            timer.Tick += (s, e) =>
            {
                angle += 5f; // Tingkat rotasi (derajat)
                if (angle >= 360f) angle = 0f; // Reset sudut setelah 1 putaran
                rotatingButton.Invalidate(); // Refresh button
            };
            timer.Start();
        }

        private void RotatingButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || buttonImage == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Tentukan pusat rotasi
            PointF center = new PointF(btn.Width / 2f, btn.Height / 2f);

            // Terapkan transformasi rotasi
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-center.X, -center.Y);

            // Gambar ulang gambar
            Rectangle rect = new Rectangle((btn.Width - buttonImage.Width) / 2, (btn.Height - buttonImage.Height) / 2,
                                            buttonImage.Width, buttonImage.Height);
            g.DrawImage(buttonImage, rect);

            // Reset transformasi
            g.ResetTransform();
        }
    }
}
