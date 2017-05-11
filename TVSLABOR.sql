-- 22/04/2017 | Nguyen Van Khoa
ALTER TABLE dbo.TblDTNganhNghe ADD IdNhomNganh Int Default(0)
ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoTinHoc Int Default(0)
ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoNgoaiNgu Int Default(0)
ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IdNhomNganh Int Default(0)
ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IDDTNganhNghe Int Default(0)

-- 03/05/2017
ALTER TABLE dbo.TblNldTuVan ADD ViTriCongViec2 nvarchar(250)
ALTER TABLE dbo.TblNldTuVan ADD MucLuongThapNhat2 float default(0)
ALTER TABLE dbo.TblNldTuVan ADD DieuKienLamViec2 nvarchar(250)
ALTER TABLE dbo.TblNldTuVan ADD DiaDiemLamViec2 nvarchar(250)
ALTER TABLE dbo.TblNldTuVan ADD CongViecTruocThatNghiep nvarchar(250)
ALTER TABLE dbo.TblNldTuVan ADD LanTuVan int default(0)

--04/05/2017
ALTER TABLE dbo.TblNldDaoTao ADD TruongHoc nvarchar(500)
--09/05/2017
ALTER TABLE dob.[TblNguoiLaoDong] ADD StateLapGiaDinh int  -- khong chọn kiểu bit vì nếu có thêm các trạng thái : ly hôn , ... 