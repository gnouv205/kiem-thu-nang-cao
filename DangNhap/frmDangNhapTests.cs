using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests;
namespace UnitTests
{
    [TestClass]
    public class frmDangNhapTests
    {
        [TestMethod]
        public void KiemTraDauVao_InputEmpty_ReturnFalse()
        {
            // Arrange
            string email = "";
            string password = "";

            // Act
            var result = TestDangNhap.KiemTraDauVao(email, password);

            // Assert
            Assert.IsFalse(result, "Expected KiemTraDauVao to return false when input is empty.");
        }

        [TestMethod]
        public void KiemTraDauVao_InputValid_ReturnTrue()
        {
            // Arrange
            string email = "test@example.com";
            string password = "password";

            // Act
            var result = KiemTraDauVao(email, password);

            // Assert
            Assert.IsTrue(result, "Expected KiemTraDauVao to return true for valid input.");
        }
    }
}
