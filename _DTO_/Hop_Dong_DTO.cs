using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
    public class Hop_Dong_DTO
    {
        private int id;
        private string maHopDong;
        private string maNguoiDung;
        private string maKhach;
        private string maPhong;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private float chiSoDien;
        private float chiSoNuoc;
        private float tienCoc;
        private float tienThue;
        private string tinhTrang;
        private string email;
        public object txtMaHD;

        public int Id { get => id; set => id = value; }
        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public float ChiSoDien { get => chiSoDien; set => chiSoDien = value; }
        public float ChiSoNuoc { get => chiSoNuoc; set => chiSoNuoc = value; }
        public float TienCoc { get => tienCoc; set => tienCoc = value; }
        public float TienThue { get => tienThue; set => tienThue = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string Email { get => email; set => email = value; }

        public Hop_Dong_DTO() { }

        public bool Luu()
        {
            throw new NotImplementedException();
        }
    }
}
