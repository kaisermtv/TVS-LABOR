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
CREATE TABLE [dbo].[TblNLDTroCapThatNghiep]
(
	[IdNLDTCTN] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IDNguoiLaoDong] INT NOT NULL,
	IDNldTuVan INT NULL,
	NgayNopHoSo DATETIME NULL DEFAULT(GETDATE()),
	IdNguoiNhan INT NULL,
	IdNoiNhan INT Null,
	SoThangDongBHXH FLOAT NULL,
	IdLoaiHopDong INT NOT NULL DEFAULT (0),
	IdGiayTokemTheo INT NOT NULL DEFAULT (0),
	NgayHoanThien DATETIME NULL,
	HanHoanThien DATETIME NULL,
	IdNoiNhanTCTN INT NOT NULL DEFAULT (0),
	IdNoiChotSoCuoi INT NOT NULL DEFAULT (0),
	IdHinhThucNhanTien INT NOT NULL DEFAULT (0),
	IdTrangThai INT NULL,
	IdQuaTrinhCongTacGanNhat INT NULL,
	NgayNghiViec DATETIME NULL,
	CongViecDaLam NTEXT NULL,

	EditDay DATETIME NOT NULL DEFAULT (GETDATE()),
	EditTrangThaiDate DATETIME NOT NULL DEFAULT (GETDATE())
)

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

ALTER TABLE dbo.[TblNLDTroCapThatNghiep] ADD TrangThaiHS Int NULL ;

CREATE TABLE dbo.tblTrangThaiHoSo(
	id INT PRIMARY KEY NOT NULL,
	name NVARCHAR(50) NULL
)

INSERT INTO dbo.tblTrangThaiHoSo VALUES (1,N'Đăng ký');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (2,N'Hoàn thiện');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (3,N'Đã tính hưởng');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (4,N'Đã thẩm định');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (5,N'Đã ký quyết định');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (10,N'Kết thúc hưởng');

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
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Lương tối thiểu vùng');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Loại hợp đồng');
INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Giấy tờ kèm theo');



-- 03/06/2017

ALTER TABLE dbo.[TblNLDTroCapThatNghiep] ADD TrangThaiHS Int NULL ;












































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
<<<<<<< .mine
>>>>>>> .theirs

-- 04/06/2017 The linh cap nhat danh sach ngay nghi le nam
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (20, 19, N'Vùng I', N'3750000', 1, CAST(0x0000A78700B5B2FF AS DateTime))
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (21, 19, N'Vùng II', N'3320000', 1, CAST(0x0000A78700B5D8C5 AS DateTime))
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (22, 19, N'Vùng III', N'2900000', 1, CAST(0x0000A78700B64AB1 AS DateTime))
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (23, 19, N'Vùng IV', N'2580000', 1, CAST(0x0000A78700B665BA AS DateTime))

INSERT INTO dbo.tblDanhMuc(NameDanhMuc) VALUES(N'Danh sách ngày nghỉ lễ trong năm');
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (25, 24, N'30/04/2017', N'Ngày Giải phóng miền Nam, Thống nhất đất nước', 1, CAST(0x0000A7880098A8CE AS DateTime))
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (26, 24, N'01/05/2017', N'Ngày Quốc tế Lao động', 1, CAST(0x0000A78800997938 AS DateTime))
INSERT [dbo].[tblDanhMuc] ([IdDanhMuc], [DanhMucId], [NameDanhMuc], [Note], [State], [CreateDate]) VALUES (27, 24, N'02/09/2017', N'Ngày Quốc khánh', 1, CAST(0x0000A78800999C92 AS DateTime))
--05/06/2017
INSERT INTO dbo.tblTrangThaiHoSo VALUES (6,N'Chuyển thẩm định');
drop  TABLE [dbo].[TblTinhHuong]
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
	[SoThangHuongBHXH] [int] NULL,
	[SoThangBaoLuuBHXH] [int] NULL,
	[MucHuongToiDa] [decimal](18, 2) NULL,
	[LuongTrungBinh] [decimal](18, 2) NULL,
	[MucHuong] [decimal](18, 2) NULL,
	[HuongTuNgay] [datetime] NULL,
	[HuongDenNgay] [datetime] NULL,
	[IDNguoiTinh] [int] NULL,
 CONSTRAINT [PK_TblTinhHuong] PRIMARY KEY CLUSTERED 
