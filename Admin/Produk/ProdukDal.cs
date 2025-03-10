using Dapper;
using Syncfusion.Olap.MDXQueryParser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class ProdukDal
    {
        public IEnumerable<ProdukModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT * FROM Sparepart
                           {filter.sql} 
                            ORDER BY kode_sparepart DESC
                            OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<ProdukModel>(sql,filter.param);
        }
        public ProdukModel? GetData(string kode_produk)
        {
            string sql = @"SELECT * FROM Sparepart
                            WHERE kode_sparepart = @kode_produk";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<ProdukModel>(sql, new { kode_produk });
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Sparepart {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }

        public void InsertData(ProdukModel produk)
        {
            using var koneksi = new SqlConnection(conn.connStr);
            const string sql = @"SELECT TOP 1 kode_sparepart FROM Sparepart ORDER BY kode_sparepart DESC";
            string? kode = koneksi.QueryFirstOrDefault<string?>(sql);

            if (string.IsNullOrEmpty(kode) || !kode.StartsWith("SP"))
                throw new ArgumentException("Format kode tidak valid");

            string numberPart = kode.Substring(2);  // Ambil setelah "SP"

            if (!int.TryParse(numberPart, out int nextNumber))
                throw new ArgumentException("Format angka tidak valid");

            // Format ulang dengan minimal 3 digit angka
            string resultKode = "SP" + (nextNumber + 1).ToString().PadLeft(3, '0');

            produk.kode_sparepart = resultKode;
            
            koneksi.Execute("InsertSparepart",produk,commandType: System.Data.CommandType.StoredProcedure);
        }
        public void UpdateData(ProdukModel produk)
        {
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute("UpdateSparepart", produk, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
