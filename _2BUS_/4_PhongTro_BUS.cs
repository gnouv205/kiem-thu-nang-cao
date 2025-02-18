using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DAL_;
using _DTO_;

namespace _2BUS_
{
    public static class PhongTro_BUS
    {       
        public static DataTable DanhSachMaPhong()
        {
            try
            {
                return PhongTro_DAL.DanhSachMaPhong();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachPhongTrong()
        {
            try
            {
                return PhongTro_DAL.TaiDanhSachPhongTrong();
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
                return PhongTro_DAL.TaiDanhSachPhongDaThue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachPhongKhongSuDung()
        {
            try
            {
                return PhongTro_DAL.TaiDanhSachPhongKhongSuDung();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable TimKiemTenPhong(string tenphong)
        {
            try
            {
                return PhongTro_DAL.TimKiemTenPhong(tenphong);
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
                return PhongTro_DAL.ThemPhong(phongtro);
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
                return PhongTro_DAL.SuaPhong(phongtro);
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
                return PhongTro_DAL.XoaPhong(maphong);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return false;
            }
        }

        public static bool KiemTraTonTai(string tenphong)
        {
            try
            {
                return PhongTro_DAL.KiemTraTonTai(tenphong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static string TinhTrangPhong(string maphong)
        {
            try
            {
                return PhongTro_DAL.TinhTrangPhong(maphong);
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
                return PhongTro_DAL.HienTrangPhong(maphong);
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
                return PhongTro_DAL.DanSachGiaPhong(maphong);
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }
    }
}
