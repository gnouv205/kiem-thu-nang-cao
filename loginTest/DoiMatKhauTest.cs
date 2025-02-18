using Microsoft.VisualStudio.TestTools.UnitTesting;
using _DTO_;
using _2BUS_;
using Unitest;


namespace DoiMatKhauTest
{
    [TestClass]
    public class DoiMatKhauHelperTests
    {
        // Test case 1: Đổi mật khẩu với thông tin rong
        [TestMethod]
        public void KiemTraDauVao_RongDuLieu_ReturnsFalse()
        {
            string newPass = "";
            string confirmPass = "";
            var user = new Nguoi_Dung_DTO { Email = "", MatKhau = "" };

            // Kiểm tra đầu vào hợp lệ
            bool dauVaoHopLe = Unitest.DoiMatKhauTest.KiemTraDauVao(user, newPass, confirmPass);
            Assert.IsFalse(dauVaoHopLe, "Đầu vào hợp lệ");
        }

        // Test case 2: Email rỗng
        [TestMethod]
        public void KiemTraDauVao_EmailRong_ReturnsFalse()
        {
            string newPass = "newPassword456";
            string confirmPass = "newPassword456";

            var user = new Nguoi_Dung_DTO { Email = "", MatKhau = "oldPassword123" };
            bool result = Unitest.DoiMatKhauTest.KiemTraDauVao(user, newPass, confirmPass);
            Assert.IsFalse(result, "Email không thể bỏ trống");

            // Kiểm tra mật khẩu mới và xác minh có khớp nhau không
            bool matKhauXacThuc = Unitest.DoiMatKhauTest.MatKhauMoiXacThuc(newPass, confirmPass);
            Assert.IsTrue(matKhauXacThuc, "Mật khẩu xác minh phải trùng với mật khẩu mới");
        }

        // Test case 3: Mật khẩu cũ rỗng
        [TestMethod]
        public void KiemTraDauVao_MatKhauCuRong_ReturnsFalse()
        {
            string newPass = "newPassword456";
            string confirmPass = "newPassword456";

            var user = new Nguoi_Dung_DTO { Email = "test@example.com", MatKhau = "" };
            bool result = Unitest.DoiMatKhauTest.KiemTraDauVao(user, newPass, confirmPass);
            Assert.IsFalse(result, "Mật khẩu cũ không thể bỏ trống");
        }

        // Test case 4: Mật khẩu mới rỗng
        [TestMethod]
        public void KiemTraDauVao_MatKhauMoiRong_ReturnsFalse()
        {
            string newPass = "";
            string confirmPass = "newPassword456";

            var user = new Nguoi_Dung_DTO { Email = "test@example.com", MatKhau = "oldPassword123" };
            bool result = Unitest.DoiMatKhauTest.KiemTraDauVao(user, newPass, confirmPass);
            Assert.IsFalse(result, "Mật khẩu mới không thể bỏ trống");
        }
        // Test case 5: xác thực Mật khẩu mới rỗng
        [TestMethod]
        public void KiemTraDauVao_XacThucMatKhauMoiRong_ReturnsFalse()
        {
            string newPass = "newPassword456";
            string confirmPass = "";

            var user = new Nguoi_Dung_DTO { Email = "test@example.com", MatKhau = "oldPassword123" };
            bool result = Unitest.DoiMatKhauTest.KiemTraDauVao(user, newPass, confirmPass);
            Assert.IsFalse(result, "xác thực Mật khẩu mới không thể bỏ trống");
        }

        // Test case 6: Mật khẩu mới không khớp với xác nhận
        [TestMethod]
        public void MatKhauMoiXacThuc_KhongKhop_ReturnsFalse()
        {
            string newPass = "newPassword456";
            string confirmPass = "newPassword123";

            bool result = Unitest.DoiMatKhauTest.MatKhauMoiXacThuc(newPass, confirmPass);
            Assert.IsFalse(result, "Mật khẩu xác nhận không khớp");
        }

        // Test case 7: Mật khẩu mới quá ngắn
        [TestMethod]
        public void DoDaiMatKhau_MatKhauMoiQuaNgan_ReturnsFalse()
        {
            string newPass = "abc";
            string confirmPass = "abc";

            bool result = Unitest.DoiMatKhauTest.DoDaiMatKhau("abc");
            Assert.IsFalse(result, "Mật khẩu phải có ít nhất 4 ký tự");


            bool matKhauXacThuc = Unitest.DoiMatKhauTest.MatKhauMoiXacThuc(newPass, confirmPass);
            Assert.IsTrue(matKhauXacThuc, "Mật khẩu xác minh phải trùng với mật khẩu mới");
        }

        // Test case 8: đổi mật khẩu thành công với dữ liệu giả
        [TestMethod]
        public void CapNhatMatKhau_DungThongTin_ReturnsTrue()
        {
            string email = "test@example.com";
            string oldPass = "oldpassword123";
            string newPass = "newpassword456";
            string confirmPass = "newpassword456";

            // Giả lập dữ liệu database
            Unitest.DoiMatKhauTest.GiaLapMatKhau(email, _1_DangNhap_BUS.encryption(oldPass)); 
            bool result =Unitest.DoiMatKhauTest.CapNhatMatKhau(email, oldPass, newPass);

            // Kiểm tra mật khẩu mới và xác minh có khớp nhau không
            bool matKhauXacThuc = Unitest.DoiMatKhauTest.MatKhauMoiXacThuc(newPass, confirmPass);
            Assert.IsTrue(matKhauXacThuc, "Mật khẩu xác minh phải trùng với mật khẩu mới");

            Assert.IsTrue(result, "Đổi mật khẩu thành công khi thông tin đúng.");
        }

        // Test case 9: Mật khẩu cũ sai 
        [TestMethod]
        public void CapNhatMatKhau_SaiMatKhauCu_ReturnsFalse()
        {
            string email = "test@example.com";
            string oldPass = "oldpassword123";
            string newPass = "newpassword456";

            // Giả lập mật khẩu trong DB
            Unitest.DoiMatKhauTest.GiaLapMatKhau(email, _1_DangNhap_BUS.encryption("wrongpassword"));

            bool result = _2_DoiMatKhau_BUS.CapNhatMatKhau(email, oldPass, newPass);

            Assert.IsFalse(result, "Đổi mật khẩu thất bại vì nhập sai mật khẩu cũ.");
        }

        // Test case 10: Email không tồn tại
        [TestMethod]
        public void CapNhatMatKhau_EmailKhongTonTai_ReturnsFalse()
        {
            string email = "test@example.com";
            string oldPass = "oldpassword123";
            string newPass = "newpassword456";

            Unitest.DoiMatKhauTest.GiaLapMatKhau("notfound@example.com", _1_DangNhap_BUS.encryption(oldPass));
            bool result = _2_DoiMatKhau_BUS.CapNhatMatKhau(email, oldPass, newPass);

            Assert.IsFalse(result, "Đổi mật khẩu thất bại vì email không tồn tại.");
        }

    }
}


