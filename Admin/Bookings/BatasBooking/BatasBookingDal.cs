using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class BatasBookingDal
    {
        public IEnumerable<BatasBookingModel> ListData()
        {
            const string sql = @"SELECT id_batas_booking, tanggal, batas_booking
                                FROM BatasBooking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BatasBookingModel>(sql);
        }
        public void DeleteData(int id)
        {
            const string sql = @"DELETE FROM BatasBooking WHERE id_batas_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }
        public BatasBookingModel? GetData(int id)
        {
            const string sql = @"SELECT id_batas_booking, tanggal, batas_booking
                                FROM BatasBooking WHERE id_batas_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<BatasBookingModel>(sql, new {id});
        }
        public BatasBookingModel? CekTanggal(DateTime tanggal, bool isInsert, int id_batas_booking)
        {
            string sql = @"SELECT 1
                                FROM BatasBooking ";
            sql += isInsert ? "WHERE tanggal = @tanggal" : " WHERE id_batas_booking <> @id_batas_booking AND tanggal = @tanggal";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<BatasBookingModel>(sql, new { tanggal, id_batas_booking});
        }

        public int GetBatasBooking(DateTime tanggal)
        {
            const string sql = @"SELECT COALESCE(
                    (SELECT TOP 1 batas_booking FROM BatasBooking WHERE tanggal = @tanggal),
                    (SELECT TOP 1 batas_booking FROM BatasBooking WHERE tanggal IS NULL)
                   ) AS batas_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<int>(sql, new { tanggal });
        }

        public void InsertData(BatasBookingModel data)
        {
            const string sql = @"INSERT INTO BatasBooking (tanggal, batas_booking)
                                VALUES (@tanggal, @batas_booking)";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, data);
        }
        public void UpdateData(BatasBookingModel data)
        {
            const string sql = @"UPDATE BatasBooking
                                SET tanggal = @tanggal, batas_booking = @batas_booking
                                WHERE id_batas_booking = @id_batas_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, data);
        }

        public void DeleteDataTerlewat()
        {
            const string sql = @"DELETE FROM BatasBooking
                                WHERE tanggal < CAST(GETDATE() AS DATE)";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql);
        }

    }
}
