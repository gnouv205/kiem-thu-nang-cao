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
    public partial class frm_KhachThue : Form
    {
        Khach_Thue_DTO khach = new Khach_Thue_DTO();

        public frm_KhachThue()
        {
            InitializeComponent();
            DanhSachMaphong();
        }
        void GiaTriBanDau()
        {
            txtMaKhach.Text = null;
            txtTenKhach.Text = null;
            txtSDT.Text = null;
            txtCCCD.Text = null;
            txtChuThue.Text = null;
            cbxMaPhong.Text = "Chọn Mã Phòng";
            txtTimKiem.Text = "Nhập Tên Khách Thuê";
            radioButtonConThue.Checked = false;
            radioButtonHetThue.Checked = false;
            dataGridViewKhachThue.DataSource = null;

            txtMaKhach.Enabled = false;
            txtTenKhach.Enabled = false;
            txtSDT.Enabled = false;
            txtCCCD.Enabled = false;
            radioButtonConThue.Enabled = false;
            radioButtonHetThue.Enabled = false;
            txtChuThue.Enabled = false;
            cbxMaPhong.Enabled = false;
            txtTimKiem.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
            btnHienDanhSach.Enabled = false;
            btnChayLai.Enabled = false;
            btnKhoiDong.Enabled = true;

        }

        void GiaTriMoi()
        {
            txtMaKhach.Text = null;
            txtTenKhach.Text = null;
            txtSDT.Text = null;
            txtCCCD.Text = null;
            txtChuThue.Text = null;
            cbxMaPhong.Text = "MP_0001";
            txtTimKiem.Text = null;
            radioButtonConThue.Checked = false;
            radioButtonHetThue.Checked = false;
            dataGridViewKhachThue.DataSource = null;

            txtMaKhach.Enabled = true;
            txtTenKhach.Enabled = true;
            txtSDT.Enabled = true;
            txtCCCD.Enabled = true;
            radioButtonConThue.Enabled = true;
            radioButtonHetThue.Enabled = true;
            txtChuThue.Enabled = true;
            cbxMaPhong.Enabled = true;
            txtTimKiem.Enabled = true;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = true;
            btnHienDanhSach.Enabled = true;
            btnChayLai.Enabled = true;
            btnKhoiDong.Enabled = false;
        }

        void TaiDanhSach()
        {
            dataGridViewKhachThue.DataSource = KhachThue_BUS.DanhSachKhachThue();
            dataGridViewKhachThue.Columns[0].HeaderText = "Mã Khách";
            dataGridViewKhachThue.Columns[1].HeaderText = "Tên khách";
            dataGridViewKhachThue.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridViewKhachThue.Columns[3].HeaderText = "CCCD";
            dataGridViewKhachThue.Columns[4].HeaderText = "Tình Trạng";
            dataGridViewKhachThue.Columns[5].HeaderText = "Chủ Thuê";
            dataGridViewKhachThue.Columns[6].HeaderText = "Mã Phòng thuê";
        }

        void HienThongTin()
        {
            try
            {
                if (dataGridViewKhachThue.Rows.Count > 0)
                {
                    txtMaKhach.Text = dataGridViewKhachThue.CurrentRow.Cells["MaKhach"].Value.ToString();
                    txtTenKhach.Text = dataGridViewKhachThue.CurrentRow.Cells["TenKhach"].Value.ToString();
                    txtSDT.Text = dataGridViewKhachThue.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                    txtCCCD.Text = dataGridViewKhachThue.CurrentRow.Cells["CCCD"].Value.ToString();
                    txtChuThue.Text = dataGridViewKhachThue.CurrentRow.Cells["MaNguoiDung"].Value.ToString();
                    cbxMaPhong.Text = dataGridViewKhachThue.CurrentRow.Cells["MaPhong"].Value.ToString();

                    string tinhtrang = dataGridViewKhachThue.CurrentRow.Cells["TinhTrang"].Value.ToString();
                    radioButtonConThue.Checked = tinhtrang == "Còn Thuê";
                    radioButtonHetThue.Checked = tinhtrang == "Hết Hạn";

                    if (txtMaKhach.Text == "") 
                    {
                        MessageBox.Show("Bảng dữ liệu không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GiaTriMoi();
                    }
                }
            }
            catch
            {
                GiaTriMoi();
                return;
            }          
        }

        #region Nghiệp Vụ

        void DanhSachMaphong()
        {
            cbxMaPhong.DataSource = PhonTro_BUS.DanhSachMaPhong();
            cbxMaPhong.DisplayMember = "maphong";
        }

        void GiatriNhap()
        {
            string tinhtrang = radioButtonConThue.Checked ? "Còn Thuê" : "Hết Hạn";
            int cccd = int.Parse(txtCCCD.Text);
            khach.TenKhach = txtTenKhach.Text;
            khach.SoDienThoai = txtSDT.Text;
            khach.CCCD = cccd;
            khach.TinhTrang = tinhtrang;
            khach.MaPhong = cbxMaPhong.Text;
        }

        bool KiemTraGiatriNhap()
        {
            return KiemTraTenKhach() && KiemTraSoDienthoai() && KiemTraCCCD() && KiemTraTinhTrang() && KiemTraMaPhong() && KiemTraTonTaiKhach();
        }

        bool KiemTraTenKhach()
        {
            if (txtTenKhach.Text.Length == 0)
            {
                MessageBox.Show("Tên Khách Không Thể Bỏ Trống ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraSoDienthoai()
        {
            int dienthoai;
            if (!int.TryParse(txtSDT.Text, out dienthoai) || txtSDT.Text.Trim().Length < 8 || txtSDT.Text.Trim().Length > 12)
            {
                MessageBox.Show("Số điện thoại yêu cầu phải là số nguyên dương và chứa ít nhất 9 -> 11 ký tự.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraCCCD()
        {
            int cccd = 0;
            if (!int.TryParse(txtCCCD.Text, out cccd) || txtCCCD.Text.Length < 9 || txtCCCD.Text.Length > 11)  
            {
                MessageBox.Show("Căn Cước Công Dân Không Thể Bỏ Trống Và Nhập Đủ 10 Số", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCCD.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if(!radioButtonConThue.Checked && !radioButtonHetThue.Checked)
            {
                MessageBox.Show("Khách Thuê Này Còn Thuê Không", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangHienTai()
        {
            if (radioButtonConThue.Checked == true)
            {
                MessageBox.Show("Khách Thuê Này Còn Thuê không thể Xóa hoặc Sửa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraMaPhong()
        {
            if (PhonTro_BUS.DanhSachMaPhong() == null)
            {
                MessageBox.Show("Phòng Không Tồn Tại", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Nhập Tên Khach Muốn Tìm? ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTonTaiKhach()
        {
            if (KhachThue_BUS.KiemTraTonTaiKhach(txtTenKhach.Text))
            {
                MessageBox.Show("Khách đã Tồn Tại", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangPhong()
        {
            frm_PhongTro.tinhtrangphong(cbxMaPhong.Text);

            if (int.Parse(frm_PhongTro.TinhTrangPhong) == 0)
            {
                MessageBox.Show("Phòng đã được thuê", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiaTriMoi();
                return false;
            }
            return true;
        }

        #endregion

        #region Hàm Xử Lý Dữ Liệu

        void ThemKhach()
        {
            try
            {
                khach.Email = "caothinh467@gmail.com";
                if (KhachThue_BUS.ThemKhach(khach))
                {
                    MessageBox.Show("Bạn đã thêm 1 Khách thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn đã thêm 1 Khách thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaKhach()
        {
            try
            {
                khach.Email = "caothinh123@gmail.com";
                khach.MaKhach = txtMaKhach.Text;
                if (KhachThue_BUS.SuaKhach(khach))
                {
                    MessageBox.Show("Bạn đã Sửa Thông Tin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn đã Sửa Thông Tin thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaKhach()
        {
            try
            {
                if (KhachThue_BUS.XoaKhach(txtMaKhach.Text))
                {
                    MessageBox.Show("Bạn đã Xóa Thông Tin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn đã Xóa Thông Tin thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemKhach()
        {
            try
            {
                DataTable danhsach = KhachThue_BUS.TimKiemKhachThue(txtTimKiem.Text);
                if (danhsach.Rows.Count > 0)
                {
                    dataGridViewKhachThue.DataSource = danhsach;
                }
                else
                {
                    MessageBox.Show("Không Tìm thấy Khách Thuê Này ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimKiem.Focus();
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        #endregion

        #region Hàm Thực Thi Chức Năng

        void ChucNang_ThemKhach()
        {
            try
            {
                if (!KiemTraGiatriNhap())
                    return;

                GiatriNhap();

                if (!KiemTraTinhTrangPhong())
                    return;

                if (MessageBox.Show("Bạn Muốn  Thêm Khách Thuê", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Thêm Khách Thuê thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    ThemKhach();
                }

            }
           catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaKhach()
        {
            try
            {
                if (!KiemTraGiatriNhap() || !KiemTraTinhTrangHienTai())
                    return;

                GiatriNhap();

                if (!KiemTraTinhTrangPhong())
                    return;

                if (MessageBox.Show("Bạn Muốn Sửa Thông Tin Khách Này", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    SuaKhach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_XoaKhach()
        {
            try
            {
                if (!KiemTraTinhTrangHienTai()) return;

                if (MessageBox.Show("Bạn Muốn Xóa Thông Tin Khách Này", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Xóa Thông Tin thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    XoaKhach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_TimKiemKhach()
        {
            try
            {
                if (!KiemTraTimKiem())
                    return;
                TimKiemKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        #endregion

        #region Chức Năng        
        private void frm_KhachThue_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void dataGridViewKhachThue_Click(object sender, EventArgs e)
        {
            HienThongTin();
        }
        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi();
        }

        private void btnHienDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void btnChayLai_Click(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang_ThemKhach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChucNang_SuaKhach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChucNang_XoaKhach();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKiemKhach();
        }


        #endregion
    }
}
