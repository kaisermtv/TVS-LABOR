using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_XemTinTuyenDung : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private ViTri objViTri = new ViTri();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private Mucluong objMucluong = new Mucluong();
    private TuyenDung objTuyenDung = new TuyenDung();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int IDNldTuVan = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    public int index = 1;
    public string sVitri = "", sMucluong = "", sDieukien = "", sDiadiem = "", sNuocNgoai = "";
    #endregion

    string page = "";

    

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        txtSearch.Focus();

        #region Lay bien truy van
        try
        {
            this.IDNldTuVan = int.Parse(Request.QueryString["IDNldTuVan"].ToString());
        }
        catch
        {
            this.IDNldTuVan = 0;
        }
        try
        {
            this.sVitri = Request.QueryString["vitri"].ToString();
        }
        catch
        {
            this.sVitri = "";
        }
        try
        {
            this.sMucluong = Request.QueryString["mucluong"].ToString();
        }
        catch
        {
            this.sMucluong = "";
        }
        try
        {
            this.sDieukien = Request.QueryString["dieukien"].ToString();
        }
        catch
        {
            this.sDieukien = "";
        }
        try
        {
            this.sDiadiem = Request.QueryString["diadiem"].ToString();
        }
        catch
        {
            this.sDiadiem = "";
        }
        try
        {
            this.sNuocNgoai = Request.QueryString["nuocngoai"].ToString();
        }
        catch
        {
            this.sNuocNgoai = "";
        }
       

        #endregion

        if (!Page.IsPostBack)
        {
            this.ddlIDChucVu.DataSource = this.objViTri.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameViTri";
            this.ddlIDChucVu.DataValueField = "ID";
            this.ddlIDChucVu.DataBind();

            this.ddlIDChucVu.SelectedValue = "0";

            this.ddlMucLuong.DataSource = this.objMucluong.getDataCategoryToCombobox();
            this.ddlMucLuong.DataTextField = "NameMucLuong";
            this.ddlMucLuong.DataValueField = "IdMucLuong";
            this.ddlMucLuong.DataBind();

            this.ddlMucLuong.SelectedValue = "0";

            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi");
            this.getData();

           
        }
        if(txtSearch.Value ==""| txtSearch==null)
        { 
        try
        {
            this.page = Request.QueryString["Page"].ToString();
            // nếu là CCPager request page
               getSearchData();
        }
        catch
        {
            //   return;
        }
       

        }
        
      
    }
    #endregion

    #region getData()
    private void getData()
    {
       
        this.objTable = this.objTuyenDung.getList(this.txtSearch.Value, int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlMucLuong.SelectedValue.ToString()),"", this.sVitri, this.sMucluong, this.sDiadiem, this.sNuocNgoai);
        cpTuyenDung.MaxPages = 1000;
        cpTuyenDung.PageSize = 12;
        cpTuyenDung.DataSource = this.objTable.DefaultView;
        cpTuyenDung.BindToControl = dtlTuyenDung;
        dtlTuyenDung.DataSource = cpTuyenDung.DataSourcePaged;
        dtlTuyenDung.DataBind();
        if (this.objTable.Rows.Count < 12)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }

        index = 1;
    }
    #endregion


    #region thực thi tìm kiếm
    private void getSearchData()
    {
        this.objTable = this.objTuyenDung.getList(this.txtSearch.Value, int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlMucLuong.SelectedValue.ToString()), "", "", "", "", this.sNuocNgoai);
        cpTuyenDung.MaxPages = 1000;
        cpTuyenDung.PageSize = 12;
        cpTuyenDung.DataSource = this.objTable.DefaultView;
        cpTuyenDung.BindToControl = dtlTuyenDung;
        dtlTuyenDung.DataSource = cpTuyenDung.DataSourcePaged;
        dtlTuyenDung.DataBind();
        if (this.objTable.Rows.Count < 12)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }

    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        getSearchData();

        index = 1;

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        ///////////////////////////
        // BỔ SUNG BẮT BUỘC NHẬP VÀO TRƯỜNG : NGÀY HẾT HIỆU LỰC ./

        if (this.txtIDChucVu.Value.Trim() == "" || this.txtIDDonVi.Value.Trim() == "" || txtNgayHetHan.Value.Trim() == "")
        {
            this.lblMsg.Text = "Vui lòng chọn thông tin đầy đủ trước khi ghi nhận";
            return;
        }
        int IDTuyenDung = 0;
        if (this.txtIDTuyenDung.Value.Trim() != "")
        {
            try
            {
                IDTuyenDung = int.Parse(this.txtIDTuyenDung.Value.Trim());
            }
            catch
            {
                IDTuyenDung = 0;
            }
        }
        int IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);
        DataTable objTmpNguoiLaoDong = this.objNguoiLaoDong.getDataNldDangKyById(IDNldDangKy);
        int IDNguoiLaoDong = 0;
        if (objTmpNguoiLaoDong.Rows.Count > 0)
        {
            IDNguoiLaoDong = int.Parse(objTmpNguoiLaoDong.Rows[0]["IDNguoiLaoDong"].ToString());
        }
        this.objNguoiLaoDong.setDataNldGioiThieu(IDTuyenDung, IDNldDangKy, IDNguoiLaoDong, int.Parse(this.txtIDDonVi.Value), int.Parse(this.txtIDChucVu.Value), DateTime.Now, Session["ACCOUNT"].ToString(), TVSSystem.CVOnlyDate(this.txtNgayHetHan.Value.ToString()));
        this.lblMsg.Text = "<span style = \"color:blue;\">Lưu dữ liệu thành công !</span>";
    } 
    #endregion

    #region ddl_SelectedIndexChanged
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSearchData();
    }
    #endregion
}