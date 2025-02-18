create database QuanLyNhaTro
go
use QuanLyNhaTro
go

create table ChuSoHuu
(
	id int identity,
	MaNguoiDung varchar(20),
	TenNguoiDung nvarchar(50)not null,
	Email nvarchar(100) not null,
	SoDienThoai nvarchar(15) not null,
	DiaChi nvarchar(100) not null,
	VaiTro nvarchar(50) not null, 
	TinhTrang nvarchar(50) not null, 
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
	TinhTrang  nvarchar(50),
	HienTrang nvarchar(50),
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
	TinhTrang nvarchar(50) not null,
	MaNguoiDung varchar(20) not null,
	MaPhong varchar(20) not null,
	Constraint PK_KT primary key(MaKhach)
)
go

create table HopDong
(
	id int identity,
	MaHopDong varchar(20) primary key,
	MaNguoiDung varchar(20) not null,
	MaKhach varchar(20) not null,
	MaPhong varchar(20) not null,
	NgayBatDau nvarchar(50) not null,
	NgayKetThuc nvarchar(50) not null,
	ChiSoDien nvarchar(20) not null, -- 3000/kWh
	ChiSoNuoc nvarchar(20) not null, -- 2500/m3
	TienCoc float not null,
	TienThue float not null,
	TinhTrang nvarchar(50) not null,
)
go

create table ViPhamHopDong
(
	Id int identity,
	MaViPham varchar(20) primary key,
	MaHopDong varchar(20) not null,
	MaNguoiDung varchar(20) not null,
	MaPhong varchar(20) not null,
	MaKhach varchar(20) not null,
	NguoiViPham nvarchar(50) not null,
	NoiDungViPham nvarchar(100) not null,
	NgayViPham nvarchar(50) not null,
	NgayHuy nvarchar(50) not null,
	BienPhapXuLy nvarchar(100) not null,
	TienBoiThuong float not null,
	TinhTrang nvarchar(50) not null
)
go

create table HoaDonThang 
(
	id int identity,
	MaHoaDon varchar(20) primary key,
	MaKhach varchar(20) not null,
	MaPhong varchar(20) not null,
	NgayBatDau nvarchar(50) not null,
	NgayKetThuc nvarchar(50) not null,
	TienDien float not null,
	TienNuoc float not null,
	GiaPhong float not null,
	TinhTrang  nvarchar(50) not null,
	TongTien float not null,
	NgayXuatHoaDon nvarchar(50) not null
)
go

alter table PhongTro add Constraint FK_PT_ND foreign key (MaNguoiDung) REFERENCES ChuSoHuu(MaNguoiDung)
alter table KhachThue add Constraint FK_KT_ND foreign key (MaNguoiDung) REFERENCES ChuSoHuu(MaNguoiDung)
alter table KhachThue add Constraint FK_KT_PT foreign key (MaPhong) REFERENCES PhongTro(MaPhong)

alter table HopDong add Constraint FK_HD_ND foreign key (MaNguoiDung) REFERENCES ChuSoHuu(MaNguoiDung)
alter table HopDong add Constraint FK_HD_KT foreign key (MaKhach) REFERENCES KhachThue(MaKhach)
alter table HopDong add Constraint FK_HD_PT foreign key (MaPhong) REFERENCES Phongtro(MaPhong)

alter table HoaDonThang add Constraint FK_HDT_KT foreign key (MaKhach) REFERENCES KhachThue(MaKhach)
alter table HoaDonThang add Constraint FK_HDT_PT foreign key (MaPhong) REFERENCES PhongTro(MaPhong)

alter table ViPhamHopDong add constraint FK_VP_HD foreign key (MaHopDong) references HopDong(MaHopDong)
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

	if(exists(select * from dbo.ChuSoHuu where Email = @email and MatKhau = @Pass) ) 
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

	if exists(select MaNguoiDung from dbo.ChuSoHuu where Email = @email)
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
	from dbo.ChuSoHuu 
	where Email = @email

	if (@old = @oldpass)
		begin
		update ChuSoHuu set MatKhau = @newpass where Email = @email
		return 1
		end
	else 
		return -1
end
go

--===========================================================================================
--=================================== Sự Kiện Người Dùng =====================================
-- danh sách
create proc SP_DanhSachNguoiDung
as
begin
	select 
	MaNguoiDung,
	TenNguoiDung,
	Email,
	SoDienThoai,
	DiaChi,
	VaiTro,
	TinhTrang
	from ChuSoHuu
	where TinhTrang = N'Hoạt Động'
