using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DangKyViecLamEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0, IDNldDangKy = 0, IDNldGioiThieu = 0, IDNldKetQua = 0;
    public string strBtnViecLamTrongNuoc = "", strBtnViecLamNgoai = "";
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();

    private ChucVu objChucVu = new ChucVu();
    private LoaiHopDong objLoaiHopDong = new LoaiHopDong();
    private TuyenDung objTuyenDung = new TuyenDung();
    private Provincer objProvincer = new Provincer();
    private District objDistrict = new District();
    private TuVan objTuVan = new TuVan();
    private Mucluong objMucluong = new Mucluong();
    private DataTable objTable = new DataTable();
    private DataTable objTableNldGioiThieu = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "ĐĂNG KÝ VIỆC LÀM";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        #region Lay thong tin so luong tin tuyen dung
        this.strBtnViecLamTrongNuoc = "Việc trong nước [ " + this.objTuyenDung.getDataCount(false) + " ]";
        #endregion
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
            this.IDNldDangKy = this.itemId;
        }
        catch
        {
            this.itemId = 0;
        }

        try
        {
            this.IDNldGioiThieu = int.Parse(Request.QueryString["idNldGT"].ToString());
        }
        catch
        {
            this.IDNldGioiThieu = 0;
        }
        
        if (!Page.IsPostBack)
        {
            this.ddlIDChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameChucVu";
            this.ddlIDChucVu.DataValueField = "IDChucVu";
            this.ddlIDChucVu.DataBind();

            this.ddlIDLoaiHopDong.DataSource = this.objLoaiHopDong.getDataCategoryToCombobox();
            this.ddlIDLoaiHopDong.DataTextField = "NameLoaiHopDong";
            this.ddlIDLoaiHopDong.DataValueField = "IDLoaiHopDong";
            this.ddlIDLoaiHopDong.DataBind();

            this.ddlIDTinh.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlIDTinh.DataTextField = "Name";
            this.ddlIDTinh.DataValueField = "Id";
            this.ddlIDTinh.DataBind();

            if (this.ddlIDTinh.Items.Count > 0)
            {
                this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
                this.ddlIDHuyen.DataTextField = "Name";
                this.ddlIDHuyen.DataValueField = "Id";
                this.ddlIDHuyen.DataBind();
            }
        }

        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objNguoiLaoDong.getDataNldDangKyById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtIDNldTuVan.Value = this.objTable.Rows[0]["IDNldTuVan"].ToString();

                this.IDNldDangKy = int.Parse(this.objTable.Rows[0]["IDNldDangKy"].ToString());
                this.txtIDNguoiLaoDong.Value = this.objTable.Rows[0]["IDNguoiLaoDong"].ToString();
                this.txtTenNguoiLaoDong.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                this.txtNoiDungKhac.Text = this.objTable.Rows[0]["NoiDungKhac"].ToString();
                this.txtTenCongViec.Text = this.objTable.Rows[0]["TenCongViec"].ToString();

                this.txtNgayDangKy.Value = DateTime.Parse(this.objTable.Rows[0]["NgayDangKy"].ToString()).ToString();

                this.lblMucLuong.Text = this.objTable.Rows[0]["MucLuongThapNhat"].ToString(); 

                this.ddlIDTinh.SelectedValue = this.objTable.Rows[0]["IDTinh"].ToString();

                this.lblIDTinh.Text = this.ddlIDTinh.SelectedItem.Text;

                this.ddlState.SelectedValue = this.objTable.Rows[0]["State"].ToString();

                if (this.ddlIDTinh.Items.Count > 0)
                {
                    this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
                    this.ddlIDHuyen.DataTextField = "Name";
                    this.ddlIDHuyen.DataValueField = "Id";
                    this.ddlIDHuyen.DataBind();
                }
                this.ddlIDHuyen.SelectedValue = this.objTable.Rows[0]["IDHuyen"].ToString();

                this.lblIDHuyen.Text = this.ddlIDHuyen.SelectedItem.Text;

                this.objTableNldGioiThieu = this.objNguoiLaoDong.getDataNldGioiThieuByNldDangKyId(this.IDNldDangKy);
                if (this.objTableNldGioiThieu.Rows.Count > 0)
                {
                    this.IDNldGioiThieu = int.Parse(this.objTableNldGioiThieu.Rows[0]["IDNldGioiThieu"].ToString());
                    this.txtIDChucVu.Value = this.objTableNldGioiThieu.Rows[0]["IDChucVu"].ToString();
                    this.txtIDDonVi.Value = this.objTableNldGioiThieu.Rows[0]["IDDonVi"].ToString();
                    this.txtNameChucVu.Text = this.objTableNldGioiThieu.Rows[0]["NameVitri"].ToString();
                    this.txtTenDonVi.Text = this.objTableNldGioiThieu.Rows[0]["TenDonVi"].ToString();

                    this.txtNgayGioiThieu.Value = DateTime.Parse(this.objTableNldGioiThieu.Rows[0]["NgayGioiThieu"].ToString()).ToString();
                }

                DataTable objTableNldKetQua = this.objNguoiLaoDong.getDataNldKetQuaByIDNldGioiThieuId(this.IDNldGioiThieu);
                if (objTableNldKetQua.Rows.Count > 0)
                {
                    this.IDNldKetQua = int.Parse(objTableNldKetQua.Rows[0]["IDNldKetQua"].ToString());
                    this.ddlIDChucVu.SelectedValue = objTableNldKetQua.Rows[0]["IDChucVu"].ToString();
                    this.txtIDDonVi1.Value = objTableNldKetQua.Rows[0]["IDDonVi"].ToString();
                    this.ddlIDLoaiHopDong.Text = objTableNldKetQua.Rows[0]["IDLoaiHopDong"].ToString();
                    this.txtTenDonVi1.Text = objTableNldKetQua.Rows[0]["TenDonVi"].ToString();
                    if (objTableNldKetQua.Rows[0]["NgayNhanViec"].ToString() != "")
                    {
                        this.txtNgayNhanViec.Value = DateTime.Parse(objTableNldKetQua.Rows[0]["NgayNhanViec"].ToString()).ToString();
                    }
                    if (objTableNldKetQua.Rows[0]["TrungTuyen"].ToString() != "")
                    {
                        try
                        {
                            this.rdbKetQuaTrungTuyen.Checked = bool.Parse(objTableNldKetQua.Rows[0]["TrungTuyen"].ToString());
                        }
                        catch
                        {
                            this.rdbKetQuaTrungTuyen.Checked = false;
                        }
                    }
                    this.rdbKetQuaKhongTrungTuyen.Checked = !this.rdbKetQuaTrungTuyen.Checked;

                    this.txtThoiGianThuViec.Text = objTableNldKetQua.Rows[0]["ThoiGianThuViec"].ToString();
                    this.txtLyDoKhongTrungTuyen.Text = objTableNldKetQua.Rows[0]["LyDoKhongTrungTuyen"].ToString();
                }
            }
        }

        this.txtTenNguoiLaoDong.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtIDNguoiLaoDong.Value.ToString().Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn người lao động cần tư vấn";
            this.txtIDNguoiLaoDong.Focus();
            return;
        }

        if (this.txtTenCongViec.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên công việc cần đăng ký";
            this.txtTenCongViec.Focus();
            return;
        }

        if (this.txtNgayDangKy.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày đăng ký";
            this.txtNgayDangKy.Focus();
            return;
        }

        if (this.objNguoiLaoDong.setDataNldDangKy(ref this.itemId, int.Parse(this.txtIDNguoiLaoDong.Value.ToString()), this.txtTenCongViec.Text, 0, int.Parse(this.ddlIDHuyen.SelectedValue.ToString()), int.Parse(this.ddlIDTinh.SelectedValue.ToString()), 0, this.ckbNuocNgoai.Checked, DateTime.Parse(this.txtNgayDangKy.Value.Trim()), this.txtNoiDungKhac.Text, Session["ACCOUNT"].ToString(), int.Parse(this.ddlState.SelectedValue.ToString())) == 1)
        {
            if (this.txtIDChucVu.Value.Trim() != "" && this.txtIDDonVi.Value.Trim() != "")
            {
                if (this.IDNldGioiThieu == 0)
                {
                    this.objTableNldGioiThieu = this.objNguoiLaoDong.getDataNldGioiThieuByNldDangKyId(this.IDNldDangKy);
                    if (this.objTableNldGioiThieu.Rows.Count > 0)
                    {
                        this.IDNldGioiThieu = int.Parse(this.objTableNldGioiThieu.Rows[0]["IDNldGioiThieu"].ToString());
                    }
                }
                this.objNguoiLaoDong.setDataNldGioiThieu(ref this.IDNldGioiThieu, this.IDNldDangKy, int.Parse(this.txtIDNguoiLaoDong.Value), int.Parse(this.txtIDDonVi.Value), int.Parse(this.txtIDChucVu.Value), DateTime.Now, Session["ACCOUNT"].ToString());
            }

            #region Luu ket qua gioi thieu viec lam
            if (this.rdbKetQuaTrungTuyen.Checked)
            {
                if (this.txtNgayNhanViec.Value.Trim() == "")
                {
                    this.lblMsg.Text = "Bạn chưa nhập ngày dự kiến nhận việc";
                    this.txtNgayNhanViec.Focus();
                    return;
                }

                if (this.ddlIDLoaiHopDong.SelectedValue.Trim() == "0")
                {
                    this.lblMsg.Text = "Bạn chưa chọn loại hợp đồng";
                    this.ddlIDLoaiHopDong.Focus();
                    return;
                }

                if (this.txtThoiGianThuViec.Text.Trim() == "")
                {
                    this.lblMsg.Text = "Bạn chưa nhập thời gian dự kiến thử việc";
                    this.txtThoiGianThuViec.Focus();
                    return;
                }
            }
            else
            {
                if (this.txtLyDoKhongTrungTuyen.Text.Trim() == "")
                {
                    this.lblMsg.Text = "Bạn chưa nhập lý do không trúng tuyển";
                    this.txtLyDoKhongTrungTuyen.Focus();
                    return;
                }
            }
            DateTime? NgayNhanViec;

            if (this.txtNgayNhanViec.Value.Trim() != "")
            {
                NgayNhanViec = DateTime.Parse(this.txtNgayNhanViec.Value.Trim());
            }
            else
            {
                NgayNhanViec = null;
            }

            if (this.rdbKetQuaTrungTuyen.Checked)
            {
                if (this.txtIDDonVi1.Value.Trim() != "" && this.txtNgayNhanViec.Value.Trim() != "")
                {
                    if (this.IDNldGioiThieu == 0)
                    {
                        DataTable objTableNldKetQua = this.objNguoiLaoDong.getDataNldKetQuaByIDNldGioiThieuId(this.IDNldGioiThieu);
                        if (objTableNldKetQua.Rows.Count > 0)
                        {
                            this.IDNldKetQua = int.Parse(objTableNldKetQua.Rows[0]["IDNldKetQua"].ToString());
                        }
                    }

                    this.objNguoiLaoDong.setDataNldKetQua(ref this.IDNldKetQua, this.IDNldGioiThieu, int.Parse(this.txtIDNguoiLaoDong.Value.Trim()), int.Parse(this.txtIDDonVi1.Value.Trim()), int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlIDLoaiHopDong.SelectedValue.ToString()), NgayNhanViec, this.txtThoiGianThuViec.Text, true, "");
                }
            }
            else if (this.rdbKetQuaKhongTrungTuyen.Checked)
            {
                if (this.IDNldGioiThieu == 0)
                {
                    DataTable objTableNldKetQua = this.objNguoiLaoDong.getDataNldKetQuaByIDNldGioiThieuId(this.IDNldGioiThieu);
                    if (objTableNldKetQua.Rows.Count > 0)
                    {
                        this.IDNldKetQua = int.Parse(objTableNldKetQua.Rows[0]["IDNldKetQua"].ToString());
                    }
                }

                this.objNguoiLaoDong.setDataNldKetQua(ref this.IDNldKetQua, this.IDNldGioiThieu, int.Parse(this.txtIDNguoiLaoDong.Value.Trim()), int.Parse(this.txtIDDonVi1.Value.Trim()), 0, 0, NgayNhanViec, "", false, this.txtLyDoKhongTrungTuyen.Text);
            }
            #endregion

            Response.Redirect("DangKyViecLamEdit.aspx?id=" + this.itemId + "&idNldGT=" + this.IDNldGioiThieu.ToString());
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DangKyViecLam.aspx");
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlIDTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
        this.ddlIDHuyen.DataTextField = "Name";
        this.ddlIDHuyen.DataValueField = "Id";
        this.ddlIDHuyen.DataBind();
    }
    #endregion
}