using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unitest;
using _DTO_;
using _2BUS_;

namespace DangNhapTest
{
    [TestClass]
    public class DangNhapHelperTests
    {
        // test case 1: đăng nhập với thông tin hợp lệ
        [TestMethod]
        public void KiemTraDauVao_EmailVaPasswordHopLe_ReturnsTrue()
        {
            var Login = new Nguoi_Dung_DTO { Email = "test@example.com", MatKhau = "password123" };
            bool result = Unitest.DangNhapTest.KiemTraDauVao(Login);
            Assert.IsTrue(result,"Đăng nhập thanh công");
        }

        // test case 2: đăng nhập với eamil không tồn tại
        [TestMethod]
        public void KiemTraDauVao_EmailKhongTonTai_ReturnsFalse()
        {
            var testEmail = new Nguoi_Dung_DTO { Email = "nonexistent@example.com" };
            bool result = Unitest.DangNhapTest.KiemTraTonTai(testEmail);

            Assert.IsFalse(result, "Email này không tồn tại");
        }

        // test case 3: đăng nhập với eamil rỗng
        [TestMethod]
        public void KiemTraDauVao_EmailRong_ReturnsFalse()
        {
            var Login = new Nguoi_Dung_DTO { Email = "", MatKhau = "password123" };
            bool result = Unitest.DangNhapTest.KiemTraDauVao(Login);
            //Assert: Kết quả phải là false, vì email rỗng không được phép đăng nhập
            Assert.IsFalse(result, "Email không thể bỏ trống");
        }

        // test case 4: đăng nhập với password rỗng
        [TestMethod]
        public void KiemTraDauVao_PasswordRong_ReturnsFalse()
        {
            var Login = new Nguoi_Dung_DTO { Email = "test@example.com", MatKhau = "" };
            bool result = Unitest.DangNhapTest.KiemTraDauVao(Login);
            //Assert: Kết quả phải là false, vì Password rỗng không được phép đăng nhập
            Assert.IsFalse(result, "PassWord không thể bỏ trống");
        }

        // test case 5: đăng nhập với eamil không đúng định dạng
        [TestMethod]
        public void KiemTraDauVao_EmailSaiDinhDang_ReturnsFalse()
        {
            var Login = new Nguoi_Dung_DTO { Email = "testexample", MatKhau = "password123" };
            bool result = Unitest.DangNhapTest.KiemTraDinhDang(Login);

            //Assert: Kết quả phải là false, vì email sai định dạng không được phép đăng nhập
            Assert.IsFalse(result, "Email sai định dạng");
        }

        // test case 6: đăng nhập với eamil và password rỗng
        [TestMethod]
        public void KiemTraDauVao_EmailVaPasswordRong_ReturnsFalse()
        {
            var Login = new Nguoi_Dung_DTO { Email = "", MatKhau = "" };
            bool result = Unitest.DangNhapTest.KiemTraDauVao(Login);
            Assert.IsFalse(result, "Email và password không thể bỏ trống");
        }

  
    }
}
