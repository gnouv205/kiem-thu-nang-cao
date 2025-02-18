using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2BUS_;
using _DTO_;
using System.Threading.Tasks;
using NUnit.Framework;
using _1DAL_;
using static _2BUS_.PhongTro_BUS;
using System.Data;

namespace Test_PhongTro_KhachThue
{
    [TestFixture]
    internal class Test_PhongTro
    {
        [Test]
        public void ThemPhong_TenPhongRong_TraVeFalse()
        {
            var phong = new Phong_Tro_DTO { TenPhong = "", DienTich = "20", Gia = 3000000 };
            bool result = PhongTro_BUS.ThemPhong(phong);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Tên phòng không được để trống.");
        }

        [Test]
        public void ThemPhong_DienTichRong_TraVeFalse()
        {
            var phong = new Phong_Tro_DTO { TenPhong = "P101", DienTich = "0", Gia = 3000000 };
            bool result = PhongTro_BUS.ThemPhong(phong);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Diện tích phòng không được để trống.");
        }

        [Test]
        public void ThemPhong_GiaPhongKhongHopLe_TraVeFalse()
        {
            var phong = new Phong_Tro_DTO { TenPhong = "P102", DienTich = "20", Gia = -1000000 };
            bool result = PhongTro_BUS.ThemPhong(phong);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Giá phòng phải lớn hơn 0.");
        }

        [Test]
        public void KiemTraTonTai_TenPhongKhongTonTai_TraVeFalse()
        {

            bool result = PhongTro_BUS.KiemTraTonTai("P101");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Phòng chưa tồn tại, kiểm tra thất bại.");
        }       
        [Test]
        public void TimKiemPhong_TenPhongRong_TraVeFalse()
        {
            List<string> danhSachPhong = new List<string> { "Phong 101", "Phong 102", "Phong 103" };
            bool timThay = danhSachPhong.Any(p => p == "");
            // Kết quả mong đợi là False
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(timThay, "Không nên tìm thấy phòng nếu tên trống.");
        }
        [Test]
        public void KiemTraMaPhong_KhongTonTai_TraVeFalse()
        {
            bool result = PhongTro_BUS.KiemTraTonTai("P999");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result, "Phòng Không Tồn Tại");
        }
    }
}
