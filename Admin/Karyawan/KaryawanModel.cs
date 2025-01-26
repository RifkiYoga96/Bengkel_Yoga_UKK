using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class KaryawanModel
    {
        public int NO { get; set; }
        public int ktp_admin { get; set; }
        public string nama_admin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string no_telp { get; set; }
        public int role { get; set; }
        public string image_name { get; set; }
        public byte[] image_data { get; set; }
    }
}
