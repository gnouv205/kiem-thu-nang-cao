using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DTO_;

namespace _1DAL_
{
    public static class _2_DoiMatKhau_DAL
    {
        public static bool CapNhatMatKhau(string email, string oldpass, string newpass)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_DoiMatKhau", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@oldpass", oldpass);
                    cmd.Parameters.AddWithValue("@newpass", newpass);

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            return false;
        }
    }
}
