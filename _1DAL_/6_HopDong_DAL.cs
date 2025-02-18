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
    public static class HopDong_DAL
    {
        private static bool ExecuteNonQuery(string proc, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        private static DataTable DanhSachHopDong(string proc)
        {
            try
            {
                using (SqlConnection conn = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable danhSachHoaDon = new DataTable();
                    danhSachHoaDon.Load(cmd.ExecuteReader());
                    return danhSachHoaDon;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachHopDongConHan()
        {
            try
            {
                return DanhSachHopDong("SP_DanhSachHopDong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new DataTable(); // Trả về một DataTable rỗng thay vì lỗi
            }
        }


        public static DataTable DanhSachHopDongHetHan()
        {
            try
            {
                return DanhSachHopDong("SP_DanhSachHopDongHetHan");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new DataTable();
            }
        }

        public static DataTable TimKiemHopDong(string ngayBatDau, string maK)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TimKiemHopDong", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    cmd.Parameters.AddWithValue("@makhach", maK);
                    DataTable danhSach = new DataTable();
                    danhSach.Load(cmd.ExecuteReader());
                    return danhSach;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static bool ThemHopDong(Hop_Dong_DTO hopDong)
        {
            try
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@email", hopDong.Email),
                    new SqlParameter("@makhach", hopDong.MaKhach),
                    new SqlParameter("@maphong", hopDong.MaPhong),
                    new SqlParameter("@ngaybatdau", hopDong.NgayBatDau),
                    new SqlParameter("@ngayketthuc", hopDong.NgayKetThuc),
                    new SqlParameter("@chisodien", hopDong.ChiSoDien),
                    new SqlParameter("@chisonuoc", hopDong.ChiSoNuoc),
                    new SqlParameter("@tiencoc", hopDong.TienCoc),
                    new SqlParameter("@tienthue", hopDong.TienThue),
                    new SqlParameter("@tinhtrang", hopDong.TinhTrang)
                };
                return ExecuteNonQuery("SP_ThemHopDong", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool SuaHopDong(Hop_Dong_DTO hopDong)
        {
            try
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@mahopdong", hopDong.MaHopDong),
                    new SqlParameter("@email", hopDong.Email),
                    new SqlParameter("@makhach", hopDong.MaKhach),
                    new SqlParameter("@maphong", hopDong.MaPhong),
                    new SqlParameter("@ngaybatdau", hopDong.NgayBatDau),
                    new SqlParameter("@ngayketthuc", hopDong.NgayKetThuc),
                    new SqlParameter("@chisodien", hopDong.ChiSoDien),
                    new SqlParameter("@chisonuoc", hopDong.ChiSoNuoc),
                    new SqlParameter("@tiencoc", hopDong.TienCoc),
                    new SqlParameter("@tienthue", hopDong.TienThue),
                    new SqlParameter("@tinhtrang", hopDong.TinhTrang)
                };
                return ExecuteNonQuery("SP_SuahopDong", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool XoaHopDong(string maHD)
        {
            try
            {
                return ExecuteNonQuery("SP_XoaHopDong", new SqlParameter("@mahopdong", maHD));
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết hơn để dễ dàng kiểm tra nguyên nhân
                Console.WriteLine($"Lỗi: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return false;
            }
        }


        public static bool KiemTraTonTaiHopDong(string maK)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraHopDongTonTai", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", maK);
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


        public static string LayThongTinTuStoredProcedure(string storedProcedure, string parameterName, string parameterValue, string columnName)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = storedProcedure;
                    cmd.Parameters.AddWithValue(parameterName, parameterValue);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader[columnName].ToString();
                        }
                        else
                        {
                            return null; // Không có dữ liệu trả về
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static string ThongTinMaHopDong(string maHopDong)
        {
            return LayThongTinTuStoredProcedure("SP_MaHopDong", "@mahopdong", maHopDong, "MaHopDong");
        }

        public static string ThongTinNguoiDungHopDong(string maHopDong)
        {
            return LayThongTinTuStoredProcedure("SP_MaNguoiDungHopDong", "@mahopdong", maHopDong, "MaNguoiDung");
        }

        public static string ThongTinKhachHopDong(string maHopDong)
        {
            return LayThongTinTuStoredProcedure("SP_MakhachHopDong", "@mahopdong", maHopDong, "MaKhach");
        }
        public static string ThongTinMaPhongHopDong(string maHopDong)
        {
            return LayThongTinTuStoredProcedure("SP_MaPhongHopDong", "@mahopdong", maHopDong, "MaPhong");
        }
    }
}
