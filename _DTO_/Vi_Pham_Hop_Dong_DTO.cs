using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
    public class Vi_Pham_Hop_Dong_DTO
    {
		private int id;
		private string maViPham;
		private string maHopDong;
		private string maNguoiDung;
		private string maPhong;
		private string maKhach;
		private string nguoiViPham;
		private string noiDungViPham;
		private string ngayViPham;
		private string ngayHuy;
		private string bienPhamXuLy;
		private float tienBoiThuong;
        private string tinhTrang;

        public int Id { get => id; set => id = value; }
        public string MaViPham { get => maViPham; set => maViPham = value; }
        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string NguoiViPham { get => nguoiViPham; set => nguoiViPham = value; }
        public string NoiDungViPham { get => noiDungViPham; set => noiDungViPham = value; }
        public string BienPhamXuLy { get => bienPhamXuLy; set => bienPhamXuLy = value; }
        public float TienBoiThuong { get => tienBoiThuong; set => tienBoiThuong = value; }
        public string NgayViPham { get => ngayViPham; set => ngayViPham = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string NgayHuy { get => ngayHuy; set => ngayHuy = value; }

        public Vi_Pham_Hop_Dong_DTO() { }
    }
}
