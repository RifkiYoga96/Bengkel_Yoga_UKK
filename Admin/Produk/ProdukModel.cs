using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class ProdukModelS
    {
        public int NO { get; set; }
        public string KODE_SPAREPART { get; set; }
        public byte[] GAMBAR { get; set; }
        public string PRODUK { get; set; }
        public string HARGA { get; set; }
        public int STOK { get; set; }
        public int STOK_MINIMUM { get; set; }
        public byte[] KETERANGAN_STOK { get; set; }
    }

    public class ProdukModel
    {
        public int kode_sparepart {  get; set; }
        public string nama_sparepart { get; set; }
        public int jumlah {  get; set; }
        public int harga {  get; set; }
        public string image_name {  get; set; }
        public byte[] image_data {  get; set; }
    }

    public class ProdukDto
    {
        public int No { get; set; }
        public string kode_sparepart { get; set; }
        public byte[] Foto { get; set; }
        public string nama_sparepart { get; set; }
        public string Harga { get; set; }
        public int Stok { get; set; }
        public int stok_minimum { get; set; }
        public byte[] keterangan_stok { get; set; }
    }
}
