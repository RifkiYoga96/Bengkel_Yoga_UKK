using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class RJButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;

        //Properties
        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        //Constructor
        public RJButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }
    }






    public class RJButtonColumn : DataGridViewColumn
    {
        public RJButtonColumn()
        {
            this.CellTemplate = new RJButtonCell(); // Gunakan RJButtonCell sebagai template
        }
    }


    /*public class RJButtonCell : DataGridViewButtonCell
    {
        private int borderSize = 0;
        private int borderRadius = 10;
        private Color borderColor = Color.PaleVioletRed;
        private int margin = 5; // Margin antara tombol dan border cell

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public int Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // Menambahkan margin pada cellBounds agar tombol tidak menempel pada border
            var buttonBounds = new Rectangle(
                cellBounds.X + margin,  // Posisi X dengan margin
                cellBounds.Y + margin,  // Posisi Y dengan margin
                cellBounds.Width - 2 * margin,  // Lebar tombol dengan margin
                cellBounds.Height - 2 * margin // Tinggi tombol dengan margin
            );

            // Menggambar latar belakang dan border tombol
            using (var backBrush = new SolidBrush(Color.MediumSlateBlue))
            using (var textBrush = new SolidBrush(Color.White))
            {
                // Gambar latar belakang tombol
                if (borderRadius > 2) // Tombol dengan sudut melengkung
                {
                    using (var path = GetFigurePath(buttonBounds, borderRadius))
                    {
                        graphics.FillPath(backBrush, path);
                        if (borderSize >= 1)
                        {
                            using (var pen = new Pen(borderColor, borderSize))
                            {
                                graphics.DrawPath(pen, path);
                            }
                        }
                    }
                }
                else // Tombol biasa
                {
                    graphics.FillRectangle(backBrush, buttonBounds);
                    if (borderSize >= 1)
                    {
                        using (var pen = new Pen(borderColor, borderSize))
                        {
                            graphics.DrawRectangle(pen, buttonBounds);
                        }
                    }
                }

                // Gambar teks tombol, memastikan teks berada di tengah tombol
                var text = formattedValue?.ToString() ?? "Aksi";
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                graphics.DrawString(text, cellStyle.Font, textBrush, buttonBounds, format);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }*/

    public class RJButtonCell : DataGridViewButtonCell
    {
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.PaleVioletRed;

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // Aktifkan antialiasing untuk membuat rendering lebih halus
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Warna latar belakang sel
            using (var backBrush = new SolidBrush(cellStyle.BackColor))
            {
                graphics.FillRectangle(backBrush, cellBounds);
            }

            // Tentukan margin untuk tombol
            var buttonRect = new Rectangle(
                cellBounds.X + 5,  // Margin kiri
                cellBounds.Y + 5,  // Margin atas
                cellBounds.Width - 30, // Lebar tombol
                cellBounds.Height - 30 // Tinggi tombol
            );

            // Gambar tombol
            using (var backBrush = new SolidBrush(Color.MediumSlateBlue))
            using (var textBrush = new SolidBrush(Color.White))
            {
                // Tombol dengan sudut melengkung
                if (borderRadius > 2)
                {
                    using (var path = GetFigurePath(buttonRect, borderRadius))
                    {
                        graphics.FillPath(backBrush, path);
                        if (borderSize >= 1)
                        {
                            using (var pen = new Pen(borderColor, borderSize))
                            {
                                graphics.DrawPath(pen, path);
                            }
                        }
                    }
                }
                else // Tombol biasa (kotak)
                {
                    graphics.FillRectangle(backBrush, buttonRect);
                    if (borderSize >= 1)
                    {
                        using (var pen = new Pen(borderColor, borderSize))
                        {
                            graphics.DrawRectangle(pen, buttonRect);
                        }
                    }
                }

                // Gambar teks tombol
                var text = formattedValue?.ToString() ?? "Aksi";
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                graphics.DrawString(text, cellStyle.Font, textBrush, buttonRect, format);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }




    public class HoverButtonCell : DataGridViewButtonCell
    {
        private int buttonMargin = 5; // Margin antara tombol dan border cell
        private bool isHovered = false; // Flag untuk mendeteksi hover

        public int ButtonMargin
        {
            get { return buttonMargin; }
            set { buttonMargin = value; }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // Ukuran tombol kecil, sesuaikan dengan margin
            Rectangle buttonBounds = new Rectangle(
                cellBounds.X + buttonMargin,
                cellBounds.Y + buttonMargin,
                cellBounds.Width - 2 * buttonMargin,
                cellBounds.Height - 2 * buttonMargin
            );

            // Periksa apakah mouse berada di atas tombol
            isHovered = buttonBounds.Contains(Cursor.Position);

            // Gambar latar belakang tombol dengan warna (tergantung hover)
            using (var backBrush = new SolidBrush(isHovered ? Color.LightSkyBlue : Color.LightBlue))
            {
                graphics.FillRectangle(backBrush, buttonBounds);
            }

            // Gambar teks tombol di tengah
            using (var textBrush = new SolidBrush(Color.Black))
            {
                var text = formattedValue?.ToString() ?? "Klik Saya";
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                graphics.DrawString(text, cellStyle.Font, textBrush, buttonBounds, format);
            }

            // Gambar border tombol jika diperlukan
            using (var pen = new Pen(Color.Black, 1))
            {
                graphics.DrawRectangle(pen, buttonBounds);
            }
        }
    }

    public class HoverButtonColumn : DataGridViewColumn
    {
        public HoverButtonColumn()
        {
            this.CellTemplate = new HoverButtonCell();
        }
    }


}
