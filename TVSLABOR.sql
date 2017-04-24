-- 22/04/2017 | Nguyen Van Khoa
ALTER TABLE dbo.TblDTNganhNghe ADD IdNhomNganh Int Default(0)
ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoTinHoc Int Default(0)
ALTER TABLE dbo.TblTuyenDung ADD IdTrinhDoNgoaiNgu Int Default(0)
ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IdNhomNganh Int Default(0)
ALTER TABLE dbo.TblNldQuaTrinhDaoTao ADD IDDTNganhNghe Int Default(0)