using System;
using _1DAL_;
using _DTO_;
using System.Data;
using System.Net.Mail;

namespace _2BUS_
{
    public static class NguoiDung_BUS
    {
        public static DataTable TaiDanhSachNguoiDungHoatDong()
        {
            try
            {
                return NguoiDung_DAL.TaiDanhSachNguoiDungHoatDong();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return null;
            }
        }

        public static DataTable TaiDanhSachNguoiDungNgungHoatDong()
        {
            try
            {
                return NguoiDung_DAL.TaiDanhSachNguoiDungNgungHoatDong();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return null;
            }
        }


        public static DataTable TimKiemTaiKhoan(string tennguoidung, string sodienthoai)
        {
            try
            {
                return NguoiDung_DAL.TimKiemTaiKHoan(tennguoidung, sodienthoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return null;
            }
        }

        public static bool ThemTaiKhoan(Nguoi_Dung_DTO nguoidung)
        {
            try
            {
                return NguoiDung_DAL.ThemTaiKhoan(nguoidung);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return false;
            }
        }

        public static bool SuaTaiKhoan(Nguoi_Dung_DTO nguoidung)
        {
            try
            {
                return NguoiDung_DAL.SuaTaiKhoan(nguoidung);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return false;
            }
        }

        public static bool XoaTaiKhoan(string manguoidung)
        {
            try
            {
                return NguoiDung_DAL.XoaTaiKhoan(manguoidung);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return false;
            }
        }

        public static bool KiemTraTonTai(string email, int sodienthoai)
        {
            try
            {
                return NguoiDung_DAL.KiemTraTonTai(email, sodienthoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi:  {ex.Message}");
                return false;
            }
        }

        // kiểm tra email
        public static bool CheckAddEmail(string emailAdd)
        {
            try
            {
                MailAddress mail = new MailAddress(emailAdd);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
