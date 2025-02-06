using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class BookingModel
    {
        public int No {  get; set; }
        public int id_booking {  get; set; }
        public string ktp_pelanggan { get; set; }
        public string nama_pelanggan { get; set;}

        public string no_pol {  get; set; }
        public string merk {  get; set; }
        public string tipe {  get; set; }
        public int kapasitas {  get; set; }
        public string tahun {  get; set; }
        public string nama_kendaraan { get; set; }

        public DateTime tanggal {  get; set; }
        public string keluhan {  get; set; }
        public string catatan {  get; set; }

        public int antrean {  get; set; }
        public string status {  get; set; }
        public byte[] statusImg {  get; set; }

    }
}
