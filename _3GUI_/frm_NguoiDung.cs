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
        public static string TinhTrangNguoiDung { get; set; }

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
            txtTimKiem.Text = "Nhập Tên Người Dùng  ";

            radioButtonNhanVien.Checked = false;
            radioButtonQuantri.Checked = false;
            radioButtonHoatDong.Checked = false;
            radioButtonNgung.Checked = false;

            ckbTaiKhoanDaXoa.Enabled = false;
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
            ckbTaiKhoanDaXoa.Checked = false;

            ckbTaiKhoanDaXoa.Enabled = true;
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

        void CotDuLieu()
        {
            dataGridViewNguoiDung.Columns[0].HeaderText = "Mã Người Dùng";
            dataGridViewNguoiDung.Columns[1].HeaderText = "Họ Và Tên";
            dataGridViewNguoiDung.Columns[2].HeaderText = "Email";
            dataGridViewNguoiDung.Columns[3].HeaderText = "Số Điện Thoại";
            dataGridViewNguoiDung.Columns[4].HeaderText = "Địa Chỉ";
            dataGridViewNguoiDung.Columns[5].HeaderText = "Vai Trò";
            dataGridViewNguoiDung.Columns[6].HeaderText = "Tình Trạng";
        }

        void TaiDanhSach()
        {
            try
            {
                dataGridViewNguoiDung.DataSource = NguoiDung_BUS.TaiDanhSachNguoiDungHoatDong();
                CotDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void HienThongTin()
        {
            try
            {
                if (dataGridViewNguoiDung.Rows.Count > 0)
                {
                    var currentRow = dataGridViewNguoiDung.CurrentRow.Cells;

                    txtMaNguoiDung.Text = currentRow["MaNguoiDung"].Value.ToString();
                    txtTenNguoiDung.Text = currentRow["TenNguoiDung"].Value.ToString();
                    txtEmail.Text = currentRow["Email"].Value.ToString();
                    txtSoDienThoai.Text = currentRow["SoDienThoai"].Value.ToString();
                    txtDiaChi.Text = currentRow["DiaChi"].Value.ToString();

                    string vaitro = currentRow["VaiTro"].Value.ToString(); 
                    radioButtonQuantri.Checked = vaitro == "Quản Trị";
                    radioButtonNhanVien.Checked = vaitro == "Nhân Viên";

                    string tinhtrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonHoatDong.Checked = tinhtrang == "Hoạt Động";
                    radioButtonNgung.Checked = tinhtrang == "Ngừng Hoạt Động";

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
            string vaitro = radioButtonQuantri.Checked ? "Quản Trị" : "Nhân Viên";
            string tinhtrang = radioButtonHoatDong.Checked ? "Hoạt Động" : "Ngừng Hoạt Động" ;
            nguoidung.TenNguoiDung = txtTenNguoiDung.Text;
            nguoidung.Email = txtEmail.Text;
            nguoidung.SoDT = sdt;
            nguoidung.DiaChi = txtDiaChi.Text;
            nguoidung.VaiTro = vaitro;
            nguoidung.TinhTrang = tinhtrang;
            nguoidung.MatKhau = _1_DangNhap_BUS.encryption("123456789");
        }

        bool KiemTraGiaTriNhap()
        {
            return KiemTraTen() && KiemTraEmail() && KiemTraSoDienThoai() && KiemTraVaitro() && KiemTraTinhTrang() && KiemTraDiaChi(); 
        }

        bool KiemTraTen()
        {
            if(txtTenNguoiDung.Text.Length == 0 )
            {
                MessageBox.Show("Tên Người Dùng Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNguoiDung.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraEmail()
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Email", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            else if (!NguoiDung_BUS.CheckAddEmail(txtEmail.Text))
            {
                MessageBox.Show("Email Không Hợp Lệ ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraEmailTonTai()
        {
            if (NguoiDung_BUS.KiemTraTonTai(txtEmail.Text, Convert.ToInt32( txtSoDienThoai.Text)))
            {
                MessageBox.Show("Email Hoặc Số Điện Thoại Đã Tồn Tại! ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Số Điện Thoại Yêu Cầu Phải Là Số Nguyên Dương Và Chứa Ít Nhất 9 -> 11 Ký Tự.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraDiaChi()
        {
            if (txtDiaChi.Text.Length < 10)
            {
                MessageBox.Show("Địa Chỉ Không Thể Bỏ Trống Và Không Ít Hơn 10 Ký Tự.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraVaitro()
        {
            if (!radioButtonQuantri.Checked && !radioButtonNhanVien.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Vai Trò Cho Người Dùng Này.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if (!radioButtonHoatDong.Checked && !radioButtonNgung.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Tình Trạng Hoạt Động", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool KiemtraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Cần Tìm ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraAdmin()
        {
            if (txtMaNguoiDung.Text == "ND_0001" && radioButtonNgung.Checked==true)
            {
                MessageBox.Show("Bạn Không Thể Xóa Người Dùng Mặc Định", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private bool KiemTraTinhTrangHienTai()
        {
            return !radioButtonHoatDong.Checked;
        }

        private void XoaNguoiDung()
        {
            if (!KiemTraTinhTrangHienTai())
            {
                MessageBox.Show("Bạn Không Thể Xóa Người Dùng Đang Hoạt Động", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện xóa người dùng
        }
        #endregion

        #region Hàm Xử Lý Dữ Liệu

        void ThemTaiKhoan()
        {
            try
            {
                if (NguoiDung_BUS.ThemTaiKhoan(nguoidung))
                {
                    MessageBox.Show("Bạn Đã Thêm Người Dùng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _1_DangNhap_BUS.SendMail(txtEmail.Text, "123456789"); 
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm Người Dùng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Người Dùng " + txtMaNguoiDung.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Người Dùng " + txtMaNguoiDung.Text + " Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaTaiKhoan()
        {
            try
            {
                if (NguoiDung_BUS.XoaTaiKhoan(txtMaNguoiDung.Text))
                {
                    if(nguoidung.Id == 1)
                    {
                        MessageBox.Show("Bạn Đã Xóa Người Dùng Này Vì Đây Là Tài Khoản Chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Bạn Đã Xóa Người Dùng " + txtMaNguoiDung.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Xóa Người Dùng " + txtMaNguoiDung.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemTaiKhoan()
        {
            try
            {
                DataTable danhsach = NguoiDung_BUS.TimKiemTaiKhoan(txtTimKiem.Text, txtTimKiem.Text);
                if (danhsach.Rows.Count > 0)
                {
                    dataGridViewNguoiDung.DataSource = danhsach;
                    HienThongTin();
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Người Dùng " + txtTimKiem.Text + " Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void ChucNang_ThemTaiKhoan()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraEmailTonTai())
                {
                    return;
                }
                GiaTriNhap();

                DialogResult result = MessageBox.Show("Bạn Muốn Thêm Người Dùng Mới", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Thêm Người Dùng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNguoiDung.Focus();
                    GiaTriMoi();
                }
                else if (result==DialogResult.Cancel)
                {
                    MessageBox.Show("Bạn Đã Thêm Người Dùng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNguoiDung.Focus();
                }
                else
                {
                    ThemTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaTaiKhoan()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraAdmin())
                {
                    return;
                }
                GiaTriNhap();

                if (MessageBox.Show("Bạn muốn Sửa Thông Tin Người Dùng " + txtMaNguoiDung.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Người Dùng " + txtMaNguoiDung.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SuaTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_XoaTaiKhoan()
        {
            try
            {
                if (!KiemTraAdmin()) return;

                if (MessageBox.Show("Bạn Muốn Xóa Người Dùng " + txtMaNguoiDung.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Xóa Người Dùng " + txtMaNguoiDung.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XoaTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ckbTaiKhoanDaXoa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTaiKhoanDaXoa.Checked == true)
            {
                dataGridViewNguoiDung.DataSource = NguoiDung_BUS.TaiDanhSachNguoiDungNgungHoatDong();
                CotDuLieu();
            }
            else
            {
                TaiDanhSach();
                GiaTriMoi();
            }
        }
        #endregion
    }
}
