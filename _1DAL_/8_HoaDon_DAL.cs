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
    public static class HoaDon_DAL
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


        private static DataTable DanhSachHoaDon(string proc)
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

        public static DataTable DanhSachHoaDonDaThu()
        {
            try
            {
                return DanhSachHoaDon("SP_HoaDonThang");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachHoaDonChuaThu()
        {
            try
            {
                return DanhSachHoaDon("SP_HoaDonThangHetHan");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        private static DataTable DanhSachXuatHoaDon(string storedProcedure, string parameterName, string parameterValue)
        {
            try
            {
                using (SqlConnection conn = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = storedProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(parameterName, parameterValue);
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
        //
        public static DataTable DanhSachHoaDonDaThuTheoNgayXuat(string ngayXuat)
        {
            try
            {
                return DanhSachXuatHoaDon("SP_DanhSachHoaDonDaThuTheoNgayXuat","@ngayxuathoadon",ngayXuat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachHoaDonChuaThuTheoNgayXuat(string ngayXuat)
        {
            try
            {
                return DanhSachXuatHoaDon("SP_DanhSachHoaDonChuaThuTheoNgayXuat", "@ngayxuathoadon", ngayXuat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable TimKiemHoaDon(string maPhong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using(SqlCommand cmd = new SqlCommand("SP_TimKiemHoaDon", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maphong",maPhong);
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

        public static bool ThemHoaDon(Hoa_Don_DTO hoaDon)
        {
            try
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@MaKhach", hoaDon.MaKhach),
                    new SqlParameter("@MaPhong", hoaDon.MaPhong),
                    new SqlParameter("@NgayBatDau", hoaDon.NgayBatDau),
                    new SqlParameter("@NgayKetThuc", hoaDon.NgayKetThuc),
                    new SqlParameter("@TienDien", hoaDon.TienDien),
                    new SqlParameter("@TienNuoc", hoaDon.TienNuoc),
                    new SqlParameter("@GiaPhong", hoaDon.GiaPhong),
                    new SqlParameter("@tinhtrang", hoaDon.TinhTrang),
                    new SqlParameter("@TongTien", hoaDon.TongTien),
                    new SqlParameter("@ngayxuatHoadon", hoaDon.NgayXuat),
                };
                return ExecuteNonQuery("SP_ThemHoaDon", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool SuaHoaDon(Hoa_Don_DTO hoaDon)
        {
            try
            {
                SqlParameter[] parameters =
                     {
                    new SqlParameter ("@MaHoaDon", hoaDon.MaHoaDon),
                    new SqlParameter("@MaKhach", hoaDon.MaKhach),
                    new SqlParameter("@MaPhong", hoaDon.MaPhong),
                    new SqlParameter("@NgayBatDau", hoaDon.NgayBatDau),
                    new SqlParameter("@NgayKetThuc", hoaDon.NgayKetThuc),
                    new SqlParameter("@TienDien", hoaDon.TienDien),
                    new SqlParameter("@TienNuoc", hoaDon.TienNuoc),
                    new SqlParameter("@GiaPhong", hoaDon.GiaPhong),
                    new SqlParameter("@tinhtrang", hoaDon.TinhTrang),
                    new SqlParameter("@TongTien", hoaDon.TongTien),
                    new SqlParameter("@ngayxuatHoadon", hoaDon.NgayXuat),
                };
                return ExecuteNonQuery("SP_SuaHoaDon", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool XoaHoaDon(string maHD)
        {
            try
            {
                return ExecuteNonQuery("SP_XoaHoaDon", new SqlParameter("@MaHoaDon", maHD));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool KiemTraTonTaiHoaDon(string maKhach, string ngayBatDau, string ngayKetThuc)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraHoaDon", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", maKhach);
                    cmd.Parameters.AddWithValue("@ngaybatdau", ngayBatDau);
                    cmd.Parameters.AddWithValue("@ngayketthuc", ngayKetThuc);
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
        public static string TinhTrangHoaDon(string maKhach)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TinhTrangHoaDon", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", maKhach);
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
