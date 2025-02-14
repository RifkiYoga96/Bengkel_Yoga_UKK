using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class MB
    {
        public static bool Konfirmasi()
        {
            bool result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?","Konfirmasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            return result;
        }

        public static void Error()
        {
            MessageBox.Show("Harap melengkapi data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
