using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DTO_
{
	public class Phong_Tro_DTO
	{
		/*
         id int identity,
	MaPhong varchar(20),
	TenPhong nvarchar(50)not null,
	DienTich nvarchar(20) not null,
	Gia float not null,
	TinhTrang tinyint default 1,-- 1 la trong, 0 la da thue
	MaNguoiDung varchar(20) not null,
	GhiChu nvarchar(100)not null
         */
		private int id;
		private string maPhong;
		private string tenPhong;
		private string dienTich;
		private float gia;
		private int tinhTrang;
		private string ghiChu;
		private string maNguoiDung;
		private string email;

		public int Id { get => id; set => id = value; }
		public string MaPhong { get => maPhong; set => maPhong = value; }
		public string TenPhong { get => tenPhong; set => tenPhong = value; }
		public string DienTich { get => dienTich; set => dienTich = value; }
		public float Gia { get => gia; set => gia = value; }
		public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
		public string GhiChu { get => ghiChu; set => ghiChu = value; }
		public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string Email { get => email; set => email = value; }

        public Phong_Tro_DTO(int id, string maphong, string tenphong, string dientich, float gia, int tinhtrang, string ghichu, string manguoidung,string email)
		{
			this.Id = id;
			this.MaPhong = maphong;
			this.TenPhong = tenphong;
			this.DienTich = dientich;
			this.Gia = gia;
			this.TinhTrang = tinhtrang;
			this.GhiChu = ghichu;
			this.MaNguoiDung = manguoidung;
			this.Email = email;
		}
		public Phong_Tro_DTO() { }
	}
}
