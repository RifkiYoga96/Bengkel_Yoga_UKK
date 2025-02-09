using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class ImageDirectory
    {
        public static Image _imageResult;
        public static byte[] _defaultProfile = ImageConvert.ImageToByteArray(ImageConvert.ResizeImageMax(Properties.Resources.defaultProfile, 55, 55));
        public static void FillInTheImage(Image image)
        {
            _imageResult = image;
        }
    }
}
