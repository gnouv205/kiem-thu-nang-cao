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
            txtTimKiem.Text = "Nhập Tên Phong";
            radioButtonThue.Checked = false;
            radioButtonTrong.Checked = false;
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
            radioButtonThue.Checked = false;
            radioButtonTrong.Checked = false;

            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtDienTich.Enabled = true;
            txtGia.Enabled = true;
            radioButtonTrong.Enabled = true;
            radioButtonThue.Enabled = true;
            txtChuThue.Enabled = true;
            txtGhiChu.Enabled = true;

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
            dataGridViewPhongTro.DataSource = PhonTro_BUS.TaiDanhSachPhong();
            dataGridViewPhongTro.Columns[0].HeaderText = "Mã Phòng Trọ";
            dataGridViewPhongTro.Columns[1].HeaderText = "Tên Phòng Trọ";
            dataGridViewPhongTro.Columns[2].HeaderText = "Diện Tích";
            dataGridViewPhongTro.Columns[3].HeaderText = "Giá";
            dataGridViewPhongTro.Columns[4].HeaderText = "Trạng Thái";
            dataGridViewPhongTro.Columns[5].HeaderText = "Chủ Thuê";
            dataGridViewPhongTro.Columns[6].HeaderText = "Ghi Chú";
        }

        void HienThongTin()
        {
            try
            {
                int tinhtrang = 1; // phòng trống
                float gia = 0;
                CultureInfo culture = new CultureInfo("vi-VN");
                if (dataGridViewPhongTro.Rows.Count > 0)
                {
                    txtMaPhong.Text = dataGridViewPhongTro.CurrentRow.Cells["MaPhong"].Value.ToString();
                    txtTenPhong.Text = dataGridViewPhongTro.CurrentRow.Cells["TenPhong"].Value.ToString();
                    txtDienTich.Text = dataGridViewPhongTro.CurrentRow.Cells["DienTich"].Value.ToString();
                    txtChuThue.Text = dataGridViewPhongTro.CurrentRow.Cells["MaNguoiDung"].Value.ToString();
                    txtGhiChu.Text = dataGridViewPhongTro.CurrentRow.Cells["GhiChu"].Value.ToString();

                    if (float.TryParse(dataGridViewPhongTro.CurrentRow.Cells["Gia"].Value.ToString(), out gia) &&
                        int.TryParse(dataGridViewPhongTro.CurrentRow.Cells["TinhTrang"].Value.ToString(), out tinhtrang))
                    {
                        txtGia.Text = gia.ToString("c", culture).Replace("₫", "");

                        radioButtonThue.Checked = tinhtrang == 0 ? true : false;
                        radioButtonTrong.Checked = !radioButtonThue.Checked;
                    }
                    else
                    {
                        MessageBox.Show("Bảng dữ liệu không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GiaTriMoi();
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        #region Nghiep Vu
        void GiaTriNhap()
        {
            int tinhtrang = radioButtonThue.Checked ? 0 : 1;
            float gia = float.Parse(txtGia.Text);
            phongtro.TenPhong = txtTenPhong.Text;
            phongtro.DienTich = txtDienTich.Text;
            phongtro.Gia = gia;
            phongtro.TinhTrang = tinhtrang;
            phongtro.GhiChu = txtGhiChu.Text;
        }

        bool KiemTraGiaTriNhap()
        {
            return KiemTraTenPhong() && KiemTraDienTich() && KiemTraGia() && KiemTraTinhTrang() && KiemTraGhiChu();
        }

        bool KiemTraTenPhongTonTai()
        {
            if (PhonTro_BUS.KiemTraTonTai(txtTenPhong.Text))
            {
                MessageBox.Show("Tên đã tồn tại ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTenPhong()
        {
            if (txtTenPhong.Text.Length == 0) 
            {
                MessageBox.Show("Tên không thể bỏ trống ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraDienTich()
        {
            if (txtDienTich.Text.Length == 0 )
            {
                MessageBox.Show("Diện tích không thể bỏ trống", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Giá không thể nhập chữ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            if (txtGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Giá không thể bỏ trống", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if (!radioButtonThue.Checked && !radioButtonTrong.Checked)
            {
                MessageBox.Show("Phòng đã được thuê hay chưa?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        bool KiemTraGhiChu()
        {
            if (txtGhiChu.Text.Length == 0)
            {
                MessageBox.Show("Bạn có ghi chú gì về phòng này? ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtGhiChu.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Nhập Tên Phòng Muốn Tìm? ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Ham Thuc Thi
        void ThemPhong()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraTenPhongTonTai())
                {
                    return;
                }
                GiaTriNhap();
                if (MessageBox.Show("Bạn Muốn Thêm 1 Phong mới", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Thêm phòng thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    phongtro.Email = "caothinh467@gmail.com";
                    if (PhonTro_BUS.ThemPhong(phongtro))
                    {
                        MessageBox.Show("Bạn đã thêm 1 phòng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSach();
                        GiaTriMoi();
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã thêm 1 phòng thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GiaTriMoi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaPhong()
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                    return;
                GiaTriNhap();

                if (MessageBox.Show("Bạn Muốn Sửa Thông Tin Phòng", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else
                {
                    phongtro.Email = "caothinh123@gmail.com";
                    phongtro.MaPhong = txtMaPhong.Text;
                    if (PhonTro_BUS.SuaPhong(phongtro))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void XoaPhong()
        {
            try
            {
                if (MessageBox.Show("Bạn muốn Sửa Thong tin phong", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Sửa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    phongtro.MaPhong = txtMaPhong.Text;
                    if (PhonTro_BUS.XoaPhong(txtMaPhong.Text))
                    {
                        MessageBox.Show("Bạn Đã Xoa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSach();
                        GiaTriMoi();
                    }
                    else
                    {
                        MessageBox.Show("Bạn Đã Xoa Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GiaTriMoi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemPhong()
        {
            try
            {
                KiemTraTimKiem();
                txtTimKiem.Text = null;
                txtTimKiem.Enabled = true;
                phongtro.TenPhong = txtTimKiem.Text;

                DataTable danhsach = PhonTro_BUS.TimKiemTenPhong(phongtro.TenPhong);
                if (danhsach.Rows.Count > 0)
                {
                    dataGridViewPhongTro.DataSource = danhsach;
                    //HienThongTin();
                }
                else
                {
                    MessageBox.Show("Khong tim thay ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Chuc Nang
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
            ThemPhong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaPhong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaPhong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemPhong();
        }
        #endregion
    }
}
