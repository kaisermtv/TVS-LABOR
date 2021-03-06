﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_ThongTinChuyenHuong : System.Web.UI.Page
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
            Load_NoiChuyenDen();
            txtSoGiayGioiThieu.Text = new CapSo().GetAutoNumber(60).ToString();
            txtNgayDeXuat.Value = DateTime.Now.ToString("dd/MM/yyyy");
            if (itemId > 0)
            {
                #region load thong chuyen huong                
                DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId); 
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
                    if (rowTroCapThatNghiep["NgayNopHoSo"] != null && rowTroCapThatNghiep["NgayNopHoSo"].ToString() != "")
                    {
                        DateTime NgayHoanThien = (DateTime)rowTroCapThatNghiep["NgayNopHoSo"];                      
                        lblNgayDangKy.Text = ((DateTime)rowTroCapThatNghiep["NgayNopHoSo"]).ToString("dd/MM/yyyy");
                    }
                }
                DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
                if(tblTinhHuong.Rows.Count>0)
                {
                    txtSoThangHuong.Text = tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString();
                    txtMucHuong.Text =((decimal) tblTinhHuong.Rows[0]["MucHuong"]).ToString("{0:0.##}");
                    txtDaHuong.Text = tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString();
                    txtConLai.Text = tblTinhHuong.Rows[0]["SoThangDuocHuongConLaiBHXH"].ToString();
                    txtHuongTuNgay.Text = ((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy");
                    txtHuongDenNgay.Text = ((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy");                
                }
                // thong tin chuyen huong 
                DataTable tblChuyenHuong = new ChuyenHuong().GetByMaxIDNLDTCTN(itemId);
                if(tblChuyenHuong.Rows.Count>0)
                {
                    ddlNoiChuyenDen.SelectedValue = tblChuyenHuong.Rows[0]["IDNoiChuyen"].ToString();
                    txtLyDoChuyen.Text = tblChuyenHuong.Rows[0]["LyDoChuyen"].ToString();
                    txtNgayDeXuat.Value = ((DateTime)tblChuyenHuong.Rows[0]["NgayDeNghi"]).ToString("dd/MM/yyyy");  
                }
                DataTable tblCapSo = new CapSo().GetByID(itemId, 60);
                if(tblCapSo.Rows.Count>0)
                {
                    txtSoGiayGioiThieu.Text = tblCapSo.Rows[0]["SoVanBan"].ToString();
                }
                #endregion
            }
        }
     
    }
    #endregion

    #region Even Phieu tinh huong
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        _msg = new Common().TaiPhieuTinhHuong(itemId, "");
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
    public void Load_NoiChuyenDen()
    {
        ddlNoiChuyenDen.DataSource = new DanhMuc().getList(52);
        ddlNoiChuyenDen.DataValueField = "IdDanhMuc";
        ddlNoiChuyenDen.DataTextField = "NameDanhMuc";
        ddlNoiChuyenDen.DataBind();

    }
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId, 19);
        Response.Redirect("DanhSachThamDinh.aspx");
    }
    protected void btnTraTiepNhan_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId, 13);
        Response.Redirect("DanhSachThamDinh.aspx");
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        ChuyenHuong objChuyenHuong = new ChuyenHuong();
        objChuyenHuong.IDNLDTCTN = itemId;
        objChuyenHuong.LyDoChuyen = txtLyDoChuyen.Text.Trim();
        if (ddlNoiChuyenDen.SelectedValue != null && ddlNoiChuyenDen.SelectedValue.ToString().Trim() != "")
        {
            objChuyenHuong.IDNoiChuyen = int.Parse(ddlNoiChuyenDen.SelectedValue.ToString());
        }
        if (txtNgayDeXuat.Value.Trim() == "")
        {
            _msg = "Bạn chưa nhập ngày đề xuất";
            return;
        }
        if(txtSoGiayGioiThieu.Text.Trim()=="")
        {
            _msg = "Bạn chưa nhập số giáy giới thiệu";
            return;
        }
        if(txtKyHieu.Text.Trim()=="")
        {
            _msg = "Bạn chưa nhập số ký hiệu";
            return;
        }
        objChuyenHuong.NgayDeNghi = Convert.ToDateTime(txtNgayDeXuat.Value, new CultureInfo("vi-VN"));
        objChuyenHuong.SoGiayGioiThieu = txtSoGiayGioiThieu.Text.Trim();
        objChuyenHuong.StatusID = 0;
        if(hdStatus.Value.Trim()=="" || hdStatus.Value=="0")        
        {
            // kiem tra so
            DateTime NgayCap=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            if(new CapSo().CheckAutoNumber(NgayCap,60,txtSoGiayGioiThieu.Text.Trim())==true)
            {
                _msg = "Số giấy giới thiệu đã tồn tại";
                return;
            }
            CapSo objCapSo = new CapSo();
            objCapSo.IDLoaiVanBan = 60;
            objCapSo.IDNLDTCTN = itemId;
            objCapSo.Nam = DateTime.Now.Year.ToString();
            objCapSo.NgayCap = NgayCap;
            objCapSo.So = int.Parse(txtSoGiayGioiThieu.Text);
            objCapSo.SoVanBan = objCapSo.So.ToString() + txtKyHieu.Text.Trim();
            objCapSo.SetData(objCapSo.So, objCapSo.NgayCap, objCapSo.SoVanBan, objCapSo.IDNLDTCTN, objCapSo.IDLoaiVanBan, objCapSo.Nam);
             //truong hop insert         
            hdStatus.Value = objChuyenHuong.InsertChuyenHuong(objChuyenHuong.IDNLDTCTN, objChuyenHuong.LyDoChuyen, objChuyenHuong.IDNoiChuyen, objChuyenHuong.NgayDeNghi, objChuyenHuong.SoGiayGioiThieu,"", objChuyenHuong.StatusID).ToString();
            _msg = "Cập nhật thành công";
            new TinhHuong().UpdateTrangThaiHS(itemId, 46);
           
        }
        if(hdStatus.Value.Trim()!="" && int.Parse(hdStatus.Value)>0)
        {
            txtSoGiayGioiThieu.ReadOnly = true;
            objChuyenHuong.IDChuyenHuong = int.Parse(hdStatus.Value);
            objChuyenHuong.UpdateChuyenHuong( objChuyenHuong.IDChuyenHuong, objChuyenHuong.IDNLDTCTN, objChuyenHuong.LyDoChuyen, objChuyenHuong.IDNoiChuyen, objChuyenHuong.NgayDeNghi, objChuyenHuong.SoGiayGioiThieu,"", objChuyenHuong.StatusID).ToString();
            _msg = "Cập nhật thành công";
        }
    }
    protected void btnInGiayGioiThieu_ServerClick(object sender, EventArgs e)
    {
        _msg = new Common().InPhieuChuyenHuong(itemId, "");

    }
}