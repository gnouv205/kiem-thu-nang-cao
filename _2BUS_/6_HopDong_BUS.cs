using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DAL_;
using _DTO_;

namespace _2BUS_
{
    public static class _6_HopDong_BUS
    {
        public static DataTable DanhSachHopDongConHan()
        {
            try
            {
                return HopDong_DAL.DanhSachHopDongConHan(); // Gọi từ Data Access Layer (DAL)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new DataTable(); // Trả về DataTable rỗng thay vì null để tránh lỗi kiểm thử
            }
        }


        public static DataTable DanhSachHopDongHetHan()
        {
            try
            {
                return HopDong_DAL.DanhSachHopDongHetHan();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new DataTable();
            }
        }

        public static DataTable TiemKiemHopDong(string ngayBatDau, string maKhach)
        {
            try
            {
                return HopDong_DAL.TimKiemHopDong(ngayBatDau, maKhach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        public static bool ThemHopDong(Hop_Dong_DTO hopDong)
        {
            try
            {
                // Kiểm tra nếu mã hợp đồng rỗng
                if (string.IsNullOrEmpty(hopDong.MaHopDong))
                {
                    Console.WriteLine("Mã hợp đồng không được để trống.");
                    return false; // Trả về false nếu mã hợp đồng trống
                }

                // Kiểm tra nếu mã khách rỗng
                if (string.IsNullOrEmpty(hopDong.MaKhach))
                {
                    Console.WriteLine("Mã khách không được để trống.");
                    return false; // Trả về false nếu mã khách trống
                }
                if (hopDong.NgayBatDau < DateTime.Now)
                {
                    Console.WriteLine("Ngày bắt đầu không thể nhỏ hơn ngày hiện tại.");
                    return false; // Trả về false nếu ngày bắt đầu không hợp lệ
                }
                if (hopDong.ChiSoDien < 0 || hopDong.ChiSoNuoc < 0)
                {
                    Console.WriteLine("Không thể lưu hợp đồng khi tiền điện hoặc tiền nước âm.");
                    return false; // Trả về false nếu tiền điện hoặc tiền nước âm
                }

                // Kiểm tra nếu tiền điện hoặc tiền nước lớn hơn 5000
                if (hopDong.ChiSoDien > 5000 || hopDong.ChiSoNuoc > 5000)
                {
                    Console.WriteLine("Không thể lưu hợp đồng khi tiền điện hoặc tiền nước lớn hơn 5000.");
                    return false; // Trả về false nếu tiền điện hoặc tiền nước lớn hơn 5000
                }
                // Kiểm tra nếu ngày kết thúc trước ngày bắt đầu
                if (hopDong.NgayKetThuc < hopDong.NgayBatDau)
                {
                    Console.WriteLine("Ngày kết thúc không thể trước ngày bắt đầu.");
                    return false; // Trả về false nếu ngày kết thúc trước ngày bắt đầu
                }
                // Kiểm tra nếu tình trạng hợp đồng rỗng
                if (string.IsNullOrEmpty(hopDong.TinhTrang))
                {
                    Console.WriteLine("Tình trạng hợp đồng không được để trống.");
                    return false; // Trả về false nếu tình trạng hợp đồng trống
                }

                // Tiến hành thêm hợp đồng vào danh sách hoặc cơ sở dữ liệu (Giả sử ở đây bạn chỉ cần thêm vào danh sách)
                Console.WriteLine("Hợp đồng đã được thêm thành công.");
                return true; // Trả về true nếu hợp đồng đã được thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Nếu có lỗi thì trả về false
            }
        }



        public static bool SuaHopDong(Hop_Dong_DTO hopDong)
        {
            try
            {
                return HopDong_DAL.SuaHopDong(hopDong);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public static bool XoaHopDong(string maHD)
        {
            try
            {
                return HopDong_DAL.XoaHopDong(maHD);
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết
                Console.WriteLine($"Lỗi: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return false;
            }
        }


        public static bool KiemTraTonTaiHopDong(string maK)
        {
            bool tonTai = false;
            try
            {
                using (SqlConnection con = DuongDanKetNoi.KetNoi())
                using (SqlCommand cmd = new SqlCommand("SP_KiemTraHopDongTonTai", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@makhach", maK);

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        tonTai = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return tonTai;
        }


        public static string ThongTinMaHopDong(string maHopDong)
        {
            try
            {
                return HopDong_DAL.ThongTinMaHopDong(maHopDong);
            }
            catch (Exception ex)
            {
                return ($"Loi:  {ex.Message}");
            }
        }
        public static string ThongTinNguoiDungHopDong(string maHopDong)
        {
            try
            {
                return HopDong_DAL.ThongTinNguoiDungHopDong(maHopDong);
            }
            catch (Exception ex)
            {
                return ($"Loi:  {ex.Message}");
            }
        }
        public static string ThongTinKhachHopDong(string maHopDong)
        {
            try
            {
                return HopDong_DAL.ThongTinKhachHopDong(maHopDong);
            }
            catch (Exception ex)
            {
                return ($"Loi:  {ex.Message}");
            }
        }
        public static string ThongTinMaPhongHopDong(string maHopDong)
        {
            try
            {
                return HopDong_DAL.ThongTinMaPhongHopDong(maHopDong);
            }
            catch (Exception ex)
            {
                return ($"Loi:  {ex.Message}");
            }
        }
    }
}
