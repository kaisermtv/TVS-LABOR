using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TuVan : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private SearchConfig objSearchConfig = new SearchConfig();
    private string hoVaTen = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "HỒ SƠ TƯ VẤN";
        try
        {
            this.hoVaTen = Request.QueryString["n"].ToString();
        }
        catch
        {
            this.hoVaTen = "";
        }
        if (!Page.IsPostBack)
        {
            this.getData();
        }
        this.txtSearch.Focus();
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objNguoiLaoDong.getDataTblNldTuVan1(this.txtSearch.Value.ToString(), this.hoVaTen);
        cpTuVanViecLam.MaxPages = 2000;
        cpTuVanViecLam.PageSize = 10;
        cpTuVanViecLam.DataSource = this.objTable.DefaultView;
        cpTuVanViecLam.BindToControl = dtlTuVanViecLam;
        dtlTuVanViecLam.DataSource = cpTuVanViecLam.DataSourcePaged;
        dtlTuVanViecLam.DataBind();
        if (this.objTable.Rows.Count < 10)
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
    }
    #endregion
}