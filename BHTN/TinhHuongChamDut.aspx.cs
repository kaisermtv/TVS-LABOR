using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TinhHuongChamDut : System.Web.UI.Page
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
            if (itemId > 0)
            {
                #region load thong tin tinh huong tam dung
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
                    txtSoThangBaoLuu.Text = tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString();
                    txtSoThangDaHuong.Text = tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString();
                    int SoThangHuong = 0;
                    int.TryParse(txtSoThangHuong.Text, out SoThangHuong);
                    int SoThangBaoLuu = 0;
                    int.TryParse(txtSoThangBaoLuu.Text, out SoThangBaoLuu);
                    int SoThangDaHuong = 0;
                    int.TryParse(txtSoThangDaHuong.Text, out SoThangDaHuong);
                    // nếu là trang thai cho tinh huong thi tinh huong
                    if ((int)rowTroCapThatNghiep["IdTrangThai"] == 50)
                    {
                        txtSoThangBaoLuuSauHuong.Text = (SoThangHuong - SoThangDaHuong + SoThangBaoLuu).ToString();
                    }
                    else
                    {
                        txtSoThangBaoLuuSauHuong.Text = tblTinhHuong.Rows[0]["SoThangBaoLuuSauHuong"].ToString();
                    }
                    if (tblTinhHuong.Rows[0]["NgayDeXuatChamDut"] != null && tblTinhHuong.Rows[0]["NgayDeXuatChamDut"].ToString().Trim() != "")
                    {
                         txtNgayDeXuatChamDut.Value = ((DateTime)tblTinhHuong.Rows[0]["NgayDeXuatChamDut"]).ToString("dd/MM/yyyy");
                    }
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

    protected void btnTinhHuong_Click(object sender, EventArgs e)
    {
        if (itemId <= 0) { _msg = "Bạn chưa chọn hồ sơ tính hưởng tiếp tục"; return; }
        if( txtSoThangBaoLuuSauHuong.Text.Trim() =="")
        {
            _msg = "Bạn chưa cập nhật số tháng bảo lưu sau hưởng";
            return;
        }
        if(txtNgayDeXuatChamDut.Value.Trim()=="")
        {
            _msg = "Bạn chưa chọn ngày đề xuất tiếp tục";
            return;
        }
        DateTime NgayDeXuatTiepTuc = Convert.ToDateTime(txtNgayDeXuatChamDut.Value, new CultureInfo("vi-VN"));
        new TinhHuong().UpdateSoThangBaoLuuSauHuong(itemId, int.Parse(txtSoThangBaoLuuSauHuong.Text),NgayDeXuatTiepTuc);
        new TinhHuong().UpdateTrangThaiHS(itemId, 51);

    }
}