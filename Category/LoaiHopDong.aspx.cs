using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LoaiHopDong : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private LoaiHopDong objLoaiHopDong = new LoaiHopDong();
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
            this.txtSearch.Text = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblLoaiHopDong", "NameLoaiHopDong");
            this.getData();
        }
        this.txtSearch.Focus();
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objLoaiHopDong.getData(this.txtSearch.Text);
        cpLoaiHopDong.MaxPages = 1000;
        cpLoaiHopDong.PageSize = 15;
        cpLoaiHopDong.DataSource = this.objTable.DefaultView;
        cpLoaiHopDong.BindToControl = dtlLoaiHopDong;
        dtlLoaiHopDong.DataSource = cpLoaiHopDong.DataSourcePaged;
        dtlLoaiHopDong.DataBind();
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
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblLoaiHopDong", "NameLoaiHopDong", this.txtSearch.Text.Trim());
        #endregion
    }
    #endregion
}