end
go

create proc SP_DanhSachNguoiDungNgungHoatDong
as
begin
	select 
	MaNguoiDung,
	TenNguoiDung,
	Email,
	SoDienThoai,
	DiaChi,
	VaiTro,
	TinhTrang
	from ChuSoHuu
	where TinhTrang = N'Ngừng Hoạt Động'
end
go

-- thêm tài khoản
create proc SP_ThemtaiKhoan
@tennguoidung nvarchar(100),
@email nvarchar(50),
@sodienthoai nvarchar(15),
@diachi nvarchar(100),
@vaitro nvarchar(50),
@tinhtrang nvarchar(50),
@matkhau nvarchar(50)
as
begin
	declare @manguoidung nvarchar(20)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from ChuSoHuu
	select @manguoidung = 'ND_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)
	
	insert into ChuSoHuu(MaNguoiDung, TenNguoiDung, Email, SoDienThoai, DiaChi, VaiTro, TinhTrang, MatKhau)
	values (@manguoidung, @tennguoidung, @email, @sodienthoai, @diachi, @vaitro, @tinhtrang, @matkhau)
end
go

-- sửa thông tin
create proc SP_SuaTaiKhoan
@manguoidung varchar(20),
@tennguoidung nvarchar(100),
@email nvarchar(50),
@sodienthoai nvarchar(15),
@diachi nvarchar(100),
@vaitro nvarchar(50),
@tinhtrang nvarchar(50)
as
begin
	 
	update ChuSoHuu 
	set TenNguoiDung = @tennguoidung, Email = @email, SoDienThoai = @sodienthoai, DiaChi = @diachi, VaiTro = @vaitro ,TinhTrang = @tinhtrang
	where MaNguoiDung = @manguoidung
end 
go 

-- xóa tài khoản
create proc SP_XoaTaiKhoan
@manguoidung varchar(20)
as
begin
	update ChuSoHuu set TinhTrang = N'Ngừng Hoạt Động' where MaNguoiDung = @manguoiDung
end
go

-- tìm kiểm 
create proc SP_TimKiemTaiKhoan
@tennguoidung nvarchar(100),
@sodienthoai nvarchar(15)
as
begin
		set nocount on;
		select MaNguoiDung, TenNguoiDung, Email, SoDienThoai, DiaChi, VaiTro, TinhTrang 
		from ChuSoHuu
		where TenNguoiDung like '%' + @tennguoidung + '%' or SoDienThoai like '%'+@sodienthoai+'%'
end
go

-- kiểm tra tồn tại (Nghiệp vụ)
create proc SP_KiemTraEmailTonTai 
@email nvarchar(100),
@sodienthoai nvarchar(15)
as
begin

	declare @status int

	if(exists(select * from dbo.ChuSoHuu where Email = @email) or exists(select * from dbo.ChuSoHuu where SoDienThoai = @sodienthoai) ) 
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

--===========================================================================================
--=================================== Sự Kiện Phòng Trọ =====================================
-- danh sach
create proc SP_DanhSachPhong
as
begin
	select MaPhong,
	TenPhong,
	DienTich,
	Gia ,
	TinhTrang,
	HienTrang,
	MaNguoiDung,
	GhiChu 
	from phongtro 
	where TinhTrang = N'Đã Thuê'
end
go

create proc SP_DanhSachPhongTrong
as
begin
	select MaPhong,
	TenPhong,
	DienTich,
	Gia ,
	TinhTrang,
	Hientrang,
	MaNguoiDung,
	GhiChu 
	from phongtro 
	where TinhTrang = N'Trống' and hientrang = N'Sử Dụng'
end
go

create proc SP_DanhSachPhongKhongSuDung
as
begin
	select MaPhong,
	TenPhong,
	DienTich,
	Gia ,
	TinhTrang,
	Hientrang,
	MaNguoiDung,
	GhiChu 
	from phongtro 
	where hientrang = N'Không Sử Dụng'
end
go

