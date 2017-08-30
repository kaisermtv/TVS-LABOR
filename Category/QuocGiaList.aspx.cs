using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_QuocGiaList : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private QuocGia objQuocGia = new QuocGia();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0;
    public int tt = 1;
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
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objQuocGia.getData("");
        cpTinHoc.MaxPages = 1000;
        cpTinHoc.PageSize = 12;
        cpTinHoc.DataSource = this.objTable.DefaultView;
        cpTinHoc.BindToControl = dtlTinHoc;
        dtlTinHoc.DataSource = cpTinHoc.DataSourcePaged;
        tt = 1;
        dtlTinHoc.DataBind();
        tt = 1;
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

}