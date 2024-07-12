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
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QUOC-TH\SQLSERVER2019;Initial Catalog=QuanLyNhaTro;Integrated Security=True");
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
