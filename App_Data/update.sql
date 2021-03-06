
CREATE TABLE [dbo].[tblTrinhDoTinHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NameTrinhDo] [nvarchar](256) NULL,
	[Note] [nvarchar](500) NULL,
	[State] [bit] NOT NULL DEFAULT ((1)),
)

CREATE TABLE [dbo].[tblTrinhDoNgoaiNgu](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NameTrinhDo] [nvarchar](256) NULL,
	[Note] [nvarchar](500) NULL,
	[State] [bit] NOT NULL DEFAULT ((1)),
)



ALTER TABLE [dbo].[TblNguoiLaoDong]
ADD IdTrinhDoTinHoc int

ALTER TABLE [dbo].[TblNguoiLaoDong]
ADD IdTrinhDoNgoaiNgu int


ALTER TABLE [dbo].[TblTuyenDung]
ADD YCNgoaiNgu int

ALTER TABLE [dbo].[TblTuyenDung]
ADD YCTinHoc int

ALTER TABLE [dbo].[TblTuyenDung]
ADD NamKinhNghiem NVARCHAR(256)

ALTER TABLE [dbo].[TblTuyenDung]
ADD ThoiGianLamViec int

ALTER TABLE [dbo].[TblLoaiHinh]
ADD Note NVARCHAR(512)

CREATE TABLE [dbo].[tblViTri](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	NameVitri NVARCHAR(256) NULL,
	[Note] NVARCHAR(500) NULL,
	[State] [bit] NOT NULL DEFAULT ((1)),
)

ALTER TABLE [dbo].[TblTuyenDung]
ADD IdViTri int

ALTER TABLE [dbo].[TblMucLuong]
ADD MinValue FLOAT DEFAULT(0)

ALTER TABLE [dbo].[TblMucLuong]
ADD MaxValue FLOAT DEFAULT(0)

CREATE TABLE dbo.TblDtKhoaHoc (
	IdDtKhoaHoc INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CodeKhoaHoc NVARCHAR(50) NULL,
	NameKhoaHoc NVARCHAR(250) NOT NULL,
	ThoiGianHoc NVARCHAR(250) NULL,
	MucHoTro FLOAT NULL,
	IDDtDonvi INT NULL,
	LoaiKhoaHoc INT NULL,
	[State] BIT NOT NULL DEFAULT (0) 
);