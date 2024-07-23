using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _DTO_;

namespace _1DAL_
{
    public static class KhachThue_DAL
    {
        private static bool ExecuteNonQuery(string proc, params SqlParameter[] parameters)
        {
            try
            {
                using(SqlConnection con = DuongDanKetNoi.KetNoi())
                using(SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static DataTable DanhSachKhachThue()
        {
            try
            {
                using(SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_DanhSachKhach";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable danhsachkhach = new DataTable();
                    danhsachkhach.Load(cmd.ExecuteReader());
                    return danhsachkhach;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return null;
        }

        public static DataTable DanhSachMaKhach()
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_DanhSachMaKhach";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable danhsachkhach = new DataTable();
                    danhsachkhach.Load(cmd.ExecuteReader());
                    return danhsachkhach;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return null;
        }

        public static DataTable TimKiemKhachThue(string tenkhach)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_TimKiemTenKhach";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenkhach", tenkhach);

                    DataTable danhsachkhach = new DataTable();
                    danhsachkhach.Load(cmd.ExecuteReader());
                    return danhsachkhach;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return null;
        }

        public static bool ThemKhach(Khach_Thue_DTO khach)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@tenkhach",khach.TenKhach),
                    new SqlParameter("@sodienthoai",khach.SoDienThoai),
                    new SqlParameter("@cccd",khach.CCCD),
                    new SqlParameter("@tinhtrang",khach.TinhTrang),
                    new SqlParameter("@maphong",khach.MaPhong),
                    new SqlParameter("@email",khach.Email),
                };
                return ExecuteNonQuery("SP_ThemKhach", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool SuaKhach(Khach_Thue_DTO khach)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@makhach", khach.MaKhach),
                    new SqlParameter("@tenKhach",khach.TenKhach),
                    new SqlParameter("@sodienthoai",khach.SoDienThoai),
                    new SqlParameter("@cccd",khach.CCCD),
                    new SqlParameter("@tinhtrang",khach.TinhTrang),
                    new SqlParameter("@maphong",khach.MaPhong),
                    new SqlParameter("@email",khach.Email),
                };
                return ExecuteNonQuery("SP_SuaKhach", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool XoaKhach(string makhach)
        {
            try
            {
                return ExecuteNonQuery("SP_XoaKhach", new SqlParameter("@makhach", makhach));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool KiemTraTonTaiKhach(string tenkhach)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraKhachTonTai", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenkhach", tenkhach);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static string TinhTrangKhach(string makhach)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using(SqlCommand cmd = new SqlCommand("SP_TinhTrangKhachThue", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", makhach);
                    string tinhtrang = cmd.ExecuteScalar().ToString();
                    return tinhtrang;
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }
    }
}
