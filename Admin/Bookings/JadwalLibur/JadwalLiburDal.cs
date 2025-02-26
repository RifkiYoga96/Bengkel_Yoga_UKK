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
    public class JadwalLiburDal
    {
        public IEnumerable<JadwalLiburModel> ListData()
        {
            const string sql = @"SELECT 
                                *
                                FROM JadwalLibur";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JadwalLiburModel>(sql);
        }
        public JadwalLiburModel? GetData(int id)
        {
            const string sql = @"SELECT * FROM JadwalLibur WHERE id_jadwal_libur = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<JadwalLiburModel>(sql, new {id});
        }
    }
}
