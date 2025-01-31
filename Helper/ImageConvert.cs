using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class ImageConvert
    {
        #region IMAGE
        public static Image ResizeImage(Image image, int maxWidth, int maxHeight)
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


        public static byte[] ImageToByteMaxSize(string imgDirectory, int width, int height)
        {
            Image image = Image.FromFile(imgDirectory);
            Image imageResize = ResizeImage(image, width, height);
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
            // Konversi byte[] menjadi Image
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);

                // Hitung rasio aspek gambar
                double ratioX = (double)maxWidth / image.Width;
                double ratioY = (double)maxHeight / image.Height;
                double ratio = Math.Min(ratioX, ratioY); // Gunakan rasio yang lebih kecil untuk mempertahankan aspek rasio

                // Hitung ukuran baru
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                // Resize gambar
                Image resizedImage = new Bitmap(image, newWidth, newHeight);

                // Konversi gambar yang sudah diresize ke byte[]
                using (MemoryStream resizedStream = new MemoryStream())
                {
                    resizedImage.Save(resizedStream, System.Drawing.Imaging.ImageFormat.Png); // Simpan sebagai PNG atau format lain
                    return resizedStream.ToArray(); // Kembalikan sebagai byte[]
                }
            }
        }

        #endregion
    }
}
