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
    public static class KhachThue_BUS
    {
        public static DataTable DanhSachKhachConThue()
        {
            try
            {
                return KhachThue_DAL.DanhSachKhachConThue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static string DanhSachMaPhongCuaKhach(string makhach)
        {
            try
            {
                return KhachThue_DAL.DanSachMaPhongCuaKhach(makhach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachKhachHetHan()
        {
            try
            {
                return KhachThue_DAL.DanhSachKhachHetHan();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachMaKhach()
        {
            try
            {
                return KhachThue_DAL.DanhSachMaKhach();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable TimKiemKhachThue(string tenkhach)
        {
            try
            {
                return KhachThue_DAL.TimKiemKhachThue(tenkhach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static bool ThemKhach(Khach_Thue_DTO khach)
        {
            try
            {
                return KhachThue_DAL.ThemKhach(khach);
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
                return KhachThue_DAL.SuaKhach(khach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool XoaKhach(string makhach,string maphong)
        {
            try
            {
                return KhachThue_DAL.XoaKhach(makhach, maphong);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return false;
        }

        public static bool KiemTraTonTaiKhach(string tenkhach, string cccd)
        {
            try
            {
                return KhachThue_DAL.KiemTraTonTaiKhach(tenkhach, cccd);
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
                return KhachThue_DAL.TinhTrangKhach(makhach);
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }
    }
}
