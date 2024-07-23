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
        public static DataTable DanhSachKhachThue()
        {
            try
            {
                return KhachThue_DAL.DanhSachKhachThue();
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

        public static bool XoaKhach(string makhach)
        {
            try
            {
                return KhachThue_DAL.XoaKhach(makhach);
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
                return KhachThue_DAL.KiemTraTonTaiKhach(tenkhach);
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
