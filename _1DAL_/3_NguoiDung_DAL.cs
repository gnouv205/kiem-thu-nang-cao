using System;
using System.Data;
using System.Data.SqlClient;
using _DTO_;

namespace _1DAL_
{
    public static class NguoiDung_DAL
    {
        // hàm để thực hiện chức năng ExecuteNonQuery
        private static bool ExecuteNonQuery(string proc, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi()) 
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
                Console.WriteLine($"Lỗi: { ex.Message}");
            }
            return false;
        }

        private static DataTable TaiDanhSachNguoiDung(string proc)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable DanhSachNguoiDung = new DataTable();
                    DanhSachNguoiDung.Load(cmd.ExecuteReader());
                    return DanhSachNguoiDung;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachNguoiDungHoatDong()
        {
            try
            {
                return TaiDanhSachNguoiDung("SP_DanhSachNguoiDung");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachNguoiDungNgungHoatDong()
        {
            try
            {
                return TaiDanhSachNguoiDung("SP_DanhSachNguoiDungNgungHoatDong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static DataTable TimKiemTaiKHoan(string tennguoidung, string sodienthoai)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TimKiemTaiKhoan", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tennguoidung", tennguoidung);
                    cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    DataTable TimTK = new DataTable();
                    TimTK.Load(cmd.ExecuteReader());
                    con.Close();
                    return TimTK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static bool ThemTaiKhoan(Nguoi_Dung_DTO nguoidung)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter ("@tennguoidung",nguoidung.TenNguoiDung),
                    new SqlParameter ("@email",nguoidung.Email),
                    new SqlParameter ("@sodienthoai",nguoidung.SoDT),
                    new SqlParameter ("@diachi",nguoidung.DiaChi),
                    new SqlParameter("@vaitro",nguoidung.VaiTro),
                    new SqlParameter ("@tinhtrang",nguoidung.TinhTrang),
                     new SqlParameter("@matkhau",nguoidung.MatKhau)
                };
                return ExecuteNonQuery("SP_ThemtaiKhoan", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool SuaTaiKhoan(Nguoi_Dung_DTO nguoidung)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter ("@manguoidung",nguoidung.MaNguoiDung),
                    new SqlParameter ("@tennguoidung",nguoidung.TenNguoiDung),
                    new SqlParameter ("@email",nguoidung.Email),
                    new SqlParameter ("@sodienthoai",nguoidung.SoDT),
                    new SqlParameter ("@diachi",nguoidung.DiaChi),
                    new SqlParameter("@vaitro",nguoidung.VaiTro),
                    new SqlParameter ("@tinhtrang",nguoidung.TinhTrang)
                };
                return ExecuteNonQuery("SP_SuaTaiKhoan", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool XoaTaiKhoan(string manguoidung)
        {
            try
            {
                return ExecuteNonQuery("SP_XoaTaiKhoan", new SqlParameter("@manguoidung", manguoidung));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool KiemTraTonTai(string email, int sodienthoai)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraEmailTonTai", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
            return false;
        }
    }
}
