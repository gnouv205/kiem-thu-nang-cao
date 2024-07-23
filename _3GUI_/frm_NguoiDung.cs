using System;
using System.Data;
using System.Windows.Forms;
using _DTO_;
using _2BUS_;

namespace _3GUI_
{
    public partial class frm_NguoiDung : Form
    {
        Nguoi_Dung_DTO nguoidung = new Nguoi_Dung_DTO();
        public frm_NguoiDung()
        {
            InitializeComponent();
        }
        
        void GiaTriBanDau()
        {
            txtMaNguoiDung.Text = null;
            txtTenNguoiDung.Text = null;
            txtEmail.Text = null;
            txtSoDienThoai.Text = null;
            txtDiaChi.Text = null;
            dataGridViewNguoiDung.DataSource = null;
            txtTimKiem.Text = "Nhập Tên Người Dùng";

            radioButtonNhanVien.Checked = false;
            radioButtonQuantri.Checked = false;
            radioButtonHoatDong.Checked = false;
            radioButtonNgung.Checked = false;

            txtMaNguoiDung.Enabled = false;
            txtTenNguoiDung.Enabled = false;
            txtEmail.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTimKiem.Enabled = false;
            radioButtonHoatDong.Enabled = false;
            radioButtonNgung.Enabled = false;
            radioButtonNhanVien.Enabled = false;
            radioButtonQuantri.Enabled = false;

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
            txtMaNguoiDung.Text = null;
            txtTenNguoiDung.Text = null;
            txtEmail.Text = null;
            txtSoDienThoai.Text = null;
            txtDiaChi.Text = null;
            txtTimKiem.Text = null;

            radioButtonNhanVien.Checked = false;
            radioButtonQuantri.Checked = false;
            radioButtonHoatDong.Checked = false;
            radioButtonNgung.Checked = false;

            txtMaNguoiDung.Enabled = true;
            txtTenNguoiDung.Enabled = true;
            txtEmail.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtDiaChi.Enabled = true;
            radioButtonHoatDong.Enabled = true;
            radioButtonNgung.Enabled = true;
            radioButtonNhanVien.Enabled = true;
            radioButtonQuantri.Enabled = true;
            txtTimKiem.Enabled = true;

            btnThem.Enabled = true ;
            btnSua.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = true;
            btnHienDanhSach.Enabled = true;
            btnChayLai.Enabled = true;
            btnKhoiDong.Enabled = false;
        }

