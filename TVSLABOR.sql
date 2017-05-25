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
<<<<<<< .mine

UPDATE TblTuyenDung SET IdQuocGia = 0 WHERE IdQuocGia IS NULL

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
=======
--UPDATE TblTuyenDung SET IdQuocGia = 0 WHERE IdQuocGia IS NULL
--Thứ 2 15/05/2017
ALTER TABLE dbo.[TblDoanhNghiep] ADD [ThuTuUuTien] [int] NULL  Default(0) ;
UPDATE TblDoanhNghiep SET TblDoanhNghiep.ThuTuUuTien = 0
-- Thứ 3 Ngày 16/05/2017
  ALTER TABLE dbo.[TblNldGioiThieu] ADD [NgayHetHieuLuc] [datetime] NULL  Default(null) ;
  UPDATE [TblNldGioiThieu] SET [TblNldGioiThieu].[NgayHetHieuLuc] = NULL





>>>>>>> .theirs


CREATE TABLE [dbo].tblBaoHiemThatghiep(

);

CREATE TABLE [dbo].tblDNBoSung(
	IdDnBoSung INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	IDNguoiLaoDong INT NOT NULL,

);