--thêm phong
create proc SP_ThemPhong
@tenphong nvarchar(50),
@dientich nvarchar(50),
@gia nvarchar(100),
@tinhtrang nvarchar(50),
@hientrang nvarchar(50),
@ghichu nvarchar(100),
@email nvarchar(100)
as
begin
	declare @manguoidung nvarchar(50)
	declare @maphong nvarchar(20)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from PhongTro
	select @maphong = 'MP_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)

	select @manguoidung = MaNguoiDung from ChuSoHuu where Email = @email

	insert into PhongTro(MaPhong, TenPhong, DienTich, Gia, TinhTrang, HienTrang, MaNguoiDung, GhiChu) 
	values(@maphong, @tenphong, @dientich, @gia, @tinhtrang, @hientrang, @manguoidung, @ghichu)

end
go

--sua phong
create proc SP_SuaPhong
@maphong varchar(20),
@tenphong nvarchar(50),
@dientich nvarchar(50),
@gia nvarchar(100),
@tinhtrang nvarchar(50),
@hientrang nvarchar(50),
@ghichu nvarchar(100),
@email nvarchar(50)
as
begin
	declare @manguoidung varchar(20)
	select @manguoidung = MaNguoiDung from ChuSoHuu where Email = @email

	update PhongTro
	set TenPhong = @tenphong, DienTich = @dientich, Gia = @gia, TinhTrang = @tinhtrang, HienTrang = @hientrang, MaNguoiDung = @manguoidung ,GhiChu = @ghichu
	where MaPhong = @maphong

end
go

--xoa phong
create proc SP_XoaPhong
@maphong varchar(20)
as
begin
	update PhongTro set HienTrang = N'Không Sử Dụng' where MaPhong = @maphong
end
go

--tiem kiem
create proc SP_TimKiemPhong
@tenPhong nvarchar(50)
as
begin
	set nocount on;
	select MaPhong, TenPhong, DienTich, Gia, TinhTrang, HienTrang, MaNguoiDung, GhiChu
	from PhongTro
	where TenPhong like '%' + @tenPhong + '%' 
end
go

--KiemTraTonTai
create proc SP_KiemTraTenPhongTonTai
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
	TinhTrang,
	MaNguoiDung,
	MaPhong
	from KhachThue
	where TinhTrang = N'Còn Thuê'
end
go

create proc SP_DanhSachKhachHetHan
as
begin
	select
	MaKhach,
	TenKhach,
	SoDienThoai,
	CCCD,
	TinhTrang,
	MaNguoiDung,
	MaPhong
	from KhachThue
	where TinhTrang = N'Hết Hạn'
end
go

--them khach
create proc SP_ThemKhach
@tenKhach nvarchar(50),
@sodienthoai nvarchar(15),
@cccd nvarchar(20),
@tinhtrang nvarchar(50),
@maphong varchar(20),
@email nvarchar(50)
as 
begin
	declare @makhach nvarchar(50)
	declare @manguoidung nvarchar(50)
	declare @id int

	select @id = ISNULL(MAX(id),0) + 1 from KhachThue
	select @makhach = 'MK_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)

	select @manguoidung = MaNguoiDung from ChuSoHuu where email = @email

	insert into KhachThue(MaKhach , TenKhach, SoDienThoai, CCCD, TinhTrang ,MaNguoiDung, MaPhong)
	values (@makhach, @tenKhach, @sodienthoai, @cccd, @tinhtrang, @manguoidung, @maphong)

	update PhongTro 
	set TinhTrang = N'Đã Thuê' where MaPhong = @maphong

end
go
-- sua khach
create proc SP_SuaKhach
@makhach varchar(20),
@tenKhach nvarchar(50),
@sodienthoai nvarchar(15),
@cccd nvarchar(20),
@tinhtrang nvarchar(50),
@maphong varchar(20),
@email nvarchar(50)
as 
begin
	DECLARE @maphonghientai VARCHAR(20)
	SELECT @maphonghientai = MaPhong FROM KhachThue WHERE MaKhach = @makhach -- lấy ra phòng hiện tại

	declare @manguoidung varchar(20)
	select @manguoidung = MaNguoiDung from ChuSoHuu where Email = @email
	
	update KhachThue
	set TenKhach = @tenKhach, SoDienThoai = @sodienthoai, CCCD = @cccd, TinhTrang = @tinhtrang, MaNguoiDung = @manguoidung, MaPhong = @maphong
	where MaKhach = @makhach

	if(@maphonghientai <> @maphong)
		update PhongTro SET tinhtrang = N'Trống' WHERE MaPhong = @maphonghientai;

	if(@tinhtrang = N'Hết Hạn')
		update phongtro set tinhtrang = N'Trống' where MaPhong = @maphong
	else 
		update phongtro set tinhtrang = N'Đã Thuê' where MaPhong = @maphong
	
