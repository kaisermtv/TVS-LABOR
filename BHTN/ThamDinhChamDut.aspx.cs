﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_ThamDinhChamDut: System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public string _msg="";
    public DataRow _Permission;
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            DataTable tblPermission = (DataTable)Session["Permission"];
            _Permission = new Account().PermissionPage(tblPermission, System.IO.Path.GetFileName(Request.PhysicalPath));
             if (_Permission ==null || (bool)_Permission["View"] != true)
            {
                Response.Redirect("default.aspx");
            }
        }
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            itemId= int.Parse(Request["id"].ToString());
        }
        if (!Page.IsPostBack)
        {
            LuongToiThieuVung();
            if (itemId > 0)
            {
                #region load thong tin tin tham dinh
                DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId);
           
                if(rowTroCapThatNghiep !=null)
                {
                    txtNgayHenTra.Text = ((DateTime)rowTroCapThatNghiep["NgayHenTraKQ"]).ToString("dd/MM/yyyy");                   
                }
                DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById((int)rowTroCapThatNghiep["IDNguoiLaoDong"]);
                if (tblNguoiLaoDong.Rows.Count > 0)
                {
                    txtHoVaTen.Text = tblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                    hdIDNguoiLaoDong.Value = tblNguoiLaoDong.Rows[0]["IDNguoiLaoDong"].ToString();
                    txtNgaySinh.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy");
                    if (tblNguoiLaoDong.Rows[0]["IdGioiTinh"].ToString().Trim() == "0")
                    {
                        chkGioiTinhNu.Checked = true;
                        chkGioiTinhNam.Checked = false;
                    }
                    else
                    {
                        chkGioiTinhNam.Checked = true;
                        chkGioiTinhNu.Checked = false;
                    }
                    txtCMND.Text = tblNguoiLaoDong.Rows[0]["CMND"].ToString();
                    // Noi Cap CMND
                    txtNoiCap.Text = tblNguoiLaoDong.Rows[0]["NoiCap"].ToString();
                    if (tblNguoiLaoDong.Rows[0]["NgayCapCMND"].ToString().Trim() != "" && ((DateTime)tblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("yyyy") != "1900")
                    {
                        txtNgayCap.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy");
                    }
                    txtSoBHXH.Text = tblNguoiLaoDong.Rows[0]["BHXH"].ToString();
                    txtSoDienThoai.Text = tblNguoiLaoDong.Rows[0]["DienThoai"].ToString();
                    // noi truong tru
                    string thuongtru = "";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Xom_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Xa_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString();
                    txtNoiThuongTru.Text = thuongtru;
                    string choohientai = "";
                    choohientai += tblNguoiLaoDong.Rows[0]["Xom_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Xa_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString();
                    txtChoOHienTai.Text = choohientai;
                    txtSoThangDongBHXH.Text = rowTroCapThatNghiep["SoThangDongBHXH"].ToString();
                    if (rowTroCapThatNghiep["NgayNghiViec"] != null && rowTroCapThatNghiep["NgayNghiViec"].ToString() != "")
                    {
                        txtNgayNghiViec.Value = ((DateTime)rowTroCapThatNghiep["NgayNghiViec"]).ToString("dd/MM/yyyy");
                    }
                    if (rowTroCapThatNghiep["NgayNopHoSo"] != null && rowTroCapThatNghiep["NgayNopHoSo"].ToString() != "")
                    {
                        DateTime NgayHoanThien = (DateTime)rowTroCapThatNghiep["NgayNopHoSo"];
                        txtNgayNopHoSo.Value = NgayHoanThien.ToString("dd/MM/yyyy");
                        lblNgayDangKy.Text = ((DateTime)rowTroCapThatNghiep["NgayNopHoSo"]).ToString("dd/MM/yyyy");
                    }
                }
                DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
                if(tblTinhHuong.Rows.Count>0)
                {
                    txtSoThangHuong.Text = tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString();
                    txtSoThangDaHuong.Text = tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString();
                    txtSoThangBaoLuuSauHuong.Text = tblTinhHuong.Rows[0]["SoThangBaoLuuSauHuong"].ToString();
                    txtHuongTuNgay.Text = ((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy");
                    txtHuongDenNgay.Text = ((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy");
                    txtNgayDeXuatChamDut.Text = ((DateTime)tblTinhHuong.Rows[0]["NgayDeXuatChamDut"]).ToString("dd/MM/yyyy");
                
                }
                DataTable tblCapSo = new CapSo().GetByID(itemId, 30);
                if(tblCapSo.Rows.Count>0)
                {
                    txtSoQuyetDinh.Text = tblCapSo.Rows[0]["SoVanBan"].ToString();
                    if (tblCapSo.Rows[0]["NgayKy"].ToString().Trim() != "" && ((DateTime)tblCapSo.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy") != "1900")
                    {
                        txtNgayKy.Text = ((DateTime)tblCapSo.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy");
                    }
                }
                #endregion
            }
        }
     
    }
    #endregion
    #region Load luong toi thieu vung
    private void LuongToiThieuVung()
    {
        DataTable tblLuongToiThieu = new DanhMuc().getList(19);
        if (tblLuongToiThieu != null && tblLuongToiThieu.Rows.Count > 0)
        {            
            ddlLuongToiThieu.DataValueField = "Note";
            ddlLuongToiThieu.DataTextField = "NameDanhMuc";
            ddlLuongToiThieu.DataSource = tblLuongToiThieu;
            ddlLuongToiThieu.DataBind();
        }
    }

    #endregion 
    #region Even Phieu tinh huong
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
            DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById(int.Parse(hdIDNguoiLaoDong.Value));
            DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId);
            if(TblNguoiLaoDong==null || TblNguoiLaoDong.Rows.Count ==0)
            {
                _msg="Người lao động chưa được khởi tạo";
                return;
            }
            if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
            {
                _msg = "Chưa có bẳng tỉnh nào được cập nhật";
                return;
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
            for (int i = 1; i <=6; i++)
            {
                lstInput.Add("[Thang" + i.ToString() + "]");
                lstOutput.Add(i.ToString());
                lstInput.Add("[TienThang" + i.ToString() + "]");
                lstOutput.Add(tblTinhHuong.Rows[0]["MucDong"+i.ToString()].ToString());
            }

            lstInput.Add("[MucDongTB]");
            lstOutput.Add(tblTinhHuong.Rows[0]["LuongTrungBinh"].ToString());
            lstInput.Add("[MucHuong]");
            lstOutput.Add(tblTinhHuong.Rows[0]["MucHuong"].ToString());        
            lstInput.Add("[SoThangHuong]");
            lstOutput.Add(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            lstInput.Add("[TongTienHuong]");
            decimal MucHuong=0,SoThangHuong=0,TongTienHuong=0;
            MucHuong = decimal.Parse( tblTinhHuong.Rows[0]["MucHuong"].ToString());
            SoThangHuong = decimal.Parse( tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            TongTienHuong=MucHuong *SoThangHuong;
            lstOutput.Add(TongTienHuong.ToString());
            lstInput.Add("[SoThangBaoLuu]");
            lstOutput.Add(tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString());
            lstInput.Add("[NgayTinhHuong]");
            lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/PhieuTinhHuong.docx"), lstInput, lstOutput);

            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=PhieuTinhHuong.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion
    #region Quyet dinh huong tro cap that nghiep
    protected void InQuyetDinhHuongTroCap_ServerClick(object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            TinhHuong objTinhHuong = new TinhHuong();  
            DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
            DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById(itemId);
            DataRow RowTroCapThatNghiep=new NLDTroCapThatNghiep().getItem(itemId);

            if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
            {
                _msg = "Người lao động chưa được khởi tạo";
                return;
            }
            if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
            {
                _msg = "Chưa có bẳng tỉnh nào được cập nhật";
                return;
            }
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();
            lstInput.Add("[NgayKy]");           
            try
            {
                 DateTime NgayDangKy = (DateTime)RowTroCapThatNghiep["NgayNopHoSo"];
                 DateTime NgayQuyetDinh = new DateTime();
                 NgayQuyetDinh = objTinhHuong.TinhNgayNghiLe(NgayDangKy, 20);
                 lstOutput.Add(NgayQuyetDinh.ToString("dd/MM/yyyy"));
            }
            catch
            {
                lstOutput.Add(".../.../.....");
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
            lstOutput.Add(tblTinhHuong.Rows[0]["SoThangDongBHXH"].ToString());
            lstInput.Add("[MucHuong]");
            lstOutput.Add(tblTinhHuong.Rows[0]["MucHuong"].ToString());
            lstInput.Add("[SoThangHuong]");
            int SoThangHuong = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"];
            lstOutput.Add(SoThangHuong.ToString());
            lstInput.Add("[HuongTuNgay]");
            DateTime HuongTuNgay = (DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"];
            DateTime HuongDenNgay = objTinhHuong.TinhNgayNghiLe(HuongTuNgay, 16);
            for (int i = 0; i < SoThangHuong; i++)
            {
                HuongDenNgay = HuongDenNgay.AddMonths(1);
            }
            lstOutput.Add(HuongTuNgay.ToString("dd/MM/yyyy"));
            lstInput.Add("[HuongDenNgay]");
            lstOutput.Add(HuongDenNgay.ToString("dd/MM/yyyy"));

            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/QuyetDinhHuongTCTN.docx"), lstInput, lstOutput);
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhHuongTCTN.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion  
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId,53);
        Response.Redirect("DanhSachThamDinh.aspx");
    }
    protected void btnTraTinhHuong_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId,51);
        Response.Redirect("DanhSachThamDinh.aspx");
    }
    protected void btnTraDeXuat_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId,49);
        Response.Redirect("DanhSachThamDinh.aspx");
    }
}