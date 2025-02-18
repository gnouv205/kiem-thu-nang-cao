using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DTO_;
using System.Data.SqlClient;
using System.Data;

namespace _1DAL_
{
    public static class _1_DangNhap_DAL
    {

        public static bool NguoiDungDangNhap(Nguoi_Dung_DTO nguoidung)
        {
            using (SqlConnection con = DuongDanKetNoi.KetNoi())
            using (SqlCommand cmd = new SqlCommand("SP_DangNhap ", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", nguoidung.Email);
                cmd.Parameters.AddWithValue("@Pass", nguoidung.MatKhau);

                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int value) && value > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #region Quen Mat Khau
        public static bool QuenMatKhau(string email)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_QuenMatKhau", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);

                    if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            return false;
        }

        public static void TaoMatKhauMoi(string email, string newpass)
        {
            try
            {
                string query = "update ChuSoHuu set MatKhau = @newpass where email  = @email";
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@newpass", newpass);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        #endregion

        public static string LayVaiTroNguoiDung(string vaitro)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_VaitroNguoiDung ", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", vaitro);
                    string vaiTro = cmd.ExecuteScalar().ToString();
                    return vaiTro;
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi: { ex.Message}";
            }
        }
    }
}
