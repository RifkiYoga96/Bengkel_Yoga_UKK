﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class PelangganDal
    {
        public IEnumerable<PelangganModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT ktp_pelanggan, nama_pelanggan, email, alamat, no_telp FROM Pelanggan {filter.sql} 
                            ORDER BY created_at DESC
                            OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<PelangganModel>(sql, filter.param);
        }

        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Pelanggan {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }

        public PelangganModel? GetData(string ktp_pelanggan)
        {
            const string sql = @"SELECT * FROM Pelanggan WHERE ktp_pelanggan = @ktp_pelanggan";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { ktp_pelanggan = ktp_pelanggan });
        }

        public void InsertData(PelangganModelUpdate pelanggan)
        {
            var dp = new DynamicParameters();
            dp.Add(@"ktp_pelanggan", pelanggan.ktp_pelanggan_new);
            dp.Add(@"nama_pelanggan", pelanggan.nama_pelanggan);
            dp.Add(@"email", pelanggan.email);
            dp.Add(@"password", pelanggan.password);
            dp.Add(@"no_telp", pelanggan.no_telp);
            dp.Add(@"alamat", pelanggan.alamat);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<PelangganModel>("InsertPelanggan", dp, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void UpdateData(PelangganModelUpdate pelanggan)
        {
            var dp = new DynamicParameters();
            dp.Add(@"ktp_admin_old", pelanggan.ktp_pelanggan_old);
            dp.Add(@"ktp_admin_new", pelanggan.ktp_pelanggan_new);
            dp.Add(@"nama_admin", pelanggan.nama_pelanggan);
            dp.Add(@"no_telp", pelanggan.no_telp);
            dp.Add(@"email", pelanggan.email);
            dp.Add(@"password", pelanggan.password);
            dp.Add(@"alamat", pelanggan.alamat);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<PelangganModel>("UpdatePelanggan", dp, commandType: System.Data.CommandType.StoredProcedure);
        }

        public bool CekEmail(string email)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE email = @email";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { email = email });
            return data != null;
        }
        public bool CekTelepon(string telepon)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE no_telp = @no_telp";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { no_telp = telepon });
            return data != null;
        }
        public bool CekKTP(string ktp)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE ktp_pelanggan = @ktp_pelanggan";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { ktp_pelanggan = ktp });
            return data != null;
        }
        public bool CekEmailUpdate(string email, string ktp_pelanggan)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE ktp_pelanggan <> @ktp_pelanggan AND email = @email";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { email = email, ktp_pelanggan = ktp_pelanggan });
            return data != null;
        }
        public bool CekTeleponUpdate(string telepon, string ktp_pelanggan)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE ktp_pelanggan <> @ktp_pelanggan AND no_telp = @no_telp";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { no_telp = telepon, ktp_pelanggan = ktp_pelanggan });
            return data != null;
        }
        public bool CekKTPUpdate(string ktp)
        {
            const string sql = @"SELECT 1 FROM Pelanggan WHERE ktp_pelanggan <> @ktp_pelanggan";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<PelangganModel>(sql, new { ktp_pelanggan = ktp });
            return data != null;
        }
        public string GetLogin(string email, string password)
        {
            const string sql = @"SELECT ktp_pelanggan FROM Pelanggan
                        WHERE email = @email AND password = @password";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<string>(sql, new { email = email, password = password }) ?? string.Empty;
        }
    }
}
