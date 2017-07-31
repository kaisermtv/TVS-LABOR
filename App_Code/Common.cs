using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
public class Common
{
    string _msg = "";
    public string TaiPhieuTinhHuong(int INLDTCTN, string FileName)
    {
        string _msg = "";
        DataTable tblTinhHuong = new TinhHuong().getDataById(INLDTCTN);
        DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(INLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)rowTroCapThatNghiep["IDNguoiLaoDong"]);
      
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
        {
            _msg = "Chưa có bẳng tỉnh nào được cập nhật";
            return _msg;
        }

        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[TenNLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgaySinh]");
        lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[SoBHXH]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
        lstInput.Add("[SoThangDong]");
        lstOutput.Add(rowTroCapThatNghiep["SoThangDongBHXH"].ToString());
        lstInput.Add("[DongTuThang]");
        lstOutput.Add(tblTinhHuong.Rows[0]["HuongTungay"].ToString());
        lstInput.Add("[DongDenThang]");
        lstOutput.Add(tblTinhHuong.Rows[0]["HuongDenNgay"].ToString());
        for (int i = 1; i <= 6; i++)
        {
            lstInput.Add("[Thang" + i.ToString() + "]");
            lstOutput.Add(i.ToString());
            lstInput.Add("[TienThang" + i.ToString() + "]");
            lstOutput.Add(((decimal)tblTinhHuong.Rows[0]["MucDong" + i.ToString()]).ToString("0.##"));
        }

