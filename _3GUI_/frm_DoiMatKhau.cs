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

namespace _3GUI_
{
    public partial class frm_DoiMatKhau : Form
    {
        Nguoi_Dung_DTO nguoidung = new Nguoi_Dung_DTO();
        frm_Main main = new frm_Main();
        public frm_DoiMatKhau()
        {
            InitializeComponent();
            txtEmail.Text = frm_Main.email;
        }
        bool KiemTraDauVao()
        {
            try
            {
                if (txtMatKhauCu.Text.Trim().Length == 0 || txtMatKhauMoi.Text.Trim().Length == 0 || txtNhapLai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
                if (txtMatKhauMoi.Text != txtNhapLai.Text)
                {
                    MessageBox.Show("Mật Khẩu Nhập Lại Không Trùng Khớp.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    return false;
                }
                if (txtMatKhauCu.Text.Trim().Length == 0 || txtMatKhauMoi.Text.Trim().Length <= 3 || txtNhapLai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Mật khẩu mới không nhỏ hơn 3 ký tự.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void DoiMatKhau()
        {
            try
            {
                if (!KiemTraDauVao())
                    return;
                nguoidung.Email = txtEmail.Text;

                // them
                if (!_1_DangNhap_BUS.KiemTraTonTai(txtEmail.Text,0398180979))
                {
                    MessageBox.Show("Thay Đổi Mật Khẩu Thất Bại!! email không tồn tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string matkhaucu = _1_DangNhap_BUS.encryption(txtMatKhauCu.Text);
                string matkhaumoi = _1_DangNhap_BUS.encryption(txtMatKhauMoi.Text);

                if (_2_DoiMatKhau_BUS.CapNhatMatKhau(txtEmail.Text, matkhaucu, matkhaumoi))
                {
                    _1_DangNhap_BUS.SendMail(txtEmail.Text, matkhaumoi);
                    MessageBox.Show("Cập Nhật Mật Khẩu Thành Công! Bạn Cần Đăng Nhập Lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main.DongForm();
                    frm_Main.seesion = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thay Đổi Mật Khẩu Thất Bại!! Kiểm Tra Lại Mật Khẩu", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: + {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    } 
}