        void TaiDanhSach()
        {
            try
            {
                dataGridViewNguoiDung.DataSource = NguoiDung_BUS.TaiDanhSachNguoiDung();
                dataGridViewNguoiDung.Columns[0].HeaderText = "Mã Người Dùng";
                dataGridViewNguoiDung.Columns[1].HeaderText = "Họ Và Tên";
                dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
                dataGridViewNguoiDung.Columns[3].HeaderText = "Số Điện Thoại";
                dataGridViewNguoiDung.Columns[4].HeaderText = "Địa Chỉ";
                dataGridViewNguoiDung.Columns[5].HeaderText = "Vai Trò";
                dataGridViewNguoiDung.Columns[6].HeaderText = "Tình Trạng";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void HienThongTin()
        {
            try
            {
                if (dataGridViewNguoiDung.Rows.Count > 0)
                {              
                    txtMaNguoiDung.Text = dataGridViewNguoiDung.CurrentRow.Cells["MaNguoiDung"].Value.ToString();
                    txtTenNguoiDung.Text = dataGridViewNguoiDung.CurrentRow.Cells["TenNguoiDung"].Value.ToString();
                    txtEmail.Text = dataGridViewNguoiDung.CurrentRow.Cells["Email"].Value.ToString();
                    txtSoDienThoai.Text = dataGridViewNguoiDung.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                    txtDiaChi.Text = dataGridViewNguoiDung.CurrentRow.Cells["DiaChi"].Value.ToString();

                    int vaitro = Convert.ToInt32(dataGridViewNguoiDung.CurrentRow.Cells["VaiTro"].Value.ToString()); // Hoạt động
                    radioButtonQuantri.Checked = vaitro== 0 ? true : false;
                    radioButtonNhanVien.Checked = !radioButtonQuantri.Checked;

                    int tinhtrang = Convert.ToInt32(dataGridViewNguoiDung.CurrentRow.Cells["TinhTrang"].Value.ToString()); // Hoạt động
                    radioButtonHoatDong.Checked = tinhtrang == 0 ? true : false;
                    radioButtonNgung.Checked = !radioButtonHoatDong.Checked;

                    if (txtMaNguoiDung.Text == "")
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

        void GiaTriNhap()
        {
            int sdt = int.Parse(txtSoDienThoai.Text);
            int vaitro = radioButtonQuantri.Checked ? 0 : 1;
            int tinhtrang = radioButtonHoatDong.Checked ? 0 : 1;
            nguoidung.TenNguoiDung = txtTenNguoiDung.Text;
            nguoidung.Email = txtEmail.Text;
            nguoidung.SoDT = sdt;
            nguoidung.DiaChi = txtDiaChi.Text;
            nguoidung.VaiTro = vaitro;
            nguoidung.TinhTrang = tinhtrang;
            nguoidung.MatKhau = "123";
        }

        bool KiemTraGiaTriNhap()
        {
            return KiemTraTen() && KiemTraEmail() && KiemTraSoDienThoai() && KiemTraVaitro() && KiemTraTinhTrang() && KiemTraDiaChi(); 
        }

        bool KiemTraTen()
        {
            if(txtTenNguoiDung.Text.Length == 0 )
            {
                MessageBox.Show("Tên không thể bỏ trống", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNguoiDung.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraEmail()
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Email", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            else if (!NguoiDung_BUS.CheckAddEmail(txtEmail.Text))
            {
                MessageBox.Show("Email Không Hợp Lệ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraEmailTonTai()
        {
            if (NguoiDung_BUS.KiemTraTonTai(txtEmail.Text, Convert.ToInt32( txtSoDienThoai.Text)))
            {
                MessageBox.Show("Email Hoặc số điện thoại đã tồn tại! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraSoDienThoai()
        {
            int dienthoai;
            if (!int.TryParse(txtSoDienThoai.Text, out dienthoai) || txtSoDienThoai.Text.Trim().Length < 8 || txtSoDienThoai.Text.Trim().Length > 12)
            {
                MessageBox.Show("Số điện thoại yêu cầu phải là số nguyên dương và chứa ít nhất 9 -> 11 ký tự.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraDiaChi()
        {
            if (txtDiaChi.Text.Length <= 10)
            {
                MessageBox.Show("Địa chỉ không thể bỏ trống và không ít hơn 10 ký tự.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraVaitro()
        {
            if (!radioButtonQuantri.Checked && !radioButtonNhanVien.Checked)
            {
                MessageBox.Show("Bạn Chưa chọn vai trò cho người dùng này.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if (!radioButtonHoatDong.Checked && !radioButtonNgung.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Tình trạng hoạt động ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemtraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Tên Khach bạn muốn tìm là ai? ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Hàm Xử Lý Dữ Liệu

        void ThemTaiKhoan()
        {
            try
            {
                if (NguoiDung_BUS.ThemTaiKhoan(nguoidung))
                {
                    MessageBox.Show("Bạn Đã Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaTaiKhoan()
        {
            try
            {
                nguoidung.MaNguoiDung = txtMaNguoiDung.Text;
                if (NguoiDung_BUS.SuaTaiKhoan(nguoidung))
                {
                    MessageBox.Show("Bạn Đã Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Sửa Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaTaiKhoan()
        {
            try
            {
                if (NguoiDung_BUS.XoaTaiKhoan(txtMaNguoiDung.Text))
                {
                    MessageBox.Show("Bạn Đã Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemTaiKhoan()
        {
            try
            {
                DataTable danhsach = NguoiDung_BUS.TimKiemTaiKhoan(txtTimKiem.Text);
                if (danhsach.Rows.Count > 0)
                {
                    dataGridViewNguoiDung.DataSource = danhsach;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Người Dùng Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void ChucNang_ThemTaiKhoan()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraEmailTonTai())
                {
                    return;
                }
                GiaTriNhap();
                if (MessageBox.Show("Bạn muốn thêm tài khoản mới", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNguoiDung.Focus();
                    GiaTriMoi();
                }
                else
                {
                    ThemTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaTaiKhoan()
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                {
                    return;
                }
                GiaTriNhap();

                if (MessageBox.Show("Bạn muốn Sửa tài khoản này", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SuaTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_XoaTaiKhoan()
        {
            try
            {
                if (MessageBox.Show("Bạn muốn xóa tài khoản này", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XoaTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_TimKiemTaiKhoan()
        {
            try
            {
                if (!KiemtraTimKiem())
                    return;
                TimKiemTaiKhoan();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        #endregion

        #region Chức Năng
        private void dataGridViewNguoiDung_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            HienThongTin();
        }        

        private void frm_NguoiDung_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang_ThemTaiKhoan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChucNang_SuaTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChucNang_XoaTaiKhoan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKiemTaiKhoan();
        }

        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi();
            txtTenNguoiDung.Focus();
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
        #endregion

    }
}