(
	[IDTinhHuong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblTinhHuong] ON
INSERT [dbo].[TblTinhHuong] ([IDTinhHuong], [IDNguoiLaoDong], [IDNLDTCTN], [NgayTao], [IDVungLuongToiThieu], [LuongToiThieuVung], [ThangDong1], [HeSoLuong1], [HeSoPhuCap1], [LuongCoBan1], [MucDong1], [ThangDong2], [HeSoLuong2], [HeSoPhuCap2], [LuongCoBan2], [MucDong2], [ThangDong3], [HeSoLuong3], [HeSoPhuCap3], [LuongCoBan3], [MucDong3], [ThangDong4], [HeSoLuong4], [HeSoPhuCap4], [LuongCoBan4], [MucDong4], [ThangDong5], [HeSoLuong5], [HeSoPhuCap5], [LuongCoBan5], [MucDong5], [ThangDong6], [HeSoLuong6], [HeSoPhuCap6], [LuongCoBan6], [MucDong6], [SoThangHuongBHXH], [SoThangBaoLuuBHXH], [MucHuongToiDa], [LuongTrungBinh], [MucHuong], [HuongTuNgay], [HuongDenNgay], [IDNguoiTinh]) VALUES (5, 9, 1, CAST(0x0000A78900FD81A7 AS DateTime), 20, CAST(3750000.00 AS Decimal(18, 2)), N'01/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'02/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'03/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'04/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'01/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'06/2017', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 3, 0, CAST(18750000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), CAST(1200000.00 AS Decimal(18, 2)), CAST(0x0000A7A000000000 AS DateTime), CAST(0x0000A7FB00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TblTinhHuong] OFF
-- 6/08/2017 the linh
INSERT INTO dbo.tblTrangThaiHoSo VALUES (7,N'Đã thẩm định');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (8,N'Đánh số - Trình ký');
=======
--19/06/2017
ALTER TABLE dbo.TblCanBo ADD IDChucVu int 
INSERT INTO dbo.tblTrangThaiHoSo VALUES (12,N'Đã trả QĐ hưởng TCTN');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (13,N'Đề xuất hủy hưởng');
--21/06/2017
ALTER TABLE dbo.TblNLDTroCapThatNghiep ADD NgayHenTraKQ datetime 
ALTER TABLE dbo.TblNLDTroCapThatNghiep ADD NgayKyQD datetime 
ALTER TABLE dbo.TblNLDTroCapThatNghiep ADD IdNguoiKy int 
-- 28/06/2017
INSERT INTO dbo.tblTrangThaiHoSo VALUES (14,N'Đã khai báo');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (15,N'Không khai báo');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (16,N'Tạm dừng');
INSERT INTO dbo.tblTrangThaiHoSo VALUES (17,,N'Tiếp tục');
-- tao bang thong bao viec lam hang thang
CREATE TABLE [dbo].[TblThongBaoViecLamHangThang](
	[IDThongBaoViecLam] [int] IDENTITY(1,1) NOT NULL,
	[IDNLDTCTN] [int] NULL,
	[IDCanBoTiepNhan] [int] NULL,
	[ThangThongBao] [int] NULL,
	[NgayThongBao] [datetime] NULL,
	[ThongBaoTrucTiep] [bit] NULL,
	[LyDo] [int] NULL,
	[BanTiepNhan] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TrangThaiThongBao] [int] NULL,
 CONSTRAINT [PK_TblThongBaoViecLamHangThang] PRIMARY KEY CLUSTERED 
(
	[IDThongBaoViecLam] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO






































































>>>>>>> .theirs