        lstInput.Add("[MucDongTB]");
        lstOutput.Add(((decimal)tblTinhHuong.Rows[0]["LuongTrungBinh"]).ToString("0.##"));
        lstInput.Add("[MucHuong]");
        lstOutput.Add(((decimal)tblTinhHuong.Rows[0]["MucHuong"]).ToString("0.##"));
        lstInput.Add("[SoThangHuong]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
        lstInput.Add("[TongTienHuong]");
        decimal MucHuong = 0, SoThangHuong = 0, TongTienHuong = 0;
        MucHuong = decimal.Parse(tblTinhHuong.Rows[0]["MucHuong"].ToString());
        SoThangHuong = decimal.Parse(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
        TongTienHuong = MucHuong * SoThangHuong;
        lstOutput.Add(TongTienHuong.ToString("0.##"));
        lstInput.Add("[SoThangBaoLuu]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString());
        lstInput.Add("[NgayTinhHuong]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
        //lstInput.Add()
        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/PhieuTinhHuong.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=PhieuTinhHuong.docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;
    }
    public string TaiQuyetDinhTCTN(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataTable tblTinhHuong = new TinhHuong().getDataById(IDNLDTCTN);
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinh = new CapSo().GetByID(IDNLDTCTN, 30);
        DataTable tblLichThongBao = new LichThongBao().GetDataByID((int)tblTinhHuong.Rows[0]["IDTinhHuong"]);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
        {
            _msg = "Chưa có bẳng tỉnh nào được cập nhật";
            return _msg;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayKy]");
        try
        {
            lstOutput.Add(((DateTime)tblQuyetDinh.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[SoQD]");
        if (tblQuyetDinh.Rows.Count == 0)
        {
            lstOutput.Add("......................");
        }
        else
        {
            lstOutput.Add(tblQuyetDinh.Rows[0]["SoVanBan"].ToString());
        }
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgaySinh]");
        lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[CMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["CMND"].ToString());
        lstInput.Add("[NgayCapCMTND]");
        lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[NoiCapCMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiCap"].ToString());
        lstInput.Add("[SoBHXH]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
        lstInput.Add("[DiaChiThuongTru]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiThuongTru"].ToString());
        lstInput.Add("[DiaChiHienTai]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["DiaChi"].ToString());
        lstInput.Add("[SoThangDong]");
        lstOutput.Add(RowTroCapThatNghiep["SoThangDongBHXH"].ToString());
        lstInput.Add("[MucHuong]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["MucHuong"]).ToString("0.##"));
        lstInput.Add("[SoThangHuong]");
        int SoThangHuong = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"];
        lstOutput.Add(SoThangHuong.ToString());
        lstInput.Add("[SoThangBaoLuu]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString());
        lstInput.Add("[HuongTuNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[HuongDenNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy"));
        //----- chen phan lich thong bao viec lam
        if (tblLichThongBao.Rows.Count == 0)
        {
            _msg = "Hồ sơ chưa có lịch thông báo";
            return _msg;
        }
        lstInput.Add("[Thang1]");
        lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang1TuNgay"]).ToString("dd/MM/yyyy"));
        for (int i = 2; i <= 12; i++)
        {
            lstInput.Add("[Thang" + i.ToString() + "Tu]");
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("yyyy") != "1900")
            {
                lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("dd/MM/yyyy"));
            }
            else
            {
                lstOutput.Add("../../....");
            }
            lstInput.Add("[Thang" + i.ToString() + "Den]");
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("yyyy") != "1900")
            {
                lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("dd/MM/yyyy"));

            }
            else
            {
                lstOutput.Add("../../....");
            }
        }

        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/QuyetDinhHuongTCTN.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhHuongTCTN" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;       
    }
    public string TaiQuyetDinhHuyHuong(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinhTCTN = new CapSo().GetByID(IDNLDTCTN, 30);
        DataTable tblQuyetDinhHuyHuong= new CapSo().GetByID(IDNLDTCTN, 49);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayKy]");
        try
        {        
            lstOutput.Add(((DateTime)tblQuyetDinhHuyHuong.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[SoQD]");
        if (tblQuyetDinhHuyHuong.Rows.Count == 0)
        {
            lstOutput.Add("......................");
        }
        else
        {
            lstOutput.Add(tblQuyetDinhHuyHuong.Rows[0]["SoVanBan"].ToString());
        }
        lstInput.Add("[SoQDTCTN]");
        lstOutput.Add(tblQuyetDinhTCTN.Rows[0]["SoVanBan"].ToString());
        lstInput.Add("[NgayKyTCTN]");
        try
        {          
            lstOutput.Add(((DateTime) tblQuyetDinhTCTN.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[Lydo]");
        lstOutput.Add(".................");
        lstInput.Add("[QDTCTN]");
        lstOutput.Add(tblQuyetDinhTCTN.Rows[0]["SoVanBan"].ToString());
        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/QuyetDinhHuyHuong.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhHuyHuong" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;       

    }
    public string TaiQuyetDinhTamDung(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinhTCTN = new CapSo().GetByID(IDNLDTCTN, 30);
        DataTable tblQuyetDinhDungHuong = new CapSo().GetByID(IDNLDTCTN, 50);
        DataTable tblTinhHuong = objTinhHuong.getDataById(IDNLDTCTN);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        if (tblTinhHuong.Rows.Count == 0)
        {
            _msg = "Tính hưởng chưa được khởi tạo";
            return _msg;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayKy]");
        try
        {
            lstOutput.Add(((DateTime)tblQuyetDinhDungHuong.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[SoQD]");
        if (tblQuyetDinhDungHuong.Rows.Count == 0)
        {
            lstOutput.Add("......................");
        }
        else
        {
            lstOutput.Add(tblQuyetDinhDungHuong.Rows[0]["SoVanBan"].ToString());
        }
        lstInput.Add("[SoQDTCTN]");
        lstOutput.Add(tblQuyetDinhTCTN.Rows[0]["SoVanBan"].ToString());
        lstInput.Add("[NgayKyTCTN]");
        try
        {
            lstOutput.Add(((DateTime) tblQuyetDinhTCTN.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgaySinh]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));

        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[CMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["CMND"].ToString());
        lstInput.Add("[NgayCapCMTND]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[NoiCapCMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiCap"].ToString());
        lstInput.Add("[SoBHXH]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
        lstInput.Add("[DiaChiThuongTru]");
        string diachithuongtru = "";
        if(TblNguoiLaoDong.Rows[0]["Xom_TT"].ToString().Trim()!="")
        {
            diachithuongtru += TblNguoiLaoDong.Rows[0]["Xom_TT"].ToString().Trim();
        }
        if(TblNguoiLaoDong.Rows[0]["Xa_TT"].ToString().Trim()!="")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Xa_TT"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString().Trim() != "")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString().Trim() != "")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString().Trim();
        }
        lstOutput.Add(diachithuongtru);
        lstInput.Add("[DiaChiHienTai]");
        string diachi= "";
        if (TblNguoiLaoDong.Rows[0]["Xom_DC"].ToString().Trim() != "")
        {
            diachi += TblNguoiLaoDong.Rows[0]["Xom_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Xa_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Xa_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString().Trim();
        }
        lstOutput.Add(diachi);
        lstInput.Add("[STD]");
        lstOutput.Add( RowTroCapThatNghiep["SoThangDongBHXH"].ToString());
        lstInput.Add("[STH]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
        lstInput.Add("[STDH]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString());

        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/QuyetDinhTamDungHuong.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhTamDungHuong" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;

    }
    public string TaiQuyetDinhTiepTuc(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinhTCTN = new CapSo().GetByID(IDNLDTCTN, 30);
        DataTable tblQuyetDinhTiepTuc = new CapSo().GetByID(IDNLDTCTN, 51);
        DataTable tblTinhHuong = objTinhHuong.getDataById(IDNLDTCTN);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        if (tblTinhHuong.Rows.Count == 0)
        {
            _msg = "Tính hưởng chưa được khởi tạo";
            return _msg;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayKy]");
        try
        {
            lstOutput.Add(((DateTime)tblQuyetDinhTiepTuc.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[SoQD]");
        if (tblQuyetDinhTiepTuc.Rows.Count == 0)
        {
            lstOutput.Add("......................");
        }
        else
        {
            lstOutput.Add(tblQuyetDinhTiepTuc.Rows[0]["SoVanBan"].ToString());
        }

        lstInput.Add("[SoQDTCTN]");
        lstOutput.Add(tblQuyetDinhTCTN.Rows[0]["SoVanBan"].ToString());
        lstInput.Add("[NgayKyTCTN]");
        try
        {
            lstOutput.Add(((DateTime)tblQuyetDinhTCTN.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }

        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgaySinh]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));

        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[CMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["CMND"].ToString());
        lstInput.Add("[NgayCapCMTND]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[NoiCapCMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiCap"].ToString());
        lstInput.Add("[SoBHXH]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
        lstInput.Add("[DiaChiThuongTru]");
        string diachithuongtru = "";
        if (TblNguoiLaoDong.Rows[0]["Xom_TT"].ToString().Trim() != "")
        {
            diachithuongtru += TblNguoiLaoDong.Rows[0]["Xom_TT"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Xa_TT"].ToString().Trim() != "")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Xa_TT"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString().Trim() != "")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString().Trim() != "")
        {
            diachithuongtru += ", " + TblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString().Trim();
        }
        lstOutput.Add(diachithuongtru);
        lstInput.Add("[DiaChiHienTai]");
        string diachi = "";
        if (TblNguoiLaoDong.Rows[0]["Xom_DC"].ToString().Trim() != "")
        {
            diachi += TblNguoiLaoDong.Rows[0]["Xom_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Xa_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Xa_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString().Trim();
        }
        if (TblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString().Trim() != "")
        {
            diachi += ", " + TblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString().Trim();
        }
        lstOutput.Add(diachi);
        lstInput.Add("[STD]");
        lstOutput.Add(RowTroCapThatNghiep["SoThangDongBHXH"].ToString());
        lstInput.Add("[STH]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
        lstInput.Add("[STCL]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangDuocHuongConLaiBHXH"].ToString());

        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/QuyetDinhTiepTucHuong.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhTiepTucHuong" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;

    }
    public string TaiPhieuHenTraKQ(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
       
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayNopHS]");
        lstOutput.Add(((DateTime)RowTroCapThatNghiep["NgayNopHoSo"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgaySinh]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[CMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["CMND"].ToString());
        lstInput.Add("[NgayCapCMTND]");
        try
        {
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }

        lstInput.Add("[NoiCapCMTND]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiCap"].ToString());
        lstInput.Add("[NgayHenTra]");
        try
        {
            lstOutput.Add(((DateTime)RowTroCapThatNghiep["NgayHenTraKQ"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/PhieuHenTraTiepNhan.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=PhieuHenTraTiepNhan" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;

    }
    public string InPhieuChuyenHuong(int IDNLDTCTN, string FileName)
    {
        string _msg = "";
        TinhHuong objTinhHuong = new TinhHuong();
        DataTable tblTinhHuong = new TinhHuong().getDataById(IDNLDTCTN);
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinhTCTN = new CapSo().GetByID(IDNLDTCTN, 30);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return _msg;
        }
        DataTable tblChuyenHuong = new ChuyenHuong().GetByMaxIDNLDTCTN(IDNLDTCTN);
        if(tblChuyenHuong.Rows.Count==0)
        {
            _msg = "Chưa có thông tin chuyển hưởng";
            return _msg;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[SoQD]");
        lstOutput.Add(tblChuyenHuong.Rows[0]["SoGiayGioiThieu"].ToString());       
        lstInput.Add("[NgayDeNghi]");
        try
        {
            lstOutput.Add(((DateTime)tblChuyenHuong.Rows[0]["NgayDeNghi"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[NoiChuyenDen]");
        DataRow NoiChuyenDen = new DanhMuc().getItem(int.Parse(tblChuyenHuong.Rows[0]["IDNoiChuyen"].ToString()));
        lstOutput.Add(NoiChuyenDen["NameDanhMuc"].ToString());
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[NgayDeNghi]");
        try
        {
            lstOutput.Add(((DateTime)tblChuyenHuong.Rows[0]["NgayDeNghi"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[TenLD]");
        lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
        lstInput.Add("[SoQDTCTN]");
        lstOutput.Add(tblQuyetDinhTCTN.Rows[0]["SoVanBan"].ToString());
        lstInput.Add("[NgayKyTCTN]");
        try
        {
            lstOutput.Add(((DateTime)tblQuyetDinhTCTN.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add("../../....");
        }
        lstInput.Add("[SoThangDaHuong]");
        int  SoThangDaHuong=0;
        int.TryParse(tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString(), out SoThangDaHuong);
        lstOutput.Add(SoThangDaHuong.ToString());
        lstInput.Add("[HuongTuNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[HuongDenNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[MucHuong]");
        lstOutput.Add(((decimal)tblTinhHuong.Rows[0]["MucHuong"]).ToString("0.##"));
        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(HttpContext.Current.Server.MapPath("../WordForm/GiayGioiThieuChuyenHuong.docx"), lstInput, lstOutput);
        HttpContext.Current.Response.AppendHeader("Content-Type", "application/msword");
        HttpContext.Current.Response.AppendHeader("Content-disposition", "inline; filename=GiayGioiThieuChuyenHuong" + FileName + ".docx");
        HttpContext.Current.Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
        return _msg;

    }
    private string replace_special_word(string chuoi)
    {
        chuoi = chuoi.Replace("không mươi không ", "");
        chuoi = chuoi.Replace("không mươi", "lẻ");
        chuoi = chuoi.Replace("i không", "i");
        chuoi = chuoi.Replace("i năm", "i lăm");
        chuoi = chuoi.Replace("một mươi", "mười");
        chuoi = chuoi.Replace("mươi một", "mươi mốt");
        chuoi = chuoi.Replace("lẻ lăm", "lẻ năm");

        return chuoi;
    }
    public string ChuyenSo(string number)
    {
        string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
        string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        string doc;
        int i, j, k, n, len, found, ddv, rd;

        len = number.Length;
        number += "ss";
        doc = "";
        found = 0;
        ddv = 0;
        rd = 0;

        i = 0;
        while (i < len)
        {
            //So chu so o hang dang duyet
            n = (len - i + 2) % 3 + 1;

            //Kiem tra so 0
            found = 0;
            for (j = 0; j < n; j++)
            {
                if (number[i + j] != '0')
                {
                    found = 1;
                    break;
                }
            }

            //Duyet n chu so
            if (found == 1)
            {
                rd = 1;
                for (j = 0; j < n; j++)
                {
                    ddv = 1;
                    switch (number[i + j])
                    {
                        case '0':
                            if (n - j == 3) doc += cs[0] + " ";
                            if (n - j == 2)
                            {
                                if (number[i + j + 1] != '0') doc += "lẻ ";
                                ddv = 0;
                            }
                            break;
                        case '1':
                            if (n - j == 3) doc += cs[1] + " ";
                            if (n - j == 2)
                            {
                                doc += "mười ";
                                ddv = 0;
                            }
                            if (n - j == 1)
                            {
                                if (i + j == 0) k = 0;
                                else k = i + j - 1;

                                if (number[k] != '1' && number[k] != '0')
                                    doc += "mốt ";
                                else
                                    doc += cs[1] + " ";
                            }
                            break;
                        case '5':
                            if (i + j == len - 1)
                                doc += "lăm ";
                            else
                                doc += cs[5] + " ";
                            break;
                        default:
                            doc += cs[(int)number[i + j] - 48] + " ";
                            break;
                    }

                    //Doc don vi nho
                    if (ddv == 1)
                    {
                        doc += dv[n - j - 1] + " ";
                    }
                }
            }


            //Doc don vi lon
            if (len - i - n > 0)
            {
                if ((len - i - n) % 9 == 0)
                {
                    if (rd == 1)
                        for (k = 0; k < (len - i - n) / 9; k++)
                            doc += "tỉ ";
                    rd = 0;
                }
                else
                    if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
            }

            i += n;
        }

        if (len == 1)
            if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

        string str1 = doc.Substring(0, 1).ToUpper();
        string str2 = doc.Substring(1, doc.Length - 1);
        string str = str1 + str2;
        return replace_special_word(str) + "đồng";
    } 
}