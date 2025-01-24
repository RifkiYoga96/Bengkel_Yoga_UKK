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
    [ToolboxBitmap(typeof(ComboBox))]
    [Description("Displays an editable text box and a drop-down list of permitted values.")]
    public class MComboBox : ComboBox
    {
        // Fields
        private Color _hoverBackColor = Color.LightGray; // Warna background saat dihover
        private Color _hoverForeColor = Color.Black; // Warna teks saat dihover
        private int _hoveredIndex = -1; // Index item yang sedang dihover

        // Constructor
        public MComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed; // Aktifkan custom drawing
            this.DropDownHeight = 200; // Atur tinggi dropdown
            this.ItemHeight = 25; // Atur tinggi item

            // Handle event DrawItem
            this.DrawItem += MComboBox_DrawItem;

            // Handle event MouseMove
            this.MouseMove += MComboBox_MouseMove;

            // Handle event DropDownClosed
            this.DropDownClosed += MComboBox_DropDownClosed;
        }

        // Properti untuk warna hover
        [Category("MControl")]
        public Color HoverBackColor
        {
            get { return _hoverBackColor; }
            set
            {
                _hoverBackColor = value;
                Invalidate();
            }
        }

        [Category("MControl")]
        public Color HoverForeColor
        {
            get { return _hoverForeColor; }
            set
            {
                _hoverForeColor = value;
                Invalidate();
            }
        }

        // Event Handlers
        private void MComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Tentukan warna background dan teks berdasarkan apakah item dipilih atau dihover
            Brush backBrush;
            Brush foreBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backBrush = new SolidBrush(SystemColors.Highlight); // Warna saat item dipilih
                foreBrush = new SolidBrush(SystemColors.HighlightText); // Warna teks saat item dipilih
            }
            else if (e.Index == _hoveredIndex)
            {
                backBrush = new SolidBrush(_hoverBackColor); // Warna background saat dihover
                foreBrush = new SolidBrush(_hoverForeColor); // Warna teks saat dihover
            }
            else
            {
                backBrush = new SolidBrush(this.BackColor); // Warna background default
                foreBrush = new SolidBrush(this.ForeColor); // Warna teks default
            }

            // Gambar background
            e.Graphics.FillRectangle(backBrush, e.Bounds);

            // Gambar teks
            string itemText = this.Items[e.Index].ToString();
            e.Graphics.DrawString(itemText, this.Font, foreBrush, e.Bounds, StringFormat.GenericDefault);

            // Bersihkan brush
            backBrush.Dispose();
            foreBrush.Dispose();
        }

        private void MComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.DroppedDown) return; // Hanya proses jika dropdown terbuka

            // Hitung index item yang sedang dihover
            int newHoveredIndex = e.Location.Y / this.ItemHeight;

            // Pastikan index berada dalam rentang yang valid
            if (newHoveredIndex >= 0 && newHoveredIndex < this.Items.Count)
            {
                if (newHoveredIndex != _hoveredIndex)
                {
                    _hoveredIndex = newHoveredIndex;
                    this.Invalidate(); // Memaksa kontrol untuk menggambar ulang
                }
            }
            else
            {
                if (_hoveredIndex != -1)
                {
                    _hoveredIndex = -1;
                    this.Invalidate(); // Memaksa kontrol untuk menggambar ulang
                }
            }
        }

        private void MComboBox_DropDownClosed(object sender, EventArgs e)
        {
            _hoveredIndex = -1; // Reset hovered index
            this.Invalidate(); // Memaksa kontrol untuk menggambar ulang
        }
    }

    public class CustomForm : Form
    {
        public CustomForm()
        {
            this.Text = "Custom Header Form";
            this.FormBorderStyle = FormBorderStyle.None; // Nonaktifkan border standar
            this.BackColor = Color.Blue; // Warna latar belakang form
            this.Paint += CustomForm_Paint; // Tangani event Paint
        }

        private void CustomForm_Paint(object sender, PaintEventArgs e)
        {
            // Gambar header secara manual
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, 30)); // Header dengan tinggi 30 piksel
            }

            // Gambar teks judul
            using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.DrawString(this.Text, font, Brushes.White, new PointF(10, 5));
            }
        }
    }
}
