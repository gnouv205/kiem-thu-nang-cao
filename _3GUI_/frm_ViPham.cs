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
    public partial class frm_ViPham : Form
    {
        Vi_Pham_Hop_Dong_DTO viPham = new Vi_Pham_Hop_Dong_DTO();
        CultureInfo culture = new CultureInfo("vi-VN");
        public frm_ViPham()
        {
            InitializeComponent();
            TaiDanhSach();
        }
        void GiaTriMoi()
        {
            txtMaViPham.Text = null;
            txtMaND.Text = null;
            txtMaHD.Text = null;
            txtMaKhach.Text = null;
            txtMaPhong.Text = null;
            radioButtonKhach.Checked = false;
            radioButtonChu.Checked = false;
            txtNoiDung.Text = null;
            dtpNgayViPham.Value = DateTime.Now.Date;
            txtBienPhap.Text = null;
            txtBoiThuong.Text = null;
        } 

        #region Danh Sách
        void ThongTinHopDong()
        {
            txtMaHD.Text=_6_HopDong_BUS.ThongTinMaHopDong(frm_HopDong.maHopDong);
            txtMaND.Text=_6_HopDong_BUS.ThongTinNguoiDungHopDong(frm_HopDong.maHopDong);
            txtMaKhach.Text=_6_HopDong_BUS.ThongTinKhachHopDong(frm_HopDong.maHopDong);
            txtMaPhong.Text=_6_HopDong_BUS.ThongTinMaPhongHopDong(frm_HopDong.maHopDong);
        }

        void CotDuLieu()
        {
            dgvViPham.Columns[0].HeaderText = "Mã Vi Phạm";
            dgvViPham.Columns[1].HeaderText = "Mã Hợp Đồng";
            dgvViPham.Columns[2].HeaderText = "Mã Người Dùng";
            dgvViPham.Columns[3].HeaderText = "Mã Khách";
            dgvViPham.Columns[4].HeaderText = "Mã Phòng";
            dgvViPham.Columns[5].HeaderText = "Người Vi Phạm";
            dgvViPham.Columns[6].HeaderText = "Nội Dung Vi Phạm";
            dgvViPham.Columns[7].HeaderText = "Ngày Vi Phạm";
            dgvViPham.Columns[8].HeaderText = "Ngày Hủy";
            dgvViPham.Columns[9].HeaderText = "Biện Pháp Xử Lý";
            dgvViPham.Columns[10].HeaderText = "Tiền Bồi Thường";
            dgvViPham.Columns[11].HeaderText = "Tình Trạng";
        }
        void TaiDanhSach()
        {
            dgvViPham.DataSource = _7_ViPhamHopDong_BUS.DanhSachHopDongChuaHuy();
            CotDuLieu();
        }
        void HienDanhSach()
        {
            try
            {
                if (dgvViPham.Rows.Count> 0)
                {
                    var currentRow = dgvViPham.CurrentRow.Cells;
                    txtMaViPham.Text = currentRow["MaViPham"].Value.ToString();
                    txtMaHD.Text = currentRow["MaHopDong"].Value.ToString();
                    txtMaND.Text = currentRow["MaNguoiDung"].Value.ToString();
                    txtMaKhach.Text = currentRow["MaKhach"].Value.ToString();
                    txtMaPhong.Text = currentRow["MaPhong"].Value.ToString();
                    txtNoiDung.Text = currentRow["NoiDungViPham"].Value.ToString();
                    txtBienPhap.Text = currentRow["BienPhapXuLy"].Value.ToString();
                    dtpNgayViPham.Text = currentRow["NgayViPham"].Value.ToString();
                    dtpNgayHuy.Text = currentRow["NgayHuy"].Value.ToString();
                    txtBoiThuong.Text = currentRow["TienBoiThuong"].Value.ToString();

                    string nguoiVP = currentRow["NguoiViPham"].Value.ToString();
                    radioButtonChu.Checked = nguoiVP == "Chủ Thuê";
                    radioButtonKhach.Checked = nguoiVP == "Khách Thuê";


                    string tinhTrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonChua.Checked = tinhTrang == "Chưa Hủy";
                    radioButtonHuy.Checked = tinhTrang == "Hủy";

                    float boiThuong;
                    float.TryParse(txtBoiThuong.Text, out boiThuong);
                    txtBoiThuong.Text = boiThuong.ToString("c", culture).Replace("₫", "");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Nghiệp Vụ
        bool KiemTraTinhTrangHoaDon()
        {
            frm_HoaDon.TinhTrangHoaDon(txtMaKhach.Text);
            if (frm_HoaDon.TinhTrang == "Chưa Thu") 
            {
                MessageBox.Show("Chưa Thanh Toán Hóa Đơn Nên Chưa Thể Hủy Hợp Đồng.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_HoaDon hoDon = new frm_HoaDon();
                hoDon.Show();
                this.Close();
                return false;
            }
            if(frm_HoaDon.TinhTrang == null)
            {
                MessageBox.Show("Khách Này Không Có Hóa Đơn. Bạn Đã Lập Bảng Hủy Hóa Đơn Cho Khách " +txtMaKhach.Text, "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return true;
        }

        void GiaTriNhap()
        {
            try {
                float tienBoiThuong = float.Parse(txtBoiThuong.Text);
                string nguoiViPham = radioButtonChu.Checked == true ? "Chủ Thuê" : "Khách Thuê";
                string tinhTrang = radioButtonChua.Checked == true ? "Chưa Hủy" : "Hủy";
                viPham.MaViPham = txtMaViPham.Text;
                viPham.MaHopDong = txtMaHD.Text;
                viPham.MaNguoiDung = txtMaND.Text;
                viPham.MaKhach = txtMaKhach.Text;
                viPham.MaPhong = txtMaPhong.Text;
                viPham.NoiDungViPham = txtNoiDung.Text;
                viPham.BienPhamXuLy = txtBienPhap.Text;
                viPham.NgayViPham = dtpNgayViPham.Text;
                viPham.NgayHuy = dtpNgayHuy.Text;
                viPham.NguoiViPham = nguoiViPham;
                viPham.TienBoiThuong = tienBoiThuong;
                viPham.TinhTrang = tinhTrang;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool KiemTraGiatriNhap()
        {
            return
                KiemTraNguoiViPham() &&
                KiemTraNoiDungViPham() &&
                KiemTraBienPhapXuLy() &&
                KiemTraBoiThuong();
        }

        bool KiemTraMaVP()
        {
            if (txtMaViPham.Text == "")
            {
                MessageBox.Show("Vui Lòng Lập Bảng Hủy Trước Khi Xác Nhận Hủy", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLap.Focus();
                return false;
            }
            return true;
        }
        bool KiemTraNguoiViPham()
        {
            if(!radioButtonChu.Checked && !radioButtonKhach.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Người Vi Phạm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonChu.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangLapBang()
        {
            if (radioButtonChua.Checked == false) 
            {
                MessageBox.Show("Vui Lòng Chọn Tình Trạng Chưa Hủy Để Lập Bảng Hủy ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonChua.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraPhuongThucTimKiem()
        {
            if (!radioButtonTimMaK.Checked || !radioButtonNgayKT.Checked)
            {
                MessageBox.Show("Vui Lòng Chọn Phương Thức Tìm Kiếm ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonChu.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraNoiDungViPham()
        {
            if (txtNoiDung.Text.Length == 0)
            {
                MessageBox.Show("Nội Dung Không Được Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonChu.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraBienPhapXuLy()
        {
            if (txtBienPhap.Text.Length==0)
            {
                MessageBox.Show("Biện Pháp Không Được Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBienPhap.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraNgayViPham()
        {
            DateTime ngayHientai = DateTime.Now.Date;
            DateTime tuanToi = ngayHientai.AddDays(7);
            if (dtpNgayViPham.Value.Date < ngayHientai || dtpNgayViPham.Value.Date > tuanToi)
            {
                MessageBox.Show("Ngày Vi Phạm Phải Nằm Trong Khoảng 7 Ngày Từ Ngày Hiện Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayViPham.Focus();
                return false;
            }
            return true;
        }
        bool KiemTraNgayHuy()
        {
            DateTime ngayhuy = dtpNgayHuy.Value;
            DateTime ngayViPham = dtpNgayViPham.Value;
            DateTime ngayViPham7ngay = dtpNgayViPham.Value.AddDays(7);
            if (ngayhuy < ngayViPham || ngayhuy > ngayViPham7ngay)
            {
                MessageBox.Show("Hủy Trong 7 Ngày Tính Từ Ngày Vi Phạm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayViPham.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraBoiThuong()
        {
            float boiThuong = 0;
            if (txtBoiThuong.Text.Length == 0)
            {
                MessageBox.Show("Bồi Thường Không Được Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoiThuong.Focus();
                return false;
            }
            if (!float.TryParse(txtBoiThuong.Text, out boiThuong)) 
            {
                MessageBox.Show("Tiền Bồi Thường Phải là Số", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoiThuong.Focus();
                return false;
            }
            if(boiThuong < 0)
            {
                MessageBox.Show("Tiền Bồi Thường Phải Lớn Hơn 0", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoiThuong.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Nội Dung Tìm Kiếm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangHuy()
        {
            if (radioButtonChua.Checked == true) 
            {
                MessageBox.Show("Bạn Hủy Không Thành Công Vì Đã Chọn Trạng Thái Chưa Hủy", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonChua.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Hàm Xử lý Dữ Liệu
        void HopDongCanHuy()
        {
            try
            {
                if (_7_ViPhamHopDong_BUS.HopDongCanHuy(viPham))
                {
                    MessageBox.Show("Bạn Bạn Đã Lập Bảng Hủy Hợp Đồng " + txtMaHD.Text + " Thành Công" , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn Bạn Đã Lập Bảng Hủy Hợp Đồng " + txtMaHD.Text +" Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void XacNhanHuy()
        {
            try
            {
                if (_7_ViPhamHopDong_BUS.HopDongXacNhanHuy(viPham))
                {
                    MessageBox.Show("Bạn Đã Hủy Hợp Đồng: " + txtMaHD.Text +" Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                    TaiDanhSach();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Hủy Hợp Đồng " + txtMaHD.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TimKiemMaHoacNgay()
        {
            try
            {
                DataTable danhSach = new DataTable();
                if (radioButtonTimMaK.Checked == true)
                {
                    danhSach = _7_ViPhamHopDong_BUS.TimKiemMaKhach(txtTimKiem.Text);
                    if (danhSach.Rows.Count > 0)
                    {
                        dgvViPham.DataSource = danhSach;
                    }
                    else
                    {
                        MessageBox.Show("Không Tìm Thấy Hợp Đồng Này ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiem.Focus();
                    }
                }
                if (radioButtonNgayKT.Checked == true) 
                {
                    danhSach = _7_ViPhamHopDong_BUS.TimKiemNgayviPham(txtTimKiem.Text);
                    if (danhSach.Rows.Count > 0)
                    {
                        dgvViPham.DataSource = danhSach;
                    }
                    else
                    {
                        MessageBox.Show("Không Tìm Thấy Hợp Đồng Này ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiem.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Hàm Thực Thi Chức Năng
        void ChucNang_LapBangHuy()
        {
            try
            {
                if ( !KiemTraGiatriNhap() || !KiemTraNgayViPham() || !KiemTraTinhTrangLapBang() ||!KiemTraTinhTrangHoaDon())
                    return;
                GiaTriNhap();

                DialogResult result = MessageBox.Show("Bạn Muốn Lập Bảng Hủy Hợp Đồng  " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Lập Bảng Hủy Hợp Đồng " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Lập Bảng Hủy Hợp Đồng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HopDongCanHuy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void ChucNang_XacNhan()
        {
            try
            {
                if (!KiemTraGiatriNhap() || !KiemTraMaVP() || !KiemTraTinhTrangHuy() || !KiemTraNgayHuy()) 
                    return;
                GiaTriNhap();

                    DialogResult result = MessageBox.Show("Bạn Xác Nhận Hủy Hợp Đồng  " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Xác Nhận Hủy Hợp Đồng " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Hủy Hợp Đồng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XacNhanHuy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                    for (int i = 0; i < dgvViPham.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvViPham.Columns[i].HeaderText;
                    }

                    // Điền dữ liệu từ DataGridView vào worksheet
                    for (int row = 0; row < dgvViPham.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvViPham.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dgvViPham.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // Lưu workbook ra file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "Danh_Sach_Huy_Hop_Dong " + txtMaHD.Text + ".xlsx";

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

        void ChucNang_TimKim()
        {
            if (!KiemTraTimKiem() || !KiemTraPhuongThucTimKiem())
                return;
            TimKiemMaHoacNgay();
        }

        void SuKienThayDoiNguoiVP()
        {
            try
            {
                string nguoiViPham = radioButtonChu.Checked == true ? "Chủ Thuê" : "Khách Thuê";
                float tienBoiThuong;
                float tienCoc = frm_HopDong.TienCoc;
                float tienPong = frm_HopDong.giaPhong;
                if (nguoiViPham == "Chủ Thuê")
                {
                    txtBienPhap.Text = "Trả Tiền Cọc Và Cộng Thêm 1 Tháng Phòng";
                    tienBoiThuong = tienCoc + tienPong;
                    txtBoiThuong.Text = tienBoiThuong.ToString("c", culture).Replace("₫", "");
                }
                if (nguoiViPham == "Khách Thuê")
                {
                    txtBienPhap.Text = "Mất Tiền Cọc Và Cộng Thêm 1 Tháng Phòng";
                    tienBoiThuong = tienPong;
                    txtBoiThuong.Text = tienBoiThuong.ToString("c", culture).Replace("₫", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chức Năng

        private void btnHienDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKim();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ChucNang_XuatFile();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            ChucNang_LapBangHuy();
        }

        private void btnXacNhanHuy_Click(object sender, EventArgs e)
        {
            ChucNang_XacNhan();
        }
        private void dgvViPham_Click(object sender, EventArgs e)
        {
            HienDanhSach();
        }

        private void frm_ViPham_Load(object sender, EventArgs e)
        {
            ThongTinHopDong();
        }

        private void checkBoxDaHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDaHuy.Checked == true)
            {
                radioButtonChua.Enabled = false;
                dgvViPham.DataSource = _7_ViPhamHopDong_BUS.DanhSachHopDongHuy();
                CotDuLieu();
            }
            else
            {
                radioButtonChua.Enabled = true;
                TaiDanhSach();
            }
        }

        private void radioButtonKhach_CheckedChanged(object sender, EventArgs e)
        {
            SuKienThayDoiNguoiVP();
        }
        #endregion
    }
}
