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
	TinhTrang tinyint default 1, -- 1 khong , 0 co
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
	MaPhong varchar(20) not null,
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
alter table HopDong add Constraint FK_HD_KT foreign key (MaKhach) REFERENCES KhachThue(MaKhach)
alter table HopDong add Constraint FK_HD_PT foreign key (MaPhong) REFERENCES Phongtro(MaPhong)

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

--===========================================================================================
--=================================== Sự Kiện Người Dùng =====================================
-- danh sách
create proc SP_TaiDanhSachNguoiDung
as
begin
	select 
	MaNguoiDung,
	TenNguoiDung,
	Email,
	SoDienThoai,
	DiaChi,
	TinhTrang
	from NguoiDung
end
go

-- thêm tài khoản
create proc SP_ThemtaiKhoan
@tennguoidung nvarchar(100),
@email nvarchar(50),
@sodienthoai nvarchar(15),
@diachi nvarchar(100),
@tinhtrang tinyint,
@matkhau nvarchar(50)
as
begin
	declare @manguoidung nvarchar(20)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from NguoiDung
	select @manguoidung = 'ND' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)
	
	insert into NguoiDung(MaNguoiDung, TenNguoiDung, Email, SoDienThoai, DiaChi, TinhTrang, MatKhau)
	values (@manguoidung, @tennguoidung, @email, @sodienthoai, @diachi, @tinhtrang, @matkhau)
end
go

-- sửa thông tin
create proc SP_SuaTaiKhoan
@manguoidung varchar(20),
@tennguoidung nvarchar(100),
@email nvarchar(50),
@sodienthoai nvarchar(15),
@diachi nvarchar(100),
@tinhtrang tinyint
as
begin
	update NguoiDung 
	set TenNguoiDung = @tennguoidung, Email = @email, SoDienThoai = @sodienthoai, DiaChi = @diachi, TinhTrang = @tinhtrang
	where MaNguoiDung = @manguoidung
end 
go 
-- xóa tài khoản
create proc SP_XoaTaiKhoan
@manguoidung varchar(20)
as
begin
	delete NguoiDung 
	where MaNguoiDung = @manguoidung
end
go

-- tìm kiểm 
create proc SP_TimKiemTaiKhoan
@tennguoidung nvarchar(100)
as
begin
		set nocount on;
		select MaNguoiDung, TenNguoiDung, Email, SoDienThoai, DiaChi, TinhTrang 
		from NguoiDung
		where TenNguoiDung like '%' + @tennguoidung + '%'
end
go

-- kiểm tra tồn tại (Nghiệp vụ)
create proc SP_KiemTraEmailTonTai 
@email nvarchar(100),
@sodienthoai nvarchar(15)
as
begin

	declare @status int

	if(exists(select * from dbo.NguoiDung where Email = @email) or exists(select * from dbo.NguoiDung where SoDienThoai = @sodienthoai) ) 
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

--===========================================================================================
--=================================== Sự Kiện Phòng Trọ =====================================
-- danh sach
create proc SP_TaiDanhSachPhong
as
begin
	select MaPhong,
	TenPhong,
	DienTich,
	Gia ,
	TinhTrang,
	MaNguoiDung,
	GhiChu 
	from phongtro 
end
go

--thêm phong
create proc SP_ThemPhong
@tenphong nvarchar(50),
@dientich nvarchar(50),
@gia nvarchar(100),
@tinhtrang tinyint,
@ghichu nvarchar(100),
@email nvarchar(50)
as
begin
	declare @manguoidung nvarchar(50)
	declare @maphong nvarchar(20)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from PhongTro
	select @maphong = 'MP_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)

	select @manguoidung = MaNguoiDung from NguoiDung where @email = Email

	insert into PhongTro(MaPhong, TenPhong, DienTich, Gia, TinhTrang, MaNguoiDung, GhiChu) 
	values(@maphong, @tenphong, @dientich, @gia, @tinhtrang, @manguoidung, @ghichu)

end
go

--sua phong
create proc SP_SuaPhong
@maphong varchar(20),
@tenphong nvarchar(50),
@dientich nvarchar(50),
@gia nvarchar(100),
@tinhtrang tinyint,
@ghichu nvarchar(100),
@email nvarchar(50)
as
begin
	declare @manguoidung varchar(20)
	select @manguoidung = MaNguoiDung from NguoiDung where @email = Email

	update PhongTro
	set TenPhong = @tenphong, DienTich = @dientich, Gia = @gia, TinhTrang = @tinhtrang, MaNguoiDung = @manguoidung ,GhiChu = @ghichu
	where MaPhong = @maphong
end
go

--xoa phong
create proc SP_XoaPhong
@maphong varchar(20)
as
begin
	delete PhongTro 
	where MaPhong = @maphong
end
go

--tiem kiem
create proc SP_TimKiem
@tenPhong nvarchar(50)
as
begin
	set nocount on;
	select MaPhong, TenPhong, DienTich, Gia, TinhTrang, MaNguoiDung, GhiChu
	from PhongTro
	where TenPhong like '%' + @tenPhong + '%'
end
go

--KiemTraTonTai
create proc SP_KiemTraTenPhong
@tenphong nvarchar(50)
as
begin
	declare @status int = 0
	if(exists(select * from dbo.PhongTro where TenPhong = @tenphong)) 
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

--===========================================================================================
--=================================== Sự Kiện Khach thue =====================================

--danh sach
create proc SP_DanhSachKhach
as
begin
	select
	MaKhach,
	TenKhach,
	SoDienThoai,
	CCCD,
	MaNguoiDung,
	Maphong
	from KhachThue
end
go

create proc SP_ThemKhach
@tenKhach nvarchar(50),
@sodienthoai nvarchar(15),
@cccd nvarchar(20),
@maphong varchar(20),
@email nvarchar(50)
as 
begin
	declare @makhach nvarchar(50)
	declare @manguoidung nvarchar(50)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from KhachThue
	select @makhach = 'MP_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)

	select @manguoidung = MaNguoiDung from NguoiDung where email = @email

end
go