end
go

--xoa khach
create proc SP_XoaKhach
@makhach varchar(20),
@maphong varchar(20)
as
begin
	update KhachThue set TinhTrang = N'Hết Hạn' where MaKhach = @makhach
	update PhongTro 
	set TinhTrang = N'Trống' where MaPhong = @maphong
end
go

-- tim kiem
create proc SP_TimKiemTenKhach
@tenkhach nvarchar(50),
@sodienthoai nvarchar(15)
as
begin
	set nocount on;
	select MaKhach , TenKhach, SoDienThoai, CCCD, TinhTrang, MaNguoiDung, MaPhong
	from KhachThue
	where TenKhach like '%' + @tenkhach + '%' or SoDienThoai like '%' + @sodienthoai + '%'
end
go

create proc SP_KiemTraKhachTonTai
@tenkhach nvarchar(50),
@cccd nvarchar(20)
as
begin
	declare @status int = 0
	if(exists(select * from KhachThue where TenKhach = @tenkhach and CCCD = @cccd and TinhTrang = N'Còn Thuê'))
		set @status = 1
	else
		set @status = 0

	select @status
end
go

--===========================================================================================
--=================================== Sự Kiện Hợp Đồng ======================================

--danh sach hop dong
create proc SP_DanhSachHopDong
as
begin
	select MaHopDong, MaNguoiDung, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, ChiSoDien, ChiSoNuoc, TienCoc, TienThue, TinhTrang
	from HopDong
	where TinhTrang = N'Còn Hạn'
end
go

create proc SP_DanhSachHopDongHetHan
as
begin
	select MaHopDong, MaNguoiDung, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, ChiSoDien, ChiSoNuoc, TienCoc, TienThue, TinhTrang
	from HopDong
	where TinhTrang = N'Hết Hạn'
end
go

-- them hop dong
create proc SP_ThemHopDong
@makhach nvarchar(50),
@maphong nvarchar(50),
@ngaybatdau nvarchar(50),
@ngayketthuc nvarchar(50),
@chisodien nvarchar(50),
@chisonuoc nvarchar(50),
@tiencoc nvarchar(50),
@tienthue nvarchar(50),
@tinhtrang nvarchar(50),
@email nvarchar(50)
as
begin
	declare @id int 
	declare @mahopdong varchar(20)
	declare @manguoidung varchar(50)
	
	select @id = ISNULL(MAX(id),0) + 1 from HopDong
	select @mahopdong = 'HD_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)
	select @manguoidung = MaNguoiDung from ChuSoHuu where email = @email

	insert into HopDong 
	(MaHopDong, MaNguoiDung, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, ChiSoDien, ChiSoNuoc, TienCoc, TienThue, TinhTrang)
	values 
	(@mahopdong, @manguoidung, @makhach, @maphong, @ngaybatdau, @ngayketthuc, @chisodien, @chisonuoc, @tiencoc, @tienthue, @tinhtrang)
end
go

-- sua hop dong
create proc SP_SuahopDong
@mahopdong varchar(20),
@makhach nvarchar(50),
@maphong nvarchar(50),
@ngaybatdau nvarchar(50),
@ngayketthuc nvarchar(50),
@chisoDien nvarchar(50),
@chisonuoc nvarchar(50),
@tiencoc nvarchar(50),
@tienthue nvarchar(50),
@tinhtrang nvarchar(50),
@email nvarchar(50)
as
begin
	declare @manguoidung varchar(50)
	select @manguoidung = MaNguoiDung from ChuSoHuu where email = @email

	update HopDong
	set 
	MaKhach = @makhach,
	MaPhong = @maphong,
	NgayBatDau = @ngaybatdau,
	NgayKetThuc = @ngayketthuc,
	ChiSoDien = @chisoDien,
	ChiSoNuoc = @chisonuoc,
	TienCoc = @tiencoc,
	TienThue = @tienthue,
	TinhTrang = @tinhtrang
	where MaHopDong = @mahopdong
end
go

-- xoa hop dong
create proc SP_XoaHopDong
@mahopdong varchar(20)
as
begin
	update HopDong set TinhTrang = N'Hết Hạn'
