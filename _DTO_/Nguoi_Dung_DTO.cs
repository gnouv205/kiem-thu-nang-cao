using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
    public class Nguoi_Dung_DTO
    {
        private int id;
        private string maNguoiDung;
        private string tenNguoiDung;
        private string email;
        private int soDT;
        private string diaChi;
        private string vaiTro;
        private string tinhTrang;
        private string matKhau;

        public int Id { get => id; set => id = value; }
        public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string TenNguoiDung { get => tenNguoiDung; set => tenNguoiDung = value; }
        public string Email { get => email; set => email = value; }
        public int SoDT { get => soDT; set => soDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string VaiTro { get => vaiTro; set => vaiTro = value; }

        public Nguoi_Dung_DTO(int id, string ma, string ten, string email, int sdt, string diachi, string vaitro, string tinhtrang,string matkhau)
        {
            this.Id = id;
            this.MaNguoiDung = ma;
            this.TenNguoiDung = ten;
            this.Email = email;
            this.SoDT = sdt;
            this.DiaChi = diachi;
            this.VaiTro = vaitro;
            this.TinhTrang = tinhtrang;
            this.MatKhau = matkhau;
        }
        public Nguoi_Dung_DTO() { }
    }
}
