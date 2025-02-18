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
    public static class PhongTro_DAL
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
                Console.WriteLine($"Lỗi: { ex.Message}");
            }
            return false;
        }

        #region Danh Sach Phong

        private static DataTable TaiDanhSachPhong(string proc)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable List = new DataTable();
                    List.Load(cmd.ExecuteReader());
                    return List;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }

        }

        public static DataTable TaiDanhSachPhongTrong()
        {
            try
            {
                return TaiDanhSachPhong("SP_DanhSachPhongTrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachPhongDaThue()
        {
            try
            {
                return TaiDanhSachPhong("SP_DanhSachPhong");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachPhongKhongSuDung()
        {
            try
            {
                return TaiDanhSachPhong("SP_DanhSachPhongKhongSuDung");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return null;
            }
        }


        #endregion

        public static DataTable DanhSachMaPhong()
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_DanhSachMaPhong";
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

        public static DataTable TimKiemTenPhong(string tenphong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TimKiemPhong", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenPhong", tenphong);
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


        public static bool ThemPhong(Phong_Tro_DTO phongtro)
        {
            try
            {
                SqlParameter[] parameter =
                {
                    new SqlParameter ("@tenphong", phongtro.TenPhong),
                     new SqlParameter("@dientich", phongtro.DienTich),
                     new SqlParameter("@gia", phongtro.Gia),
                     new SqlParameter("@tinhtrang", phongtro.TinhTrang),
                     new SqlParameter("@hientrang", phongtro.HienTrang),
                     new SqlParameter("@email", phongtro.Email),
                     new SqlParameter("@ghichu", phongtro.GhiChu)
                };
                return ExecuteNonQuery("SP_ThemPhong", parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return false;
            }
        }

        public static bool SuaPhong(Phong_Tro_DTO phongtro)
        {
            try
            {
                SqlParameter[] parameter =
                {
                    new SqlParameter ("@maphong",phongtro.MaPhong),
                    new SqlParameter ("@tenphong", phongtro.TenPhong),
                     new SqlParameter("@dientich", phongtro.DienTich),
                     new SqlParameter("@gia", phongtro.Gia),
                     new SqlParameter("@tinhtrang", phongtro.TinhTrang),
                     new SqlParameter("@hientrang", phongtro.HienTrang),
                     new SqlParameter("@email", phongtro.Email),
                     new SqlParameter("@ghichu", phongtro.GhiChu)
                };
                return ExecuteNonQuery("SP_SuaPhong", parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return false;
            }
        }

        public static bool XoaPhong(string maphong)
        {
            try
            {
                return ExecuteNonQuery("SP_XoaPhong", new SqlParameter("@maphong", maphong));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool KiemTraTonTai(string tenphong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraTenPhong", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenphong", tenphong);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return false;
            }
            return false;    
        }

        public static string TinhTrangPhong(string maphong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_TinhTrangPhong", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maphong", maphong);
                    string tinhtrang = cmd.ExecuteScalar().ToString();
                    return tinhtrang;
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }

        public static string HienTrangPhong(string maphong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_HienTrangPhong", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maphong", maphong);
                    string tinhtrang = cmd.ExecuteScalar().ToString();
                    return tinhtrang;
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }

        public static string DanSachGiaPhong(string maphong)
        {
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_DanhSachGiaPhong";
                    cmd.Parameters.AddWithValue("@maPhong", maphong);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Giả sử cột trả về có tên là "Gia"
                            return reader["Gia"].ToString();
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
            }
            return null;
        }

    }
}
