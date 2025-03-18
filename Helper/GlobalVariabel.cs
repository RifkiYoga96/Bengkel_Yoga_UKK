using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class GlobalVariabel
    {
        public static string _ktp = string.Empty;
        public static string _ktp_pelanggan = string.Empty;
        public static int _role = 0;
        public static int _antrean = 0;
        public static void SetSession(string ktp, int role = 0)
        {
            _ktp = ktp;
            _role = role;
        }
        public static void SetKTPPelanggan(string ktp)
        {
            _ktp_pelanggan = ktp;
        }

        public static void SetAntrean(int antrean)
        {
            _antrean = antrean;
        }
    }
}