end
go

-- tiem kiem
create proc SP_TimKiemHopDong
@NgayBatDau nvarchar(50),
@makhach varchar(20)
as
begin
	select MaHopDong, MaNguoiDung, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, ChiSoDien, ChiSoNuoc, TienCoc, TienThue, TinhTrang
	from HopDong
	where NgayBatDau like '%' + @NgayBatDau + '%' or MaKhach like '%' + @makhach + '%'
end
go

--kiem tr ton tai
create proc SP_KiemTraHopDongTonTai
@makhach varchar(20)
as
begin
	declare @status int
	if(exists(select * from dbo.HopDong where  MaKhach = @makhach and TinhTrang = N'Còn Hạn'))
		set @status = 1
	else 
		set @status = 0
	select @status
end
go

--===========================================================================================
--=================================== Sự Kiện Hóa Đơn =======================================
-- Table Hóa đơn tháng
-- Load list hóa đơn tháng

create proc SP_DanhSachHoaDonDaThuTheoNgayXuat
@ngayxuathoadon nvarchar(50)
as
begin
	select  MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, Giaphong, TinhTrang ,TongTien, NgayXuatHoaDon
	from HoaDonThang
	where NgayXuatHoaDon = @ngayxuathoadon and TinhTrang = N'Đã Thu'
end
go

create proc SP_DanhSachHoaDonChuaThuTheoNgayXuat
@ngayxuathoadon nvarchar(50)
as
begin
	select  MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, Giaphong, TinhTrang ,TongTien, NgayXuatHoaDon
	from HoaDonThang
	where NgayXuatHoaDon = @ngayxuathoadon and TinhTrang = N'Chưa Thu'
end
go


create PROC SP_HoaDonThang
AS 
BEGIN
	select MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, Giaphong, TinhTrang ,TongTien, NgayXuatHoaDon
	from HoaDonThang 
	where TinhTrang = N'Đã Thu'
END
GO

create PROC SP_HoaDonThangHetHan
AS 
BEGIN
	select MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, Giaphong, TinhTrang, TongTien,NgayXuatHoaDon
	from HoaDonThang 
	where TinhTrang = N'Chưa Thu'
END
GO

-- Insert hóa đơn
-- Alter stored procedure for inserting customer
create PROC SP_ThemHoaDon
@makhach VARCHAR(50),
@maphong VARCHAR(100),
@NgayBatDau nvarchar(50),
@NgayKetThuc nvarchar(50),
@TienDien FLOAT,
@TienNuoc FLOAT,
@GiaPhong FLOAT,
@tinhtrang nvarchar(20),
@TongTien FLOAT,
@ngayxuatHoadon nvarchar(50)
AS
BEGIN
	declare @MaHoaDon VARCHAR(11)
	DECLARE @ID INT
    SELECT @ID = ISNULL(MAX(Id), 0) + 1 FROM HoaDonThang

	select @MaHoaDon = 'HDT_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)
	select @maphong = MaPhong from KhachThue where MaKhach = @makhach 

    INSERT INTO HoaDonThang(MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, GiaPhong, TinhTrang ,TongTien, NgayXuatHoaDon)
    VALUES (@MaHoaDon, @makhach, @maphong, @NgayBatDau, @NgayKetThuc, @TienDien, @TienNuoc, @GiaPhong, @tinhtrang, @TongTien, @ngayxuatHoadon);
END
GO

-- Delete Hóa đơn
create PROC SP_XoaHoaDon
@MaHoaDon VARCHAR(11)
AS 
BEGIN
	update HoaDonThang set TinhTrang = N'Đã Thu' where MaHoaDon = @MaHoaDon
END
GO

-- Update Hóa đơn
create PROCEDURE SP_SuaHoaDon
@MaHoaDon VARCHAR(11),
@makhach VARCHAR(50),
@maphong VARCHAR(100),
@NgayBatDau nvarchar(50),
@NgayKetThuc nvarchar(50),
@TienDien FLOAT,
@TienNuoc FLOAT,
@GiaPhong FLOAT,
@tinhtrang nvarchar(20),
@TongTien FLOAT,
@ngayxuatHoadon nvarchar(50)
AS
BEGIN
    UPDATE HoaDonThang 
    SET 
	MaKhach = @makhach, 
	MaPhong = @maphong, 
	NgayBatDau = @NgayBatDau, 
	NgayKetThuc = @NgayKetThuc,
    TienDien = @TienDien, 
	TienNuoc = @TienNuoc, 
	GiaPhong = @GiaPhong,
	TinhTrang = @tinhtrang,
    @TongTien = @TienDien + @TienNuoc + @GiaPhong,
	TongTien = @TongTien,
	ngayxuatHoadon = @ngayxuatHoadon
    WHERE MaHoaDon = @MaHoaDon;
