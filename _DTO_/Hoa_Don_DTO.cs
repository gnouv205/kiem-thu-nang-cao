using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
    public class Hoa_Don_DTO
    {
        private string maHoaDon;
        private string maKhach;
        private string maPhong;
        private string ngayBatDau;
        private string ngayKetThuc;
        private float tienDien;
        private float tienNuoc;
        private float giaPhong;
        private string tinhTrang;
        private float tongTien;
        private string ngayXuat;

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public float TienDien { get => tienDien; set => tienDien = value; }
        public float TienNuoc { get => tienNuoc; set => tienNuoc = value; }
        public float GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public string NgayXuat { get => ngayXuat; set => ngayXuat = value; }

        public Hoa_Don_DTO() { }
    }
}
