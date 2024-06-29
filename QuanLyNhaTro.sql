create database QuanLyNhaTro
go
use QuanLyNhaTro
go

create table NguoiDung
(
	id int identity,
	MaNguoiDung varchar(20),
	TenNguoiDung nvarchar(50)not null,
	Email nvarchar(100) not null,
	SoDienThoai nvarchar(15) not null,
	DiaChi nvarchar(100) not null,
	MatKhau nvarchar(50) not null
	Constraint PK_NguoiDung primary key(MaNguoiDung)
)
go

create table PhongTro
(
	id int identity,
	MaPhong varchar(20),
	TenPhong nvarchar(50)not null,
	DienTich nvarchar(20) not null,
	Gia float not null,
	TinhTrang tinyint default 1,-- 1 la trong, 0 la da thue
	MaNguoiDung varchar(20) not null,
	GhiChu nvarchar(100)not null
	Constraint PK_PT primary key(MaPhong)
)
go

create table KhachThue
(
	id int identity,
	MaKhach varchar(20),
	TenKhach nvarchar(50)not null,
	SoDienThoai nvarchar(15) not null,
	CCCD int not null,
	MaNguoiDung varchar(20) not null,
	Maphong varchar(20) not null
	Constraint PK_KT primary key(MaKhach)
)
go

create table HopDong
(
	id int identity,
	MaHopDong varchar(20) primary key,
	MaNguoiDung varchar (20) not null,
	MaKhach varchar(20)not null,
	NgayBatDau Date not null,
	NgayKetThuc date not null,
	ChiSoDien nvarchar(20) not null, -- 3000/kWh
	ChiSoNuoc nvarchar(20) not null, -- 2500/m3
	TienCoc float not null,
	TienThue float not null,
)
go

create table HoaDonThang 
(
	id int identity,
	MaHoaDon varchar(20) primary key,
	MaKhach varchar(20) not null,
	MaPhong varchar(20) not null,
	NgayBatDau date not null,
	NgayKetThuc date not null,
	TienDien float not null,
	TienNuoc float not null,
	GiaPhong float not null,
	TongTien float not null,
)
go

alter table PhongTro add Constraint FK_PT_ND foreign key (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
alter table KhachThue add Constraint FK_KT_ND foreign key (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
alter table KhachThue add Constraint FK_KT_PT foreign key (MaPhong) REFERENCES PhongTro(MaPhong)

alter table HopDong add Constraint FK_HD_ND foreign key (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
alter table HopDong add Constraint FK_DH_KT foreign key (MaKhach) REFERENCES KhachThue(MaKhach)

alter table HoaDonThang add Constraint FK_HDT_KT foreign key (MaKhach) REFERENCES KhachThue(MaKhach)
alter table HoaDonThang add Constraint FK_HDT_PT foreign key (MaPhong) REFERENCES PhongTro(MaPhong)
go
--===========================================================================================
--=================================== Sự Kiện Đăng Nhập =====================================

-- Đăng Nhập
create proc SP_DangNhap
@email nvarchar(100),
@pass nvarchar(50)
as
begin
	declare @status int

	if(exists(select * from dbo.NguoiDung where Email = @email and MatKhau = @Pass) ) 
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

--quên mật khẩu
create proc SP_QuenMatKhau
@email nvarchar(100)
as
begin

	declare @status int 

	if exists(select MaNguoiDung from dbo.NguoiDung where Email = @email)
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

-- đổi mật khẩu
create proc SP_DoiMatKhau
@email nvarchar(50),
@oldpass nvarchar(50),
@newpass nvarchar(50)
as
begin

	declare @old nvarchar(50)
	select @old = MatKhau 
	from dbo.NguoiDung 
	where Email = @email

	if (@old = @oldpass)
		begin
		update NguoiDung set MatKhau = @newpass where Email = @email
		return 1
		end
	else 
		return -1
end
go
