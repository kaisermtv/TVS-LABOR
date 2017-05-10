using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_PrintThongBaoKetQua : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTableNguoiLaoDong = new DataTable();
    private DataTable objTableNldTuVan = new DataTable();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private ChucVu objChucVu = new ChucVu();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public string DVTenDonVi = "", DVNgayGioiThieu = "";
    public string NLDHoten = "", NLDNgaySinh = "", NLDGioiTinh = "", NLDCMND = "", NLDNgayCapCMND = "", NLNoiCap = "", NLDViTriCongViec = "", NldKq_ViTriLamViec = "", NldKq_NgayDuKienNhanViec = "", NldKq_ThoiGianThuViec = "", NldKq_LyDoKhongTrungTuyen = "";
    private int IDNldTuVan = 0, IDNldGioiThieu = 0;
    #endregion

    #region method  Page_Load
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
                 this.NLDGioiTinh = this.objTableNguoiLaoDong.Rows[0]["IDGioiTinh"].ToString().Replace("0", "Nữ").Replace("1", "Nam");
                 this.NLDCMND = this.objTableNguoiLaoDong.Rows[0]["CMND"].ToString();
                 this.NLDNgayCapCMND = DateTime.Parse(this.objTableNguoiLaoDong.Rows[0]["NgayCapCMND"].ToString()).ToString("dd/MM/yyyy");
                 this.NLNoiCap = this.objTableNguoiLaoDong.Rows[0]["NoiCap"].ToString();
                 this.NLDViTriCongViec = this.objTableNldTuVan.Rows[0]["ViTriCongViec"].ToString();
                 int IDNldDangKy = 0;

                 IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);

                 DataTable objNldGioiThieu = new DataTable();
                 objNldGioiThieu = this.objNguoiLaoDong.getDataNldGioiThieuByNldDangKyId(IDNldDangKy);
                 if (objNldGioiThieu.Rows.Count > 0)
                 {
                     this.IDNldGioiThieu = int.Parse(objNldGioiThieu.Rows[0]["IDNldGioiThieu"].ToString());
                     this.DVTenDonVi = objNldGioiThieu.Rows[0]["TenDonVi"].ToString();
                     if (objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString() != "")
                     {
                         //this.DVNgayGioiThieu = "Nghệ An, ngày " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("dd") + " tháng " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("MM") + " năm " + DateTime.Parse(objNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString("yyyy");

                         this.DVNgayGioiThieu = "Nghệ An, ngày &nbsp;&nbsp;&nbsp; tháng &nbsp;&nbsp;&nbsp; năm 201";
                     }
                     //
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

                     //DataTable objNldKetQua = new DataTable();
                     //objNldKetQua = this.objNguoiLaoDong.getDataNldKetQuaByIDNldGioiThieuId(this.IDNldGioiThieu);
                     //if (objNldKetQua.Rows.Count > 0)
                     //{
                     //    if (objNldKetQua.Rows[0]["TrungTuyen"].ToString() == "True")
                     //    {
                     //        this.ckbTrungTuyen.Checked = true;
                     //        this.ckbKhongTrungTuyen.Checked = false;

                     //        this.NldKq_ViTriLamViec = this.objChucVu.getDataById(int.Parse(objNldKetQua.Rows[0]["IDChucVu"].ToString())).Rows[0]["NameChucVu"].ToString();
                     //        if (objNldKetQua.Rows[0]["NgayNhanViec"].ToString() != "")
                     //        {
                     //            this.NldKq_NgayDuKienNhanViec = DateTime.Parse(objNldKetQua.Rows[0]["NgayNhanViec"].ToString()).ToString("dd/MM/yyyy");
                     //        }
                     //        this.NldKq_ThoiGianThuViec = objNldKetQua.Rows[0]["ThoiGianThuViec"].ToString();
                     //    }
                     //    else
                     //    {
                     //        this.ckbTrungTuyen.Checked = false;
                     //        this.ckbKhongTrungTuyen.Checked = true;
                     //        this.NldKq_LyDoKhongTrungTuyen = objNldKetQua.Rows[0]["LyDoKhongTrungTuyen"].ToString();
                     //    }
                     //}
                 }
             }
        }
    } 
    #endregion
}