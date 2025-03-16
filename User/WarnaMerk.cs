using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class WarnaMerk
    {
        public static Dictionary<string, Color> MotorColors = new Dictionary<string, Color>
        {
            { "honda", Color.FromArgb(218, 41, 28) },
            { "yamaha", Color.FromArgb(15, 76, 129) },
            { "kawasaki", Color.FromArgb(119, 192, 67) },
            { "suzuki", Color.FromArgb(0, 61, 165) },
            { "ducati", Color.FromArgb(204, 0, 0) },
            { "ktm", Color.FromArgb(240, 101, 35) }
        };

        public static Dictionary<string, Color> MobilColors = new Dictionary<string, Color>
        {
            { "toyota", Color.FromArgb(235, 10, 30) },
            { "nissan", Color.FromArgb(195, 0, 47) },
            { "mitsubishi", Color.FromArgb(230, 0, 18) },
            { "mazda", Color.FromArgb(166, 25, 46) },
            { "ford", Color.FromArgb(0, 39, 76) },
            { "tesla", Color.FromArgb(204, 0, 0) }
        };

        public static Color GetWarnaMerek(string merek)
        {
            if (MotorColors.ContainsKey(merek))
                return MotorColors[merek];
            if (MobilColors.ContainsKey(merek))
                return MobilColors[merek];

            return Color.Gray; // Default jika tidak ditemukan
        }
    }
}
