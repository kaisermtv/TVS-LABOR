using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_PhieuTuVan : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTableNguoiLaoDong = new DataTable();
    private DataTable objTableNldTuVan = new DataTable();
    private DataTable objTableNldDaoTao = new DataTable();
    private DataTable objTableNldCongTac = new DataTable();

    private Account objAccount = new Account();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private NgoaiNgu objNgoaiNgu = new NgoaiNgu();
    private TinHoc objTinHoc = new TinHoc();
    private DanToc objDanToc = new DanToc();
    private TonGiao objTonGiao = new TonGiao();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private int IDNldTuVan = 0;
    public string NLDHoten = "", NLDNgaySinh = "", NLDCMND = "", NLDNgayCapCMND = "", NLNoiCap = "", NLDBHXH = "", NLDDienThoai = "", NLDEmail = "", NLDDanToc = "", NLDTonGiao = "", NLDMucLuongTN = "", NLDLyDoTN = "", NLDDNDaLienHe = "";
    public string NLDNoiThuongTru = "", NLDDiaChi = "", NLDSucKhoe = "", NLDChieuCao = "", NLDCanNang = "", NLDTrinhDoPhoThong = "", NLDNgoaiNgu = "", NLDTinHoc = "", NLDTrinhDoKyNangNghe = "", NLDKhaNangNoiTroi = "";
    public string NLDViTriCongViec = "", NLDMucLuongThapNhat = "", NLDDieuKienLamViec = "", NLDDiaDiemLamViec = "", NLDNoiDungKhac = "", NLDNgayTuVan = "";
    public string NLDQuaTrinhDaoTao_CN1 = "", NLDQuaTrinhDaoTao_CM1 = "", NLDQuaTrinhDaoTao_CN2 = "", NLDQuaTrinhDaoTao_CM2 = "", NLDQuaTrinhDaoTao_CN3 = "", NLDQuaTrinhDaoTao_CM3 = "";
    public string NLDQuaTrinhCongTac_DV1 = "", NLDQuaTrinhCongTac_TG1 = "", NLDQuaTrinhCongTac_VT1 = "", NLDQuaTrinhCongTac_DV2 = "", NLDQuaTrinhCongTac_TG2 = "", NLDQuaTrinhCongTac_VT2 = "", NLDQuaTrinhCongTac_DV3 = "", NLDQuaTrinhCongTac_TG3 = "", NLDQuaTrinhCongTac_VT3 = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["ACCOUNT"] == null)
        //{
        //    Response.Redirect("../Login.aspx");
        //}
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

            if (this.objTableNldTuVan.Rows.Count > 0)
            {
                this.objTableNguoiLaoDong = this.objNguoiLaoDong.getDataById(int.Parse(this.objTableNldTuVan.Rows[0]["IDNguoiLaoDong"].ToString()));
                if (this.objTableNguoiLaoDong.Rows.Count > 0)
                {
                    this.NLDHoten = this.objTableNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                    this.NLDNgaySinh = DateTime.Parse(this.objTableNguoiLaoDong.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    this.NLDCMND = this.objTableNguoiLaoDong.Rows[0]["CMND"].ToString();
                    this.NLDNgayCapCMND = DateTime.Parse(this.objTableNguoiLaoDong.Rows[0]["NgayCapCMND"].ToString()).ToString("dd/MM/yyyy");
                    this.NLNoiCap = this.objTableNguoiLaoDong.Rows[0]["NoiCap"].ToString();
                    this.NLDBHXH = this.objTableNguoiLaoDong.Rows[0]["BHXH"].ToString();
                    this.NLDDienThoai = this.objTableNguoiLaoDong.Rows[0]["DienThoai"].ToString();
                    this.NLDEmail = this.objTableNguoiLaoDong.Rows[0]["Email"].ToString();
                    this.NLDDanToc = this.objDanToc.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDDanToc"].ToString()));
                    this.NLDTonGiao = this.objTonGiao.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDTonGiao"].ToString()));
                    this.NLDNoiThuongTru = this.objTableNguoiLaoDong.Rows[0]["NoiThuongTru"].ToString();
                    this.NLDDiaChi = this.objTableNguoiLaoDong.Rows[0]["DiaChi"].ToString();
                    this.NLDSucKhoe = this.objTableNguoiLaoDong.Rows[0]["SucKhoe"].ToString();
                    this.NLDChieuCao = this.objTableNguoiLaoDong.Rows[0]["ChieuCao"].ToString();
                    this.NLDCanNang = this.objTableNguoiLaoDong.Rows[0]["CanNang"].ToString();
                    this.NLDTrinhDoPhoThong = this.objTrinhDoPhoThong.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDTrinhDoPhoThong"].ToString()));
                    this.NLDNgoaiNgu = this.objNgoaiNgu.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDNgoaiNgu"].ToString()));
                    this.NLDTinHoc = this.objTinHoc.getDataNameById(int.Parse(this.objTableNguoiLaoDong.Rows[0]["IDTinHoc"].ToString()));
                    this.NLDTrinhDoKyNangNghe = this.objTableNguoiLaoDong.Rows[0]["TrinhDoKyNangNghe"].ToString();
                    this.NLDKhaNangNoiTroi = this.objTableNguoiLaoDong.Rows[0]["KhaNangNoiTroi"].ToString();

                    this.objTableNldDaoTao = this.objNguoiLaoDong.getDataNldQuaTrinhDaoTao(int.Parse(this.objTableNldTuVan.Rows[0]["IDNguoiLaoDong"].ToString()));

                    if (this.objTableNldDaoTao.Rows.Count > 0)
                    {
                        NLDQuaTrinhDaoTao_CN1 = this.objTableNldDaoTao.Rows[0]["DonVi"].ToString();
                        NLDQuaTrinhDaoTao_CM1 = this.objTableNldDaoTao.Rows[0]["NameTrinhdoChuyenMon"].ToString();
                    }

                    if (this.objTableNldDaoTao.Rows.Count > 1)
                    {
                        NLDQuaTrinhDaoTao_CN2 = this.objTableNldDaoTao.Rows[1]["DonVi"].ToString();
                        NLDQuaTrinhDaoTao_CM2 = this.objTableNldDaoTao.Rows[1]["NameTrinhdoChuyenMon"].ToString();
                    }

                    if (this.objTableNldDaoTao.Rows.Count > 2)
                    {
                        NLDQuaTrinhDaoTao_CN3 = this.objTableNldDaoTao.Rows[2]["DonVi"].ToString();
                        NLDQuaTrinhDaoTao_CM3 = this.objTableNldDaoTao.Rows[2]["NameTrinhdoChuyenMon"].ToString();
                    }

                    this.objTableNldCongTac = this.objNguoiLaoDong.getDataNldQuatrinhCongTac(int.Parse(this.objTableNldTuVan.Rows[0]["IDNguoiLaoDong"].ToString()));

                    if (this.objTableNldCongTac.Rows.Count > 0)
                    {
                        NLDQuaTrinhCongTac_DV1 = this.objTableNldCongTac.Rows[0]["DonVi"].ToString();
                        NLDQuaTrinhCongTac_TG1 = DateTime.Parse(this.objTableNldCongTac.Rows[0]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(this.objTableNldCongTac.Rows[0]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
                        NLDQuaTrinhCongTac_VT1 = this.objTableNldCongTac.Rows[0]["NameChucVu"].ToString();
                    }

                    if (this.objTableNldCongTac.Rows.Count > 1)
                    {
                        NLDQuaTrinhCongTac_DV2 = this.objTableNldCongTac.Rows[1]["DonVi"].ToString();
                        NLDQuaTrinhCongTac_TG2 = DateTime.Parse(this.objTableNldCongTac.Rows[1]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(this.objTableNldCongTac.Rows[1]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
                        NLDQuaTrinhCongTac_VT2 = this.objTableNldCongTac.Rows[1]["NameChucVu"].ToString();
                    }

                    if (this.objTableNldCongTac.Rows.Count > 2)
                    {
                        NLDQuaTrinhCongTac_DV3 = this.objTableNldCongTac.Rows[2]["DonVi"].ToString();
                        NLDQuaTrinhCongTac_TG3 = DateTime.Parse(this.objTableNldCongTac.Rows[2]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(this.objTableNldCongTac.Rows[2]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
                        NLDQuaTrinhCongTac_VT3 = this.objTableNldCongTac.Rows[2]["NameChucVu"].ToString();
                    }
                }

                if (this.objTableNldTuVan.Rows[0]["MucLuongTN"].ToString() != "0")
                {
                    this.NLDMucLuongTN = String.Format("{0:0,0}", double.Parse(this.objTableNldTuVan.Rows[0]["MucLuongTN"].ToString())) + " đ";
                }

                this.NLDLyDoTN = this.objTableNldTuVan.Rows[0]["LyDoTN"].ToString();
                this.NLDDNDaLienHe = this.objTableNldTuVan.Rows[0]["DNDaLienHe"].ToString();

                this.ckbTuVanPhapLuat.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanPhapLuat"].ToString());
                this.ckbTuVanViecLam.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanViecLam"].ToString());
                this.ckbTuVanBHTN.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanBHTN"].ToString());
                this.ckbTuVanKhac.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanKhac"].ToString());

                this.NLDViTriCongViec = this.objTableNldTuVan.Rows[0]["ViTriCongViec"].ToString();
                if (this.objTableNldTuVan.Rows[0]["MucLuongThapNhat"].ToString() != "0")
                {
                    this.NLDMucLuongThapNhat = String.Format("{0:0,0}", double.Parse(this.objTableNldTuVan.Rows[0]["MucLuongThapNhat"].ToString()))+" đ";
                }
                this.NLDDieuKienLamViec = this.objTableNldTuVan.Rows[0]["DieuKienLamViec"].ToString();
                this.NLDDiaDiemLamViec = this.objTableNldTuVan.Rows[0]["DiaDiemLamViec"].ToString();
                this.NLDNoiDungKhac = this.objTableNldTuVan.Rows[0]["NoiDungKhac"].ToString();

                if (this.objTableNldTuVan.Rows[0]["NgayTuVan"].ToString() != "")
                {
                    this.NLDNgayTuVan = "Vinh, ngày " + DateTime.Parse(this.objTableNldTuVan.Rows[0]["NgayTuVan"].ToString()).ToString("dd") + " tháng " + DateTime.Parse(this.objTableNldTuVan.Rows[0]["NgayTuVan"].ToString()).ToString("MM") + " năm " + DateTime.Parse(this.objTableNldTuVan.Rows[0]["NgayTuVan"].ToString()).ToString("yyyy");
                }
            }
        }
    }
    #endregion
}