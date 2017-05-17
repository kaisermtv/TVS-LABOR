using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_PrintPhieuGioiThieu : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTableNguoiLaoDong = new DataTable();
    private DataTable objTableNldTuVan = new DataTable();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public string NLDHoten = "", NLDNgaySinh = "", NLDGioiTinh = "", NLDCMND = "", NLDNgayCapCMND = "", NLNoiCap = "", NLDBHXH = "", NLDDienThoai = "", NLDEmail = "", NLDDanToc = "", NLDTonGiao = "", NLDMucLuongTN = "", NLDLyDoTN = "", NLDDNDaLienHe = "", CongViecTruocThatNghiep = "";
    public string NLDNoiThuongTru = "", NLDTrinhDoPhoThong = "",NLDTrinhDoTayNghe="", NLDTrinhDoKyNangNghe = "", NLDViTriCongViec = "", DVTenDonVi = "", DVDiaChi = "", DVDienThoai = "", DVNgayGioiThieu = "", DVNgayHetHan = "";

    private int IDNldTuVan = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.IDNldTuVan = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.IDNldTuVan = 0;
        }
        if (!Page.IsPostBack && this.IDNldTuVan > 0)
        {
             this.objTableNldTuVan = this.objNguoiLaoDong.getDataTblNldTuVanById(this.IDNldTuVan);

             this.objTableNguoiLaoDong = this.objNguoiLaoDong.getDataById(int.Parse(this.objTableNldTuVan.Rows[0]["IDNguoiLaoDong"].ToString()));
             if (this.objTableNguoiLaoDong.Rows.Count > 0)
             {
              


                 this.NLDHoten = this.objTableNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                 this.NLDNgaySinh = DateTime.Parse(this.objTableNguoiLaoDong.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                 this.NLDGioiTinh = this.objTableNguoiLaoDong.Rows[0]["IDGioiTinh"].ToString().Replace("0","Nữ").Replace("1","Nam");
                 this.NLDCMND = this.objTableNguoiLaoDong.Rows[0]["CMND"].ToString();
                 this.NLDNgayCapCMND = DateTime.Parse(this.objTableNguoiLaoDong.Rows[0]["NgayCapCMND"].ToString()).ToString("dd/MM/yyyy");
                 this.NLNoiCap = this.objTableNguoiLaoDong.Rows[0]["NoiCap"].ToString();
                 this.NLDBHXH = this.objTableNguoiLaoDong.Rows[0]["BHXH"].ToString();
                 this.NLDDienThoai = this.objTableNguoiLaoDong.Rows[0]["DienThoai"].ToString();
                 this.NLDEmail = this.objTableNguoiLaoDong.Rows[0]["Email"].ToString();
                 this.NLDNoiThuongTru = this.objTableNguoiLaoDong.Rows[0]["Xom_TT"].ToString() + ", " + this.objTableNguoiLaoDong.Rows[0]["Xa_TT"].ToString() + ", " + this.objTableNguoiLaoDong.Rows[0]["Huyen_TT"].ToString() + ", " + this.objTableNguoiLaoDong.Rows[0]["Tinh_TT"].ToString();
                 this.NLDTrinhDoPhoThong = this.objTrinhDoPhoThong.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDTrinhDoPhoThong"].ToString()));
                 this.NLDTrinhDoTayNghe = this.objTableNguoiLaoDong.Rows[0]["TrinhDoDaoTao"].ToString();
                 this.NLDTrinhDoKyNangNghe = this.objTableNguoiLaoDong.Rows[0]["TrinhDoKyNangNghe"].ToString();
                 this.CongViecTruocThatNghiep = this.objTableNldTuVan.Rows[0]["CongViecTruocThatNghiep"].ToString();

                 int IDNldDangKy = 0;

                 IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);

                 DataTable objNldGioiThieu = new DataTable();
                 objNldGioiThieu = this.objNguoiLaoDong.getDataNldGioiThieuByNldDangKyId(IDNldDangKy);
                 if (objNldGioiThieu.Rows.Count > 0)
                 {
                     DataTable objTableTuyenDung = new DataTable();
                     TuyenDung objTuyenDung = new TuyenDung();
                     objTableTuyenDung = objTuyenDung.getDataById(int.Parse(objNldGioiThieu.Rows[0]["IDTuyenDung"].ToString()));
                     if (objTableTuyenDung.Rows.Count > 0)
                     {

                         ViTri objVitri = new ViTri();
                         DataRow objRowVitri = objVitri.getItem(int.Parse(objTableTuyenDung.Rows[0]["IdViTri"].ToString()));

                         if (objRowVitri != null)
                         {
                             this.NLDViTriCongViec = objRowVitri["NameVitri"].ToString();
                         }
                     }

                     this.DVTenDonVi = objNldGioiThieu.Rows[0]["TenDonVi"].ToString();
                     this.DVDiaChi = objNldGioiThieu.Rows[0]["DiaChi"].ToString();
                     this.DVDienThoai = objNldGioiThieu.Rows[0]["DienThoaiDonVi"].ToString().Trim();
                      if (DVDienThoai == null || DVDienThoai == "") DVDienThoai = "Phòng nhân sự";
                     
                     if (objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString() != "")
                     {
                         this.DVNgayGioiThieu = "Nghệ An, ngày " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("dd") + " tháng " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("MM") + " năm " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("yyyy");
                     }
                     if (objNldGioiThieu.Rows[0]["NgayHetHieuLuc"] == null || objNldGioiThieu.Rows[0]["NgayHetHieuLuc"].ToString() != "")
                     {
                         this.DVNgayHetHan = " Ngày " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayHetHieuLuc"].ToString()).ToString("dd") + " tháng " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayHetHieuLuc"].ToString()).ToString("MM") + " năm " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayHetHieuLuc"].ToString()).ToString("yyyy");
                     }
                 }

             }

        }
    } 
    #endregion
}