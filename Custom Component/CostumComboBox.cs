using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class RoundedComboBox : ComboBox
    {
        public int CornerRadius { get; set; } = 10;

        public RoundedComboBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Aktifkan high-quality rendering
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Buat rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = CornerRadius;
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Gambar background
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Gambar border
                using (Pen pen = new Pen(this.ForeColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Gambar teks
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                };
                e.Graphics.DrawString(this.Text, this.Font, brush, new Rectangle(5, 0, this.Width - 20, this.Height), format);
            }

            // Gambar tanda panah dropdown
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.FillPolygon(brush, new Point[]
                {
                new Point(this.Width - 15, this.Height / 2 - 2),
                new Point(this.Width - 10, this.Height / 2 + 3),
                new Point(this.Width - 5, this.Height / 2 - 2)
                });
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index < 0) return;

            // Gambar background item
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Gambar teks item
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, brush, e.Bounds);
            }
        }
    }
}
