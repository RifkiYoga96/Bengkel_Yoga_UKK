using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class RiwayatDal
    {
        public IEnumerable<RiwayatModel> ListData()
        {
            const string sql = @"SELECT 
                        r.*,p.nama_pelanggan,k.no_pol,k.merk,
                        k.tipe,k.kapasitas,k.tahun,a.nama_admin
                        FROM Riwayat r
                        INNER JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                        INNER JOIN Kendaraan k ON r.no_pol = k.no_pol
                        INNER JOIN Admins a ON r.ktp_admin = a.ktp_admin";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatModel>(sql);
        }

        public IEnumerable<RiwayatSparepartModel> ListDataSparepart()
        {
            const string sql = @"SELECT rs.*, s.* 
                                FROM RiwayatSparepart rs 
                                INNER JOIN Sparepart s ON rs.kode_sparepart = s.kode_sparepart";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatSparepartModel>(sql);
        }
    }
}
