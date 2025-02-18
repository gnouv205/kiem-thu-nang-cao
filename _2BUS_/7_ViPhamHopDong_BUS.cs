using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DTO_;
using _1DAL_;
using System.Data;
using System.Data.SqlClient;

namespace _2BUS_
{
    public static class _7_ViPhamHopDong_BUS
    {
        public static DataTable DanhSachHopDongHuy()
        {
            try
            {
                return ViPhamHopDong_DAL.DanhSachHopDongHuy();
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
                return ViPhamHopDong_DAL.DanhSachHopDongChuaHuy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }
        public static bool HopDongCanHuy(Vi_Pham_Hop_Dong_DTO viPham)
        {
            try
            {
                return ViPhamHopDong_DAL.HopDongCanHuy(viPham);
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
                return ViPhamHopDong_DAL.HopDongXacNhanHuy(viPham);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static DataTable TimKiemMaKhach(string maKhach)
        {
            try
            {
                return ViPhamHopDong_DAL.TimKiemMaKhac(maKhach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }
        public static DataTable TimKiemNgayviPham(string ngayViPham)
        {
            try
            {
                return ViPhamHopDong_DAL.TimKiemNgayViPham(ngayViPham);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }
    }
}
