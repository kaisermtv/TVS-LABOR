using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuyenDung : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private TuyenDung objTuyenDung = new TuyenDung();
    private ChucVu objChucVu = new ChucVu();
    private Mucluong objMucluong = new Mucluong();
    private SearchConfig objSearchConfig = new SearchConfig();
    public int itemId = 0, IdDonVi = 0;
    public string tenDonVi = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;

    public int index = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "TIN TUYỂN DỤNG";
        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
            this.objTuyenDung.setThuTuUuTien(this.itemId);
        }
        catch
        {
            this.itemId = 0;
        }
        try
        {
            this.IdDonVi = int.Parse(Request.QueryString["did"].ToString());
        }
        catch
        {
            this.IdDonVi = 0;
        }
        try
        {
            this.tenDonVi = Request.QueryString["n"].ToString();
        }
        catch
        {
            this.tenDonVi = "";
        }
        if (!Page.IsPostBack)
        {
            this.ddlIDChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameChucVu";
            this.ddlIDChucVu.DataValueField = "IDChucVu";
            this.ddlIDChucVu.DataBind();
            this.ddlIDChucVu.SelectedValue = "0";

            this.ddlIDMucLuong.DataSource = this.objMucluong.getDataCategoryToCombobox();
            this.ddlIDMucLuong.DataTextField = "NameMucLuong";
            this.ddlIDMucLuong.DataValueField = "IDMucLuong";
            this.ddlIDMucLuong.DataBind();
            this.ddlIDMucLuong.SelectedValue = "0";

            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblTuyenDung", "Mota");
            this.getData();
        }
        this.txtSearch.Focus();
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objTuyenDung.getList(this.txtSearch.Value, int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlIDMucLuong.SelectedValue.ToString()), this.tenDonVi);
        cpTuyenDung.MaxPages = 1000;
        cpTuyenDung.PageSize = 10;
        cpTuyenDung.DataSource = this.objTable.DefaultView;
        cpTuyenDung.BindToControl = dtlTuyenDung;
        dtlTuyenDung.DataSource = cpTuyenDung.DataSourcePaged;
        dtlTuyenDung.DataBind();
        if (this.objTable.Rows.Count < 10)
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

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblTuyenDung", "Mota", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion
}