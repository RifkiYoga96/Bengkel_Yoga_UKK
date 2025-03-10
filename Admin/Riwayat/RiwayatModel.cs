using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class RiwayatModel
    {
        public int No { get; set; }
        public int id_riwayat { get; set; }
        public string ktp_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }

        public int id_kendaraan { get; set; }
        public string no_pol { get; set; }
        public string merk { get; set; }
        public string tipe { get; set; }
        public int kapasitas { get; set; }
        public string tahun { get; set; }
        public string nama_kendaraan { get; set; }

        public DateTime tanggal { get; set; }
        public DateTime tanggal_servis { get; set; }
        public DateTime tanggal_selesai { get; set; }
        public string ktp_admin { get; set; }
        public string nama_admin { get; set; }
        public string ktp_mekanik { get; set; }
        public string nama_mekanik { get; set; }
        public string pembatalan_oleh { get; set; } = string.Empty;

        public string keluhan { get; set; }
        public string catatan { get; set; }
        public int total_harga { get; set; }
        public string status { get; set; }
        public byte[] statusImg { get; set; }
    }

    public class RiwayatSparepartModel
    {
        public int id_riwayat { get; set; }
        public string kode_sparepart { get; set; }
        public string nama_sparepart { get; set; }
        public int jumlah { get; set; }
        public int harga { get; set; }
        public string image_name { get; set; }
        public byte[] image_data { get; set; }
    }

    public class RiwayatDto
    {
        public int No { get; set; }
        public byte[] Status { get; set; }
        public int id_riwayat { get; set; }
        public string ktp_pelanggan { get; set; }
        public string Pelanggan { get; set; }

        public int id_kendaraan { get; set; }
        public string no_pol { get; set; }
        public string Kendaraan { get; set; }

        public DateTime Tanggal { get; set; }
        public string Pegawai { get; set; }
        public string Mekanik { get; set; }

        public string Keluhan { get; set; }
        public string Catatan { get; set; }
        public string Sparepart { get; set; }
        public string catatan { get; set; }
        public int total_harga { get; set; }

    }
}
