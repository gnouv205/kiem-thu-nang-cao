using _1DAL_;
using _DTO_;
using _2BUS_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitest
{
    public static class DoiMatKhauTest
    {
        // kiểm tra đầu vào
        public static bool KiemTraDauVao(Nguoi_Dung_DTO nguoiDung, string newPass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(nguoiDung.Email) || string.IsNullOrWhiteSpace(nguoiDung.MatKhau) || string.IsNullOrWhiteSpace(confirmPass) || string.IsNullOrWhiteSpace(newPass))
            {
                return false;
            }
            return true;
        }

        // xác thức mật khẩu
        public static bool MatKhauMoiXacThuc(string newPass, string confirmPass)
        {
            if(confirmPass != newPass) 
                return false;
            return true;
        }
        public static bool DoDaiMatKhau(string newPass)
        {
            if (newPass.Length <= 3)
                return false;
            return true;
        }

        // giả lập dữ liệu trong database
        public static Dictionary<string, string> _giaLapDatabase = new Dictionary<string, string>();

        public static void GiaLapMatKhau(string email, string hashedPassword)
        {
             _giaLapDatabase[email] = hashedPassword; // Lưu mật khẩu giả lập
        }

        public static bool KiemTraMatKhauCu(string email, string oldPass)
        {
            return _giaLapDatabase.ContainsKey(email) && _giaLapDatabase[email] == _1_DangNhap_BUS.encryption(oldPass);
        }

        public static bool CapNhatMatKhau(string email, string oldPass, string newPass)
        {
            string oldPassHash = _1_DangNhap_BUS.encryption(oldPass); // Mã hóa mật khẩu cũ trước khi so sánh

            if (!_giaLapDatabase.ContainsKey(email) || _giaLapDatabase[email] != oldPassHash)
            {
                return false; // Trả về false nếu mật khẩu cũ không đúng
            }

            // Cập nhật mật khẩu mới
            _giaLapDatabase[email] = _1_DangNhap_BUS.encryption(newPass);
            return true;
        }
    }
}
