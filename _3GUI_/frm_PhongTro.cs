using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2BUS_;
using _DTO_;

namespace _3GUI_
{
    public partial class frm_PhongTro : Form
    {
        Phong_Tro_DTO phongtro = new Phong_Tro_DTO();

        public static string TinhTrangPhong { get; set; }
        public static string HienTrangPhong { get; set; }

        public frm_PhongTro()
        {
            InitializeComponent();
            TaiDanhSach();
        }     

        void GiaTriBanDau()
        {
            txtMaPhong.Text = null;
            txtTenPhong.Text = null;
            txtDienTich.Text = null;
            txtGia.Text = null;
            txtChuThue.Text = null;
            txtGhiChu.Text = null;
            txtTimKiem.Text = "Nhập Tên Phòng";
            radioButtonThue.Checked = false;
            radioButtonTrong.Checked = false;
            radioButtonSuDung.Checked = false;
            radioButtonKhongSD.Checked = false;
            dataGridViewPhongTro.DataSource = null;

            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            txtDienTich.Enabled = false;
            txtGia.Enabled = false;
            radioButtonTrong.Enabled = false;
            radioButtonThue.Enabled = false;
            txtChuThue.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            ckbPhongKhongSD.Enabled = false;
            ckbPhongThue.Enabled = false;

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
            txtMaPhong.Text = null;
            txtTenPhong.Text = null;
            txtDienTich.Text = null;
            txtGia.Text = null;
            txtChuThue.Text = null;
            txtGhiChu.Text = null;
            txtTimKiem.Text = null;
            radioButtonThue.Checked = false;
            radioButtonTrong.Checked = false;
            radioButtonSuDung.Checked = false;
            radioButtonKhongSD.Checked = false;
            ckbPhongKhongSD.Checked = false;
            ckbPhongThue.Checked = false;

            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtDienTich.Enabled = true;
            txtGia.Enabled = true;
            radioButtonTrong.Enabled = true;
            radioButtonThue.Enabled = true;
            txtChuThue.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            ckbPhongThue.Enabled = true;
            ckbPhongKhongSD.Enabled = true;

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
            dataGridViewPhongTro.Columns[0].HeaderText = "Mã Phòng Trọ";
            dataGridViewPhongTro.Columns[1].HeaderText = "Tên Phòng Trọ";
            dataGridViewPhongTro.Columns[2].HeaderText = "Diện Tích";
            dataGridViewPhongTro.Columns[3].HeaderText = "Giá";
            dataGridViewPhongTro.Columns[4].HeaderText = "Trạng Thái";
            dataGridViewPhongTro.Columns[5].HeaderText = "Hiện Trạng";
            dataGridViewPhongTro.Columns[6].HeaderText = "Chủ Thuê";
            dataGridViewPhongTro.Columns[7].HeaderText = "Ghi Chú";
        }

