using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _1DAL_;
using _DTO_;

namespace _2BUS_
{
    public static class _1_DangNhap_BUS
    {
        // ma hoa
        public static string encryption(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryption;
            UTF8Encoding uTF8 = new UTF8Encoding();
            encryption = md5.ComputeHash(uTF8.GetBytes(pass));
            StringBuilder encryptiondata = new StringBuilder();
            for (int i = 0; i < encryption.Length; i++)
            {
                encryptiondata.Append(encryption[i].ToString());
            }
            return encryptiondata.ToString();
        }

        // them
        public static bool KiemTraTonTai(string email, int sodienthoai)
        {
            return NguoiDung_DAL.KiemTraTonTai(email, sodienthoai);
        }

        public static string LayVaiTroNhanVien(string email)
        {
            try
            {
                return _1_DangNhap_DAL.LayVaiTroNguoiDung(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return null;
            }
        }

        public static bool NguoiDungDangNhap(Nguoi_Dung_DTO nguoidung)
        {
            return _1_DangNhap_DAL.NguoiDungDangNhap(nguoidung);
        }


        #region Quen Mat Khau

        public static bool QuenMatKhau(string email)
        {
            try
            {
                return _1_DangNhap_DAL.QuenMatKhau(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: { ex.Message}");
                return false;
            }
        }

        public static void TaoMatKhauMoi(string email, string newpass)
        {
            try
            {
                _1_DangNhap_DAL.TaoMatKhauMoi(email, newpass);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        public static string RandomString(int size, bool LowerCase)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                Random rand = new Random();
                char kytu;
                for (int i = 0; i < size; i++)
                {
                    kytu = (char)rand.Next(65, 91);
                    builder.Append(kytu);
                }
                if (LowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return " ";
            }
        }

        public static int RandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        public static void SendMail(string email, string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                NetworkCredential cred = new NetworkCredential("thinhcqps37749@fpt.edu.vn", "xcum nptg dyzz uecg");

                MailMessage msg = new MailMessage();

                msg.From = new MailAddress(email);

                msg.To.Add(email);

                msg.Subject = "Chào Mừng Bạn Đến Với Quản Lý Nhà Trọ";

                msg.Body = "Chào anh/chị. Mật khẩu mới của anh chị để truy cập phần mềm là: " + matkhau;

                client.Credentials = cred;

                client.EnableSsl = true;

                client.Send(msg);
            }
            catch (Exception ex)
            {
                string result = ex.Message;
            }
        }
        #endregion
    }
}
