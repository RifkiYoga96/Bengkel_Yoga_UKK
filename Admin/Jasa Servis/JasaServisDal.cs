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
        public IEnumerable<JasaServisModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT * FROM JasaServis {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JasaServisModel>(sql, filter.param);
        }
        public JasaServisModel? GetData(int id)
        {
            const string sql = @"SELECT * FROM JasaServis WHERE id_jasaServis = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<JasaServisModel>(sql, new {id});
        }
        public void SoftDeleteData(int id)
        {
            const string sql = @"UPDATE JasaServis SET deleted_at = GETDATE() WHERE id_jasaServis = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }

        public void RestoreData(int id)
        {
            const string sql = @"UPDATE JasaServis SET deleted_at = NULL WHERE id_jasaServis = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM JasaServis {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }
    }
}
