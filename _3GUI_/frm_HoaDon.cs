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
using ClosedXML.Excel;

namespace _3GUI_
{
    public partial class frm_HoaDon : Form
    {
        Hoa_Don_DTO hoadon = new Hoa_Don_DTO();
        public static string TinhTrang { get; set; }

        public frm_HoaDon()
        {
            InitializeComponent();
            TaiDanhSach();
        }

        #region Giá Trị
        void GiaTriBanDau()
        {
            txtMaHD.Text = null;
            cbxMaKhach.DataSource = null;
            txtMaPhong.Text = null;
            txtTienDien.Text = null;
            txtTienNuoc.Text = null;
            txtTongTien.Text = null;
            txtTimKiem.Text = "Nhập Mã Phòng";
            dgvDSHoaDon.DataSource = null;
            radioButtonThu.Checked = false;
            radioButtonChua.Checked = false;

            txtMaHD.Enabled = false;
            cbxMaKhach.Enabled = false;
            txtMaPhong.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            dtpNgayKetThuc.Enabled = false;
            txtTienDien.Enabled = false;
            txtTienNuoc.Enabled = false;
            txtGiaPhong.Enabled = false;
            txtTimKiem.Enabled = false;
            txtTongTien.Enabled = false;
            radioButtonThu.Enabled = false;
            radioButtonChua.Enabled = false;

            btnKhoiDong.Enabled = true;
            btnHienDanhSach.Enabled = false;
            btnChayLai.Enabled = false;
            btnThem.Enabled = false;
            btnSuaDon.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXuatHD.Enabled = false;
            btnTongTien.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        void GiaTriMoi()
        {
            txtMaHD.Text = null;
            txtMaPhong.Text = null;
            txtTienDien.Text = null;
            txtTienNuoc.Text = null;
            txtTongTien.Text = null;
            txtTimKiem.Text = null;
            radioButtonThu.Checked = false;
            radioButtonChua.Checked = false;

            txtMaHD.Enabled = true;
            cbxMaKhach.Enabled = true;
            txtMaPhong.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;
            txtTienDien.Enabled = true;
            txtTienNuoc.Enabled = true;
            txtGiaPhong.Enabled = true;
            txtTimKiem.Enabled = true;
            txtTongTien.Enabled = true;
            radioButtonThu.Enabled = true;
            radioButtonChua.Enabled = true;

            btnKhoiDong.Enabled = false;
            btnHienDanhSach.Enabled = true;
            btnChayLai.Enabled = true;
            btnThem.Enabled = true;
            btnSuaDon.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXuatHD.Enabled = true;
            btnTongTien.Enabled = true;
            btnThanhToan.Enabled = true;
        }
        #endregion

        void DanhSachKhach()
        {
            cbxMaKhach.DataSource = KhachThue_BUS.DanhSachMaKhach();
            cbxMaKhach.DisplayMember = "MaKhach";
        }

        void CotDuLieu()
        {
            dgvDSHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvDSHoaDon.Columns[1].HeaderText = "Mã Khách";
            dgvDSHoaDon.Columns[2].HeaderText = "Mã Phòng";
            dgvDSHoaDon.Columns[3].HeaderText = "Ngày Bất Đầu";
            dgvDSHoaDon.Columns[4].HeaderText = "Ngày Kết Thúc";
            dgvDSHoaDon.Columns[5].HeaderText = "Tiên Nước ";
            dgvDSHoaDon.Columns[6].HeaderText = "Tiền Điện";
            dgvDSHoaDon.Columns[7].HeaderText = "Giá Phòng";
            dgvDSHoaDon.Columns[8].HeaderText = "Tình Trạng";
            dgvDSHoaDon.Columns[9].HeaderText = "Tổng Tiền";
            dgvDSHoaDon.Columns[10].HeaderText = "Ngày Xuất Hóa Đơn";
        }

        void TaiDanhSach()
        {
            dgvDSHoaDon.DataSource = _8_HoaDon_BUS.DanhSachHoaDonChuaThu();
            CotDuLieu();
        }

        void HienDanhSach()
        {
            try
            {
                CultureInfo culture = new CultureInfo("vi-VN");

                if (dgvDSHoaDon.Rows.Count > 0)
                {
                    var currentRow = dgvDSHoaDon.CurrentRow.Cells;
                    // Cập nhật thông tin từ dòng hiện tại
                    txtMaHD.Text = currentRow["MaHoaDon"].Value.ToString();
                    cbxMaKhach.Text = currentRow["MaKhach"].Value.ToString();
                    txtMaPhong.Text = currentRow["MaPhong"].Value.ToString();
                    dtpNgayBatDau.Text = currentRow["NgayBatDau"].Value.ToString();
                    dtpNgayKetThuc.Text = currentRow["NgayKetThuc"].Value.ToString();
                    txtTienDien.Text = currentRow["TienDien"].Value.ToString();
                    txtTienNuoc.Text = currentRow["TienNuoc"].Value.ToString();
                    txtGiaPhong.Text = currentRow["GiaPhong"].Value.ToString();
                    txtTongTien.Text = currentRow["TongTien"].Value.ToString();
                    dtpNgayXuat.Text = currentRow["NgayXuatHoaDon"].Value.ToString();

                    // Xác định tình trạng
                    string tinhtrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonThu.Checked = tinhtrang == "Đã Thu";
                    radioButtonChua.Checked = tinhtrang == "Chưa Thu";

                    // Chuyển đổi và định dạng số tiền
                    float tienDien, tienNuoc, giaPhong, tongTien;
                    float.TryParse(txtTienDien.Text, out tienDien);
                    float.TryParse(txtTienNuoc.Text, out tienNuoc);
                    float.TryParse(txtGiaPhong.Text, out giaPhong);
                    float.TryParse(txtTongTien.Text, out tongTien);

                    txtTienDien.Text = tienDien.ToString("c", culture).Replace("₫", "");
                    txtTienNuoc.Text = tienNuoc.ToString("c", culture).Replace("₫", "");
                    txtGiaPhong.Text = giaPhong.ToString("c", culture).Replace("₫", "");
                    txtTongTien.Text = tongTien.ToString("c", culture).Replace("₫", "");

                    if (txtMaHD.Text == null)
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

        void GiaTriNhap()
        {
            try
            {
                float tienDien = float.Parse(txtTienDien.Text);
                float tienNuoc = float.Parse(txtTienNuoc.Text);
                float gia = float.Parse(txtGiaPhong.Text);
                float tongTien = float.Parse(txtTongTien.Text);
                string tinhTrang = radioButtonThu.Checked ? "Đã Thu" : "Chưa Thu";
                hoadon.MaHoaDon = txtMaHD.Text;
                hoadon.MaKhach = cbxMaKhach.Text;
                hoadon.MaPhong = txtMaPhong.Text;
                hoadon.NgayBatDau = dtpNgayBatDau.Text;
                hoadon.NgayKetThuc = dtpNgayKetThuc.Text;
                hoadon.TienDien = tienDien;
                hoadon.TienNuoc = tienNuoc;
                hoadon.GiaPhong = gia;
                hoadon.TinhTrang = tinhTrang;
                hoadon.TongTien = tongTien;
                hoadon.NgayXuat = dtpNgayXuat.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool KiemTraGiatriNhap()
        {
            return KiemTraMaKhach() && KiemTraNgayBatDauNgayKetThuc() && KiemTraTienDienNuoc() && KiemTraTinhTrang() && KiemTraTongTien() && KiemTraNgayXuat();
        }

        bool KiemTraMaKhach()
        {
            if(cbxMaKhach.DataSource == null)
            {
                MessageBox.Show("Mã Khách Không Tồn Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMaKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraNgayBatDauNgayKetThuc()
        {
            DateTime ngayHientai = DateTime.Now.Date;
            DateTime thangTruoc = ngayHientai.AddMonths(-1) ;
            if (dtpNgayBatDau.Value.Date > ngayHientai || dtpNgayBatDau.Value.Date < thangTruoc )
            {
                MessageBox.Show("Ngày Bắt Đầu Phải Phải Nhỏ Hơn 1 Tháng Truóc Ngày Hiện Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayBatDau.Focus();
                return false;
            }

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date; 
            DateTime ngayBatDauThem1Thang = ngayBatDau.AddMonths(1);
            if (ngayKetThuc > ngayHientai || ngayKetThuc > ngayBatDauThem1Thang)
            {
                MessageBox.Show("Ngày Kết Thúc Phải Nhỏ Hoặc Bằng 1 Tháng Tính Từ Ngày Bắt Đầu", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayKetThuc.Focus();
                return false;
            }
            if (ngayKetThuc == ngayBatDau )
            {
                MessageBox.Show("Ngày Kết Thúc Không Được Bằng Ngày Bắt Đầu", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayKetThuc.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraNgayXuat()
        {
            DateTime ngayHientai = DateTime.Now.Date;
            DateTime tuanTruoc = ngayHientai.AddDays(-7);
            DateTime tuanToi = ngayHientai.AddDays(7);
            if (dtpNgayXuat.Value.Date > tuanToi || dtpNgayXuat.Value.Date < tuanTruoc)
            {
                MessageBox.Show("Ngày Xuất Hóa Đơn Phải Nằm trong 7 Ngày Trước Tính Từ Ngày Hiện Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayXuat.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTienDienNuoc()
        {
            float tienDien = 0, tienNuoc = 0;
            if (txtTienDien.Text.Length == 0 || txtTienNuoc.Text.Length == 0) 
            {
                MessageBox.Show("Tiền Điện Và Tiền Nước Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            if (!float.TryParse(txtTienDien.Text,out tienDien) || !float.TryParse(txtTienNuoc.Text, out tienNuoc) )
            {
                MessageBox.Show("Tiền Điện Và Tiền Nước Vui Lòng Nhập Số", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }

            if (tienDien < 0 || tienNuoc < 0)
            {
                MessageBox.Show("Tiền Điện Và Tiền Nước Không Thể Là Số Âm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrang()
        {
            if (!radioButtonThu.Checked && !radioButtonChua.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Tình Trạng Hóa Đơn", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangThem()
        {
            if (radioButtonThu.Checked==true)
            {
                MessageBox.Show("Hóa Đơn Mới Phải Là Chưa Thu", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangDaThu()
        {
            if (radioButtonThu.Checked == true)
            {
                MessageBox.Show("Hóa Đơn Đã Thu Không Thể Sửa", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTonTaiHoaDon()
        {
            if (_8_HoaDon_BUS.KiemTraTonTaiHoaDon(cbxMaKhach.Text,dtpNgayBatDau.Text, dtpNgayKetThuc.Text))
            {
                MessageBox.Show("Hóa Đơn đã Tồn Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Cần Tìm ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTongTien()
        {
            if (txtTongTien.Text.Length==0)
            {
                MessageBox.Show("Bạn Chưa Tính Tiền Hóa Đơn", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTongTien.Focus();
                return false;
            }
            return true;
        }

        public static void TinhTrangHoaDon(string maKhach)
        {
            try
            {
                string tinhTrangHoaDon = _8_HoaDon_BUS.TinhTranHoaDon(maKhach);
                if (!string.IsNullOrEmpty(tinhTrangHoaDon))
                {
                    TinhTrang = tinhTrangHoaDon;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Hàm Xử Lý Dữ Liệu
        void ThemHoaDon()
        {
            try
            {
                if (_8_HoaDon_BUS.ThemHoaDon(hoadon))
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Hóa Đơn Mới Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Hóa Đơn Mới Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void SuaHoaDon()
        {
            try
            {
                if (_8_HoaDon_BUS.SuaHoaDon(hoadon))
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Hóa Đơn: " +txtMaHD.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ThanToanHoaDon()
        {
            try
            {
                if (_8_HoaDon_BUS.XoaHoaDon(txtMaHD.Text))
                {
                    MessageBox.Show("Bạn Đã Thah Toán Hóa Đơn: " + txtMaHD.Text + "Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thanh Toán Hóa Đơn " + txtMaHD.Text + "Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void TimKiemHoaDon()
        {
            try
            {
                DataTable danhSach = _8_HoaDon_BUS.TimKiemHoaDon(txtTimKiem.Text); 
                if (danhSach.Rows.Count > 0)
                {
                    dgvDSHoaDon.DataSource = danhSach;
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy Hợp Đồng Này ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        void ChucNang_ThemHoaDon()
        {
            try
            {
                if (!KiemTraGiatriNhap() || !KiemTraTonTaiHoaDon() || !KiemTraTinhTrangThem())
                    return;

                GiaTriNhap();


                DialogResult result = MessageBox.Show("Bạn Muốn Thêm Hóa Đơn Mới ", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Thêm Hóa Đơn Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Thêm Hóa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ThemHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_SuaHoaDon()
        {
            try
            {
                if (!KiemTraGiatriNhap()||!KiemTraTinhTrangDaThu())
                    return;

                GiaTriNhap();


                DialogResult result = MessageBox.Show("Bạn Muốn Sửa Thông Tin Hóa Đơn " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Sửa Thông Tin Hóa Đơn " + txtMaHD.Text , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Sửa Thông Tin Hóa Đơn" + txtMaHD.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SuaHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }

        }

        void ChucNang_XoaHoaDon()
        {
            try
            {
                if (MessageBox.Show("Bạn Muốn Thanh Toán Hóa Đơn " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    MessageBox.Show("Bạn Đã Thanh Toán " + txtMaHD.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ThanToanHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_TimKiemHoaDon()
        {
            try
            {
                if (!KiemTraTimKiem())
                    return;
                TimKiemHoaDon();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }

        void ChucNang_TinhTong()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
           
            float tienDien = float.Parse(txtTienDien.Text);
            float tienNuoc = float.Parse(txtTienNuoc.Text);
            float giaPhong = float.Parse(txtGiaPhong.Text);
            float tongTien = tienDien + tienNuoc + giaPhong;
            txtTongTien.Text =  tongTien.ToString("c", culture).Replace("₫", "");
        }

        void ChucNang_XuatFile()
        {
            try
            {
                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo worksheet mới
                    var worksheet = workbook.Worksheets.Add("DanhSachHoaDon");

                    // Đặt tiêu đề cho các cột
                    for (int i = 0; i < dgvDSHoaDon.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvDSHoaDon.Columns[i].HeaderText;
                    }

                    // Điền dữ liệu từ DataGridView vào worksheet
                    for (int row = 0; row < dgvDSHoaDon.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvDSHoaDon.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dgvDSHoaDon.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // Lưu workbook ra file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "Danh_Sach_Hoa_Don " + txtMaHD.Text +  ".xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Chức Năng
        private void dgvDSHoaDon_Click(object sender, EventArgs e)
        {
            radioButtonThu.Enabled = false;
            HienDanhSach();
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void cbxMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string maphong = KhachThue_BUS.DanhSachMaPhongCuaKhach(cbxMaKhach.Text);
            txtMaPhong.Text = maphong;
            float gia;
            txtGiaPhong.Text = PhongTro_BUS.DanSachGiaPhong(txtMaPhong.Text);
            float.TryParse(txtGiaPhong.Text, out gia);
            txtGiaPhong.Text = gia.ToString("c", culture).Replace("₫", "");
        }


        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi(); 
            DanhSachKhach();
        }

        private void btnHienDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void btnChayLai_Click(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang_ThemHoaDon();
        }

        private void btnSuaDon_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            ChucNang_SuaHoaDon();
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            ChucNang_XoaHoaDon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKiemHoaDon();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            ChucNang_XuatFile();
        }

        private void btnTongTien_Click(object sender, EventArgs e)
        {
            ChucNang_TinhTong();
        }

        private void checkBoxDaThu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDaThu.Checked == true)
            {
                radioButtonChua.Enabled = false;
                dgvDSHoaDon.DataSource = _8_HoaDon_BUS.DanhSachHoaDonDaThu();
                CotDuLieu();
            }
            else
            {
                radioButtonChua.Enabled = true;
                TaiDanhSach();
                GiaTriMoi();
            }
        }
        #endregion
    }
}
