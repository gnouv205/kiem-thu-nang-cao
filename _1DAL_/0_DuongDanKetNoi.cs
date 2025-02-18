using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DAL_
{
    public static class DuongDanKetNoi
    {
        public static SqlConnection KetNoi()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BE27PHRL\SQLEXPRESS;Initial Catalog=QuanLyNhaTro;User ID=sa;Password=12345");
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi khi kết nối với cơ sở dữ liệu: " + ex.Message);
                return null;
            }
        }
    }
}
