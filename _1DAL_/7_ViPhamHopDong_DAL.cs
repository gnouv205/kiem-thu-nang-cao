using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DTO_;
using System.Data;
using System.Data.SqlClient;

namespace _1DAL_
{
    public static class ViPhamHopDong_DAL
    {
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
        public static DataTable DanhSachHopDongHuy()
        {
            try
            {
                return DanhSachHopDong("SP_DanhSachHuyHopDong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }
        public static DataTable DanhSachHopDongChuaHuy()
        {
            try
            {
                return DanhSachHopDong("SP_DanhSachChuaHuyHopDong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

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

        public static bool HopDongCanHuy(Vi_Pham_Hop_Dong_DTO viPham)
        {
            try
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@mahopdong", viPham.MaHopDong),
                    new SqlParameter("@manguoidung", viPham.MaNguoiDung),
                    new SqlParameter("@makhach", viPham.MaKhach),
                    new SqlParameter("@maphong", viPham.MaPhong),
                    new SqlParameter("@nguoivipham", viPham.NguoiViPham),
                    new SqlParameter("@noidungvipham", viPham.NoiDungViPham),
                    new SqlParameter("@ngayvipham", viPham.NgayViPham),
                    new SqlParameter("@ngayhuy", viPham.NgayHuy),
                    new SqlParameter("@bienphapxuly", viPham.BienPhamXuLy),
                    new SqlParameter("@tienboithuong", viPham.TienBoiThuong),
                    new SqlParameter("@tinhtrang", viPham.TinhTrang)
                };
                return ExecuteNonQuery("SP_LapBangHuyHopDong", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool HopDongXacNhanHuy(Vi_Pham_Hop_Dong_DTO viPham)
        {
            try
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@mavipham", viPham.MaViPham),
                    new SqlParameter("@mahopdong", viPham.MaHopDong),
                    new SqlParameter("@manguoidung", viPham.MaNguoiDung),
                    new SqlParameter("@makhach", viPham.MaKhach),
                    new SqlParameter("@maphong", viPham.MaPhong),
                    new SqlParameter("@nguoivipham", viPham.NguoiViPham),
                    new SqlParameter("@noidungvipham", viPham.NoiDungViPham),
                    new SqlParameter("@ngayvipham", viPham.NgayViPham),
                    new SqlParameter("@ngayhuy", viPham.NgayHuy),
                    new SqlParameter("@bienphapxuly", viPham.BienPhamXuLy),
                    new SqlParameter("@tienboithuong", viPham.TienBoiThuong),
                    new SqlParameter("@tinhtrang", viPham.TinhTrang)
                };
                return ExecuteNonQuery("SP_XacNhanHuyHopDong", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static DataTable TimKiemMaKhac(string maKhach)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TimKiemMaKhach", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", maKhach);
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
        public static DataTable TimKiemNgayViPham(string ngayViPham)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TimKiemNgayKetThuc", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ngayvipham", ngayViPham);
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
    }
}
