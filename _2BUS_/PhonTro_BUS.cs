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
    public static class PhonTro_BUS
    {
        public static DataTable TaiDanhSachPhong()
        {
            try
            {
                return PhongTro_DAL.TaiDanhSachPhong();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
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
    }
}
