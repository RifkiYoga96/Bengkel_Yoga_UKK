using Dapper;
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
        public IEnumerable<KaryawanModel> ListData()
        {
            const string sql = @"SELECT * FROM Admins";
            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<KaryawanModel>(sql);
        }

        public void InsertData()
        {
            const string sql = @"INSERT INTO Admins(js,s,s,s,)";
        }

        public void UpdateData(KaryawanModel karyawan)
        {
            const string sql = @"
                UPDATE Admins
                SET 
                    nama_admin = @nama_admin,
                    email = @email,
                    password = @password,
                    no_telp = @no_telp,
                    role = @role,
                    image_name = @image_name,
                    image_data = @image_data
                WHERE ktp_admin = @ktp_admin";

            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, karyawan);
        }
    }
}
