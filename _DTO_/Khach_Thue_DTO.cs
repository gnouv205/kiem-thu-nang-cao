using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
    public class Khach_Thue_DTO
    {
        private int id;
        private string maKhach;
        private string tenKhach;
        private string soDienThoai;
        private int cCCD;
        private string tinhTrang;
        private string maNguoiDung;
        private string maPhong;
        private string email;

        public int Id { get => id; set => id = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string TenKhach { get => tenKhach; set => tenKhach = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CCCD { get => cCCD; set => cCCD = value; }
        public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string Email { get => email; set => email = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public Khach_Thue_DTO(int id, string makhach, string tenkhach, string sodienthoai, int cccd, string tinhtrang,string manguoidung, string maphong, string email)
        {
            this.Id = id;
            this.MaKhach = makhach;
            this.TenKhach = tenkhach;
            this.SoDienThoai = sodienthoai;
            this.CCCD = cccd;
            this.TinhTrang = tinhtrang;
            this.MaNguoiDung = manguoidung;
            this.MaPhong = maphong;
            this.Email = email;
        }
        public Khach_Thue_DTO() { }
    }
}
