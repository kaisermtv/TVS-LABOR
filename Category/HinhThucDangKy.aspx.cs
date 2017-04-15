using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_HinhThucDangKy : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private HinhThucDangKy objHinhThucDangKy = new HinhThucDangKy();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0;
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
        if (!Page.IsPostBack)
        {
            this.txtSearch.Text = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblHinhThucDangKy", "NameHinhThucDangKy");
            this.getData();
        }
        this.txtSearch.Focus();
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objHinhThucDangKy.getData(this.txtSearch.Text);
        cpHinhThucDangKy.MaxPages = 1000;
        cpHinhThucDangKy.PageSize = 15;
        cpHinhThucDangKy.DataSource = this.objTable.DefaultView;
        cpHinhThucDangKy.BindToControl = dtlHinhThucDangKy;
        dtlHinhThucDangKy.DataSource = cpHinhThucDangKy.DataSourcePaged;
        dtlHinhThucDangKy.DataBind();
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
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblHinhThucDangKy", "NameHinhThucDangKy", this.txtSearch.Text.Trim());
        #endregion
    }
    #endregion
}