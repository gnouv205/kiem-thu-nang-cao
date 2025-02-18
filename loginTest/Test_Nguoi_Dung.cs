using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using _2BUS_;
using _DTO_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Nguoi_Dung
{
    [TestFixture]
    internal class Test_NguoiDung
    {
        [Test]
        public void TC050_ThemNguoiDung_TenRong_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 1,
                MaNguoiDung = "ND001",
                TenNguoiDung = "",
                Email = "test@example.com",
                SoDT = 987654321,
                DiaChi = "Hà Nội",
                VaiTro = "User",
                TinhTrang = "Active",
                MatKhau = "password123"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Tên người dùng không được để trống.");
        }

        [Test]
        public void TC051_ThemNguoiDung_EmailRong_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 2,
                MaNguoiDung = "ND002",
                TenNguoiDung = "Nguyen Van A",
                Email = "",
                SoDT = 987654321,
                DiaChi = "Hồ Chí Minh",
                VaiTro = "Admin",
                TinhTrang = "Inactive",
                MatKhau = "admin123"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Email không được để trống.");
        }

        [Test]
        public void TC052_ThemNguoiDung_EmailKhongHopLe_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 3,
                MaNguoiDung = "ND003",
                TenNguoiDung = "Le Van B",
                Email = "example.com", // Email không hợp lệ
                SoDT = 987654321,
                DiaChi = "Đà Nẵng",
                VaiTro = "User",
                TinhTrang = "Active",
                MatKhau = "user456"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Email không hợp lệ.");
        }

        [Test]
        public void TC053_ThemNguoiDung_EmailDaTonTai_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 4,
                MaNguoiDung = "ND004",
                TenNguoiDung = "Tran Thi C",
                Email = "nguyen.vana@example.com", // Email đã tồn tại
                SoDT = 987654321,
                DiaChi = "Hải Phòng",
                VaiTro = "Manager",
                TinhTrang = "Active",
                MatKhau = "admin456"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Email đã tồn tại trong hệ thống.");
        }

        [Test]
        public void TC054_ThemNguoiDung_SoDienThoaiKhongHopLe_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 5,
                MaNguoiDung = "ND005",
                TenNguoiDung = "Pham Van D",
                Email = "phamvand@example.com",
                SoDT = 9876, // Số điện thoại không đủ 10 số
                DiaChi = "Cần Thơ",
                VaiTro = "User",
                TinhTrang = "Active",
                MatKhau = "user123"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Số điện thoại không hợp lệ.");
        }

        [Test]
        public void TC055_ThemNguoiDung_DiaChiQuaNgan_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 6,
                MaNguoiDung = "ND006",
                TenNguoiDung = "Le Thi E",
                Email = "lethie@example.com",
                SoDT = 987654321,
                DiaChi = "HCM", // Địa chỉ ngắn hơn 10 ký tự
                VaiTro = "User",
                TinhTrang = "Active",
                MatKhau = "user789"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Địa chỉ phải có ít nhất 10 ký tự.");
        }

        [Test]
        public void TC056_ThemNguoiDung_KhongChonVaiTro_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 7,
                MaNguoiDung = "ND007",
                TenNguoiDung = "Nguyen Van F",
                Email = "nguyenvanf@example.com",
                SoDT = 987654321,
                DiaChi = "Đà Lạt",
                VaiTro = "", // Không chọn vai trò
                TinhTrang = "Active",
                MatKhau = "user999"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Vai trò không được để trống.");
        }

        [Test]
        public void TC057_ThemNguoiDung_KhongChonTinhTrang_TraVeFalse()
        {
            var nguoiDung = new Nguoi_Dung_DTO
            {
                Id = 10,
                MaNguoiDung = "ND010",
                TenNguoiDung = "Nguyen Van B",
                Email = "nguyenvanb@example.com",
                SoDT = 0912345678,
                DiaChi = "456 Đường XYZ, Quận 2, TP.HCM",
                VaiTro = "Admin",
                TinhTrang = "Hoạt động",
                MatKhau = "ValidPass123"
            };

            bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Tình trạng hoạt động không được để trống.");
        }

        [Test]
        public void TC058_KiemTraTimKiemNguoiDung_TenRong_TraVeFalse()
        {
            bool result = NguoiDung_BUS.KiemTraTonTai("", 0); // truyền 0 hoặc số điện thoại bất kỳ
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Không thể tìm kiếm nếu không nhập tên.");
        }


        [Test]
        public void TC059_KiemTraKhongTheXoaNguoiDungMacDinh_TraVeFalse()
        {
            bool result = NguoiDung_BUS.XoaTaiKhoan("ND_0001");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Không thể xóa người dùng mặc định.");
        }

        //[Test]
        //public void TC060_KiemTraNhapThongTinNguoiDungHopLe_TraVeTrue()
        //{
        //    var nguoiDung = new Nguoi_Dung_DTO
        //    {
        //        Id = 9,
        //        MaNguoiDung = "ND009",
        //        TenNguoiDung = "Nguyen Van tri",
        //        Email = "nguyen.vana@example.com",
        //        SoDT = 5,
        //        DiaChi = "123 Đường ABC, Quận 1, TP.HCM",
        //        VaiTro = "Nhân viên",
        //        TinhTrang = "Đang hoạt động",
        //        MatKhau = "validPassword"
        //    };

        //    // Gọi phương thức thêm tài khoản
        //    bool result = NguoiDung_BUS.ThemTaiKhoan(nguoiDung);

        //    // Kiểm tra kết quả
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result, "Thông tin người dùng hợp lệ nhưng không được chấp nhận.");
        //}


    }
}
