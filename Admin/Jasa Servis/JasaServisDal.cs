using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class JasaServisDal
    {
        public IEnumerable<JasaServisModel> ListData()
        {
            const string sql = @"SELECT * FROM JasaServis";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JasaServisModel>(sql);
        }
    }
}