END;
GO

--Tim kiem hoa don
create proc SP_TimKiemHoaDon
@maphong nvarchar(50)
as
begin
	select  MaHoaDon, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienDien, TienNuoc, Giaphong, TinhTrang,TongTien, NgayXuatHoaDon
	from HoaDonThang
	where MaPhong like '%' + @maphong + '%'
end
go

create proc SP_KiemTraHoaDon
@ngaybatdau nvarchar(50),
@ngayketthuc nvarchar(50),
@makhach varchar(20)
as
begin
	declare @status int
	if(exists(select * from dbo.HoaDonThang where MaKhach = @makhach and NgayBatDau = @ngaybatdau and NgayKetThuc = @ngayketthuc ))
		set @status = 1
	else 
		set @status = 0
	select @status
end
go
--===========================================================================================
--=================================== Lấy Danh Sach Mã ======================================

create proc SP_DanhSachMaNguoiDung
as
begin
	select MaNguoiDung from ChuSoHuu where tinhtrang = N'Hoạt Động'
end
go

create proc SP_DanhSachMaKhach
as
begin
	select MaKhach from KhachThue where tinhtrang = N'Còn Thuê' 
end
go
create proc SP_DanhSachMaPhongTheoMaKhach
@maKhach varchar(20)
as
begin
	select maphong from KhachThue where MaKhach = @maKhach
end
go

create proc SP_DanhSachGiaPhong
@maPhong varchar(20)
as
begin
	select gia from PhongTro where MaPhong = @maPhong
end
go

create proc SP_DanhSachMaPhong
as
begin
	select MaPhong from PhongTro where HienTrang = N'Sử Dụng'
end
go
--===========================================================================================
--============================= Lấy ra Vai Trò Tình Trạng ===================================

-- Vai trò người dùng: dùng để phân quyền người dùng
create proc SP_VaitroNguoiDung
@email nvarchar(50)
as
begin
	select VaiTro from ChuSoHuu where email = @email
end
go

--tình trạng người dùng: kiểm tra còn hoạt động không. nếu tình trạng là không hoạt động thì không thể đăng nhập 
create proc SP_TinhTrangNguoiDung
@email nvarchar(50)
as
begin
	select TinhTrang from ChuSoHuu where Email = @email
end
go

-- tình trạng của phòng: kiểm tra phòng còn trống không nếu phồng trọ là trống thì được thêm khách vào nếu đã thuê thì không được thêm khách và không thể lập hợp đồng
create proc SP_TinhTrangPhong
@maphong varchar(50)
as
begin
	select TinhTrang from PhongTro where MaPhong = @maphong
end
go

create proc SP_HienTrangPhong
@maphong varchar(50)
as
begin
	select HienTrang from PhongTro where MaPhong = @maphong
end
go

-- tình trạng của khách: kiểm tra khách này còn thuê không. để lập hợp đồng
create proc SP_TinhTrangKhachThue
@makhach varchar(50)
as
begin
	select TinhTrang from KhachThue where MaKhach = @makhach
end
go

create proc SP_TinhTrangHoaDon
@makhach varchar(50)
as
begin
	select TinhTrang from HoaDonThang where MaKhach = @makhach
end
go

--===========================================================================================
--============================= Lấy Thông tin hop dong ===================================
create proc SP_MaHopDong
@mahopdong varchar(20)
as
begin
	select MaHopDong from HopDong where MaHopDong = @mahopdong
end
go

create proc SP_MaNguoiDungHopDong
@mahopdong varchar(20)
as
begin
	select MaNguoiDung from HopDong where MaHopDong = @mahopdong
end
go

create proc SP_MakhachHopDong
@mahopdong varchar(20)
as
begin
	select MaKhach from HopDong where MaHopDong = @mahopdong
end
go