        void TaiDanhSach()
        {
            try
            {
                dataGridViewPhongTro.DataSource = PhongTro_BUS.TaiDanhSachPhongTrong();
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
                CultureInfo culture = new CultureInfo("vi-VN");
                if (dataGridViewPhongTro.Rows.Count > 0)
                {
                    var currentRow = dataGridViewPhongTro.CurrentRow.Cells;

                    txtMaPhong.Text = currentRow["MaPhong"].Value.ToString();
                    txtTenPhong.Text = currentRow["TenPhong"].Value.ToString();
                    txtDienTich.Text = currentRow["DienTich"].Value.ToString();
                    txtChuThue.Text = currentRow["MaNguoiDung"].Value.ToString();
                    txtGhiChu.Text = currentRow["GhiChu"].Value.ToString();
                    txtGia.Text = currentRow["Gia"].Value.ToString();

                    string tinhtrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonThue.Checked = tinhtrang == "Đã Thuê";
                    radioButtonTrong.Checked = tinhtrang == "Trống";

                    string hientrang = currentRow["hientrang"].Value.ToString();
                    radioButtonSuDung.Checked = hientrang == "Sử Dụng";
                    radioButtonKhongSD.Checked = hientrang == "Không Sử Dụng";

                    float gia = 0;
                    float.TryParse(txtGia.Text, out gia);
                    txtGia.Text = gia.ToString("c", culture).Replace("₫", "");
 
                    if (txtMaPhong.Text == "")
                    {
                        MessageBox.Show("Bảng Dữ Liệu Không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void GiaTriNhap()
        {
            string tinhtrang = radioButtonThue.Checked ? "Đã Thuê" : "Trống";
            string hientrang = radioButtonSuDung.Checked ? "Sử Dụng" : "Không Sử Dụng";
            float gia = float.Parse(txtGia.Text);
            phongtro.TenPhong = txtTenPhong.Text;
            phongtro.DienTich = txtDienTich.Text;
            phongtro.Gia = gia;
            phongtro.TinhTrang = tinhtrang;
            phongtro.HienTrang = hientrang;
            phongtro.GhiChu = txtGhiChu.Text;
        }

        bool KiemTraGiaTriNhap()
        {
            return
                KiemTraTenPhong() &&
                KiemTraDienTich() &&
                KiemTraGia() &&
                KiemTraTinhTrang() &&
                KiemTraHienTrangPhong() &&
                KiemTraGhiChu();
        }

        bool KiemTraTenPhongTonTai()
        {
            if (PhongTro_BUS.KiemTraTonTai(txtTenPhong.Text))
            {
                MessageBox.Show("Tên Phòng Đã Tồn Tại ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTenPhong()
        {
            if (txtTenPhong.Text.Length == 0) 
            {
                MessageBox.Show("Tên Phòng Không Thể Bỏ Trống ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraDienTich()
        {
            if (txtDienTich.Text.Length == 0 )
            {
                MessageBox.Show("Diện Tích Phòng Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienTich.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraGia()
        {
            float Gia;
            if (!float.TryParse(txtGia.Text, out Gia))
            {
                MessageBox.Show("Giá Phòng Không Thể Nhập Chữ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            if (txtGia.Text.Trim().Length <= 0 )
            {
                MessageBox.Show("Giá Phòng Không Thể Bỏ Trống Và Lớn Hơn 0", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if (!radioButtonThue.Checked && !radioButtonTrong.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Tình Trạng Của Phòng", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonTrong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraHienTrangPhong()
        {
            if (!radioButtonKhongSD.Checked && !radioButtonSuDung.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Hiện Trạng Của Phòng", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonSuDung.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangTrong()
        {
            if (radioButtonTrong.Checked==false)
            {
                MessageBox.Show("Phòng Mới Chưa Có Khách Thuê Vui Lòng Chọn Tình Trạng Phòng Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonTrong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangDangThue()
        {
            if (radioButtonThue.Checked == true)
            {
                MessageBox.Show("Không Thể Xóa Hoặc Sửa Phòng " + txtMaPhong.Text + " Thành Đã Thuê", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonTrong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraGhiChu()
        {
            if (txtGhiChu.Text.Length == 0)
            {
                MessageBox.Show("Ghi Chú Của Phòng Không Thể Bỏ Trống ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGhiChu.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Nhập Tên Phòng Cần Tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        public static void tinhtrangphong(string maphong)
        {
            try
            {
                string tinhtrangphong = PhongTro_BUS.TinhTrangPhong(maphong);
                if (!string.IsNullOrEmpty(tinhtrangphong))
                {
                    TinhTrangPhong = tinhtrangphong;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void hientrangphong(string maphong)
        {
            try
            {
                string hientrangphong = PhongTro_BUS.HienTrangPhong(maphong);
                if (!string.IsNullOrEmpty(hientrangphong))
                {
                    HienTrangPhong = hientrangphong;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Hàm Xử Lý dữ liệu

        void ThemPhong()
        {
            try
            {
                phongtro.Email =frm_Main.email;
                if (PhongTro_BUS.ThemPhong(phongtro))
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Phòng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm Phòng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaPhong()
        {
            try
            {
                phongtro.Email = frm_Main.email;
                phongtro.MaPhong = txtMaPhong.Text;

                if (PhongTro_BUS.SuaPhong(phongtro))
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Phòng " + txtMaPhong.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Phòng " + txtMaPhong.Text + " Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaPhong()
        {
            try
            {
                phongtro.MaPhong = txtMaPhong.Text;                
                if (PhongTro_BUS.XoaPhong(txtMaPhong.Text))
                {
                    MessageBox.Show("Bạn Đã Xóa Phòng " + txtMaPhong.Text + " Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Xóa " + txtMaPhong.Text + " Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemPhong()
        {
            try
            {
                DataTable danhsach = PhongTro_BUS.TimKiemTenPhong(txtTimKiem.Text);
                if (danhsach.Rows.Count > 0)
                {
                    dataGridViewPhongTro.DataSource = danhsach;
                    HienThongTin();
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Tên " + txtTimKiem.Text + " Phòng Trọ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void ChucNang_ThemPhong()
        {
            try
            {
                if (!KiemTraGiaTriNhap()|| !KiemTraTenPhongTonTai() || !KiemTraTinhTrangTrong())
                {
                    return;
                }
                GiaTriNhap();

                DialogResult result = MessageBox.Show("Bạn Muốn Thêm 1 Phòng Mới", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ( result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Thêm Phòng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if(result == DialogResult.Cancel)
                {
                    MessageBox.Show("Bạn Đã Thêm Phòng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ThemPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaPhong()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraTinhTrangDangThue() || !KiemTraTinhTrangTrong()) 
                    return;
                GiaTriNhap();

                if (MessageBox.Show("Bạn Muốn Sửa Thông Tin Phòng " + txtMaPhong.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Sửa Thông Tin Phòng" + txtMaPhong.Text , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SuaPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_XoaPhong()
        {
            try
            {
                if (!KiemTraTinhTrangDangThue()) return;

                if (MessageBox.Show("Bạn Muốn Xóa Phòng " + txtMaPhong.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Xóa " + txtMaPhong.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XoaPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_TimKiemPhong()
        {
            try
            {
                if (!KiemTraTimKiem())
                    return;

                TimKiemPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }
        
        #endregion

        #region Chức Năng
        private void frm_PhongTro_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }    
        
        private void dataGridViewPhongTro_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            HienThongTin();
        }

        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi();
            radioButtonTrong.Checked = true;
        }

        private void btnHienDanhSach_Click(object sender, EventArgs e)
        {
            ckbPhongKhongSD.Checked = false;
            ckbPhongThue.Checked = false;
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
            ChucNang_ThemPhong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChucNang_SuaPhong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChucNang_XoaPhong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKiemPhong();
        }

        private void ckbPhongTrong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPhongThue.Checked == true)
            {
                ckbPhongKhongSD.Enabled = false;
                radioButtonTrong.Enabled = false; 
                dataGridViewPhongTro.DataSource = PhongTro_BUS.TaiDanhSachPhongDaThue();
                CotDuLieu();
            }
            else
            {
                ckbPhongKhongSD.Enabled = true;
                radioButtonTrong.Enabled = true;
                TaiDanhSach();
                GiaTriMoi();
            }
        }


        private void ckbPhongKhongSD_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPhongKhongSD.Checked == true)
            {
                ckbPhongThue.Enabled = false;
                radioButtonThue.Enabled = false;
                dataGridViewPhongTro.DataSource = PhongTro_BUS.TaiDanhSachPhongKhongSuDung();
                CotDuLieu();
            }
            else
            {
                ckbPhongThue.Enabled = true;
                radioButtonThue.Enabled = true;
                TaiDanhSach();
                GiaTriMoi();
            }
        }
        #endregion

    }
}
