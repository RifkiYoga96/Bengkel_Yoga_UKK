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
        public static void SetKTPSession(string ktp)
        {
            _ktp = ktp;
        }
    }
}
