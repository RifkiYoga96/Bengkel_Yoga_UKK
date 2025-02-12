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
                        INNER JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                        INNER JOIN Admins a ON r.ktp_admin = a.ktp_admin";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatModel>(sql);
        }

        public IEnumerable<RiwayatSparepartModel> ListDataSparepart()
        {
            const string sql = @"SELECT * FROM RiwayatSparepart";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatSparepartModel>(sql);
        }
    }
}
