using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
	public class Phong_Tro_DTO
	{
		private int id;
		private string maPhong;
		private string tenPhong;
		private string dienTich;
		private float gia;
		private string tinhTrang;
		private string hienTrang;
		private string ghiChu;
		private string maNguoiDung;
		private string email;

		public int Id { get => id; set => id = value; }
		public string MaPhong { get => maPhong; set => maPhong = value; }
		public string TenPhong { get => tenPhong; set => tenPhong = value; }
		public string DienTich { get => dienTich; set => dienTich = value; }
		public float Gia { get => gia; set => gia = value; }
		public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
		public string GhiChu { get => ghiChu; set => ghiChu = value; }
		public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string Email { get => email; set => email = value; }
        public string HienTrang { get => hienTrang; set => hienTrang = value; }

        public Phong_Tro_DTO(int id, string maphong, string tenphong, string dientich, float gia, string tinhtrang, string hientrang, string ghichu, string manguoidung,string email)
		{
			this.Id = id;
			this.MaPhong = maphong;
			this.TenPhong = tenphong;
			this.DienTich = dientich;
			this.Gia = gia;
			this.TinhTrang = tinhtrang;
			this.HienTrang = hientrang;
			this.GhiChu = ghichu;
			this.MaNguoiDung = manguoidung;
			this.Email = email;
		}
		public Phong_Tro_DTO() { }
	}
}
