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

-- 02/6/2017 The Linh Create tbltinhhuong
CREATE TABLE [dbo].[TblTinhHuong](
	[IDTinhHuong] [int] IDENTITY(1,1) NOT NULL,
	[IDNguoiLaoDong] [int] NULL,
	[IDNLDTCTN] [int] NULL,
	[NgayTao] [datetime] NULL,
	[IDVungLuongToiThieu] [int] NULL,
	[LuongToiThieuVung] [decimal](18, 2) NULL,
	[ThangDong1] [nvarchar](50) NULL,
	[HeSoLuong1] [float] NULL,
	[HeSoPhuCap1] [float] NULL,
	[LuongCoBan1] [decimal](18, 2) NULL,
	[MucDong1] [decimal](18, 2) NULL,
	[ThangDong2] [nvarchar](50) NULL,
	[HeSoLuong2] [float] NULL,
	[HeSoPhuCap2] [float] NULL,
	[LuongCoBan2] [decimal](18, 2) NULL,
	[MucDong2] [decimal](18, 2) NULL,
	[ThangDong3] [nvarchar](50) NULL,
	[HeSoLuong3] [float] NULL,
	[HeSoPhuCap3] [float] NULL,
	[LuongCoBan3] [decimal](18, 2) NULL,
	[MucDong3] [decimal](18, 2) NULL,
	[ThangDong4] [nvarchar](50) NULL,
	[HeSoLuong4] [float] NULL,
	[HeSoPhuCap4] [float] NULL,
	[LuongCoBan4] [decimal](18, 2) NULL,
	[MucDong4] [decimal](18, 2) NULL,
	[ThangDong5] [nvarchar](50) NULL,
	[HeSoLuong5] [float] NULL,
	[HeSoPhuCap5] [float] NULL,
	[LuongCoBan5] [decimal](18, 2) NULL,
	[MucDong5] [decimal](18, 2) NULL,
	[ThangDong6] [nvarchar](50) NULL,
	[HeSoLuong6] [float] NULL,
	[HeSoPhuCap6] [float] NULL,
	[LuongCoBan6] [decimal](18, 2) NULL,
	[MucDong6] [decimal](18, 2) NULL,
	[SoThangDongBHXH] [int] NULL,
	[SoThangHuongBHXH] [int] NULL,
	[MucHuongToiDa] [decimal](18, 2) NULL,
	[LuongTrungBinh] [decimal](18, 2) NULL,
	[MucHuong] [decimal](18, 2) NULL,
	[HuongTuNgay] [datetime] NULL,
	[IDNguoiTinh] [int] NULL,
 CONSTRAINT [PK_TblTinhHuong] PRIMARY KEY CLUSTERED 
(
	[IDTinhHuong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblTinhHuong] ON
INSERT [dbo].[TblTinhHuong] ([IDTinhHuong], [IDNguoiLaoDong], [IDNLDTCTN], [NgayTao], [IDVungLuongToiThieu], [LuongToiThieuVung], [ThangDong1], [HeSoLuong1], [HeSoPhuCap1], [LuongCoBan1], [MucDong1], [ThangDong2], [HeSoLuong2], [HeSoPhuCap2], [LuongCoBan2], [MucDong2], [ThangDong3], [HeSoLuong3], [HeSoPhuCap3], [LuongCoBan3], [MucDong3], [ThangDong4], [HeSoLuong4], [HeSoPhuCap4], [LuongCoBan4], [MucDong4], [ThangDong5], [HeSoLuong5], [HeSoPhuCap5], [LuongCoBan5], [MucDong5], [ThangDong6], [HeSoLuong6], [HeSoPhuCap6], [LuongCoBan6], [MucDong6], [SoThangDongBHXH], [SoThangHuongBHXH], [MucHuongToiDa], [LuongTrungBinh], [MucHuong], [HuongTuNgay], [IDNguoiTinh]) VALUES (1, 9, 0, CAST(0x0000A7850100A624 AS DateTime), 0, CAST(3750000.00 AS Decimal(18, 2)), N'01/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'02/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'03/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'04/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'01/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'06/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 48, 4, CAST(18750000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), CAST(1200000.00 AS Decimal(18, 2)), CAST(0x0000A79B00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TblTinhHuong] OFF
