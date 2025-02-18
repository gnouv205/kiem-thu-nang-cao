using NUnit.Framework;
using _2BUS_;
using _DTO_;
using System;

namespace HopDongBusTests
{
    [TestFixture]
    public class HopDongTests
    {
        [Test]
        public void KiemTraKhongNhapMaHopDong()
        {
            // Bỏ trống mã hợp đồng
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "", // Mã hợp đồng trống
                MaKhach = "KH001",
                MaPhong = "P001",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2025, 12, 31),
                ChiSoDien = 100,
                ChiSoNuoc = 50,
                TienCoc = 2000000,
                TienThue = 100000,
                TinhTrang = "Còn Hạn"
            };

            // Gọi phương thức với đối tượng hopDong
            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            // Kiểm tra xem kết quả có đúng như mong đợi không
            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng khi mã hợp đồng không được nhập.");
        }

        [Test]
        public void KiemTraTienDienTienNuocAm()
        {
            // Nhập giá trị âm cho tiền điện và tiền nước
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ002",
                MaKhach = "KH002",
                MaPhong = "P002",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2025, 12, 31),
                ChiSoDien = -100, // Tiền điện âm
                ChiSoNuoc = -50, // Tiền nước âm
                TienCoc = 3000000,
                TienThue = 150000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng với tiền điện và tiền nước âm.");
        }

        [Test]
        public void KiemTraTienDienTienNuocLonHon5000()
        {
            // Nhập tiền điện và tiền nước lớn hơn 5000
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ003",
                MaKhach = "KH003",
                MaPhong = "P003",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2025, 12, 31),
                ChiSoDien = 6000, // Tiền điện > 5000
                ChiSoNuoc = 5500, // Tiền nước > 5000
                TienCoc = 4000000,
                TienThue = 200000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng với tiền điện và tiền nước lớn hơn 5000.");
        }

        [Test]
        public void KiemTraNgayBatDauKhongHopLe()
        {
            // Chọn ngày bắt đầu nhỏ hơn ngày hiện tại
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ004",
                MaKhach = "KH004",
                MaPhong = "P004",
                NgayBatDau = DateTime.Now.AddDays(-1), // Ngày bắt đầu nhỏ hơn hiện tại
                NgayKetThuc = new DateTime(2025, 12, 31),
                ChiSoDien = 100,
                ChiSoNuoc = 50,
                TienCoc = 2000000,
                TienThue = 100000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng khi ngày bắt đầu nhỏ hơn ngày hiện tại.");
        }

        [Test]
        public void KiemTraNgayKetThucTruocNgayBatDau()
        {
            // Chọn ngày kết thúc trước ngày bắt đầu
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ005",
                MaKhach = "KH005",
                MaPhong = "P005",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2024, 12, 31), // Ngày kết thúc trước ngày bắt đầu
                ChiSoDien = 100,
                ChiSoNuoc = 50,
                TienCoc = 2000000,
                TienThue = 100000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng khi ngày kết thúc trước ngày bắt đầu.");
        }
        [Test]
        public void ThemHopDongThanhCong_Success()
        {
            // Tạo hợp đồng với tất cả thông tin hợp lệ
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ008",           // Mã hợp đồng hợp lệ
                MaKhach = "KH008",             // Mã khách hợp lệ
                MaPhong = "P008",              // Mã phòng hợp lệ
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2026, 2, 1),   // Ngày kết thúc hợp lệ
                ChiSoDien = 200,               // Chỉ số điện hợp lệ
                ChiSoNuoc = 100,               // Chỉ số nước hợp lệ
                TienCoc = 3000000,             // Tiền cọc hợp lệ
                TienThue = 150000,             // Tiền thuê hợp lệ
                TinhTrang = "Còn Hạn"         // Tình trạng hợp đồng hợp lệ
            };

            // Gọi phương thức thêm hợp đồng
            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            // Kiểm tra xem kết quả có đúng như mong đợi không
            NUnit.Framework.Assert.That(ketQua, Is.True, "Lưu hợp đồng hợp lệ thất bại.");
        }

        [Test]
        public void KiemTraKhongNhapMaKhach()
        {
            // Bỏ trống mã khách
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ007",
                MaKhach = "", // Mã khách trống
                MaPhong = "P007",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2026, 2, 1),
                ChiSoDien = 200,
                ChiSoNuoc = 100,
                TienCoc = 3000000,
                TienThue = 150000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            // Kiểm tra xem kết quả có đúng như mong đợi không
            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng khi mã khách không được nhập.");
        }

        [Test]
        public void KiemTraKhongChonTinhTrangHopDong()
        {
            // Không chọn tình trạng hợp đồng
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ006",
                MaKhach = "KH006",
                MaPhong = "P006",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2025, 12, 31),
                ChiSoDien = 100,
                ChiSoNuoc = 50,
                TienCoc = 2000000,
                TienThue = 100000,
                TinhTrang = "" // Tình trạng hợp đồng trống
            };

            // Gọi phương thức thêm hợp đồng
            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            // Kiểm tra kết quả trả về có phải là false khi tình trạng hợp đồng trống
            NUnit.Framework.Assert.That(ketQua, Is.False, "Không thể lưu hợp đồng khi tình trạng hợp đồng không được chọn.");
        }


        [Test]
        public void KiemTraTatCaDuLieuHopLe()
        {
            // Nhập tất cả dữ liệu hợp lệ
            var hopDong = new Hop_Dong_DTO
            {
                MaHopDong = "HĐ007",
                MaKhach = "KH007",
                MaPhong = "P007",
                NgayBatDau = DateTime.Now.AddDays(+1),
                NgayKetThuc = new DateTime(2026, 10, 10),
                ChiSoDien = 200,
                ChiSoNuoc = 100,
                TienCoc = 3000000,
                TienThue = 150000,
                TinhTrang = "Còn Hạn"
            };

            bool ketQua = _6_HopDong_BUS.ThemHopDong(hopDong);

            NUnit.Framework.Assert.That(ketQua, Is.True, "Lưu hợp đồng hợp lệ thất bại.");
        }
    }
}
