using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DAL_;
using _DTO_;
using System.Data;
using System.Data.SqlClient;

namespace _2BUS_
{
    public static class _8_HoaDon_BUS
    {
        public static DataTable DanhSachHoaDonDaThu()
        {
            try
            {
                return HoaDon_DAL.DanhSachHoaDonDaThu();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static DataTable DanhSachHoaDonChuaThu()
        {
            try
            {
                return HoaDon_DAL.DanhSachHoaDonChuaThu();
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
                return HoaDon_DAL.DanhSachHoaDonChuaThuTheoNgayXuat(ngayXuat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }
        public static DataTable DanhSachHoaDonDaThuTheoNgayXuat(string ngayXuat)
        {
            try
            {
                return HoaDon_DAL.DanhSachHoaDonDaThuTheoNgayXuat(ngayXuat);
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
                return HoaDon_DAL.TimKiemHoaDon(maPhong);
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
                return HoaDon_DAL.ThemHoaDon(hoaDon);
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
                return HoaDon_DAL.SuaHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool XoaHoaDon(string maHD)
        {
            try
            {
                return HoaDon_DAL.XoaHoaDon(maHD);
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
                    return HoaDon_DAL.KiemTraTonTaiHoaDon(maKhach, ngayBatDau, ngayKetThuc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }
        public static string TinhTranHoaDon(string maKhach)
        {
            try
            {
                return HoaDon_DAL.TinhTrangHoaDon(maKhach);
            }
            catch(Exception ex)
            {
                return $"Loi: {ex.Message}";
            }
        }
    }
}
