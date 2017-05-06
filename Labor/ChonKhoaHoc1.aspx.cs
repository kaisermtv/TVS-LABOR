using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_ChonKhoaHoc1 : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private DtKhoaHoc objDtKhoaHoc = new DtKhoaHoc();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0, IDNguoiLaoDong = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}

        try
        {
            this.IDNguoiLaoDong = int.Parse(Request.QueryString["IdNguoiLaoDong"].ToString());
        }
        catch
        {
            this.IDNguoiLaoDong = 0;
        }

        this.txtIDNguoiLaoDong.Value = this.IDNguoiLaoDong.ToString();

        if (!Page.IsPostBack)
        {
            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi");
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objDtKhoaHoc.getData();
        cpKhoaHoc.MaxPages = 1000;
        cpKhoaHoc.PageSize = 15;
        cpKhoaHoc.DataSource = this.objTable.DefaultView;
        cpKhoaHoc.BindToControl = dtlKhoaHoc;
        dtlKhoaHoc.DataSource = cpKhoaHoc.DataSourcePaged;
        dtlKhoaHoc.DataBind();
        if (this.objTable.Rows.Count < 9)
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
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtMucHoTro.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức hỗ trợ";
            this.txtMucHoTro.Focus();
            return;
        }
        float tmpMucHoTro = 0;
        try
        {
            tmpMucHoTro = float.Parse(this.txtMucHoTro.Value);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập mức hỗ trợ";
            this.txtMucHoTro.Focus();
            return;
        }

        if (this.objNguoiLaoDong.setNldDaoTaoData(0, int.Parse(this.txtIDNguoiLaoDong.Value), int.Parse(this.txtIdDtKhoaHoc.Value), this.txtTruongHoc.Value, this.txtDiaChiHoc.Value, this.txtKhoaHoc.Value, this.txtDTLienHe.Value, 1) == 1)
        {
            this.lblMsg.Text = "<span style = \"color:blue;\">Lưu dữ liệu thành công !</span>";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DaoTaoNghe.aspx");
    }
    #endregion
}