using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class ImageConvert
    {
        #region IMAGE
        public static Image ResizeImageMax(Image image, int maxWidth, int maxHeight)
        {
            // Hitung rasio aspek gambar
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY); // Gunakan rasio yang lebih kecil untuk mempertahankan aspek rasio

            // Hitung ukuran baru
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Buat gambar baru dengan ukuran yang diubah
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Kualitas tinggi
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public static Image ResizeImagePersentase(Image image, int persentase)
        {
            double persen = (double)persentase / 100;
            // Hitung rasio aspek gambar
            double ratioX = image.Width * persen;
            double ratioY = image.Height * persen;

            // Hitung ukuran baru
            int newWidth = (int)Math.Round(ratioX);
            int newHeight = (int)Math.Round(ratioY);

            // Buat gambar baru dengan ukuran yang diubah
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Kualitas tinggi
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image Image_ByteToImage(byte[] image_data)
        {
            using MemoryStream ms = new MemoryStream(image_data);
            return Image.FromStream(ms);
        }


        public static byte[] ImageToByteMaxSize(string imgDirectory, int width, int height)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImageMax(image, width, height);
            byte[] byteimg = ImageToByteArray(imageResize);
            return byteimg;
        }
        public static byte[] ImageToBytePercent(string imgDirectory, int percent)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImagePersentase(image, percent);
            return ImageToByteArray(imageResize);
        }


        public static byte[] ResizeImageBytes(byte[] imageBytes, int maxWidth, int maxHeight)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);

                double ratioX = (double)maxWidth / image.Width;
                double ratioY = (double)maxHeight / image.Height;
                double ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                Image resizedImage = new Bitmap(image, newWidth, newHeight);

                using (MemoryStream resizedStream = new MemoryStream())
                {
                    resizedImage.Save(resizedStream, System.Drawing.Imaging.ImageFormat.Png);
                    return resizedStream.ToArray();
                }
            }
        }

        #endregion

        #region IMAGE CIRCLE
        public static Image CropToCircle(Image srcImage)
        {
            int size = Math.Min(srcImage.Width, srcImage.Height);
            Bitmap bmp = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.Clear(Color.Transparent);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(1, 1, size - 2, size - 2); // Beri margin kecil untuk menghindari tepi lurus
                    g.SetClip(path);

                    // Hitung posisi cropping agar lebih presisi
                    int xOffset = (srcImage.Width - size) / 2;
                    int yOffset = (srcImage.Height - size) / 2;

                    g.DrawImage(srcImage, new Rectangle(0, 0, size, size), new Rectangle(xOffset, yOffset, size, size), GraphicsUnit.Pixel);
                }
            }

            return bmp;
        }


        public static Image SmoothImagePictureBox(Image image, int width, int height)
        {
            // Buat bitmap baru dengan ukuran PictureBox
            Bitmap resizedImage = new Bitmap(width, height);

            // Gunakan Graphics untuk menggambar gambar asli ke bitmap baru
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Atur InterpolationMode ke HighQualityBicubic
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }

            // Set gambar yang sudah di-resize ke PictureBox
            return resizedImage;
        }


        #endregion
    }
}