create proc SP_MaPhongHopDong
@mahopdong varchar(20)
as
begin
	select MaPhong from HopDong where MaHopDong = @mahopdong
end
go

--===========================================================================================
--================================= Sự Kiện Hủy Hợp Đồng ====================================
-- danh sach hop doi tuong hop dong
create proc SP_DanhSachHuyHopDong
as
begin
	select MaViPham, MaHopDong, MaNguoiDung, MaKhach, MaPhong, NguoiViPham, NoiDungViPham, NgayViPham, NgayHuy, BienPhapXuLy, TienBoiThuong, TinhTrang from ViPhamHopDong where TinhTrang = N'Hủy'
end 
go
create proc SP_DanhSachChuaHuyHopDong
as
begin
	select MaViPham, MaHopDong, MaNguoiDung, MaKhach, MaPhong, NguoiViPham, NoiDungViPham, NgayViPham, NgayHuy, BienPhapXuLy, TienBoiThuong, TinhTrang from ViPhamHopDong where TinhTrang = N'Chưa Hủy'
end 
go


create proc SP_XacNhanHuyHopDong
@mavipham varchar(20),
@mahopdong varchar(20),
@manguoidung varchar(20),
@makhach varchar(20),
@maphong varchar(20),
@nguoivipham nvarchar(20),
@noidungvipham nvarchar(100),
@ngayvipham nvarchar(50),
@ngayhuy nvarchar(50),
@bienphapxuly nvarchar(100),
@tienboithuong float,
@tinhtrang nvarchar(50)
as
begin
	update ViPhamHopDong
	set NguoiViPham = @nguoivipham , NoiDungViPham = @noidungvipham, BienPhapXuLy = @bienphapxuly, TinhTrang = @tinhtrang where MaViPham = @mavipham 

	if(@tinhtrang = N'Hủy')
	begin
	update ViPhamHopDong set TinhTrang = N'Hủy' where MaViPham = @mavipham
	update PhongTro set TinhTrang = N'Trống' where MaPhong = @maphong
	update KhachThue set TinhTrang = N'Hết Hạn' where MaKhach = @makhach
	update HoaDonThang set TinhTrang = N'Đã Thu' where MaKhach = @makhach
	update HopDong set TinhTrang = N'Hết Hạn' where MaHopDong = @mahopdong
	end
end
go

create proc SP_LapBangHuyHopDong
@mahopdong varchar(20),
@manguoidung varchar(20),
@makhach varchar(20),
@maphong varchar(20),
@nguoivipham nvarchar(20),
@noidungvipham nvarchar(100),
@ngayvipham nvarchar(50),
@ngayhuy nvarchar(50),
@bienphapxuly nvarchar(100),
@tienboithuong float,
@tinhtrang nvarchar(50)
as
begin
	declare @id int
	declare @mavipham varchar(20)

	select @id = ISNULL(MAX(id),0) + 1 from HopDong
	select @mavipham = 'VP_' + RIGHT('0000' + CAST(@id as nvarchar(4)),4)

	insert into ViPhamHopDong (MaViPham ,MaHopDong, MaNguoiDung, MaKhach, MaPhong, NguoiViPham, NoiDungViPham, NgayViPham, NgayHuy,BienPhapXuLy, TienBoiThuong, TinhTrang) 
	values(@mavipham, @mahopdong, @manguoidung, @makhach, @maphong, @nguoivipham, @noidungvipham, @ngayvipham, @ngayhuy, @bienphapxuly, @tienboithuong, @tinhtrang)

end
go

create proc SP_TimKiemMaKhach 
@makhach nvarchar(20)
as
begin
	select MaViPham ,MaHopDong, MaNguoiDung, MaKhach, MaPhong, NguoiViPham, NoiDungViPham, NgayViPham, NgayHuy, BienPhapXuLy, TienBoiThuong, TinhTrang
	from ViPhamHopDong
	where MaKhach like '%'+ @makhach + '%'
end
go


create proc SP_TimKiemNgayKetThuc
@ngayvipham nvarchar(20)
as
begin
	select MaViPham ,MaHopDong, MaNguoiDung, MaKhach, MaPhong, NguoiViPham, NoiDungViPham, NgayViPham, NgayHuy, BienPhapXuLy, TienBoiThuong, TinhTrang
	from ViPhamHopDong
	where NgayViPham like '%'+ @ngayvipham + '%'
end
go
