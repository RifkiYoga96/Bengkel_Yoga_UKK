using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class ProdukModel
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
}
