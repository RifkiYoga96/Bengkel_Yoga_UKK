using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class JadwalDal
    {
        public IEnumerable<JadwalModel> ListData()
        {
            const string sql = @"SELECT 
                                *
                                FROM JadwalLibur";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JadwalModel>(sql);
        }
        public JadwalModel? GetData(int id)
        {
            const string sql = @"SELECT * FROM JadwalLibur WHERE id_jadwal_libur = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<JadwalModel>(sql, new { id });
        }
        public void InsertData(JadwalModel model)
        {
            const string sql = @"INSERT INTO JadwalLibur (tanggal, hari) VALUES (@tanggal, @hari)";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { tanggal = model.tanggal ?? (DateTime?)null, hari = model.hari ?? (string?)null });
        }
        public void UpdateData(JadwalModel model)
        {
            const string sql = @"UPDATE JadwalLibur SET tanggal = @tanggal, hari = @hari WHERE id_jadwal_libur = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { tanggal = model.tanggal ?? (DateTime?)null, hari = model.hari ?? (string?)null, id = model.id_jadwal_libur });
        }

        public void DeleteData(int id)
        {
            const string sql = @"DELETE FROM JadwalLibur WHERE id_jadwal_libur = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }
        public bool CekLibur(DateTime tanggal)
        {
            const string sql = @"
                SELECT COUNT(*) 
                FROM JadwalLibur 
                WHERE tanggal = @tanggal 
                   OR hari = @hari";

            var namaHari = tanggal.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

            if (namaHari == "Jumat")
                namaHari = "Jum''at";

            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.ExecuteScalar<int>(sql, new { tanggal, hari = namaHari }) > 0;
        }

    }
}
