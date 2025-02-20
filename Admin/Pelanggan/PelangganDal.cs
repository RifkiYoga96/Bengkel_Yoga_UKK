using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class PelangganDal
    {
        public IEnumerable<PelangganModel> ListData()
        {
            const string sql = @"SELECT * FROM Pelanggan";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<PelangganModel>(sql);
        }

        public PelangganModel? GetLogin(string email, string password)
        {
            const string sql = @"SELECT ktp_pelanggan FROM Pelanggan WHERE email = @email AND password = @password";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<PelangganModel>(sql, new {email = email, password = password});
        }
    }
}
