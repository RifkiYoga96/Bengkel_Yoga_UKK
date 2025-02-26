using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class JadwalLiburModel
    {
        public int id_jadwal_libur {  get; set; }
        public DateTime? tanggal {  get; set; }
        public string? hari {  get; set; }
    }

    public class JadwalLiburDto
    {
        public int id_jadwal_libur { get; set; }
        public int No {  get; set; }
        public string Libur {  get; set; }
    }
}
