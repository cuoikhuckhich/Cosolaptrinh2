-- TẠO CSDL
Create Database Qly_KhachSan
On 
(	Name = QL_KS_data,
	Filename = 'D:\Quynhtrang\test\qly_ks.mdf',
	size = 5,
	Maxsize = 10,
	filegrowth = 2
)
Log on
(	Name = ql_ks_log,
	Filename = 'D:\Quynhtrang\test\qly_ks.ldf',
	size = 5mb,
	Filegrowth = 2mb
)
--TẠO BẢNG
Create table tbIPhong
(
 Maphong nvarchar(10)  primary key not null,
 TenPhong nvarchar(50) not null,
 Dongia float not null,
)
---tao dữ liêu
Insert into tbIPhong (Maphong,Tenphong,Dongia) values('a5','A101',400);
Insert into tbIPhong(Maphong,Tenphong,Dongia) values('a2','A102',400);
Insert into tbIPhong(Maphong,Tenphong,Dongia) values('a3','A103',400);
Insert into tbIPhong(Maphong,Tenphong,Dongia) values('a4','A104',400);
