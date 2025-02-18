using NUnit.Framework;
using System;

namespace ThongKeHoaDonTests
{
    [TestFixture]
    public class ThongKeHoaDonTests
    {
        // Kiểm tra tình trạng hóa đơn chưa thanh toán
        [Test]
        public void Test_KiemTraHoaDonChuaThanhToan()
        {
            // Bước 1: Nhập mã khách hàng
            var maKhachHang = "KH12345";

            // Bước 2: Nhấn nút "Kiểm tra"
            var ketQua = KiemTraHoaDon(maKhachHang); // Giả sử đây là phương thức kiểm tra hóa đơn chưa thanh toán

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(ketQua.IsChuaThanhToan, "Hóa đơn chưa thanh toán nhưng kết quả không đúng.");
        }

        // Kiểm tra nhập nội dung vi phạm trống
        [Test]
        public void Test_NhapNoiDungViPhamTrong()
        {
            // Bước 1: Để trống trường txtNoiDung
            var noiDung = "";

            // Bước 2: Nhấn nút "Lưu"
            var ketQua = LuuViPham(noiDung); // Giả sử đây là phương thức lưu vi phạm

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Nội dung không thể trống nhưng không xuất hiện lỗi.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Nội dung không được để trống", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }

        // Kiểm tra biện pháp xử lý trống
        [Test]
        public void Test_NhapBienPhapTruocKhiLuu()
        {
            // Bước 1: Để trống trường txtBienPhap
            var bienPhap = "";

            // Bước 2: Nhấn nút "Lưu"
            var ketQua = LuuBienPhap(bienPhap); // Giả sử đây là phương thức lưu biện pháp xử lý

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Biện pháp xử lý không thể trống nhưng không xuất hiện lỗi.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Biện pháp xử lý không được để trống", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }

        // Kiểm tra biện pháp xử lý trống với ngày hủy ngoài 7 ngày từ ngày vi phạm
        [Test]
        public void Test_BienPhapVoiNgayHuyNgoai7Ngay()
        {
            // Bước 1: Nhập ngày hủy là "30/01/2025" (vượt quá 7 ngày so với ngày vi phạm)
            var ngayViPham = new DateTime(2025, 1, 23);
            var ngayHuy = new DateTime(2025, 2, 1);  // Đây là ngày hủy quá 7 ngày (từ 23/01 đến 01/02 là 9 ngày)

            // Bước 2: Gọi phương thức xử lý biện pháp
            var ketQua = LuuBienPhapVoiNgayHuy(ngayViPham, ngayHuy);

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Ngày hủy không được quá 7 ngày từ ngày vi phạm.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Ngày hủy phải trong vòng 7 ngày kể từ ngày vi phạm", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }


        // Kiểm tra bồi thường không phải số
        [Test]
        public void Test_BoiThuongKhongPhaiSo()
        {
            // Bước 1: Nhập giá trị "ABC" vào trường txtBoiThuong
            var boiThuong = "ABC";

            // Bước 2: Nhấn nút "Lưu"
            var ketQua = LuuBoiThuong(boiThuong); // Giả sử đây là phương thức lưu bồi thường

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Bồi thường phải là số nhưng không xuất hiện lỗi.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Bồi thường phải là một số", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }

        // Kiểm tra tình trạng chưa hủy khi lập bảng hủy
        [Test]
        public void Test_TinhTrangChuaHuyKhiLapBangHuy()
        {
            // Bước 1: Chọn trạng thái "Hủy" thay vì "Chưa Hủy"
            var trangThai = "Hủy";

            // Bước 2: Nhấn nút "Lập bảng"
            var ketQua = LapBangHuy(trangThai);

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Trạng thái phải là 'Chưa Hủy' trước khi lập bảng.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Chỉ được lập bảng khi trạng thái là 'Chưa Hủy'", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }

        // Kiểm tra phương thức tìm kiếm không chọn
        [Test]
        public void Test_KiemTraTimKiemKhongChonPhuongThuc()
        {
            // Bước 1: Không chọn bất kỳ phương thức tìm kiếm nào
            var phuongThucTimKiem = "";

            // Bước 2: Nhấn nút "Tìm"
            var ketQua = TimKiem(phuongThucTimKiem); // Giả sử đây là phương thức tìm kiếm

            // Kiểm tra kết quả
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(ketQua.IsSuccess, "Cần phải chọn phương thức tìm kiếm.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Phương thức tìm kiếm không được để trống", ketQua.ErrorMessage, "Thông báo lỗi không chính xác.");
        }

        // Giả sử đây là các phương thức giả lập xử lý của bạn
        private dynamic KiemTraHoaDon(string maKhachHang)
        {
            // Logic kiểm tra hóa đơn
            return new { IsChuaThanhToan = true };
        }

        private dynamic LuuViPham(string noiDung)
        {
            if (string.IsNullOrEmpty(noiDung))
            {
                return new { IsSuccess = false, ErrorMessage = "Nội dung không được để trống" };
            }

            return new { IsSuccess = true };
        }

        private dynamic LuuBienPhap(string bienPhap)
        {
            if (string.IsNullOrEmpty(bienPhap))
            {
                return new { IsSuccess = false, ErrorMessage = "Biện pháp xử lý không được để trống" };
            }

            return new { IsSuccess = true };
        }

        private dynamic LuuBienPhapVoiNgayHuy(DateTime ngayViPham, DateTime ngayHuy)
        {
            if ((ngayHuy - ngayViPham).Days > 7)
            {
                return new { IsSuccess = false, ErrorMessage = "Ngày hủy phải trong vòng 7 ngày kể từ ngày vi phạm" };
            }

            return new { IsSuccess = true };
        }

        private dynamic LuuBoiThuong(string boiThuong)
        {
            if (!decimal.TryParse(boiThuong, out _))
            {
                return new { IsSuccess = false, ErrorMessage = "Bồi thường phải là một số" };
            }

            return new { IsSuccess = true };
        }

        private dynamic LapBangHuy(string trangThai)
        {
            if (trangThai == "Hủy")
            {
                return new { IsSuccess = false, ErrorMessage = "Chỉ được lập bảng khi trạng thái là 'Chưa Hủy'" };
            }

            return new { IsSuccess = true };
        }

        private dynamic TimKiem(string phuongThucTimKiem)
        {
            if (string.IsNullOrEmpty(phuongThucTimKiem))
            {
                return new { IsSuccess = false, ErrorMessage = "Phương thức tìm kiếm không được để trống" };
            }

            return new { IsSuccess = true };
        }
    }
}
