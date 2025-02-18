using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _DTO_;
using _2BUS_;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using System.Threading;
using Google.Apis.Oauth2.v2.Data;
using Unitest;

namespace _3GUI_
{
    public partial class frm_DangNhap : Form
    {
        Nguoi_Dung_DTO nguoidung = new Nguoi_Dung_DTO();
        public static string vaitro { get ; set; }

        private static string[] Scopes = { Oauth2Service.Scope.UserinfoProfile, Oauth2Service.Scope.UserinfoEmail };
        private static string ClientId = "780697413318-1vqnlddoc4vaha5vilhgbjspo4lmodb5.apps.googleusercontent.com";
        private static string ClientSecret = "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";
        private UserCredential credential;
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        //sửa chổ này
        bool KiemTraDauVao()
        {
            nguoidung.Email = txtEmail.Text;
            nguoidung.MatKhau = txtPassWord.Text;
            if(!DangNhapTest.KiemTraDauVao(nguoidung))
            {
                if (!DangNhapTest.KiemTraDinhDang(nguoidung))
                {
                    MessageBox.Show("Email sai định dạng", "Lỗi Dữ Liệu Vào ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                MessageBox.Show("Bạn Vui Lòng Nhập Đủ Thông Tin", "Lỗi Dữ Liệu Vào ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangNguoiDung()
        {
            try
            {
                if (frm_NguoiDung.TinhTrangNguoiDung == "Ngừng Hoạt Động" )
                {
                    MessageBox.Show("Tài Khoản Này Đã Không Còn Sử Dụng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Text = "";
                    txtPassWord.Text = "";
                    txtEmail.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        void vaitronhanvien()
        {
            try
            {
                string vaitro = _1_DangNhap_BUS.LayVaiTroNhanVien(nguoidung.Email);
                if (!string.IsNullOrEmpty(vaitro))
                {
                    frm_DangNhap.vaitro = vaitro;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Đăng Nhập

        void KiemTraDangNhap(string email, string pass)
        {
            try
            {
                nguoidung.Email = email;
                nguoidung.MatKhau = _1_DangNhap_BUS.encryption(pass);

                if (!KiemTraTinhTrangNguoiDung())
                    return;

                if (_1_DangNhap_BUS.NguoiDungDangNhap(nguoidung))
                {
                    vaitronhanvien();
                    MessageBox.Show("Đăng Nhập Thành Công! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_Main.email = nguoidung.Email;
                    frm_Main.seesion = 0;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không thành Công! Kiểm Tra Lại Email Hoặc PassWord!", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DangNhap()
        {
            if (!KiemTraDauVao()) 
                return;
            KiemTraDangNhap(txtEmail.Text, txtPassWord.Text);
        }

        #endregion

        #region Quên Mật Khẩu

        void TaoMatKhauNgauNhien()
        {
            try
            {
                if (_1_DangNhap_BUS.QuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(_1_DangNhap_BUS.RandomString(4, true));
                    builder.Append(_1_DangNhap_BUS.RandomNumber(1000, 9999));
                    builder.Append(_1_DangNhap_BUS.RandomString(2, false));
                    string NewPass = _1_DangNhap_BUS.encryption(builder.ToString());
                    _1_DangNhap_BUS.TaoMatKhauMoi(txtEmail.Text, NewPass); // cập nhật đến sql
                    _1_DangNhap_BUS.SendMail(txtEmail.Text, builder.ToString());
                    txtEmail.Text = "";
                    txtPassWord.Text = "";
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại Email", "Lỗi Dữ Liệu", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void QuenMatKhau()
        {
            try
            {
                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn vui lòng nhập Email! ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                TaoMatKhauNgauNhien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Chức Năng

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btnForgetPassWord_Click(object sender, EventArgs e)
        {
            QuenMatKhau();
        }

        private async void btnLoginWithGG_Click(object sender, EventArgs e)
        {
            try
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = ClientId, ClientSecret = ClientSecret },
                    Scopes,
                    "user",
                    CancellationToken.None);

                if (credential != null)
                {
                    Oauth2Service oauth2Service = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Google Login Example"
                    });

                    Userinfo userInfo = oauth2Service.Userinfo.Get().Execute();
                    MessageBox.Show($"Hello, {userInfo.Name}! Your email is {userInfo.Email}");
                    frm_Main main = new frm_Main();
                    main.Show();
                    main.Hide();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Thoát Chương Trình??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void btnMiNi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (credential != null)
                {
                    credential.RevokeTokenAsync(CancellationToken.None).Wait();
                    MessageBox.Show("Bạn đã đăng xuất.");
                    credential = null; // Đặt credential về null sau khi hủy
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}");
            }
        }

        #endregion
    }
}
