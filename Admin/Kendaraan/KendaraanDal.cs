using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class KendaraanDal
    {
        public IEnumerable<KendaraanModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT k.id_kendaraan,k.merk,k.tipe,k.no_pol,k.transmisi,k.kapasitas,k.tahun,k.total_servis,p.nama_pelanggan
                                FROM Kendaraan k 
                                INNER JOIN Pelanggan p
                                    ON k.ktp_pelanggan = p.ktp_pelanggan 
                                {filter.sql}
                                {filter.sql2}
                                OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY
                                ";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<KendaraanModel>(sql,filter.param);
        }
        public KendaraanModel? GetData(int id)
        {
            string sql = @"SELECT k.id_kendaraan,k.merk,k.tipe,k.kapasitas,k.no_pol,k.transmisi,k.tahun,k.total_servis,p.nama_pelanggan,k.ktp_pelanggan
                                FROM Kendaraan k 
                                INNER JOIN Pelanggan p
                                    ON k.ktp_pelanggan = p.ktp_pelanggan
                            WHERE id_kendaraan = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KendaraanModel>(sql, new {id});
        }

        public IEnumerable<KendaraanModel> ListDataPelanggan(string ktp_pelanggan)
        {
            const string sql = @"SELECT k.*,p.nama_pelanggan
                                FROM Kendaraan k 
                                RIGHT JOIN Pelanggan p
                                    ON k.ktp_pelanggan = p.ktp_pelanggan
                                WHERE k.ktp_pelanggan = @ktp_pelanggan AND p.deleted_at IS NULL";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<KendaraanModel>(sql, new { ktp_pelanggan = ktp_pelanggan });
        }
        public bool CekNoPol(string no_pol)
        {
            const string sql = @"SELECT 1 FROM Kendaraan WHERE no_pol = @no_pol";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KendaraanModel>(sql, new { no_pol }) != null;
        }
        public bool CekNoPolUpdate(string no_pol, int id)
        {
            const string sql = @"SELECT 1 FROM Kendaraan WHERE no_pol = @no_pol AND id_kendaraan <> @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KendaraanModel>(sql, new { no_pol , id}) != null;
        }
        public void SoftDeleteData(int id_kendaraan)
        {
            const string sql = @"UPDATE Kendaraan SET deleted_at = GETDATE() WHERE id_kendaraan = @id_kendaraan";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id_kendaraan });
        }

        public void RestoreData(int id_kendaraan)
        {
            const string sql = @"UPDATE Kendaraan SET deleted_at = NULL WHERE id_kendaraan = @id_kendaraan";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id_kendaraan });
        }

        public void InsertData(KendaraanModel kendaraan)
        {
            using var koneksi = new SqlConnection(conn.connStr);

            var dp = new DynamicParameters();
            dp.Add("@ktp_pelanggan",kendaraan.ktp_pelanggan);
            dp.Add("@merk",kendaraan.merk);
            dp.Add("@tipe",kendaraan.tipe);
            dp.Add("@transmisi",kendaraan.transmisi);
            dp.Add("@kapasitas",kendaraan.kapasitas);
            dp.Add("@tahun",kendaraan.tahun);
            dp.Add("@no_pol",kendaraan.no_pol);

            koneksi.Query<KendaraanModel>("InsertKendaraan",dp,commandType : System.Data.CommandType.StoredProcedure);
        }
        public void UpdateData(KendaraanModel kendaraan)
        {
            using var koneksi = new SqlConnection(conn.connStr);

            var dp = new DynamicParameters();
            dp.Add("@id_kendaraan", kendaraan.id_kendaraan);
            dp.Add("@ktp_pelanggan", kendaraan.ktp_pelanggan);
            dp.Add("@merk", kendaraan.merk);
            dp.Add("@tipe", kendaraan.tipe);
            dp.Add("@transmisi", kendaraan.transmisi);
            dp.Add("@kapasitas", kendaraan.kapasitas);
            dp.Add("@tahun", kendaraan.tahun);
            dp.Add("@no_pol", kendaraan.no_pol);

            koneksi.Query<KendaraanModel>("UpdateKendaraan", dp, commandType: System.Data.CommandType.StoredProcedure);
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Kendaraan k
                             INNER JOIN Pelanggan p
                                    ON k.ktp_pelanggan = p.ktp_pelanggan 
                            {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }
    }
}
