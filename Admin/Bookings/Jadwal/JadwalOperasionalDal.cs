using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bengkel_Yoga_UKK
{
    public class JadwalOperasionalDal
    {
        public IEnumerable<JadwalOperasionalModel> ListData()
        {
            const string sql = @"SELECT * FROM JadwalOperasional
                        ORDER BY 
                            CASE 
                                WHEN hari IS NULL THEN 0
                                WHEN hari = 'Senin' THEN 1
                                WHEN hari = 'Selasa' THEN 2
                                WHEN hari = 'Rabu' THEN 3
                                WHEN hari = 'Kamis' THEN 4
                                WHEN hari = 'Jum''at' THEN 5
                                WHEN hari = 'Sabtu' THEN 6
                                WHEN hari = 'Minggu' THEN 7
                                ELSE 8 
                            END";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JadwalOperasionalModel>(sql);
        }

        public JadwalOperasionalModel? GetData(int id)
        {
            const string sql = @"SELECT * FROM JadwalOperasional WHERE id_jadwal_operasional = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<JadwalOperasionalModel>(sql, new { id });
        }

        public void InsertData(JadwalOperasionalModel jom)
        {
            const string sql = @"INSERT INTO JadwalOperasional (hari, jam_buka, jam_tutup) VALUES (@hari, @jam_buka, @jam_tutup)";

            var dp = new DynamicParameters();
            dp.Add(@"hari",jom.hari, System.Data.DbType.String);
            dp.Add(@"jam_buka",jom.jam_buka, System.Data.DbType.Time);
            dp.Add(@"jam_tutup",jom.jam_tutup, System.Data.DbType.Time);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql,dp);
        }
        public void UpdateData(JadwalOperasionalModel jom)
        {
            const string sql = @"UPDATE JadwalOperasional 
                         SET hari = @hari, 
                             jam_buka = @jam_buka, 
                             jam_tutup = @jam_tutup 
                         WHERE id_jadwal_operasional = @id";

            var dp = new DynamicParameters();
            dp.Add(@"id", jom.id_jadwal_operasional, System.Data.DbType.Int32);
            dp.Add(@"hari", jom.hari, System.Data.DbType.String);
            dp.Add(@"jam_buka", jom.jam_buka, System.Data.DbType.Time);
            dp.Add(@"jam_tutup", jom.jam_tutup, System.Data.DbType.Time);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, dp);
        }
        public void DeleteData(int id)
        {
            const string sql = @"DELETE FROM JadwalOperasional WHERE id_jadwal_operasional = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }
        public JadwalOperasionalModel? CekHari(string hari, bool isInsert, int id_jadwal_operasional)
        {
            string sql = @"SELECT 1
                                FROM JadwalOperasional ";
            sql += isInsert ? "WHERE hari = @hari" : " WHERE id_jadwal_operasional <> @id_jadwal_operasional AND hari = @hari";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<JadwalOperasionalModel>(sql, new { hari, id_jadwal_operasional });
        }

        public bool CekTutup(DateTime tanggal)
        {
            const string sql = @"
                SELECT TOP 1 jam_tutup 
                FROM JadwalOperasional 
                WHERE hari = @hari 
                ORDER BY CASE WHEN hari = @hari THEN 1 ELSE 2 END";

            var namaHari = tanggal.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

            if (namaHari == "Jumat")
                namaHari = "Jum''at";

            using var koneksi = new SqlConnection(conn.connStr);
            TimeSpan? jamTutup = koneksi.QueryFirstOrDefault<TimeSpan?>(sql, new { tanggal, hari = namaHari });

            if (jamTutup == null)
                return false;

            return DateTime.Now.TimeOfDay >= jamTutup;
        }


    }
}
