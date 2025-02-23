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
        public IEnumerable<PelangganModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT * FROM Pelanggan {filter.sql} 
                            ORDER BY ";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<PelangganModel>(sql);
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Pelanggan {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }
    }
}
