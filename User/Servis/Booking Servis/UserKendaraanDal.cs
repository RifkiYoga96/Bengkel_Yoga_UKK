using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bengkel_Yoga_UKK
{
    public class UserKendaraanDal
    {
        public KendaraanModel? GetDataKendaraan(int id_kendaraan)
        {
            const string sql = @"SELECT k.merk, 
                    CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')') AS tipe,
                    k.no_pol
                    FROM Kendaraan k
                    WHERE id_kendaraan = @id_kendaraan AND deleted_at IS NULL";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KendaraanModel>(sql, new { id_kendaraan });
        }

        public ServisTerakhirDto? GetServisBooking(int id_kendaraan)
        {
            const string sql = @"SELECT TOP 1 tanggal, catatan, status, antrean, tipe_antrean, id_booking AS id_terkait
                                FROM Bookings
                                WHERE id_kendaraan = @id_kendaraan AND deleted_at IS NULL
                                ORDER BY tanggal DESC";
            using var koneksi = new SqlConnection(conn.connStr);

            return koneksi.QueryFirstOrDefault<ServisTerakhirDto>(sql, new { id_kendaraan = id_kendaraan });
        }
        public ServisTerakhirDto? GetServisRiwayat(int id_kendaraan)
        {
            const string sql = @"SELECT TOP 1 tanggal, catatan, status, id_riwayat AS id_terkait
                                FROM Riwayat
                                WHERE id_kendaraan = @id_kendaraan
                                ORDER BY tanggal DESC";
            using var koneksi = new SqlConnection(conn.connStr);

            return koneksi.QueryFirstOrDefault<ServisTerakhirDto>(sql, new { id_kendaraan = id_kendaraan });
        }
    }
}

public class ServisTerakhirDto
{
    public DateTime tanggal { get; set; }
    public string catatan { get; set; }
    public string status { get; set; }
    public int antrean { get; set; }
    public int tipe_antrean { get; set; }
    public int id_terkait { get; set; }
}
