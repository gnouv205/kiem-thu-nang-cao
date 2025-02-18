using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _1DAL_;
using _2BUS_;
using _DTO_;

namespace Unitest
{
    public static class DangNhapTest
    {
        public static bool KiemTraDauVao(Nguoi_Dung_DTO nguoiDung)
        {
            if (string.IsNullOrWhiteSpace(nguoiDung.Email) || string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
            {
                return false;
            }
            return true;
        }
        public static bool KiemTraDinhDang(Nguoi_Dung_DTO nguoiDung)
        {
            // Kiểm tra định dạng email hợp lệ
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(nguoiDung.Email, emailPattern))
            {
                return false;
            }
            return true;
        }

        public static bool KiemTraTonTai(Nguoi_Dung_DTO nguoiDung)
        {
            try
            {
                int sodienthoai = 0123456789;
                return _1_DangNhap_BUS.KiemTraTonTai(nguoiDung.Email, sodienthoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return false;
            }
        }

    }

}
