using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2BUS_;
using _DTO_;
using ClosedXML.Excel;

namespace _3GUI_
{
    public partial class frm_ThongKeHoaDon : Form
    {
        public frm_ThongKeHoaDon()
        {
            InitializeComponent();
        }

        void CotDuLieu()
        {
            dtgvDSHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dtgvDSHoaDon.Columns[1].HeaderText = "Mã Khách";
            dtgvDSHoaDon.Columns[2].HeaderText = "Mã Phòng";
            dtgvDSHoaDon.Columns[3].HeaderText = "Ngày Bất Đầu";
            dtgvDSHoaDon.Columns[4].HeaderText = "Ngày Kết Thúc";
            dtgvDSHoaDon.Columns[5].HeaderText = "Tiên Nước ";
            dtgvDSHoaDon.Columns[6].HeaderText = "Tiền Điện";
            dtgvDSHoaDon.Columns[7].HeaderText = "Giá Phòng";
            dtgvDSHoaDon.Columns[8].HeaderText = "Tình Trạng";
            dtgvDSHoaDon.Columns[9].HeaderText = "Tổng Tiền";
            dtgvDSHoaDon.Columns[10].HeaderText = "Ngày Xuất Hóa Đơn";
        }

        void TaiDanhSachDaThu()
        {
            dtgvDSHoaDon.DataSource = _8_HoaDon_BUS.DanhSachHoaDonDaThuTheoNgayXuat(dtpNgayXuat.Text);
            CotDuLieu();
        }
        void TaiDanhSachChuaThu()
        {
            dtgvDSHoaDon.DataSource = _8_HoaDon_BUS.DanhSachHoaDonChuaThuTheoNgayXuat(dtpNgayXuat.Text);
            CotDuLieu();
        }
        void XuatFile()
        {
            try
            {
                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo worksheet mới
                    var worksheet = workbook.Worksheets.Add("DanhSachHoaDon");

                    // Đặt tiêu đề cho các cột
                    for (int i = 0; i < dtgvDSHoaDon.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dtgvDSHoaDon.Columns[i].HeaderText;
                    }

                    // Điền dữ liệu từ DataGridView vào worksheet
                    for (int row = 0; row < dtgvDSHoaDon.Rows.Count; row++)
                    {
                        for (int col = 0; col < dtgvDSHoaDon.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dtgvDSHoaDon.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // Lưu workbook ra file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "DanhSachHoaDon.xlsx";

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

        private void button1_Click(object sender, EventArgs e)
        {
            TaiDanhSachDaThu();
        }

        private void btnDaThu_Click(object sender, EventArgs e)
        {
            TaiDanhSachDaThu();
        }

        private void btnChuaThu_Click(object sender, EventArgs e)
        {
            TaiDanhSachChuaThu();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            XuatFile();
        }
    }
}
