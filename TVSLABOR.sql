---- 22/04/2017 | Nguyen Van Khoa
--ALTER TABLE dbo.TblDTNganhNghe ADD IdNhomNganh Int Default(0)
--ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoTinHoc Int Default(0)
--ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoNgoaiNgu Int Default(0)
--ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IdNhomNganh Int Default(0)
--ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IDDTNganhNghe Int Default(0)
--
---- 03/05/2017
--ALTER TABLE dbo.TblNldTuVan ADD ViTriCongViec2 nvarchar(250)
--ALTER TABLE dbo.TblNldTuVan ADD MucLuongThapNhat2 float default(0)
--ALTER TABLE dbo.TblNldTuVan ADD DieuKienLamViec2 nvarchar(250)
--ALTER TABLE dbo.TblNldTuVan ADD DiaDiemLamViec2 nvarchar(250)
--ALTER TABLE dbo.TblNldTuVan ADD CongViecTruocThatNghiep nvarchar(250)
--ALTER TABLE dbo.TblNldTuVan ADD LanTuVan int default(0)
--
----04/05/2017
--ALTER TABLE dbo.TblNldDaoTao ADD TruongHoc nvarchar(500)
----09/05/2017
--ALTER TABLE dbo.[TblNguoiLaoDong] ADD StateLapGiaDinh int  -- khong chọn kiểu bit vì nếu có thêm các trạng thái : ly hôn , ... 

--14/05/2017
--CREATE TABLE [dbo].[TblQuocGia](
--	[IdQuocGia] [int] IDENTITY(1,1) NOT NULL,
--	[CodeQuocGia] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
--	[NameQuocGia] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
--	[Region] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
--	[State] [bit] NULL CONSTRAINT [DF_TblQuocGia_State]  DEFAULT ((0)),
-- CONSTRAINT [PK_TblQuocGia] PRIMARY KEY CLUSTERED 
--(
--	[IdQuocGia] ASC
--)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]

--ALTER TABLE dbo.TblTuyenDung ADD IdQuocGia int Default(0)
--ALTER TABLE dbo.TblTuyenDung ADD NameQuocGia nvarchar(250)

--UPDATE TblTuyenDung SET IdQuocGia = 0 WHERE IdQuocGia IS NULL

--16/05/2017
--CREATE TABLE [dbo].[tblFunction](
--	[Id] [int] NOT NULL,
--	[Name] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
--	[View] [bit] NULL,
--	[Add] [bit] NULL,
--	[Edit] [bit] NULL,
--	[Del] [bit] NULL,
--	[Other] [bit] NULL
--) ON [PRIMARY]

--UPDATE TblTuyenDung SET IdQuocGia = 0 WHERE IdQuocGia IS NULL

--Thứ 2 15/05/2017
--ALTER TABLE dbo.[TblDoanhNghiep] ADD [ThuTuUuTien] [int] NULL  Default(0) ;
--UPDATE TblDoanhNghiep SET TblDoanhNghiep.ThuTuUuTien = 0

-- Thứ 3 Ngày 16/05/2017
--ALTER TABLE dbo.[TblNldGioiThieu] ADD [NgayHetHieuLuc] [datetime] NULL  Default(null) ;
--UPDATE [TblNldGioiThieu] SET [TblNldGioiThieu].[NgayHetHieuLuc] = NULL

--25/05/2017
GO
CREATE TABLE [dbo].[TblNLDTroCapThatNghiep](
	[IdNLDTCTN] [int] IDENTITY(1,1) NOT NULL,
	[IDNguoiLaoDong] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_IDNguoiLaoDong]  DEFAULT ((0)),
	[NgayNghiViec] [datetime] NULL,
	[SoThangBHTN] [float] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_SoThangBHTN]  DEFAULT ((0)),
	[NhuCauTuVan] [bit] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NhuCauTuVan]  DEFAULT ((0)),
	[NhuCauGTVL] [bit] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NhuCauGTVL]  DEFAULT ((0)),
	[NhuCauHocNghe] [bit] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NhuCauHocNghe]  DEFAULT ((0)),
	[NgayDangKyTN] [datetime] NULL,
	[DangKyTre] [bit] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_DangKyTre]  DEFAULT ((0)),
	[DangKyTreLyDo] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_DangKyTreLyDo]  DEFAULT ((0)),
	[NoiTiepNhan] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NoiTiepNhan]  DEFAULT ((0)),
	[NgayHoanThien] [datetime] NULL,
	[NoiNhanBaoHiem] [int] NULL,
	[HinhThucNhanTien] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_HinhThucNhanTien]  DEFAULT ((0)),
	[NoiChotSoCuoi] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NoiChotSoCuoi]  DEFAULT ((0)),
	[DaXacNhanChuaDangKy] [bit] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_DaXacNhanChuaDangKy]  DEFAULT ((0)),
	[NoiXacNhanChuaDangKy] [int] NULL CONSTRAINT [DF_TblNLDTroCapThatNghiep_NoiXacNhanChuaDangKy]  DEFAULT ((0)),
 CONSTRAINT [PK_TblNLDTroCapThatNghiep] PRIMARY KEY CLUSTERED 
(
	[IdNLDTCTN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].tblDNBoSung(
	IdDnBoSung INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	IDNguoiLaoDong INT NOT NULL,

);


ALTER TABLE dbo.[TblNguoiLaoDong] ADD NgayCapBHXH DATETIME NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD NoiCapBHXH INT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD NoiDangKyKhamBenh INT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD TrinhDoChuyenMon INT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD LinhVucDaoTao INT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD CongViecDaLam NTEXT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD IDNganHang INT NULL ;
ALTER TABLE dbo.[TblNguoiLaoDong] ADD MaSoThue NVARCHAR(50) NULL ;

-- 27/05/2017

ALTER TABLE dbo.TblDoanhNghiep ADD FaxDonVi NVARCHAR(50) NULL ;
ALTER TABLE dbo.TblDoanhNghiep ADD SoDKKD NVARCHAR(50) NULL ;


ALTER TABLE dbo.[TblNguoiLaoDong] ADD IdDoanhNghiep Int NULL 

ALTER TABLE dbo.[TblNguoiLaoDong] ADD TrangThaiHS Int NULL ;

CREATE TABLE dbo.tblTrangThaiHoSo(
	id INT PRIMARY KEY NOT NULL,
	name NVARCHAR(50) NULL
)

INSERT INTO dbo.tblTrangThaiHoSo VALUES (1,N'Đăng ký');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (2,N'Hoàn thiện');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (3,N'Đã tính hưởng');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (4,N'Đã thẩm định');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (5,N'Đã ký quyết định');

-- 31/05/2017
CREATE TABLE dbo.tblDanhMuc(
	IdDanhMuc INT PRIMARY KEY IDENTITY(1,1),
	DanhMucId INT NOT NULL DEFAULT(0),
	NameDanhMuc NVARCHAR(256) NULL,
	Note NTEXT NULL,

	--Paren INT NULL, 
	--MaDanhMuc NVARCHAR(256) NULL,
	[State] BIT NOT NULL  DEFAULT(1),
	CreateDate DATETIME NOT NULL DEFAULT(GETDATE())
)

INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Nơi cấp CMND');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Nơi cấp BHXH');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Lý do đăng ký trễ');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Nơi nhận bảo hiểm');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Nơi chốt sổ cuối');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Nơi đăng ký khám bệnh');