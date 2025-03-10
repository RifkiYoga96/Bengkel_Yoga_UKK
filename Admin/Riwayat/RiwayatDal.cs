using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class RiwayatDal
    {
        public IEnumerable<RiwayatModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT 
                        r.id_riwayat,
                        r.ktp_pelanggan, 
                        COALESCE(r.nama_pelanggan, p.nama_pelanggan) AS nama_pelanggan, 
                        r.id_kendaraan, 
                        COALESCE(r.no_pol, k.no_pol) AS no_pol,
                        COALESCE(
                            r.nama_kendaraan, 
                            CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')')
                        ) AS nama_kendaraan,
                        r.tanggal,
                        r.tanggal_servis,
                        r.tanggal_selesai,
                        r.keluhan,
                        r.catatan,
                        a.nama_admin AS nama_admin,
                        m.nama_admin AS nama_mekanik,
                        r.id_jasaServis,
                        r.status,
                        r.total_harga,
                        r.pembatalan_oleh
                    FROM Riwayat r
                    LEFT JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                    LEFT JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                    LEFT JOIN JasaServis js ON r.id_jasaServis = js.id_jasaServis
                    LEFT JOIN Admins a ON r.ktp_admin = a.ktp_admin  -- Join untuk admin
                    LEFT JOIN Admins m ON r.ktp_mekanik = m.ktp_admin  -- Join lagi untuk mekanik
                    {filter.sql} 
                    ORDER BY r.tanggal DESC
                    OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY";

            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatModel>(sql, filter.param);
        }

        public RiwayatModel? GetData(int id_riwayat)
        {
            string sql = $@"SELECT 
                        r.id_riwayat,
                        r.ktp_pelanggan, 
                        COALESCE(r.nama_pelanggan, p.nama_pelanggan) AS nama_pelanggan, 
                        r.id_kendaraan, 
                        COALESCE(r.no_pol, k.no_pol) AS no_pol,
                        COALESCE(
                            r.nama_kendaraan, 
                            CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')')
                        ) AS nama_kendaraan,
                        r.tanggal,
                        r.tanggal_servis,   
                        r.tanggal_selesai,
                        r.keluhan,
                        r.catatan,
                        a.nama_admin AS nama_admin,
                        m.nama_admin AS nama_mekanik,
                        r.id_jasaServis,
                        r.status,
                        r.total_harga,
                        r.pembatalan_oleh
                    FROM Riwayat r
                    LEFT JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                    LEFT JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                    LEFT JOIN JasaServis js ON r.id_jasaServis = js.id_jasaServis
                    LEFT JOIN Admins a ON r.ktp_admin = a.ktp_admin  -- Join untuk admin
                    LEFT JOIN Admins m ON r.ktp_mekanik = m.ktp_admin  -- Join lagi untuk mekanik
                    WHERE id_riwayat = @id_riwayat";

            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<RiwayatModel>(sql, new {id_riwayat});
        }

        public IEnumerable<RiwayatSparepartModel> ListDataSparepart()
        {
            const string sql = @"SELECT * FROM RiwayatSparepart";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatSparepartModel>(sql);
        }

        public IEnumerable<JasaServisModel> GetJasaServis(int id_riwayat)
        {
            const string sql = @"SELECT js.nama_jasaServis,js.harga
                                FROM JasaServis js
                                INNER JOIN Riwayat r ON js.id_jasaServis = r.id_jasaServis
                                WHERE r.id_riwayat = @id_riwayat";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<JasaServisModel>(sql, new { id_riwayat });
        }

        public IEnumerable<RiwayatSparepartModel> ListDataSparepartUser(int id_riwayat)
        {
            const string sql = @"SELECT * FROM RiwayatSparepart WHERE id_riwayat = @id_riwayat";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatSparepartModel>(sql, new { id_riwayat });
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Riwayat r
                    LEFT JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                    LEFT JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                    LEFT JOIN JasaServis js ON r.id_jasaServis = js.id_jasaServis
                    LEFT JOIN Admins a ON r.ktp_admin = a.ktp_admin
                    LEFT JOIN Admins m ON r.ktp_mekanik = m.ktp_admin {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        } 
    }
}
