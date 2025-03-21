﻿using Dapper;
using Sodium;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class KaryawanDal
    {
        public IEnumerable<KaryawanModel> ListData(FilterDto filter)
        {
            string sql = $@"SELECT * FROM Admins {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<KaryawanModel>(sql, filter.param);
        }

        public KaryawanModel? GetData(string ktp_admin)
        {
            const string sql = @"SELECT * FROM Admins WHERE ktp_admin = @ktp_admin";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { ktp_admin = ktp_admin });
        }

        public void InsertData(KaryawanModelUpdate karyawan)
        {
            var dp = new DynamicParameters();
            dp.Add(@"ktp_admin", karyawan.ktp_admin_new);
            dp.Add(@"nama_admin", karyawan.nama_admin);
            dp.Add(@"no_telp", karyawan.no_telp);
            dp.Add(@"email", karyawan.email);
            dp.Add(@"password", karyawan.password);
            dp.Add(@"alamat", karyawan.alamat);
            dp.Add(@"role", karyawan.role);
            dp.Add("@image_data", karyawan.image_data != null ? karyawan.image_data : DBNull.Value, System.Data.DbType.Binary);

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<KaryawanModelUpdate>("InsertAdmin", dp, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void UpdateData(KaryawanModelUpdate karyawan)
        {
            var dp = new DynamicParameters();
            dp.Add(@"ktp_admin_old", karyawan.ktp_admin_old);
            dp.Add(@"ktp_admin_new", karyawan.ktp_admin_new);
            dp.Add(@"nama_admin", karyawan.nama_admin);
            dp.Add(@"no_telp", karyawan.no_telp);
            dp.Add(@"email", karyawan.email);
            dp.Add(@"password", karyawan.password);
            dp.Add(@"alamat", karyawan.alamat);
            dp.Add(@"role", karyawan.role);
            dp.Add("@image_data", karyawan.image_data != null ? karyawan.image_data : DBNull.Value, System.Data.DbType.Binary);


            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Query<KaryawanModelUpdate>("UpdateAdmin", dp, commandType: System.Data.CommandType.StoredProcedure);
        }

        public bool CekEmail(string email)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE email = @email";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { email = email });
            return data is null;
        }
        public bool CekTelepon(string telepon)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE no_telp = @no_telp";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { no_telp = telepon });
            return data is null;
        }
        public bool CekKTP(string ktp)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE ktp_admin = @ktp_admin";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { ktp_admin = ktp });
            return data is null;
        }
        public bool CekKTPUpdate(string ktp_new, string ktp_old)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE ktp_admin <> @ktp_old AND ktp_admin = @ktp_new";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { ktp_new = ktp_new, ktp_old = ktp_old });
            return data is null;
        }

        public bool CekEmailUpdate(string email, string ktp_admin)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE ktp_admin <> @ktp_admin AND email = @email";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { email = email, ktp_admin = ktp_admin });
            return data is null;
        }
        public bool CekTeleponUpdate(string telepon, string ktp_admin)
        {
            const string sql = @"SELECT 1 FROM Admins WHERE ktp_admin <> @ktp_admin AND no_telp = @no_telp";
            using var koneksi = new SqlConnection(conn.connStr);
            var data = koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { no_telp = telepon, ktp_admin = ktp_admin });
            return data is null;
        }

         

        public void UpdateKTP(string ktp_new, string ktp_old)
        {
            const string sql = @"UPDATE Riwayat SET ktp_mekanik = @ktp_new WHERE ktp_mekanik = @ktp_old";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { ktp_new = ktp_new, ktp_old = ktp_old });
        }
        public KaryawanModel? GetLogin(string email)
        {
            const string sql = @"SELECT ktp_admin, password, role FROM Admins
                        WHERE email = @email";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QueryFirstOrDefault<KaryawanModel>(sql, new { email = email});
        }
        public void SoftDeleteData(string ktp)
        {
            const string sql = @"UPDATE Admins SET deleted_at = GETDATE() WHERE ktp_admin = @ktp";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { ktp });
        }

        public void RestoreData(string ktp)
        {
            const string sql = @"UPDATE Admins SET deleted_at = NULL WHERE ktp_admin = @ktp";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new { ktp });
        }
        public int GetTotalRows(FilterDto filter)
        {
            string sql = $@"SELECT COUNT(*)
                            FROM Admins
                            {filter.sql}";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.QuerySingleOrDefault<int>(sql, filter.param);
        }
    }
}
