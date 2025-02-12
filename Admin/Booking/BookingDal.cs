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
        public IEnumerable<BookingModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT 
                                b.id_booking,
                                b.ktp_pelanggan, 
                                COALESCE(b.nama_pelanggan, p.nama_pelanggan) AS nama_pelanggan, 
                                b.id_kendaraan, 
                                COALESCE(b.no_pol, k.no_pol) AS no_pol,
                                COALESCE(
                                    b.nama_kendaraan, 
                                    CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')')
                                ) AS nama_kendaraan,
                                b.tanggal,
                                b.keluhan,
                                b.catatan,
                                b.ktp_mekanik,
                                b.id_jasaServis,
                                js.nama_jasaServis,
                                b.status
                            FROM Bookings b 
                            LEFT JOIN Pelanggan p ON b.ktp_pelanggan = p.ktp_pelanggan
                            LEFT JOIN Kendaraan k ON b.id_kendaraan = k.id_kendaraan
                            INNER JOIN JasaServis js ON js.id_jasaServis = b.id_jasaServis;
                                {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BookingModel>(sql,filter.param);
        }

        public BookingModel? GetData(int id_booking)
        {
            const string sql = @"SELECT b.*, p.nama_pelanggan,p.anonimPelanggan, k.merk, k.tipe,
                                k.kapasitas, k.tahun, k.anonimKendaraan
                                FROM Bookings b 
                                INNER JOIN Pelanggan p
                                    ON b.ktp_pelanggan = p.ktp_pelanggan
                                INNER JOIN Kendaraan k
                                    ON b.id_kendaraan = k.id_kendaraan
                                WHERE b.id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<BookingModel>(sql, new {id_booking = id_booking});
        }
    }
}
