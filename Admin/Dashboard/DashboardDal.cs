using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class DashboardDal
    {
        public IEnumerable<BookingModel> ListDataServis()
        {
            const string sql = @"SELECT TOP 5
                                b.id_booking,
                                COALESCE(b.nama_pelanggan, p.nama_pelanggan) AS nama_pelanggan, 
                                COALESCE(b.no_pol, k.no_pol) AS no_pol,
                                COALESCE(
                                    b.nama_kendaraan, 
                                    CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')')
                                ) AS nama_kendaraan,
                                b.antrean,
                                b.tipe_antrean                    
                            FROM Bookings b 
                            LEFT JOIN Pelanggan p ON b.ktp_pelanggan = p.ktp_pelanggan
                            LEFT JOIN Kendaraan k ON b.id_kendaraan = k.id_kendaraan
                            WHERE tanggal <= CONVERT(DATE, GETDATE())
                            ORDER BY tanggal ASC, tipe_antrean DESC, antrean ASC";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BookingModel>(sql);
        }

        public int GetPendapatan(DateTime tgl1, DateTime tgl2)
        {
            const string sql = @"SELECT ISNULL(SUM(total_harga), 0) AS TotalPendapatan
                                FROM Riwayat
                                WHERE tanggal_selesai BETWEEN @tgl1 AND @tgl2";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, new { tgl1, tgl2 });
        }

        public int GetJumlahBooking(DateTime tgl1, DateTime tgl2)
        {
            const string sql = @"SELECT COUNT(*) AS TotalBooking
                                FROM Bookings
                                WHERE tanggal BETWEEN @tgl1 AND @tgl2";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, new { tgl1, tgl2 });
        }

        public int GetBookingBelumDitangani(DateTime tgl1, DateTime tgl2)
        {
            const string sql = @"SELECT COUNT(*) AS BookingBelumDitangani
                                FROM Bookings
                                WHERE status = 'pending' AND tanggal <= CONVERT(DATE, GETDATE())";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, new { tgl1, tgl2 });
        }

        public int GetSparepartMenipisHabis()
        {
            const string sql = @"SELECT COUNT(*) AS SparepartMenipisHabis
                                FROM Sparepart
                                WHERE stok <= stok_minimum AND stok > 0";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql);
        }



        //Admin
        public IEnumerable<ServisTerbanyakDto> ListServisTerbanyak()
        {
            const string sql = @"SELECT TOP 5
                    p.nama_pelanggan, COUNT(*) AS jumlah_servis
                    FROM Riwayat r
                    INNER JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                    GROUP BY r.ktp_pelanggan, p.nama_pelanggan";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<ServisTerbanyakDto>(sql);
        }

    }
}

public class ServisTerbanyakDto
{
    public string nama_pelanggan { get; set; }
    public int jumlah_servis { get; set; }
}
