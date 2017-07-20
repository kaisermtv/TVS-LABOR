using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
public class Common
{
    string _msg = "";
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
        lstOutput.Add(tblTinhHuong.Rows[0]["MucHuong"].ToString());
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
}