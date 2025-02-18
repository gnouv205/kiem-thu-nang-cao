using _2BUS_;
using _DTO_;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_HoaDon {
    [TestFixture]
    public class Test_HoaDon
    {
        private Hoa_Don_DTO hoaDon;

        [SetUp]
        public void Setup()
        {
            hoaDon = new Hoa_Don_DTO
            {
                MaHoaDon = "HD001",
                MaKhach = "KH001",
                NgayBatDau = "2025-01-01",  // Gán ngày dưới dạng chuỗi
                NgayKetThuc = "2025-02-01", // Gán ngày dưới dạng chuỗi
                TienDien = 100000,
                TienNuoc = 50000,
                TinhTrang = "Chưa thu"
            };
        }

        [Test]
        public void ThemHoaDon_MaHoaDonRong_TraVeFalse()
        {
            hoaDon.MaHoaDon = "";
            bool result = _8_HoaDon_BUS.ThemHoaDon(hoaDon); // Đảm bảo sử dụng đúng tên lớp HoaDon_BUS
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Mã hóa đơn không được để trống!");
        }

        [Test]
        public void ThemHoaDon_TienDienKhongHopLe_TraVeFalse()
        {
            hoaDon.MaHoaDon = "HD002";
            hoaDon.TienDien = -10000; // Giá trị âm
            bool result = _8_HoaDon_BUS.ThemHoaDon(hoaDon); // Đảm bảo sử dụng đúng tên lớp HoaDon_BUS
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Tiền điện phải là giá trị dương!");
        }

        [Test]
        public void ThemHoaDon_TienNuocKhongHopLe_TraVeFalse()
        {
            hoaDon.MaHoaDon = "HD003";
            hoaDon.TienNuoc = 0; // Tiền nước không hợp lệ
            bool result = _8_HoaDon_BUS.ThemHoaDon(hoaDon); // Đảm bảo sử dụng đúng tên lớp HoaDon_BUS
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Tiền nước phải lớn hơn 0!");
        }

        [Test]
        public void ThemHoaDon_NgayKetThucTruocNgayBatDau_TraVeFalse()
        {
            hoaDon.MaHoaDon = "HD004";
            hoaDon.NgayBatDau = "2025-02-01"; // Ngày bắt đầu dưới dạng chuỗi
            hoaDon.NgayKetThuc = "2025-01-01"; // Ngày kết thúc dưới dạng chuỗi
            bool result = _8_HoaDon_BUS.ThemHoaDon(hoaDon); // Đảm bảo sử dụng đúng tên lớp HoaDon_BUS
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Ngày kết thúc không thể nhỏ hơn ngày bắt đầu!");
        }

        [Test]
        public void CapNhatTinhTrangHoaDon_TinhTrangKhongChon_TraVeFalse()
        {
            hoaDon.MaHoaDon = "HD005";
            hoaDon.TinhTrang = "";
            bool result = _8_HoaDon_BUS.SuaHoaDon(hoaDon); // Đảm bảo sử dụng đúng tên lớp HoaDon_BUS
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Tình trạng hóa đơn phải được chọn!");
        }

        [Test]
        public void KiemTraTonTaiHoaDon_HoaDonKhongTonTai_TraVeFalse()
        {
            string maHoaDon = "HD999";
            string ngayBatDau = "2025-01-01";  // Cung cấp ngày bắt đầu
            string ngayKetThuc = "2025-02-01"; // Cung cấp ngày kết thúc

            bool result = _8_HoaDon_BUS.KiemTraTonTaiHoaDon(maHoaDon, ngayBatDau, ngayKetThuc);
            NUnit.Framework.Assert.That(result, Is.False, "❌ Lỗi: Hóa đơn không tồn tại!");
        }
    }
}
