﻿using Dapper;
using Syncfusion.MIME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                                b.antrean,
                                b.tipe_antrean,                     
                                b.ktp_mekanik,
                                b.id_jasaServis,
                                b.status
                            FROM Bookings b 
                            LEFT JOIN Pelanggan p ON b.ktp_pelanggan = p.ktp_pelanggan
                            LEFT JOIN Kendaraan k ON b.id_kendaraan = k.id_kendaraan
                            LEFT JOIN JasaServis js ON js.id_jasaServis = b.id_jasaServis 
                            {filter.sql} 
                            ORDER BY b.tipe_antrean ASC, b.antrean ASC
                            OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BookingModel>(sql,filter.param);
        }

        public BookingModel? GetData(int id_booking)
        {
            const string sql = @"SELECT 
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
                                b.antrean,
                                b.tipe_antrean,
                                b.ktp_mekanik,
                                b.id_jasaServis,
                                b.status
                            FROM Bookings b 
                            LEFT JOIN Pelanggan p ON b.ktp_pelanggan = p.ktp_pelanggan
                            LEFT JOIN Kendaraan k ON b.id_kendaraan = k.id_kendaraan
                            LEFT JOIN JasaServis js ON js.id_jasaServis = b.id_jasaServis
                                WHERE b.id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<BookingModel>(sql, new {id_booking = id_booking});
        }

        public IEnumerable<BookingSparepartModel> ListDataProduk(int id_booking)
        {
            const string sql = @"SELECT kode_sparepart, nama_sparepart, harga, jumlah
                            FROM BookingsSparepart
                            WHERE id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<BookingSparepartModel>(sql, new {id_booking = id_booking});
        }

        public AntreanDto? GetAntrean(DateTime tanggal, int tipe_antrean)
        {
            const string sql = @"SELECT * FROM GetAntrean(@tanggal,@tipe_antrean)";

            using var koneksi = new SqlConnection(conn.connStr);
            var dp = new DynamicParameters();
            dp.Add("@tanggal", tanggal);
            dp.Add("@tipe_antrean", tipe_antrean);

            return koneksi.QueryFirstOrDefault<AntreanDto>(sql, dp) ?? new AntreanDto();
        }


        public bool CekNoPol(string no_pol)
        {
            const string sql = @"SELECT COUNT(*) FROM Kendaraan WHERE no_pol = @no_pol";
            using var koneksi = new SqlConnection(conn.connStr);
            int count =  koneksi.QuerySingleOrDefault<int>(sql, new {no_pol = no_pol});
            return count > 0;
        }
        public async Task UpdateKonfirmasiBookingAsync(FilterDto data)
        {
            using var koneksi = new SqlConnection(conn.connStr);

            await koneksi.ExecuteAsync(data.sql, data.param);
        }



        public void InsertDataBooking(BookingModel booking, bool pelanggan)
        {
            var dp = new DynamicParameters();
            if (pelanggan)
            {
                dp.Add("@ktp_pelanggan", booking.ktp_pelanggan);
                dp.Add("@id_kendaraan", booking.id_kendaraan);
                dp.Add("@tanggal", booking.tanggal);
                dp.Add("@keluhan", booking.keluhan);
                dp.Add("@antrean", booking.antrean);
            }
            else
            {
                dp.Add("@nama_pelanggan", booking.nama_pelanggan);
                dp.Add("@nama_kendaraan", booking.nama_kendaraan);
                dp.Add("@no_pol",booking.no_pol);
                dp.Add("@tanggal", booking.tanggal);
                dp.Add("@keluhan", booking.keluhan);
                dp.Add("@antrean", booking.antrean);
            }

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<BookingModel>("InsertBooking",dp,commandType: CommandType.StoredProcedure);
        }

        public void InsertDataBookingSparepart(ProdukAddDto sparepart)
        {
            var dp = new DynamicParameters();
            dp.Add("@id_booking",sparepart.id_booking);
            dp.Add("@kode_sparepart",sparepart.Kode);
            dp.Add("@jumlah",sparepart.Jumlah);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<ProdukAddDto>("InsertBookingSparepart", dp, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBookingSparepart(int id_booking)
        {
            const string sql = @"DELETE FROM BookingsSparepart WHERE id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id_booking = id_booking });
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Bookings b 
                            LEFT JOIN Pelanggan p ON b.ktp_pelanggan = p.ktp_pelanggan
                            LEFT JOIN Kendaraan k ON b.id_kendaraan = k.id_kendaraan
                            LEFT JOIN JasaServis js ON js.id_jasaServis = b.id_jasaServis {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }

        public IEnumerable<ProdukAddDto> ListDataSparepart(int id)
        {
                        const string sql = @"SELECT 
                p.kode_sparepart AS Kode, 
                p.nama_sparepart AS Sparepart, 
                ISNULL(bs.jumlah, 1) AS Jumlah, -- Jika NULL, maka jumlah = 1
                p.stok AS Stok
            FROM Sparepart p
            LEFT JOIN BookingsSparepart bs 
                ON bs.kode_sparepart = p.kode_sparepart 
                AND bs.id_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<ProdukAddDto>(sql, new {id});
        }
        public async Task<IEnumerable<BookingModel>> ListDataAntrean(DateTime tanggal)
        {
            const string sql = @"
                SELECT id_booking, antrean, tipe_antrean, status
                FROM Bookings 
                WHERE tanggal <= @tanggal
                ORDER BY tanggal ASC, antrean ASC";

            using var koneksi = new SqlConnection(conn.connStr);
            return await koneksi.QueryAsync<BookingModel>(sql, new { tanggal });
        }

        public void UpdateAntrean(BookingModel booking)
        {
            const string sql = @"UPDATE Bookings SET antrean = @antrean, tipe_antrean = @tipe_antrean WHERE id_booking = @id_booking";
            using var koneksi = new SqlConnection(conn.connStr);

            var dp = new DynamicParameters();
            dp.Add("@antrean",booking.antrean);
            dp.Add("@tipe_antrean",booking.tipe_antrean);
            dp.Add("@id_booking",booking.id_booking);

            koneksi.Execute(sql, dp);
        }

        public void HardDeleteData(int id)
        {
            const string sql = @"DELETE FROM Bookings WHERE id_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new {id});
        }
        public void HardDeleteBookingSparepart(int id)
        {
            const string sql = @"DELETE FROM BookingsSparepart WHERE id_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { id });
        }

        public async Task SelesaiServisUpdate(DynamicParameters dp, List<BookingSparepartModel> listBookingSparepart)
        {
            string sql = @"
                INSERT INTO Riwayat (
                    ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, 
                    tanggal, tanggal_servis, tanggal_selesai, 
                    ktp_admin, ktp_mekanik, keluhan, catatan, total_harga, 
                    id_jasaServis, status, pembatalan_oleh, created_at
                )
                SELECT 
                    b.ktp_pelanggan, b.nama_pelanggan, b.id_kendaraan, b.no_pol, b.nama_kendaraan, 
                    b.tanggal, b.tanggal_servis, GETDATE(),
                    @ktp_admin, b.ktp_mekanik, b.keluhan, b.catatan, @total_harga, 
                    b.id_jasaServis, @status, @pembatalan_oleh,
                    GETDATE()
                FROM Bookings b
                WHERE b.id_booking = @id_booking;

                SELECT SCOPE_IDENTITY();";


            string sqlDelete = @"UPDATE Bookings SET deleted_at = GETDATE() WHERE id_booking = @id_booking";

            using var koneksi = new SqlConnection(conn.connStr);

            int idRiwayat = await koneksi.ExecuteScalarAsync<int>(sql, dp);
            await koneksi.ExecuteAsync(sqlDelete, dp);

            foreach (var i in listBookingSparepart)
            {
                //dp
                var dpRS = new DynamicParameters();
                dpRS.Add("@id_riwayat", idRiwayat);
                dpRS.Add("@kode_sparepart",i.kode_sparepart);
                dpRS.Add("@jumlah", i.jumlah);
                await koneksi.ExecuteAsync("InsertRiwayatSparepart", dpRS, commandType: CommandType.StoredProcedure);
            }


        }
    }
}