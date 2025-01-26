using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using MaterialSkin.Controls;

namespace Bengkel_Yoga_UKK
{
    public class RoundedMaterialCard : MaterialCard
    {
        public int CornerRadius { get; set; } = 10; // Atur radius sudut

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Mengaktifkan anti-aliasing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Membuat path berdasarkan CornerRadius
            GraphicsPath path = new GraphicsPath();
            if (CornerRadius > 0)
            {
                // Jika CornerRadius > 0, buat rounded corners
                path.AddArc(0, 0, CornerRadius * 2, CornerRadius * 2, 180, 90); // Kiri atas
                path.AddArc(Width - CornerRadius * 2, 0, CornerRadius * 2, CornerRadius * 2, 270, 90); // Kanan atas
                path.AddArc(Width - CornerRadius * 2, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 0, 90); // Kanan bawah
                path.AddArc(0, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 90, 90); // Kiri bawah
                path.CloseFigure();
            }
            else
            {
                // Jika CornerRadius = 0, buat rectangle biasa
                path.AddRectangle(new Rectangle(0, 0, Width, Height));
            }

            // Menggambar latar belakang dengan warna yang sesuai
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Menggambar border (opsional)
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
