using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class BookingDal
    {
        public IEnumerable<BookingModel> ListData()
        {
            const string sql = @"SELECT b.*, p.nama_pelanggan, k.merk, k.tipe,
                                k.kapasitas, k.tahun
                                FROM Bookings b 
                                INNER JOIN Pelanggan p
                                    ON b.ktp_pelanggan = p.ktp_pelanggan
                                INNER JOIN Kendaraan k
                                    ON b.no_pol = k.no_pol";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BookingModel>(sql);
        }

        public BookingModel? GetData(int id_booking)
        {
            const string sql = @"SELECT b.*, p.nama_pelanggan, k.merk, k.tipe,
                                k.kapasitas, k.tahun
                                FROM Bookings b 
                                INNER JOIN Pelanggan p
                                    ON b.ktp_pelanggan = p.ktp_pelanggan
                                INNER JOIN Kendaraan k
                                    ON b.no_pol = k.no_pol
                                WHERE b.id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<BookingModel>(sql, new {id_booking = id_booking});
        }
    }
}
