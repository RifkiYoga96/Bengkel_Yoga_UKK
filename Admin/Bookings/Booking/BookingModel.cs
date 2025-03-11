using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class BookingModel
    {
        public int id_booking {  get; set; }
        public string ktp_pelanggan { get; set; } = string.Empty;
        public string nama_pelanggan { get; set;}
        
        public int id_kendaraan {  get; set; }
        public string no_pol {  get; set; }
        public string merk {  get; set; }
        public string tipe {  get; set; }
        public int kapasitas {  get; set; }
        public string tahun {  get; set; }

        public DateTime tanggal {  get; set; }
        public string keluhan {  get; set; }
        public string catatan {  get; set; }
        public string ktp_mekanik {  get; set; }
        public string nama_mekanik { get; set;}

        public int antrean {  get; set; }
        public string status {  get; set; }

    }

    public class BookingModel2
    {
        public int id_booking { get; set; }
        public string ktp_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }

        public int id_kendaraan { get; set; }
        public string no_pol { get; set; }
        public string nama_kendaraan { get; set; }
        public DateTime tanggal { get; set; }
        public string keluhan { get; set; }
        public string catatan { get; set; }
        public int id_jasaServis {  get; set; }
        public string ktp_mekanik { get; set; }
        public string nama_mekanik { get; set; }

        public int antrean { get; set; }
        public int tipe_antrean { get; set; }
        public string status { get; set; }

    }

    public class BookingDto
    {
        public int id_booking { get; set; }
        public int No { get; set; }
        public string antrean { get; set; }
        public byte[] statusImg { get; set; }
        public string ktp_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }

        public int id_kendaraan { get; set; }
        public string no_pol { get; set; }
        public string nama_kendaraan { get; set; }

        public DateTime tanggal { get; set; }
        public string keluhan { get; set; }
        public string catatan { get; set; }

    }

    public class BookingSparepartModel
    {
        public int id_booking { set; get; }
        public string kode_sparepart { set; get; }
        public string nama_sparepart { get; set; }
        public int stok { get; set; }
        public int harga { get; set; }
        public int jumlah { set; get; }
    }

    public class AntreanDto
    {
        public int Antrean { get; set; }
        public int ServisNow {  set; get; }
    }
}
