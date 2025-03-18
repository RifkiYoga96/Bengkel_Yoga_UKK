using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class BookingDetailUserDal
    {
        public void CancelBooking(int id)
        {
            const string sql = @"UPDATE Bookings SET status = 'batal booking' WHERE id_booking = @id";
            using var koneksi = new SqlConnection(conn.connStr);
            koneksi.Execute(sql, new {id});
        }
    }
}
