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

            ckbKhachThueHetHan.Enabled = false;
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
            cbxMaPhong.DataSource = PhongTro_BUS.DanhSachMaPhong();
            txtTimKiem.Text = null;
            radioButtonConThue.Checked = false;
            radioButtonHetThue.Checked = false;
            ckbKhachThueHetHan.Checked = false;

            ckbKhachThueHetHan.Enabled = true;
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

        void CotDuLieu()
        {
            dataGridViewKhachThue.Columns[0].HeaderText = "Mã Khách";
            dataGridViewKhachThue.Columns[1].HeaderText = "Tên khách";
            dataGridViewKhachThue.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridViewKhachThue.Columns[3].HeaderText = "CCCD";
            dataGridViewKhachThue.Columns[4].HeaderText = "Tình Trạng";
            dataGridViewKhachThue.Columns[5].HeaderText = "Chủ Thuê";
            dataGridViewKhachThue.Columns[6].HeaderText = "Mã Phòng thuê";
        }

        void TaiDanhSach()
        {
            dataGridViewKhachThue.DataSource = KhachThue_BUS.DanhSachKhachConThue();
            CotDuLieu();
        }
       
        void HienThongTin()
        {
            try
            {
                if (dataGridViewKhachThue.Rows.Count > 0)
                {
                    var currentRow = dataGridViewKhachThue.CurrentRow.Cells;

                    txtMaKhach.Text = currentRow["MaKhach"].Value.ToString();
                    txtTenKhach.Text = currentRow["TenKhach"].Value.ToString();
                    txtSDT.Text = currentRow["SoDienThoai"].Value.ToString();
                    txtCCCD.Text = currentRow["CCCD"].Value.ToString();
                    txtChuThue.Text = currentRow["MaNguoiDung"].Value.ToString();
                    string maPhong = currentRow["MaPhong"].Value.ToString();
                    cbxMaPhong.Text = maPhong;

                    string tinhtrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonConThue.Checked = tinhtrang == "Còn Thuê";
                    radioButtonHetThue.Checked = tinhtrang == "Hết Hạn";

                    if (txtMaKhach.Text == "") 
                    {
                        MessageBox.Show("Bảng dữ liệu không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GiaTriMoi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Nghiệp Vụ

        void DanhSachMaphong()
        {
            try
            {
                cbxMaPhong.DataSource = PhongTro_BUS.DanhSachMaPhong();
                cbxMaPhong.DisplayMember = "MaPhong"; // Tên cột hiển thị
                cbxMaPhong.ValueMember = "MaPhong";
            }  
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            return KiemTraTenKhach() && KiemTraSoDienthoai() && KiemTraCCCD() && KiemTraTinhTrang() && KiemTraMaPhong();
        }

        bool KiemTraTenKhach()
        {
            if (txtTenKhach.Text.Length == 0)
            {
                MessageBox.Show("Tên Khách Không Thể Bỏ Trống ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraSoDienthoai()
        {
            int dienthoai;
            if (!int.TryParse(txtSDT.Text, out dienthoai) || txtSDT.Text.Trim().Length < 9 || txtSDT.Text.Trim().Length > 11) 
            {
                MessageBox.Show("Số điện thoại yêu cầu phải là số nguyên dương và chứa ít nhất 9 -> 11 ký tự.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            if (dienthoai < 0)
            {
                MessageBox.Show("Số Điện Thoại Không Thể Là Số Âm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraCCCD()
        {
            int cccd ;
            if (!int.TryParse(txtCCCD.Text, out cccd) || txtCCCD.Text.Trim().Length < 9 || txtCCCD.Text.Trim().Length > 12) 
            {
                MessageBox.Show("Căn Cước Công Dân Không Thể Bỏ Trống Và Có 9 -> 12 Ký Tự", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCCD.Focus();
                return false;
            }
            if (cccd < 0)
            {
                MessageBox.Show("Căn Cước Không Thể Là Số Âm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCCD.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if(!radioButtonConThue.Checked && !radioButtonHetThue.Checked)
            {
                MessageBox.Show("Khách Thuê Này Còn Thuê Không", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonConThue.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraMaPhong()
        {
            if (PhongTro_BUS.DanhSachMaPhong() == null) 
            {
                MessageBox.Show("Phòng Không Tồn Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Khách Cần Tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTonTaiKhach()
        {
            if (KhachThue_BUS.KiemTraTonTaiKhach(txtTenKhach.Text, txtCCCD.Text))
            {
                MessageBox.Show("Khách đã Tồn Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraKhachHienTai()
        {
            if (radioButtonHetThue.Checked == true)
            {
                MessageBox.Show("Khách " + txtTenKhach.Text + " Không Thể Sửa Tình Trạng Thành Hết Thuê ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonConThue.Focus();
                return false;
            }
            return true;
        }

        bool DieuKienThemKhach()
        {
            if (radioButtonConThue.Checked == false)
            {
                MessageBox.Show("Khách Mới Được Thêm Vui Lòng Chọn Tình Trạng Còn Thuê" , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangPhong()
        {
            frm_PhongTro.tinhtrangphong(cbxMaPhong.Text);
            frm_PhongTro.hientrangphong(cbxMaPhong.Text);

            if (frm_PhongTro.TinhTrangPhong == "Đã Thuê")
            {
                MessageBox.Show("Phòng đã được thuê. Không Thể Cập Nhật Thông Tin Khách Với Tình Trạng Còn Thuê.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (frm_PhongTro.HienTrangPhong == "Không Sử Dụng")
            {
                MessageBox.Show("Phòng Đã Không Còn Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                khach.Email = frm_Main.email;
                if (KhachThue_BUS.ThemKhach(khach))
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Khách Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Khách Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaKhach()
        {
            try
            {
                khach.Email = frm_Main.email;
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
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaKhach()
        {
            try
            {
                if (KhachThue_BUS.XoaKhach(txtMaKhach.Text,cbxMaPhong.Text))
                {
                    MessageBox.Show("Bạn Đã Xóa Thông Tin Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Xóa Thông Tin Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Không Tìm Thấy Khách Thuê Này ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimKiem.Focus();
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        #endregion

        #region Hàm Thực Thi Chức Năng

        void ChucNang_ThemKhach()
        {
            try
            {
                if (!KiemTraGiatriNhap() || !KiemTraTonTaiKhach() || !DieuKienThemKhach() || !KiemTraTinhTrangPhong()) 
                    return;

                GiatriNhap();
 

                DialogResult result = MessageBox.Show("Bạn Muốn Thêm Khách Thuê", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Thêm Khách Thuê Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Bạn Đã Thêm Khách Thuê Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ThemKhach();
                }

            }
           catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaKhach()
        {
            try
            {
                if (!KiemTraGiatriNhap() || !KiemTraKhachHienTai() ) 
                    return;

                GiatriNhap();

                if (!KiemTraTinhTrangPhong())
                    return;

                if (MessageBox.Show("Bạn Muốn Sửa Thông Tin Khách " + txtMaKhach.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    SuaKhach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_XoaKhach()
        {
            try
            {
                if (MessageBox.Show("Bạn Muốn Xóa Thông Tin Khách " + txtMaKhach.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Xóa Thông Tin Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XoaKhach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnThem.Enabled = false;
            HienThongTin();
        }
        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi();
            DanhSachMaphong();
        }

        private void btnHienDanhSach_Click(object sender, EventArgs e)
        {
            ckbKhachThueHetHan.Checked = false;
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

        private void ckbKhachThueHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbKhachThueHetHan.Checked == true)
            {
                radioButtonConThue.Enabled = false;
                dataGridViewKhachThue.DataSource = KhachThue_BUS.DanhSachKhachHetHan();
                CotDuLieu();
            }
            else
            {
                radioButtonConThue.Enabled = true;
                TaiDanhSach();
                GiaTriMoi();
            }
        }
        #endregion
    }
}
