using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class ImageCropTest : Form
    {

        private int maxPictureBoxWidth = 800;
        private int maxPictureBoxHeight = 600;
        private Image originalImage;
        private Rectangle cropRect;
        private bool isDragging = false;
        private bool isResizing = false;
        private Point startPoint;
        private int resizeHandleSize = 5; // Ukuran handle resize
        private string activeResizeHandle = "";
        private int maxCropSize = 200;
        public ImageCropTest(Image image)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;



            originalImage = image;
            InitPicture();

            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                this.Close();
            };

            this.DoubleBuffered = true;

        }

        private void InitPicture()
        {
            originalImage = ImageConvert.ResizeImageMax(originalImage, pictureBox1.Width, pictureBox1.Height);
            AdjustPictureBoxSize();
            int size = (Math.Min(pictureBox1.Width, pictureBox1.Height)) - 2;
            maxCropSize = size;
            cropRect = new Rectangle((pictureBox1.Width - size) / 2, (pictureBox1.Height - size) / 2, size, size);

            pictureBox1.BackgroundImage = originalImage;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Invalidate();
        }


        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (originalImage == null || cropRect.Width == 0 || cropRect.Height == 0) return;

            // Validasi ukuran crop area
            if (cropRect.Width > maxCropSize || cropRect.Height > maxCropSize)
            {
                MessageBox.Show("Ukuran crop area melebihi batas maksimum yang diizinkan.");
                return;
            }

            Point offset = GetImageOffset(); // Hitung offset gambar

            // Sesuaikan koordinat cropRect dengan offset gambar
            Rectangle adjustedCropRect = new Rectangle(cropRect.X + offset.X, cropRect.Y + offset.Y, cropRect.Width, cropRect.Height);

            Bitmap croppedImage = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, new Rectangle(0, 0, cropRect.Width, cropRect.Height), adjustedCropRect, GraphicsUnit.Pixel);
            }

            Image bunder = ImageConvert.CropToCircle(croppedImage);
            ImageDirectory.FillInTheImage(bunder);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private Point GetImageOffset()
        {
            if (pictureBox1.BackgroundImage == null)
                return Point.Empty;

            int offsetX = (pictureBox1.Width - pictureBox1.BackgroundImage.Width) / 2;
            int offsetY = (pictureBox1.Height - pictureBox1.BackgroundImage.Height) / 2;

            return new Point(offsetX, offsetY);
        }


        private void pictureBox1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (originalImage == null) return;

            Point offset = GetImageOffset(); // Hitung offset gambar
            Point adjustedLocation = new Point(e.X - offset.X, e.Y - offset.Y); // Sesuaikan lokasi mouse dengan offset gambar

            activeResizeHandle = GetResizeHandle(adjustedLocation);
            if (!string.IsNullOrEmpty(activeResizeHandle))
            {
                isResizing = true;
            }
            else if (cropRect.Contains(adjustedLocation))
            {
                isDragging = true;
                startPoint = adjustedLocation;
            }
        }

        private void pictureBox1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (originalImage == null) return;

            Point offset = GetImageOffset(); // Hitung offset gambar
            Point adjustedLocation = new Point(e.X - offset.X, e.Y - offset.Y); // Sesuaikan lokasi mouse dengan offset gambar

            string handle = GetResizeHandle(adjustedLocation);
            if (handle == "top-left" || handle == "bottom-right")
                pictureBox1.Cursor = Cursors.SizeNWSE;
            else if (handle == "top-right" || handle == "bottom-left")
                pictureBox1.Cursor = Cursors.SizeNESW;
            else if (handle == "left" || handle == "right")
                pictureBox1.Cursor = Cursors.SizeWE;
            else if (handle == "top" || handle == "bottom")
                pictureBox1.Cursor = Cursors.SizeNS;
            else if (cropRect.Contains(adjustedLocation))
                pictureBox1.Cursor = Cursors.Hand;
            else
                pictureBox1.Cursor = Cursors.Default;

            if (isResizing)
            {
                ResizeCropArea(adjustedLocation);
            }
            else if (isDragging)
            {
                MoveCropArea(adjustedLocation);
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object? sender, MouseEventArgs e)
        {
            isDragging = false;
            isResizing = false;
        }

        private void pictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            Point offset = GetImageOffset(); // Hitung offset gambar

            using (Pen pen = new Pen(Color.LightGray, 2))
            {
                // Sesuaikan koordinat cropRect dengan offset gambar
                e.Graphics.DrawRectangle(pen, new Rectangle(cropRect.X + offset.X, cropRect.Y + offset.Y, cropRect.Width, cropRect.Height));
            }

            using (Brush brush = new SolidBrush(Color.White))
            {
                // Sesuaikan koordinat handle resize dengan offset gambar
                e.Graphics.FillRectangle(brush, new Rectangle(cropRect.Left - resizeHandleSize / 2 + offset.X, cropRect.Top - resizeHandleSize / 2 + offset.Y, resizeHandleSize, resizeHandleSize));
                e.Graphics.FillRectangle(brush, new Rectangle(cropRect.Right - resizeHandleSize / 2 + offset.X, cropRect.Top - resizeHandleSize / 2 + offset.Y, resizeHandleSize, resizeHandleSize));
                e.Graphics.FillRectangle(brush, new Rectangle(cropRect.Left - resizeHandleSize / 2 + offset.X, cropRect.Bottom - resizeHandleSize / 2 + offset.Y, resizeHandleSize, resizeHandleSize));
                e.Graphics.FillRectangle(brush, new Rectangle(cropRect.Right - resizeHandleSize / 2 + offset.X, cropRect.Bottom - resizeHandleSize / 2 + offset.Y, resizeHandleSize, resizeHandleSize));
            }
        }



        private string GetResizeHandle(Point location)
        {
            Point offset = GetImageOffset(); // Hitung offset gambar
            Point adjustedLocation = new Point(location.X - offset.X, location.Y - offset.Y); // Sesuaikan lokasi mouse dengan offset gambar

            if (new Rectangle(cropRect.Left - resizeHandleSize / 2, cropRect.Top - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize).Contains(adjustedLocation))
                return "top-left";
            if (new Rectangle(cropRect.Right - resizeHandleSize / 2, cropRect.Top - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize).Contains(adjustedLocation))
                return "top-right";
            if (new Rectangle(cropRect.Left - resizeHandleSize / 2, cropRect.Bottom - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize).Contains(adjustedLocation))
                return "bottom-left";
            if (new Rectangle(cropRect.Right - resizeHandleSize / 2, cropRect.Bottom - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize).Contains(adjustedLocation))
                return "bottom-right";

            return "";
        }

        private void ResizeCropArea(Point location)
        {
            Point offset = GetImageOffset(); // Hitung offset gambar
            location = new Point(location.X - offset.X, location.Y - offset.Y); // Sesuaikan lokasi mouse dengan offset gambar

            int minSize = 20; // Ukuran minimum crop area
            int maxWidth = pictureBox1.BackgroundImage.Width; // Lebar maksimum = lebar gambar
            int maxHeight = pictureBox1.BackgroundImage.Height; // Tinggi maksimum = tinggi gambar

            if (activeResizeHandle == "bottom-right")
            {
                int newSize = Math.Max(location.X - cropRect.Left, location.Y - cropRect.Top);
                newSize = Math.Min(newSize, maxWidth - cropRect.Left - 2); // Cegah melebihi lebar gambar
                newSize = Math.Min(newSize, maxHeight - cropRect.Top); // Cegah melebihi tinggi gambar
                newSize = Math.Min(newSize, maxCropSize); // Cegah melebihi panjang sisi maksimum
                cropRect.Width = cropRect.Height = Math.Max(newSize, minSize);
            }
            else if (activeResizeHandle == "top-left")
            {
                int newSize = Math.Max(cropRect.Right - location.X, cropRect.Bottom - location.Y);
                newSize = Math.Min(newSize, cropRect.Right);
                newSize = Math.Min(newSize, cropRect.Bottom);
                newSize = Math.Min(newSize, maxCropSize); // Cegah melebihi panjang sisi maksimum
                cropRect = new Rectangle(cropRect.Right - newSize, cropRect.Bottom - newSize, newSize, newSize);
            }
        }

        private void MoveCropArea(Point location)
        {
            Point offset = GetImageOffset(); // Hitung offset gambar
            location = new Point(location.X - offset.X, location.Y - offset.Y); // Sesuaikan lokasi mouse dengan offset gambar

            int dx = location.X - startPoint.X;
            int dy = location.Y - startPoint.Y;

            int newX = cropRect.Left + dx;
            int newY = cropRect.Top + dy;

            // Batasi pergerakan cropRect agar tidak keluar dari gambar
            if (newX < 0) newX = 0;
            if (newY < 0) newY = 0;
            if (newX + cropRect.Width > pictureBox1.BackgroundImage.Width)
                newX = pictureBox1.BackgroundImage.Width - cropRect.Width - 2; // Batasi agar tidak melebihi batas kanan
            if (newY + cropRect.Height > pictureBox1.BackgroundImage.Height)
                newY = pictureBox1.BackgroundImage.Height - cropRect.Height; // Batasi agar tidak melebihi batas bawah

            // Pastikan ukuran crop area tidak melebihi panjang sisi maksimum
            if (cropRect.Width > maxCropSize)
            {
                cropRect.Width = maxCropSize;
                newX = Math.Min(newX, pictureBox1.BackgroundImage.Width - maxCropSize);
            }
            if (cropRect.Height > maxCropSize)
            {
                cropRect.Height = maxCropSize;
                newY = Math.Min(newY, pictureBox1.BackgroundImage.Height - maxCropSize);
            }

            cropRect.Location = new Point(newX, newY);
            startPoint = location;
        }

        private void AdjustPictureBoxSize()
        {
            if (originalImage == null) return;

            // Hitung rasio gambar
            double imageRatio = (double)originalImage.Width / originalImage.Height;
            double pictureBoxRatio = (double)pictureBox1.Width / pictureBox1.Height;

            // Sesuaikan ukuran PictureBox berdasarkan rasio gambar
            if (imageRatio > pictureBoxRatio)
            {
                // Gambar lebih lebar dari PictureBox
                pictureBox1.Height = (int)(originalImage.Height);
            }
            else
            {
                // Gambar lebih tinggi dari PictureBox
                pictureBox1.Width = (int)(originalImage.Width);
            }

            // Atur PictureBox ke tengah form atau parent container
            pictureBox1.Anchor = AnchorStyles.None; // Non-aktifkan anchor
            pictureBox1.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
        }

        public static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            double ratio = Math.Min((double)maxWidth / image.Width, (double)maxHeight / image.Height);
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}



