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
    public partial class frm_HopDong : Form
    {
        Hop_Dong_DTO hopdong = new Hop_Dong_DTO();
        public static string maHopDong { get; set; }
        public static float TienCoc { get; set; }
        public static float giaPhong { get; set; }
        public frm_HopDong()
        {
            InitializeComponent();
            TaiDanhSach();
        }
        #region Giá Trị
        void GiaTriBanDau()
        {
            txtMaHD.Text = null;
            txtNguoiDung.Text = null;
            cbxMaKhach.DataSource = null;
            txtMaPhong.Text = null;
            dtpNgayBatDau.Value = DateTime.Now.Date;
            dtpNgayKetThuc.Value = DateTime.Now.Date;
            txtTienDien.Text = null;
            txtTienNuoc.Text = null;
            txtCoc.Text = null;
            txtThue.Text = null;
            txtTimKiem.Text = null;
            dgvHopDong.DataSource = null;
            radioButtonCon.Checked = false;
            radioButtonHet.Checked = false;

            txtMaHD.Enabled = false;
            txtNguoiDung.Enabled = false;
            cbxMaKhach.Enabled = false;
            txtMaPhong.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            dtpNgayKetThuc.Enabled = false;
            txtTienDien.Enabled = false;
            txtTienNuoc.Enabled = false;
            txtCoc.Enabled = false;
            txtThue.Enabled = false;
            txtTimKiem.Enabled = false;
            radioButtonCon.Enabled = false;
            radioButtonHet.Enabled = false;

            btnKhoiDong.Enabled = true;
            btnHienDanhSach.Enabled = false;
            btnChayLai.Enabled = false;
            btnThemHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnHuyHD.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXuatHD.Enabled = false;
        }

        void GiaTriMoi()
        {
            txtMaHD.Text = null;
            txtMaPhong.Text = null;
            dtpNgayBatDau.Value = DateTime.Now.Date;
            dtpNgayKetThuc.Value = DateTime.Now.Date;
            txtTienDien.Text = null;
            txtTienNuoc.Text = null;
            txtCoc.Text = null;
            txtThue.Text = null;
            txtTimKiem.Text = null;
            radioButtonCon.Checked = false;
            radioButtonHet.Checked = false;

            txtMaHD.Enabled = true;
            txtNguoiDung.Enabled = true;
            cbxMaKhach.Enabled = true;
            txtMaPhong.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;
            txtTienDien.Enabled = true;
            txtTienNuoc.Enabled = true;
            txtCoc.Enabled = true;
            txtThue.Enabled = true;
            txtTimKiem.Enabled = true;
            radioButtonCon.Enabled = true;
            radioButtonHet.Enabled = true;

            btnKhoiDong.Enabled = false;
            btnHienDanhSach.Enabled = true;
            btnChayLai.Enabled = true;
            btnThemHD.Enabled = true;
            btnSuaHD.Enabled = true;
            btnHuyHD.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXuatHD.Enabled = true;
        }
        #endregion

        #region Danh Sách 
        void CotDuLieu()
        {
            dgvHopDong.Columns[0].HeaderText = "Mã Hợp Đồng";
            dgvHopDong.Columns[1].HeaderText = "Mã Người Dùng";
            dgvHopDong.Columns[2].HeaderText = "Mã Khách";
            dgvHopDong.Columns[3].HeaderText = "Mã Phòng";
            dgvHopDong.Columns[4].HeaderText = "Ngày Bất Đầu";
            dgvHopDong.Columns[5].HeaderText = "Ngày Kết Thúc";
            dgvHopDong.Columns[6].HeaderText = "Chỉ Số Điện /KWh";
            dgvHopDong.Columns[7].HeaderText = "Chỉ Số Nước /m3";
            dgvHopDong.Columns[8].HeaderText = "Tiền Cọc";
            dgvHopDong.Columns[9].HeaderText = "Tiền Thuê";
            dgvHopDong.Columns[10].HeaderText = "Tình Trạng";
        }

        void HienDanhSach()
        {
            try
            {
                CultureInfo culture = new CultureInfo("vi-VN");

                if (dgvHopDong.Rows.Count > 0)
                {
                    var currentRow = dgvHopDong.CurrentRow.Cells;

                    txtMaHD.Text = currentRow["MaHopDong"].Value.ToString();
                    txtNguoiDung.Text = currentRow["MaNguoiDung"].Value.ToString();
                    cbxMaKhach.Text = currentRow["MaKhach"].Value.ToString();
                    txtMaPhong.Text = currentRow["MaPhong"].Value.ToString();
                    dtpNgayBatDau.Text = currentRow["NgayBatDau"].Value.ToString();
                    dtpNgayKetThuc.Text = currentRow["NgayKetThuc"].Value.ToString();
                    txtTienDien.Text = currentRow["ChiSoDien"].Value.ToString();
                    txtTienNuoc.Text = currentRow["ChiSoNuoc"].Value.ToString();
                    txtCoc.Text = currentRow["TienCoc"].Value.ToString();
                    txtThue.Text = currentRow["TienThue"].Value.ToString();

                    string tinhtrang = currentRow["TinhTrang"].Value.ToString();
                    radioButtonCon.Checked = tinhtrang == "Còn Hạn";
                    radioButtonHet.Checked = tinhtrang == "Hết Hạn";

                    float tienCoc, tienThue, tienDien, tienNuoc;
                    float.TryParse(txtCoc.Text, out tienCoc);
                    float.TryParse(txtThue.Text, out tienThue);
                    float.TryParse(txtTienDien.Text, out tienDien);
                    float.TryParse(txtTienNuoc.Text, out tienNuoc);


                    txtCoc.Text = tienCoc.ToString("c", culture).Replace("₫", "");
                    txtThue.Text = tienThue.ToString("c", culture).Replace("₫", "");
                    txtTienDien.Text = tienDien.ToString("c", culture).Replace("₫", "");
                    txtTienNuoc.Text = tienNuoc.ToString("c", culture).Replace("₫", "");
                    maHopDong = txtMaHD.Text;
                    TienCoc = tienCoc;
                    giaPhong = tienThue;

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

        void DanhSachKhach()
        {
            txtNguoiDung.Text = frm_Main.email;
            cbxMaKhach.DataSource = KhachThue_BUS.DanhSachMaKhach();
            cbxMaKhach.DisplayMember = "MaKhach";
        }

        void TaiDanhSach()
        {
            dgvHopDong.DataSource = _6_HopDong_BUS.DanhSachHopDongConHan();
            CotDuLieu();
        }

        #endregion

        #region Nghiệp Vụ
        void GiaTriNhap()
        {
            try
            {
                float tienDien = float.Parse(txtTienDien.Text);
                float tienNuoc = float.Parse(txtTienNuoc.Text);
                float tienCoc = float.Parse(txtCoc.Text);
                float tienThue = float.Parse(txtThue.Text);
                string tinhTrang = radioButtonCon.Checked ? "Còn Hạn" : "Hết Hạn";
                hopdong.MaHopDong = txtMaHD.Text;
                hopdong.MaKhach = cbxMaKhach.Text;
                hopdong.MaPhong = txtMaPhong.Text;
                hopdong.NgayBatDau = DateTime.Parse(dtpNgayBatDau.Text);
                hopdong.NgayKetThuc = DateTime.Parse(dtpNgayKetThuc.Text);
                hopdong.ChiSoDien = tienDien;
                hopdong.ChiSoNuoc = tienNuoc;
                hopdong.TienCoc = tienCoc;
                hopdong.TienThue = tienThue;
                hopdong.TinhTrang = tinhTrang;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool KiemTraGiaTriNhap()
        {
            return
                KiemTraMaNguoiDung() &&
                KiemTraMaKhach() &&
                KiemTraMaPhong() &&
                KiemTraNgayBatDauNgayKetThuc() &&
                KiemTraChiSoDienNuoc() &&
                KiemTraTienCocTienThue() &&
                KiemTraTinhTrang();
        }

        bool KiemTraMaHopDong()
        {
            if (txtMaHD.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Chọn Hợp Đồng ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMaKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraMaNguoiDung()
        {
            if (txtNguoiDung.Text.Length == 0)
            {
                MessageBox.Show("Mã Người Dùng Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMaKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraMaKhach()
        {
            if (cbxMaKhach.Text.Length == 0)
            {
                MessageBox.Show("Mã Khách Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMaKhach.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraMaPhong()
        {
            if (txtMaPhong.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Chọn Mã Khách", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxMaKhach.Focus();
                return false;
            }
            return true;
        }


        bool KiemTraNgayBatDauNgayKetThuc()
        {
            DateTime ngayHientai = DateTime.Now.Date;
            DateTime tuanToi = ngayHientai.AddDays(7);
            if (dtpNgayBatDau.Value.Date < ngayHientai || dtpNgayBatDau.Value.Date > tuanToi)
            {
                MessageBox.Show("Ngày Bắt Đầu Phải Nằm Trong Khoảng 7 Ngày Từ Ngày Hiện Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayBatDau.Focus();
                return false;
            }

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
            DateTime ngayBatDauThem6Thang = ngayBatDau.AddMonths(6);
            DateTime ngayBatDauThem1Nam = ngayBatDau.AddMonths(12);
            if (ngayKetThuc <= ngayBatDauThem6Thang || ngayKetThuc > ngayBatDauThem1Nam)
            {
                MessageBox.Show("Ngày Kết Thúc Phải Từ 6 Tháng Đến 1 Năm Tính Từ Ngày Bất Đầu", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayKetThuc.Focus();
                return false;
            }
            return true;
        }
        bool KiemTraNgayThoiGianHopDong()
        {

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
            DateTime ngayBatDauThem6Thang = ngayBatDau.AddMonths(6);
            DateTime ngayBatDauThem1Nam = ngayBatDau.AddMonths(12);

            if (ngayBatDau > ngayKetThuc)
            {
                TimeSpan conlai = ngayKetThuc - ngayBatDau;
                MessageBox.Show("Hợp Đồng Còn Thời Hạn " + conlai, "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayKetThuc.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraChiSoDienNuoc()
        {
            float tienDien, tienNuoc;
            if (txtTienDien.Text.Length == 0 || txtTienNuoc.Text.Length == 0)
            {
                MessageBox.Show("Chỉ Số Điện Và Chỉ Số Nước Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            if (!float.TryParse(txtTienDien.Text, out tienDien) || !float.TryParse(txtTienNuoc.Text, out tienNuoc))
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
            if (tienDien >= 5000 || tienNuoc >= 5000)
            {
                MessageBox.Show("Tiền Điện Và Tiền Nước Không Thể Lớn Hớn 5000", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }




        bool KiemTraTienCocTienThue()
        {
            double tienCoc, tienThue;


            // Loại bỏ khoảng trắng
            string coc = txtCoc.Text.Trim();
            string thue = txtThue.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(coc) || string.IsNullOrEmpty(thue))
            {
                MessageBox.Show("Tiền Cọc Và Tiền Thuê Không Thể Bỏ Trống", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCoc.Focus();
                return false;
            }

            // Loại bỏ dấu phân tách hàng nghìn (nếu có)
            coc = coc.Replace(",", "").Replace(".", "");
            thue = thue.Replace(",", "").Replace(".", "");

            // Kiểm tra có phải số hợp lệ không
            if (!double.TryParse(coc, NumberStyles.Number, CultureInfo.InvariantCulture, out tienCoc) ||
                !double.TryParse(thue, NumberStyles.Number, CultureInfo.InvariantCulture, out tienThue))
            {
                MessageBox.Show("Tiền Cọc Và Tiền Thuê Vui Lòng Nhập Số Hợp Lệ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCoc.Focus();
                return false;
            }

            // Kiểm tra số âm
            if (tienCoc < 0 || tienThue < 0)
            {
                MessageBox.Show("Tiền Cọc Và Tiền Thuê Không Thể Là Số Âm", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCoc.Focus();
                return false;
            }

            return true;
        }




        bool KiemTraTinhTrang()
        {
            if (!radioButtonCon.Checked && !radioButtonHet.Checked)
            {
                MessageBox.Show("Bạn Chưa Chọn Tình Trạng Hợp Đồng", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienDien.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTinhTrangHienTai()
        {
            if (radioButtonHet.Checked == true)
            {
                MessageBox.Show("Vui Lòng Chọn Tình Trạng Còn Hạn Cho Hợp Đồng Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonCon.Focus();
                return false;
            }
            return true;
        }
        bool KiemTraTinhTrangHienTaiHetHan()
        {
            if (radioButtonHet.Checked == true)
            {
                MessageBox.Show("Hợp Đồng Đã Hết Hạn Không Thể Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButtonCon.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTonTai()
        {
            //string tinhtrang;
            //radioButtonCon.Checked = tinhtrang == "Còn Hạn";
            //radioButtonHet.Checked = tinhtrang == "Hết Hạn";
            if (_6_HopDong_BUS.KiemTraTonTaiHopDong(cbxMaKhach.Text))
            {
                MessageBox.Show("Hợp Đồng đã Tồn Tại", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Focus();
                return false;
            }
            return true;
        }

        bool KiemTraTimKiem()
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Cần Tìm ", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Hàm Xử Lý Dữ Liệu
        void ThemHopDong()
        {
            try
            {
                hopdong.Email = frm_Main.email;
                if (_6_HopDong_BUS.ThemHopDong(hopdong))
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Hợp Đồng Mới Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Thêm 1 Hợp Đồng Mới Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void SuaHopDong()
        {
            try
            {
                hopdong.Email = frm_Main.email;
                if (_6_HopDong_BUS.SuaHopDong(hopdong))
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Hợp Đồng: " + txtMaHD.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSach();
                    GiaTriMoi();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Sửa Thông Tin Hợp Đồng: " + txtMaHD.Text + " Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //void HuyHopDong()
        //{
        //    try
        //    {
        //        if (_6_HopDong_BUS.XoaHogDong(txtMaHD.Text))
        //        {
        //            frm_ViPham viPham = new frm_ViPham();
        //            viPham.ShowDialog();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Bạn Đã Xóa Hợp Đồng " + txtMaHD.Text + "Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            TaiDanhSach();
        //            GiaTriMoi();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        GiaTriMoi();
        //    }
        //}

        void TimKiemHopDong()
        {
            try
            {
                DataTable danhSach = _6_HopDong_BUS.TiemKiemHopDong(txtTimKiem.Text, txtTimKiem.Text);
                if (danhSach.Rows.Count > 0)
                {
                    dgvHopDong.DataSource = danhSach;
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
        void ChucNang_ThemHopDong()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraTonTai() || !KiemTraTinhTrangHienTai())
                    return;

                GiaTriNhap();


                DialogResult result = MessageBox.Show("Bạn Muốn Thêm Hợp Đồng Mới ", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Thêm Hợp Đồng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Thêm Hóa Đơn Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ThemHopDong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }
        void ChucNang_SuaHopDong()
        {
            try
            {
                if (!KiemTraGiaTriNhap() || !KiemTraTinhTrangHienTaiHetHan() || !KiemTraTonTai())
                    return;

                GiaTriNhap();


                DialogResult result = MessageBox.Show("Bạn Muốn Sửa Hợp Đồng  " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Sửa Hợp Đồng " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Sửa Hợp Đồng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SuaHopDong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }
        void ChucNang_HuyHopDong()
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn Muốn Hủy Hợp Đồng  " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    MessageBox.Show("Bạn Đã Hủy Thao Tác Hủy Hợp Đồng " + txtMaHD.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaTriMoi();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Hủy Hợp Đồng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!KiemTraMaHopDong())
                        return;
                    else
                    {
                        frm_ViPham viPham = new frm_ViPham();
                        viPham.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GiaTriMoi();
            }
        }
        void ChucNang_TimKiemHopDong()
        {
            if (!KiemTraTimKiem())
                return;
            TimKiemHopDong();
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
                    for (int i = 0; i < dgvHopDong.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvHopDong.Columns[i].HeaderText;
                    }

                    // Điền dữ liệu từ DataGridView vào worksheet
                    for (int row = 0; row < dgvHopDong.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvHopDong.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dgvHopDong.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // Lưu workbook ra file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "DanhSachHopDong " + txtMaHD.Text + " " + DateTime.Now + ".xlsx";

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
        private void dgvHopDong_Click(object sender, EventArgs e)
        {
            HienDanhSach();
            radioButtonHet.Enabled = false;
        }

        private void frm_HopDong_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void cbxMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            float thue;

            txtMaPhong.Text = KhachThue_BUS.DanhSachMaPhongCuaKhach(cbxMaKhach.Text);
            txtThue.Text = PhongTro_BUS.DanSachGiaPhong(txtMaPhong.Text);

            float.TryParse(txtThue.Text, out thue);
            txtThue.Text = thue.ToString("c", culture).Replace("₫", "");
        }
        private void checkBoxHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHetHan.Checked)
            {
                dgvHopDong.DataSource = _6_HopDong_BUS.DanhSachHopDongHetHan();
                radioButtonCon.Enabled = false;
            }
            else
            {
                txtNguoiDung.Text = frm_Main.email;
                radioButtonCon.Enabled = true;
                TaiDanhSach();
                GiaTriMoi();
            }
        }


        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            GiaTriMoi();
            DanhSachKhach();
            TaiDanhSach();
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

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ChucNang_ThemHopDong();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            ChucNang_SuaHopDong();
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            ChucNang_HuyHopDong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChucNang_TimKiemHopDong();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            ChucNang_XuatFile();
        }
        #endregion

        private void txtCoc_TextChanged(object sender, EventArgs e)
        {
            string input = txtCoc.Text;
            string filtered = "";

            foreach (char c in input)
            {
                if (char.IsDigit(c))  // Chỉ cho phép nhập số
                {
                    filtered += c;
                }
            }

            if (input != filtered)
            {
                txtCoc.Text = filtered;
                txtCoc.SelectionStart = filtered.Length;
            }
        }

        private void txtTienDien_TextChanged(object sender, EventArgs e)
        {

        }

        //private void txtThue_TextChanged(object sender, EventArgs e)
        //{
        //    txtThue.Text = LoaiBoKyTuKhongPhaiSo(txtThue.Text);
        //    txtThue.SelectionStart = txtThue.Text.Length;
        //}

        private string LoaiBoKyTuKhongPhaiSo(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        private void txtThue_TextChanged_1(object sender, EventArgs e)
        {
            txtThue.Text = LoaiBoKyTuKhongPhaiSo(txtThue.Text);
            txtThue.SelectionStart = txtThue.Text.Length;
        }
    }
}
