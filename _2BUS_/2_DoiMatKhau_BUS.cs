using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DAL_;
using _DTO_;

namespace _2BUS_
{
    public static class _2_DoiMatKhau_BUS
    {
        public static bool CapNhatMatKhau(string email, string oldpass, string newpass)
        {
            try
            {
                return _2_DoiMatKhau_DAL.CapNhatMatKhau(email, oldpass, newpass);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return false;
            }
        }
    }
}
