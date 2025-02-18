using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2BUS_;
using _DTO_;
using System.Threading.Tasks;
using NUnit.Framework;
using _1DAL_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_PhongTro_KhachThue
{
    [TestFixture]
    internal class Test_KhachThue
    {
        [Test]
        public void ThemKhachThue_TenRong_TraVeFalse()
        {
            var khach = new Khach_Thue_DTO { TenKhach = "", CCCD = 123456789, SoDienThoai = "0987654321", TinhTrang = "Đang thuê" };
            bool result = KhachThue_BUS.ThemKhach(khach);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Tên khách thuê không được để trống.");
        }

        [Test]
        public void ThemKhachThue_CCCDKhongHopLe_TraVeFalse()
        {
            var khach = new Khach_Thue_DTO { TenKhach = "Nguyen Van A", CCCD = 12345, SoDienThoai = "0987654321", TinhTrang = "Đang thuê" };
            bool result = KhachThue_BUS.ThemKhach(khach);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "CCCD phải có độ dài từ 9 đến 12 ký tự.");
        }

        [Test]
        public void ThemKhachThue_SDTKhongHopLe_TraVeFalse()
        {
            var khach = new Khach_Thue_DTO { TenKhach = "Nguyen Van B", CCCD = 123456789, SoDienThoai = "1234", TinhTrang = "Đang thuê" };
            bool result = KhachThue_BUS.ThemKhach(khach);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Số điện thoại phải có từ 9 đến 11 số.");
        }

        [Test]
        public void CapNhatTinhTrangKhachThue_TinhTrangKhongChon_TraVeFalse()
        {
            var khach = new Khach_Thue_DTO { TenKhach = "Nguyen Van C", CCCD = 123456789, SoDienThoai = "0987654321", TinhTrang = "" };
            bool result = KhachThue_BUS.SuaKhach(khach);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Khách thuê phải có trạng thái rõ ràng.");
        }
        [Test]
        public void KiemTraMaPhong_KhongTonTai_TraVeFalse()
        {
            bool result = PhongTro_BUS.KiemTraTonTai("P999");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Phòng Không Tồn Tại");
        }
    }
}
